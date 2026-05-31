using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Enfermeiro : Funcionario
    {
        public Enfermeiro()
        {
            
        }
        public Enfermeiro(int id, string nome, string sobrenome, string cPF, DateTime dataNascimento, string matricula, decimal salario, string cRE) : base(id, nome, sobrenome, cPF, dataNascimento, matricula, salario)
        {
            CRE = cRE;
        }

        public string CRE { get; set; } = string.Empty;

    }
}
