Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Configuration
Imports ExcelLibrary.SpreadSheet

Public Class frmRepCompVentas
    '--
    Dim ds As New DataSet
    Dim i As Integer
    Dim strChekados As String
    Dim dsReporte As DataSet
    Dim strCommonColumnName As String
    Dim bolTipoBusqueda As Boolean

    Private Sub frmRepCompVentas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Return And Me.txtNombre.Focused Then
            If Len(Trim(Me.txtNombre.Text)) >= 1 Then
                bolTipoBusqueda = True
                funUpdateGrid()
            Else
                bolTipoBusqueda = False
                funUpdateGrid()
            End If
        End If
    End Sub

    Private Sub frmRepCompVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '--
        bolFound = False
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        '--
    End Sub

    Private Function funUpdateGrid()
        Try
            '-- ds = clsDepartamento.funListaDeptos()
            '-- 
            If bolTipoBusqueda = True Then
                '-- Busca el contenido de textbox
                strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection, " & _
                            "Suc_Id, " & _
                            "Suc_Nombre " & _
                            "FROM dbo.Sucursal "
                '--
                strSQL += "WHERE (Suc_Nombre LIKE '%" & Me.txtNombre.Text & "%' OR Suc_Id LIKE '%" & Me.txtNombre.Text & "%')"
                '--
                strSQL += " ORDER BY Suc_Nombre "
            Else
                '-- Cuando carga por default
                strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection, " & _
                            "Suc_Id, Suc_Nombre " & _
                            "FROM dbo.Sucursal " & _
                            "ORDER BY Suc_Nombre"
            End If
            '--
            ds = funFillDataSet(strSQL)
            '--
            Me.gcLista.DataSource = ds.Tables(0)
            '--
            funDxGrid(Me.gvLista, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Sub gvLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvLista.Click
        With Me.gvLista
            If .FocusedColumn.Name = "colOpt" Then
                .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("optSelection")))
            End If
        End With
    End Sub

    Private Sub repositoryItemCheckEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        gvLista.PostEditor()

        ' The UpdateCurrentRow method call is optional for CheckEditor.
        ' Don't call it for Text editors!
        ' gridView1.UpdateCurrentRow();   

        ' TEST:
        'Console.WriteLine(gvLista.GetDataRow(gvLista.FocusedRowHandle)(gvLista.FocusedColumn.FieldName))
    End Sub

    Private Sub bbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbAdd.Click
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", True)
            Next
        End With
    End Sub

    Private Sub bbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbDelete.Click
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", False)
            Next
        End With
    End Sub

    Private Sub bbPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        funProcesaChekados()
        If funValidar() = True Then
            Me.Cursor = Cursors.WaitCursor
            funImprimir()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function funImprimir()
        '--
        Dim lstParametros As New List(Of String)
        '--
        lstParametros.Add(Me.dtpDesde1.Value.Date)
        lstParametros.Add(Me.dtpHasta1.Value.Date)
        lstParametros.Add(Me.dtpDesde2.Value.Date)
        lstParametros.Add(Me.dtpHasta2.Value.Date)
        lstParametros.Add(Me.strChekados.ToString)
        '-- Cual reporte visualizar
        If Me.optOpcion.SelectedIndex = 0 Then
            funPrintConSp("repCompVentasSucDepto.rpt", lstParametros)
        Else
            funPrintConSp("repCompVentasSucCat.rpt", lstParametros)
        End If
        '--
        Return True
    End Function

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                If Convert.ToBoolean(.GetDataRow(i)("optSelection")) = True Then
                    strChekados += IIf(nCambios > 0, ",", "")
                    strChekados += .GetDataRow(i)("Suc_Id").ToString
                    nCambios += 1
                End If
            Next
            If Trim(strChekados).Length > 0 Then
                strChekados = IIf(Mid(strChekados, Len(strChekados), 1) = ",", Mid(strChekados, 1, Len(strChekados) - 1), strChekados)
            End If
        End With
        Return True
    End Function

    Private Function funValidar() As Boolean
        If Trim(strChekados).Length = 0 Then
            Me.gvLista.Focus()
            MsgBox("Falta seleccionar una Sucursal !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub
   
End Class