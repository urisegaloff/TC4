﻿<%@ Page Language="C#" MasterPageFile="~/MasterPageHerramientas.master" AutoEventWireup="true" CodeFile="TipoTag.aspx.cs" Inherits="TipoTag" %>

<asp:Content ID="HeaderContentTipoTag" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentTipoTag" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formRegistro" runat="server" >
            <div class="col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Tipo Tag</h4>
                    </div>
                      <div class="panel-body">                    
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">ID</span>
                                    <asp:TextBox ID="tbID" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group"> 
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp2">Descripcion</span>
                                    <asp:TextBox ID="tbDescripcion" class="form-control" aria-describedby="sp2" runat="server" ></asp:TextBox>
                                </div>
                                <asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                            </div>                                      
                        </div>
                    
                        <div class ="panel-footer text-center">
                            <div class="form-group text-center">
                                <asp:Button ID="btnRegistro" class="btn btn-primary" runat="server" onclick="btnRegistro_Click" Text="Aceptar"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
</asp:Content>

    

