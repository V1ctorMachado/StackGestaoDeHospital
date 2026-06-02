using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public enum SexoEnum
    {
        Masculino = 1,
        Feminino = 2,
        Outro = 3
    }

    public enum TipoSanguineoEnum
    {
        APositivo = 1,
        ANegativo = 2,
        BPositivo = 3,
        BNegativo = 4,
        ABPositivo = 5,
        ABNegativo = 6,
        OPositivo = 7,
        ONegativo = 8
    }

    public enum StatusAtendimentoEnum
    {
        Aberto = 1,
        EmTriagem = 2,
        EmAtendimento = 3,
        Concluido = 4
    }
}