using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaEntity;
using ElRaData;
using ElRaDataSQLServer;

namespace ElRaBusiness
{
    public class UsuarioBO
    {
        private UsuarioDA daUsuario;

        public UsuarioBO()
        {
            daUsuario = new UsuarioDA();
        }

        public UsuarioEntity Autenticar(int idUsuario, string password)
        {
            try
            {
                UsuarioEntity usuario = daUsuario.BuscarUsuario(idUsuario, password);

                if (usuario == null)
                    throw new AutenticacionExcepcionBO();

                return usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la autenticación del usuario.", ex);
            }
        }

        public void Registrar(UsuarioEntity usuario, string emailVerificacion)
        {
            try
            {
                usuario.ValidarDatos();

                if (daUsuario.ExisteEmail(usuario.mail))
                    throw new EmailExisteExcepcionBO();

                if (usuario.mail != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daUsuario.Insertar(usuario);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del usuario.", ex);
            }
        }
    }
}
