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
            //usuario.password = cursor.GetString(cursor.GetOrdinal("UsuarioPassword"));
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

        public void Actualizar(int id, string nombreArchivo, byte[] archivoFoto)
        {
            try
            {
                FileInfo infoArchivo = new FileInfo(nombreArchivo);

                string rutaFotos = ConfigurationManager.AppSettings["RutaFotos"];
                string nuevoNombreArchivo = id.ToString() + infoArchivo.Extension;

                using (FileStream archivo = File.Create(rutaFotos + nuevoNombreArchivo))
                {
                    archivo.Write(archivoFoto, 0, archivoFoto.Length);
                    archivo.Close();
                }

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {                    
                    using (SqlCommand comando = new SqlCommand("UsuarioActualizarFoto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UsuarioID"].Value = id;
                        comando.Parameters["@UsuarioFoto"].Value = nuevoNombreArchivo;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar la foto.", ex);
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
        #endregion Métodos Públicos
    }
}
