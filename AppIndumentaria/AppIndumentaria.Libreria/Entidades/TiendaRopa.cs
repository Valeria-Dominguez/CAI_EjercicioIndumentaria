using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppIndumentaria.Libreria.Exceptions;

namespace AppIndumentaria.Libreria.Entidades
{
    public class TiendaRopa
    {
        List<Indumentaria> _inventario;
        List<Venta> _ventas;
        int _ultimoCodigo;
        int _stockPorDefecto;

        public List<Indumentaria> _Inventario { get => _inventario; set => _inventario = value; }
        public List<Venta> _Ventas { get => _ventas; set => _ventas = value; }        
        public int StockPorDefecto { get => _stockPorDefecto; }

        public TiendaRopa()
        {
            _inventario = new List<Indumentaria>();
            _ventas = new List<Venta>();
            _ultimoCodigo = 0;
            _stockPorDefecto = 3;
        }

        // No uso propiedad. Hice al reves, que el GetProximoCodigo se use en Program (public), y dentro de la clase se modifique el ultimo código.
        // public int UltimoCodigo { get => _ultimoCodigo; set => _ultimoCodigo = value; }
        public int GetProximoCodigo()
        {
            return this._ultimoCodigo + 1;
        }

        public void AgregarIndumentaria(Indumentaria indumentaria)
        {
            foreach (Indumentaria existencia in this._inventario)
            {
                if (existencia.Equals(indumentaria))
                {
                    throw new CodigoExistenteException("El código ingresado para esa prenda ya existe\n");
                }
            }
            this._Inventario.Add(indumentaria);
        }

        public void ModificarIndumentaria (Indumentaria indumentaria)
        {
            Indumentaria indumentariaAModificar = null;
            foreach (Indumentaria existencia in this._inventario)
            {
                if (existencia.Equals(indumentaria))
                {
                    indumentariaAModificar = existencia;
                }
            }
            if (indumentariaAModificar==null)
            {
                throw new CodigoInexistenteException("La prenda que intenta modificar no existe\n");
            }

            indumentariaAModificar = indumentaria;
        }

        public void QuitarIndumentaria(int codigo)
        {
            Indumentaria indumentaria = null;
            foreach (Indumentaria existencia in this._Inventario)
            {
                if(existencia.Codigo==codigo)
                {
                    indumentaria = existencia;
                }
            }
            if (indumentaria==null)
            {
                throw new CodigoInexistenteException();
            }
            QuitarIndumentaria(indumentaria);
        }

        public void QuitarIndumentaria (Indumentaria indumentaria)
        {
            this._Inventario.Remove(indumentaria);
        }

        public string Listar()
        {
            string listado = "";
            foreach(Indumentaria existencia in this._Inventario)
            {
                listado = listado + existencia.ToString() + "\n";
            }
            if(listado=="")
            {
                listado= "No hay inventario\n";
            }
            return listado;
        }

        public Indumentaria BuscarPrenda(int codigo, int cantidad)
        {
            Indumentaria prenda = null;
            foreach (Indumentaria existencia in this._Inventario)
            {
                if(existencia.Codigo==codigo)
                {
                    if(existencia.Stock < cantidad)
                    {
                        throw new Exceptions.SinStockException("La cantidad ingresada supera el stock disponible: " + existencia.Stock + "\n");
                    }
                    prenda = existencia;
                }
            }
            if(prenda==null)
            {
                throw new Exceptions.CodigoInexistenteException();
            }

            return prenda;
        }

        public void IngresarOrden(Venta venta)
        {
            this._Ventas.Add(venta);
            this._ultimoCodigo++;
            foreach (VentaItem item in venta.Items)
            {
                foreach (Indumentaria existencia in this._Inventario)
                {
                    if(item.Prenda.Codigo==existencia.Codigo)
                    {
                        existencia.Stock = existencia.Stock - item.Cantidad;
                    }
                }               
            }
        }

        //Cambié que devuelva List<Venta> por string.
        public string ListarOrdenes()
        {
            string listado = "";

            foreach (Venta venta in this._Ventas)
            {
                listado = listado + venta.GetListadoOrden();
            }
            if (listado == "")
            {
                listado = "No hay órdenes ingresadas\n";
            }
            return listado;
        }

        public void DevolverOrden(int codigo)
        {
            Venta ordenADevolver = null;
            foreach(Venta orden in this._Ventas)
            {
                if(orden.Codigo==codigo)
                {
                    ordenADevolver = orden;
                }
            }
            if(ordenADevolver==null)
            {
                throw new CodigoInexistenteException("El código de orden ingresado no existe\n");
            }

            DevolverOrden(ordenADevolver);
        }

        public void DevolverOrden(Venta venta)
        {
            venta.Estado = (int)Venta.EnumEstado.Devuelto;
            foreach (VentaItem item in venta.Items)
            {
                foreach (Indumentaria existencia in this._Inventario)
                {
                    if (item.Prenda.Codigo == existencia.Codigo)
                    {
                        existencia.Stock = existencia.Stock + item.Cantidad;
                    }
                }
            }
        }


    }
}
