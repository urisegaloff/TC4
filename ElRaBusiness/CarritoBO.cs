﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaEntity;
using ElRaData;
using ElRaDataSQLServer;

namespace ElRaBusiness
{
    public class CarritoBO
    {
        private CarritoDA daCarrito;

        public CarritoBO()
        {
            daCarrito = new CarritoDA();
        }


        public void Actualizar(CarritoEntity entidad)
        {
            try
            {
                daCarrito.Actualizar(entidad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error al actualizar el carrito", ex);
            }
        }

        public void Eliminar(int idCarrito)
        {
            try
            {
                daCarrito.Eliminar(idCarrito);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error al eliminar el carrito", ex);
            }
        }

        public void EliminarArticulo(int idCarrito, int idProducto)
        {
            try
            {
                daCarrito.EliminarArticulo(idCarrito, idProducto);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error al eliminar un articulo del carrito", ex);
            }
        }

        public List<ArticuloEntity> BuscarArticulos(int idCarrito)
        {
            try
            {
                return daCarrito.BuscarArticulos(idCarrito);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda de los Articulos del carrito.", ex);
            }
        }

    }
}
