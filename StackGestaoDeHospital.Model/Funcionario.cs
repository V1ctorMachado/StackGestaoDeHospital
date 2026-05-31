using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public abstract class Funcionario : Pessoa
    {
        protected Funcionario(int id, string nome, string sobrenome, string cPF, DateTime dataNascimento, string matricula, decimal salario) : base(id, nome, sobrenome, cPF, dataNascimento)
        {
            Matricula = matricula;
            Salario = salario;
        }

        public string Matricula { get; set; } = string.Empty;
        public decimal Salario { get; set; }

    }
}
