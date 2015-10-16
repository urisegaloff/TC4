using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaWebUtil;


public partial class Login : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        tbUsuario.Text = "";
        tbPassword.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Text = "Usuario inexistente";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        /*
        Context.Items.Add("Valor1", TextBox1.Text);
        //Se transfiere la ejecución a la siguiente página.
        Server.Transfer("Prueba.aspx");
        */

        try
        {
            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(Convert.ToInt32(tbUsuario.Text), tbPassword.Text));
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Convert.ToString(SessionHelper.UsuarioAutenticado.idUsuario), false);
            Context.Items.Add("id_user", SessionHelper.UsuarioAutenticado.idUsuario);
            Context.Items.Add("idpermiso", SessionHelper.UsuarioAutenticado.idPermiso);
            Server.Transfer("Default.aspx");
        }
        catch (AutenticacionExcepcionBO ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}