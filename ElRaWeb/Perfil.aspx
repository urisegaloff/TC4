<%@ Page Language="C#" MasterPageFile="~/MAsterPageHerramientas.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Registro" %>

<asp:Content ID="HeaderContentPerfil" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentPerfil" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formRegistro" runat="server" >
            <div class="col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Mis datos</h4>
                    </div>
                      <div class="panel-body">                    
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1">E-Mail</span>
                                    <asp:TextBox ID="tbMail" class="form-control" aria-describedby="sp1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group"> 
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp2">Contraseña</span>
                                    <asp:TextBox ID="tbPassword" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="valTbPassword" ValidationGroup="valModPerfil" ControlToValidate="tbPassword" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp3">Nombre</span>
                                    <asp:TextBox ID="tbNombre" class="form-control" aria-describedby="sp3" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="valTbNombre" ValidationGroup="valModPerfil" ControlToValidate="tbNombre" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp4">Apellido</span>
                                    <asp:TextBox ID="tbApellido" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="valTbApellido" ValidationGroup="valModPerfil" ControlToValidate="tbApellido" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp5">Telefono</span>
                                    <asp:TextBox ID="tbTelefono" class="form-control" aria-describedby="sp5" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="valTbTelefono" ValidationGroup="valModPerfil" ControlToValidate="tbTelefono" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp6">Domicilio</span>
                                    <asp:TextBox ID="tbDomicilio" class="form-control"  aria-describedby="sp6" runat="server"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="valTbDomicilio" ValidationGroup="valModPerfil" ControlToValidate="tbDomicilio" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <hr />
                    </div>
                    <div class ="panel-footer text-center">
                        <div class="form-group text-center">
                            <asp:Button ID="btnModPerfil" class="btn btn-primary" CausesValidation="true" ValidationGroup="valModPerfil" runat="server" onclick="btnModPerfil_Click" Text="Aceptar"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

