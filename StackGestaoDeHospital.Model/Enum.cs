using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.Model
{
    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2,
        Outro = 3
    }

    public enum TipoSanguineo
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

    public enum StatusAtendimento
    {
        Aberto = 1,
        EmAtendimento = 2,
        Concluido = 3,
        Cancelado = 4
    }

    public enum TipoLeito
    {
        Enfermaria = 1,
        Apartamento = 2,
        UTI = 3,
        CTI = 4
    }

    public enum StatusInternacao
    {
        Ativa = 1,
        AltaConcedida = 2,
        Obito = 3,
        Transferida = 4
    }

    public enum StatusExame
    {
        Solicitado = 1,
        Realizado = 2,
        Cancelado = 3
    }
}