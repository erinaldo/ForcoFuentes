Imports System.Data.OleDb
Imports System.IO
'Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmTraslados_SIN

    Dim ds As New DataSet
    Dim ds2 As New DataSet

    Shadows focus As Object
    Dim fila As Integer

    Dim ruta_archivo As String

    Dim dt As DataTable

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmTraslados_SIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'funCargaData()
    End Sub


    Private Sub bbOrigen_Click(sender As Object, e As EventArgs) Handles bbOrigen.Click
        Dim dialog As New OpenFileDialog()
        dialog.Filter = "Excel files |*.xls;*.xlsx"
        dialog.InitialDirectory = "C:\"
        dialog.Title = "Veuillez sélectionner le fichier à importer"
        'Encrypt the selected file. I'll do this later. :)
        If dialog.ShowDialog() = DialogResult.OK Then
            'Dim dt As DataTable
            dt = ImportExceltoDatatable(dialog.FileName)
            funUpdateGrid1()
        End If
    End Sub

    Private Sub bbDestino_Click(sender As Object, e As EventArgs) Handles bbDestino.Click
        Dim dialog As New OpenFileDialog()
        dialog.Filter = "Excel files |*.xls;*.xlsx"
        dialog.InitialDirectory = "C:\"
        dialog.Title = "Veuillez sélectionner le fichier à importer"
        'Encrypt the selected file. I'll do this later. :)
        If dialog.ShowDialog() = DialogResult.OK Then
            'Dim dt As DataTable
            dt = ImportExceltoDatatable(dialog.FileName)
            funUpdateGrid2()
        End If
    End Sub

    Public Shared Function ImportExceltoDatatable(filepath As String) As DataTable
        ' string sqlquery= "Select * From [SheetName$] Where YourCondition";
        Dim dt As New DataTable
        Try
            Dim ds As New DataSet()
            Dim constring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            Dim con As New OleDbConnection(constring & "")

            con.Open()

            Dim myTableName = con.GetSchema("Tables").Rows(0)("TABLE_NAME")
            Dim sqlquery As String = String.Format("SELECT * FROM [{0}]", myTableName) ' "Select * From " & myTableName  
            Dim da As New OleDbDataAdapter(sqlquery, con)
            da.Fill(ds)
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical)
            Return dt
        End Try
    End Function

    Private Function funUpdateGrid1() As Boolean
        '--  
        Me.gcDetalle.DataSource = dt
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle, "Articulo", "Articulo", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Origen", "Origen", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Cantidad", "Cantidad", funIndice(), 80, 1)
        Return True
    End Function

    Private Function funUpdateGrid2() As Boolean
        '--       
        Me.gcDetalle2.DataSource = dt
        '--
        GridViewStyle(Me.gvDetalle2)
        funOcultarTodasLasColumnas(Me.gvDetalle2)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle2, "Articulo", "Articulo", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Destino", "Destino", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Cantidad", "Cantidad", funIndice(), 80, 1)
        Return True
    End Function

    Private Sub bbProceso_Click(sender As Object, e As EventArgs) Handles bbProceso.Click
        '-- Procesar 
        funGrabarOrigen()
        funGrabarDestino()
        clsTraslado.funGetTrasladoSIN(Trim(Me.txtTraslado.Text))
        'cls.funGetDataRepMovDetalle(intEmpresa, strDesde, strHasta, strChekados)
        '--
    End Sub

    Private Sub funGrabarOrigen()
        Dim dsDetalle As New DataSet
        '--
        AbrirConexionGlobal()
        '--
        strSQL = "DELETE FROM bus_sinubica"
        funRunSQLTransaccion(strSQL)
        '--
        Try
            For i = 0 To Me.gvDetalle.RowCount - 1
                '--
                funAddCampo("Emp_Id", 1, "")
                funAddCampo("Suc_Id", 1001, "")
                funAddCampo("Bodega_Id", 1011, "")
                funAddCampo("Mov_Id", Trim(Me.txtTraslado.Text), "")
                funAddCampo("Detalle_Id", 1, "")
                funAddCampo("Posicion_X_Id", 1, "")
                funAddCampo("Posicion_Y_Id", 1, "")
                funAddCampo("Posicion_Z_Id", 1, "")
                funAddCampo("Posicion_Z_Codigo", "0101SIN", "")
                funAddCampo("Articulo_Id", Me.gvDetalle.GetDataRow(i)("Articulo").ToString, "")
                funAddCampo("Detalle_Cantidad", Me.gvDetalle.GetDataRow(i)("Cantidad"), 0)
                funAddCampo("Posicion_Tipo", 0, "")
                funAddCampo("Ubicacion", Me.gvDetalle.GetDataRow(i)("Origen").ToString, "")
                '--
                Dim nTipoD As Integer
                Dim nRecno As Integer
                '--
                If funNull2Val(("nRecno")) = 0 Then
                    nTipoD = 1
                Else
                    nTipoD = 2
                    nRecno = funNull2Val(("nRecno"))
                End If
                '-- 
                strLlave = "Articulo_Id = " & Me.gvDetalle.GetDataRow(i)("Articulo")
                '--
                funParametrosGrabacionTransaccion("bus_sinubica", strLlave, nTipoD, nRecno, , 0)
                '--
            Next
            transaccionGlobal.Commit()
        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        DBConnGlobal.Close()
    End Sub


    Private Sub funGrabarDestino()
        Dim dsDetalle As New DataSet
        '--
        AbrirConexionGlobal()
        '--
        strSQL = "DELETE FROM bus"
        funRunSQLTransaccion(strSQL)
        '--
        Try
            For i = 0 To Me.gvDetalle2.RowCount - 1
                '--
                funAddCampo("Emp_Id", 1, "")
                funAddCampo("Suc_Id", 1001, "")
                funAddCampo("Bodega_Id", 1011, "")
                funAddCampo("Mov_Id", Trim(Me.txtTraslado.Text), "")
                funAddCampo("Detalle_Id", 1, "")
                funAddCampo("Posicion_X_Id", 0, "")
                funAddCampo("Posicion_Y_Id", 0, "")
                funAddCampo("Posicion_Z_Id", 0, "")
                funAddCampo("Posicion_Z_Codigo", 0, "")
                funAddCampo("Articulo_Id", Me.gvDetalle2.GetDataRow(i)("Articulo").ToString, "")
                funAddCampo("Detalle_Cantidad", Me.gvDetalle2.GetDataRow(i)("Cantidad"), 0)
                funAddCampo("Posicion_Tipo", 1, "")
                funAddCampo("Ubicacion", Me.gvDetalle2.GetDataRow(i)("Destino").ToString, "")
                '--
                Dim nTipoD As Integer
                Dim nRecno As Integer
                '--
                If funNull2Val(("nRecno")) = 0 Then
                    nTipoD = 1
                Else
                    nTipoD = 2
                    nRecno = funNull2Val(("nRecno"))
                End If
                '-- 
                strLlave = "Articulo_Id = " & Me.gvDetalle2.GetDataRow(i)("Articulo")
                '--
                funParametrosGrabacionTransaccion("bus", strLlave, nTipoD, nRecno, , 0)
                '--
            Next
            transaccionGlobal.Commit()
        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        DBConnGlobal.Close()
    End Sub


End Class