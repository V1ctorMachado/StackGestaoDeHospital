using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public abstract class Funcionario : Pessoa
    {
        protected Funcionario()
        {
            
        }
        protected Funcionario(int id, string nome, string sobrenome, string cPF, DateTime dataNascimento, string matricula, decimal salario, Departamento departamento) : base(id, nome, sobrenome, cPF, dataNascimento)
        {
            Matricula = matricula;
            Salario = salario;
            Departamento = departamento;
        }

        public string Matricula { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public Departamento Departamento { get; set; }
      

        public void SetDepartamento(Departamento value)
        {
            Departamento = value ?? throw new ArgumentNullException(nameof(value));
        }

    }
}
