using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    class Medico : Funcionario
    {

        public string CRM { get; set; }
        public Especialidade Especialidade { get; set; }
        public Medico(string crm, Especialidade especialidade)
        {
            CRM = crm;
            Especialidade = especialidade;
        }
    }
}
