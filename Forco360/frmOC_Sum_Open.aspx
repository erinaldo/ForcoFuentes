<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmOC_Sum_Open.aspx.vb" Inherits="frmOC_Sum_Open" Title="Contactos Cliente" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="border-style: solid; border-width: thin; width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; height: 1%" align="left" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="left" valign="top" bgcolor="#339966">
                             <asp:Button ID="btnAgregar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Agregarr" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton"
                                Width="80px" Visible="False" />
                            <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Cerrar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Width="80px" /></td>
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
                                                                <dx:ASPxDateEdit ID="dtpInicio" runat="server" DisplayFormatString="dd/MM/yyyy" AllowNull="False" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label2" runat="server" Text="Fecha Final :"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxDateEdit ID="dtpFinal" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="middle" align="right">
                                                                <asp:Label ID="Label1" runat="server" Text="Proveedor :"></asp:Label></td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="lkProveedor" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial">
                                                                </asp:DropDownList></td>

                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="middle" align="right">
                                                                <asp:Label ID="lblTipoContacto" runat="server" Text="Estado :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="lkEstado" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial">
                                                                </asp:DropDownList>
                                                                <asp:Button ID="btnFiltro" runat="server" Font-Size="XX-Small" Width="83px" Text="Filtrar"></asp:Button>
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
                        <tr>
                            <td style="width: 100%; height: 20px; border-bottom-style: solid; border-bottom-width: thin;" valign="top" align="center"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 99%" valign="top" align="center">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100%; height: 100%" valign="top" align="center">
                                                <asp:Panel ID="Panel1" runat="server" Height="372px" ScrollBars="Both">
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="2px" ForeColor="#333333" GridLines="None" CellPadding="4" 
                                                        AutoGenerateColumns="False">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:HyperLinkField>
                                                                <ItemStyle Width="10px" />
                                                            </asp:HyperLinkField>
                                                            <asp:HyperLinkField>
                                                                <ItemStyle Width="10px" />
                                                            </asp:HyperLinkField>
                                                            <asp:BoundField DataField="Orden_Id" HeaderText="Orden">
                                                                <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Orden_Fecha_Crea" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                                                <ItemStyle HorizontalAlign="Left" Width="20px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Orden_Estado" HeaderText="Logical">
                                                                <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strCompra_Status" HeaderText="Estado">
                                                                <ItemStyle HorizontalAlign="Left" Width="5px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Prov_Nombre" HeaderText="Proveedor">
                                                                <ItemStyle HorizontalAlign="Left" Width="190px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Usuario_Crea" HeaderText="Usuario Reg.">
                                                                <ItemStyle HorizontalAlign="Left" Width="20px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="dtmFecha_Auto" HeaderText="Fecha_Auto" DataFormatString="{0:dd/MM/yyyy}">
                                                                <ItemStyle HorizontalAlign="Left" Width="15px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strUsuario_Auto" HeaderText="Usuario_Auto">
                                                                <ItemStyle HorizontalAlign="Left" Width="15px"></ItemStyle>
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
