<%@ Page Title="Elra - Cómo Comprar" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComoComprar.aspx.cs" Inherits="ComoComprar" %>

<asp:Content id="HeaderContentComoComprar" runat="server" ContentPlaceHolderID="cphHeader">

</asp:Content>

<asp:Content id="BodyContentComoComprar" runat="server" ContentPlaceHolderID="cphBody">
    <div class="container">
        <div class="panel panel-primary">
		    <div class="panel-heading text-center">
			    <h2>¿Cómo Comprar?</h2>
		    </div>
            <div class="panel-body text-center">
		        <div style="color:#337AB7">
			        <a href="#1"> ¿Es necesario que me registre para realizar un pedido?</a><br />
			        <a href="#2"> ¿Cómo realizo un pedido ?</a><br />
			        <a href="#3"> ¿Cómo pago los productos que compro?</a><br />
			        <a href="#4"> ¿Los precios incluye IVA?</a><br />
			        <a href="#5"> ¿Qué garantía tiene los productos ?</a><br />
			        <a href="#6"> ¿Cuáles son los horarios de atención al público y online?</a><br />
		        </div>
            </div>
		</div>	
		<br />
			
		<hr class=" dl-horizontal" id="1"/>
        <br />
			
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Es necesario que me registre para realizar un pedido?</label>
			</div>
			<div class="panel-body text-justify">
				Si, es muy importante que te registres porque necesitamos la información para poder contactarnos en todo momento, 
				tambien es necesaria para confeccionar la factura que acompañará la mercadería.
				Tus datos no serán utilizados para otra cosa más que para gestionar el alta en nuestro sistema y agilizar toda
                la transacción. Tampoco se te enviará correo electrónico no solicitado.
            </div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>
		<br /><hr class="bordered" id="2" /><br />
			
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Cómo realizo un Pedido?</label>
			</div>
            <div class="panel-body text-justify">
			    <ol>
                    <li>Buscá tu producto dentro de cada categoría.</li>
                    <li>Agregalas al carrito.</li>
                    <li>Confirmá tu pedido.</li>
                    <li>Llamanos, o esperá nuestro llamado para coordinar el retiro.</li>
			    </ol>
            </div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>


		<br /><hr class="bordered" id="3" /><br />
			
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Cómo pago los productos que compro?</label>
			</div>
			<div class="panel-body text-justify">
				Debes concurrir al local para realizar la compra. La página permite realizar ordenes de Pedido para agilizar
                las transacciones y ver tus necesidades. A partir de la misma, nosotros podremos comunicarte nuestra disponibilidad
                y las alternativas.
			</div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>

		<br /><hr class="bordered" id="4"/><br />
			
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Los precios incluye IVA?</label>
			</div>
			<div class="panel-body text-justify">
				Los precios están expresados en pesos y se exiben con el IVA. Si necesitas factura especial con IVA discriminado se te
				pedirá que ingreses los datos básicos para confeccionar la factura.
			</div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>

		<br /><hr class="bordered" id="5" /><br />
			    
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Qué garantía tiene los productos?</label>
			</div>
			<div class="panel-body text-justify">
				Todos nuestros productos son nuevos y vienen en caja cerrada con su repectiva garantía. En caso que no estés conforme
				con tu compra podés traer el producto dentro de las 72 hs. y te devolvemos tu dinero. 
			</div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>

		<br /><hr class="bordered" id="6" /><br />
			    
        <div class="panel panel-default">
			<div class="panel-heading text-center">
                <label>¿Cuáles son los horarios de atención al público?</label>
			</div>
			<div class="panel-body text-justify">
				Nuestros horarios de atención al público es de Lunes a Viernes de 10:00 a 20:00 hs. y Sábados de 10:00 a 18:00 hs.
				De todas formas podrás ver en el momento todos nuestros productos y realizar cualquier pedido las 24hs. del día, tendiendo
				en cuenta que los envios serán despachados en horario comercial.  
			</div>
            <div class="panel-footer text-right">
                <a href="#" class="glyphicon glyphicon-triangle-top"></a>
            </div>
        </div>

		<br /><hr class="bordered" /><br />
		<br />
    </div>
</asp:Content>