﻿<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="CarritoBuscarProducto.aspx.cs" Inherits="CarritoBuscarProducto" %>

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

                          <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp2"">Marca</span>
                                    <asp:TextBox ID="tbMarca" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                            </div> 

                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp3"">Cod. Articulo</span>
                                    <asp:TextBox ID="tbCodigo" class="form-control" aria-describedby="sp3" runat="server"></asp:TextBox>
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
                                <asp:CommandField EditText="Agregar" ShowEditButton="True" />                        
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

