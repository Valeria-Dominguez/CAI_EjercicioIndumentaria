using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public class Pantalon : Indumentaria
    {
        string _material;
        bool _tieneBolsillos;

        public string Material { get => _material; set => _material = value; }
        public bool TieneBolsillos { get => _tieneBolsillos; set => _tieneBolsillos = value; }

        public Pantalon(TipoIndumentaria tipo, int codigo, int stock, string talle, double precio, string material, bool tieneBolsillos) : base(tipo, codigo, stock, talle, precio)
        {
            this._material = material;
            this._tieneBolsillos = tieneBolsillos;
        }

        public override string GetDetalle()
        {
            string descripcionBolsillo = "";
            if (this.TieneBolsillos == true)
            {
                descripcionBolsillo = "Con bolsillos";
            }
            else
            {
                descripcionBolsillo = "Sin bolsillo";
            }
            return $"{this.Tipo} Código) {this.Codigo} -  Stock: {this.Stock} unidades - Talle {this.Talle} - Material {this.Material} - {descripcionBolsillo} - Precio: {this.Precio}";
        }
    }
}
