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

public partial class TipoTag : System.Web.UI.Page
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
        if (Context.Items["ID"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private TipoTagBO boTipoTag = new TipoTagBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("TipoTag"))
            {
                TipoTagEntity entidad = (TipoTagEntity)Context.Items["TipoTag"];

                tbID.Text = Convert.ToString(entidad.idTipo);
                tbDescripcion.Text = entidad.descripcion;              

                // Se deshabilita la carga del legajo porque es clave primaria.
                tbID.Enabled = false;
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
            TipoTagEntity TipoTag = new TipoTagEntity();

            TipoTag.idTipo = tbID.Text;
            TipoTag.descripcion = tbDescripcion.Text;
            
            if (Convert.ToBoolean(ViewState["Nuevo"]))
            {
                boTipoTag.Registrar(TipoTag);
            }
            else
            {
                boTipoTag.Actualizar(TipoTag);
            }

            Context.Items.Add("ID", TipoTag.idTipo);
            //Server.Transfer("Default.aspx");
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}