using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    private int idUsuario;
    private int idPermiso;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            idUsuario = Convert.ToInt32(Context.Items["id_user"].ToString());
            idPermiso = Convert.ToInt32(Context.Items["idpermiso"].ToString());
            lblConfig1.Text = Convert.ToString(idUsuario);
            lblConfig2.Text = Convert.ToString(idPermiso);
        }
    }
}