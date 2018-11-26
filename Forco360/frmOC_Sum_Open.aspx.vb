Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports clsEmpleado
Imports Util
Imports DevExpress.Web

Partial Class frmOC_Sum_Open
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim nRol As Integer
    Dim ds As DataSet

    Private Sub InitialInformation()
        '-- 
        Me.dtpInicio.Value = Now
        Me.dtpFinal.Value = Now
        funCargaCombos()
        '--
    End Sub
    Protected Sub funValidaRol()
        '-- Obtenemos el rol
        strSQL = String.Format("SELECT * FROM vw_GB_Usuarios WHERE Usuario_Login = '{0}';", Page.User.Identity.Name)
        ds = clsForcoHelper.funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            nRol = ds.Tables("Tabla").Rows(0)("nRol")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '--
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Ordenes de Compra de Suministros ::"
            Me.InitialInformation()
            If Session("Editando") = 1 Then
                funValidaRol()
                funUpdateGrid_Back()
                Session("Editando") = Nothing
            End If
        End If
    End Sub

    Private Sub funUpdateGrid_Back()
        '-- Grid cuando regresa de otra page
        Me.dtpInicio.Value = Session("dtmFecha_Inicio")
        Me.dtpFinal.Value = Session("dtmFecha_Final")
        Me.lkProveedor.SelectedValue = Session("Proveedor")
        Me.lkEstado.SelectedValue = Session("Estado")
        dt = clsOrdenCompra.funGetLista_Orden_Compra_LD(Session("Proveedor"), Session("Estado"), Me.Session("dtmFecha_Inicio"), Session("dtmFecha_Final"))
        '--
        With Me.gvContactos
            .DataKeyNames = New String() {"Orden_Id"}
            .EmptyDataText = "Actualmente no hay Ordenes de Compra con los filtros seleccionados"
            .DataSource = dt
            .DataBind()
        End With
    End Sub
    Private Sub funUpdateGrid()
        '-- '-- Grid normal
        dt = clsOrdenCompra.funGetLista_Orden_Compra_LD(lkProveedor.SelectedValue, lkEstado.SelectedValue, dtpInicio.Value, dtpFinal.Value)
        '--
        With Me.gvContactos
            .DataKeyNames = New String() {"Orden_Id"}
            .EmptyDataText = "Actualmente no hay Ordenes de Compra con los filtros seleccionados"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Session("Editando") = 0
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub

    Private Sub funCargaCombos()
        '-- Estados
        dt = clsOrdenCompra.funGetLista_Estado_Solicitud_Compra()
        Me.LoadDropDownList(Me.lkEstado, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
        '--
        dt = clsProveedor.funGetLista_OC_Proveedor()
        Me.LoadDropDownList(Me.lkProveedor, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
    End Sub

    Private Sub LoadDropDownList(ByVal cDropDownList As DropDownList, ByVal dt As DataTable, ByVal strDataValueField As String, ByVal strDataTextField As String)
        For i As Integer = 0 To dt.Columns.Count - 1
            For i2 As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i2)(i) IsNot DBNull.Value Then
                    dt.Rows(i2)(i) = dt.Rows(i2)(i).ToString
                End If
            Next
        Next
        With cDropDownList
            .DataSource = dt
            .DataValueField = strDataValueField
            .DataTextField = strDataTextField
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub

    Protected Sub btnFiltro_Click(sender As Object, e As EventArgs) Handles btnFiltro.Click
        '--
        funValidaRol()
        funUpdateGrid()
        '--
    End Sub

    Protected Sub gvContactos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContactos.RowDataBound
        '-- Inicio variable session
        If nRol = 1 Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Session("Editando") = 1
                Session("dtmFecha_Inicio") = Me.dtpInicio.Value
                Session("dtmFecha_Final") = Me.dtpFinal.Value
                Session("Proveedor") = Me.lkProveedor.SelectedValue
                Session("Estado") = Me.lkEstado.SelectedValue
                Dim Orden_Id As Integer = Me.gvContactos.DataKeys(e.Row.RowIndex).Values("Orden_Id").ToString
                '-- Configura el link hacia el detalle
                CType(e.Row.Cells(0).Controls(0), HyperLink).NavigateUrl = String.Concat("~/frmOC_Sum_Data.aspx?nOrden=", Orden_Id)
                CType(e.Row.Cells(0).Controls(0), HyperLink).ToolTip = "Ver"
                CType(e.Row.Cells(0).Controls(0), HyperLink).ImageUrl = "images/edit_icon.gif"
                '-- Autoriza
                CType(e.Row.Cells(1).Controls(0), HyperLink).NavigateUrl = String.Concat("~/frmOC_Sum_Data_Auto.aspx?nOrden=", Orden_Id)
                CType(e.Row.Cells(1).Controls(0), HyperLink).ToolTip = "Autorizar"
                CType(e.Row.Cells(1).Controls(0), HyperLink).ImageUrl = "images/accept.png"
            End If
        ElseIf nRol = 2 Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Session("Editando") = 1
                Session("dtmFecha_Inicio") = Me.dtpInicio.Value
                Session("dtmFecha_Final") = Me.dtpFinal.Value
                Session("Proveedor") = Me.lkProveedor.SelectedValue
                Session("Estado") = Me.lkEstado.SelectedValue
                Dim Orden_Id As Integer = Me.gvContactos.DataKeys(e.Row.RowIndex).Values("Orden_Id").ToString
                '-- Configura el link hacia el detalle
                CType(e.Row.Cells(0).Controls(0), HyperLink).NavigateUrl = String.Concat("~/frmOC_Sum_Data.aspx?nOrden=", Orden_Id)
                CType(e.Row.Cells(0).Controls(0), HyperLink).ToolTip = "Ver"
                CType(e.Row.Cells(0).Controls(0), HyperLink).ImageUrl = "images/edit_icon.gif"
            End If
        End If
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Response.Redirect("~/frmPR_Data.aspx")
        Response.Redirect("~/frmOC_Sum_Data.aspx")
    End Sub
End Class
