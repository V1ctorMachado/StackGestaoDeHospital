using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Medico : Funcionario
    {

        public string CRM { get; set; }
        public IList<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

        public Medico() {}
        public Medico(string crm, IList<Especialidade> especialidades)
        {
            SetCrm(crm);
            SetEspecialidades(especialidades);
        }

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
