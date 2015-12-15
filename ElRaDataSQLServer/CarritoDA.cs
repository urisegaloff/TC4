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
            articulo.precio = cursor.GetDecimal(cursor.GetOrdinal("precio"));
            articulo.stock = cursor.GetInt32(cursor.GetOrdinal("cantidad"));
            //Tag.fecha_alta = cursor.GetDateTime(cursor.GetOrdinal("fecha_alta"));
            //Tag.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));
            return articulo;
        }
        private PedidosEntity CrearPedido(SqlDataReader cursor)
        {
            PedidosEntity pedido = new PedidosEntity();
            pedido.id_pedido = cursor.GetInt32(cursor.GetOrdinal("id_pedido"));
            pedido.idUsuario = cursor.GetInt32(cursor.GetOrdinal("id_usuario"));            
            pedido.IdProducto = cursor.GetInt32(cursor.GetOrdinal("idProducto"));
            pedido.Descripcion= cursor.GetString(cursor.GetOrdinal("descripcion"));
            pedido.Precio= cursor.GetDecimal(cursor.GetOrdinal("precio"));
            pedido.cantidad = cursor.GetInt32(cursor.GetOrdinal("cantidad"));
            return pedido;
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

        public int Eliminar(int idCarrito)
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
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void EliminarArticulo(int idCarrito, int idProducto)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("QuitarProductoCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UserID"].Value = idCarrito;
                        comando.Parameters["@ProductoID"].Value = idProducto;
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
                    using (SqlCommand comando = new SqlCommand("ConsultarCarritoAbierto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UserID"].Value = idCarrito;

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

        public void Confirmar(int idCarrito)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ConfirmarCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UserID"].Value = idCarrito;
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

        public List<PedidosEntity> BuscarPedidos(int idCarrito)
        {
            // Lista de objetos con datos de empleados.
            List<PedidosEntity> lpedidos = null;
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("TraerPedidos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UserID"].Value = idCarrito;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            lpedidos = new List<PedidosEntity>();
                            while (cursor.Read())
                            {
                                lpedidos.Add(CrearPedido(cursor));
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return lpedidos;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar por email y contraseña.", ex);
            }
        }


        #endregion Métodos Públicos
    }
}
