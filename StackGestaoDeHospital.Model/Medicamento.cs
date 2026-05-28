using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Generic;

namespace StackGestaoDeHospital.Model
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? PrincipioAtivo { get; set; }
        public string? Apresentacao { get; set; }
        public string? Fabricante { get; set; }

        public ICollection<Prescricao> Prescricoes { get; set; } = new List<Prescricao>();
    }
}
