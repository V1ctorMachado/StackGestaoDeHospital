using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace StackGestaoDeHospital.Model
{
    public class Internacao
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataAlta { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string? Observacoes { get; set; }
        public StatusInternacao Status { get; set; } = StatusInternacao.Ativa;

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public int? LeitoId { get; set; }
        public Leito? Leito { get; set; }

        public int? MedicoResponsavelId { get; set; }
        public Medico? MedicoResponsavel { get; set; }
    }
}
