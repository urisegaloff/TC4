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
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

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
