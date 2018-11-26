<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAccessDenied.aspx.vb" Inherits="frmAccessDenied" Title="Acceso Denegado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Acceso Denegado</title>
</head>
<body>
    <form id="form1" runat="server">
<table cellpadding="5" style="vertical-align: top; height: 100%; background-color: #ffffff;" width="100%">
        <tr>
            <td style="width: 207px" valign="top">
                <br />
                <br />
                <img src="images/seguridad.png" style="width: 208px; height: 255px" /><br />
            </td>
            <td valign="top">
                <br />
                <br />
                <asp:Label ID="lblAccessDenied" runat="server" Font-Bold="True" Font-Size="XX-Large"
                    ForeColor="Red"></asp:Label><br />
                <br />
                <asp:Label ID="lblMensajeUsuario" runat="server" ForeColor="#404040"></asp:Label><br />
                <br />
                <asp:Label ID="lblIndications" runat="server" Font-Names="Arial" Font-Size="Small"
                    ForeColor="Gray"></asp:Label><br />
                <br />
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
