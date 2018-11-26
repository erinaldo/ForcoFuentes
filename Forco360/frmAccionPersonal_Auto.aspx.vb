Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports clsEmpleado
Imports Util

Partial Class frmAccionPersonal_Edit

    Inherits System.Web.UI.Page

    Dim strSQL As String
    Dim Mensaje As String
    Dim strScript As String
    Dim sDS As SqlDataSource
    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim ds As DataSet
    Dim dt As DataTable
    Dim strNombreEmpleado As String
    '-- datos
    Dim vnTipo As Integer
    Dim vnTipoSub As Integer
    Dim vnStatus As Integer

    Private Sub InitialInformation()
        '--
        funCargaEmpleado()
        Me.funCargaData()
        funCargaComboStatus()
        funCargaComboStatusNuevo()
        funCargaComboAccion()
        funCargaComboAccion_SubTipo()
        Me.ddlStatus.SelectedIndex = vnStatus
        Me.ddlTipo.SelectedIndex = vnTipo
        Me.ddlTipoSub.SelectedIndex = vnTipoSub
        Me.tbAutoriza.Text = strUsuario
        funLock()
        '--
    End Sub

    Private Sub funLock()
        Me.ddlStatus.Enabled = False
        Me.ddlTipo.Enabled = False
        Me.ddlTipoSub.Enabled = False
        Me.cpFechaInicio.Enabled = False
        Me.cpFechaFin.Enabled = False
        Me.mcboEmpleado.Enabled = False
        Me.tbDetalle.Enabled = False
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = "Autorizando Acción de Personal"
            Me.InitialInformation()
        End If
        '-- Ver que se ejecuta aqui

    End Sub

    Private Sub funCargaEmpleado()
        mcboEmpleado.DataSource = clsEmpleado.funGetEmpleadoPortienda(strUsuario)
        mcboEmpleado.DataBind()
    End Sub

    Private Sub funCargaComboStatus()
        '--
        dt = clsAccionPersonal.funGetCombo_Status()
        '--
        Me.LoadDropDownList(Me.ddlStatus, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.ddlStatus.Items.Insert(0, _Seleccione)
        Me.ddlStatus.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboStatusNuevo()
        '--
        dt = clsAccionPersonal.funGetCombo_Status_Nuevo()
        '--
        Me.LoadDropDownList(Me.ddlStatusNuevo, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.ddlStatusNuevo.Items.Insert(0, _Seleccione)
        Me.ddlStatusNuevo.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboAccion()
        '--
        dt = clsAccionPersonal.funGetCombo_Accion_Personal()
        '--
        Me.LoadDropDownList(Me.ddlTipo, dt, dt.Columns(1).ColumnName, dt.Columns(2).ColumnName)
        Me.ddlTipo.Items.Insert(0, _Seleccione)
        Me.ddlTipo.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaComboAccion_SubTipo()
        '--
        dt = clsAccionPersonal.funGetCombo_Accion_Personal_SubTipo(vnTipo)
        '--
        Me.LoadDropDownList(Me.ddlTipoSub, dt, dt.Columns(2).ColumnName, dt.Columns(3).ColumnName)
        Me.ddlTipoSub.Items.Insert(0, _Seleccione)
        Me.ddlTipoSub.SelectedIndex = 0
        '--
    End Sub

    Private Sub funCargaData()
        '-- Variable de session
        Session("nCode") = Request.Params("nCode").ToString

        '-- Filtramos el registro
        strSQL = "SELECT * FROM vw_Accion_Personal_Browse WHERE nCode = " & Session("nCode")
        '-- Cargamos el DS
        ds = clsForcoHelper.funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.tbConsecutivo.Text = Session("nCode")
            vnStatus = ds.Tables("Tabla").Rows(0)("nStatus").ToString
            Me.cpFecha.SelectedValue = ds.Tables("Tabla").Rows(0)("dtmFecha").ToString
            vnTipo = ds.Tables("Tabla").Rows(0)("nTipo").ToString
            vnTipoSub = ds.Tables("Tabla").Rows(0)("nSubTipo").ToString
            Me.cpFechaInicio.SelectedValue = ds.Tables("Tabla").Rows(0)("dtmDesde").ToString
            Me.cpFechaFin.SelectedValue = ds.Tables("Tabla").Rows(0)("dtmHasta").ToString
            Me.mcboEmpleado.SelectedValue = ds.Tables("Tabla").Rows(0)("strCodeEmpleado").ToString
            Me.tbDetalle.Text = ds.Tables("Tabla").Rows(0)("strJustifica").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        funGuardar()
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
            strSQL = "SELECT * FROM RH_AccionPersonal WHERE nCode = " & Val(Me.tbConsecutivo.Text)
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
                    'clsForcoHelper.funAddCampo("nEmpresa", nEmpresa, 0)
                    'clsForcoHelper.funAddCampo("nSuc", nSuc, 0)
                    'clsForcoHelper.funAddCampo("nCode", tbConsecutivo.Text, 0)
                    'clsForcoHelper.funAddCampo("dtmFecha", clsForcoHelper.funFechaSql(cpFecha.SelectedDate.ToString, True), "")
                    'clsForcoHelper.funAddCampo("nTipo", Me.ddlTipo.SelectedValue.ToString, 0)
                    'clsForcoHelper.funAddCampo("nSubTipo", Me.ddlTipoSub.SelectedValue.ToString, 0)
                    'clsForcoHelper.funAddCampo("dtmDesde", clsForcoHelper.funFechaSql(Me.cpFechaInicio.SelectedValue.ToString, True), "")
                    'clsForcoHelper.funAddCampo("dtmHasta", clsForcoHelper.funFechaSql(Me.cpFechaFin.SelectedValue.ToString, True), "")
                    'clsForcoHelper.funAddCampo("strCodeEmpleado", Me.mcboEmpleado.SelectedValue.ToString, "")
                    'clsForcoHelper.funAddCampo("nStatus", 1, 0)
                    'clsForcoHelper.funAddCampo("strJustifica", Me.tbDetalle.Text, "")
                    'clsForcoHelper.funAddCampo("strUserAdd", strUsuario, "")
                    'clsForcoHelper.funAddCampo("strUserUpdate", strUsuario, "")
                Else
                    '-- Editando

                    'clsForcoHelper.funAddCampo("strConcepto", Trim(tbDetalle.Text), .Item("strConcepto").ToString)
                    'clsForcoHelper.funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                    'clsForcoHelper.funAddCampo("strUserUpdate", "", .Item("strUserUpdate").ToString)
                    'clsForcoHelper.funAddCampo("nStatus", , 0)
                    clsForcoHelper.funAddCampo("nStatus", Me.ddlStatusNuevo.SelectedValue.ToString, .Item("nStatus").ToString)
                    clsForcoHelper.funAddCampo("dtmInicio", clsForcoHelper.funFechaSql(cpFechaAuto1.SelectedDate.ToString, True), .Item("dtmInicio").ToString)
                    clsForcoHelper.funAddCampo("dtmFin", clsForcoHelper.funFechaSql(cpFechaAuto2.SelectedDate.ToString, True), .Item("dtmFin").ToString)
                    clsForcoHelper.funAddCampo("strNotas", Trim(Me.tbNotas.Text), .Item("strNotas").ToString)
                    clsForcoHelper.funAddCampo("strUserUpdate", strUsuario, .Item("strUserUpdate").ToString)
                End If
                '-- Definimos la llave              
                Dim strLlave As String = " nEmpresa = " & nEmpresa & " " & _
                      "AND nSuc = " & nSuc & " " & _
                      "AND nCode = " & Val(Me.tbConsecutivo.Text)
                '-- Pasamos los parametros de grabación
                clsForcoHelper.funParametrosGrabacionTransaccion("RH_AccionPersonal", strLlave, intTipoRegistro, vnRecno)
                '--
                clsForcoHelper.transaccionGlobal.Commit()
                clsForcoHelper.DBConnGlobal.Close()
            End With
        Catch ex As Exception
            clsForcoHelper.LimpiarCampos()
            clsForcoHelper.transaccionGlobal.Rollback()
            clsForcoHelper.DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        clsForcoHelper.DBConnGlobal.Close()
        '-- Pagina de listado de acciones.
        Response.Redirect("~/frmAccionPersonal.aspx")
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

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Response.Redirect("~/frmAccionPersonal.aspx")
    End Sub

End Class
