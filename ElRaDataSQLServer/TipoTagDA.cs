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
    public class TipoTagDA
    {
        public TipoTagDA()
        {
        }

        #region Métodos Privados
        private TipoTagEntity CrearTipoTag(SqlDataReader cursor)
        {
            TipoTagEntity TipoTag = new TipoTagEntity();
            TipoTag.idTipo = cursor.GetString(cursor.GetOrdinal("id_tipo"));
            TipoTag.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            
            return TipoTag;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(TipoTagEntity TipoTag)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearTipoTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TipoTagID"].Value = TipoTag.idTipo;
                        comando.Parameters["@TipoTagDescripcion"].Value = TipoTag.descripcion.Trim();                        
                        comando.ExecuteNonQuery();                        
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el TipoTag.", ex);
            }
        }

        public void Actualizar(TipoTagEntity TipoTag)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarTipoTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TipoTagID"].Value = TipoTag.idTipo;
                        comando.Parameters["@TipoTagDescripcion"].Value = TipoTag.descripcion.Trim();
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el TipoTag.", ex);
            }
        }

        public TipoTagEntity BuscarTipoTag(int idTipo)
        {
            try
            {
                TipoTagEntity TipoTag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("TipoTagBuscarPorID", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TipoTagID"].Value = TipoTag.idTipo;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                TipoTag = CrearTipoTag(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return TipoTag;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }


        public List<TipoTagEntity> Buscar(string descripcion)
        {
            // Lista de objetos con datos de empleados.
            List<TipoTagEntity> TipoTags = null;
            try
            {
                TipoTagEntity TipoTag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarTipoTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TipoTagDescripcion"].Value = descripcion.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            TipoTags = new List<TipoTagEntity>();
                            while (cursor.Read())
                            {
                                TipoTags.Add(CrearTipoTag(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return TipoTags;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por descripcion.", ex);
            }
        }

        #endregion Métodos Públicos
    }
}
