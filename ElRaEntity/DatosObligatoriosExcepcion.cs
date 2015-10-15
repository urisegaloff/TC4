using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class DatosObligatoriosExcepcion : ValidacionExcepcionAbstract
    {
        public DatosObligatoriosExcepcion()
            : base("Todos los datos son obligatorios.")
        {
        }
    }
}
