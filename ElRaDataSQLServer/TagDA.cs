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
    public class TagDA
    {
        public TagDA()
        {
        }

        #region Métodos Privados
        private TagEntity CrearTag(SqlDataReader cursor)
        {
            TagEntity Tag = new TagEntity();
            Tag.idTag = cursor.GetInt32(cursor.GetOrdinal("id_tag"));
            Tag.idTipo = cursor.GetString(cursor.GetOrdinal("id_tipo"));
            Tag.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            Tag.fecha_alta = cursor.GetDateTime(cursor.GetOrdinal("fecha_alta"));
            //Tag.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));            
            return Tag;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(TagEntity Tag)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        //comando.Parameters["@TagID"].Value = Tag.idTag;
                        comando.Parameters["@id_tipo"].Value = Tag.idTipo;
                        comando.Parameters["@descripcion"].Value = Tag.descripcion.Trim();
                        //comando.Parameters["@TagFechaAlta"].Value = Tag.fecha_alta;
                        //comando.Parameters["@TagFechaBaja"].Value = Tag.fecha_baja;
                        
                        comando.ExecuteNonQuery();                        
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el Tag.", ex);
            }
        }

        public void Actualizar(TagEntity Tag)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TagID"].Value = Tag.idTag;
                        comando.Parameters["@TagIdtipo"].Value = Tag.idTipo;
                        comando.Parameters["@TagDescripcion"].Value = Tag.descripcion.Trim();
                        comando.Parameters["@TagFechaAlta"].Value = Tag.fecha_alta;
                        comando.Parameters["@TagFechaBaja"].Value = Tag.fecha_baja;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el Tag.", ex);
            }
        }

        public TagEntity BuscarTag(int idTipo)
        {
            try
            {
                TagEntity Tag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("TagBuscarPorID", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TagID"].Value = Tag.idTag;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                Tag = CrearTag(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return Tag;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar el tag.", ex);
            }
        }


        public List<TagEntity> Buscar(string descripcion)
        {
            // Lista de objetos con datos de empleados.
            List<TagEntity> Tags = null;
            try
            {
                TagEntity Tag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@TagDescripcion"].Value = descripcion.Trim();

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            Tags = new List<TagEntity>();
                            while (cursor.Read())
                            {
                                Tags.Add(CrearTag(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return Tags;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por descripcion.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
