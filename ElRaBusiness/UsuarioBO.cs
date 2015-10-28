﻿using System;
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
                throw new ExcepcionBO("Error en la búsqueda del usuario.", ex);                
            }
        }


        public UsuarioEntity Autenticar(string email, string password)
        {
            try
            {
                UsuarioEntity usuario = daUsuario.BuscarUsuario(email, password);

                if (usuario == null)
                    throw new AutenticacionExcepcionBO();

                return usuario;
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se encontró el usuario.", ex);
            }
        }

        public void Actualizar(UsuarioEntity entidad)
        {
            try
            {
                // Valida los datos cargados por el usuario.
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
