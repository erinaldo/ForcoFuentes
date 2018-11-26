<%@ Page Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="frmPR_Data.aspx.vb" Inherits="frmPR_Data" Title="Solicitud de Proyectos" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="Server">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
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
                                                    <asp:GridView ID="gvContactos" runat="server" Width="800px" Height="1px" ForeColor="#333333"
                                                        GridLines="None" CellPadding="4" AutoGenerateColumns="False" Style="margin-top: 0px">
                                                        <RowStyle BackColor="#E3EAEB" CssClass="GridRow"></RowStyle>
                                                        <Columns>
                                                            <asp:CommandField EditImageUrl="~/Images/magnifierwb.png" ShowEditButton="True" ButtonType="Image" HeaderText="SELECT">
                                                                <ItemStyle Width="50px"></ItemStyle>
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="nConcepto" HeaderText="Código" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strConcepto" HeaderText="Concepto" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="strActividad" HeaderText="Actividad" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Imagenes" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkdelete" href="#myModal" data-toggle="modal" runat="server">Agregar</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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

    <!-- this is bootstrp modal popup -->
    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">:: Listado de Imágenes ::</h4>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 85%; margin-top: 50px; margin-bottom: 50px;">
                    <asp:FileUpload ID="fileupload" runat="server" />
                    <asp:Button ID="upload" runat="server" Font-Bold="true" Text="Subir" />
                    <asp:Label ID="lblResult" runat="server" />
                    <asp:Label ID="lblmessage" runat="server" ClientIDMode="Static"></asp:Label>
                    <asp:GridView runat="server" ID="gvImage" AutoGenerateColumns="false" AllowPaging="True"
                        OnRowCancelingEdit="gvImage_RowCancelingEdit" DataKeyNames="ImageId" CellPadding="4"
                        OnRowEditing="gvImage_RowEditing" OnRowUpdating="gvImage_RowUpdating" OnRowDeleting="gvImage_RowDeleting" HeaderStyle-BackColor="Tomato">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lblImgId" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle Width="200px"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lblImageName" runat="server" Text='<%# Eval("ImageName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_Name" runat="server" Text='<%# Eval("ImageName") %>'></asp:TextBox>
                                </EditItemTemplate>

                                <HeaderStyle Width="200px"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Imagen" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'
                                        Height="80px" Width="100px" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Image ID="img_user" runat="server" ImageUrl='<%# Eval("Image") %>'
                                        Height="80px" Width="100px" /><br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </EditItemTemplate>

                                <HeaderStyle Width="200px"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Editar</asp:LinkButton>
                                    <asp:LinkButton ID="LkB11" runat="server" CommandName="Delete">Borrar</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LkB2" runat="server" CommandName="Update">Actualizar</asp:LinkButton>
                                    <asp:LinkButton ID="LkB3" runat="server" CommandName="Cancel">Cancelar</asp:LinkButton>
                                </EditItemTemplate>

                                <HeaderStyle Width="150px"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="Tomato"></HeaderStyle>
                    </asp:GridView>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
