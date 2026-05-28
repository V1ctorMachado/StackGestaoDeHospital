using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Paciente : Pessoa
    {

        public string NumeroCarteirinha { get; set; } = string.Empty;
        public string PlanoSaude { get; set; } = string.Empty;
    }
}
