using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    class Enfermeiro : Funcionario
    {

        public string CRE { get; set; }
        public Enfermeiro(string Cre)
        {
            CRE = Cre;
        }

    }
}
