Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports clsEmpleado
Imports Util

Partial Class frmAccionPersonal_Add

    Inherits System.Web.UI.Page

    Dim strSQL As String
    Dim Mensaje As String
    Dim strScript As String
    Dim sDS As SqlDataSource
    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim ds As DataSet
    Dim dt As DataTable
    Dim strNombreEmpleado As String

    Private Sub InitialInformation()
        '--
        Me.tbConsecutivo.Text = clsAccionPersonal.funConsecutivo()
        Me.funCargaComboAccion()
        funCargaEmpleado()
        '--
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = "Ingresar Acción de Personal"
            Me.InitialInformation()
        End If
        '-- Ver que se ejecuta aqui

    End Sub

    Private Sub funCargaEmpleado()
        mcboEmpleado.DataSource = clsEmpleado.funGetEmpleadoPortienda(strUsuario)
        mcboEmpleado.DataBind()
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
        dt = clsAccionPersonal.funGetCombo_Accion_Personal_SubTipo(Me.ddlTipo.SelectedValue)
        '--
        Me.LoadDropDownList(Me.ddlTipoSub, dt, dt.Columns(2).ColumnName, dt.Columns(3).ColumnName)
        Me.ddlTipoSub.Items.Insert(0, _Seleccione)
        Me.ddlTipoSub.SelectedIndex = 0
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
                    clsForcoHelper.funAddCampo("nEmpresa", nEmpresa, 0)
                    clsForcoHelper.funAddCampo("nSuc", nSuc, 0)
                    clsForcoHelper.funAddCampo("nCode", tbConsecutivo.Text, 0)
                    clsForcoHelper.funAddCampo("dtmFecha", clsForcoHelper.funFechaSql(cpFecha.SelectedDate.ToString, True), "")
                    clsForcoHelper.funAddCampo("nTipo", Me.ddlTipo.SelectedValue.ToString, 0)
                    clsForcoHelper.funAddCampo("nSubTipo", Me.ddlTipoSub.SelectedValue.ToString, 0)
                    clsForcoHelper.funAddCampo("dtmDesde", clsForcoHelper.funFechaSql(Me.cpFechaInicio.SelectedValue.ToString, True), "")
                    clsForcoHelper.funAddCampo("dtmHasta", clsForcoHelper.funFechaSql(Me.cpFechaFin.SelectedValue.ToString, True), "")
                    clsForcoHelper.funAddCampo("strCodeEmpleado", Me.mcboEmpleado.SelectedValue.ToString, "")
                    clsForcoHelper.funAddCampo("nStatus", 1, 0)
                    clsForcoHelper.funAddCampo("strJustifica", Me.tbDetalle.Text, "")
                    clsForcoHelper.funAddCampo("strUserAdd", strUsuario, "")
                    clsForcoHelper.funAddCampo("strUserUpdate", strUsuario, "")
                Else
                    '-- Editando
                    clsForcoHelper.funAddCampo("strConcepto", Trim(tbDetalle.Text), .Item("strConcepto").ToString)
                    clsForcoHelper.funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                    clsForcoHelper.funAddCampo("strUserUpdate", "", .Item("strUserUpdate").ToString)
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

    Protected Sub ddlTipo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipo.SelectedIndexChanged
        funCargaComboAccion_SubTipo()
    End Sub

   
End Class
