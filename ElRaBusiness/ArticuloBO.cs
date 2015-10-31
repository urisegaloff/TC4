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
    }
}
