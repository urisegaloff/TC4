
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TvAudioVideo.aspx.cs" Inherits="TvAudioVideo" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="cphTvAudioVideo" ContentPlaceHolderID="cphBody" Runat="Server">
    
<div class="panel panel-primary">
    <div class="panel-heading text-center">
        <asp:Label ID="lblTitulo" Text="Tv, Audio y Video" runat="server"></asp:Label>
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
                            <asp:Image ID="imgEquipo" Width="215px" Height="215px" ImageUrl="img\Audio.jpg" runat="server" />
                        </div>
                        <div class="panel-footer">
                            <asp:Label ID="lblPrecioArt" Text='<%# "$"+Eval("precio") %>' runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>

</asp:Content>
