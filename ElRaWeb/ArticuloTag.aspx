﻿<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="ArticuloTag.aspx.cs" Inherits="ArticuloTag" %>

<asp:Content ID="HeaderContentLogin" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentLogin" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formRegistro" runat="server" >
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Agregar Tags</h4>
                    </div>
                    <div class="panel-body">                              
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp2">ID</span>
                                <asp:TextBox ID="tbID" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="valTbID" ValidationGroup="valAgregarTag" ControlToValidate="tbID" runat="server" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                        </div>                
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="sp1">Tag:</span>
                                <asp:dropdownlist CssClass=" form-control" id ="ddlTags" runat ="server"> </asp:dropdownlist >
                            </div>
                        </div>                         
                        <div class="form-group text-center">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" CausesValidation="true" ValidationGroup="valArticuloTag"  runat="server" onclick="btnAgregar_Click" Text="Agregar"/>
                        </div>                               
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="IDTag">
                                    <Columns>
                                        <asp:BoundField DataField="IDTag" HeaderText="Cod. Tag"></asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>                                
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class ="panel-footer text-center">
                        <div class="form-group text-center">
                            <asp:Button ID="btnVolver" class="btn btn-primary" runat="server" onclick="btnVolver_Click" Text="Volver"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

