<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>



<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
    <div class="col-xs-4 col-xs-offset-4 text-center">
        <div class="panel panel-primary">
             <div class="panel panel-heading">
                <h4 class="h4">Login</h4>
            </div>
            <div class="panel panel-body text-center">
                       
                <form class="form-inline" id="form1" runat="server">
                        <div class="form-group">
                            <label for="TextBox1">Usuario</label>  
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group"> 
                            <label for="TextBox2">Contraseña:</label>
                            <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Limpiar" />
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Iniciar Sesion"/>
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Nuevo" />
                        </div>

                </form>
            </div>
        </div>
    </div>

</asp:Content>

    

