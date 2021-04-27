using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public class VentaItem
    {
        Indumentaria _prenda;
        int _cantidad;

        public Indumentaria Prenda { get => _prenda; set => _prenda = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        public VentaItem(Indumentaria prenda, int cantidad)
        {
            _prenda = prenda;
            _cantidad = cantidad;
        }

        public double GetTotal()
        {
            return this.Prenda.Precio * this.Cantidad;
        }
    }
}
