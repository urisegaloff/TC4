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
    public class ArticuloDA
    {
        public ArticuloDA()
        {
        }

        #region Métodos Privados
        private ArticuloEntity CrearArticulo(SqlDataReader cursor)
        {
            ArticuloEntity articulo = new ArticuloEntity();
            articulo.idProducto = cursor.GetInt32(cursor.GetOrdinal("Id_Producto"));
            articulo.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            articulo.stock = cursor.GetInt32(cursor.GetOrdinal("stock"));
            articulo.precio = cursor.GetDouble(cursor.GetOrdinal("precio"));
            articulo.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));
            
            return articulo;
        }
        #endregion Métodos Privados

        #region Métodos Públicos
        public void Insertar(ArticuloEntity articulo)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("CrearArticulo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = articulo.idProducto;
                        comando.Parameters["@ArticuloDescripcion"].Value = articulo.descripcion.Trim();
                        comando.Parameters["@ArticuloStock"].Value = articulo.stock;
                        comando.Parameters["@ArticuloPrecio"].Value = articulo.precio;
                        //comando.Parameters["@ArticuloTelefono"].Value = articulo.telefono.Trim();
                        
                        //comando.Parameters["@ArticuloFechaRegistracion"].Value = articulo.FechaRegistracion;
                        comando.ExecuteNonQuery();
                        /*articulo.idArticulo = Convert.ToInt32(comando.Parameters["@RETURN_VALUE"].Value);*/
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar el articulo.", ex);
            }
        }

        public void Actualizar(ArticuloEntity articulo)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarArticulo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = articulo.idProducto;
                        comando.Parameters["@ArticuloDescripcion"].Value = articulo.descripcion.Trim();
                        comando.Parameters["@ArticuloStock"].Value = articulo.stock;
                        comando.Parameters["@ArticuloPrecio"].Value = articulo.precio;

                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el articulo.", ex);
            }
        }

        /*
        public ArticuloEntity BuscarArticulo(string email, string password)
        {
            try
            {
                ArticuloEntity articulo = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ArticuloBuscarPorID", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = articulo.idProducto;
                        
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            if (cursor.Read())
                            {
                                articulo = CrearArticulo(cursor);
                            }

                            cursor.Close();
                        }
                    }

                    conexion.Close();
                }

                return articulo;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
         */


        public List<ArticuloEntity> Buscar(string descripcion)
        {
            // Lista de objetos con datos de empleados.
            List<ArticuloEntity> Articulos = null;
            try
            {
                ArticuloEntity articulo = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarArticulo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloDescripcion"].Value = articulo.descripcion.Trim();
                        
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            Articulos = new List<ArticuloEntity>();
                            while (cursor.Read())
                            {
                                Articulos.Add(CrearArticulo(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return Articulos;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }

        #endregion Métodos Públicos
    }
}
