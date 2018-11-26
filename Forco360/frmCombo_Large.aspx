<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmCombo_Large.aspx.vb"
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
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 50%; height: 100%" valign="top" align="center">
                                                <table style="width: 100%; height: 1px" cellspacing="0" cellpadding="0">
                                                    <tbody>                                                       
                                                    </tbody>
                                                </table>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" />
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
