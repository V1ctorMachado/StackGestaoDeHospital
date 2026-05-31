using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public abstract class Funcionario : Pessoa
    {

        public string Matricula { get; set; } = string.Empty;
        public decimal Salario { get; set; }

    }
}
