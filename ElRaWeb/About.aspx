<%@ Page Title="About Us" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>
    
<asp:Content ID="HeaderContentAbout" runat="server" ContentPlaceHolderID="cphHeader">
    <style>
        #map {
            width: 100%;
            height: 85%;
        }

    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="cphBody">
    <form id="formContacto" runat="server">
    <div class="col-lg-5">
        <div class="panel panel-primary ">
            <div class="panel-heading">
                Contacto
            </div>
            <div class="panel-body" style="padding:10px;">
                <ul>
                    <li>Tel: 1111-1111</li>
                    <li>Facebook: facebook.com/elra</li>
                    <li>Twitter: twitter/elratwitter</li>
                    <li>E-Mail: elra@gmail.com</li>
                    <li>Dirección: Yatay 240, CP(1184), Ciudad Autónoma de Buenos Aires, Argentina</li>
                    <li>Horarios: Lunes a Viernes de 10:00 a 20:00hs. y Sábados de 10:00 a 18:00hs.</li>
                </ul>
            </div>
        </div>
        <div class="panel panel-primary ">
            <div class="panel-heading">
                Envianos un mensaje
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-2">
                            <asp:Label ID="lblNombreContacto" for="tbNombreContacto" runat="server" Text="Nombre"></asp:Label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="tbNombreContacto" class="form-control" size="10" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <asp:Label ID="lblMailContacto" runat="server" Text="E-Mail"></asp:Label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="tbMailContacto" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <asp:Label ID="lblMensajeContacto" runat="server" Text="Mensaje"></asp:Label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox ID="tbMensajeContacto" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-7">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Mapa
            </div>
            <div class="panel-body">
                <ul>
                    
                </ul>
                <div id="map"></div>
            </div>
        </div>
    </div>

    <script>
        function initMap() {
            var myLatLng = { lat: -34.6099545, lng: -58.4290547 };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: myLatLng
            });

            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: 'Elra'
            });
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAQhMp21NhC70iRdXW92nnO96p_lPy36Ag&signed_in=true&callback=initMap"></script>

    </form>
</asp:Content>
