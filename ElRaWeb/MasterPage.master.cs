using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaWebUtil;

public partial class MasterPage : System.Web.UI.MasterPage
{


    /*
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
     */

    private UsuarioBO boUsuario = new UsuarioBO();

    protected void btnIniciarSesionMP_Click(object sender, EventArgs e)
    {
        try
        {
            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(tbUsuarioMP.Text, tbPasswordMP.Text));
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Convert.ToString(SessionHelper.UsuarioAutenticado.idUsuario), false);
			Session["idpermiso"] = SessionHelper.UsuarioAutenticado.idPermiso;
			Session["idusuario"] = SessionHelper.UsuarioAutenticado.idUsuario;
			Session["nombre"] = SessionHelper.UsuarioAutenticado.nombre;
			Session["apellido"] = SessionHelper.UsuarioAutenticado.apellido;
			Session["telefono"] = SessionHelper.UsuarioAutenticado.telefono;
			Session["mail"] = SessionHelper.UsuarioAutenticado.mail;
			Session["domicilio"] = SessionHelper.UsuarioAutenticado.domicilio;
		
            Server.Transfer("Default.aspx");
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }

    protected void lnkVolver_Click(object sender, EventArgs e)
    {
        //Redirigir la navegación a otra página
        Response.Redirect("Login.aspx");
    }
}
