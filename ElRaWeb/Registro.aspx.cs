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

public partial class Registro : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.nombre = tbNombre.Text;
            usuario.apellido = tbApellido.Text;
            usuario.mail = tbMail.Text;
            usuario.password = tbPassword.Text;
            
            boUsuario.Registrar(usuario, tbMail.Text);

            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(tbMail.Text, tbPassword.Text));
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.UsuarioAutenticado.mail, false);
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }

        
    }
}