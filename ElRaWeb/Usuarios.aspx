<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="HeaderContentLogin" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentLogin" ContentPlaceHolderID="cphBody" Runat="Server">
     <div class="form-inline " id="formUsuarios" runat="server" >
        <div class="panel-group">
            <div class="col-xs-4 ">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Buscar Usuario</h4>
                    </div>
                      <div class="panel-body">                    
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">E-Mail</span>
                                    <asp:TextBox ID="tbMail" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Nombre</span>
                                    <asp:TextBox ID="tbNombre" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon" id="sp1"">Apellido</span>
                                    <asp:TextBox ID="tbApellido" class="form-control" aria-describedby="sp2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                           <hr />                   
                    
                        <div class="form-group text-center">
                            <asp:Button ID="btnBuscar" class="btn btn-primary" runat="server" onclick="btnBuscar_Click" Text="Buscar"/>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="btnNuevo" class="btn btn-primary" runat="server" onclick="btnNuevo_Click" Text="Nuevo Usuario"/>
                        </div>
                    </div>
                    <div class ="panel-footer">
                        
                   </div>
                </div>
            </div>
            <br />
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:GridView id="dgResultados" CssClass="table table-condensed table-bordered" runat="server" AutoGenerateColumns="False" OnRowCreated="dgResultados_RowCreated" OnRowDeleting="dgResultados_RowDeleting" OnRowEditing="dgResultados_RowEditing" DataKeyNames="mail">
                            <Columns>
                                <asp:CommandField EditText="Editar" ShowEditButton="True" />
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" />
                                <asp:BoundField DataField="mail" HeaderText="E-Mail"></asp:BoundField>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido"></asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

    

