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

        public List<UsuarioEntity> Buscar(string email, string nombre, string apellido)
        {
            try
            {
                return daUsuario.Buscar(email, nombre, apellido);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Usuario.", ex);                
            }
        }

        public UsuarioEntity BuscarPorClavePrimaria(string email)
        {
            try
            {
                return daUsuario.BuscarPorClavePrimaria(email);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Usuario.", ex);
            }
        }


        public UsuarioEntity Autenticar(string email, string password)
        {
            try
            {
                UsuarioEntity Usuario = daUsuario.BuscarUsuario(email, password);

                if (Usuario == null)
                    throw new AutenticacionExcepcionBO();

                return Usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se encontró el Usuario.", ex);
            }
        }

        public void Actualizar(UsuarioEntity entidad)
        {
            try
            {
                // Valida los datos cargados por el Usuario.
                //Validar(entidad);

                // Si el empleado no existe en la base de datos...
                /*
                if (daUsuario.BuscarPorClavePrimaria(entidad.mail) == null)
                {
                    // ...se lanza la excepción correspondiente.
                    //throw new UsuarioNoExisteException(entidad.Legajo);
                }
                 */

                // Si existe, se actualizan los datos.
                daUsuario.Actualizar(entidad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }


        public void Registrar(UsuarioEntity Usuario, string emailVerificacion)
        {
            try
            {
                Usuario.ValidarDatos();

                if (daUsuario.ExisteEmail(Usuario.mail))
                    throw new EmailExisteExcepcionBO();

                if (Usuario.mail != emailVerificacion.Trim())
                    throw new VerificacionEmailExcepcionBO();

                daUsuario.Insertar(Usuario);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Usuario.", ex);
            }
        }

        public void Eliminar(int idUsuario)
        {
            try
            {
                daUsuario.Eliminar(idUsuario);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }
    }
}
