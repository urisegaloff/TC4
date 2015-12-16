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

public partial class CarritoBuscarProducto : System.Web.UI.Page
{
    private ArticuloBO boArticulo = new ArticuloBO();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!checkLogin())
        {
            Server.Transfer("Default.aspx", true);
        }
    }

    public bool checkLogin()
    {
        if (Session["mail"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;

    private void BuscarArticulos()
    {
        try
        {
            dgResultados.DataSource = boArticulo.Buscar(tbDescripcion.Text, tbMarca.Text, tbCodigo.Text);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnBuscar_Click(object sender, System.EventArgs e)
    {
        BuscarArticulos();
    }


    protected void btnNuevo_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        Server.Transfer("Articulo.aspx");
    }


    protected void dgResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Context.Items.Add("Articulo", boArticulo.Buscar(dgResultados.DataKeys[e.NewEditIndex].Value.ToString()));
            // Se transfiere la ejecución a la página de carga y modificación de empleado.
            Server.Transfer("Articulo.aspx");
        }
        catch (Exception ex)
        {
            
        }
    }
}