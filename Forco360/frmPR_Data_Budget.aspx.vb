Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Util
Imports DevExpress.Web

Partial Class frmPR_Data_Budget

    Inherits System.Web.UI.Page

    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim ds As DataSet
    Dim dt As DataTable
    Dim strSQL As String


    Private Sub frmPR_Data_Budget_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Presupuesto de Proyectos ::"
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
        funCargaData()
        '--
        funUpdateGridOne()
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


    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        funUpdateGridOne()
        'Me.BindGrid()
    End Sub

    Protected Sub OnRowCancelingEdit(sender As Object, e As EventArgs)
        GridView1.EditIndex = -1
        funUpdateGridOne()
        'Me.BindGrid()
    End Sub

    Protected Sub OnRowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        'Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        'Dim customerId As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Values(0))
        'Dim name As String = TryCast(row.FindControl("txtName"), TextBox).Text
        'Dim country As String = TryCast(row.FindControl("txtCountry"), TextBox).Text
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand("Customers_CRUD")
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.AddWithValue("@Action", "UPDATE")
        '        cmd.Parameters.AddWithValue("@CustomerId", customerId)
        '        cmd.Parameters.AddWithValue("@Name", name)
        '        cmd.Parameters.AddWithValue("@Country", country)
        '        cmd.Connection = con
        '        con.Open()
        '        cmd.ExecuteNonQuery()
        '        con.Close()
        '    End Using
        'End Using
        'GridView1.EditIndex = -1
        'Me.BindGrid()
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        'If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowIndex <> GridView1.EditIndex Then
        ' TryCast(e.Row.Cells(2).Controls(2), LinkButton).Attributes("onclick") = "return confirm('Do you want to delete this row?');"
        'End If

        '-- Probar
        'If GridView1.EditIndex <> -1 Then
        '    DirectCast(GridView1.Rows(GridView1.EditIndex).FindControl("txtCYProjected"), TextBox).Enabled = False
        'End If

        '-- Probar
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    If e.Row.DataItem IsNot Nothing Then
        '        Dim lblControl As Label = DirectCast(e.Row.Cells(2).FindControl("lblCategoryName"), Label)
        '        If lblControl.Text = "Confections" Then
        '            e.Row.Cells(0).Enabled = False
        '        End If
        '    End If
        'End If


        '-- Este si funciona
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.DataItem IsNot Nothing Then
                If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                    e.Row.Cells(0).Enabled = False
                End If
            End If
        End If

    End Sub

    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        'Dim customerId As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Values(0))
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand("Customers_CRUD")
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.Parameters.AddWithValue("@Action", "DELETE")
        '        cmd.Parameters.AddWithValue("@CustomerId", customerId)
        '        cmd.Connection = con
        '        con.Open()
        '        cmd.ExecuteNonQuery()
        '        con.Close()
        '    End Using
        'End Using
        'Me.BindGrid()
    End Sub

    Private Sub funUpdateGridOne()
        '-- 
        dt = clsProyectos.funGetLista_PR_Detalle()
        With Me.GridView1
            .DataKeyNames = New String() {"nRecno"}
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub
End Class
