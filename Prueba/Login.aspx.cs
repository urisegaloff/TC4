using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Prueba
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "Usuario inexistente";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Context.Items.Add("Valor1", TextBox1.Text);
            //Se transfiere la ejecución a la siguiente página.
            Server.Transfer("Prueba2.aspx");



        }
    }
}