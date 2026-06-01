using System;
using System.Collections.Generic;
using System.Text;

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
        public IList<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

       

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
