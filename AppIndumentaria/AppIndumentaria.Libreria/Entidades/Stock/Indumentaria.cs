using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public abstract class Indumentaria
    {
        TipoIndumentaria _tipo;
        int _codigo;
        int _stock;
        string _talle;
        double _precio;

        public TipoIndumentaria Tipo { get => _tipo; set => _tipo = value; }
        public int Codigo { get => _codigo; set => _codigo = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public string Talle { get => _talle; set => _talle = value; }
        public double Precio { get => _precio; set => _precio = value; }

        protected Indumentaria(TipoIndumentaria tipo, int codigo, int stock, string talle, double precio)
        {
            _tipo = tipo;
            _codigo = codigo;
            _stock = stock;
            _talle = talle;
            _precio = precio;
        }

        public override string ToString()
        {
            return GetDetalle();
        }

        public override bool Equals(object obj)
        {
            bool igual = false;
            Indumentaria indumentaria = (Indumentaria)obj;
            if (this.Codigo == indumentaria.Codigo)
            {
                igual = true; ;
            }
            return igual;
        }

        public abstract string GetDetalle();

    }    
}
