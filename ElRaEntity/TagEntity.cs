using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class TagEntity
    {
        public TagEntity()
        {
            idTag = 0;
            idTipo = "";
            descripcion = "";
            fecha_alta = DateTime.Today;           
            fecha_baja = DateTime.Today;
        }

        public int idTag { get; set; }
        public string idTipo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_baja { get; set; }


        public void ValidarDatos()
        {
            if (descripcion.Trim() == "")
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
