<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmRequisa_Data.aspx.vb"
    Inherits="frmRequisa_Data" Title=":: REQUISAS ::" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Controles/buscarArticulo.ascx" TagName="ucBuscarArticulo" TagPrefix="ucbp" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
    <%--start highlighted block--%>
	<script type="text/javascript">
		var startTime;
		function OnBeginCallback() {
			startTime = new Date();
		}
		function OnEndCallback() {
			var result = new Date() - startTime;
			result /= 1000;
			result = result.toString();
			if(result.length > 4)
				result = result.substr(0, 4);
			time.SetText(result.toString() + " sec");
			label.SetText("Time to retrieve the last data:");
		}
	</script>
	<%--end highlighted block--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 149%; height: 1%" align="center" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="center" valign="top">
                            <asp:Label ID="lblError" runat="server" Font-Size="10pt" Text="Error" ForeColor="Red"
                                Font-Names="Arial" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 1%" align="center" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="center" valign="top">
                            <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 50%; height: 100%" align="left" valign="top">
                                        <asp:Button ID="btnRegresar" runat="server" BackColor="Gray" BorderColor="#404040"
                                            BorderStyle="Outset" ForeColor="White" Height="30px" Text="Regresar" CssClass="Estilo_Boton" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px" align="center" valign="top"></td>
        </tr>
        <tr>
            <td style="width: 149%; height: 1px" align="center" valign="top">
                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td style="width: 100%; height: 99%" valign="top" align="center">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 1px" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="Label2" runat="server" Text="Solicitud :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <asp:TextBox ID="txtNumero" runat="server" Width="194px" Font-Names="Arial" Font-Size="X-Small"
                                                                    ForeColor="Black" MaxLength="80"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="Label1" runat="server" Text="Test :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" EnableCallbackMode="true" CallbackPageSize="10"
                                                                    ValueType="System.String" ValueField="Articulo_Id"
                                                                    OnItemsRequestedByFilterCondition="ASPxComboBox_OnItemsRequestedByFilterCondition_SQL"
				                                                    OnItemRequestedByValue="ASPxComboBox_OnItemRequestedByValue_SQL" TextFormatString="{0} {1}"
				                                                    Width="400px" DropDownStyle="DropDown">                                                                    
                                                                    <Columns>
                                                                        <dx:ListBoxColumn FieldName="Articulo_Id" />
                                                                        <dx:ListBoxColumn FieldName="Articulo_Nombre" />
                                                                    </Columns>
                                                                    <ClientSideEvents BeginCallback="function(s, e) { OnBeginCallback(); }" EndCallback="function(s, e) { OnEndCallback(); } " />
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Oficial:
                                                            </td>
                                                            <td>
                                                                <asp:HiddenField ID="hfOficialID" runat="server" />
                                                                <asp:TextBox ID="txtOficial" runat="server" Width="200" ReadOnly="True" CssClass="field"></asp:TextBox>
                                                                <asp:Button ID="btnOficial" runat="server" Text="..." OnClick="btnPolicia_Click" />
                                                                <asp:ModalPopupExtender ID="BuscarOficial_ModalPopupExtender" runat="server" DynamicServicePath=""
                                                                    Enabled="True" TargetControlID="btnOficial" PopupControlID="pnlModalPanel" PopupDragHandleControlID="pnlHead"
                                                                    BackgroundCssClass="modalBackground" DropShadow="True">
                                                                </asp:ModalPopupExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                                <asp:Label ID="lblProductoPor" runat="server" Text="Descripción :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="txtDescripcion" runat="server" Font-Size="X-Small" Width="194px"
                                                                    ForeColor="Black" Font-Names="Arial" MaxLength="80"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%; height: 1px" align="right" valign="middle">
                                                                <asp:Label ID="lblAlias" runat="server" Text="Alias:"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" align="left" valign="middle">
                                                                <asp:TextBox ID="txtAlias" runat="server" Width="194px" Font-Names="Arial" Font-Size="X-Small"
                                                                    ForeColor="Black" MaxLength="80"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 1px" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 10%; height: 1px" valign="middle" align="left">
                                                                <asp:Label ID="lblTema" runat="server" Text="Notas :"></asp:Label>
                                                            </td>
                                                            <td style="width: 70%; height: 1px" valign="middle" align="left">
                                                                <asp:TextBox ID="tbTema" runat="server" Font-Size="X-Small" Width="404px" Height="47px"
                                                                    ForeColor="Black" Font-Names="Arial" TextMode="MultiLine" MaxLength="255" Style="margin-left: 0px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 20px" valign="top" align="left">
                                <asp:Button ID="btnAdd" runat="server" BackColor="Gray" BorderColor="#404040" BorderStyle="Outset"
                                    ForeColor="White" Height="30px" Text="Agregar" CssClass="Estilo_Boton" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 99%" valign="top" align="center">
                                <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100%; height: 100%" valign="top" align="center">
                                                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="350px" ScrollBars="Both">
                                                    <asp:GridView ID="gvMaquinas" runat="server" Width="750px" Height="1px" ForeColor="#333333"
                                                        GridLines="None" CellPadding="4" AutoGenerateColumns="False">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="CANTIDAD" HeaderText="CODIGO"></asp:BoundField>
                                                            <asp:BoundField DataField="DES_TIPO_MAQUINA" HeaderText="DESCRIPCION"></asp:BoundField>
                                                            <asp:BoundField DataField="U.MEDIDA" HeaderText="U.MEDIDA"></asp:BoundField>
                                                            <asp:BoundField DataField="UNIDADES" HeaderText="UNIDADES"></asp:BoundField>
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
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display: none" BackColor="White">
        <table border="0" cellpadding="0" cellspacing="0" class="BordeContenedor">
            <tr>
                <td>
                    <asp:Panel ID="pnlHead" runat="server">
                        <table cellpadding="4" cellspacing="0" class="etiquetaSubTitulo" width="100%">
                            <tr>
                                <td width="100%">
                                    <b>Buscar Suministros</b>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ucbp:ucBuscarArticulo ID="ucBuscarArticulo" runat="server" onselectedclicked="ucBuscarArticulo_SelectedClick"
                        OnBuscarClicked="ucBuscarArticulo_BuscarClick" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
