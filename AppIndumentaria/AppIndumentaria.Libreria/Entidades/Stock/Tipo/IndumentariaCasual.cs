﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{ 
    public class IndumentariaCasual : TipoIndumentaria
    {
        public IndumentariaCasual(string origen, double porcentajeAlgodon) : base(origen, porcentajeAlgodon)
        {
        }
    }
}
