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

public partial class TipoTags : System.Web.UI.Page
{
    private TipoTagBO boTipoTag = new TipoTagBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;

    private void BuscarTipoTags()
    {
        try
        {
            dgResultados.DataSource = boTipoTag.Buscar(tbDescripcion.Text);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }


    protected void btnBuscar_Click(object sender, System.EventArgs e)
    {
        BuscarTipoTags();
    }


    protected void btnNuevo_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        Server.Transfer("TipoTag.aspx");
    }


    protected void dgResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Context.Items.Add("TipoTag", boTipoTag.Buscar(dgResultados.DataKeys[e.NewEditIndex].Value.ToString()));
            // Se transfiere la ejecución a la página de carga y modificación de empleado.
            Server.Transfer("TipoTag.aspx");
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

    /// <summary>
    /// Si se presiona el link "Borrar" de la grilla.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e">Referencia a la fila en la cual se presionó.</param>
    protected void dgResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            // Se busca el empleado por el legajo y se lo borra.
            //boTipoTag.Eliminar(dgResultados.DataKeys[e.RowIndex].Value.ToString());
            // Se recarga la grilla.
            BuscarTipoTags();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

    protected void dgResultados_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // onclick: al hacer click con el mouse sobre el link
        // se ejecuta "return confirm('¿Está seguro que desea borrar al contacto?');"
        e.Row.Cells[DGCOLUMN_BORRAR].Attributes.Add("onclick", "javascript: return confirm('¿Está seguro que desea borrar al empleado?');");
    }
}