<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="HeaderContentLogin" ContentPlaceHolderID="cphHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContentLogin" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="container-fluid">
        <div class="form-inline " id="formUsuarios" runat="server" >
            <div class="col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                     <div class="panel-heading text-center">
                        <h4 class="h4">Login</h4>
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
                        <asp:GridView id="dgResultados" runat="server" AutoGenerateColumns="False" OnRowCreated="dgResultados_RowCreated" OnRowDeleting="dgResultados_RowDeleting" OnRowEditing="dgResultados_RowEditing" DataKeyNames="Legajo">
					        <Columns>
                                <asp:CommandField EditText="Editar" ShowEditButton="True" />
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" />
						        <asp:BoundField DataField="Correo" HeaderText="Legajo"></asp:BoundField>
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

    

