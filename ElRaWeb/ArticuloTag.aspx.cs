using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaComun;
using ElRaWebUtil;

public partial class ArticuloTag : System.Web.UI.Page
{
    private ArticuloBO boArticulo = new ArticuloBO();
    private ArticuloEntity Articulo = new ArticuloEntity();
    private TagEntity Tag = new TagEntity();
    private int idTag = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("ID"))
            {
                tbID.Text = Convert.ToString(Context.Items["ID"]);
                BuscarTagsNoAsociados();
                BuscarTagsAsociados();
                tbID.Enabled = false;
            }
        }
    }
    private void BuscarTagsNoAsociados()
    {
        try
        {
            /*List<TagEntity> ltags;
            ltags = new List<TagEntity>();
            ltags = boArticulo.TraerNoAsignados(Convert.ToInt32(tbID.Text));

            foreach (TagEntity tag in ltags)
            {
                ddlTags.Items.Add();
            }*/
            ddlTags.DataSource = boArticulo.TraerNoAsignados(Convert.ToInt32(tbID.Text));
            ddlTags.DataTextField = "descripcion";
            ddlTags.DataValueField = "idTag";
            
            ddlTags.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }


    private void BuscarTagsAsociados()
    {
        try
        {

            dgResultados.DataSource = boArticulo.TraerAsignados(Convert.ToInt32(tbID.Text)); 
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Context.Items.Add("Articulo", boArticulo.BuscarPorClavePrimaria(Convert.ToInt32(tbID.Text)));
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        Server.Transfer("Articulo.aspx");
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //List<TagEntity> tags = (TagEntity)dgResultados.DataSource;
        //Agrega el tag en la base de datos 

        idTag = Convert.ToInt32(ddlTags.SelectedItem.Value);

        

        Articulo.idProducto = Convert.ToInt32(tbID.Text);

        boArticulo.AgregarTag(Articulo, idTag);
        //vuelve a traer los asignados y no asignados
        BuscarTagsNoAsociados();
        BuscarTagsAsociados();
         

    }
}