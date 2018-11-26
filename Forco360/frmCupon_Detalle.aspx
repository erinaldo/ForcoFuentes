<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmCupon_Detalle.aspx.vb"
    Inherits="frmCupon_Detalle" Title="Cupones" %>

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
                            <asp:Button ID="btnGuardar" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Guardar" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Visible="True"
                                Width="80px" />
                            <asp:Button ID="btnVer" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Ver" Height="30px" BorderColor="#404040" CssClass="Estilo_Boton" Visible="False"
                                Width="80px" />
                            <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderStyle="Outset"
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
                                                                <asp:Label ID="lblConsecutivo" runat="server" Text="Numero :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtNumero" runat="server" Font-Size="8pt" Width="100px" ForeColor="Black"
                                                                    Font-Names="Arial" __designer:wfdid="w224" Enabled="False">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFecha" runat="server" Text="Fecha :" __designer:wfdid="w236" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxDateEdit ID="dtmFecha" runat="server" DisplayFormatString="dd/MM/yyyy" AllowNull="False" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblTipo" runat="server" Text="Tipo :" __designer:wfdid="w228" Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:DropDownList ID="lkTipo" runat="server" AutoPostBack="True" Font-Size="8pt"
                                                                    Width="200px" ForeColor="Black" Font-Names="Arial" __designer:wfdid="w229" Height="17px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblDistrito" runat="server" Text="Concepto :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:DropDownList ID="lkConcepto" runat="server" Font-Size="8pt" Width="200px"
                                                                    ForeColor="Black" Font-Names="Arial">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblMonto" runat="server" Text="Monto :" __designer:wfdid="w223"
                                                                    Font-Size="10pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">                                                                
                                                                <dx:ASPxSpinEdit ID="txtMonto" runat="server" Number="0" Font-Size="8pt" DecimalPlaces="2" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 1px" valign="top" align="center">
                                                <table style="width: 100%; height: 1px" cellspacing="0" cellpadding="0">
                                                    <tbody>                                                        
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="left">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" Enabled="False" Font-Size="8pt" />
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:Button ID="bbCargar" runat="server" Text="Cargar" Enabled="False" Font-Size="8pt" Height="21px" />
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
                                                <asp:Panel ID="Panel1" runat="server" Width="800px" Height="350px" ScrollBars="Both">
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="1px" ForeColor="#333333"
                                                        GridLines="None" CellPadding="4" AutoGenerateColumns="False">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="EMPLEADO_CODIGO" HeaderText="Código">
                                                                <ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EMPLEADO_NOMBRE" HeaderText="Empleado">
                                                                <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad">
                                                                <ItemStyle HorizontalAlign="Left" Width="10px"></ItemStyle>
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
