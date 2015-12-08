
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perifericos.aspx.cs" Inherits="Perifericos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="cphBodyPerifericos" ContentPlaceHolderID="cphBody" Runat="Server">

<div id="alertOK" class="alert alert-success text-center" visible="false" role="alert" runat="server"><strong>¡Hecho!</strong> El producto se agrego satisfactoriamente</div>
<div id="alertNOT" class="alert alert-danger text-center" visible="false" role="alert" runat="server"><strong>¡Error!</strong> No se pudo agregar el producto.</div>
        
<div class="panel panel-primary">
    <div class="panel-heading text-center">
        <asp:Label ID="lblTitulo" Text="Tv, Audio y Video" runat="server"></asp:Label>
    </div>
    <div class="panel-body">
        <asp:DataList ID="vidriera" runat="server" RepeatColumns="4"  CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Table" OnItemCommand = "vidriera_ItemCommand">  
            <ItemTemplate>                    
                <div class="container-fluid">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label ID="lblNombreArt" Text='<%# Eval("descripcion") %>' runat="server"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:Image ID="imgEquipo" Width="215px" Height="215px" ImageUrl="img\Audio.jpg" runat="server" />
                        </div>
                        <div class="panel-footer text-center">                            
                            <asp:Label ID="lblPrecioArt" Text='<%# "$"+Eval("precio") %>' runat="server"></asp:Label>
                            <asp:LinkButton ID="btnAgregarACarrito" CssClass="btn btn-primary" CommandName="btnAgregarACarrito" runat="server"><span class="glyphicon glyphicon-shopping-cart"></span></asp:LinkButton>
                            <asp:TextBox ID="tbCantidad" BorderWidth="1px" style="text-align:center" BorderColor="#337AB7" Width="30" Height="27px" runat="server">1</asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField id="hfIdProducto" value='<%# Eval("idProducto") %>' runat="server" />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>

</asp:Content>