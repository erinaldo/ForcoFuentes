<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="False" CodeFile="frmAccionPersonal_Auto.aspx.vb"
    Inherits="frmAccionPersonal_Edit" Title="Acciones de Personal Edit" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="JmComboBox" Namespace="JmComboBox" TagPrefix="jmcb" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="Server">
    <table style="width: 80%; height: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 98%; height: 1%" align="center" valign="top">
                <table style="width: 100%; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100%; height: 100%" align="left" valign="top" bgcolor="#CC0000">
                            <asp:Button ID="btnSave" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Guardar" Height="30px" BorderColor="#404040" 
                                CssClass="Tooltip_Table" Font-Size="10pt"
                                Width="90px" />
                            <asp:Button ID="btnCerrar" runat="server" BackColor="Gray" BorderStyle="Outset" ForeColor="White"
                                Text="Cerrar" Height="30px" BorderColor="#404040" CssClass="Tooltip_Table" Font-Size="10pt"
                                Width="90px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px; border-right-style: groove; border-left-style: groove;
                border-right-width: thin; border-left-width: thin;" align="center" valign="top">
            </td>
        </tr>
        <tr>
            <td style="border-style: none groove groove groove; border-width: thin; width: 98%;
                height: 99%" align="center" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td style="width: 50%; height: 100%" valign="top" align="center">
                                        <table style="width: 100%; height: 1px" cellspacing="8" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo:" __designer:wfdid="w223"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:TextBox ID="tbConsecutivo" runat="server" Font-Size="Small" Width="194px" ForeColor="Black"
                                                            Font-Names="Arial" __designer:wfdid="w224" Enabled="False">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status:" __designer:wfdid="w228" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            Width="300px" ForeColor="Black" Font-Names="Arial" __designer:wfdid="w229">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha:" __designer:wfdid="w236" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <ew:CalendarPopup ID="cpFecha" runat="server" Width="194px" ForeColor="Transparent"
                                                            __designer:wfdid="w237" AutoPostBack="True" PadSingleDigits="True" Font-Size="Small"
                                                            Enabled="False">
                                                        </ew:CalendarPopup>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblTipo" runat="server" Text="Tipo:" __designer:wfdid="w228" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            Width="300px" ForeColor="Black" Font-Names="Arial" __designer:wfdid="w229">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; " valign="middle" align="right">
                                                        <asp:Label ID="lblDistrito" runat="server" Text="Sub-Tipo:"></asp:Label>
                                                    </td>
                                                    <td style="width: 70%; " valign="middle" align="left">
                                                        <asp:DropDownList ID="ddlTipoSub" runat="server" Font-Size="Small" Width="300px"
                                                            ForeColor="Black" Font-Names="Arial">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblFechaInicio" runat="server" Text="Desde:" __designer:wfdid="w236"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <ew:CalendarPopup ID="cpFechaInicio" runat="server" Width="194px" ForeColor="Transparent"
                                                            __designer:wfdid="w237" AutoPostBack="True" PadSingleDigits="True" Font-Size="Small">
                                                        </ew:CalendarPopup>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblFechaFin" runat="server" Text="Hasta:" __designer:wfdid="w236"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <ew:CalendarPopup ID="cpFechaFin" runat="server" Width="194px" ForeColor="Transparent"
                                                            __designer:wfdid="w237" AutoPostBack="True" PadSingleDigits="True" Font-Size="Small">
                                                        </ew:CalendarPopup>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="Label2" runat="server" Text="Empleado :" designer:wfdid="w233" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td class="auto-style2" style="width: 300px">
                                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>                                                        
                                                        <jmcb:MultiComboBox ID="mcboEmpleado" runat="server" DataValueField="ID" Height="34px"
                                                            Width="300" DataTextField="NOMBRE" TextFormatString="{1}" LayoutHeight="300"
                                                            LayoutWidth="600" MaximumEntries="600" AutoPostBack="False">
                                                            <columns>
                                                                <jmcb:ColumnField ID="ID" runat="server" CssClass="CB_CellLeft" Width="20px">
                                                                    <HeaderText>ID</HeaderText>
                                                                    <FieldTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td style="width: 18px; padding-right: 6px;"><img src="../../images/twitter-icon.png" style="width: 18px; height: 18px" /></td>
                                                                                <td style=" text-align: left;"><%# DataBinder.Eval(Container.DataItem, "ID")%></td>
                                                                            </tr>
                                                                        </table>
                                                                    </FieldTemplate>
                                                                </jmcb:ColumnField>                                               
                                                                <jmcb:ColumnField CssClass="CB_CellLeft"  Width="100px">
                                                                    <HeaderText>Nombre</HeaderText>
                                                                    <FieldTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "NOMBRE")%>
                                                                    </FieldTemplate>
                                                                </jmcb:ColumnField>
                                                            </columns>                        
                                                        </jmcb:MultiComboBox>
                                                        </ContentTemplate>   
                                                        </asp:UpdatePanel>
                                                    </td>  
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblDetalle" runat="server" Text="Justificación:"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:TextBox ID="tbDetalle" runat="server" Font-Size="Small" Width="500px" Height="100px"
                                                            ForeColor="Black" Font-Names="Arial" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:Label ID="lblErrorDetalle" runat="server" Font-Size="Large" Text="*" ForeColor="Red"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblNuevoStatus" runat="server" Text="Nuevo Status:" __designer:wfdid="w228" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:DropDownList ID="ddlStatusNuevo" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            Width="300px" ForeColor="Black" Font-Names="Arial" __designer:wfdid="w229">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="Label1" runat="server" Text="Inicio:" __designer:wfdid="w236"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <ew:CalendarPopup ID="cpFechaAuto1" runat="server" Width="194px" ForeColor="Transparent"
                                                            __designer:wfdid="w237" AutoPostBack="True" PadSingleDigits="True" 
                                                            Font-Size="Small">
                                                        </ew:CalendarPopup>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="Label3" runat="server" Text="Fin:" __designer:wfdid="w236"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <ew:CalendarPopup ID="cpFechaAuto2" runat="server" Width="194px" ForeColor="Transparent"
                                                            __designer:wfdid="w237" AutoPostBack="True" PadSingleDigits="True" 
                                                            Font-Size="Small">
                                                        </ew:CalendarPopup>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblAutoriza" runat="server" Text="Autoriza:" __designer:wfdid="w223"
                                                            Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:TextBox ID="tbAutoriza" runat="server" Font-Size="Small" Width="194px" ForeColor="Black"
                                                            Font-Names="Arial" __designer:wfdid="w224" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%; height: 1px" valign="middle" align="right">
                                                        <asp:Label ID="lblNota" runat="server" Text="Notas:"></asp:Label>
                                                    </td>
                                                    <td style="width: 735px; height: 1px" valign="middle" align="left">
                                                        <asp:TextBox ID="tbNotas" runat="server" Font-Size="Small" Width="500px" Height="100px"
                                                            ForeColor="Black" Font-Names="Arial" TextMode="MultiLine"></asp:TextBox>                                                       
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
