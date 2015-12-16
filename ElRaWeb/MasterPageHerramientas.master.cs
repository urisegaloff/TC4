using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageHerramientas : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       var Permiso = Session["idPermiso"].ToString();
       if (Permiso == "2")
       {
           btnArticulos.Visible = false;
           btnTags.Visible = false;
           btnUsuarios.Visible = false;

       }
       if (Permiso == "3")
       {
           btnArticulos.Visible = false;
           btnPedidos.Visible = false;
           btnTags.Visible = false;
           btnUsuarios.Visible = false;

       }
    }
	protected void btnPerfil_Click(Object sender, EventArgs e) 
    {
		Server.Transfer("Perfil.aspx");
    }
	protected void btnCarrito_Click(Object sender, EventArgs e)
	{
        Server.Transfer("CarritoUsr.aspx");
	}
	protected void btnMisPedidos_Click(Object sender, EventArgs e)
	{
        Server.Transfer("TodosLosCarritos.aspx");
	}
	protected void btnArticulos_Click(Object sender, EventArgs e)
	{
		Server.Transfer("Articulos.aspx");
	}
	protected void btnTags_Click(Object sender, EventArgs e)
	{
		Server.Transfer("Tags.aspx");
	}
		protected void btnUsuarios_Click(Object sender, EventArgs e)
	{
		Server.Transfer("Usuarios.aspx");
	}
	protected void btnPedidos_Click(Object sender, EventArgs e)
	{
        Server.Transfer("TodosLosCarritos.aspx");
	}

}
