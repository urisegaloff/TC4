
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    
<div id="carousel" class="carousel slide" data-ride="carousel">
    <!-- Indicadores -->
    <ol class="carousel-indicators">
        <li data-target="#carousel" data-slide-to="0" class="active"></li>
        <li data-target="#carousel" data-slide-to="1"></li>
        <li data-target="#carousel" data-slide-to="2"></li>
    </ol>
    <!-- Envoltura por cada slide -->
    <div class="carousel-inner" role="listbox">
        <div class="item active">
            <img src="http://www.sisaypc.net/themes/ap_funiture/img/modules/leosliderlayer/logitech1170.jpg" alt="Alto monitor">
            <div class="carousel-caption">
                Un monitor de punta
            </div>
        </div>
        <div class="item">
            <img src="http://www.sisaypc.net/themes/ap_funiture/img/modules/leosliderlayer/conceptronic1170.jpg" alt="...">
            <div class="carousel-caption">
                Una pc super gamer
            </div>
        </div>
        <div class="item">
            <img src="http://adshop.com.vn/image/cache/catalog/Slide/slide3-adshop.com.vn-1170x300.jpg" alt="...">
            <div class="carousel-caption">
                Una mega notebook
            </div>
        </div>
    </div>
    <!-- Controles -->
    <a class="left carousel-control" href="#carousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#carousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
    <table>
        <tr>
        <td>Configuración 1:</td>
        <td><asp:Label runat="server" ID="lblConfig1"></asp:Label></td>
        </tr>
    </table>         
</div>
    
    <!--<table>
        <tr>
            <td>Configuración 2:</td>
            <td><asp:Label runat="server" ID="lblConfig2"></asp:Label></td>
        </tr>
        <tr id="row">
            <td>Hola</td>
        </tr>
    </table>-->
</asp:Content>

