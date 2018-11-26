<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmConstancia_Open.aspx.vb" Inherits="frmConstancia_Open" Title="Contactos Cliente" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; height: 1%" align="left" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="center" valign="top">
                            <asp:Button ID="btnAdd" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White" Text="Agregar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Visible="True" Width="80px" />
                            <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White" Text="Cerrar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Width="80px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px" align="center" valign="top"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 99%" align="left" valign="top">
                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td style="width: 100%; height: 1%" valign="top" align="left">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio :"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <ew:CalendarPopup ID="cpFechaInicio" runat="server" Font-Size="3px" Width="80px" ForeColor="Transparent" AutoPostBack="True">
                                                                </ew:CalendarPopup>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFechaFinalizada" runat="server" Text="Fecha Fin :"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <ew:CalendarPopup ID="cpFechaFinalizada" runat="server" Font-Size="3px" Width="80px" ForeColor="Transparent" AutoPostBack="True">
                                                                </ew:CalendarPopup>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="top" align="right">
                                                                <asp:Label ID="Label1" runat="server" Text="Tipo :"></asp:Label></td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="ddlTipo" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial" AutoPostBack="True">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="top" align="right">
                                                                <asp:Label ID="lblTipoContacto" runat="server" Text="Status :"></asp:Label></td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial" AutoPostBack="True">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px" valign="top" align="center"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 99%" valign="top" align="center">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100%; height: 100%" valign="top" align="center">
                                                <asp:Panel ID="Panel1" runat="server" Width="800px" Height="350px" ScrollBars="Both">
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="1px" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:HyperLinkField></asp:HyperLinkField>
                                                            <asp:HyperLinkField></asp:HyperLinkField>
                                                            <asp:BoundField DataField="nRecno" HeaderText="nRecno" Visible="False"></asp:BoundField>
                                                            <asp:BoundField DataField="nCode" HeaderText="NUMERO">
                                                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtmFecha" HeaderText="FECHA">
                                                                <ItemStyle HorizontalAlign="Left" Width="80px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strTipo" HeaderText="TIPO">
                                                                <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strEmpleado" HeaderText="EMPLEADO">
                                                                <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strStatus" HeaderText="STATUS">
                                                                <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                        <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>
                                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                        <HeaderStyle BackColor="#1C5E55" CssClass="GridHeader" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>
                                                        <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRow"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

