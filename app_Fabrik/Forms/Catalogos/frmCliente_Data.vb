Imports System
Imports System.Data

Public Class frmCliente_Data
    Dim ds, dsAgregar, dsEmpresa, dsPersonaClasifica As New DataSet
    Dim intTipoRegistro, vnStatusPersonaClasifica As Integer
    Public nTipo, vnRecno, vnCodigo, vnTipoPersona As Integer
    Dim vnStatus As Integer = 1
    Dim bolInicio As Boolean

    Private Sub frmCliente_Data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmCliente_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        If nTipo = 1 Then
            funCargaCombos()
            funDesactivaNatural()
            funDesactivaJuridico()
            vnStatus = 1
            Me.XtraTabControl1.SelectedTabPageIndex = 0
        Else
            '-- Me.bbPista.Enabled = True
            Me.lblCodigo.Text = vnCodigo
            funCargaData()
            funCargaCombos()
            Me.lkTipo.EditValue = vnTipoPersona
            Me.lkStatus.EditValue = vnStatus
            Me.lkTipo.Enabled = False
            If vnTipoPersona = 1 Then
                '-- Natural
                funDesactivaJuridico()
            Else
                '-- Juridica
                funDesactivaNatural()
            End If
        End If
        bolInicio = False
    End Sub

    Private Function funCargaData()
        '-- Filtramos el registro
        strSQL = "SELECT * FROM Gen_Cliente_Venta " &
                    "WHERE nPersona = " & Me.vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Cargamos datos
        If vnTipoPersona = 1 Then
            '-- Persona Natural
            Me.txtCedula.Text = ds.Tables(0).Rows(0)("strCedula").ToString
            'Me.txtRuc1.Text = ds.Tables(0).Rows(0)("strRuc").ToString
            'Me.txtProveedor1.Text = ds.Tables(0).Rows(0)("strProveedor").ToString
            Me.txtNombre1.Text = ds.Tables(0).Rows(0)("strNombre1").ToString
            Me.txtNombre2.Text = ds.Tables(0).Rows(0)("strNombre2").ToString
            Me.txtApellido1.Text = ds.Tables(0).Rows(0)("strApellido1").ToString
            Me.txtApellido2.Text = ds.Tables(0).Rows(0)("strApellido2").ToString
            Me.rgSexo.SelectedIndex = CInt(funNull2Val(ds.Tables(0).Rows(0)("nSexo")) - 1)
            Me.txtTelefono.Text = ds.Tables(0).Rows(0)("strTelefono").ToString
            Me.txtCelular.Text = ds.Tables(0).Rows(0)("strCelular").ToString
            Me.txtDomicilio.Text = ds.Tables(0).Rows(0)("strDomicilio").ToString
            '- Fechas
            Me.dtmNace.Value = ds.Tables(0).Rows(0)("dtmNace").ToString
        Else
            '-- Persona Juridica
            Me.txtCedula2.Text = ds.Tables(0).Rows(0)("strCedula").ToString
            'Me.txtProveedor2.Text = ds.Tables(0).Rows(0)("strProveedor").ToString
            Me.txtEmpresa.Text = ds.Tables(0).Rows(0)("strNombre1").ToString
            Me.txtComercial.Text = ds.Tables(0).Rows(0)("strApellido1").ToString
            Me.txtTelefono2.Text = ds.Tables(0).Rows(0)("strTelefono").ToString
            Me.txtCelular.Text = ds.Tables(0).Rows(0)("strCelular").ToString
            Me.txtDomicilio2.Text = ds.Tables(0).Rows(0)("strDomicilio").ToString
        End If
        '-- Cargamos Status de la Persona
        vnStatus = ds.Tables(0).Rows(0)("nStatus")
        '-- Movernos de TAB
        If vnTipoPersona = 1 Then
            Me.XtraTabControl1.SelectedTabPageIndex = 0
        Else
            Me.XtraTabControl1.SelectedTabPageIndex = 1
        End If
        '--
        Return True
    End Function

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nPersona), 0) + 1 " &
                    "FROM Gen_Cliente_Venta"
        '--
        Me.lblCodigo.Text = funGetValor(strSQL)
        vnCodigo = funGetValor(strSQL)
        Return True
    End Function

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub funCargaCombos()
        '-- Combo Tipo de Persona
        funCargarlue(Me.lkTipo, "SELECT nID AS nCodigo, strDescripcion AS strDescripcion FROM TablaDeTablas " &
                                    "WHERE nCodTbl = 113 AND nEstatus = 1 AND nEmpresa = " & intEmpresa)
        '-- Combo de Status 
        funCargarlue(Me.lkStatus, "SELECT nID AS nCodigo, strDescripcion AS strDescripcion FROM TablaDeTablas " &
                                   "WHERE nCodTbl = 114 AND nEstatus = 1 AND nEmpresa = " & intEmpresa)
        '--
        Me.lkStatus.EditValue = vnStatus
    End Sub

    Private Sub lkTipo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkTipo.EditValueChanged
        If nTipo = 1 Then
            If Me.lkTipo.EditValue = 1 Then
                '-- Natural
                funActivaNatural()
                funDesactivaJuridico()
                funLimpiarJuridico()
                Me.XtraTabControl1.SelectedTabPageIndex = 0
                Me.txtCedula.Focus()
                '-- Juridico
            Else
                funActivaJuridico()
                funDesactivaNatural()
                funLimpiarNatural()
                Me.XtraTabControl1.SelectedTabPageIndex = 1
                Me.txtCedula2.Focus()
            End If
        End If
    End Sub

    Function funActivaNatural()
        txtCedula.Enabled = True
        'txtRuc1.Enabled = True
        'txtProveedor1.Enabled = True
        txtNombre1.Enabled = True
        txtNombre2.Enabled = True
        txtApellido1.Enabled = True
        txtApellido2.Enabled = True
        rgSexo.Enabled = True
        txtTelefono.Enabled = True
        txtCelular.Enabled = True
        txtDomicilio.Enabled = True
        Return True
    End Function

    Function funDesactivaNatural()
        txtCedula.Enabled = False
        'txtRuc1.Enabled = False
        'txtProveedor1.Enabled = False
        txtNombre1.Enabled = False
        txtNombre2.Enabled = False
        txtApellido1.Enabled = False
        txtApellido2.Enabled = False
        rgSexo.Enabled = False
        txtTelefono.Enabled = False
        txtDomicilio.Enabled = False
        Return True
    End Function

    Function funActivaJuridico()
        txtCedula2.Enabled = True
        'txtProveedor2.Enabled = True
        txtEmpresa.Enabled = True
        txtComercial.Enabled = True
        txtTelefono2.Enabled = True
        txtCelular.Enabled = True
        txtDomicilio2.Enabled = True
        Return True
    End Function

    Function funDesactivaJuridico()
        txtCedula2.Enabled = False
        'txtProveedor2.Enabled = False
        txtEmpresa.Enabled = False
        txtComercial.Enabled = False
        txtTelefono2.Enabled = False
        txtDomicilio2.Enabled = False
        Return True
    End Function

    Function funLimpiarNatural()
        txtCedula.Text = ""
        'Me.txtRuc1.Text = ""
        'txtProveedor1.Text = ""
        txtNombre1.Text = ""
        txtNombre2.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtTelefono.Text = ""
        txtDomicilio.Text = ""
        Return True
    End Function

    Function funLimpiarJuridico()
        txtCedula2.Text = ""
        'txtProveedor2.Text = ""
        txtEmpresa.Text = ""
        txtComercial.Text = ""
        txtTelefono2.Text = ""
        txtDomicilio2.Text = ""
        Return True
    End Function


    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        GroupControl1.Focus()
        If Me.lkTipo.EditValue = 1 Then
            '-- Guarda Natural
            If ValidarNatural() = True Then
                If MessageBox.Show("¿ Desea Grabar los datos ...?", "Atención !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    funSaveNatural()
                End If
            End If
        Else
            '-- Guarda Juridico
            If ValidarJuridico() = True Then
                If MessageBox.Show("¿ Desea Grabar los datos ...?", "Atención !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    funSaveJuridico()
                End If
            End If
        End If
    End Sub

    Private Function ValidarNatural() As Boolean
        If Len(Trim(Me.lblCodigo.Text)) = 0 Then
            Me.lblCodigo.Focus()
            MsgBox("Falta Codigo de Cliente !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtCedula.Text)) = 0 Then
            Me.txtCedula.Focus()
            MsgBox("Falta Nº. de Cedula !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtNombre1.Text)) = 0 Then
            Me.txtCedula.Focus()
            MsgBox("Falta Primer Nombre !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtApellido1.Text)) = 0 Then
            Me.txtApellido1.Focus()
            MsgBox("Falta Primer Apellido !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        '--
        Return True
    End Function

    Private Function ValidarJuridico() As Boolean
        If Len(Trim(Me.lblCodigo.Text)) = 0 Then
            Me.lblCodigo.Focus()
            MsgBox("Falta Codigo de Cliente !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
            'ElseIf Len(Trim(Me.txtRuc2.Text)) = 0 Then
            'Me.txtRuc2.Focus()
            'MsgBox("Falta Nº. de RUC !!!", MsgBoxStyle.Critical, "Atención !!!")
            'Return False
            'ElseIf Len(Trim(Me.txtProveedor2.Text)) = 0 Then
            'Me.txtProveedor2.Focus()
            'MsgBox("Falta Nº. de Proveedor del Estado !!!", MsgBoxStyle.Critical, "Atención !!!")
            'Return False
        ElseIf Len(Trim(Me.txtEmpresa.Text)) = 0 Then
            Me.txtCedula.Focus()
            MsgBox("Falta Nombre de Empresa !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtComercial.Text)) = 0 Then
            Me.txtApellido1.Focus()
            MsgBox("Falta Nombre Comercial !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funSaveNatural() As Boolean
        AbrirConexionGlobal()
        Try
            '-- GB-2012-01-09: Multiples conexiones, renumera codigo
            If nTipo = 1 Then
                funNuevoNumero()
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Gen_Cliente_Venta " &
                        "WHERE nPersona = " & vnCodigo

            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables(0).Rows.Count = 0 Then
                funNuevoNumero()
                dsAgregar.Tables(0).Rows.Add()
            End If
            '--
            With dsAgregar.Tables(0).Rows(0)
                '-- Tomamos el nRecno
                Dim vnRecno = funNull2Val(.Item("nRecno"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
                '-- Unir nombre
                Dim vcFullName As String
                vcFullName = String.Format("{0} {1} {2} {3}", txtApellido1.Text, Me.txtApellido2.Text, Me.txtNombre1.Text, Me.txtNombre2.Text)
                '-- Definir Sexo 1:Masculino, 2:Femenino
                Dim vnSexo As Integer = Me.rgSexo.SelectedIndex + 1
                '--
                If intTipoRegistro = 1 Then
                    '-- Agregando
                    funAddCampo("nPersonaTipo", Me.lkTipo.EditValue, 0)
                    funAddCampo("nStatus", vnStatus, 0)
                    funAddCampo("nPersona", vnCodigo, vnCodigo)
                    funAddCampo("strCedula", Trim(Me.txtCedula.Text), "")
                    'funAddCampo("strRuc", Trim(Me.txtRuc1.Text), "")
                    'funAddCampo("strProveedor", Trim(Me.txtProveedor1.Text), "")
                    funAddCampo("strNombre1", Trim(Me.txtNombre1.Text), "")
                    funAddCampo("strNombre2", Trim(Me.txtNombre2.Text), "")
                    funAddCampo("strApellido1", Trim(Me.txtApellido1.Text), "")
                    funAddCampo("strApellido2", Trim(Me.txtApellido2.Text), "")
                    funAddCampo("nSexo", vnSexo, 0)
                    funAddCampo("strTelefono", Trim(Me.txtTelefono.Text), "")
                    funAddCampo("strCelular", Trim(Me.txtCelular.Text), "")
                    funAddCampo("strDomicilio", Trim(Me.txtDomicilio.Text), "")
                    funAddCampo("strFullName", Trim(vcFullName), "")
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    '-- 14/10/2017
                    funAddCampo("dtmNace", Format(Me.dtmNace.Value, "s"), "")
                Else
                    '-- Editando
                    funAddCampo("nStatus", vnStatus, .Item("nStatus"))
                    funAddCampo("strCedula", Trim(Me.txtCedula.Text), .Item("strCedula").ToString)
                    'funAddCampo("strRuc", Trim(Me.txtRuc1.Text), .Item("strRuc").ToString)
                    'funAddCampo("strProveedor", Trim(Me.txtProveedor1.Text), .Item("strProveedor").ToString)
                    funAddCampo("strNombre1", Trim(Me.txtNombre1.Text), .Item("strNombre1").ToString)
                    funAddCampo("strNombre2", Trim(Me.txtNombre2.Text), .Item("strNombre2").ToString)
                    funAddCampo("strApellido1", Trim(Me.txtApellido1.Text), .Item("strApellido1").ToString)
                    funAddCampo("strApellido2", Trim(Me.txtApellido2.Text), .Item("strApellido2").ToString)
                    funAddCampo("nSexo", vnSexo, funNull2Val(.Item("nSexo")))
                    funAddCampo("strTelefono", Trim(Me.txtTelefono.Text), .Item("strTelefono").ToString)
                    funAddCampo("strCelular", Trim(Me.txtCelular.Text), .Item("strCelular").ToString)
                    funAddCampo("strDomicilio", Trim(Me.txtDomicilio.Text), .Item("strDomicilio").ToString)
                    funAddCampo("strFullName", Trim(vcFullName), .Item("strFullName").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    '-- 14/10/2017
                    funAddCampo("dtmNace", Format(Me.dtmNace.Value, "s"), .Item("dtmNace").ToString)
                End If
                '--- strLlave = "nRecno "
                strLlave = " nRecno = " & vnRecno
                ' funParametrosGrabacionTransaccion("Gen_Clientes", intTipoRegistro, vnRecno)
                funParametrosGrabacionTransaccion("Gen_Cliente_Venta", strLlave, intTipoRegistro, vnRecno)
                '--
                transaccionGlobal.Commit()
                DBConnGlobal.Close()
                Me.Close()

            End With

            LimpiarCampos()
            'transaccionGlobal.Rollback()
            DBConnGlobal.Close()

            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.bbSave.Enabled = False
        Me.Close()
    End Function

    Private Function funSaveJuridico() As Boolean
        AbrirConexionGlobal()
        '-- GB-2012-01-09: Multiples conexiones, renumera codigo
        If nTipo = 1 Then
            funNuevoNumero()
        End If
        ' -- Datos de la transacción
        strSQL = "SELECT * FROM Gen_Cliente_Venta " &
                 "WHERE nPersona = " & vnCodigo

        Dim dsAgregar As DataSet = funFillDataSet(strSQL)
        '--
        If dsAgregar.Tables(0).Rows.Count = 0 Then
            funNuevoNumero()
            dsAgregar.Tables(0).Rows.Add()
        End If
        '--
        With dsAgregar.Tables(0).Rows(0)
            '-- Tomamos el nRecno
            Dim vnRecno = funNull2Val(.Item("nRecno"))
            '-- Tipo de Accion para Guardar: 1:Add, 2:Update
            intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
            '-- Unir nombre
            Dim vcFullName As String
            vcFullName = Me.txtEmpresa.Text
            '--
            If intTipoRegistro = 1 Then
                '-- Agregando2
                funAddCampo("nPersonaTipo", Me.lkTipo.EditValue, 0)
                funAddCampo("nStatus", vnStatus, 0)
                funAddCampo("nPersona", vnCodigo, vnCodigo)
                funAddCampo("strCedula", Trim(Me.txtCedula2.Text), "")
                'funAddCampo("strRuc", Trim(Me.txtRuc2.Text), "")
                'funAddCampo("strProveedor", Trim(Me.txtProveedor2.Text), "")
                funAddCampo("strNombre1", Trim(Me.txtEmpresa.Text), "")
                funAddCampo("strApellido1", Trim(Me.txtComercial.Text), "")
                funAddCampo("strTelefono", Trim(Me.txtTelefono2.Text), "")
                funAddCampo("strCelular", Trim(Me.txtCelular.Text), "")
                funAddCampo("strDomicilio", Trim(Me.txtDomicilio2.Text), "")
                funAddCampo("strFullName", Trim(vcFullName), "")
                funAddCampo("strUserAdd", strUser, "")
                funAddCampo("strUserUpdate", strUser, "")
            Else
                '-- Editando
                funAddCampo("nStatus", vnStatus, funNull2Val(.Item("nStatus")))
                funAddCampo("strCedula", Trim(Me.txtCedula2.Text), .Item("strCedula").ToString)
                'funAddCampo("strRuc", Trim(Me.txtRuc2.Text), .Item("strRuc").ToString)
                'funAddCampo("strProveedor", Trim(Me.txtProveedor2.Text), .Item("strProveedor").ToString)
                funAddCampo("strNombre1", Trim(Me.txtEmpresa.Text), .Item("strNombre1").ToString)
                funAddCampo("strApellido1", Trim(Me.txtComercial.Text), .Item("strApellido1").ToString)
                funAddCampo("strTelefono", Trim(Me.txtTelefono2.Text), .Item("strTelefono").ToString)
                funAddCampo("strCelular", Trim(Me.txtCelular.Text), .Item("strCelular").ToString)
                funAddCampo("strDomicilio", Trim(Me.txtDomicilio2.Text), .Item("strDomicilio").ToString)
                funAddCampo("strFullName", Trim(vcFullName), .Item("strFullName").ToString)
                funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate".ToString))
            End If
            '--- strLlave = " nRecno "
            strLlave = " nRecno = " & vnRecno
            funParametrosGrabacionTransaccion("Gen_Cliente_Venta", strLlave, intTipoRegistro, vnRecno)
            '--
            transaccionGlobal.Commit()
            DBConnGlobal.Close()
            Me.Close()
        End With

        LimpiarCampos()
        '   transaccionGlobal.Rollback()
        DBConnGlobal.Close()

        Exit Function

        Me.bbSave.Enabled = False
        Me.Close()
    End Function

    Private Sub lkStatus_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkStatus.EditValueChanged
        If bolInicio = False Then
            vnStatus = IIf(Me.lkStatus.EditValue = 1, 1, 2)
        End If
    End Sub

    Private Sub txtCedula_ButtonPressed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCedula.ButtonPressed
        Select Case e.Button.Caption
            Case "NAC"
                'Especificar formato de cedula nacional
                txtCedula.Properties.Mask.EditMask = "\d\d\d-\d\d\d\d\d\d-\d\d\d\d\p{Lu}"
            Case "EXT"
                'Especificar formato de cedula de residencia
                txtCedula.Properties.Mask.EditMask = "\d\d\d\d\d\d"
            Case Else
                'NO ACCTION
        End Select
    End Sub


End Class