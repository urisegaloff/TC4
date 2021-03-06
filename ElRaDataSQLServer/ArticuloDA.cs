﻿using System;
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
            articulo.precio = cursor.GetDecimal(cursor.GetOrdinal("precio"));
            articulo.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));
            
            return articulo;
        }

        private ArticuloEntity ExponerArticulo(SqlDataReader cursor)
        {
            ArticuloEntity articulo = new ArticuloEntity();
            articulo.idProducto = cursor.GetInt32(cursor.GetOrdinal("Id_Producto"));
            articulo.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            articulo.stock = cursor.GetInt32(cursor.GetOrdinal("stock"));
            articulo.precio = cursor.GetDecimal(cursor.GetOrdinal("precio"));

            return articulo;
        }

        private TagEntity CrearTag(SqlDataReader cursor)
        {
            TagEntity Tag = new TagEntity();
            Tag.idTag = cursor.GetInt32(cursor.GetOrdinal("id_tag"));
            //Tag.idTipo = cursor.GetString(cursor.GetOrdinal("id_tipo"));
            Tag.descripcion = cursor.GetString(cursor.GetOrdinal("descripcion"));
            //Tag.fecha_alta = cursor.GetDateTime(cursor.GetOrdinal("fecha_alta"));
            //Tag.fecha_baja = cursor.GetDateTime(cursor.GetOrdinal("fecha_baja"));
            return Tag;
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

                        //comando.Parameters["@ArticuloID"].Value = articulo.idProducto;
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

        public void Eliminar(int idProducto)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EliminarArticulo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = idProducto;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al eliminar el articulo.", ex);
            }
        }


        public List<ArticuloEntity> CargarVidriera(int Categoria)
        {
            try
            {
                string strQuery = "SELECT p.Id_producto, p.descripcion, p.stock, p.precio FROM dbo.m_productos p INNER JOIN d_prod_cat pc ON p.Id_producto = pc.Id_producto and pc.id_categoria = " + Categoria;
                List<ArticuloEntity> articulo = new List<ArticuloEntity>();

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(strQuery, conexion))
                    {
                        
                  
                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            while (cursor.Read())
                            {
                                articulo.Add(ExponerArticulo(cursor));
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

                        comando.Parameters["@ArticuloDescripcion"].Value = descripcion.Trim();
                        
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


        public ArticuloEntity BuscarPorClavePrimaria(int idProducto)
        {
            // Lista de objetos con datos de empleados.
            List<ArticuloEntity> Articulos = null;
            try
            {
                ArticuloEntity Articulo = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarArticuloPorClave", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = idProducto;

                        using (SqlDataReader cursor = comando.ExecuteReader())
                        {
                            Articulo = new ArticuloEntity();
                            while (cursor.Read())
                            {
                                Articulo = CrearArticulo(cursor);
                            }
                            cursor.Close();
                        }
                    }
                    conexion.Close();
                }
                return Articulo;
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al buscar el Articulo.", ex);
            }
        }



        public List<ArticuloEntity> Buscar(string descripcion, string Marca, string Codigo)
        {
            // Lista de objetos con datos de empleados.
            List<ArticuloEntity> Articulos = null;
            try
            {
                ArticuloEntity articulo = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarArticuloCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloDescripcion"].Value = descripcion.Trim();
                        comando.Parameters["@ArticuloMarca"].Value = Marca.Trim();
                        comando.Parameters["@ArticuloCodigo"].Value = Codigo.Trim();

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


        public List<TagEntity> BuscarNoAsignados(int idProducto)
        {
            // Lista de objetos con datos de empleados.
            List<TagEntity> Tags = null;
            try
            {
                TagEntity Tag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarTagsNoAsignados", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idProducto"].Value = idProducto;

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


        public List<TagEntity> BuscarAsignados(int idProducto)
        {
            // Lista de objetos con datos de empleados.
            List<TagEntity> Tags = null;
            try
            {
                TagEntity Tag = null;

                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("BuscarTagsAsignados", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@idProducto"].Value = idProducto;

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


        public void AgregarTag(ArticuloEntity articulo, int idTag)
        {
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("AgregarArticuloTag", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@ArticuloID"].Value = articulo.idProducto;
                        comando.Parameters["@ArticuloTag"].Value = idTag;
                        comando.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionDA("Se produjo un error al insertar la combinacion articulo-tag.", ex);
            }
        }

        public int AgregarACarrito(string idUsuario, string idArticulo, string idCantidad)
        {
            int hecho;
            try
            {
                using (SqlConnection conexion = ConexionDA.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("AgregarProductoCarrito", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(comando);

                        comando.Parameters["@UserID"].Value = Convert.ToInt32(idUsuario);
                        comando.Parameters["@ProductoID"].Value = Convert.ToInt32(idArticulo);
                        comando.Parameters["@Cantidad"].Value = Convert.ToInt32(idCantidad);
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
        #endregion Métodos Públicos
    }
}
