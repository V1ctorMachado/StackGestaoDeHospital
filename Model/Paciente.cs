using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    class Paciente : Pessoa
    {

        public string NumeroCarteirinha { get; set; }
        public string PlanoSaude { get; set; }
        public Paciente(string numeroCarteirinha, string planoSaude)
        {
            NumeroCarteirinha = numeroCarteirinha;
            PlanoSaude = planoSaude;
        }
    }
}
