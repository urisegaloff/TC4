<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="Articulo.aspx.cs" Inherits="Articulo" %>

<asp:Content ID="HeaderContentArticulo" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentArticulo" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline" id="formRegistro" runat="server" >
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Articulo</h4>
                    </div>
                    <div class="panel-body">                    
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp1"">ID</span>
                                <asp:TextBox ID="tbID" class="form-control" aria-describedby="sp1" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbId" ValidationGroup="valAltaArticulo" ControlToValidate="tbID" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group"> 
                            <div class="input-group">
                                <span class="input-group-addon" id="sp2">Descripcion</span>
                                <asp:TextBox ID="tbDescripcion" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbDescripcion" ValidationGroup="valAltaArticulo" ControlToValidate="tbDescripcion" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                            <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp3"">Stock</span>
                                <asp:TextBox ID="tbStock" class="form-control" aria-describedby="sp3" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbStock" ValidationGroup="valAltaArticulo" ControlToValidate="tbStock" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp4"">Precio</span>
                                <asp:TextBox ID="tbPrecio" class="form-control" aria-describedby="sp4" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbPrecio" ValidationGroup="valAltaArticulo" ControlToValidate="tbPrecio" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp5"">Fecha Baja</span>
                                <asp:TextBox ID="tbFecha" class="form-control" aria-describedby="sp6" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbFecha" ValidationGroup="valAltaArticulo" ControlToValidate="tbFecha" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                        </div>                            
                    </div>
                    <div class ="panel-footer text-center">
                        <div class="form-group text-center">
                            <asp:Button ID="btnRegistro" class="btn btn-primary" CausesValidation="true" ValidationGroup="valAltaArticulo" runat="server" onclick="btnRegistro_Click" Text="Aceptar"/>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="btnTags" class="btn btn-primary" runat="server" onclick="btnTags_Click" Text="Agregar Tags"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

