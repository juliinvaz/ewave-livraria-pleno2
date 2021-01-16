using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Livraria.Domain.Enums
{
    public enum ELivroSituacao
    {
        [Description("Disponivel")]
        Disponivel = 1,

        [Description("Emprestado")]
        Emprestado = 2,

        [Description("Reservado")]
        Reservado = 3,

        [Description("Inativo")]
        Inativo = 4
    }
}
