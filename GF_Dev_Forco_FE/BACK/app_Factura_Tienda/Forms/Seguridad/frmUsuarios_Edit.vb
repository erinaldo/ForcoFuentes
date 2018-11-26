Imports System
Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmUsuarios_Edit
    Public nTipo, nPromotorProc As Integer
    Public nPromotorActual As Integer
    Dim Seguridad As New Seguridad.EncriptarClave
    Dim dsUsuarios, dsEmpresa As DataSet
    Dim nPromotor As Integer
    Dim nNameUser As String


    Private Sub frmUsuarios_Edit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        funUpdateGridEmpresas()
        Me.barText.Caption = IIf(nTipo = 1, "Agregando...", "Editando...")
        strSQL = "SELECT * FROM Gen_Usuarios WHERE NCODE = " & nPromotorActual
        dsUsuarios = funFillDataSet(strSQL)
        If dsUsuarios.Tables(0).Rows.Count >= 1 Then
            With dsUsuarios.Tables(0).Rows(0)
                Me.txtNombre1.Text = .Item("strNombre1").ToString
                Me.txtNombre2.Text = .Item("strNombre2").ToString
                Me.txtApellido1.Text = .Item("strApellido1").ToString
                Me.txtApellido2.Text = .Item("strApellido2").ToString
                Me.txtCedula.Text = .Item("strCedula").ToString
                Me.txtUser.Text = .Item("strData").ToString
                Me.rgSexo.SelectedIndex = Val(.Item("nSexo").ToString) - 1
                Me.rgEstatus.SelectedIndex = Val(.Item("nEstatus").ToString) - 1
            End With
            funCargarRoles()

        Else
            dsUsuarios.Tables(0).Rows.Add()
            Me.newUser()


        End If
    End Sub

    Function funUpdateGridEmpresas(Optional ByVal SQL As String = "")
        Dim nPromotor As Integer = nPromotorActual
        If nTipo = 1 Then
            strSQL = "SELECT ISNULL(MAX(NCODE),0)+1 FROM Gen_Usuarios"
            nPromotor = funGetValor(strSQL)
            nPromotorProc = nPromotor
        End If

        If Len(Trim(SQL)) = 0 Then
            SQL = " SELECT E.NCODE, E.STRNOMBRE, ISNULL(PE.NUSERID, 0) AS USUARIO, ISNULL(PE.nAsignada, 0) AS STATUS FROM Gen_Empresas E " & _
                  " LEFT JOIN Gen_UsuariosEmpresas PE ON E.NCODE = PE.NEMPRESA AND PE.NUSERID = " & nPromotor & _
                  " ORDER BY E.NCODE "
        Else
            SQL = " SELECT E.NCODE, E.STRNOMBRE, ISNULL(PE.NUSERID, 0) AS USUARIO, ISNULL(PE.nAsignada, 0) AS STATUS FROM Gen_Empresas E " & _
                  " LEFT JOIN Gen_UsuariosEmpresas PE ON E.NCODE = PE.NEMPRESA AND PE.NUSERID = " & nPromotorActual & _
                  " ORDER BY E.NCODE "
        End If
        dsEmpresa = funFillDataSet(SQL)
        With Me.gcEmpresas
            .DataSource = dsEmpresa.Tables(0)
        End With
        funDxGrid(Me.GvEmpresas, 1, False, False, False, 0, True, False, False)
        funOcultarTodasLasColumnas(Me.GvEmpresas)
        Me.GvEmpresas.OptionsBehavior.Editable = True
        indice = 0
        funSetColumna(Me.GvEmpresas, "NCODE", "Código", funIndice(), 80, 1)
        funSetColumna(Me.GvEmpresas, "STRNOMBRE", "Descripción", funIndice(), 250, 1)
        funSetColumna(Me.GvEmpresas, "STATUS", "Status", funIndice(), 90, 1, 0, , , 2)
        Return True
    End Function

    Function funCargarRoles()
        strSQL = String.Format("SELECT * FROM FUNROLESPORUSUARIO({0}, {1}) ORDER BY STRDESCRIPCION ", intEmpresa, nPromotorActual)
        Me.gcRoles.DataSource = funFillDataSet(strSQL).Tables(0)
        funOcultarTodasLasColumnas(Me.gcRoles)
        funDxGrid(Me.gvRoles, 2, False, True, False, 1)
        funSetColumna(Me.gvRoles, "NID", "ID", funIndice, 100)
        funSetColumna(Me.gvRoles, "STRDESCRIPCION", "Cuentas", funIndice, 200)
        funSetColumna(Me.gvRoles, "STATUS", "Status", funIndice, 60, , 0)
        Me.gvRoles.BestFitColumns()
        Return True
    End Function

    Private Sub frmUsuarios_Edit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub bbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbReset.Click
        strSQL = "UPDATE Gen_Usuarios SET strPassword='' WHERE NCODE =" & nPromotorActual
        funRunSQL(strSQL)
    End Sub

    Function newUser()
        nPromotor = nPromotorActual
        If nTipo = 1 Then
            strSQL = "SELECT ISNULL(MAX(NCODE),0)+1 FROM Gen_Usuarios"
            nPromotor = funGetValor(strSQL)
            nPromotorProc = nPromotor
        End If
        Return True
    End Function
    Function comprobarName()
        strSQL = " SELECT strData FROM dbo.Gen_Usuarios" & _
                 " WHERE strData= '" & Trim(Me.txtUser.Text) & _
                 "'"
        nNameUser = funGetValor(strSQL)
        Return True
    End Function

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If nTipo = 1 Then
            comprobarName()
            saveUser()
        Else
            nNameUser = ""
            saveUser()
        End If
     
        
    End Sub

    Function saveUser()
        If Len(Trim(Me.txtUser.Text)) >= 4 Then
            If Trim(Me.txtUser.Text) <> nNameUser Then
                With dsUsuarios.Tables(0).Rows(0)
                    funAddCampo("NCODE", IIf(nTipo = 1, nPromotor, nPromotorActual), "")
                    funAddCampo("strData", Trim(Me.txtUser.Text), .Item("strData").ToString)
                    funAddCampo("strNombre1", Trim(Me.txtNombre1.Text), .Item("strNombre1").ToString)
                    funAddCampo("strNombre2", Trim(Me.txtNombre2.Text), .Item("strNombre2").ToString)
                    funAddCampo("strApellido1", Trim(Me.txtApellido1.Text), .Item("strApellido2").ToString)
                    funAddCampo("strApellido2", Trim(Me.txtApellido2.Text), .Item("strApellido2").ToString)
                    funAddCampo("strCedula", Trim(Me.txtCedula.Text), .Item("strCedula").ToString)
                    funAddCampo("nSexo", Me.rgSexo.SelectedIndex + 1, funNull2Val(.Item("nSexo")))
                    funAddCampo("nEstatus", Me.rgEstatus.SelectedIndex + 1, funNull2Val(.Item("nEstatus")))
                    funAddCampo("strUsuarioAdd", strUser, "")
                    If nTipo = 1 Then
                        funAddCampo("strPassword", "")
                    End If
                    funParametrosGrabacion("Gen_Usuarios", "NCODE", nTipo, IIf(nTipo = 1, nPromotor, nPromotorActual), 0)
                End With
                funSavePersonaEmpresa()
                funSavePermisos()
                Me.Close()
            Else
                MsgBox("El Nombre de Usuario, ya Existe !!!", MsgBoxStyle.Critical, "Atención !!!")
            End If
        Else
            Me.txtUser.Focus()
            MsgBox("El Nombre de Usuario, tiene que ser mayor que 4 Caracteres !!!", MsgBoxStyle.Critical, "Atención !!!")
        End If
    End Function

    Function funSavePermisos()
        With Me.gvRoles
            For i As Integer = 0 To .RowCount - 1
                Dim dr As DataRow = .GetDataRow(i)
                If Not dr Is Nothing Then
                    funAddCampo("NUSERID", nPromotorActual)
                    funAddCampo("NROLID", funNull2Val(dr.Item("NID")))
                    Dim bolStatus As Boolean = dr.Item("STATUS")
                    funAddCampo("NSTATUS", IIf(bolStatus, 1, 0))
                    strSQL = "SELECT NRECNO FROM Gen_UsuariosRoles WHERE NUSERID = " & nPromotorActual & _
                            " AND NROLID = " & funNull2Val(dr.Item("NID"))
                    Dim nRecno As Integer = funNull2Val(funGetValor(strSQL))
                    funParametrosGrabacion("Gen_UsuariosRoles", "NRECNO", IIf(nRecno = 0, 1, 2), nRecno)
                End If
            Next
        End With
        Return True
    End Function

    Private Function funSavePersonaEmpresa()
        '--
        For i As Integer = 0 To Me.GvEmpresas.RowCount - 1
            Dim vnEmpresa As Integer = 0
            vnEmpresa = Me.GvEmpresas.GetDataRow(i)("nCode")

            strSQL = "SELECT * FROM Gen_UsuariosEmpresas " & _
                        "WHERE nUserID = " & IIf(nTipo = 1, nPromotor, nPromotorActual) & _
                        " AND nEmpresa = " & vnEmpresa
            Dim dsEmpresa As DataSet = funFillDataSet(strSQL)

            If dsEmpresa.Tables(0).Rows.Count = 0 Then
                dsEmpresa.Tables(0).Rows.Add()
            End If

            Dim vnRecno As Integer
            With dsEmpresa.Tables(0).Rows(0)
                '-- Tomamos el nRecno
                If nTipo = 1 Then
                    strSQL = "SELECT MAX(NRECNO)+1 AS newnRecno" & _
                       " FROM dbo.Gen_UsuariosEmpresas"
                    vnRecno = funGetValor(strSQL)
                Else
                    vnRecno = funNull2Val(.Item("nRecno"))
                End If

                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                If nTipo = 1 Then
                    funAddCampo("NUSERID", IIf(nTipo = 1, nPromotor, nPromotorActual), 0)
                    funAddCampo("nEmpresa", vnEmpresa, 0)
                    '-- 2012-08-30: Omitida para evitar que el usuario seleccione la empresa la proxima vez
                    '-- funAddCampo("nActiva", 0)
                    Dim bolStatus As Boolean = Me.GvEmpresas.GetDataRow(i)("STATUS") '.Item("nAsignada")
                    funAddCampo("nAsignada", IIf(bolStatus, 1, 0))
                    'funAddCampo("strUserAdd", strUser, "")
                Else
                    funAddCampo("nEmpresa", Me.GvEmpresas.GetDataRow(i)("NCODE"), funNull2Val(.Item("nEmpresa")))
                    Dim bolStatus As Boolean = Me.GvEmpresas.GetDataRow(i)("STATUS")
                    funAddCampo("nAsignada", IIf(bolStatus, 1, 0), funNull2Val(.Item("nAsignada")))
                    '-- 2012-08-30: Omitida para evitar que el usuario seleccione la empresa la proxima vez
                    '-- funAddCampo("nActiva", 0)
                End If


                strLlave = " NUSERID = " & IIf(nTipo = 1, nPromotor, nPromotorActual) & " " & _
                            " AND nEmpresa = " & vnEmpresa & _
                            " AND nRecno "
                funParametrosGrabacion("Gen_UsuariosEmpresas", strLlave, nTipo, vnRecno)
            End With
        Next
        Return True
    End Function


    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbRoles_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRoles.ItemClick
        Dim f As New frmRolEdit
        f.ShowDialog()
    End Sub

    Private Sub gvRoles_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvRoles.CellValueChanging
        If e.Column.FieldName = "STATUS" Then
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")
        End If
    End Sub

    'Private Sub gvEmpresas_Click(sender As Object, e As System.EventArgs) Handles GvEmpresas.Click
    '    '-- 2013-07-26: Permite un solo click en la columna Checkbox en un gridview creando en tiempo de ejecucion
    '    '-- para los gridview creados en diseños aplicar ejemplod e ministerio public
    '    With Me.GvEmpresas
    '        '-- Debe ir siempre la palabra "col" + "campo", el nombre del campo debe mantener su escritura mayusculas o minusculas
    '        If .FocusedColumn.Name = "colSTATUS" Then
    '            '-- Debe ir siempre a como fue escrito el nombre del campo mayusculas o minusculas
    '            .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("STATUS")))
    '        End If
    '    End With
    'End Sub

    'Private Sub gvRoles_Click(sender As Object, e As System.EventArgs) Handles gvRoles.Click
    '    '-- 2013-07-26: Permite un solo click en la columna Checkbox en un gridview creando en tiempo de ejecucion
    '    '-- para los gridview creados en diseños aplicar ejemplod e ministerio public
    '    With Me.gvRoles
    '        '-- Debe ir siempre la palabra "col" + "campo", el nombre del campo debe mantener su escritura mayusculas o minusculas
    '        If .FocusedColumn.Name = "colSTATUS" Then
    '            '-- Debe ir siempre a como fue escrito el nombre del campo mayusculas o minusculas
    '            .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("STATUS")))
    '        End If
    '    End With
    'End Sub
End Class