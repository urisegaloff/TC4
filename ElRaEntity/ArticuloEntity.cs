using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class ArticuloEntity
    {
        public ArticuloEntity()
        {
            idProducto = 0;
            descripcion = "";
            stock = 0;
            precio = 0;
            fecha_baja = DateTime.Today;
            ltags = null;
        }

        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public Decimal precio { get; set; }
        public DateTime fecha_baja { get; set; }
        public List<TagEntity> ltags { get; set; }
    

        public void ValidarDatos()
        {
            if (descripcion.Trim() == "")
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
