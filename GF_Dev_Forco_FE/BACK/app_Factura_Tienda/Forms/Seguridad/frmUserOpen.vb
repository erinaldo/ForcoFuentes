Imports System.Windows.Forms

Public Class frmUserOpen
    Shadows focus As Object
    Dim bolTipoBusqueda As Boolean
    Dim fila As Integer

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmOpenUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Return And Me.txtNombre.Focused Then
            bolTipoBusqueda = IIf(Len(Trim(Me.txtNombre.Text)) >= 1, True, False)
            funUpdateGrid()
        End If
    End Sub

    Private Sub frmOpenUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        Me.txtNombre.Focus()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            strSQL = "SELECT * FROM vw_Gen_Gv_User "
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strNombre LIKE '%" & Me.txtNombre.Text & "%')"
            strSQL += " ORDER BY nCode"
        Else
            strSQL = "SELECT TOP 100 * FROM vw_Gen_Gv_User " & _
                         " ORDER BY nCode"
        End If
        '--
        Me.gcUser.DataSource = funFillDataSet(strSQL).Tables(0)

        funDxGrid(Me.gvUser, 1, False, False, False, 0)
        funOcultarTodasLasColumnas(Me.gvUser)
        indice = 0
        '--
        funSetColumna(Me.gvUser, "nCode", "Código", funIndice(), 80, 1)
        funSetColumna(Me.gvUser, "strNombre", "Nombre de la Persona", funIndice(), 300, 1)
        funSetColumna(Me.gvUser, "strData", "Usuario", funIndice(), 150, 1)
        funSetColumna(Me.gvUser, "strEstatus", "Status", funIndice(), 80, 1)
        funSetColumna(Me.gvUser, "strUsuarioAdd", "Usuario +", funIndice(), 90, 1)
        funSetColumna(Me.gvUser, "DNACIMIENTO", "Fecha +", funIndice(), 90, 1)
        funSetColumna(Me.gvUser, "strHostName", "Pc +", funIndice(), 80, 1)
        funSetColumna(Me.gvUser, "strEstatusNow", "Login", funIndice(), 100, 1)
        Me.gvUser.BestFitColumns()
        Return True
    End Function

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick
        bolTipoBusqueda = False
        funUpdateGrid()
    End Sub

    Private Sub bbBitacora_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        'Dim f As New frmUserBitacora
        'f.vnpUserId = funNull2Val(gvUser.GetFocusedRowCellValue("nCode"))
        'f.lblNombreUser.Text = gvUser.GetFocusedRowCellValue("strNombre").ToString
        'f.ShowDialog()
    End Sub

    Private Sub bbAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        Using f As New frmUsuarios_Edit()
            f.nTipo = 1
            ' 1-Agregar, 2-Editar
            f.ShowDialog()
        End Using

        RegistroActual()
    End Sub

    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        Using f As New frmUsuarios_Edit()
            f.nTipo = 2
            f.nPromotorActual = funNull2Val(Me.gvUser.GetFocusedRowCellValue("nCode"))
            f.ShowDialog()
        End Using

        RegistroActual()
    End Sub

    Private Sub bbChange_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        'Dim f As New frmCambiarPassword
        'f.vnpCodeUser = funNull2Val(Me.gvUser.GetFocusedRowCellValue("nCode"))
        'f.txtUsuario.Text = Me.gvUser.GetFocusedRowCellValue("strData").ToString
        'f.vnpPerfilCall = 1
        'f.ShowDialog()
        '--
        RegistroActual()
    End Sub

    Private Sub RegistroActual()
        Me.gcUser.Focus()
        If Me.gvUser.RowCount > 0 Then
            focus = Me.gvUser.FocusedValue()
            fila = Me.gvUser.FocusedRowHandle
        End If
        bolTipoBusqueda = False
        funUpdateGrid()
        If Me.gvUser.RowCount > fila Then
            Me.gvUser.FocusedRowHandle = fila
            Me.gvUser.SetFocusedValue(focus)
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim f As New frmRolEdit
        f.ShowDialog()
    End Sub
End Class