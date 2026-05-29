using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace StackGestaoDeHospital.Model
{
    public class Prescricao
    {
        public int Id { get; set; }
        public DateTime DataPrescricao { get; set; }
        public string Dosagem { get; set; } = string.Empty;
        public string Frequencia { get; set; } = string.Empty;
        public string? Duracao { get; set; }
        public string? Observacoes { get; set; }

        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; } = null!;

        public int MedicamentoId { get; set; }
        public Medicamento Medicamento { get; set; } = null!;

        public int MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
    }
}
