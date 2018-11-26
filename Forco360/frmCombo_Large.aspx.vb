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

Partial Class frmRequisa_Data
    Inherits System.Web.UI.Page

    Dim strSQL As String
    Dim vnRecno As Integer
    Dim query As String
    Dim Mensaje As String
    Dim strScript As String
    Dim sDS As SqlDataSource
    Dim dt As DataTable
    Dim strUsuario As String = Me.Page.User.Identity.Name

    Private Sub InitialInformation()
        Me.lblError.Visible = False
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        '--
        SqlDataSource1.ConnectionString = clsForcoHelper.funConexion
        '--
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Metodo
        CType(Me.Master, MasterCRM3).PageTitle = "SOLICITUDES DE SUMINISTROS"
        If Not IsPostBack Then
            Me.InitialInformation()
        End If
    End Sub

    Private Sub SetMensajeError(ByVal mensaje As String)
        '--
        Me.lblError.Visible = True
        Me.lblError.Text = mensaje
        ''--
    End Sub

    Protected Sub ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(ByVal source As Object, ByVal e As ListEditItemsRequestedByFilterConditionEventArgs)
        Dim comboBox As ASPxComboBox = CType(source, ASPxComboBox)
        SqlDataSource1.SelectCommand = "SELECT [Articulo_Id], [Articulo_Nombre] FROM (select [Articulo_Id], [Articulo_Nombre], row_number()over(order by t.[Articulo_Nombre]) as [rn] from [Articulo_Info]  as t where (([Articulo_Id] + ' ' + [Articulo_Nombre]) LIKE @filter)) as st where st.[rn] between @startIndex and @endIndex"
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
        SqlDataSource1.SelectCommand = "SELECT ID, LastName, [Phone], FirstName FROM Persons WHERE (ID = @ID) ORDER BY FirstName"

        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString())
        comboBox.DataSource = SqlDataSource1
        comboBox.DataBind()
    End Sub


End Class
