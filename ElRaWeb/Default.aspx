
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="cphDefaultHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <style>
        .carousel-caption{
            color: #44A9FF; 
        }
        
        .carousel-indiators{
            color: #44A9FF;
        }
    </style>
</asp:Content>

<asp:Content ID="cphDefault" ContentPlaceHolderID="cphBody" Runat="Server">
<div class="container">
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
                <img src="img\AudioVid.png" alt="Alto monitor">
                <div class="carousel-caption">
                    El mejor audio y video para tu hogar
                </div>
            </div>
            <div class="item">
                <img src="img\mbaio.jpg" alt="...">
                <div class="carousel-caption">
                    Computadoras con los mejores componentes
                </div>
            </div>
            <div class="item">
                <img src="img\nb.jpg" alt="...">
                <div class="carousel-caption">
                    Notebooks de primer nivel
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
    </div>
</div>    
   
</asp:Content>

