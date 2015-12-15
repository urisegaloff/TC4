using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElRaComun;

namespace ElRaEntity
{

    
    public class PedidosEntity
    {
        public PedidosEntity()
        {
           id_pedido = 0;
           idUsuario = 0;
           IdProducto = 0; 
           Descripcion = "";
           Precio = 0;
           cantidad = 0;
        }


        public int id_pedido { get; set; }
        public int idUsuario { get; set; }
        public int IdProducto { get; set; }
        public String Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int cantidad { get; set; }
         
    }

}
