using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace StackGestaoDeHospital.Model
{
    public class Exame
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string? Resultado { get; set; }
        public StatusExame Status { get; set; } = StatusExame.Solicitado;

        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; } = null!;
    }
}
