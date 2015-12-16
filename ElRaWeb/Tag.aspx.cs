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

public partial class Tag : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (!checkLogin())
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
    private TagBO boTag = new TagBO();
    private TipoTagBO boTipoTag = new TipoTagBO();

    protected void Page_Load(object sender, EventArgs e)
    {
        ddlTipoTags.DataTextField = "descripcion";
        ddlTipoTags.DataValueField = "idTipo";
        
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("Tag"))
            {
                TagEntity entidad = (TagEntity)Context.Items["Tag"];

                tbID.Text = Convert.ToString(entidad.idTag);
                tbDescripcion.Text = entidad.descripcion;
                //ddlTipoTags.SelectedItem.Value = entidad.idTipo;
                ddlTipoTags.DataSource = boTipoTag.BuscarTipoAsociado(entidad.idTag);

                tbID.Enabled = false;
                ViewState.Add("Nuevo", false);
            }
            else
            {
                // Se agrega en el objeto ViewState una entrada que indica
                // que el empleado es nuevo.
                ViewState.Add("Nuevo", true);
                ddlTipoTags.DataSource = boTipoTag.Buscar("");

            }

        }else{
            ddlTipoTags.DataSource = boTipoTag.Buscar("");
        }
        ddlTipoTags.DataBind();
    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            TagEntity Tag = new TagEntity();

            Tag.idTipo = ddlTipoTags.SelectedItem.Value;
            Tag.descripcion = tbDescripcion.Text;

            if (Convert.ToBoolean(ViewState["Nuevo"]))
            {
                boTag.Registrar(Tag);
            }
            else
            {
                boTag.Actualizar(Tag);
            }

            //Context.Items.Add("ID", Tag.idTag);
            Server.Transfer("Tags.aspx");
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }
    }
}