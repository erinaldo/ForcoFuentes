Option Explicit On
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain
    Dim Usuarios As New SGA.clsUsuarios
    Dim ds As DataSet
    Public strModulo As String
    Public bolSolicitudCheque As Boolean
    Dim j, x As Integer

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        funCleanTempFiles()
    End Sub

    Private Sub subFullVisibleFalse()
        '--
        Me.nav2RepProveedor.Visible = False
        Me.nav2Saldos.Visible = False
        Me.nav2RepMovto.Visible = False
        Me.nbCat1.Visible = False
        Me.nbCat2.Visible = False
        Me.nbCat3.Visible = False
        Me.nbCat4.Visible = False
        Me.nbCat5.Visible = False
        Me.nbCat6.Visible = False
        Me.nbConsumo1.Visible = False
        Me.nbConsumo2.Visible = False
        Me.nbExiste1.Visible = False
        Me.nbExiste2.Visible = False
        Me.nbExisteNo1.Visible = False
        Me.nbExisteNo2.Visible = False
        '--
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '--
        Try
            '-- Pasamos los rotulos de la barra de status
            strTitulo = ""
            Me.ssUser.Text = strUser
            Me.ssServidor.Text = strServidor
            Me.ssBaseDatos.Text = strBaseDatos
            If strModulo = "" Then
                strModulo = GetSetting(Application.ProductName, "Menu", "Modulo", "")
            End If
            If strModulo = "" Then
                Me.NavBarControl1.Groups("navCatalogo").Expanded = True
            Else
                Me.NavBarControl1.Groups(strModulo).Expanded = True
            End If
            '-- Seleccionamos la Empresa
            strSQL = "SELECT TOP 1 STRDESCRIPCION FROM TABLADETABLAS WHERE NCODTBL = 1 AND NID = " & intEmpresa
            EmpresaNombre = funGetValor(strSQL)
            Me.ssEmpresa.Text = EmpresaNombre
            '-- Texto de Ubicación acutal de la barra de menu
            Me.ssModulo.Text = Me.NavBarControl1.ActiveGroup.Caption
            '-- Seleccinamos el Area 
            strSQL = "SELECT TOP 1 STRDESCRIPCION FROM TABLADETABLAS WHERE NCODTBL = 10 AND NID = " & nDepto
            Me.ssArea.Text = funGetValor(strSQL)
            '--
            funRecorreMenuOutlook()
            funActivarMenuUsuario()
            funActivarMenuUsuarioprin()
            '--
            subFullVisibleFalse()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '--
    End Sub

    Function funRecorreMenuOutlook()
        funRunSQL("TRUNCATE TABLE GEN_MENU")
        Dim NVALORMENU As Integer
        For i As Integer = 0 To NavBarControl1.Groups.Count - 1
            NVALORMENU = i
            For k As Integer = 0 To NavBarControl1.Groups(i).ItemLinks.Count - 1

                NavBarControl1.Groups(i).ItemLinks.Item(k).Item.Visible = False
                Dim strMenu As String = NavBarControl1.Groups(i).Name
                Dim strSubMenu As String = NavBarControl1.Groups(i).ItemLinks.Item(k).ItemName
                strSQL = String.Format("INSERT INTO GEN_MENU ( cMenu, cSubMenu, nIdMenu ) VALUES  ( '{0}', '{1}', '{2}')", strMenu, strSubMenu, NVALORMENU)
                funRunSQL(strSQL)
            Next
        Next
        Return True
    End Function

    Function funActivarMenuUsuario()
        strSQL = String.Format("SELECT  * FROM dbo.Gen_RolMenu" & _
                            " WHERE nRolId IN ( SELECT  NID " & _
                            " FROM FUNROLESPORUSUARIO({0}, {1}) WHERE STATUS = 1 )" & _
                            " AND NSTATUS = 1", _
                            intEmpresa, nUserID)
        Dim dsRoles As DataSet = funFillDataSet(strSQL)

        For i As Integer = 0 To dsRoles.Tables(0).Rows.Count - 1
            Dim dr As DataRow = dsRoles.Tables(0).Rows(i)
            For j As Integer = 0 To NavBarControl1.Groups.Count - 1

                For k As Integer = 0 To NavBarControl1.Groups(j).ItemLinks.Count - 1
                    If NavBarControl1.Groups(j).ItemLinks.Item(k).ItemName = dr.Item("STRMENU").ToString Then
                        NavBarControl1.Groups(j).ItemLinks.Item(k).Item.Visible = True
                    End If
                Next
            Next
        Next
        Return True
    End Function

    Function funActivarMenuUsuarioprin()
        strSQL = String.Format(" SELECT  dbo.Gen_Menu.cMenu, dbo.Gen_Menu.nIdMenu FROM dbo.Gen_RolMenu GRM " & _
                             " INNER JOIN dbo.Gen_Menu ON dbo.Gen_Menu.cSubMenu=GRM.strMenu " & _
                             " WHERE nRolId IN ( SELECT  NID FROM FUNROLESPORUSUARIO({0}, {1}) WHERE STATUS = 1 ) " & _
                             " AND GRM.NSTATUS = 1  GROUP BY nIdMenu,cMenu", _
                             intEmpresa, nUserID)
        Dim dsRoles As DataSet = funFillDataSet(strSQL)


        For j As Integer = 0 To NavBarControl1.Groups.Count - 1
            NavBarControl1.Groups(j).Visible = False
            For i As Integer = 0 To dsRoles.Tables(0).Rows.Count - 1
                Dim dr As DataRow = dsRoles.Tables(0).Rows(i)

                If NavBarControl1.Groups(j).Name = dr.Item("cMenu").ToString Then
                    NavBarControl1.Groups(j).Visible = True
                End If
            Next
        Next
        Return True
    End Function
    Private Sub NavBarControl1_ActiveGroupChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarGroupEventArgs) Handles NavBarControl1.ActiveGroupChanged
        If Me.ssUser.Text = "statusUser" Then
            Exit Sub
        End If
        Me.ssModulo.Text = Me.NavBarControl1.ActiveGroup.Caption
        If Me.NavBarControl1.ActiveGroup.Name <> "" Then
            SaveSetting(Application.ProductName, "Menu", "Modulo", Me.NavBarControl1.ActiveGroup.Name)
        End If
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("¿Desea cerrar el programa ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cerrar el programa") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub nav2Empresa_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Empresa.LinkClicked
        CambiarEmpresa()
    End Sub

    Private Sub CambiarEmpresa()
        If Me.MdiChildren.Length() = 0 Then
            Dim f As New frmCambiarEmpresa
            f.ShowDialog()
        Else
            If MsgBox("Debe cerrar todos los formularios abiertos antes de cambiar de empresa." & Chr(13) & "¿Desea cerrarlos ahora mismo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Atención") = MsgBoxResult.Yes Then
                For i As Integer = 0 To Me.MdiChildren.Length - 1
                    Me.ActiveMdiChild.Close()
                Next
                Dim f As New frmCambiarEmpresa
                f.ShowDialog()
            End If
        End If
        Me.ssEmpresa.Text = EmpresaNombre
    End Sub

    Private Sub MostrarForm(ByVal f As Object)
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub nav2StatusInventario_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2StatusInventario.LinkClicked
        '-- 111: Status Movimiento del Inventario
        'Dim f As New frmTablaDeTablas
        'f.nValor = 111
        'f.ShowDialog()
    End Sub

    Private Sub nav2Producto_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Producto.LinkClicked
        'Me.MostrarForm(My.Forms.frmProducto_Open)
    End Sub

    Private Sub nav2Conceptos_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Conceptos.LinkClicked
        'Me.MostrarForm(My.Forms.frmConcepto_Open)
    End Sub

    Private Sub nav2General_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2General.LinkClicked
        'Dim f As New frmTablaDeTablas
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2CatEmpresa_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2CatEmpresa.LinkClicked
        'Me.MostrarForm(My.Forms.frmEmpresa_Open)
    End Sub

    Private Sub nav2Recalculo_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Recalculo.LinkClicked
        'Me.MostrarForm(My.Forms.frmOpenRecalculaStock)
    End Sub

    'Private Sub nav2Prg_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Prg.LinkClicked
    '    '-- Programa
    '    Me.MostrarForm(My.Forms.frmE1Prg_Open)
    'End Sub

    'Private Sub nav2SubPrg_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2SubPrg.LinkClicked
    '    '-- Sub-Programa
    '    Me.MostrarForm(My.Forms.frmE2SubPrg_Open)
    'End Sub

    'Private Sub nav2Actividad_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Actividad.LinkClicked
    '    Dim f As New frmE3Actividad_Open
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ShowDialog()
    'End Sub

    'Private Sub nav2Dep_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Dep.LinkClicked
    '    Dim f As New frmE4Dep_Open
    '    f.StartPosition = FormStartPosition.CenterScreen
    '    f.ShowDialog()
    'End Sub

    Private Sub nav2Persona_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Persona.LinkClicked
        '-- Proveedores
        'Me.MostrarForm(My.Forms.frmProveedor_Open)
    End Sub

    Private Sub nav2Compra_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Compra.LinkClicked
        '-- Entradas, Compras
        'Me.MostrarForm(My.Forms.frmInvCompra_Open)
    End Sub

    Private Sub nav2Salida_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Salida.LinkClicked
        '-- Me.MostrarForm(My.Forms.frmFactura_Open)
        '-- Me.MostrarForm(My.Forms.frmSalida_Open)
        '-- vnTipoSalida = 11
        vnTipoSalida = 9
        'Me.MostrarForm(My.Forms.frmFactura_Open)
    End Sub

   
    Private Sub nav2Salida2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Salida2.LinkClicked
        '-- Me.MostrarForm(My.Forms.frmFactura_Open)
        '-- Me.MostrarForm(My.Forms.frmSalida_Open)
        vnTipoSalida = 12
        'Me.MostrarForm(My.Forms.frmFactura_Open)
    End Sub

    Private Sub nav2Saldos_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Saldos.LinkClicked
        'Dim f As New frmRepSaldo2
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2RepMovto_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2RepMovto.LinkClicked
        'Dim f As New frmRepMovimientos
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2RepProveedor_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2RepProveedor.LinkClicked
        'Dim f As New frmRepProveedor
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2Usuarios_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Usuarios.LinkClicked
        Using f As New frmUserOpen() With {.StartPosition = FormStartPosition.CenterScreen}
            f.ShowDialog()
        End Using
    End Sub

    Private Sub nav2Inicial_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Inicial.LinkClicked
        '-- Saldos Iniciales
        vnTipoAjuste = 1
        strTitulo = "Ajustes Iniciales"
        'Me.MostrarForm(My.Forms.frmInvAjuste_Open)
    End Sub

    Private Sub nav2AjusteEntrada_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2AjusteEntrada.LinkClicked
        '-- Ajuste de Entrada
        strTitulo = "Ajustes de Entradas"
        vnTipoAjuste = 3
        'Me.MostrarForm(My.Forms.frmInvAjuste_Open)
    End Sub

    Private Sub nav2AjusteSalida_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2AjusteSalida.LinkClicked
        '-- Ajuste de Salida
        strTitulo = "Ajustes de Salidas"
        vnTipoAjuste = 4
        'Me.MostrarForm(My.Forms.frmInvAjuste_Open)
    End Sub

    Private Function funPrintLocal(ByVal strReporte As String, ByVal strFuenteDatos As String)
        'If ds.Tables("Tabla").Rows.Count >= 1 Then
        '--
        Me.Cursor = Cursors.WaitCursor
        bolPrintTitulo = True
        funImprimirNew(strReporte, 0, 0, 0, 0, 0, 0, strFuenteDatos)
        bolPrintTitulo = False
        Me.Cursor = Cursors.Default
        'Else
        'MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        'End If
        Return True
    End Function

    Private Sub nbCat1_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat1.LinkClicked
        strNameReporte = "repInvPro_Clave.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbCat2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat2.LinkClicked
        strNameReporte = "repInvPro_Data.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbCat3_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat3.LinkClicked
        strNameReporte = "repInvPro_GrupoInv.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbCat4_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat4.LinkClicked
        strNameReporte = "repInvPro_GrupoInvEsp.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbCat5_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat5.LinkClicked
        strNameReporte = "repInvPro_GrupoInvEspCal.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbCompra_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCompra.LinkClicked
        'Dim f As New frmRepEntrada2
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbSalidas_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbSalidas.LinkClicked
        'Dim f As New frmRepConsumoDetalle
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbTarjeta_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbTarjeta.LinkClicked
        'Dim f As New frmRepKardex
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbExistencia_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExistencia.LinkClicked
        'Dim f As New frmRepExistencias
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbConsumo_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbConsumo.LinkClicked
        'Dim f As New frmRepConsumoAct
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

   
    Private Sub nbPrecios_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbPrecios.LinkClicked
        'Dim f As New frmRepPrecios
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbOtros_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbOtros.LinkClicked
        Me.nav2RepProveedor.Visible = Not Me.nav2RepProveedor.Visible
        Me.nav2Saldos.Visible = Not Me.nav2Saldos.Visible
        Me.nav2RepMovto.Visible = Not Me.nav2RepMovto.Visible
    End Sub

    Private Sub nbCat0_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat0.LinkClicked
        Me.nbCat1.Visible = Not Me.nbCat1.Visible
        Me.nbCat2.Visible = Not Me.nbCat2.Visible
        Me.nbCat3.Visible = Not Me.nbCat3.Visible
        Me.nbCat4.Visible = Not Me.nbCat4.Visible
        Me.nbCat5.Visible = Not Me.nbCat5.Visible
        Me.nbCat6.Visible = Not Me.nbCat6.Visible
    End Sub

    Private Sub nav2ConsumoFisicoFin_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2ConsumoFisicoFin.LinkClicked
        'Dim f As New frmRepConsumoConDep
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbCat6_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbCat6.LinkClicked
        strNameReporte = "repInvPro_Grupo.rpt"
        strNameFuenteDatos = "v_Inv_Gv_Producto"
        funPrintLocal(strNameReporte, strNameFuenteDatos)
    End Sub

    Private Sub nbConsumo1_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbConsumo1.LinkClicked
        'Dim f As New frmRepConsumoConDep2
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbConsumo2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbConsumo2.LinkClicked
        'Dim f As New frmRepConsumoDepCtab
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbConsumoFisico_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbConsumoFisico.LinkClicked
        Me.nbConsumo1.Visible = Not Me.nbConsumo1.Visible
        Me.nbConsumo2.Visible = Not Me.nbConsumo2.Visible
    End Sub

    Private Sub nbExiste1_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExiste1.LinkClicked
        'Dim f As New frmRepCertExisteFam
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbExiste_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExiste.LinkClicked
        Me.nbExiste1.Visible = Not Me.nbExiste1.Visible
        Me.nbExiste2.Visible = Not Me.nbExiste2.Visible
    End Sub

    Private Sub nbExisteNo1_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExisteNo1.LinkClicked
        'Dim f As New frmRepCertExisteFamNo
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbExisteNo_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExisteNo.LinkClicked
        Me.nbExisteNo1.Visible = Not Me.nbExisteNo1.Visible
        Me.nbExisteNo2.Visible = Not Me.nbExisteNo2.Visible
    End Sub

    Private Sub nav2AnulaSol_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2AnulaSol.LinkClicked
        'vnTipoSalida = 11
        'Me.MostrarForm(My.Forms.frmInvSalida_Open2)
    End Sub

    Private Sub nav2AnulaComp_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2AnulaComp.LinkClicked
        'vnTipoSalida = 12
        'Me.MostrarForm(My.Forms.frmInvSalida_Open2)
    End Sub

    Private Sub nbExiste2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExiste2.LinkClicked
        'Dim f As New frmRepCertExisteItem
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nbExisteNo2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nbExisteNo2.LinkClicked
        'Dim f As New frmRepCertExisteItemNo
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2DisLotes_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2DisLotes.LinkClicked
        'Dim f As New frmLote_Distribution
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub Nav2RecalculoLote_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles Nav2RecalculoLote.LinkClicked
        'Dim f As New frmOpenRecalculaLote
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog()
    End Sub

    Private Sub nav2Orden_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Orden.LinkClicked
        '-- Produccion
        'Me.MostrarForm(My.Forms.frmOrden_Open)
    End Sub

    Private Sub nav2Receta_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Receta.LinkClicked
        'Me.MostrarForm(My.Forms.frmReceta_Open)
    End Sub

    Private Sub nav2Familia_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Familia.LinkClicked
        'Me.MostrarForm(My.Forms.frmFamilia_Open)
    End Sub
End Class

