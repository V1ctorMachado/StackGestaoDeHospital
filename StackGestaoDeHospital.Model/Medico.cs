using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    class Medico : Funcionario
    {

        public string CRM { get; set; }
        public Medico(string crm)
        {
            CRM = crm;
        }
    }
}
