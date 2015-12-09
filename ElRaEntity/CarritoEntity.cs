using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{
    public class CarritoEntity
    {
        public CarritoEntity()
        {
            idCarrito = 0;
            idCliente = 0;
            lArticulos = null;
        }

        public int idCarrito { get; set; }
        public int idCliente { get; set; }
        public List<ArticuloEntity> lArticulos { get; set; }


        public void ValidarDatos()
        {
            if (idCarrito == 0)
            {
                throw new DatosObligatoriosExcepcion();
            }
        }
    }
}
