Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class frmLogin
   Dim dsUser As New DataSet
    Dim ds As New DataSet
    Dim intentos As Integer
    Public Seguridad As New Seguridad.EncriptarClave
    'Dim bolModulo As Boolean

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtUsuario.Text = GetSetting(Application.ProductName, "Login", "Usuario", "")
            If GetSetting(Application.ProductName, "Login", "Clave", "").ToString.Length > 0 Then
                Me.txtPassword.Text = GetSetting(Application.ProductName, "Login", "Clave", "")
            End If
            If GetSetting(Application.ProductName, "Login", "Recordar", "") = "Si" Then
                Me.chkRecordarClave.Checked = IIf(GetSetting(Application.ProductName, "Login", "RecordarClave", "") = "Si", True, False)
                Me.chkRecordar.Checked = True
                Me.txtPassword.Focus()
            Else
                Me.chkRecordar.Checked = False
                Me.txtUsuario.Focus()
            End If
            intentos = 0
            EmpresasPorUsuario()
            Me.txtPassword.Focus()
            '--
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'If bolModulo = False Then
        '    MsgBox("No tiene acceso a este modulo, Consulete con el Administrador !!!", MsgBoxStyle.Information, "Atención !!!")
        '    Me.Close()
        '    Exit Sub
        'End If
        '--
        If Len(Trim(Me.cbEmpresa.Text)) Then
            '-- Si hay datos digitados que proceda

            strSQL = String.Format("SELECT * FROM Gen_Usuarios WHERE strData = '{0}'", strUser)
            dsUser = funFillDataSet(strSQL)
            '--
            If dsUser.Tables(0).Rows.Count = 0 Then
                MsgBox("Usuario no existe", MsgBoxStyle.Critical)
                Me.txtPassword.Focus()
                Me.txtPassword.Text = ""
                Me.txtPassword.SelectAll()
                intentos += 1
                If intentos >= 10 Then
                    MsgBox("Intentos fallidos...", MsgBoxStyle.Information, "Intentos fallidos...")
                    Me.Close()
                End If
                Exit Sub
            End If
            With dsUser.Tables(0).Rows(0)
                '--
                Dim strClave As String = funCTxt(Me.txtPassword.Text)
                Dim strClaveBase As String = .Item("strPassword").ToString
                '--
                If Len(Trim(strClaveBase)) = 0 Then
                    MsgBox("Debe cambiar su contraseña", MsgBoxStyle.Information, "Cambiar contraseña")
                    Dim f As New frmCambiarPassword
                    f.txtUsuario.Text = strUser
                    f.txtUsuario.ReadOnly = True
                    f.txtUsuario.BackColor = Color.White
                    f.ShowDialog()
                ElseIf Len(Trim(strClave)) = 0 Then
                    MsgBox("Escriba su contraseña", MsgBoxStyle.Critical)
                    Me.txtPassword.Focus()
                    Me.txtPassword.Text = ""
                    Me.txtPassword.SelectAll()
                ElseIf .Item("strPassword").ToString <> Seguridad.GenerateHashDigest(strClave) Then
                    MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
                    Me.txtPassword.Focus()
                    Me.txtPassword.Text = ""
                    Me.txtPassword.SelectAll()
                    Exit Sub
                Else
                    funDatosGenerales()
                    If nUserID = 68 Then '-- Si es el admin
                        funSaveSettings()
                    End If
                    '-- Variables para ok del program
                    bolLogin = True
                    Me.Close()
                End If
            End With
            '--
        End If
    End Sub

    Function funSaveSettings()
        '--
        Try
            nUserID = dsUser.Tables(0).Rows(0).Item("nCode")
            '--
            If Me.chkRecordar.Checked = True Then
                SaveSetting(Application.ProductName, "Login", "Usuario", funCTxt(Me.txtUsuario.Text))
                SaveSetting(Application.ProductName, "Login", "Recordar", "Si")
                '-- Recordar la contraseña
                If Me.chkRecordarClave.Checked = True Then
                    SaveSetting(Application.ProductName, "Login", "Clave", funCTxt(Me.txtPassword.Text))
                    SaveSetting(Application.ProductName, "Login", "RecordarClave", "Si")
                Else
                    SaveSetting(Application.ProductName, "Login", "Clave", "")
                    SaveSetting(Application.ProductName, "Login", "RecordarClave", "No")
                End If
            Else
                SaveSetting(Application.ProductName, "Login", "Usuario", "")
                SaveSetting(Application.ProductName, "Login", "Recordar", "No")
                SaveSetting(Application.ProductName, "Login", "Clave", "")
                SaveSetting(Application.ProductName, "Login", "RecordarClave", "No")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '--
        Return True
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtUsuario_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.Leave
        EmpresasPorUsuario()
    End Sub

    Private Sub chkRecordar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecordar.CheckedChanged
        If Me.chkRecordar.Checked = False Then
            Me.chkRecordarClave.Checked = False
        End If
    End Sub

    Private Sub chkRecordarClave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecordarClave.CheckedChanged
        If Me.chkRecordarClave.Checked = True Then
            Me.chkRecordar.Checked = True
        End If
    End Sub

    Private Sub funDatosGenerales()

        intEmpresa = Me.cbEmpresa.SelectedValue
        '-- Desactivamos los registros del usuario
        strSQL = "UPDATE Gen_UsuariosEmpresas SET nActiva = 0 " & _
                 "WHERE nUserID = " & nUserID
        '--
        funRunSQL(strSQL)

        '-- Activamos el registro del usuario actual
        strSQL = "UPDATE Gen_UsuariosEmpresas SET nActiva = 1 " & _
                 "WHERE nUserID = " & nUserID & _
                 "AND nEmpresa = " & intEmpresa
        '--
        funRunSQL(strSQL)

        '-- Obtenemos el nombre de la empresa
        strSQL = "SELECT gu.nEmpresa,ge.STRNOMBRE AS Nombre, ge.* " & _
                "FROM GEN_USUARIOSEMPRESAS gu " & _
                "INNER JOIN Gen_Empresas ge ON gu.nEmpresa = ge.NCODE " & _
                "WHERE gu.nActiva = 1 And gu.nUserID = " & nUserID
        '--
        ds = funFillDataSet(strSQL)
        '--
        EmpresaNombre = ds.Tables(0).Rows(0).Item("Nombre")
    End Sub

    Private Sub EmpresasPorUsuario()
        Try
            strUser = funCTxt(Me.txtUsuario.Text)
            '--
            strSQL = String.Format("SELECT NCODE FROM Gen_Usuarios WHERE strData= '{0}'", strUser)
            nUserID = funGetValor(strSQL)
            '--
            strSQL = "SELECT gu.nEmpresa AS Codigo,ge.strNombre AS Nombre, ge.* " & _
                    "FROM GEN_USUARIOSEMPRESAS gu " & _
                    "INNER JOIN GEN_EMPRESAS ge ON gu.nEmpresa = ge.NCODE " & _
                    "WHERE gu.nActiva = 1 And gu.nUserID = " & nUserID
            '--
            ds = funFillDataSet(strSQL)
            '--
            If ds.Tables(0).Rows.Count = 0 Then
                '--
            Else
                intEmpresa = ds.Tables(0).Rows(0).Item("Codigo")
            End If
            '--
            strSQL = "SELECT gu.nEmpresa AS Codigo, ge.STRNOMBRE AS NOMBRE, gu.nActiva " & _
                     "FROM GEN_USUARIOSEMPRESAS gu " & _
                     "INNER JOIN GEN_EMPRESAS ge ON gu.nEmpresa = ge.NCODE AND gu.nUserID = " & nUserID & " " & _
                     "WHERE gu.nAsignada = 1"
            '--
            Me.cbEmpresa.DataSource = funFillDataSet(strSQL).Tables(0)
            Me.cbEmpresa.ValueMember = "Codigo"
            Me.cbEmpresa.DisplayMember = "Nombre"
            Me.cbEmpresa.SelectedValue = intEmpresa

            ''-- Obtenemos el permiso del modulo
            'strSQL = "SELECT nModuloSAR FROM Gen_Usuarios WHERE NCODE = " & nUserID
            'bolModulo = funGetValor(strSQL)

            '--
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
