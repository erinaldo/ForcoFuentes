Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepConta
    '--
    Dim ds As New DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepConta_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
    End Sub
    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombos()
            funCargaSucursal()
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
        End Try
        '--
        Return True
    End Function

    Private Function funCargaCombos()
        '-- Cargar Empresa
        '-- Cast para convertir de smallint a int y el combo lo tome por default
        strSQL = "SELECT CAST(Casa_Id AS Int) AS nCodigo, Casa_Nombre AS strDescripcion FROM Casa ORDER BY Casa_Id"
        '--
        funCargarLue(Me.lkCasa, strSQL)
        lkCasa.EditValue = 1
        '--
        Return True
    End Function

    Private Function funCargaSucursal()
        Try
            strSQL = "SELECT Suc_Id, Suc_Nombre FROM Sucursal ORDER BY Suc_Id"
            '-
            ds = funFillDataSet(strSQL)
            '--
            Me.gcLista.DataSource = funFillDataSet(strSQL).Tables(0)
            '--
            funDxGrid(Me.gvLista, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Function funValidar() As Boolean
        If Len(Trim(Me.lkCasa.Text)) = 0 Then
            Me.lkCasa.Focus()
            MsgBox("Falta la casa!!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

End Class