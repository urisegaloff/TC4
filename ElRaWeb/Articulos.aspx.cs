﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElRaBusiness;
using ElRaEntity;
using ElRaComun;
using ElRaWebUtil;

public partial class Articulos : System.Web.UI.Page
{
    private ArticuloBO boArticulo = new ArticuloBO();
    private string sDescripcion;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Context.Items.Contains("Descripcion"))
            {

                sDescripcion = Convert.ToString(Context.Items["Descripcion"]);
                lblAviso.Text = sDescripcion + " registrado exitosamente";
                lblAviso.Visible = true;
            }
        }
    }


    // Constantes de columnas de la grilla.
    private const int DGCOLUMN_BORRAR = 1;

    private void BuscarArticulos()
    {
        try
        {
            dgResultados.DataSource = boArticulo.Buscar(tbDescripcion.Text);
            dgResultados.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }


    protected void btnBuscar_Click(object sender, System.EventArgs e)
    {
        divPanel.Visible = true;
        BuscarArticulos();
    }


    protected void btnNuevo_Click(object sender, System.EventArgs e)
    {
        // Se transfiere la ejecución a la página de carga y modificación de empleado.
        Server.Transfer("Articulo.aspx");
    }


    protected void dgResultados_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Context.Items.Add("Articulo", boArticulo.BuscarPorClavePrimaria(Convert.ToInt32(dgResultados.DataKeys[e.NewEditIndex].Value.ToString())));
            // Se transfiere la ejecución a la página de carga y modificación de empleado.
            Server.Transfer("Articulo.aspx");
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void dgResultados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            boArticulo.Eliminar(Convert.ToInt32(dgResultados.DataKeys[e.RowIndex].Value.ToString()));

            //boArticulo.BuscarPorClavePrimaria(Convert.ToInt32(dgResultados.DataKeys[e.NewEditIndex].Value.ToString())));

            // Se recarga la grilla.
            //BuscarArticulos();
        }
        catch (Exception ex)
        {
            
        }
    }
    
    protected void dgResultados_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // onclick: al hacer click con el mouse sobre el link
        // se ejecuta "return confirm('¿Está seguro que desea borrar al contacto?');"
        e.Row.Cells[DGCOLUMN_BORRAR].Attributes.Add("onclick", "javascript: return confirm('¿Está seguro que desea borrar al empleado?');");
    }
}