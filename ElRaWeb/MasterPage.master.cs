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
        //Label1.Text = "Usuario inexistente";
        /*
        Context.Items.Add("Valor1", TextBox1.Text);
        //Se transfiere la ejecución a la siguiente página.
        Server.Transfer("Prueba.aspx");
        */

        try
        {
            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(tbUsuarioMP.Text, tbPasswordMP.Text));
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Convert.ToString(SessionHelper.UsuarioAutenticado.idUsuario), false);
            Context.Items.Add("e_mail", SessionHelper.UsuarioAutenticado.mail);
            Context.Items.Add("idpermiso", SessionHelper.UsuarioAutenticado.idPermiso);
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
    /// <summary>
    /// Propiedad o atributo público que me permite
    /// asignar un valor al atributo Text del label lblTitulo.
    /// </summary>
   /* public string Titulo
    {
        get
        {
            return lblTitulo.Text;
        }
        set
        {
            lblTitulo.Text = value;
        }
    }*/
}
