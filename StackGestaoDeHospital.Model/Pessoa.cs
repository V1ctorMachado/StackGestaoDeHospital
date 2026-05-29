using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }


    }
}
