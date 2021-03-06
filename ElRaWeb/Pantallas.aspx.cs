﻿using System;
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
    private ArticuloBO boArticulo = new ArticuloBO();

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
    
    protected void vidriera_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        if (!checkLogin())
        {
            Server.Transfer("Login.aspx", true);
        }
        else
        {
            switch (e.CommandName)
            {
                case "btnAgregarACarrito":

                    HiddenField hfIdProducto = (HiddenField)e.Item.FindControl("hfIdProducto");
                    var idArticulo = hfIdProducto.Value;
                    Context.Items.Add("IdArticulo", idArticulo);
                    Server.Transfer("DetalleArticulo.aspx");
                    break;
            }
        }
    }
}