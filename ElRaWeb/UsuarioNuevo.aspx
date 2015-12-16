<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="UsuarioNuevo.aspx.cs" Inherits="Registro" %>

<asp:Content ID="BodyContentNuevoUsuario" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formRegistro" runat="server" >
            <div class="col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Login</h4>
                    </div>
                      <div class="panel-body">                    
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">E-Mail</span>
                                    <asp:TextBox ID="tbMail" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group"> 
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1">Contraseña</span>
                                    <asp:TextBox ID="tbPassword" class="form-control" aria-describedby="sp1" runat="server" ></asp:TextBox>
                                </div>
                                <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Nombre</span>
                                    <asp:TextBox ID="tbNombre" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Apellido</span>
                                    <asp:TextBox ID="tbApellido" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Telefono</span>
                                    <asp:TextBox ID="tbTelefono" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Domicilio</span>
                                    <asp:TextBox ID="tbDomicilio" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="spPermiso" visible="false" runat="server">Permiso</span>
                                    <asp:TextBox ID="tbPermiso" class="form-control" aria-describedby="sp2" Visible="false" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                    </div>
                    <div class ="panel-footer text-center">
                        <div class="form-group text-center">
                            <asp:Button ID="btnRegistro" class="btn btn-primary" runat="server" onclick="btnRegistro_Click" Text="Aceptar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

