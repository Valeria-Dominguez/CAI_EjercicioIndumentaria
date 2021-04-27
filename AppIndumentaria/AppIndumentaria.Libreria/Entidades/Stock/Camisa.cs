using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public class Camisa : Indumentaria
    {
        bool _tieneEstampado;
        string _tipoManga;

        public bool TieneEstampado { get => _tieneEstampado; set => _tieneEstampado = value; }
        public string TipoManga { get => _tipoManga; set => _tipoManga = value; }

        public Camisa(TipoIndumentaria tipo, int codigo, int stock, string talle, double precio, bool tieneEstampado, string tipoManga) : base(tipo, codigo, stock, talle, precio)
        {
            this._tieneEstampado = tieneEstampado;
            this._tipoManga = tipoManga;
        }

        public override string GetDetalle()
        {
            string descripcionEstamapdo = "";
            if (this.TieneEstampado== true)
            {
                descripcionEstamapdo = "Estampado";
            }
            else
            {
                descripcionEstamapdo = "Liso";
            }
            return $"Origen: {this.Tipo.Origen} - %Algodón: {this.Tipo.PorcentajeAlgodon} Código) {this.Codigo} -  Stock: {this.Stock} unidades - Talle {this.Talle} - Manga {this.TipoManga} - {descripcionEstamapdo} - Precio: {this.Precio}";
        }
    } 
}
