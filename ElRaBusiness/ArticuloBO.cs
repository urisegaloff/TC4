using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaEntity;
using ElRaData;
using ElRaDataSQLServer;

namespace ElRaBusiness
{
    public class ArticuloBO
    {
        private ArticuloDA daArticulo;

        public ArticuloBO()
        {
            daArticulo = new ArticuloDA();
        }

        public List<ArticuloEntity> Buscar(string descripcion)
        {
            try
            {
                
                return daArticulo.Buscar(descripcion);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Articulo.", ex);
            }
        }

        public List<ArticuloEntity> Buscar(string descripcion, string Marca, string Codigo)
        {
            try
            {

                return daArticulo.Buscar(descripcion);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Articulo.", ex);
            }
        }

        public ArticuloEntity BuscarPorClavePrimaria(int idProducto)
        {
            try
            {

                return daArticulo.BuscarPorClavePrimaria(idProducto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Articulo.", ex);
            }
        }


        public void Actualizar(ArticuloEntity entidad)
        {
            try
            {
                daArticulo.Actualizar(entidad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }

        public void Eliminar(int idProducto)
        {
            try
            {
                daArticulo.Eliminar(idProducto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }


        public void Registrar(ArticuloEntity Articulo)
        {
            try
            {
                Articulo.ValidarDatos();

                daArticulo.Insertar(Articulo);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Articulo.", ex);
            }
        }


        public List<TagEntity> TraerNoAsignados(int idProducto)
        {
            try
            {
                return daArticulo.BuscarNoAsignados(idProducto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda de Tags.", ex);
            }
        }

        public List<TagEntity> TraerAsignados(int idProducto)
        {
            try
            {
                return daArticulo.BuscarAsignados(idProducto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda de Tags.", ex);
            }
        }

        public void AgregarTag(ArticuloEntity Articulo, int idTag)
        {
            try
            {
                daArticulo.AgregarTag(Articulo, idTag);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Articulo.", ex);
            }
        }

        public List<ArticuloEntity> CargarVidriera(int Categoria)
        {
            try
            {
               return daArticulo.CargarVidriera(Categoria);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Articulo.", ex);
            }
        }

        public int AgregarACarrito(string idUsuario, string idArticulo, string idCantidad)
        {
            return daArticulo.AgregarACarrito(idUsuario, idArticulo, idCantidad);
        }
    }
}
