using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaComun;
using ElRaWebUtil;

public partial class CarritoUsr : System.Web.UI.Page
{
    private CarritoBO boCarrito = new CarritoBO();
    private int idCarrito;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("idPedido"))
            {

                idCarrito = Convert.ToInt32(Context.Items["idPedido"]);
                
                //Traigo el detalle del carrito
                //BuscarCarrito(idCarrito)

            }
        }
    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;

    private void BuscarArticulos(int carrito)
    {
        try
        {
            dgResultados.DataSource = boCarrito.BuscarArticulos(carrito);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }


    protected void btnConfirmar_Click(object sender, System.EventArgs e)
    {
        //divPanel.Visible = true;
        //BuscarArticulos();
    }


    protected void btnEliminar_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        boCarrito.Eliminar(idCarrito);
        //Server.Transfer("Articulo.aspx");
    }

 
    protected void dgResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {   /*
        try
        {
 
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
         */
    }
    

    protected void dgResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            boCarrito.EliminarArticulo(idCarrito,Convert.ToInt32(dgResultados.DataKeys[e.RowIndex].Value.ToString()));
            //Muestro mensaje para avisar qué articulo fue eliminado
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

    protected void dgResultados_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // onclick: al hacer click con el mouse sobre el link
        // se ejecuta "return confirm('¿Está seguro que desea borrar al contacto?');"
        e.Row.Cells[DGCOLUMN_BORRAR].Attributes.Add("onclick", "javascript: return confirm('¿Está seguro que desea borrar al empleado?');");
    }
}