<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="HeaderContentLogin" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentLogin" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formLogin" runat="server">
            <div class="col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-2">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Login</h4>
                    </div>
                      <div class="panel-body text-center ">
                    
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
                                </div>
                                <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                            </div>
                            <hr />
                            <div class="form-group text-center">
                                <asp:Button ID="btnInicioSesion" class="btn btn-primary" runat="server" onclick="btnIniciarSesion_Click" Text="Iniciar Sesion"/>
                            </div>

                    </div>
                </div>
            </div>

            <div class="col-sm-4 col-md-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">¿No tenes usuario?</h4>
                    </div>
                      <div class="panel-body text-center ">
                        <h3>Registrate</h3>
                          <p>
                              Solo toma unos segundos, dejanos tus datos y podrás realizar tu orden de pedido al instante.
                          </p>
                          <p>
                             Tus datos son confidenciales y no serán publicados sin tu permiso.
                          </p>
                          <hr />
                          <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" runat="server" Text="Registrate" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

