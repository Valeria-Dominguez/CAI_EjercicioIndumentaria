using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppIndumentaria.Libreria.Entidades;
using Validaciones;
using AppIndumentaria.Libreria.Exceptions;

namespace AppIndumentaria.Consola
{
    class Program
    {
        static TiendaRopa miTienda;
        static void Main(string[] args)
        {
            miTienda = new TiendaRopa();
            Menu();

            void Menu()
            {
                string opcion = "";
                const string opListarIndumentarias = "1";
                const string opAgregarIndumentaria = "2";
                const string opModificarIndumentaria = "3";
                const string opEliminarIndumentaria = "4";
                const string opListarOrdenes = "5";
                const string opIngresarOrden = "6";
                const string opDevolverOrden = "7";
                const string opSalir = "8";

                do
                {
                    opcion = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción:\n"
                        + opListarIndumentarias + ". Listar Indumentarias \n"
                        + opAgregarIndumentaria + ". Agregar Indumentaria\n"
                        + opModificarIndumentaria + ". Modificar Indumentaria\n"
                        + opEliminarIndumentaria + ". Eliminar Indumentaria\n"
                        + opListarOrdenes + ". Listar ordenes \n"
                        + opIngresarOrden + ". Ingresar Orden \n"
                        + opDevolverOrden + ". Devolver Orden\n"
                        + opSalir + ". Salir\n"
                        );

                    switch (opcion)
                    {
                        case opListarIndumentarias:
                            Console.WriteLine(miTienda.Listar());
                            break;
                        case opAgregarIndumentaria:
                            AgregarIndumentaria(miTienda);
                            break;
                        case opModificarIndumentaria:
                            ModificarIndumentaria(miTienda);
                            break;
                        case opEliminarIndumentaria:
                            EliminarIndumentaria(miTienda);
                            break;
                        case opListarOrdenes:
                            Console.WriteLine(miTienda.ListarOrdenes());
                            break;
                        case opIngresarOrden:
                            AgregarOrden(miTienda);
                            break;
                        case opDevolverOrden:
                            DevolverOrden(miTienda);
                            break;
                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }
                }
                while (opcion != opSalir);
            }
        }

       static void AgregarIndumentaria(TiendaRopa tienda)
        {
            try
            {
                tienda.AgregarIndumentaria(CargarDatosIndumentaria(tienda));
            }
            catch (TipoInvalidoException tipoInvalidoExcep)
            {
                Console.WriteLine(tipoInvalidoExcep.Message);
            }
            catch (CodigoExistenteException codigoExistenteExcep)
            {
                Console.WriteLine(codigoExistenteExcep.Message);
            }
        }

        static void ModificarIndumentaria(TiendaRopa tienda)
        {
            try
            {
                tienda.ModificarIndumentaria(CargarDatosIndumentaria(tienda));
            }
            catch (TipoInvalidoException tipoInvalidoExcep)
            {
                Console.WriteLine(tipoInvalidoExcep.Message);
            }
            catch (CodigoInexistenteException codigoInexistenteExcep)
            {
                Console.WriteLine(codigoInexistenteExcep.Message);
            }
        }

        static void EliminarIndumentaria(TiendaRopa tienda)
        {
            int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código");
            try
            {
                tienda.QuitarIndumentaria(codigo);
            }
            catch (CodigoInexistenteException codigoInexistenteExcep)
            {
                Console.WriteLine(codigoInexistenteExcep.Message);
            }
        }

        static Indumentaria CargarDatosIndumentaria(TiendaRopa tienda)
        {
            Indumentaria indumentaria;

            int camisaOPantalon = Validaciones.Validaciones.ValidarInt("Seleccione una opción:\n1.Camisa\n2.Pantalón");
            if (camisaOPantalon != 1 && camisaOPantalon != 2)
            {
                throw new TipoInvalidoException("Tipo inválido, debe seleccionar 1 o 2\n");
            }

            int casualODeportivaOFormal = Validaciones.Validaciones.ValidarInt("Seleccione una opción:\n1.Indumentaria Casual\n2.Indumentaria Deportiva\n3.Indumentaria Formal");
            if (casualODeportivaOFormal != 1 && casualODeportivaOFormal != 2 && casualODeportivaOFormal != 3)
            {
                throw new TipoInvalidoException("Tipo inválido, debe seleccionar 1, 2 o 3\n");
            }
            double porcentajeAlgodon = Validaciones.Validaciones.ValidarDouble("Igrese porcentaje de algodón");
            string origen = Validaciones.Validaciones.ValidarStrNoVac("Ingrese origen");

            TipoIndumentaria tipoIndumentaria;
            if (casualODeportivaOFormal == 1) { tipoIndumentaria = new IndumentariaCasual(origen, porcentajeAlgodon); }
            else if (casualODeportivaOFormal == 2) { tipoIndumentaria = new IndumentariaDeportiva(origen, porcentajeAlgodon); }
            else /*casualODeportivaOFormal == 3*/ { tipoIndumentaria = new IndumentariaFormal(origen, porcentajeAlgodon); }


            int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código");
            string talle = Validaciones.Validaciones.ValidarStrNoVac("Ingrese talle");
            double precio = Validaciones.Validaciones.ValidarDoubleMayorACero("Igrese precio");


            int stock;
            int ingresarStock = Validaciones.Validaciones.ValidarInt("Seleccione una opción:\n1.Ingresar cantidad\n2.Cantidad por defecto");
            if (camisaOPantalon != 1 && camisaOPantalon != 2)
            {
                throw new TipoInvalidoException("Tipo inválido, debe seleccionar 1 o 2\n");
            }
            if (ingresarStock==1)
            {
                stock = (int)Validaciones.Validaciones.ValidarUint("Ingrese cantidad");
            }
            else { stock = tienda.StockPorDefecto; }


            if (camisaOPantalon == 1) //pantalon
            {
                string material = Validaciones.Validaciones.ValidarStrNoVac("Ingrese material");
                int tieneBolsillos = Validaciones.Validaciones.ValidarInt("Seleccione una opción:\n1.Con bolsillos\n2.Sin bolsillos");
                bool bolsillos;
                if (tieneBolsillos != 1 && tieneBolsillos != 2)
                {
                    throw new TipoInvalidoException("Tipo inválido, debe seleccionar 1 o 2\n");
                }
                if (tieneBolsillos == 1) { bolsillos = true; }
                else
                {
                    bolsillos = false;
                }
                indumentaria = new Pantalon(tipoIndumentaria, codigo, stock, talle, precio, material, bolsillos);
            }

            else //camisa
            {
                string tipoDeManga = Validaciones.Validaciones.ValidarStrNoVac("Ingrese tipo de manga");
                int tieneEstampado = Validaciones.Validaciones.ValidarInt("Seleccione una opción:\n1.Tiene estampado\n2.Liso");
                bool estampado;
                if (tieneEstampado != 1 && tieneEstampado != 2)
                {
                    throw new TipoInvalidoException("Tipo inválido, debe seleccionar 1 o 2\n");
                }
                if (tieneEstampado == 1) { estampado = true; }
                else
                {
                    estampado = false;
                }
                indumentaria = new Camisa(tipoIndumentaria, codigo, stock, talle, precio, estampado, tipoDeManga);
            }

            return indumentaria;
        }

        static void AgregarOrden (TiendaRopa tienda)
        {
            try
            {
                tienda.IngresarOrden(CargarOrden(tienda));
            }
            catch (CodigoInexistenteException codInexistExcep)
            {
                Console.WriteLine(codInexistExcep.Message);
            }
            catch (SinStockException sinStockExcep)
            {
                Console.WriteLine(sinStockExcep.Message);
            }
        }


        static Venta CargarOrden (TiendaRopa tienda)
        {
            Venta venta;

            string apellido = Validaciones.Validaciones.ValidarStrNoVac("Ingrese apellido del cliente");
            string nombre = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre del cliente");
            int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código de ciente");
            Cliente cliente = new Cliente(codigo, apellido, nombre);
            venta = new Venta(cliente, tienda.GetProximoCodigo());

            int masItems;
            do
            {
                masItems = Validaciones.Validaciones.ValidarInt("1.Continuar carga de prendas\n2.Cerrar orden\n");
                if(masItems==1)
                {
                    int codigoPrenda = (int)Validaciones.Validaciones.ValidarUint("Ingrese código de prenda");
                    int cantPrenda = (int)Validaciones.Validaciones.ValidarUint("Ingrese cantidad");
                    Indumentaria prenda = tienda.BuscarPrenda(codigoPrenda, cantPrenda);
                    VentaItem item = new VentaItem(prenda, cantPrenda);
                    venta.Items.Add(item);
                }
            }
            while (masItems != 2);
            venta.Estado = (int)Venta.EnumEstado.Iniciada;
            return venta;
        }


        static void DevolverOrden (TiendaRopa tienda)
        {
            try
            {
                int codigoOrden = (int)Validaciones.Validaciones.ValidarUint("Ingrese código de la orden");
                tienda.DevolverOrden(codigoOrden);
            }
            catch (CodigoInexistenteException codInexistExcep)
            {
                Console.WriteLine(codInexistExcep.Message);
            }
        }


    }
}
