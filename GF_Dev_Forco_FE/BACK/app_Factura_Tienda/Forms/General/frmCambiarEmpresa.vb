Public Class frmCambiarEmpresa
    Dim User As New SGA.clsUsuarios
    Dim ds As New DataSet
    Dim i As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCambiarEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorFondoFormulario(Me)
        'DataGridRowStyle(Me.dgvEmpresas)
        funUpdateGrid()
    End Sub

    Private Sub funUpdateGrid()
        Me.dgvEmpresas.Rows.Clear()
        ds = User.UsuariosEmpresas
        If ds.Tables("Tabla").Rows.Count > 0 Then
            Me.dgvEmpresas.Rows.Add(ds.Tables("Tabla").Rows.Count)
            For i = 0 To ds.Tables("Tabla").Rows.Count - 1
                With ds.Tables("Tabla").Rows(i)
                    Me.dgvEmpresas.Rows(i).Cells("nCodigo").Value = .Item("Código").ToString
                    Me.dgvEmpresas.Rows(i).Cells("strNombre").Value = .Item("Nombre").ToString
                    Me.dgvEmpresas.Rows(i).Cells("nActiva").Value = .Item("nActiva").ToString
                    Me.dgvEmpresas.Rows(i).Cells("nMoneda").Value = .Item("nMoneda").ToString
                End With
            Next
        End If
        Me.nRegistros.Text = "Registros: " & ds.Tables("Tabla").Rows.Count
    End Sub

    Private Sub dgvCatalogo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpresas.CellClick
        If e.ColumnIndex = 0 Then
            SendKeys.Send("{Right}")
            SendKeys.Send("{Left}")

            Me.dgvEmpresas.Rows(e.RowIndex).Cells("nActiva").Value = True

            For i = 0 To Me.dgvEmpresas.Rows.Count - 1
                If i <> e.RowIndex Then
                    Me.dgvEmpresas.Rows(i).Cells("nActiva").Value = False
                End If
            Next

            intEmpresa = Me.dgvEmpresas.Rows(e.RowIndex).Cells("nCodigo").Value
            EmpresaNombre = Me.dgvEmpresas.Rows(e.RowIndex).Cells("strNombre").Value
            EmpresaMoneda = ds.Tables("Tabla").Rows(0).Item("nMoneda")

            'MesInicio = Me.dgvCatalogo.Rows(e.RowIndex).Cells("nMesInicio").Value
            'Me.ssEmpresa.Text = Me.dgvEmpresas.Rows(e.RowIndex).Cells("strNombre").Value

            'strImagen = funGetParametroPorEmpresa("IMAGEN", intEmpresa)
            'EmpresaLogo = Application.StartupPath & "\Logos\" & strImagen
            'ImagenFooter = Application.StartupPath & "\Logos\" & funGetParametroPorEmpresa("IMAGEN2", intEmpresa)

            User.CambiarEmpresa(nUserID, intEmpresa)

        End If
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
End Class
