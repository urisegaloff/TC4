
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perifericos.aspx.cs" Inherits="Perifericos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="cphBodyPerifericos" ContentPlaceHolderID="cphBody" Runat="Server">
    
<div class="panel panel-primary">
    <div class="panel-heading text-center">
        <asp:Label ID="lblTitulo" Text="Perifericos" runat="server"></asp:Label>
    </div>
    <div class="panel-body">
        <asp:DataList ID="vidriera" runat="server" RepeatColumns="4"  CellSpacing="10" RepeatDirection="Horizontal" RepeatLayout="Table">  
            <ItemTemplate>                    
                <div class="container-fluid">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label ID="lblNombreArt" Text='<%# Eval("descripcion") %>' runat="server"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:Image ID="imgEquipo" Width="215px" Height="215px" ImageUrl="img\perifericos.png" runat="server" />
                        </div>
                        <div class="panel-footer">                            
                            <asp:Label ID="lblPrecioArt" Text='<%# "$"+Eval("precio") %>' runat="server"></asp:Label>
                            <div class="text-right">
                                <asp:LinkButton ID="btnAgregarACarrito"  CssClass="btn btn-primary" OnClick="btnAgregarACarrito_Click" runat="server"><span id="descBTN" class="glyphicon glyphicon-shopping-cart"></span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>

</asp:Content>
