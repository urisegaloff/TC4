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
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!checkLogin())
        {
            MasterPageFile = "~/MasterPage.master";
        }
        else
        {
            MasterPageFile = "~/MasterPageAutenticado.master";
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
    private CarritoBO boCarrito = new CarritoBO();
    //private int idCarrito;
    private int idUsuario;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["idusuario"] != null)
            {

                //idCarrito = Convert.ToInt32(Context.Items["idPedido"]);
                idUsuario = Convert.ToInt32(Session["idusuario"]);
                //Traigo el detalle del carrito
                BuscarCarrito(idUsuario);

            }
        }
    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;

    private void BuscarCarrito(int usuario)
    {
        try
        {
            dgResultados.DataSource = boCarrito.BuscarArticulos(usuario);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }


    protected void btnConfirmar_Click(object sender, System.EventArgs e)
    {
        boCarrito.Confirmar(Convert.ToInt32(Session["idusuario"]));
        BuscarCarrito(Convert.ToInt32(Session["idusuario"]));
        Server.Transfer("Default.aspx");
        //divPanel.Visible = true;
        //BuscarArticulos();
    }


    protected void btnEliminar_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        int res = boCarrito.Eliminar(idUsuario);
        mostrarAlerta(res);
        //Server.Transfer("Articulo.aspx");
    }    

    protected void dgResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            boCarrito.EliminarArticulo(Convert.ToInt32(Session["idusuario"]), Convert.ToInt32(dgResultados.DataKeys[e.RowIndex].Value.ToString()));
            BuscarCarrito(Convert.ToInt32(Session["idusuario"]));
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

    protected void mostrarAlerta(int num)
    {
        if (num < 0)
        {
            alertNOT.Visible = true;
            alertOK.Visible = false;
        }
        else
        {
            alertNOT.Visible = false;
            alertOK.Visible = true;
        }
    }
}