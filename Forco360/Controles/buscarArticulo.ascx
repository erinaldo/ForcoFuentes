<%@ Control Language="VB" AutoEventWireup="false" CodeFile="buscarArticulo.ascx.vb"
    Inherits="gui_buscarArticulo" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" class="tablePanelsContainer" width="100%">
                <tr>
                    <td valign="top">
                        <table cellpadding="10" width="100%">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="200px">
                                                Criterio:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cboCriterio" runat="server" Width="350px">
                                                    <asp:ListItem Selected="True">Código</asp:ListItem>
                                                    <asp:ListItem Value="NombreCompleto">Artículo</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td rowspan="2" width="100%" align="right">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Clave:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBuscar" runat="server" Width="350px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="gvwResultado" runat="server" CssClass="recordSet" AutoGenerateColumns="False"
                                                    Width="100%" DataKeyNames="Articulo_Id" GridLines="None" CaptionAlign="Left"
                                                    Font-Bold="False" OnSelectedIndexChanged="gvwResultado_SelectedIndexChanged"
                                                    AllowPaging="True" OnPageIndexChanging="gvwResultado_PageIndexChanging">
                                                    <Columns>
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/icons/BlueArrow.gif"
                                                            ShowCancelButton="False" ShowSelectButton="True" >
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="Articulo_Id" HeaderText="Código" ReadOnly="True">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Articulo_Nombre" HeaderText="Artículo" ReadOnly="True">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No se encontró ningún registro
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="recordSetHeaderResumen" HorizontalAlign="Left" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <RowStyle CssClass="recordSetRow" />
                                                    <AlternatingRowStyle CssClass="recordSetRowAlt" />
                                                    <SelectedRowStyle BackColor="#FFC20E" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
