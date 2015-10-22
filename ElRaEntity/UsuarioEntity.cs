using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class UsuarioEntity
    {
        public UsuarioEntity()
        {
            idUsuario = 0;
            idPermiso = 0;
            nombre = "";
            apellido = "";
            password = "";
            mail = "";
            telefono = "";
            domicilio = "";
        }

        public int idUsuario { get; set; }
        public int idPermiso { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }

        public void ValidarDatos()
        {
            if (nombre.Trim() == "" ||
                apellido.Trim() == "" ||
                mail.Trim() == "" ||
                password.Trim() == "" ||
                telefono.Trim() == "" ||
                domicilio.Trim() == "")
            {
                throw new DatosObligatoriosExcepcion();
            }

            if (!Util.EsEmail(mail))
            {
                throw new EmailExcepcion();
            }
        }         
    } 
}
