using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StackGestaoDeHospital.Model
{
    public class Medico : Funcionario
    {
        public Medico()
        {

        }

        public Medico(int id, string nome, string sobrenome, string cPF, DateTime dataNascimento,
                      string matricula, decimal salario, Departamento departamento,
                      string cRM, IList<Especialidade> especialidades)
            : base(id, nome, sobrenome, cPF, dataNascimento, matricula, salario, departamento)
        {
            SetCrm(cRM);
            SetEspecialidades(especialidades);
        }

        public string CRM { get; set; }
        public virtual IList<Especialidade> Especialidades { get; set; } = new List<Especialidade>();


        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string EspecialidadesExibicao => string.Join(", ", Especialidades?.Select(e => e.Descricao) ?? Array.Empty<string>());



        public void SetEspecialidades(IList<Especialidade> especialidades)
        {
            Especialidades.Clear();
            foreach (Especialidade especialidade in especialidades)
            {
                Especialidades.Add(especialidade);
            }
        }
        public void SetCrm(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CRM não pode ser vazio.", nameof(CRM));

            if (value.Length > 20)
                throw new ArgumentException("CRM é muito longo.", nameof(CRM));

            CRM = value.Trim();
        }
    }
}
