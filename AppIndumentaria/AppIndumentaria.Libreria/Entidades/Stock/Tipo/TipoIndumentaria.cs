using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIndumentaria.Libreria.Entidades
{
    public abstract class TipoIndumentaria
    {
        string _origen;
        double _porcentajeAlgodon;

        protected TipoIndumentaria(string origen, double porcentajeAlgodon)
        {
            _origen = origen;
            _porcentajeAlgodon = porcentajeAlgodon;
        }

        public string Origen { get => _origen; set => _origen = value; }
        public double PorcentajeAlgodon { get => _porcentajeAlgodon; set => _porcentajeAlgodon = value; }
    }
}
