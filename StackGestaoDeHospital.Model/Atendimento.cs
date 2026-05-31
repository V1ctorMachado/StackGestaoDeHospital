using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime Data { get; protected set; }
        public string Queixa { get; protected set; }
        public string? Diagnostico { get; protected set; }
        public int Status { get; protected set; }
        public Especialidade Especialidade { get; protected set; }
        public Enfermeiro Enfermeiro { get; protected set; }
        public Medico Medico { get; protected set; }

        public Atendimento() { }
        public Atendimento(string queixa, string? diagnostico, int status, Especialidade especialidade, Enfermeiro enfermeiro, Medico medico)
        {
            Data = DateTime.Now;
            SetQueixa(queixa);
            SetDiagnostico(diagnostico);
            SetStatus(status);
            SetEspecialidade(especialidade);
            SetEnfermeiro(enfermeiro);
            SetMedico(medico);
        }

        public void SetQueixa(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Queixa não pode ser vazia.", nameof(Queixa));
            if (value.Length > 1000)
                throw new ArgumentException("Queixa é muito longa.", nameof(Queixa));
            Queixa = value;
        }

        public void SetDiagnostico(string? value)
        {
            if (value != null && value.Length > 1000)
                throw new ArgumentException("Diagnóstico é muito longo.", nameof(Diagnostico));
            Diagnostico = value;
        }

        public void SetStatus(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Status), "Status deve ser maior ou igual a zero.");
            Status = value;
        }

        public void SetEspecialidade(Especialidade value)
        {
            Especialidade = value ?? throw new ArgumentNullException(nameof(Especialidade));
        }

        public void SetEnfermeiro(Enfermeiro value)
        {
            Enfermeiro = value ?? throw new ArgumentNullException(nameof(Enfermeiro));
        }

        public void SetMedico(Medico value)
        {
            Medico = value ?? throw new ArgumentNullException(nameof(Medico));
        }

    }
}
