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

public partial class TodosLosCarritos : System.Web.UI.Page
{
    private int idUsuario;
    private CarritoBO boCarrito = new CarritoBO();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["idusuario"] != null)
            {

                //idCarrito = Convert.ToInt32(Context.Items["idPedido"]);
                idUsuario = Convert.ToInt32(Session["idusuario"]);
                //Traigo el detalle del carrito
                TraerCarritos(idUsuario);

            }
        }
    }


    private void TraerCarritos(int usuario)
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

    protected void btnVolver_Click(object sender, System.EventArgs e)
    {
        
        Server.Transfer("Default.aspx");
        //divPanel.Visible = true;
        //BuscarArticulos();
    }
}