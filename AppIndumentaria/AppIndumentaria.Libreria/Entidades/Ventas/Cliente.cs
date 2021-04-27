using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public class Cliente
    {
        int _codigo;
        string _apellido;
        string _nombre;
        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public Cliente(int codigo, string apellido, string nombre)
        {
            _codigo = codigo;
            _apellido = apellido;
            _nombre = nombre;
        }

    }
}
