using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Controller
{
     public class AtendimentoComando
    {
        public string? Queixa { get; set; }
        public string? Diagnostico { get; set; }
        public virtual Especialidade? Especialidade { get; set; }

    }
}
