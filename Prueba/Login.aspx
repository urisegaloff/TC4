<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prueba.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 210px">
    <table align="center" style="margin-top:105px">
          <tr>
            <td>Usuario</td>  
            <td colspan = 2><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
          </tr>
          <tr> 
            <td>Contraseña:</td>
            <td><asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></td>
             <td><asp:Label ID="Label1" runat="server" BackColor="White" EnableTheming="False" 
                    ForeColor="Red" Font-Bold="True"></asp:Label>
              </td>
           </tr>
           <tr>
            <td><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Limpiar" /></td>
            <td><asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="Iniciar Sesion" Width="121px"/></td>
            <td><asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Nuevo" 
                    Width="51px" /></td>

            </tr>
    </table>
    </div>
    </form>
</body>
</html>
