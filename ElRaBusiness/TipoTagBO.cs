using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaEntity;
using ElRaData;
using ElRaDataSQLServer;

namespace ElRaBusiness
{
    public class TipoTagBO
    {
        private TipoTagDA daTipoTag;

        public TipoTagBO()
        {
            daTipoTag = new TipoTagDA();
        }

        public List<TipoTagEntity> Buscar(string descripcion)
        {
            try
            {
                return daTipoTag.Buscar(descripcion);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Tipo de Tag.", ex);
            }
        }

        public void Actualizar(TipoTagEntity entidad)
        {
            try
            {
                daTipoTag.Actualizar(entidad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }


        public void Registrar(TipoTagEntity TipoTag)
        {
            try
            {
                TipoTag.ValidarDatos();

                daTipoTag.Insertar(TipoTag);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Tipo de Tag.", ex);
            }
        }
    }
}
