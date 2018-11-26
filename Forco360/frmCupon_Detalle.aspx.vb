Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Linq

Partial Class frmCupon_Detalle
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim dtListaArticulos As DataTable
    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim strSQL As String
    Dim boolGrabado As Boolean

    Private Sub InitialInformation()
        boolGrabado = False
        Me.dtmFecha.Value = Now()
        Me.txtNumero.Text = clsCupon.funConsecutivo()
        funCargaCombo()
        Me.funUpdateGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = "Registro de Cupones"
            Me.InitialInformation()
        End If
    End Sub
    Private Sub funCargaCombo()
        '--
        dt = clsCupon.funGetCombo_Cupon_Tipo()
        Me.LoadDropDownList(Me.lkTipo, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        '--
        dt = clsCupon.funGetCombo_Cupon_Concepto()
        Me.LoadDropDownList(Me.lkConcepto, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
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
        '-- 
        dt = clsCupon.funGetLista_CuponesDetalle(Me.txtNumero.Text)
        With Me.gvContactos
            .DataKeyNames = New String() {"nRecno"}
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub

    Protected Sub gvContactos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContactos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim nNumero As Integer = Me.gvContactos.DataKeys(e.Row.RowIndex).Values("nRecno").ToString
        End If
    End Sub

    Protected Sub bbCargar_Click(sender As Object, e As EventArgs) Handles bbCargar.Click
        If FileUpload1.HasFile Then
            If Path.GetExtension(FileUpload1.FileName) = ".xlsx" Then
                '--
                Dim pck As New ExcelPackage(FileUpload1.FileContent)
                '--
                Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.First()
                '-- Obtenemos el datatable
                dtListaArticulos = WorksheetToDataTable(ws)
            End If
            '-- Grabamos detalle
            funSave_Detalle()
            funUpdateGrid()
        End If
    End Sub

    Private Function WorksheetToDataTable(ByVal ws As ExcelWorksheet, Optional ByVal hasHeader As Boolean = True) As DataTable
        '--
        Dim dt As DataTable = New DataTable(ws.Name)
        Dim totalCols As Integer = ws.Dimension.[End].Column
        Dim totalRows As Integer = ws.Dimension.[End].Row
        Dim startRow As Integer = If(hasHeader, 2, 1)
        Dim wsRow As ExcelRange
        Dim dr As DataRow

        For Each firstRowCell In ws.Cells(1, 1, 1, totalCols)
            dt.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
        Next
        For rowNum As Integer = startRow To totalRows
            wsRow = ws.Cells(rowNum, 1, rowNum, totalCols)
            dr = dt.NewRow()
            For Each cell In wsRow
                dr(cell.Start.Column - 1) = cell.Text
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
        '--
    End Function

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        '-- Guardar los datos del encabezado
        funSave_Encabezado()
        If boolGrabado = True Then
            Me.btnGuardar.Visible = False
            Me.btnVer.Visible = True
            '--
            Me.dtmFecha.Enabled = False             '--
            Me.lkTipo.Enabled = False
            Me.lkConcepto.Enabled = False
            Me.txtMonto.Enabled = False
            '--
            Me.FileUpload1.Enabled = True
            Me.bbCargar.Enabled = True
        End If
        '--
    End Sub

    Private Sub funSave_Encabezado()
        '-- Grabando encabezado
        clsForcoHelper.AbrirConexionGlobal()
        Try
            '--
            Dim vnEmpresa As Integer = 1
            Dim vnSuc As Integer = 1
            Dim vnNumero As Integer = 0
            '-- Fecha del Servidor
            Dim varToday As Date = clsForcoHelper.funFechaServer()
            '-- Para ver el siguiente registro, solo de una empresa
            strSQL = "SELECT * FROM RH_Cupon WHERE nNumero = " & Val(Me.txtNumero.Text)
            '--
            Dim dsAgregar As DataSet = clsForcoHelper.funFillDataSet(strSQL)
            '--
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = clsCupon.funConsecutivo()
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
                    clsForcoHelper.funAddCampo("nEmpresa", vnEmpresa, 0)
                    clsForcoHelper.funAddCampo("nSuc", vnSuc, 0)
                    clsForcoHelper.funAddCampo("nNumero", txtNumero.Text, 0)
                    clsForcoHelper.funAddCampo("nTipo", CInt(Me.lkTipo.SelectedValue), 0)
                    clsForcoHelper.funAddCampo("nConcepto", CInt(Me.lkConcepto.SelectedValue), 0)
                    clsForcoHelper.funAddCampo("nMonto", Me.txtMonto.Text, 0)
                    clsForcoHelper.funAddCampo("dtmFecha", clsForcoHelper.funFechaSql(Me.dtmFecha.Value.ToString, True), "")
                    clsForcoHelper.funAddCampo("strUserAdd", strUsuario, "")
                    clsForcoHelper.funAddCampo("strUserUpdate", strUsuario, "")
                End If
                '-- Definimos la llave              
                Dim strLlave As String = " nEmpresa = " & vnEmpresa & " " &
                                         "AND nSuc = " & vnSuc & " " &
                                         "AND nNumero = " & Val(Me.txtNumero.Text)
                '-- Pasamos los parametros de grabación
                clsForcoHelper.funParametrosGrabacionTransaccion("RH_Cupon", strLlave, intTipoRegistro, vnRecno)
                '--
                boolGrabado = True
                '--
                clsForcoHelper.transaccionGlobal.Commit()
                clsForcoHelper.DBConnGlobal.Close()
                Me.bbCargar.Enabled = False
            End With
        Catch ex As Exception
            clsForcoHelper.LimpiarCampos()
            clsForcoHelper.transaccionGlobal.Rollback()
            clsForcoHelper.DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        clsForcoHelper.DBConnGlobal.Close()
    End Sub

    Private Sub funSave_Detalle()
        '-- Grabando detalle
        clsForcoHelper.AbrirConexionGlobal()
        Try
            '--
            Dim vnEmpresa As Integer = 1
            Dim vnSuc As Integer = 1
            Dim i As Integer
            '-- Fecha del Servidor
            Dim varToday As Date = clsForcoHelper.funFechaServer()
            '-- Eliminamos los registros existentes
            strSQL = "DELETE FROM RH_Cupon_Detalle WHERE nNumero = " & Val(Me.txtNumero.Text)
            clsForcoHelper.funRunSQLTransaccion(strSQL)
            '-- Verificamos si hay registros
            For i = 0 To dtListaArticulos.Rows.Count - 1
                '--
                clsForcoHelper.funAddCampo("nEmpresa", vnEmpresa, 0)
                clsForcoHelper.funAddCampo("nSuc", vnSuc, 0)
                clsForcoHelper.funAddCampo("nNumero", txtNumero.Text, 0)
                With dtListaArticulos
                    clsForcoHelper.funAddCampo("cEmpleado", .Rows(i)("CODIGO").ToString, 0)
                    clsForcoHelper.funAddCampo("nCantidad", .Rows(i)("CANTIDAD").ToString, 0)
                End With
                '--
                Dim nTipoD As Integer
                Dim nRecno As Integer
                '--
                If clsForcoHelper.funNull2Val(("nRecno")) = 0 Then
                    nTipoD = 1
                Else
                    nTipoD = 2
                    nRecno = clsForcoHelper.funNull2Val(("nRecno"))
                End If
                '-- 
                '-- Definimos la llave              
                Dim strLlave As String = " nEmpresa = " & vnEmpresa & " " &
                                         "AND nSuc = " & vnSuc & " " &
                                         "AND nNumero = " & Val(Me.txtNumero.Text) & " " &
                                         "AND cEmpleado = '" & dtListaArticulos(i)("Codigo") & "'"
                '--
                clsForcoHelper.funParametrosGrabacionTransaccion("RH_Cupon_Detalle", strLlave, nTipoD, nRecno, , 0)
            Next
            clsForcoHelper.transaccionGlobal.Commit()
            clsForcoHelper.DBConnGlobal.Close()
        Catch ex As Exception
            clsForcoHelper.LimpiarCampos()
            clsForcoHelper.transaccionGlobal.Rollback()
            clsForcoHelper.DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        clsForcoHelper.DBConnGlobal.Close()
    End Sub
    Protected Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click

    End Sub
End Class
