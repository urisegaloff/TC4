using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElRaComun
{
    public class FechaInvalidaExcepcion : ValidacionExcepcionAbstract
    {
        public FechaInvalidaExcepcion()
            : base("La fecha es inválida.")
        {
        }
    }
}
