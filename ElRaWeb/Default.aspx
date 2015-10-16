
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
    
    <table>
        <tr>
            <td>Configuración 1:</td>
            <td><asp:Label runat="server" ID="lblConfig1"></asp:Label></td>
        </tr>
        <tr>
            <td>Configuración 2:</td>
            <td><asp:Label runat="server" ID="lblConfig2"></asp:Label></td>
        </tr>
        <tr id="row">
            <td>Hola</td>
        </tr>
    </table>



</asp:Content>

