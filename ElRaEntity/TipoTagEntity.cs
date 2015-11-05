using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class TipoTagEntity
    {
        public TipoTagEntity()
        {
            idTipo = 0;
            descripcion = "";
        }

        public int idTipo { get; set; }
        public string descripcion { get; set; }

        public void ValidarDatos()
        {
            if (descripcion.Trim() == "")
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
