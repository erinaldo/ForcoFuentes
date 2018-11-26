Imports System
Imports System.Data

Public Class frmCambiarPassword
    Dim Seguridad As New Seguridad.EncriptarClave
    Public vnpCodeUser As Integer
    Public vnpPerfilCall As Integer = 0

    Private Sub frmCambiarPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCambiarPassword_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtPasswordActual.Focus()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If vnpPerfilCall = 1 Then
            '-- Formulario cargado desde altas de usuarios
            strSQL = String.Format("SELECT * FROM Gen_Usuarios WHERE NCODE = '{0}'", Me.vnpCodeUser)
        Else
            '-- Formulario cargados desde el login
            strSQL = String.Format("SELECT * FROM Gen_Usuarios WHERE strData = '{0}'", Me.txtUsuario.Text)
        End If

        Dim dsUser As DataSet = funFillDataSet(strSQL)

        If dsUser.Tables(0).Rows.Count = 0 Then
            MsgBox("El nombre de usuario o la contraseña que ha escrito no son correctos.", MsgBoxStyle.Exclamation, "Usuarios")
            Me.txtPasswordActual.Focus()
            Me.txtPasswordActual.Text = ""
            Me.txtPassword.Text = ""
            Me.txtPassword1.Text = ""
            Exit Sub
        End If

        If Trim(Me.txtPassword.Text) = "" Then
            MsgBox("Introduzca la Nueva Contraseña", MsgBoxStyle.Information, "Usuarios")
            Me.txtPassword.Text = ""
            Me.txtPassword1.Text = ""
            Me.txtPassword.Focus()
            Me.txtPassword.SelectAll()
            Exit Sub
        End If

        If Me.txtPassword.Text <> Me.txtPassword1.Text Then
            MsgBox("Las contraseñas que ha escrito no coinciden. Vuelva a escribir las contraseñas.", MsgBoxStyle.Exclamation, "Usuarios")
            Me.txtPassword.Text = ""
            Me.txtPassword1.Text = ""
            Me.txtPassword.Focus()
            Me.txtPassword.SelectAll()
            Exit Sub
        End If

        If Me.txtPassword.Text.Length < 4 Then
            MsgBox("La contraseña debe contener al menos 4 carácteres", MsgBoxStyle.Information, "Usuarios")
            Me.txtPassword.Text = ""
            Me.txtPassword1.Text = ""
            Me.txtPassword.Focus()
            Me.txtPassword.SelectAll()
            Exit Sub
        End If

        strSQL = "UPDATE Gen_Usuarios " & _
                " SET strPassword = '" & Seguridad.GenerateHashDigest(Me.txtPassword.Text) & _
                "' WHERE NCODE = " & dsUser.Tables(0).Rows(0).Item("NCODE").ToString
        funRunSQL(strSQL)

        MsgBox("La contraseña se cambió con exito", MsgBoxStyle.Information, "Usuarios")

        Me.Close()
    End Sub

    Private Sub frmCambiarPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Text = strUser
    End Sub
End Class
