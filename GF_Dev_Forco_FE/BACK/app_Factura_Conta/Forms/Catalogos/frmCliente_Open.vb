Imports System
Imports System.Data

Public Class frmCliente_Open
    Dim ds As New DataSet
    Shadows focus As Object
    Dim fila As Integer
    '-- Reporte
    Dim strFormula As String
    Dim bolTipoBusqueda As Boolean

    Private Sub frmPersonas_Open_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmCliente_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        Me.txtNombre.Focus()
    End Sub

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        Dim f As New frmCliente_Data
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
        RegistroActual()
    End Sub

    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        Dim f As New frmCliente_Data
        f.barText.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnTipoPersona = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nPersonaTipo"))
        f.vnCodigo = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nPersona"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.ShowDialog()
        RegistroActual()
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            '--
            strSQL = "SELECT * FROM v_Gen_Clientes_Ventas_All "
            If IsNumeric(Me.txtNombre.Text) Then
                strSQL += " Where nPersona LIKE '%" & Me.txtNombre.Text & "%'"
            Else
                strSQL += " Where strFullName LIKE '%" & Trim(Me.txtNombre.Text) & "%'"
            End If
            strSQL += " ORDER BY strFullName"
            '--
        Else
            '--
            strSQL = "SELECT TOP 100 * FROM v_Gen_Clientes_Ventas_All " &
                     " ORDER BY nPersona"
            '--
        End If
        '--
        ds = funFillDataSet(strSQL)
        '--
        With Me.gcPersonas
            .DataSource = ds.Tables(0)
        End With
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(Me.GridView1, "nPersona", "Cód", funIndice(), 60, 1)
        funSetColumna(Me.GridView1, "strCedula", "Cédula", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strEstatus", "Estado", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strDescripcion", "Tipo Cliente", funIndice(), 90, 1)
        'funSetColumna(Me.GridView1, "strRuc", "RUC", funIndice(), 90, 1)
        'funSetColumna(Me.GridView1, "strProveedor", "No. Proveedor", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strFullName", "Apellidos y Nombres", funIndice(), 250, 1)
        funSetColumna(Me.GridView1, "strUserAdd", "User.Reg", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "strUserUpdate", "User.Mod", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "dtmAdd", "F.Reg", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "dtmUpdate", "F.Mod", funIndice(), 90, 1, , , "d")
        funSetColumna(Me.GridView1, "strHostName", "Pc.Reg", funIndice(), 90, 1)
        Return True
    End Function

    Private Sub bbExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        Try
            Dim strFileName As String = Application.StartupPath & "\repPersonas.xls"
            Me.gcPersonas.ExportToXls(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RegistroActual()
        Me.gcPersonas.Focus()
        If Me.GridView1.RowCount > 0 Then
            focus = Me.GridView1.FocusedValue()
            fila = Me.GridView1.FocusedRowHandle
        End If
        bolTipoBusqueda = False
        funUpdateGrid()
        If Me.GridView1.RowCount > fila Then
            Me.GridView1.FocusedRowHandle = fila
            Me.GridView1.SetFocusedValue(focus)
        End If
    End Sub

    Private Sub bbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles bbRefresh.Click
        bolTipoBusqueda = False
        funUpdateGrid()
    End Sub
End Class