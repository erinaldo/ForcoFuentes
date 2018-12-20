Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmConcepto_Open
    Dim ds As New DataSet
    Shadows focus As Object
    Dim fila As Integer
    '-- Reporte
    Dim strFormula As String

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmConcepto_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM v_Inv_Gv_Concepto " & _
                    "ORDER BY nCode"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcConcepto.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(Me.GridView1, "nCode", "ID", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strConcepto", "Concepto", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strData", "Descripción", funIndice(), 250, 1)
        funSetColumna(Me.GridView1, "strTipoConcepto", "Tipo", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "bitReservado", "Reservado", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strUserUpdate", "Usuario +", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "dtmUpdate", "Fecha +", funIndice(), 150, 1, , , "d")
        funSetColumna(Me.GridView1, "strHostName", "Pc +", funIndice(), 150, 1)
        '-- Numero de Registros
        Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    Private Function funRegistroActual()
        Me.gcConcepto.Focus()
        If Me.GridView1.RowCount > 0 Then
            focus = Me.GridView1.FocusedValue()
            fila = Me.GridView1.FocusedRowHandle
        End If
        funUpdateGrid()
        If Me.GridView1.RowCount > fila Then
            Me.GridView1.FocusedRowHandle = fila
            Me.GridView1.SetFocusedValue(focus)
        End If
        Return True
    End Function

    Private Sub bbAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        Dim f As New frmConcepto_Data
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
        funRegistroActual()
    End Sub
  
#Region "Reportes"

    Private Sub bbCode_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbCode.ItemClick
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '--
            Me.Cursor = Cursors.WaitCursor
            funImprimirNew("repInvConcepto_Code.rpt", 0, 0, 0, 0, 0, 0, "v_Inv_Gv_Concepto")
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
    End Sub

    Private Sub bbData_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbData.ItemClick
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '--
            Me.Cursor = Cursors.WaitCursor
            funImprimirNew("repInvConcepto_Name.rpt", 0, 0, 0, 0, 0, 0, "v_Inv_Gv_Concepto")
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
    End Sub

    Private Sub bbGrupo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbGrupo.ItemClick
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '--
            Me.Cursor = Cursors.WaitCursor
            funImprimirNew("repInvConcepto_Group.rpt", 0, 0, 0, 0, 0, 0, "v_Inv_Gv_Concepto")
            Me.Cursor = Cursors.Default
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
    End Sub

#End Region
 
    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmConcepto_Data
        f.barText.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnCodigo = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nCode"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.ShowDialog()
        funRegistroActual()
    End Sub
End Class