Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmTablaDeTablas
    Dim dsEmpresas As New DataSet
    Dim ds As New DataSet
    Public i, Fila, Col, intTabla, nTabla, nValor As Integer
    Dim bolInicio As Boolean
    Dim strCampo As String

    Private Sub frmOpenSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- ColorFondoFormulario(Me)
        'Try
        '    intTabla = Val(GetSetting(Application.ProductName, "Tablas", "nTabla", 1))
        'Catch
        'End Try
        bolInicio = True
        strCampo = "strDescripcion"
        funComboTablas()
        funCargarEmpresas()
        Me.lblTabla.Text = Me.cbTablas.SelectedValue & " - " & Me.cbTablas.Text
        bolInicio = False
        funUpdateGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Function funComboTablas()
        If nValor > 0 Then
            strSQL = "SELECT NCODTBL, STRDESCRIPCION, STRCONCEPTO" & _
                        " FROM TablaDeTablas" & _
                        " WHERE NCODTBL=" & IIf(nValor = 0, 0, nValor) & _
                        " AND nID = 0 " & _
                        " AND NEMPRESA = 1" & _
                        " ORDER BY STRDESCRIPCION"
            '--
        Else
            strSQL = "SELECT NCODTBL, STRDESCRIPCION, STRCONCEPTO" & _
                        " FROM TablaDeTablas" & _
                        " WHERE 1 = 1 " & _
                        " AND nID = 0 " & _
                        " AND NEMPRESA = 1" & _
                        " ORDER BY STRDESCRIPCION"
            '--
        End If
        '-- GB: 16-04-2010
        '-- Pasamos el parametro de numero de tabla ó el de la tabla Empresa
        intTabla = IIf(nValor > 0, nValor, 1)
        '--
        Me.cbTablas.DataSource = funFillDataSet(strSQL).Tables(0)
        Me.cbTablas.ValueMember = "NCODTBL"
        Me.cbTablas.DisplayMember = "STRDESCRIPCION"
        Me.cbTablas.SelectedValue = intTabla
        Me.cbTablas.Enabled = True
        Me.cbTablas.BackColor = Color.White
        Return True
    End Function

    Function funUpdateGrid()
        If Not IsNumeric(Me.cbTablas.SelectedValue) Then
        Else
            strSQL = " SELECT DISTINCT NCODTBL, STRDESCRIPCION, STRCONCEPTO, NID " & _
                        " FROM TablaDeTablas" & _
                        " WHERE 1 = 1 " & _
                        " AND NCODTBL =  " & intTabla
            '--
            If Len(Trim(Me.txtNombre.Text)) >= 1 Then
                strSQL += " AND STRDESCRIPCION LIKE '%" & Me.txtNombre.Text & "%'"
            End If
            strSQL += " ORDER BY NID"
            ds = funFillDataSet(strSQL)
            Me.dgvTablas.DataSource = ds
            Me.dgvTablas.DataMember = "Tabla"
            funOcultarTodasLasColumnas(Me.dgvTablas)
            funSetColumna(Me.dgvTablas, "NID", "ID", 0, 50)
            funSetColumna(Me.dgvTablas, "STRDESCRIPCION", "DESCRIPCION", 2, 200)
            funSetColumna(Me.dgvTablas, "STRCONCEPTO", "COMENTARIO", 3, 200)
            Me.nRegistros.Text = "Registros: " & ds.Tables("Tabla").Rows.Count
        End If
        Return True
    End Function

    Function funCargarEmpresas()
        If intTabla = 999 Then
            Me.dgvEmpresas.Visible = False
            Me.sbAplicar.Visible = False
        Else
            Me.dgvEmpresas.Visible = True
            Me.sbAplicar.Visible = True
        End If
        strSQL = "SELECT DISTINCT NCODTBL, NID, STRDESCRIPCION, STRCONCEPTO, NGRUPO, NESTATUS" & _
                    " FROM TablaDeTablas" & _
                    " WHERE 1 = 1" & _
                    " AND NCODTBL = 1 " & _
                    " AND nID >= 1" & _
                    " AND NEMPRESA = 1" & _
                    " ORDER BY NID"
        '--
        dsEmpresas = funFillDataSet(strSQL)
        dgvEmpresas.DataSource = dsEmpresas
        dgvEmpresas.DataMember = "Tabla"
        funOcultarTodasLasColumnas(Me.dgvEmpresas)
        funSetColumna(dgvEmpresas, "NID", "ID", 0, 50)
        funSetColumna(dgvEmpresas, "STRDESCRIPCION", "MODULO", 1, 250)
        funSetColumna(dgvEmpresas, "NESTATUS", "STATUS", 2, 70, , 0)
        Me.dgvEmpresas.Visible = True
        Return True
    End Function

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim f As New frmTablaDeTablasNew
        f.Tipo = 1
        f.nCodTbl = Me.cbTablas.SelectedValue
        f.ShowDialog()
        'Se actualiza el combo porque puede haber nuevas tablas
        bolInicio = True
        funComboTablas()
        bolInicio = False
        'Es probable que la tabla haya cambiado
        intTabla = f.nCodTbl
        Me.cbTablas.SelectedValue = intTabla
        funUpdateGrid()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        funUpdateGrid()
    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Ver()
    End Sub

    Private Sub Ver()
        If Me.dgvTablas.RowCount = 0 Then
            Exit Sub
        End If
        funCargarDatosEditar()
        Try
            If Me.dgvTablas.RowCount > 0 Then
                Fila = Me.dgvTablas.CurrentRow.Index
                Col = Me.dgvTablas.CurrentCell.ColumnIndex
            End If
            funUpdateGrid()
            If Me.dgvTablas.RowCount > Fila Then
                Me.dgvTablas.CurrentCell = Me.dgvTablas.Rows(Fila).Cells(Col)
                Me.dgvTablas.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function funCargarDatosEditar()
        With Me.dgvTablas.Rows(Me.dgvTablas.SelectedCells(0).RowIndex)
            Dim f As New frmTablaDeTablasNew
            f.nRecNo = -1
            f.nCodTbl = .Cells("NCODTBL").Value
            f.txtDescripcion.Text = .Cells("STRDESCRIPCION").Value
            f.txtConcepto.Text = .Cells("STRCONCEPTO").Value.ToString
            f.nID = .Cells("nID").Value.ToString
            strSQL = "SELECT NESTATUS FROM TABLADETABLAS WHERE NRECNO = " & f.nRecNo
            Dim nStatus = 1
            f.RadioButton1.Checked = IIf(nStatus <> 1, True, False)
            f.RadioButton2.Checked = IIf(nStatus = 0, True, False)
            f.Tipo = 2
            f.ShowDialog()
        End With
        Return True
    End Function

    Private Sub dgvTablas_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTablas.CellMouseClick
        Select Case e.ColumnIndex
            Case 3 : Me.strCampo = "nID"
            Case 5 : Me.strCampo = "strDescripcion"
            Case Else : Me.strCampo = "strDescripcion"
        End Select

        If Me.dgvTablas.RowCount > 0 Then
            Fila = Me.dgvTablas.CurrentRow.Index
        End If

        Col = e.ColumnIndex
    End Sub

    Private Sub cbTablas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTablas.SelectedValueChanged
        If Not bolInicio Then
            strCampo = "strDescripcion"
            SaveSetting(Application.ProductName, "Tablas", "nTabla", Convert.ToString(Me.cbTablas.SelectedValue))
            Me.lblTabla.Text = Me.cbTablas.SelectedValue & " - " & Me.cbTablas.Text
            intTabla = Me.cbTablas.SelectedValue
            funUpdateGrid()
        End If
    End Sub

    Private Sub dgvTablas_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTablas.RowEnter
        'RegistrosPorEmpresa(e.RowIndex)
        For i As Integer = 0 To Me.dgvEmpresas.RowCount - 1
            strSQL = "SELECT NESTATUS FROM TABLADETABLAS " & _
                        " WHERE NCODTBL =  " & intTabla & _
                        " AND NID = " & Me.dgvTablas.Rows(e.RowIndex).Cells("NID").Value & _
                        " AND NEMPRESA = " & i + 1
            '--
            Me.dgvEmpresas.Rows(i).Cells("NESTATUS").Value = CBool(funGetValor(strSQL))
        Next
    End Sub

    Private Sub cmdBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBorrar.Click
        If Me.dgvTablas.RowCount = 0 Then
            Exit Sub
        End If
        If Me.dgvTablas.Rows(Me.dgvTablas.SelectedCells(0).RowIndex).Cells("nCodTbl").Value = 1 Then
            MsgBox("No se puede eliminar una empresa", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If
        If MessageBox.Show("¿Está seguro que desea eliminar...?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
            Exit Sub
        Else
            AbrirConexionGlobal()
            Try
            Catch ex As Exception
                transaccionGlobal.Rollback()
                DBConnGlobal.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
        End If
        DBConnGlobal.Close()
        funUpdateGrid()
    End Sub

    Private Sub bbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbAplicar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            For j As Integer = 0 To Me.dgvTablas.RowCount - 1
                For i As Integer = 0 To Me.dgvEmpresas.RowCount - 1
                    If Me.dgvTablas.Rows(j).Selected = True Then
                        strSQL = "UPDATE TABLADETABLAS " & _
                                    " SET NESTATUS = " & Val(Me.dgvEmpresas.Rows(i).Cells("NESTATUS").Value) & _
                                    " WHERE NCODTBL = " & intTabla & _
                                    " AND NEMPRESA = " & Me.dgvEmpresas.Rows(i).Cells("NID").Value & _
                                    " AND NID = " & Me.dgvTablas.Rows(j).Cells("NID").Value
                        '--
                        funRunSQL(strSQL)

                    End If
                Next
            Next
        Catch EX As Exception
            MsgBox(EX.ToString)
        End Try
        Me.Cursor = Cursors.Default
        MsgBox("Apliación exitosa...")
    End Sub
End Class
