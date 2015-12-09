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
    public class CarritoDA
    {
        public CarritoDA()
        {
        }

        #region Métodos Privados
        private CarritoEntity CrearCarrito(SqlDataReader cursor)
        {
            CarritoEntity Carrito = new CarritoEntity();
            Carrito.idCarrito = cursor.GetInt32(cursor.GetOrdinal("id_carrito"));
            Carrito.idCliente = cursor.GetInt32(cursor.GetOrdinal("id_cliente"));
            return Carrito;
        }

        private ArticuloEntity CrearArticulo(SqlDataReader cursor)
        {
            ArticuloEntity articulo = new ArticuloEntity();
            articulo.idProducto = cursor.GetInt32(cursor.GetOrdinal("idProducto"));
            //Tag.idTipo = cursor.GetString(cursor.GetOrdinal("id_tipo"));
            articulo.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            //Tag.fecha_alta = cursor.GetDateTime(cursor.GetOrdinal("fecha_alta"));
            //Tag.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));
            return articulo;
        }

        #endregion Métodos Privados

        #region Métodos Públicos
        

        public void Actualizar(CarritoEntity Carrito)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@CarritoID"].Value = Carrito.idCarrito;
                        comando.Parameters["@CarritoIdCliente"].Value = Carrito.idCliente;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al actualizar el Carrito.", ex);
            }
        }

        public void Eliminar(int idCarrito)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EliminarCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@CarritoID"].Value = idCarrito;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al eliminar el Carrito.", ex);
            }
        }

        public void EliminarArticulo(int idCarrito, int idProducto)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EliminarCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@CarritoID"].Value = idCarrito;
                        comando.Parameters["@CarritoIdProducto"].Value = idProducto;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al eliminar el Carrito.", ex);
            }
        }




        public List<ArticuloEntity> BuscarArticulos(int idCarrito)
        {
            // Lista de objetos con datos de empleados.
            List<ArticuloEntity> larticulos= null;
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarArticulos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@CarritoID"].Value = idCarrito;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            larticulos = new List<ArticuloEntity>();
                            while (cursor.Read())
                            {
                                larticulos.Add(CrearArticulo(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return larticulos;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }
        #endregion Métodos Públicos
    }
}
