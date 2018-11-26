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

Partial Class frmOC_Detalle
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim strUsuario As String = Me.Page.User.Identity.Name


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        '--
        SqlDataSource1.ConnectionString = clsForcoHelper.funConexion
        Me.funCargaComboProveedor
        '--
    End Sub

    Private Sub InitialInformation()
        Me.funUpdateGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = "Orden de Compra"
            Me.InitialInformation()
        End If
    End Sub

    Private Sub funCargaComboProveedor()
        '--
        dt = clsProveedor.funGetLista_Proveedor_Local()
        '--
        Me.LoadDropDownList(Me.ddlProveedor, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
        Me.ddlProveedor.Items.Insert(0, _Seleccione)
        Me.ddlProveedor.SelectedIndex = 0
        '--
    End Sub

    Private Sub LoadDropDownList(ByVal cDropDownList As DropDownList, ByVal dt As DataTable, ByVal strDataValueField As String, ByVal strDataTextField As String)
        For i As Integer = 0 To dt.Columns.Count - 1
            For i2 As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i2)(i) IsNot DBNull.Value Then
                    dt.Rows(i2)(i) = dt.Rows(i2)(i).ToString.ToUpper
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

    Private Sub funUpdateGrid()
        '-- dt = GetContacto(Me.ddlCliente.SelectedValue.ToString, Me.tbContacto.Text,
        '-- dt = GetLista_AccionesDePersonal()
        dt = clsOrdenCompra.funGetLista_CompraDetalle(txtNumero.Text)
        With Me.gvContactos
            .DataKeyNames = New String() {"nRecno"}
            .EmptyDataText = "Actualmente no existen registros"
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
            Dim nNumero As Integer = Me.gvContactos.DataKeys(e.Row.RowIndex).Values("nRecno").ToString
        End If
    End Sub

    'Protected Sub ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(ByVal source As Object, ByVal e As ListEditItemsRequestedByFilterConditionEventArgs)
    '    Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
    '    SqlDataSource1.SelectCommand = "SELECT [Articulo_Id], [Articulo_Nombre] FROM (select [Articulo_Id], [Articulo_Nombre], row_number()over(order by t.[Articulo_Nombre]) as [rn] from [vw_GB_Articulos_Suministro]  as t where (([Articulo_Id] + ' ' + [Articulo_Nombre]) LIKE @filter)) as st where st.[rn] between @startIndex and @endIndex"
    '    SqlDataSource1.SelectParameters.Clear()
    '    SqlDataSource1.SelectParameters.Add("filter", TypeCode.String, String.Format("%{0}%", e.Filter))
    '    SqlDataSource1.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString())
    '    SqlDataSource1.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString())
    '    comboBox.DataSource = SqlDataSource1
    '    comboBox.DataBind()
    'End Sub

    Protected Sub ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(ByVal source As Object, ByVal e As ListEditItemsRequestedByFilterConditionEventArgs)
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
        SqlDataSource1.SelectCommand = "SELECT [cCode], [strData] FROM (select [cCode], [strData], row_number()over(order by t.[strData]) as [rn] from [vw_GB_CAT_Servicios] as t where (([cCode] + ' ' + [strData]) LIKE @filter)) as st where st.[rn] between @startIndex and @endIndex"
        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectParameters.Add("filter", TypeCode.String, String.Format("%{0}%", e.Filter))
        SqlDataSource1.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString())
        SqlDataSource1.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString())
        comboBox.DataSource = SqlDataSource1
        comboBox.DataBind()
    End Sub


    Protected Sub ASPxComboBox_OnItemRequestedByValue_SQL(ByVal source As Object, ByVal e As ListEditItemRequestedByValueEventArgs)
        Dim value As Long = 0
        If e.Value Is Nothing OrElse (Not Int64.TryParse(e.Value.ToString(), value)) Then
            Return
        End If
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
        'SqlDataSource1.SelectCommand = "SELECT ID, LastName, [Phone], FirstName FROM Persons WHERE (ID = @ID) ORDER BY FirstName"
        'SqlDataSource1.SelectParameters.Clear()
        'SqlDataSource1.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString())
        SqlDataSource1.SelectCommand = "SELECT cCode, strData FROM CAT_Servicios WHERE (cCode = @cCode) ORDER BY strData"
        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString())
        comboBox.DataSource = SqlDataSource1
        comboBox.DataBind()
    End Sub


    Protected Sub txtCantidad_ValueChanged(sender As Object, e As EventArgs) Handles txtCantidad.ValueChanged
        If Me.txtPrecioUnitario.Text > 0 Then
            Me.txtTotal.Text = txtCantidad.Value * txtPrecioUnitario.Value
        End If
    End Sub

End Class
