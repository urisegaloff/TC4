<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="Articulos.aspx.cs" Inherits="Articulos" %>

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
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Descripcion</span>
                                    <asp:TextBox ID="tbDescripcion" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                            </div>                           
                           <hr />              
                    
                        <div class="form-group text-center">
                            <asp:Button ID="btnBuscar" class="btn btn-primary" runat="server" onclick="btnBuscar_Click" Text="Buscar"/>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="btnNuevo" class="btn btn-primary" runat="server" onclick="btnNuevo_Click" Text="Nuevo Articulo"/>
                        </div>
                    </div>
                    <div class ="panel-footer">
                        <asp:Label ID="lblAviso" CssClass="alert-info" runat="server"></asp:Label>
                   </div>
                </div>
            </div>
            <br />
            <div class="container-fluid">
                <div id="divPanel" class="panel panel-primary col-lg-6 col-lg-offset-3" visible="false" runat="server">
                    <div class="panel-body">
                        <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered" HeaderStyle-BackColor="#80B1DC" AlternatingRowStyle-BackColor="WhiteSmoke" runat="server" AutoGenerateColumns="False" OnRowCreated="dgResultados_RowCreated" OnRowDeleting="dgResultados_RowDeleting" OnRowEditing="dgResultados_RowEditing" DataKeyNames="idProducto">
                            <Columns>
                                <asp:BoundField DataField="IdProducto" HeaderText="# Prod."></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>                                
                                <asp:CommandField EditText="<asp:ImageButton class='glyphicon glyphicon-edit' runat='server' />" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ShowEditButton="True" />
                                <asp:CommandField DeleteText="<asp:ImageButton class='glyphicon glyphicon-remove' runat='server' />" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

