using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageAutenticado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPerfil.Text = Session["mail"].ToString();
    }

    protected void lbtnPerfil_Click(Object sender, EventArgs e) 
    {
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }

    protected void lbtnCarrito_Click(Object sender, EventArgs e) 
    {
        //Session.RemoveAll();
        Response.Redirect("CarritoUsr.aspx");
    }
}
