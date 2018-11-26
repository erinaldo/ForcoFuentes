<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmOC_Detalle.aspx.vb"
    Inherits="frmOC_Detalle" Title="Cupones" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; height: 1%" align="left" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="left" valign="top" bgcolor="#CC0000">
                            <asp:Button ID="btnSave" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Gurardar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Visible="True"
                                Width="80px" />
                            <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Cerrar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton"
                                Width="80px" />
                        </td>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" />
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
                                                <table style="width: 100%; height: 100%" cellspacing="8" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo:" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtNumero" runat="server" Font-Size="Small" Width="100px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="True">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:" __designer:wfdid="w236" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <ew:CalendarPopup ID="cpFecha" runat="server" Width="100px" ForeColor="Transparent"
                                                                    AutoPostBack="True" PadSingleDigits="True" Font-Size="Small"
                                                                    Enabled="False">
                                                                </ew:CalendarPopup>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblTipo" runat="server" Text="Tipo:" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:RadioButton ID="rbContado" runat="server" GroupName="Tipo" Text="Contado" />
                                                                <asp:RadioButton ID="rbCredito" runat="server" GroupName="Tipo" Text="Crédito" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:DropDownList ID="ddlProveedor" runat="server" Font-Size="X-Small" Width="232px"
                                                                    ForeColor="Black" Font-Names="Arial">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 1px" valign="top" align="center">
                                                <table style="width: 100%; height: 1px" cellspacing="8" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="Label1" runat="server" Text="Artículo / Servicios :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" EnableCallbackMode="True" CallbackPageSize="10" ValueField="cCode"
                                                                    OnItemsRequestedByFilterCondition="ASPxComboBox_OnItemsRequestedByFilterCondition_SQL"
                                                                    OnItemRequestedByValue="ASPxComboBox_OnItemRequestedByValue_SQL" TextFormatString="{0} {1}"
                                                                    Width="300px" DropDownStyle="DropDown" Font-Size="X-Small" Font-Underline="False" ForeColor="#3333CC">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="cCode" Width="8px" Caption="Código" />
                                                                        <dx:ListBoxColumn FieldName="strData" Width="30px" Caption="Descripción" />
                                                                    </Columns>
                                                                    <ClientSideEvents EndCallback="function(s, e) { OnEndCallback(); } " />
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxSpinEdit ID="txtCantidad" runat="server" Number="0" Width="100px"></dx:ASPxSpinEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblPrecioUnitario" runat="server" Text="Precio Unitario:" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxSpinEdit ID="txtPrecioUnitario" runat="server" Number="0" Width="100px"></dx:ASPxSpinEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblImpuesto" runat="server" Text="Impuesto:" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxSpinEdit ID="txtImpuesto" runat="server" Number="0" Width="100px"></dx:ASPxSpinEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblMarcaPor" runat="server" Text="Total:"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtTotal" runat="server" Font-Size="X-Small" Width="100px"
                                                                    ForeColor="Black" Font-Names="Arial" MaxLength="80" Font-Bold="True"></asp:TextBox>&nbsp;<asp:Button
                                                                        ID="btnAdd" runat="server" Font-Size="X-Small" Text="Agregar" Height="25px" Enabled="False"></asp:Button>
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
                            <td style="width: 100%; height: 20px" valign="top" align="center"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 99%" valign="top" align="center">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100%; height: 100%" valign="top" align="center">
                                                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both">
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="1px" ForeColor="#333333"
                                                        GridLines="None" CellPadding="4" AutoGenerateColumns="False" Style="margin-top: 0px">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="cArticulo_Id" HeaderText="Código" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Articulo_Nombre" HeaderText="Descripción" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nCantidad" HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nPrecio_Unitario" HeaderText="Precio Unitario" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="nMonto_Total" HeaderText="Total" ItemStyle-HorizontalAlign="Center">
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
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
