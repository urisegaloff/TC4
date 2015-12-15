<%@ Page Language="C#" MasterPageFile="~/MasterPageAutenticado.master" AutoEventWireup="true" CodeFile="TodosLosCarritos.aspx.cs" Inherits="TodosLosCarritos" %>

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
                        <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered table-hover table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="id_pedido">
                            <Columns>                                
                                <asp:BoundField DataField="id_pedido" HeaderText="# Pedido"></asp:BoundField>
                                <asp:BoundField DataField="idUsuario" HeaderText="Cliente" ></asp:BoundField>
                                <asp:BoundField DataField="IdProducto" HeaderText="# Prod" ItemStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
                                <asp:BoundField DataField="Precio" HeaderText="Precio"></asp:BoundField>
                                <asp:BoundField DataField="stock" HeaderText="Cantidad"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>                                         
                    <div class="form-group text-center">
                        <asp:Button ID="btnVolver" class="btn btn-primary" runat="server" onclick="btnVolver_Click" Text="Menu Principal"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

