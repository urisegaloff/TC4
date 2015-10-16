<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>



<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
    
    <div class="col-sm-4 col-sm-offset-4 col-md-4 col-md-offset-4">
        
        <div class="panel panel-primary">
             <div class="panel panel-heading text-center">
                <h4 class="h4">Login</h4>
            </div>
          
              <div class="panel panel-body text-center ">
                       
                <form class="form-inline " id="formLogin" runat="server">
                    
                    <div class="form-group">
                        
                        <div class="input-group">
                            <span class="input-group-addon" id="sp1"">Usuario</span>  
                            <asp:TextBox ID="tbUsuario" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                        </div>

                    </div>

                    <br /><br />

                    <div class="form-group"> 

                        <div class="input-group">

                            <span class="input-group-addon" id="sp2">Contraseña</span>
                            <asp:TextBox ID="tbPassword" class="form-control" aria-describedby="sp2" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                       
                        </div>

                    </div>

                    <br /><br />

                    <div class="form-group text-center">

                        <div class="btn-group">

                            <asp:Button ID="Button1" class="btn btn-default" runat="server" onclick="Button1_Click" Text="Limpiar" />
                            <asp:Button ID="Button3" class="btn btn-default" runat="server" onclick="Button3_Click" Text="Iniciar Sesion"/>
                            <asp:Button ID="Button2" class="btn btn-default" runat="server" onclick="Button2_Click" Text="Nuevo" />

                        </div>

                    </div>

                </form>

            </div>

        </div>

    </div>

</asp:Content>

    

