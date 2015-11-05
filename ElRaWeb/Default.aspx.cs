﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
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

    private string mail;
    private int idPermiso;
    protected void Page_Load(object sender, EventArgs e)
    {
        
       if (!Page.IsPostBack)
        {
            try {
                mail = Session["mail"].ToString();
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