<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmOC_Sum_Data.aspx.vb"
    Inherits="frmOC_Detalle" Title="Cupones" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="border-style: solid; border-width: thin; width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; height: 1%" align="left" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="left" valign="top" bgcolor="#339966">
                            <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Regresar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton"
                                Width="80px" />                            
                            <asp:Button ID="btnCerrar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Cerrar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton"
                                Width="80px" />
                        </td>
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
                                                                <asp:Label ID="lblConsecutivo" runat="server" Text="Orden :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtOrden" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label1" runat="server" Text="Solicita :" __designer:wfdid="w223"
                                                                    Font-Size="10pt" Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtSolicita" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:" __designer:wfdid="w236" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtFecha" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblNota" runat="server" Text="Notas:"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtNotas" runat="server" Font-Size="9pt" Width="300px" Height="50px"
                                                                    ForeColor="Black" Font-Names="Arial" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProveedor" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label2" runat="server" Text="Ced. Juridica :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProv_Cedula" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label6" runat="server" Text="Correo :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProv_Correo" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label3" runat="server" Text="Dirección :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProv_Direccion" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label4" runat="server" Text="Telefono :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProv_Telefono" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label5" runat="server" Text="Banco Cta :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtProv_Cuenta" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="middle" align="right">
                                                                <asp:Label ID="lblTipoContacto" runat="server" Text="Estado :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="lkEstado" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial" Enabled="False">
                                                                </asp:DropDownList>
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
                                                <asp:Panel ID="Panel1" runat="server" Height="283px" ScrollBars="Both">
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="1px" ForeColor="#333333"
                                                        GridLines="None" CellPadding="4" AutoGenerateColumns="False" Style="margin-top: 0px">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="Articulo_Id" HeaderText="Código" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Articulo_Nombre" HeaderText="Descripción" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Detalle_Cantidad" HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Detalle_Costo_Neto" HeaderText="Precio Unitario" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:n}">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Detalle_Total" HeaderText="Total" ItemStyle-HorizontalAlign="Center" ApplyFormatInEditMode="True" DataFormatString="{0:n}">
                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
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
                        <tr>
                            <td style="width: 100%; height: 20%" align="left" valign="top">
                                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 10%; height: 1px" valign="middle" align="right">
                                            <asp:Label ID="Label7" runat="server" Text="Sub-Total :" __designer:wfdid="w223"
                                                Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td style="width: 735px; height: 1px" valign="middle" align="left">
                                            <asp:TextBox ID="txtSubTotal" runat="server" Font-Size="9pt" Width="100px" ForeColor="Black"
                                                Font-Names="Arial" Enabled="False" Font-Bold="False">0</asp:TextBox>
                                        </td>
                                        <td style="width: 735px; height: 1px" valign="middle" align="left">&nbsp;</td>
                                        <td style="width: 30%; height: 1px" valign="middle" align="right">
                                            <asp:Label ID="Label8" runat="server" Text="Descuento :" __designer:wfdid="w223"
                                                Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td style="width: 735px; height: 1px" valign="middle" align="left">
                                            <asp:TextBox ID="txtDescuento" runat="server" Font-Size="9pt" Width="100px" ForeColor="Black"
                                                Font-Names="Arial" Enabled="False" Font-Bold="False">0</asp:TextBox>
                                        </td>
                                        <td style="width: 30%; height: 1px" valign="middle" align="right">
                                            <asp:Label ID="Label9" runat="server" Text="Impuesto :" __designer:wfdid="w223"
                                                Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td style="width: 735px; height: 1px" valign="middle" align="left">
                                            <asp:TextBox ID="txtImpuesto" runat="server" Font-Size="9pt" Width="100px" ForeColor="Black"
                                                Font-Names="Arial" Enabled="False" Font-Bold="False">0</asp:TextBox>
                                        </td>
                                        <td style="width: 30%; height: 1px" valign="middle" align="right">
                                            <asp:Label ID="Label10" runat="server" Text="Total :" __designer:wfdid="w223"
                                                Font-Size="10pt"></asp:Label>
                                        </td>
                                        <td style="width: 735px; height: 1px" valign="middle" align="left">
                                            <asp:TextBox ID="txtTotal" runat="server" Font-Size="9pt" Width="100px" ForeColor="Black"
                                                Font-Names="Arial" Enabled="False" Font-Bold="False">0</asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px; border-bottom-style: solid; border-bottom-width: thin;" valign="top" align="center"></td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
