using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    private string mail;
    private int idPermiso;
    protected void Page_Load(object sender, EventArgs e)
    {
        
       if (!Page.IsPostBack)
        {
            try { 
                mail = Context.Items["e_mail"].ToString();
                idPermiso = Convert.ToInt32(Context.Items["idpermiso"].ToString());
                lblConfig1.Text = mail;            
                //lblConfig2.Text = Convert.ToString(idPermiso);
            }
            catch
            {
                mail = "Nada";
                idPermiso = -1;         
            }
        }
    }
}