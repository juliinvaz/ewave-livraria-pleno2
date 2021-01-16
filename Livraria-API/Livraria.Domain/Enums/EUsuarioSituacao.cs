using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Livraria.Domain.Enums
{
    public enum EUsuarioSituacao
    {
        [Description("Ativo")]
        Ativo = 1,

        [Description("Inativo")]
        Inativo = 2
    }
}
