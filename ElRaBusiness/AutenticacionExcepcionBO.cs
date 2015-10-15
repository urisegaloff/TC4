using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElRaBusiness
{
    public class AutenticacionExcepcionBO : ExcepcionBO
    {
        public AutenticacionExcepcionBO()
            : base("Combinación incorrecta de correo electrónico/contraseña.")
        {
        }
    }
}
