using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Exceptions
{
    public class TipoInvalidoException : Exception
    {
        public TipoInvalidoException(string message) : base(message)
        {
        }
        public TipoInvalidoException() : base("Tipo inválido\n")
        {
        }
    }
}
