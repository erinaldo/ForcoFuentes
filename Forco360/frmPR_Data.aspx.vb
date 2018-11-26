Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Util
Imports DevExpress.Web

Partial Class frmPR_Data

    Inherits System.Web.UI.Page

    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim ds As DataSet
    Dim dt As DataTable
    Dim strSQL As String


    Private Sub frmPR_Data_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Solicitud de Proyecto ::"
            Me.InitialInformation()
        End If
        '-- Ver que se ejecuta aqui
    End Sub

    Private Sub InitialInformation()
        '--
        funCargaComboEstado()
        funCargaComboTienda()
        funCargaComboProyecto()
        funCargaComboConcepto()
        funUpdateGridOne()
        funCargaData()
        '-
        funUpdateGridPicture()
        '--
    End Sub

    Private Sub funCargaComboEstado()
        '--
        dt = clsProyectos.funGetCombo_PR_Estado()
        '--
        Me.LoadDropDownList(Me.lkEstado, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.lkEstado.Items.Insert(0, _Seleccione)
        Me.lkEstado.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboTienda()
        '--
        dt = clsTienda.funGetLista_Tienda_Full()
        '--
        Me.LoadDropDownList(Me.lkTienda, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
        Me.lkTienda.Items.Insert(0, _Seleccione)
        Me.lkTienda.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboProyecto()
        '--
        dt = clsProyectos.funGetLista_PR_Proyecto()
        '--
        Me.LoadDropDownList(Me.lkProyecto, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.lkProyecto.Items.Insert(0, _Seleccione)
        Me.lkProyecto.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboConcepto()
        '--
        dt = clsProyectos.funGetLista_PR_Concepto()
        '--
        Me.LoadDropDownList(Me.lkConcepto, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.lkConcepto.Items.Insert(0, _Seleccione)
        Me.lkConcepto.SelectedIndex = 0
        '--
    End Sub
    Private Sub funUpdateGridOne()
        '-- 
        dt = clsProyectos.funGetLista_PR_Detalle()
        With Me.gvContactos
            .DataKeyNames = New String() {"nRecno"}
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
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

    Private Sub funCargaData()
        '--
        Me.lkEstado.SelectedValue = 1
        '--
    End Sub

    Private Sub gvContactos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvContactos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Dim username As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Product_Name"))
            'Dim lnkbtnresult As LinkButton = DirectCast(e.Row.FindControl("lnkdelete"), LinkButton)
            'BindGrid2()
        End If
    End Sub

    Protected Sub gvImage_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvImage.RowCancelingEdit

    End Sub
    Protected Sub gvImage_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvImage.RowDeleting

    End Sub
    Protected Sub gvImage_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvImage.RowEditing

    End Sub
    Protected Sub gvImage_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvImage.RowUpdating

    End Sub

    Protected Sub funUpdateGridPicture()
        '-- 
        dt = clsOrdenCompra.funGetLista_Orden_Compra_Picture_LD(12246)
        With Me.gvImage
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub


End Class
