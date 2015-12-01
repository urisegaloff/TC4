using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using ElRaBusiness;
using ElRaEntity;
using ElRaComun;
using ElRaWebUtil;
using ElRaData;

public partial class Pantallas : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!checkLogin())
        {
            MasterPageFile = "~/MasterPage.master";
        }
        else
        {
            MasterPageFile = "~/MasterPageAutenticado.master";
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

    protected void Page_Load(object sender, EventArgs e)
    {

        ArticuloBO articulo = new ArticuloBO();

        List<ArticuloEntity> a = articulo.CargarVidriera(3);

        vidriera.DataSource = a;
        vidriera.DataBind();


    }
}