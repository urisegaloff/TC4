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

public partial class Usuarios : System.Web.UI.Page
{
    private UsuarioBO boUsuario = new UsuarioBO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;
    
    /// <summary>
    /// Busca los empleados y carga la grilla.
    /// </summary>
    private void BuscarEmpleados()
    {
        try
        {
            dgResultados.DataSource = boUsuario.Buscar(tbMail.Text, tbNombre.Text, tbApellido.Text);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

     /// <summary>
    /// Se ejecuta al presionar el botón buscar.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBuscar_Click(object sender, System.EventArgs e)
    {
        BuscarEmpleados();
    }

    /// <summary>
    /// Se ejecuta al presionar el botón nuevo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNuevo_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        Server.Transfer("Registro.aspx");
    }

    /// <summary>
    /// Si se presiona el link "Editar" de la grilla.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e">Referencia a la fila en la cual se presionó.</param>
    protected void dgResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            // Se busca el empleado por el legajo y se envía a la página de edición.

            Context.Items.Add("Usuario", boUsuario.Buscar(dgResultados.DataKeys[e.NewEditIndex].Value.ToString(), "", ""));
            // Se transfiere la ejecución a la página de carga y modificación de empleado.
            Server.Transfer("Registro.aspx");
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
            //boUsuario.Eliminar(dgResultados.DataKeys[e.RowIndex].Value.ToString());
            // Se recarga la grilla.
            BuscarEmpleados();
        }
        catch (Exception ex)
        {
            throw new ExcepcionBO("Error", ex);
        }
    }

    /// <summary>
    /// Al crearse un item (una fila de la grilla) se le asigna al link "Borrar"
    /// una función que pide la confirmación antes de eliminar al empleado. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">Referencia a la fila creada.</param>
    protected void dgResultados_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // onclick: al hacer click con el mouse sobre el link
        // se ejecuta "return confirm('¿Está seguro que desea borrar al contacto?');"
        e.Row.Cells[DGCOLUMN_BORRAR].Attributes.Add("onclick", "javascript: return confirm('¿Está seguro que desea borrar al empleado?');");
    }



}