using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaWebUtil
{
    public class WebUtilExcepcion : ValidacionExcepcionAbstract
    {
        public WebUtilExcepcion(string mensaje) : base(mensaje)
        {
        }

        public WebUtilExcepcion(string mensaje, Exception ex) : base(mensaje, ex)
        {
        }
    }
}
