using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Exceptions
{
    public class CodigoInexistenteException : Exception
    {
        public CodigoInexistenteException(string message) : base(message)
        {
        }
        public CodigoInexistenteException() : base("El código ingresado no existe\n")
        {
        }
    }
}
