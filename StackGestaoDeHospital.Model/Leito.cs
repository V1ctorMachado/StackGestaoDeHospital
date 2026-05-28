using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public class Leito
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public TipoLeito Tipo { get; set; }
        public bool Ocupado { get; set; }

        public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}