using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaComun;
using ElRaWebUtil;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!checkLogin())
        {
            MasterPageFile = "~/MasterPage.master";
        }
        else
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
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("Usuario"))
            {
                UsuarioEntity entidad = (UsuarioEntity)Context.Items["Usuario"];

                tbApellido.Text = entidad.apellido;
                tbNombre.Text = entidad.nombre;
                tbTelefono.Text = entidad.telefono;
                tbMail.Text = entidad.mail;
                tbDomicilio.Text = entidad.domicilio;
                tbPassword.Text = entidad.password;

                // Se deshabilita la carga del legajo porque es clave primaria.
                tbMail.Enabled = false;
                ViewState.Add("Nuevo", false);
            }
            else
            {
                // Se agrega en el objeto ViewState una entrada que indica
                // que el empleado es nuevo.
                ViewState.Add("Nuevo", true);
            }
        }

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
            usuario.domicilio = tbDomicilio.Text;
            usuario.telefono = tbTelefono.Text;


            if (Convert.ToBoolean(ViewState["Nuevo"]))
            {
                boUsuario.Registrar(usuario, tbMail.Text);
            }
            else
            {
                boUsuario.Actualizar(usuario);
                Context.Items.Add("MostrarTodos", "S");
                Server.Transfer("Usuarios.aspx");
            } 
            SessionHelper.AlmacenarUsuarioAutenticado(boUsuario.Autenticar(tbMail.Text, tbPassword.Text));
            /*System.Web.Security.FormsAuthentication.RedirectFromLoginPage(SessionHelper.UsuarioAutenticado.mail, false);*/
            Context.Items.Add("e_mail", SessionHelper.UsuarioAutenticado.mail);
            Context.Items.Add("idpermiso", SessionHelper.UsuarioAutenticado.idPermiso);
            Server.Transfer("Default.aspx");
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }

        
    }
}