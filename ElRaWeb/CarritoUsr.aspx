<%@ Page Language="C#" MasterPageFile="~/MasterPageAutenticado.master" AutoEventWireup="true" CodeFile="CarritoUsr.aspx.cs" Inherits="CarritoUsr" %>

<asp:Content ID="HeaderContentArticulos" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentArticulos" ContentPlaceHolderID="cphBody" Runat="Server">
     <div class="form-inline " id="formUsuarios" runat="server" >
        <div class="panel-group">
            <div class="container-fluid">
                <div id="alertOK" class="alert alert-success text-center" visible="false" role="alert" runat="server"><strong>¡Hecho!</strong> El producto se eliminó satisfactoriamente</div>
                <div id="alertNOT" class="alert alert-danger text-center" visible="false" role="alert" runat="server"><strong>¡Error!</strong> No se pudo eliminar el producto.</div>
            </div>
            <br />
            <div class="container-fluid">
                <div class="panel panel-primary col-lg-6 col-lg-offset-3">
                    <div class="panel-body">
                        <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgResultados_RowDeleting" DataKeyNames="IdProducto">
                            <Columns>
                                <asp:BoundField DataField="IdProducto" HeaderText="# Prod" ItemStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
                                <asp:BoundField DataField="Precio" HeaderText="Precio"></asp:BoundField>
                                <asp:BoundField DataField="stock" HeaderText="Cantidad"></asp:BoundField>
                                <asp:CommandField DeleteText="<asp:ImageButton class='glyphicon glyphicon-remove' runat='server' />" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ShowDeleteButton="True" />                            
                            </Columns>
                        </asp:GridView>
                    </div>                                         
                    <div class="form-group text-center">
                        <asp:Button ID="btnConfirmar" class="btn btn-primary" runat="server" onclick="btnConfirmar_Click" Text="Confirmar Pedido"/>
                    </div>
                    <div class="form-group text-center">
                        <asp:Button ID="btnEliminar" class="btn btn-primary" runat="server" onclick="btnEliminar_Click" Text="Eliminar Pedido"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

