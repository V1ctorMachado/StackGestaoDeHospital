using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

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
            Disponivel = false;
        }

        public string Matricula { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public virtual Departamento Departamento { get; set; }
        public bool Disponivel { get; private set; }


        [NotMapped]
        public string NomeCompletoMatricula => $"{NomeCompleto} - {Matricula}".Trim();


        public void SetDisponivel(bool value)
        {
            Disponivel = value;
        }

        public void SetDepartamento(Departamento value)
        {
            Departamento = value ?? throw new ArgumentNullException(nameof(value));
        }

    }
}
