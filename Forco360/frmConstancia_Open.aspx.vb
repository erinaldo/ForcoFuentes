'-- Imports GestorDatos
Imports System.Data
Imports Util

Partial Class frmConstancia_Open
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim strUsuario As String = Me.Page.User.Identity.Name

    Private Sub InitialInformation()
        Me.funUpdateGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Constancias ::"
            Me.InitialInformation()
        End If
    End Sub

    Private Sub funUpdateGrid()
        '-- dt = GetContacto(Me.ddlCliente.SelectedValue.ToString, Me.tbContacto.Text,
        '-- dt = GetLista_AccionesDePersonal()
        dt = clsConstancias.funGetLista_Constancia()
        With Me.gvContactos
            .DataKeyNames = New String() {"nCode"}
            .EmptyDataText = "Actualmente no hay contactos asignados con los filtros seleccionados"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        'Dim CLIENTE As String = Me.ddlCliente.SelectedValue.ToString
        'Response.Redirect("~/wfInformacionCliente.aspx?CLIENTE=" & CLIENTE)
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub

    Protected Sub gvContactos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContactos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim nCode As Integer = Me.gvContactos.DataKeys(e.Row.RowIndex).Values("nCode").ToString
            'Configura el link hacia el detalle
            CType(e.Row.Cells(0).Controls(0), HyperLink).NavigateUrl = String.Concat("~/frmAccionPersonal_Edit.aspx?nCode=", nCode)
            CType(e.Row.Cells(0).Controls(0), HyperLink).ToolTip = "Ver/Editar"
            CType(e.Row.Cells(0).Controls(0), HyperLink).ImageUrl = "images/edit_icon.gif"
            '-- Autoriza
            CType(e.Row.Cells(1).Controls(0), HyperLink).NavigateUrl = String.Concat("~/frmAccionPersonal_Auto.aspx?nCode=", nCode)
            CType(e.Row.Cells(1).Controls(0), HyperLink).ToolTip = "Autorizar"
            CType(e.Row.Cells(1).Controls(0), HyperLink).ImageUrl = "images/accept.png"

        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("~/frmConstancia_Add.aspx")
    End Sub

End Class
