using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using ElRaEntity;
using ElRaData;

namespace ElRaDataSQLServer
{
    public class UsuarioDA
    {
        public UsuarioDA()
        {
        }

        #region Métodos Privados      
        private UsuarioEntity CrearUsuario(SqlDataReader cursor)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.idUsuario = cursor.GetInt32(cursor.GetOrdinal("id_user"));

            // completar los getordinal ( con los nombres de los campos de tabla m_usuario
            usuario.idPermiso = cursor.GetInt32(cursor.GetOrdinal("idpermiso"));
            usuario.nombre = cursor.GetString(cursor.GetOrdinal("nombre"));
            usuario.apellido = cursor.GetString(cursor.GetOrdinal("apellido"));
            usuario.mail = cursor.GetString(cursor.GetOrdinal("mail"));
            usuario.password = cursor.GetString(cursor.GetOrdinal("contraseña"));
            usuario.telefono = cursor.GetString(cursor.GetOrdinal("telefono"));
            usuario.domicilio = cursor.GetString(cursor.GetOrdinal("domicilio"));

            return usuario;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(UsuarioEntity usuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioNombre"].Value = usuario.nombre.Trim();
                        comando.Parameters["@UsuarioApellido"].Value = usuario.apellido.Trim();
                        comando.Parameters["@UsuarioEmail"].Value = usuario.mail.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = usuario.password.Trim();
                        comando.Parameters["@UsuarioTelefono"].Value = usuario.telefono.Trim();
                        /*comando.Parameters["@UsuarioIDPermiso"].Value = usuario.idPermiso;*/
                        comando.Parameters["@UsuarioDomicilio"].Value = usuario.domicilio.Trim();


                        //comando.Parameters["@UsuarioFechaRegistracion"].Value = usuario.FechaRegistracion;
                        comando.ExecuteNonQuery();

                        /*usuario.idUsuario = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);*/                        
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el usuario.", ex);
            }
        }

        public void Actualizar(UsuarioEntity usuario)
        {
            try
            {
               using (SqlConnection conexion = ConexionDA.ObtenerConexion())
               {                    
                    using (SqlCommand comando = new SqlCommand("ActualizarUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioNombre"].Value = usuario.nombre.Trim();
                        comando.Parameters["@UsuarioApellido"].Value = usuario.apellido.Trim();
                        comando.Parameters["@UsuarioEmail"].Value = usuario.mail.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = usuario.password.Trim();
                        comando.Parameters["@UsuarioTelefono"].Value = usuario.telefono.Trim();
                        comando.Parameters["@UsuarioIDPermiso"].Value = usuario.idPermiso;
                        comando.Parameters["@UsuarioDomicilio"].Value = usuario.domicilio.Trim();

                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el usuario.", ex);
            }
        }

        public bool ExisteEmail(string mail)
        {
            try
            {
                bool existeEmail;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarEmail", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@mail"].Value = mail.Trim();
                        existeEmail = Convert.ToBoolean(comando.ExecuteScalar());
                    }

                    conexion.Close();
                }

                return existeEmail;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por id de usuario.", ex);
            }
        }

        public UsuarioEntity BuscarUsuario(string email, string password)
        {
            try
            {
                UsuarioEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarPorEmailPassword", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        comando.Parameters["@UsuarioPassword"].Value = password.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }


        public UsuarioEntity BuscarPorClavePrimaria(string email)
        {
            try
            {
                UsuarioEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscarPorEmail", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@mail"].Value = email.Trim();
                        
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                usuario = CrearUsuario(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }


        public List<UsuarioEntity> Buscar(string email, string nombre, string apellido)
        {
            // Lista de objetos con datos de empleados.
            List<UsuarioEntity> usuarios = null;
            try
            {
                UsuarioEntity usuario = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("UsuarioBuscar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioEmail"].Value = email.Trim();
                        comando.Parameters["@UsuarioNombre"].Value = nombre.Trim();
                        comando.Parameters["@UsuarioApellido"].Value = apellido.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            usuarios = new List<UsuarioEntity>();
                            while (cursor.Read())
                            {
                                usuarios.Add(CrearUsuario(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }


        public void Eliminar(int idUsuario)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EliminarUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioID"].Value = idUsuario;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al eliminar el Usuario.", ex);
            }
        }

        #endregion Métodos Públicos
    }
}
