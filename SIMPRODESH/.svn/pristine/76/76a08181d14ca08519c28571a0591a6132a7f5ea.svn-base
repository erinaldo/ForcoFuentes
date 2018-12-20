Imports System.Data.OleDb
Public Class frmConsultaPorCategoriavb
    Dim m As Integer
    Private Sub frmConsultaPorCategoriavb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultacategoria()
    End Sub
    Private Sub consultacategoria()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "SELECT ca.Categoria_Nombre+ ' - '+convert(VARCHAR,ca.Categoria_Id) Categoria FROM dbo.Categoria_Articulo ca (NOLOCK) where ca.Emp_Id=" + com(empresa) + "order by ca.Categoria_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                ListBox1.Items.Add(dt.Rows(i)("Categoria"))
            Next
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      
        Dim i As Integer
        For i = ListBox1.SelectedIndices.Count - 1 To 0 Step -1

            ListBox2.Items.Add(ListBox1.SelectedItem)

            ListBox1.Items.RemoveAt(Convert.ToInt32(ListBox1.SelectedIndex))
        Next
    End Sub
    Public Class cargargrids
        Public idpro As String
        Public nombr As String
    End Class
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filtro As String
        Dim i As Integer
        ProgressBar1.Value = 0
        For i = 0 To ListBox2.Items.Count - 1
            If ListBox2.Items.Count > 1 Then
                If i = 0 Then
                    filtro = "(" & com(ListBox2.Items(i)) & ","
                ElseIf i = ListBox2.Items.Count - 1 Then
                    filtro = filtro + com(ListBox2.Items(i)) + ")"
                Else
                    filtro = filtro + com(ListBox2.Items(i)) + ","
                End If
            ElseIf ListBox2.Items.Count = 1 Then
                filtro = "(" & com(ListBox2.Items(i)) & ")"
            End If
        Next
        m = ListBox2.Items.Count
        BackgroundWorker1.RunWorkerAsync(filtro)
        Timer1.Start()
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = ListBox2.SelectedIndices.Count - 1 To 0 Step -1

            ListBox1.Items.Add(ListBox2.SelectedItem)

            ListBox2.Items.RemoveAt(Convert.ToInt32(ListBox2.SelectedIndex))
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim i As Integer
        abrirconexion()
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim h As Integer
        Dim cadenaconexion As String
        cadenaconexion = Conexion.ConnectionString
        Using connection As New OleDbConnection(cadenaconexion)
            Dim command As New OleDbCommand()
            Dim transaction As OleDbTransaction
            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection
            ' Open the connection and execute the transaction. 
            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                command.Connection = connection
                command.Transaction = transaction
                ' Execute the commands.
                For i = 0 To DataGridView1.SelectedRows.Count - 1
                    If tipo = 1 Then
                        n = 0
                        Dim sqlcomando As New OleDb.OleDbCommand
                        Dim sqlstring As String
                        sqlstring = "select v.Articulo_Id 'Articulo' from dbo.Descuento_Venta_Articulo v (nolock) where v.Descuento_Id= " + com(descuento.ToString())
                        sqlcomando.CommandText = sqlstring
                        sqlcomando.CommandType = CommandType.Text
                        sqlcomando.Connection = Conexion
                        Dim dt As New DataTable
                        dt.Load(sqlcomando.ExecuteReader)
                        For h = 0 To dt.Rows.Count - 1
                            If (dt.Rows(h)("Articulo").ToString() = DataGridView1.SelectedRows(i).Cells(0).Value.ToString) Then
                                m += 1
                                n += 1
                            End If
                        Next
                        If n = 0 Then
                            command.CommandText = _
                        "Insert into dbo.Descuento_Venta_Articulo(Articulo_Id,Descuento_Id,Emp_Id,Descuento_Fec_Actualizacion) values(" & com(DataGridView1.SelectedRows(i).Cells(0).Value.ToString) & "," & Convert.ToInt16(descuento.ToString()) & "," & Convert.ToInt16(empresa.ToString()) & ",GETDATE())"
                            command.ExecuteNonQuery()
                        End If
                    ElseIf tipo = 2 Then
                        n = 0
                        Dim sqlcomando2 As New OleDb.OleDbCommand
                        Dim sqlstring2 As String
                        sqlstring2 = "select p.Articulo_Id 'Articulo' from dbo.Promocion_Volumen_Articulo p (nolock) where p.Promocion_Id = " + com(promociones)
                        sqlcomando2.CommandText = sqlstring2
                        sqlcomando2.CommandType = CommandType.Text
                        sqlcomando2.Connection = Conexion
                        Dim dt As New DataTable
                        dt.Load(sqlcomando2.ExecuteReader)
                        For h = 0 To dt.Rows.Count - 1
                            If (dt.Rows(h)("Articulo").ToString() = DataGridView1.SelectedRows(i).Cells(0).Value.ToString) Then
                                m += 1
                                n += 1
                            End If
                        Next
                        If n = 0 Then
                            command.CommandText = _
                       "Insert into dbo.Promocion_Volumen_Articulo(Articulo_Id,Promocion_Id,Emp_Id,Promocion_Fec_Actualizacion) values(" & com(DataGridView1.SelectedRows(i).Cells(0).Value.ToString) & "," & Convert.ToInt16(promociones) & "," & Convert.ToInt16(empresa.ToString()) & ",GETDATE())"
                            command.ExecuteNonQuery()
                        End If
                    ElseIf tipo = 3 Then
                        n = 0
                        Dim sqlcomando As New OleDb.OleDbCommand
                        Dim sqlstring As String
                        sqlstring = " select p.Articulo_Id 'Articulo' from dbo.PV_Lista_Precios_Detalle p (nolock) where  p.ListaP_Id = " + com(listapr.ToString())
                        sqlcomando.CommandText = sqlstring
                        sqlcomando.CommandType = CommandType.Text
                        sqlcomando.Connection = Conexion
                        Dim dt As New DataTable
                        dt.Load(sqlcomando.ExecuteReader)
                        For h = 0 To dt.Rows.Count - 1
                            If (dt.Rows(h)("Articulo").ToString() = DataGridView1.SelectedRows(i).Cells(0).Value.ToString) Then
                                m += 1
                                n += 1
                            End If
                        Next
                        If n = 0 Then
                            command.CommandText = _
                        "Insert into dbo.PV_Lista_Precios_Detalle(Articulo_Id,ListaP_Id,Emp_Id,Detalle_Fec_Actualizacion,Detalle_Precio) values(" & com(DataGridView1.SelectedRows(i).Cells(0).Value.ToString) & "," & Convert.ToInt16(listapr) & "," & Convert.ToInt16(empresa.ToString()) & ",GETDATE()," & 0 & ")"
                            command.ExecuteNonQuery()
                        End If
                        End If
                Next
                transaction.Commit()
                cerrarconexion()
                connection.Close()
                connection.Dispose()
            Catch ex As Exception
                MessageBox.Show("El articulo ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                transaction.Rollback()
                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using

        Close()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ProgressBar1.Maximum = 100
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(m + 5)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim filtros As String = e.Argument.ToString()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        abrirconexion()
        Try
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a (nolock) , dbo.Categoria_Articulo  c (nolock) where a.Categoria_Id=c.Categoria_Id and c.Categoria_Nombre+ ' - '+convert(VARCHAR,c.Categoria_Id) in" & filtros + " order by a.Articulo_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            e.Result = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cerrarconexion()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DataGridView1.DataSource = e.Result()
    End Sub
End Class