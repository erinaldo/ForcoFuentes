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
        funCargaCombo()
    End Sub

    Private Sub funCargaCombo()
        'Me.ASPxComboBox1.DataSource = Nothing
        'Me.ASPxComboBox1.DataSource = clsArticulos.funGetLista_Articulos(21)
        'Me.ASPxComboBox1.DataBind()
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

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        '-- vnRecno es CERO cuando esta agregando
        vnRecno = 0
        funGuardar()
        '--
    End Sub

    Protected Sub funGuardar()
        '--
        clsForcoHelper.AbrirConexionGlobal()
        Try
            '--
            Dim nEmpresa As Integer = 1
            Dim nSuc As Integer = 1
            '-- Fecha del Servidor
            Dim varToday As Date = clsForcoHelper.funFechaServer()
            '-- Guardar datos
            strSQL = "SELECT * FROM SUM_Solicitud_Detalle WHERE nRecno = " & vnRecno
            '--
            Dim dsAgregar As DataSet = clsForcoHelper.funFillDataSet(strSQL)
            '--
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                clsAccionPersonal.funConsecutivo()
                dsAgregar.Tables("Tabla").Rows.Add()
            End If
            '--
            With dsAgregar.Tables("Tabla").Rows(0)
                '-- Tomamos el nRecno
                Dim vnRecno = clsForcoHelper.funNull2Val(.Item("nRecno"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                Dim intTipoRegistro = IIf(clsForcoHelper.funNull2Val(.Item("nRecno")) = 0, 1, 2)
                '--
                If intTipoRegistro = 1 Then
                    '-- Agregando
                    clsForcoHelper.funAddCampo("nEmpresa", nEmpresa, 0)
                    clsForcoHelper.funAddCampo("nSuc", nSuc, 0)
                    clsForcoHelper.funAddCampo("nNumero", txtAlias.Text, 0)
                    clsForcoHelper.funAddCampo("cArticulo_Id", txtDescripcion.Text, 0)
                Else
                    '-- Editando
                    clsForcoHelper.funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                    clsForcoHelper.funAddCampo("strUserUpdate", "", .Item("strUserUpdate").ToString)
                End If
                '-- Definimos la llave              
                Dim strLlave As String = " nRecno = " & vnRecno
                '-- Pasamos los parametros de grabación
                clsForcoHelper.funParametrosGrabacionTransaccion("SUM_Solicitud_Detalle", strLlave, intTipoRegistro, vnRecno)
                '--
                clsForcoHelper.transaccionGlobal.Commit()
                clsForcoHelper.DBConnGlobal.Close()
            End With
        Catch ex As Exception
            clsForcoHelper.LimpiarCampos()
            clsForcoHelper.transaccionGlobal.Rollback()
            clsForcoHelper.DBConnGlobal.Close()
            '-- Mensaje asp.net
            If Not ex.InnerException Is Nothing Then
                ex = ex.InnerException
            End If
            If ex.Message.Contains("PRIMARY KEY") Then
                Me.SetMensajeError("Ya existe un articulo en el detalle.")
            Else
                Me.SetMensajeError(ex.Message)
            End If
            Exit Sub
        End Try
        clsForcoHelper.DBConnGlobal.Close()
        '--
    End Sub

    Private Sub SetMensajeError(ByVal mensaje As String)
        '--
        Me.lblError.Visible = True
        Me.lblError.Text = mensaje
        ''--
    End Sub

    Protected Sub btnPolicia_Click(sender As Object, e As System.EventArgs) Handles btnOficial.Click
        BuscarOficial_ModalPopupExtender.Show()
    End Sub

    Protected Sub ucBuscarArticulo_BuscarClick(sender As Object, e As System.EventArgs) Handles btnOficial.Click
        BuscarOficial_ModalPopupExtender.Show()
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
