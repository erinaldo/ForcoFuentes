
Public Class frmRolEdit
    Public nTipo As Integer
    Public nPromotorActual As Integer

    Private Sub frmUsuarios_Edit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        funCargarlue(Me.LookUpEdit1, "SELECT nID AS nCodigo, strDescripcion AS strDescripcion FROM TablaDeTablas " & _
                           "WHERE nCodTbl = 116 AND nID>=1 AND nEstatus = 1 AND nEmpresa = " & intEmpresa)
         Me.LookUpEdit1.EditValue = CInt(GetSetting(Application.ProductName, Me.Name, "ROL", 0))
        funCargarMenu()
        Me.gvRoles.Focus()
    End Sub

    Function funCargarMenu()
        strSQL = "SELECT  CMENU, CSUBMENU," & _
                "ISNULL(( SELECT CONVERT(BIT, NSTATUS)" & _
                " FROM DBO.GEN_ROLMENU" & _
                " WHERE NROLID = " & funNull2Val(Me.LookUpEdit1.EditValue) & _
                " AND STRMENU = CSUBMENU),0) AS NSTATUS" & _
                " FROM DBO.GEN_MENU"
        Me.gcRoles.DataSource = funFillDataSet(strSQL).Tables(0)
        funOcultarTodasLasColumnas(Me.gvRoles)
        funDxGrid(Me.gvRoles, 2, False, True, False, 1, , , , True)
        funSetColumna(Me.gvRoles, "CMENU", "Menu", funIndice, 100, , , , , , , , , , , , , True)
        funSetColumna(Me.gvRoles, "CSUBMENU", "SubMenu", funIndice, 200)
        funSetColumna(Me.gvRoles, "NSTATUS", "Status", funIndice, 60, , 0)
        Me.gvRoles.BestFitColumns()
        Return True
    End Function

    Private Sub frmUsuarios_Edit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        Me.Cursor = Cursors.WaitCursor
        funSavePermisos()
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Function funSavePermisos()
        With Me.gvRoles
            For i As Integer = 0 To .RowCount - 1
                Dim dr As DataRow = .GetDataRow(i)
                If Not dr Is Nothing And Me.LookUpEdit1.EditValue >= 1 Then
                    funAddCampo("NROLID", Me.LookUpEdit1.EditValue)
                    funAddCampo("STRMENU", dr.Item("CSUBMENU").ToString)
                    funAddCampo("STRMODULO", Me.LookUpEdit1.Text)
                    funAddCampo("NSTATUS", IIf(funNull2Boolean(dr.Item("NSTATUS")), 1, 0))
                    strSQL = String.Format("SELECT NRECNO FROM Gen_RolMenu  WHERE NROLID = {0} AND STRMENU = '{1}'", _
                                           Me.LookUpEdit1.EditValue, dr.Item("CSUBMENU").ToString)
                    Dim nRecno As Integer = funNull2Val(funGetValor(strSQL))
                    funParametrosGrabacion("Gen_RolMenu", "NRECNO", IIf(nRecno = 0, 1, 2), nRecno)
                End If
            Next
        End With

        Return True
    End Function

    Private Sub LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookUpEdit1.EditValueChanged
        funCargarMenu()
        SaveSetting(Application.ProductName, Me.Name, "ROL", Me.LookUpEdit1.EditValue)
        Me.gvRoles.Focus()
    End Sub

    Private Sub gvRoles_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvRoles.CellValueChanging
        If e.Column.FieldName = "NSTATUS" Then
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")
        End If
    End Sub
End Class