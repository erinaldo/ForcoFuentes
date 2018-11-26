<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmPR_Data_Budget.aspx.vb" Inherits="frmPR_Data_Budget" Title="Proyectos" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="border-style: solid; border-width: thin; width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 100%; height: 1%" align="left" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="left" valign="top" bgcolor="#339966">
                            <asp:Button ID="btnGuardar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Guardar" Height="30px" CssClass="Estilo_Boton"
                                Width="80px" />
                            <asp:Button ID="btnCerrar" runat="server" BackColor="Gray" BorderStyle="Outset"
                                ForeColor="White" Text="Cerrar" Height="30px" CssClass="Estilo_Boton"
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
                                                <%--1px para ajustar arriba en la tabla--%>
                                                <table style="width: 100%; height: 1px" cellspacing="5" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblConsecutivo" runat="server" Text="No. :" Font-Size="9pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtSolicitud" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False">00009</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label1" runat="server" Text="Solicita :" Font-Size="9pt" Font-Bold="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtSolicita" runat="server" Font-Size="9pt" Width="300px" ForeColor="Black"
                                                                    Font-Names="Arial" Enabled="False" Font-Bold="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:" Font-Size="9pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <dx:ASPxDateEdit ID="dtpInicio" runat="server" DisplayFormatString="dd/MM/yyyy" AllowNull="False" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblNota" runat="server" Text="Notas:" Font-Size="9"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtNotas" runat="server" Font-Size="9pt" Width="300px" Height="50px"
                                                                    ForeColor="Black" Font-Names="Arial" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <%--1px para ajustar arriba en la tabla--%>
                                                <table style="width: 100%; height: 1px" cellspacing="5" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="Label3" runat="server" Text="Estado :" Font-Size="9pt"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <asp:DropDownList ID="lkEstado" runat="server" Width="200px" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="Black" Enabled="False">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="lblTienda" runat="server" Text="Tienda :" Font-Size="9"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <asp:DropDownList ID="lkTienda" runat="server" Width="200px" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="Black">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="Label2" runat="server" Text="Proyecto :" Font-Size="9pt"></asp:Label></td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <asp:DropDownList ID="lkProyecto" runat="server" Width="200px" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="Black">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 100%" valign="middle" align="right">
                                                                <asp:Label ID="lblTipoContacto" runat="server" Text="Concepto :" Font-Size="9"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 100%" valign="top" align="left">
                                                                <asp:DropDownList ID="lkConcepto" runat="server" Font-Size="X-Small" Width="200px" ForeColor="Black" Font-Names="Arial">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="Label6" runat="server" Text="Actividad :" Font-Size="9pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtActividad" runat="server" Font-Size="9pt" Width="200px" ForeColor="Black"
                                                                    Font-Names="Arial" Font-Bold="False" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Button ID="btnAdd" runat="server" Font-Size="XX-Small" Width="83px" Text="Agregar"></asp:Button>
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
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="nRecno"
                                                        OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
                                                        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added.">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Concepto" ItemStyle-Width="150">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblConcepto" runat="server" Text='<%# Eval("strConcepto") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtConcepto" runat="server" Text='<%# Eval("strConcepto") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Monto" ItemStyle-Width="150">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMonto" runat="server" Text='<%# Eval("nMonto") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtMonto" runat="server" Text='<%# Eval("nMonto") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                                ItemStyle-Width="150" EditText="Editar" DeleteText="Borrar" />
                                                        </Columns>
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
