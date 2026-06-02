using System;
using System.Collections.Generic;

namespace StackGestaoDeHospital.Model
{
    public class Departamento
    {
        protected Departamento()
        {

        }

        public Departamento(string nome)
        {
            SetNome(nome);
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; } = string.Empty;
        public virtual IList<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public void SetNome(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio.", nameof(Nome));
            if (value.Length > 100)
                throw new ArgumentException("Nome muito grande", nameof(Nome));
            Nome = value.Trim();
        }
    }
}