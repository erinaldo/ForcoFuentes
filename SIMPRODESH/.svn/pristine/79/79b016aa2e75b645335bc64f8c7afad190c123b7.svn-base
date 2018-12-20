Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports System.Threading
Imports ExcelLibrary.SpreadSheet
Imports DevExpress.XtraBars.Alerter
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Module modRutinas
    Public indice As Integer = 0
    Public strUser As String    'Nombre del usuario publico
    Public strSQL As String
    Public strQuery As String
    '-- 
    Public bolFound As Boolean
    Public vcArticulo As String
    Public vnProveedor As Integer

    Public DBConnGlobal As SqlConnection
    Public transaccionGlobal As SqlTransaction
    'Conexión a la Base de Datos
    Public strConexion As String = ""
    Public strServidor As String = ""
    Public strBaseDatos As String = ""
    Public strUserSql As String = ""
    Public strKey As String = ""
    Public strCnxConfianza As String = ""

    Public arrCampos As New ArrayList
    Public arrTipos As New ArrayList
    Public arrValorAnterior As New ArrayList
    Public arrValorActual As New ArrayList

    Public strLlave As String

    Function funFillDataSet(ByVal strSql As String) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter(strSql, DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Function GridViewStyle(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        With gv
            .OptionsCustomization.AllowGroup = False
            .OptionsView.ShowGroupPanel = False
            .OptionsSelection.MultiSelect = True
            .OptionsView.EnableAppearanceOddRow = True

            .OptionsView.ColumnAutoWidth = False
            '.Appearance.OddRow.BackColor = Color.SkyBlue
            .Appearance.OddRow.BackColor = Color.FromArgb(227, 241, 254)
            .OptionsBehavior.Editable = False
            .OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
            .BestFitColumns()
        End With
        Return True
    End Function

    Function funOcultarTodasLasColumnas(ByVal Grid As Object)
        Dim i As Integer
        If TypeOf Grid Is DataGridView Then
            With CType(Grid, DataGridView)
                For i = 0 To .ColumnCount - 1
                    .Columns(i).Visible = False
                Next
            End With
        ElseIf TypeOf Grid Is DevExpress.XtraGrid.Views.Grid.GridView Then
            With CType(Grid, DevExpress.XtraGrid.Views.Grid.GridView)
                For i = 0 To .Columns.Count - 1
                    .Columns(i).Visible = False
                Next
            End With
        ElseIf TypeOf Grid Is DevExpress.XtraTreeList.TreeList Then
            With CType(Grid, DevExpress.XtraTreeList.TreeList)
                For i = 0 To .Columns.Count - 1
                    .Columns(i).Visible = False
                Next
            End With
        End If
        Return True

    End Function

    Function funSetColumna(ByVal Grid As Object, _
                                 ByVal strNombre As String, _
                                 ByVal strHeading As String, _
                                 ByVal intPosicion As Integer, _
                                 ByVal intTamano As Integer, _
                                 Optional ByVal intVisible As Integer = 1, _
                                 Optional ByVal intReadOnly As Integer = 1, _
                                 Optional ByVal intSorteable As Integer = 1, _
                                 Optional ByVal strFormat As String = "", _
                                 Optional ByVal intAlineacion As Integer = 1, _
                                 Optional ByVal intHeaderAlineacion As Integer = 1, _
                                 Optional ByVal formatType As DevExpress.Utils.FormatType = DevExpress.Utils.FormatType.None, _
                                 Optional ByVal frozen As Boolean = False, _
                                   Optional ByVal bEsNumero As Boolean = False, _
                             Optional ByVal bEsCombo As Boolean = False, _
                             Optional ByVal bEsCheck As Boolean = False, _
                             Optional ByVal bEsSuma As Boolean = False, _
                             Optional ByVal bEsGrupo As Boolean = False, _
                             Optional ByVal nColor As Integer = 0, _
                             Optional ByVal nDecimales As Integer = -1, _
                             Optional ByVal bEsPorcentaje As Boolean = False, _
                             Optional ByVal bHayGrupos As Boolean = False)

        'If Grid.GetType.ToString = "System.Windows.Forms.DataGridView" Then
        If TypeOf Grid Is DataGridView Then
            With CType(Grid, DataGridView)
                .Columns(strNombre).Visible = IIf(intVisible = 1, True, False)
                .Columns(strNombre).DisplayIndex = intPosicion
                .Columns(strNombre).Width = intTamano
                .Columns(strNombre).HeaderText = IIf(Len(Trim(strHeading)) = 0, strNombre, strHeading)
                .Columns(strNombre).ReadOnly = IIf(funNull2Val(intReadOnly) = 1, True, False)
                .Columns(strNombre).SortMode = intSorteable
                .Columns(strNombre).DefaultCellStyle.Format = strFormat
                'Celdas
                If intAlineacion = 1 Then
                    .Columns(strNombre).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                ElseIf intAlineacion = 2 Then
                    .Columns(strNombre).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Else
                    .Columns(strNombre).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                .Columns(strNombre).Frozen = frozen
            End With
            'ElseIf Grid.GetType.ToString = "DevExpress.XtraGrid.Views.Grid.GridView" Then
        ElseIf TypeOf Grid Is DevExpress.XtraGrid.Views.Grid.GridView Then
            With CType(Grid, DevExpress.XtraGrid.Views.Grid.GridView)
                .Columns(strNombre).Visible = False 'IIf(intVisible = 1, False, False)
                .Columns(strNombre).VisibleIndex = intPosicion

                Try
                    .Columns(strNombre).Width = intTamano
                Catch ex As Exception

                End Try

                .Columns(strNombre).Caption = IIf(Len(Trim(strHeading)) = 0, strNombre, strHeading)
                .Columns(strNombre).OptionsColumn.ReadOnly = IIf(funNull2Val(intReadOnly) = 1, True, False)
                .Columns(strNombre).SortMode = intSorteable
                .Columns(strNombre).DisplayFormat.FormatType = formatType
                .Columns(strNombre).DisplayFormat.FormatString = strFormat
                .Columns(strNombre).AppearanceCell.Options.UseTextOptions = True
                If intAlineacion = 1 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    '.Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                ElseIf intAlineacion = 2 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    '.Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf intAlineacion = 3 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    '.Columns(strNombre).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                .Columns(strNombre).OptionsColumn.AllowEdit = IIf(intReadOnly = 1, False, True)

            End With


        ElseIf TypeOf Grid Is DevExpress.XtraTreeList.TreeList Then
            With CType(Grid, DevExpress.XtraTreeList.TreeList)
                .Columns(strNombre).Visible = False 'IIf(intVisible = 1, False, False)
                .Columns(strNombre).VisibleIndex = intPosicion

                Try
                    .Columns(strNombre).Width = intTamano
                Catch ex As Exception

                End Try

                .Columns(strNombre).Caption = IIf(Len(Trim(strHeading)) = 0, strNombre, strHeading)
                .Columns(strNombre).OptionsColumn.ReadOnly = IIf(funNull2Val(intReadOnly) = 1, True, False)

                '.Columns(strNombre).SortMode = intSorteable
                '.Columns(strNombre).DisplayFormat.FormatType = formatType
                '.Columns(strNombre).DisplayFormat.FormatString = strFormat

                .Columns(strNombre).AppearanceCell.Options.UseTextOptions = True
                If intAlineacion = 1 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                ElseIf intAlineacion = 2 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                ElseIf intAlineacion = 3 Then
                    .Columns(strNombre).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    .Columns(strNombre).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                .Columns(strNombre).OptionsColumn.AllowEdit = IIf(intReadOnly = 1, False, True)

            End With
        End If
        Return True
    End Function

    Public Function funIndice() As Integer
        indice += 1
        Return indice
    End Function

    Public Function funConexion() As String
        '--
        If Len(Trim(strConexion)) = 0 Then
            '--
            If conexionEKO = False Then
                '--
                strServidor = "192.168.0.28"
                strUserSql = "sa"
                strKey = "M28y05b07"
                strBaseDatos = "LDCOM_SH"
                strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"

                'strServidor = "DEVELOPER"
                'strUserSql = "sa"
                'strKey = "1"
                'strBaseDatos = "LDCOM_MM"
                'strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"

                'strServidor = "192.168.0.25"
                'strUserSql = "sa"
                'strKey = "M28y05b07"
                'strBaseDatos = "LDCOM_PRUEBAS"
                'strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
                '--
            Else
                '--
                strServidor = "192.168.0.20"
                strUserSql = "SA"
                strKey = "M28y05b07"
                strBaseDatos = "LD_ECOMMERCE"
                strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
                '--
            End If
        End If
        '--
        Return strConexion
    End Function

    Function funNull2Val(ByVal strValor As Object) As Double
        If IsDBNull(strValor) Then
            Return 0
        Else
            Dim strTemp = Trim(Convert.ToString(strValor))
            If IsNumeric(strTemp) Then
                Return CDbl(strTemp)
            Else
                Return 0
            End If
        End If
    End Function

    Function funFechaSql(ByVal Fecha As String, _
           Optional ByVal bSoloFecha As Boolean = False) As String
        'Devuelve un string de Fecha en el formato yyyymmdd
        Dim strResultado As String = ""
        If IsDate(Fecha) Then
            strResultado = CDate(Fecha).Year & _
                            Format(CDate(Fecha).Month, "00") & _
                            Format(CDate(Fecha).Day, "00")
            If bSoloFecha = False Then
                strResultado += Space(1) & _
                            Format(CDate(Fecha).Hour, "00") & ":" & _
                            Format(CDate(Fecha).Minute, "00") & ":" & _
                            Format(CDate(Fecha).Second, "00") & "." & _
                            Format(CDate(Fecha).Millisecond, "000")
            End If
        End If
        Return strResultado
    End Function

    Public Function WriteXLSFile(ByVal pFileName As String, ByVal pDataSet As DataSet) As Boolean
        Try
            'This function CreateWorkbook will cause xls file cannot be opened
            'normally when file size below 7Kb, see my work around below
            'ExcelLibrary.DataSetHelper.CreateWorkbook(pFileName, pDataSet)

            'Create a workbook instance
            Dim workbook As Workbook = New Workbook()
            Dim worksheet As Worksheet
            Dim iRow As Integer = 0
            Dim iCol As Integer = 0
            Dim sTemp As String = String.Empty
            Dim dTemp As Double = 0
            Dim iTemp As Integer = 0
            Dim dtTemp As DateTime
            Dim count As Integer = 0
            Dim iTotalRows As Integer = 0
            Dim iSheetCount As Integer = 0

            'Read DataSet
            If Not pDataSet Is Nothing And pDataSet.Tables.Count > 0 Then

                'Traverse DataTable inside the DataSet
                For Each dt As DataTable In pDataSet.Tables

                    'Create a worksheet instance
                    iSheetCount = iSheetCount + 1
                    worksheet = New Worksheet("Sheet " & iSheetCount.ToString())

                    'Write Table Header
                    For Each dc As DataColumn In dt.Columns
                        worksheet.Cells(iRow, iCol) = New Cell(dc.ColumnName)
                        iCol = iCol + 1
                    Next

                    'Write Table Body
                    iRow = 1
                    For Each dr As DataRow In dt.Rows
                        iCol = 0
                        For Each dc As DataColumn In dt.Columns
                            sTemp = dr(dc.ColumnName).ToString()
                            Select Case dc.DataType
                                Case GetType(DateTime)
                                    DateTime.TryParse(sTemp, dtTemp)
                                    '-- Cambiamos el formato original de fecha
                                    worksheet.Cells(iRow, iCol) = New Cell(dtTemp, "YYYY-MM-DD")
                                Case GetType(Double)
                                    Double.TryParse(sTemp, dTemp)
                                    worksheet.Cells(iRow, iCol) = New Cell(dTemp, "#,##0.00")
                                Case Else
                                    worksheet.Cells(iRow, iCol) = New Cell(sTemp)
                            End Select
                            iCol = iCol + 1
                        Next
                        iRow = iRow + 1
                    Next

                    'Attach worksheet to workbook
                    workbook.Worksheets.Add(worksheet)
                    iTotalRows = iTotalRows + iRow
                Next
            End If

            'Bug on Excel Library, min file size must be 7 Kb
            'thus we need to add empty row for safety
            If iTotalRows < 100 Then
                worksheet = New Worksheet("Sheet X")
                count = 1
                Do While count < 100
                    worksheet.Cells(count, 0) = New Cell(" ")
                    count = count + 1
                Loop
                workbook.Worksheets.Add(worksheet)
            End If

            workbook.Save(pFileName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function funCargarComboDX(ByVal lue As Object, _
                        ByVal dtSource As DataTable, _
                        Optional ByVal bVerCodigo As Boolean = False)
        'Para cargar combos...
        If TypeOf lue Is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Then
            'lue.EnterMoveNextControl = True
            With lue
                .DataSource = dtSource
                .DisplayMember = "STRDESCRIPCION"
                .ValueMember = "NID"
                .PopulateColumns()
                .ShowHeader = False
                .DropDownRows = 12
                .NullText = ""

                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).Visible = False
                Next

                .Columns("NID").Visible = bVerCodigo
                .Columns("STRDESCRIPCION").Visible = True
            End With
        ElseIf TypeOf lue Is DevExpress.XtraEditors.LookUpEdit Then
            lue.EnterMoveNextControl = True
            With lue.properties
                .DataSource = dtSource
                .DisplayMember = "STRDESCRIPCION"
                .ValueMember = "NID"
                .NullText = ""
                .ShowHeader = False
                .DropDownRows = 12
                .PopulateColumns()
                '.SearchMode = SearchMode.AutoComplete

                For i As Integer = 0 To lue.Properties.Columns.Count - 1
                    .Columns(i).Visible = False
                Next

                .Columns("NID").Visible = bVerCodigo
                .Columns("STRDESCRIPCION").Visible = True
            End With
        ElseIf TypeOf lue Is DevExpress.XtraEditors.ComboBoxEdit Then
            lue.EnterMoveNextControl = True
            With lue
                .ITEMSOURCE = dtSource
                .DisplayMember = "STRDESCRIPCION"
                .ValueMember = "NID"
                .PopulateColumns()
                .ShowHeader = False
                .DropDownRows = 12
                .NullText = ""
                '.SearchMode = SearchMode.AutoComplete

                For i As Integer = 0 To lue.Properties.Columns.Count - 1
                    .Columns(i).Visible = False
                Next

                .Columns("NID").Visible = bVerCodigo
                .Columns("STRDESCRIPCION").Visible = True
            End With
        ElseIf TypeOf lue Is System.Windows.Forms.ComboBox Then
            With lue
                .datasource = dtSource
                .DisplayMember = "STRDESCRIPCION"
                .ValueMember = "NID"
                '.SelectedValue = 0
            End With


            ' Ame
        ElseIf TypeOf lue Is DevExpress.XtraEditors.CheckedComboBoxEdit Then
            lue.EnterMoveNextControl = True
            With lue.Properties
                .DataSource = dtSource
                .DisplayMember = "STRDESCRIPCION"
                .ValueMember = "NID"
                .DropDownRows = 12
                .NullText = ""
                .SelectAllItemCaption = "Todos.-"
            End With
            lue.EnterMoveNextControl = True
        End If
        Return True
    End Function

    Function funCargarLue(ByRef lue As DevExpress.XtraEditors.LookUpEdit, ByVal strQuery As String)
        'Carga un combo ejecutando internamente la consulta
        With lue.Properties
            .DataSource = funFillDataSet(strQuery).Tables(0)
            .DisplayMember = "strDescripcion"
            .ValueMember = "nCodigo"
            .PopulateColumns()
            lue.EditValue = 0
            .ShowHeader = False
            .DropDownRows = 12

            For i As Integer = 0 To lue.Properties.Columns.Count - 1
                .Columns(i).Visible = False
            Next

            .Columns("nCodigo").Visible = True
            .Columns("strDescripcion").Visible = True
        End With
        '--
        Return True
    End Function

    Public Function funDxGrid(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView, _
                      Optional ByVal nSelectMode As Integer = 1, _
                      Optional ByVal bShowPanel As Boolean = False, _
                      Optional ByVal bEditable As Boolean = False, _
                      Optional ByVal bAddRows As Boolean = False, _
                      Optional ByVal nFilasNuevas As Integer = 1, _
                      Optional ByVal bShowFooter As Boolean = False, _
                      Optional ByVal bHeaderGrande As Boolean = False, _
                      Optional ByVal bEraseRows As Boolean = False, _
                      Optional ByVal bHayGrupos As Boolean = False) As Boolean
        With gv
            .Appearance.OddRow.BackColor = Color.FromArgb(227, 241, 254)
            '.Appearance.OddRow.BackColor = Color.SkyBlue
            .ColumnPanelRowHeight = IIf(bHeaderGrande, 40, -1)
            .OptionsBehavior.AllowAddRows = bAddRows
            If bEraseRows Then
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
            End If
            .OptionsBehavior.Editable = bEditable
            .OptionsCustomization.AllowGroup = False
            .OptionsSelection.MultiSelect = True
            .OptionsView.ColumnAutoWidth = False
            .OptionsView.EnableAppearanceOddRow = True
            .OptionsView.ShowFooter = bShowFooter
            If bShowFooter Then
                .GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
            End If
            .OptionsView.ShowGroupPanel = bShowPanel
            .OptionsView.NewItemRowPosition = IIf(nFilasNuevas = 1, DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom, _
                                            IIf(nFilasNuevas = 2, DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top, _
                                                DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None))

            .OptionsSelection.MultiSelectMode = IIf(nSelectMode = 1, _
                            DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, _
                            DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect)
            '.BestFitColumns()
        End With
        Return True
    End Function

    Public Function GetComputerName() As String
        Dim ComputerName As String
        ComputerName = System.Net.Dns.GetHostName
        Return ComputerName
    End Function

    Function funGetVariablesConexion()
        'Obtiene las variables de la conexión guardadas en el Registro de Windows
        strServidor = GetSetting(Application.ProductName, "Conexion", "sServidor", "")
        strBaseDatos = GetSetting(Application.ProductName, "Conexion", "sBaseDatos", "")
        strUserSql = GetSetting(Application.ProductName, "Conexion", "sUsuario", "")
        strKey = GetSetting(Application.ProductName, "Conexion", "sKey", "")
        strCnxConfianza = GetSetting(Application.ProductName, "Conexion", "sConexionConfianza", "")
        'strFolderReportes = GetSetting(Application.ProductName, "Conexion", "FolderReportes", "")
        funSetStringConexion()

        Return True
    End Function

    Function funSetStringConexion()
        If strServidor.Trim.Length >= 1 And strBaseDatos.Trim.Length >= 1 Then
            strConexion = "server=" & strServidor & _
                          ";Initial Catalog=" & strBaseDatos
            If strCnxConfianza.ToLower = "true" Then
                strConexion += ";integrated security =SSPI;"
            Else
                strConexion += ";User Id=" & strUserSql & _
                               ";Password=" & strKey & ";"
            End If
        End If
        Return True
    End Function

    Function funAlert(strDisplay As String,
                    Optional strDisplay2 As String = "")

        Dim x As AlertInfo = New AlertInfo(strDisplay, strDisplay2)
        frmPrincipal.AlertControl1.Show(frmPrincipal, x)
        Return True
    End Function

    Function funCheckConexion() As Integer
        If strServidor.Trim.Length >= 1 And strBaseDatos.Trim.Length >= 1 Then
            funAlert(strBaseDatos)
            strSQL = "SELECT COUNT(*) FROM Seg_Empresa_x_Usuario"
            Return funNull2Val(funGetValor(strSQL))
            'indice = funNull2Val(funGetValor(strSQL))
            '    Return True
            'Else
            '    Return False
        End If
        Return 0
    End Function
    Function funGetValor(ByVal strQuery As String)
        'Ejecuta una instrucción sql y devuelve un valor escalar
        Try
            Using db As New SqlConnection(funConexion())
                Dim cmd As New SqlCommand(strQuery, db)
                db.Open()
                Return cmd.ExecuteScalar
            End Using
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function AbrirConexionGlobal()
        DBConnGlobal = New SqlConnection(funConexion())
        DBConnGlobal.Open()
        transaccionGlobal = DBConnGlobal.BeginTransaction

        Return True
    End Function

    Function funAddCampo(ByVal strCampo As String,
                        ByVal strValorActual As String,
                        Optional ByVal strValorAnterior As String = "")

        arrCampos.Add(strCampo)
        'arrTipos.Add(xTipo)
        arrValorAnterior.Add(strValorAnterior)
        arrValorActual.Add(strValorActual)
        Return True
    End Function

    Function funParametrosGrabacionTransaccion(
                      ByVal strTabla As String,
                      ByVal strCampoLlave As String,
                      ByVal nTipo As Integer,
                      Optional ByVal nRecno As Integer = 0,
                      Optional ByVal nCabecera As Integer = 0,
                      Optional ByVal nPista As Integer = 1)

        'nTipo = 1-Nuevo, 2-Edición
        Dim I As Integer
        Dim nCambios As Integer
        If nTipo = 1 Then
            nCambios = 1
            strSQL = "INSERT INTO " & strTabla & "("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += arrCampos(I)
            Next
            strSQL += ") VALUES ("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += "'" & Trim(arrValorActual(I)) & "'"
            Next
            strSQL += ") "
            Debug.Print(strSQL)
        Else
            nCambios = 0
            strSQL = "UPDATE " & strTabla & " SET "
            For I = 0 To arrCampos.Count - 1
                If arrValorActual(I) <> arrValorAnterior(I) Then
                    strSQL += IIf(nCambios >= 1, ",", "")
                    strSQL += arrCampos(I) & " = '" & Trim(arrValorActual(I)) & "'"
                    nCambios += 1
                End If
            Next

            'If nRecno <> 0 Then
            '    strSQL += " WHERE " & strCampoLlave & " = " & nRecno
            'Else
            strSQL += " WHERE " & strCampoLlave
            'End If

            Debug.Print(strSQL)
        End If

        If nCambios = 0 Then 'NO HAY NINGUN CAMBIO
        Else
            funRunSQLTransaccion(strSQL)
            If nPista = 1 Then ' Solo graba pista cuando es 1
                If nTipo = 2 Then
                    For I = 0 To arrCampos.Count - 1
                        funSetTrace(strTabla, nRecno, arrCampos(I), Mid(arrValorAnterior(I), 1, 150), Mid(arrValorActual(I), 1, 150), nCabecera)
                    Next
                End If
            End If
        End If

        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
        Return True
    End Function

    Function funRunSQLTransaccion(ByVal strSQL As String)
        Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Sub LimpiarCampos()
        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
    End Sub

    Function funSetTrace(ByVal strTable As String,
                       ByVal strKey As String,
                       ByVal strField As String,
                       ByVal strOldValue As String,
                       ByVal strNewValue As String,
                       Optional ByVal nCabecera As Integer = 0) As Boolean
        'actualiza la pista de auditoría
        If strOldValue <> strNewValue Then
            Dim strSQL = "INSERT INTO TRACE(nTraceRecNo, strUsuario, strTabla, strCampo, " &
                         "strValorAnterior, strValorActual, nCabecera) VALUES ( '" &
                strKey & "', '" &
                strUser & "', '" &
                strTable & "', '" &
                strField & "', '" &
                strOldValue & "', '" &
                strNewValue & "', '" &
                nCabecera & "')"

            'If IsNothing(DBConnGlobal) Then
            '    DBConnGlobal = New SqlConnection(funConexion())
            '    DBConnGlobal.Open()
            'End If
            Try
                If DBConnGlobal.State = ConnectionState.Open Then
                Else
                    DBConnGlobal = New SqlConnection(funConexion())
                    DBConnGlobal.Open()
                End If
            Catch ex As Exception
                DBConnGlobal = New SqlConnection(funConexion())
                DBConnGlobal.Open()
            End Try

            Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
            funSetTrace = True
        End If
    End Function

End Module

