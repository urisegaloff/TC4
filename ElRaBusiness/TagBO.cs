using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaEntity;
using ElRaData;
using ElRaDataSQLServer;

namespace ElRaBusiness
{
    public class TagBO
    {
        private TagDA daTag;

        public TagBO()
        {
            daTag = new TagDA();
        }

        public List<TagEntity> Buscar(string descripcion)
        {
            try
            {
                return daTag.Buscar(descripcion);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Tipo de Tag.", ex);
            }
        }

        public TagEntity BuscarPorClavePrimaria(int idTag)
        {
            try
            {
                return daTag.BuscarTag(idTag);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error en la búsqueda del Tag.", ex);
            }
        }

        public void Actualizar(TagEntity entidad)
        {
            try
            {
                daTag.Actualizar(entidad);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("Error", ex);
            }
        }


        public void Registrar(TagEntity Tag)
        {
            try
            {
                Tag.ValidarDatos();

                daTag.Insertar(Tag);
            }
            catch (ExcepcionDA ex)
            {
                throw new ExcepcionBO("No se pudo realizar la registración del Tag.", ex);
            }
        }
    }
}
