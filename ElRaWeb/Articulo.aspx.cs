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

public partial class Articulo : System.Web.UI.Page
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
    private ArticuloBO boArticulo = new ArticuloBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Items.Contains("Articulo")) 
        {
            ArticuloEntity entidad = (ArticuloEntity)Context.Items["Articulo"];

            tbID.Text = Convert.ToString(entidad.idProducto);
            tbDescripcion.Text = entidad.descripcion;
            tbPrecio.Text = Convert.ToString(entidad.precio);
            tbStock.Text = Convert.ToString(entidad.stock);
            tbFecha.Text = Convert.ToString(entidad.fecha_baja);
                        
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
    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            ArticuloEntity Articulo = new ArticuloEntity();

            Articulo.idProducto = Convert.ToInt32(tbID.Text);
            Articulo.descripcion = tbDescripcion.Text;
            Articulo.precio = Convert.ToDouble(tbPrecio.Text);
            Articulo.stock = Convert.ToInt32(tbStock.Text);
            Articulo.fecha_baja = Convert.ToDateTime(tbFecha.Text);
            
            if (Convert.ToBoolean(ViewState["Nuevo"]))
            {
                boArticulo.Registrar(Articulo);
            }
            else
            {
                boArticulo.Actualizar(Articulo);
            } 
                       
            Context.Items.Add("ID", Articulo.idProducto);
            //Server.Transfer("Default.aspx");
        }
        catch (ValidacionExcepcionAbstract ex)
        {
            WebHelper.MostrarMensaje(Page, ex.Message);
        }        
    }
}