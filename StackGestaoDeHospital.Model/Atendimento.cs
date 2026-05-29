using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Queixa { get; set; } = string.Empty;
        public string? Diagnostico { get; set; }
        public int Status { get; set; }
    }
}
