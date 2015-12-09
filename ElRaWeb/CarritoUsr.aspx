<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="CarritoUsr.aspx.cs" Inherits="CarritoUsr" %>

<asp:Content ID="HeaderContentArticulos" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentArticulos" ContentPlaceHolderID="cphBody" Runat="Server">
     <div class="form-inline " id="formUsuarios" runat="server" >
        <div class="panel-group">
            <div class="container-fluid">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Buscar Articulo</h4>
                    </div>
                    <div class="panel-body">                    
                    </div>
                    <div class ="panel-footer">
                        
                   </div>
                </div>
            </div>
            <br />
            <div class="container-fluid">
                <div class="panel panel-primary col-lg-6 col-lg-offset-3">
                    <div class="panel-body">
                        <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False" OnRowEditing="dgResultados_RowEditing" DataKeyNames="IdProducto">
                            <Columns>
                                <asp:BoundField DataField="IdProducto" HeaderText="# Prod" ItemStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>        
                                <asp:CommandField EditText="<asp:ImageButton class='glyphicon glyphicon-edit' runat='server' />" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ShowEditButton="True" />
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

    

