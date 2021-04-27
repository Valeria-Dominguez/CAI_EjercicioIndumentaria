using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public class Venta
    {
        List<VentaItem> _items;
        Cliente _cliente;
        int _estado;
        int _codigo;

        public enum EnumEstado
        {
            Iniciada = 1,
            Procesada = 2,
            Devuelto = 3
        }

        public Venta(Cliente cliente, int codigo)
        {
            _items = new List<VentaItem>();
            Cliente = cliente;
            Estado = (int)EnumEstado.Iniciada; 
            Codigo = codigo;
        }

        public List<VentaItem> Items { get => _items; set => _items = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public int Codigo { get => _codigo; set => _codigo = value; }


        public double GetTotalPedido()
        {
            double totalPedido = 0;
            foreach (VentaItem item in this.Items)
            {
                totalPedido = totalPedido + item.GetTotal();
            }
            return totalPedido;
        }

        public double GetTotalPrendas()
        {
            int cantPrendas = 0;
            foreach (VentaItem item in this.Items)
            {
                cantPrendas = cantPrendas + item.Cantidad;
            }
            return cantPrendas;
        }
        public string GetListadoOrden()
        {
            return $"{this.Codigo}) {this.Cliente.Apellido}, {this.Cliente.Nombre}, {this.GetTotalPrendas()}, ${this.GetTotalPedido()}";
        }
    }
}
