using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Livraria.Infra.Exeptions
{
    public class LivrariaException : Exception
    {
        
        public LivrariaException(string msg) : base(msg)
        {
            
        }
    }
}
