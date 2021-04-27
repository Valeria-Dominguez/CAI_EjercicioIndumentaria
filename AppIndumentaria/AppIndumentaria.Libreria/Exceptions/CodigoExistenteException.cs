using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Exceptions
{
    public class CodigoExistenteException : Exception
    {
        public CodigoExistenteException(string message) : base(message)
        {
        }
        public CodigoExistenteException() : base("El código ingresado ya existe\n")
        {
        }
    }
}
