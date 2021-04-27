using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Exceptions
{
    public class SinStockException : Exception
    {
        public SinStockException(string message) : base(message)
        {
        }
        public SinStockException() : base("No hay stock")
        {
        }
    }
}
