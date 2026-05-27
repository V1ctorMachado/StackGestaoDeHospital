using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    class Atendimento
    {
        public DateTime Data { get; set; }
        public string Queixa { get; set; }
        public string? Diagnostico { get; set; }
        public int Status { get; set; }
    }
}
