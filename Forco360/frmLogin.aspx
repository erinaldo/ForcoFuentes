<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar sesión - FORCO360</title>
    <style type="text/css">
        #Form1 {
            height: 526px;
        }

        .style3 {
            width: 350px;
            height: 92px;
        }
    </style>
</head>
<body style="background-color: #f4f4f4; color: #5a5656; font-family: 'Open Sans', Arial, Helvetica, sans-serif; font-size: 16px; line-height: 1.5em;">
    <div style="position: absolute; top: 25%; left: 26%; margin-top: -50px; margin-left: -50px; width: 709px; height: 226px; right: 523px;">
        <form id="form1" runat="server">
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" BackColor="#F7F6F3"
                BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="217px" Width="294px">
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                <LayoutTemplate>
                    <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse; width: 532px;">
                        <tr>
                            <td>
                                <td align="left" style="width: 190px; height: 100%; background-repeat: no-repeat;"
                                    valign="middle">
                                    <img src="Images/logo_alpiste.jpg" />
                                </td>

                            </td>
                            <td>
                                <table border="0" cellpadding="0" style="height: 217px; width: 312px;" bgcolor="#669999">
                                    <tr>
                                        <td align="center" colspan="2" style="color: White; background-color: #5D7B9D; font-size: 0.9em; font-weight: bold;">Forco 360
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="Small" ForeColor="White">Usuario:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Size="Small" Height="20px" Width="160px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="Small" ForeColor="White">Contraseña:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Font-Size="Small" TextMode="Password" Height="20px"
                                                Width="160px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Recordarme la próxima vez." ForeColor="White" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" Style="margin-right: 30px;"
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login"
                                                Font-Names="Verdana" Font-Size="Small" ForeColor="#284775" Text="Ingresar" ValidationGroup="Login1"
                                                OnClick="LoginButton_Click" Height="24px" Width="66px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <a style="margin-left: 5px;" href="RecuperarClave.aspx">¿No recuerda su contraseña?</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            </asp:Login>
        </form>
    </div>
</body>
</html>
