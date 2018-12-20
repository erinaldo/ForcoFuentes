Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmTablaDeTablasNew
    Dim i As Integer
    Public Tipo As Integer '1 = Nuevo, 2 = Editar
    Public nCodTbl As Integer
    Public nGrupo As Integer
    Public nRecNo As Integer
    Public nID As String
    Public nGrupoComp As Integer
    Public nTransaccion As Integer
    Dim dsEmpresas As New DataSet
    Dim bolInicio As Boolean
    

    Private Sub frmTablaDeTablasNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        bolInicio = True
        CargarDatos()
        ColorFondoFormulario(Me)
        Me.Text = "Agregar"
        Me.cbTablas.SelectedValue = Me.nCodTbl
        Me.cbTablas.Enabled = True
        Me.cbTablas.BackColor = Color.White
        Me.bolInicio = False
        Dim nTabla As Integer

        If Me.Tipo = 2 Then 'Editar
            Me.Text = "Editar"

            strSQL = "SELECT nCodTbl FROM TablaDeTablas WHERE nRecNo = " & nGrupo
            nTabla = funGetValor(strSQL)

            Me.cbTablas.SelectedValue = Me.nCodTbl
            Me.cbGrupos.SelectedValue = nTabla
            Me.cbSubGrupo.SelectedValue = nGrupo
            Me.cbGruposComp.SelectedValue = nGrupoComp
            Me.cbTransacciones.SelectedValue = nTransaccion
            Me.cbTablas.Enabled = False
        End If

        If 1 = 0 Then
            Me.Label5.Visible = True
            Me.cbGruposComp.Visible = True
            Me.Label6.Visible = True
            Me.cbTransacciones.Visible = True
        Else
            Me.Label5.Visible = False
            Me.cbGruposComp.Visible = False
            Me.Label6.Visible = False
            Me.cbTransacciones.Visible = False
        End If

        Me.txtDescripcion.SelectAll()
        Me.txtDescripcion.Focus()
        Me.lblMensaje.Text = ""
        Me.bolInicio = False
    End Sub

    Private Sub frmTablaDeTablasNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            Exit Sub
        End If

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        
        If Trim(Me.txtDescripcion.Text) = "" Then
            Me.lblMensaje.Text = "Introduzca la descripción"
            MsgBox("Introduzca la descripción", MsgBoxStyle.Information)
            Me.txtDescripcion.Focus()
            Me.txtDescripcion.SelectAll()
            Exit Sub
        End If

        AbrirConexionGlobal()

        Try
            funGrabacion()
            transaccionGlobal.Commit()
            CargarDatos()
        Catch ex As Exception
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        DBConnGlobal.Close()
        Me.Close()
    End Sub

    Function funGrabacion()
        Dim nId As Integer
        If Me.cbTablas.SelectedValue = 0 Then 'Agregar una nueva Tabla
            nId = 0
            strSQL = "select isnull(max(ncodtbl),0) + 1 " & _
                    " from tabladetablas " & _
                    " where nempresa = " & intEmpresa
            nCodTbl = Val(funGetValor(strSQL))
        Else 'Agregar registros a una Tabla existente
            strSQL = "select isnull(max(NID),0) + 1 " & _
                    " from tabladetablas " & _
                    " where nempresa = " & intEmpresa & _
                    " and ncodtbl = " & Me.cbTablas.SelectedValue
            nId = Val(funGetValor(strSQL))
            nCodTbl = Me.cbTablas.SelectedValue
        End If

        strSQL = "SELECT COUNT(*) FROM TABLADETABLAS WHERE NCODTBL = 1 AND NID >= 1 AND NEMPRESA = 1"
        Dim nEmpresas As Integer = Val(funGetValor(strSQL))

        For I As Integer = 1 To nEmpresas
            funAddCampo("NCODTBL", nCodTbl, Me.cbTablas.SelectedValue)
            funAddCampo("NID", nId, nId)
            funAddCampo("NEMPRESA", I, 0)
            funAddCampo("STRDESCRIPCION", Me.txtDescripcion.Text, DBNull.Value.ToString)
            funAddCampo("STRCONCEPTO", Me.txtConcepto.Text, DBNull.Value.ToString)
            funAddCampo("NESTATUS", funStatus(), -2)
            Dim strCondicion As String = "NID=" & Me.nID & " AND NCODTBL = " & nCodTbl & " AND NEMPRESA = " & I
            funParametrosGrabacionTransaccion("TABLADETABLAS", strCondicion, Me.Tipo, , , 0)
        Next

        Me.lblMensaje.Text = "Los datos se guardaron correctamente"
        Me.txtDescripcion.Text = ""
        Me.txtConcepto.Text = ""
        Me.txtDescripcion.Focus()
        Return True
    End Function

    Function funStatus() As Integer
        If Me.RadioButton1.Checked Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub CargarDatos()

        strSQL = "SELECT 0 AS NCODTBL, ' Nueva' as STRDESCRIPCION, '' AS STRCONCEPTO " & _
                " UNION " & _
                "SELECT NCODTBL, STRDESCRIPCION, STRCONCEPTO" & _
                " FROM TablaDeTablas" & _
                " WHERE nEmpresa = " & intEmpresa & _
                " AND nID = 0" & _
                " ORDER BY STRDESCRIPCION"
        Me.cbTablas.DataSource = funFillDataSet(strSQL).Tables(0)
        Me.cbTablas.ValueMember = "NCODTBL"
        Me.cbTablas.DisplayMember = "STRDESCRIPCION"

        strSQL = "SELECT 0 AS NCODTBL, 'NINGUNO' AS STRDESCRIPCION, 1 AS ORDEN " & _
                "UNION " & _
                " SELECT NCODTBL, STRDESCRIPCION, 2 AS ORDEN FROM TABLADETABLAS " & _
                " WHERE NID = 0 AND NESTATUS = 1 " & _
                " AND NEMPRESA = " & intEmpresa & _
                " GROUP BY NCODTBL, STRDESCRIPCION " & _
                " ORDER BY ORDEN, STRDESCRIPCION"
        Me.cbGrupos.DataSource = funFillDataSet(strSQL).Tables(0)
        Me.cbGrupos.ValueMember = "NCODTBL"
        Me.cbGrupos.DisplayMember = "STRDESCRIPCION"

        Me.cbGruposComp.DataSource = funFillDataSet(strSQL).Tables("Tabla")
        Me.cbGruposComp.ValueMember = "NCODTBL"
        Me.cbGruposComp.DisplayMember = "STRDESCRIPCION"

        Me.cbTransacciones.DataSource = funFillDataSet(strSQL).Tables("Tabla")
        Me.cbTransacciones.ValueMember = "NCODTBL"
        Me.cbTransacciones.DisplayMember = "STRDESCRIPCION"

    End Sub

    Private Sub cbGrupos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGrupos.SelectedValueChanged
        If Not bolInicio Then
            If IsNumeric(cbGrupos.SelectedValue) Then
                strSQL = "SELECT NID, STRDESCRIPCION, NRECNO FROM TABLADETABLAS " & _
                         " WHERE NCODTBL = " & cbGrupos.SelectedValue & _
                         " AND NEMPRESA = " & intEmpresa
                Me.cbSubGrupo.DataSource = funFillDataSet(strSQL).Tables(0)
                Me.cbSubGrupo.DisplayMember = "STRDESCRIPCION"
                Me.cbSubGrupo.ValueMember = "nRecno"
            End If
        End If
    End Sub

End Class
