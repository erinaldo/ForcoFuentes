Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Enterprise.InfoStore
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports System.Threading

Module modRutinas
    Public indice As Integer = 0
    Public DBConnGlobal As SqlConnection
    Public transaccionGlobal As SqlTransaction
    Public strNombreUsuario As String
    Public strUser As String    'Nombre del usuario publico
    Public nUserID As Integer   'Id del usuario
    Public strDepto As String   'Nombre del area en la tabla de usuarios
    Public nUser As Integer     'Codigo del usuario en la tabla de usuarios
    Public nDepto As Integer    'Codigo del area en la tabla de usuarios\
    Public intEmpresa As Integer
    Public EmpresaNombre As String
    Public EmpresaLogo As String
    Public ImagenFooter As String
    Public EmpresaMoneda As Integer
    Public strSQL As String
    Public strQuery As String
    Public strLlave As String
    Public strValorAnterior As String
    Public strValorActual As String
    '-- Conexión a la Base de Datos
    Public strConexion As String
    Public strServidor As String
    Public strBaseDatos As String
    Public strUserSql As String
    Public strKey As String
    '--
    Public dsValorAnterior As New DataSet
    Public dblTipoCambio As Double
    Public dblValorMinimo As Double = 0.00001
    '--
    Public alProveedores As New ArrayList
    Public arrCampos As New ArrayList
    Public arrTipos As New ArrayList
    Public arrValorAnterior As New ArrayList
    Public arrValorActual As New ArrayList
    '--
    Public lngRegistros As Long
    Public intStatus As Integer
    Public intReporte As Integer
    Public intProceso As Integer
    '--
    Public strCampo As String
    Public nValor As Integer = 0
    Public strFiltro As String = ""
    Dim filtro As String
    Public varNumSPID As Integer
    Public nPeriodo As Integer
    Public strPeriodo As String
    Public nRecargoPeriodo As Double
    Public nPerRecargo As Double
    '-- 
    Public bolFound As Boolean
    '-- Parametro de Reportes en Formularios
    Public strNameReporte As String
    Public strNameFuenteDatos As String
    '-- 
    Public vcCode As String
    Public vcData As String
    Public vnCantidad As Double  '-- Verificar si puedo convertirla a double, se cambio para decimal 
    Public vnCantidad2 As Double
    Public vnCode As Integer
    Public vnPrecioUnitario As Double
    Public vnDescuento As Double '-- Para desucuento en entradas
    Public bolIVA As Boolean
    Public vnIva As Double
    '-- Para salidas
    Public vnSolicitado As Double '-- se cambio para decimal
    Public vnEntregado As Double '-- se cambio para decimal
    Public vnCosto As Double

    Public vnTipoSalida As Integer
    Public vnTipoAjuste As Integer
    Public bolLogin As Boolean = False  '-- Validacion del forms login
    '-- 
    Public bolPermiteRegFechaAnterior As Boolean = False
    Public bolPermiteBotDebitoDirecto As Boolean = False
    '-- 
    Public dtmFechaLastRecibo As Date
    Public dtmFechaLastRoc As Date
    '-- 
    Public bolCargado As Boolean = False
    '-- 2012-11-13
    Public vnProducto As Integer
    Public vnLote As Integer
    Public strTitulo As String
    '-- 2017-1117
    Public vnTipoCliente As Integer


    Function funModulo(ByVal strUser As String, ByVal strModulo As String)
        strSQL = "SELECT COUNT(*) FROM GEN_USUARIOSMODULOS WHERE STRUSER = '" & strUser & _
                 "' AND STRMODULO = '" & strModulo & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funModulo = IIf(cmd.ExecuteScalar >= 1, True, False)
        db.Close()
    End Function

    Function funTipoCambio(ByVal strFecha As Date)
        'devuelve el tipo de cambio del dia strFecha.
        Dim strSQL = "SELECT VALOR FROM TCDOLAR WHERE FECHA ='" & strFecha & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funTipoCambio = cmd.ExecuteScalar
        db.Close()
    End Function

    Public Function funGetParametro(ByVal strVariable)
        strSQL = "SELECT TVALOR FROM GEN_PARAMETROS WHERE TVARIABLE = '" & _
                strVariable & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funGetParametro = cmd.ExecuteScalar
        db.Close()
    End Function

    Public Function funGetParametroPorEmpresa(ByVal strVariable As String, ByVal nEmpresa As Integer)
        strSQL = "SELECT TVALOR FROM GEN_PARAMETROS WHERE TVARIABLE = '" & _
                strVariable & "' AND nEmpresa = " & nEmpresa
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funGetParametroPorEmpresa = cmd.ExecuteScalar
        db.Close()
    End Function

    'Public Function Login() As Boolean
    '    Dim objLogin As New frmLogin
    '    With objLogin
    '        .ShowDialog()
    '        Login = .Logged
    '    End With
    '    objLogin = Nothing
    'End Function

    Public Function funConexion() As String

        If Len(Trim(strConexion)) = 0 Then
            If File.Exists(Application.StartupPath & "\Server.ini") Then
                Dim ConnectionFile As New System.IO.StreamReader(Application.StartupPath & "\Server.ini")
                strServidor = ConnectionFile.ReadLine.ToString()
                strUserSql = ConnectionFile.ReadLine.ToString()
                strKey = ConnectionFile.ReadLine.ToString()
                strBaseDatos = ConnectionFile.ReadLine.ToString()
                strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
                'strFechaEfectiva = ConnectionFile.ReadLine.ToString()
            Else
                MsgBox("No se encontró el archivo: Server.ini", MsgBoxStyle.Information)
                Return "Nothing"
                strConexion = "Nothing"
                Exit Function
            End If
        End If
        Return strConexion
    End Function

    Function funFechaServerTransaccion()
        Dim strSQL As String = "SELECT GETDATE()"
        Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
        cmd.Transaction = transaccionGlobal
        funFechaServerTransaccion = Convert.ToDateTime(cmd.ExecuteScalar)
    End Function

    Function funFechaServer()
        Dim strSQL As String = "SELECT GETDATE()"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funFechaServer = Convert.ToDateTime(cmd.ExecuteScalar)
        db.Close()
    End Function

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

    Function funValorAnterior(ByVal strRecno As String, _
                                ByVal strTabla As String, _
                                ByVal strCampo As String) As Boolean

        Dim strSQL = "SELECT * FROM " & strTabla & " WHERE " & strCampo & " = " & strRecno
        Dim cmd As New SqlDataAdapter(strSQL, DBConnGlobal)
        dsValorAnterior.Clear()
        cmd.SelectCommand.Connection = DBConnGlobal
        cmd.SelectCommand.Transaction = transaccionGlobal
        cmd.Fill(dsValorAnterior, "Tabla")
    End Function

    Function funGetTrace(ByVal strID As String, _
                        ByVal strTabla As String, _
                        ByVal strTabla2 As String, _
                        ByVal strCampo As String, _
                        ByVal strCampo2 As String, _
                        ByRef ds As DataSet, _
                        Optional ByVal bolEmpresa As Boolean = False) As Boolean
        If strTabla = "Inv_Proveedores" _
            Or strTabla = "Inv_Inventario" _
            Or strTabla = "INV_DESTINOS" _
            Or bolEmpresa Then
            strSQL = "SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo AS Registro " & _
            "FROM " & strTabla & " tbl INNER JOIN Trace T " & _
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
            "WHERE strTabla = '" & strTabla & "' " & _
            "AND tbl." & strCampo & " = " & strID
        Else
            strSQL = "SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo AS Registro " & _
            "FROM " & strTabla & " tbl INNER JOIN Trace T " & _
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
            "WHERE strTabla = '" & strTabla & "' " & _
            "AND tbl." & strCampo & " = " & strID & " " & _
            "AND tbl.nEmpresa = " & intEmpresa '& " " & _
        End If

        If strTabla2 = "" Then
            strSQL += " ORDER BY T.nRecNo, T.dtmFecha"
        Else
            If strTabla2 <> "Ban_SolicitudesCKDetalles" _
            And strTabla2 <> "Cont_ComprobantesDetalle" Then
                strSQL += " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
                "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo  AS Registro " & _
                "FROM " & strTabla2 & " tbl INNER JOIN Trace T " & _
                "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
                "WHERE strTabla = '" & strTabla2 & "' " & _
                "AND tbl." & strCampo & " = " & strID & " " & _
                "AND tbl.nEmpresa = " & intEmpresa & " " & _
                "ORDER BY T.nRecNo, T.dtmFecha"
            Else
                strSQL += " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
                "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo  AS Registro " & _
                "FROM " & strTabla2 & " tbl INNER JOIN Trace T " & _
                "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
                "WHERE strTabla = '" & strTabla2 & "' " & _
                "AND T.nCabecera = " & strID & " " & _
                "AND tbl.nEmpresa = " & intEmpresa & " " & _
                "ORDER BY T.nRecNo, T.dtmFecha"
            End If

        End If

        Debug.Print(vbCr)
        Debug.Print(strSQL)
        Dim DBConn As New SqlConnection(funConexion())
        Dim cmd As New SqlDataAdapter(strSQL, DBConn)
        cmd.Fill(ds, "Tabla")
        DBConn.Close()
        funGetTrace = True
    End Function

    Function funGetTraceUnion(ByVal strID As String, ByVal strTabla As String, ByVal strTabla2 As String, ByVal strCampo As String, ByVal strCampo2 As String, ByRef ds As DataSet) As Boolean

        If strTabla2 = "" Then
            strSQL = strSQL & " ORDER BY T.nRecNo, T.dtmFecha"
        Else
            strSQL = strSQL & " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo " & _
            "FROM " & strTabla2 & " tbl INNER JOIN Trace T " & _
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
            "WHERE strTabla = '" & strTabla2 & "' " & _
            "AND tbl." & strCampo & " = " & strID & " " & _
            "AND tbl.nEmpresa = " & intEmpresa & " " & _
            "ORDER BY T.nRecNo, T.dtmFecha"
        End If

        Dim DBConn As SqlConnection
        DBConn = New SqlConnection(funConexion())
        Dim cmd As New SqlDataAdapter(strSQL, DBConn)
        cmd.Fill(ds, "Tabla")
        DBConn.Close()
        funGetTraceUnion = True
    End Function

    'Public Function TablaDatosGrupos(ByVal nTabla As Integer, ByVal nTabla1 As Integer, ByVal nID As Integer) As DataSet
    '    Dim ds As New DataSet()
    '    Dim DBConn As New SqlConnection(funConexion())
    '    Dim DBCommand As New SqlDataAdapter("spTablaDatosGrupos", DBConn)
    '    DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

    '    Dim _nTabla As New SqlParameter("@nTabla", SqlDbType.Int)
    '    _nTabla.Value = nTabla
    '    DBCommand.SelectCommand.Parameters.Add(_nTabla)

    '    Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
    '    _nEmpresa.Value = intEmpresa
    '    DBCommand.SelectCommand.Parameters.Add(_nEmpresa)

    '    Dim _nTabla1 As New SqlParameter("@nTabla1", SqlDbType.Int)
    '    _nTabla1.Value = nTabla1
    '    DBCommand.SelectCommand.Parameters.Add(_nTabla1)

    '    Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
    '    _nID.Value = nID
    '    DBCommand.SelectCommand.Parameters.Add(_nID)

    '    DBCommand.Fill(ds, "Tabla")
    '    DBConn.Close()
    '    Return ds
    'End Function

    'Public Function Transacciones(ByVal nTipo As Integer) As DataSet
    '    Dim ds As New DataSet()
    '    Dim DBConn As New SqlConnection(funConexion())
    '    Dim DBCommand As New SqlDataAdapter("spTransacciones", DBConn)
    '    DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

    '    Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
    '    _nTipo.Value = nTipo
    '    DBCommand.SelectCommand.Parameters.Add(_nTipo)

    '    Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
    '    _nEmpresa.Value = intEmpresa
    '    DBCommand.SelectCommand.Parameters.Add(_nEmpresa)

    '    DBCommand.Fill(ds, "Tabla")
    '    DBConn.Close()
    '    Return ds
    'End Function

    'Public Function TablaDatos(ByVal nTabla As Integer) As DataSet
    '    Dim ds As New DataSet()
    '    Dim DBConn As New SqlConnection(funConexion())
    '    Dim DBCommand As New SqlDataAdapter("spTablaDatos", DBConn)
    '    DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

    '    Dim _nTabla As New SqlParameter("@nTabla", SqlDbType.Int)
    '    _nTabla.Value = nTabla
    '    DBCommand.SelectCommand.Parameters.Add(_nTabla)

    '    Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
    '    _nEmpresa.Value = intEmpresa
    '    DBCommand.SelectCommand.Parameters.Add(_nEmpresa)

    '    DBCommand.Fill(ds, "Tabla")
    '    DBConn.Close()
    '    Return ds
    'End Function

    Public Sub DataGridRowStyle(ByRef dgv As DataGridView)
        With dgv
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(227, 241, 254) 'Color.FromArgb(236, 243, 246) 'Color.OldLace
            .RowTemplate.Height = 15
            .BackgroundColor = Color.FromArgb(227, 241, 254)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
            .GridColor = Color.SteelBlue
            .BorderStyle = BorderStyle.Fixed3D

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False

            .RowTemplate.Resizable = DataGridViewTriState.False
            .RowHeadersWidth = 25
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        End With
    End Sub

    Public Sub DataGridRowStyle1(ByRef dgv As DataGridView)
        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
        'dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(224, 239, 224) '.Lavender
        dgv.BackgroundColor = Color.WhiteSmoke
    End Sub

    Public Function ColorFondoFormulario(ByRef Form As Form) As Color
        Form.BackColor = Color.FromArgb(227, 241, 254)

        For i As Integer = 0 To Form.Controls.Count - 1
            If TypeOf Form.Controls(i) Is StatusStrip Then
                CType(Form.Controls(i), StatusStrip).BackColor = Color.FromArgb(227, 241, 254)
            End If
        Next

        Return Form.BackColor
    End Function

    Function funFileName(ByVal strNombre As String) As String
        Dim strNombre2 As String = Mid(strNombre, InStrRev(strNombre, "\") + 1)
        Return strNombre2
    End Function

    Public Sub ParametrosAdd(ByVal nEmpresa As Integer, _
                        ByVal strVariable As String, _
                        ByVal strValor As String)
        Dim cmd As SqlCommand = New SqlCommand("spParametrosAdd", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = nEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _strVariable As New SqlParameter("@strVariable", SqlDbType.NVarChar)
        _strVariable.Value = strVariable
        cmd.Parameters.Add(_strVariable)

        Dim _strValor As New SqlParameter("@strValor", SqlDbType.NVarChar)
        _strValor.Value = strValor
        cmd.Parameters.Add(_strValor)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
    End Sub

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Function SoloNumerosEnteros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosEnteros = 0
        Else
            SoloNumerosEnteros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosEnteros = Keyascii
            Case 13
                SoloNumerosEnteros = Keyascii
        End Select
    End Function

    Function funMakeFileName(ByVal strNombre As String)
        Dim strFileName As String
        strFileName = strUser & "_" & Microsoft.VisualBasic.DateAndTime.Timer & "_" & strNombre
        Return strFileName
    End Function

    Function funCleanTempFiles()
        On Error Resume Next
        strSQL = Application.StartupPath & "\DatosXml\" & strUser & "*.xml"
        Kill(strSQL)
        Return True
    End Function

    Function funSqlParametro(ByVal strVariable As String, _
                ByVal varValor As String, _
                ByVal varTipo As SqlDbType, _
                ByVal cmd As Object, _
                ByVal intCmd As Integer)

        Dim varParametro As New SqlParameter(strVariable, varTipo)
        varParametro.Value = varValor

        '1=SqlDataAdapter, 2=SqlCommand
        If intCmd = 1 Then
            CType(cmd, SqlDataAdapter).SelectCommand.Parameters.Add(varParametro)
        Else
            CType(cmd, SqlCommand).Parameters.Add(varParametro)
        End If

        Return True
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

    Function funNull2Date(ByVal strFecha) As String
        If IsDBNull(strFecha) Then
            Return ""
        Else
            If Len(Trim(CStr(strFecha))) = 0 Then
                Return ""
            ElseIf IsDate(strFecha) Then
                'MsgBox(Convert.ToString(CDate(strFecha).Date))
                Return FormatDateTime(CDate(strFecha).Date, DateFormat.ShortDate)
            Else
                Return ""
            End If
        End If
    End Function

    Function funNull2Boolean(ByVal strValor) As Boolean
        If IsDBNull(strValor) Then
            Return False
        Else
            Return CBool(strValor)
        End If
    End Function

    Function funRunSQL(ByVal strSQL As String)
        'Ejecuta bien una instrucciones INSERT y/o UPDATE, las otras hay que revisar
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        cmd.ExecuteNonQuery()
        db.Close()
        Return True
    End Function

    Function funAddCampo(ByVal strCampo As String, _
                         ByVal strValorActual As String, _
                         Optional ByVal strValorAnterior As String = "")

        arrCampos.Add(strCampo)
        'arrTipos.Add(xTipo)
        arrValorAnterior.Add(strValorAnterior)
        arrValorActual.Add(strValorActual)
        Return True
    End Function

    Function funParametrosGrabacion(ByVal strTabla As String, _
                                    ByVal strCampoLlave As String, _
                                    ByVal nTipo As Integer, _
                                    Optional ByVal nRecno As Integer = 0, _
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
            strSQL += " WHERE " & strCampoLlave & " = " & nRecno
            Debug.Print(strSQL)
        End If
        If nCambios >= 1 Then
            funRunSQL(strSQL)
            If nPista = 1 Then
                For I = 0 To arrCampos.Count - 1
                    If nRecno > 0 Then
                        funSetTrace(strTabla, nRecno, arrCampos(I), arrValorAnterior(I), arrValorActual(I))
                    End If
                Next
            End If
        End If

        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
        Return True
    End Function

    Function funFillDataSet(ByVal strSql As String) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter(strSql, DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Function funFillDataSetTransaccion(ByVal strSql As String) As DataSet
        Dim DBCommand As SqlDataAdapter
        Dim ds As New DataSet()

        DBCommand = New SqlDataAdapter(strSql, DBConnGlobal)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.SelectCommand.Connection = DBConnGlobal
        DBCommand.SelectCommand.Transaction = transaccionGlobal
        DBCommand.Fill(ds, "Tabla")
        Return ds
    End Function

    Function AddCheckColumn(ByVal Grid As DataGridView, _
                               ByVal strNombre As String, _
                               ByVal strHeader As String, _
                               ByVal intPosicion As Integer)

        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .HeaderText = strHeader
            .Name = strNombre
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
        End With
        Grid.Columns.Insert(intPosicion, column)
        Return True
    End Function

    Function funParametrosGrabacionTransaccion( _
                        ByVal strTabla As String, _
                        ByVal strCampoLlave As String, _
                        ByVal nTipo As Integer, _
                        Optional ByVal nRecno As Integer = 0, _
                        Optional ByVal nCabecera As Integer = 0, _
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

    Function funGetValorTransaccion(ByVal strQuery As String)
        'Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strQuery, DBConnGlobal)
        'db.Open()

        'DBCommand.SelectCommand.Connection = DBConnGlobal
        'DBCommand.SelectCommand.Transaction = transaccionGlobal
        cmd.Transaction = transaccionGlobal
        funGetValorTransaccion = cmd.ExecuteScalar
        'db.Close()
    End Function

    Function funGetValor(ByVal strQuery As String)
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strQuery, db)
        db.Open()
        funGetValor = cmd.ExecuteScalar
        db.Close()
    End Function

    Public Sub LimpiarCampos()
        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
    End Sub

    Public Function IP() As String
        Dim Host As String

        Host = Dns.GetHostName

        Dim IPs As IPHostEntry = Dns.GetHostEntry(Host)
        'Dim Direcciones As IPAddress() = IPs.AddressList
        Return IPs.HostName 'Direcciones(0).ToString()

    End Function

    Public Function funIndice() As Integer
        indice += 1
        Return indice
    End Function

    Function funTipoCambioTwo(ByVal dtm As DateTime, ByVal Moneda As Integer) As Double
        Dim strSQL As String
        If Moneda = 2 Then
            dtm = FormatDateTime(dtm, DateFormat.ShortDate)
            strSQL = "SELECT VALOR FROM TCDOLAR WHERE FECHA = '" & dtm & "'"
            funTipoCambioTwo = funGetValor(strSQL)
        ElseIf Moneda = 3 Then
            dtm = FormatDateTime(dtm, DateFormat.ShortDate)
            strSQL = "SELECT EUROS FROM TCDOLAR WHERE FECHA = '" & dtm & "'"
            funTipoCambioTwo = funNull2Val(funGetValor(strSQL))
        End If
        Return funTipoCambioTwo
    End Function
    Public Function AbrirConexionGlobal()
        DBConnGlobal = New SqlConnection(funConexion())
        DBConnGlobal.Open()
        transaccionGlobal = DBConnGlobal.BeginTransaction

        Return True
    End Function

    Function funSPID()
        '- Retorna el ID del proceso que se esta ejecutando, lo usaremos para identificar
        '-  la session abierta por el usuario
        Dim strSQL As String = "SELECT @@SPID"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funSPID = cmd.ExecuteScalar
        db.Close()
    End Function

    Function funFechaEfectiva(ByVal strFecha As String)
        'Devuelve la fecha efectiva de una fecha
        Dim strResultado As String

        strQuery = "SELECT ISNULL(MAX(STRDATA), '') FROM GEN_CURSO_LECTIVO WHERE NEMPRESA = " & intEmpresa & _
                   " AND '" & strFecha & "' >= CONVERT(DATETIME, CONVERT(NVARCHAR(10), DTMINICIO, 103)) " & _
                   " AND  '" & strFecha & "' <= CONVERT(DATETIME, CONVERT(NVARCHAR(10), DTMFINAL, 103)) "

        strResultado = funGetValor(strQuery)

        Return IIf(Len(Trim(strResultado)) >= 1, strResultado, "")

    End Function

    Function funGetTablaDeTablas(ByVal nTabla As Integer, _
                              Optional ByVal nGrupo As Integer = 0, _
                              Optional ByVal bFiltrarStatus As Boolean = True, _
                              Optional ByVal bRecnoEsClave As Boolean = False) As DataTable

        If bRecnoEsClave Then
            strSQL = " SELECT NRECNO AS NID, NCODTBL, NGRUPO, STRDESCRIPCION, STRCONCEPTO" & _
                       " FROM TABLADETABLAS" & _
                       " WHERE NID >= 1 " & _
                       " AND NCODTBL = " & nTabla & _
                       " AND NEMPRESA = " & intEmpresa
        Else
            'DEFAULT
            strSQL = " SELECT NRECNO, NCODTBL, NID, NGRUPO, STRDESCRIPCION, STRCONCEPTO" & _
                       " FROM TABLADETABLAS" & _
                       " WHERE NID >= 1 " & _
                       " AND NCODTBL = " & nTabla & _
                       " AND NEMPRESA = " & intEmpresa
        End If
        If bFiltrarStatus Then
            strSQL += " AND NESTATUS = 1"
        End If
        If nGrupo >= 1 Then
            strSQL += " AND NGRUPO = " & nGrupo
        End If
        strSQL += " ORDER BY STRDESCRIPCION"
        Dim dtTabla As DataTable = funFillDataSet(strSQL).Tables(0)
        Return dtTabla
    End Function

    Function funCTxt(ByVal stReplace As String) As String
        '-- Limpia apostrofes de un TextBox
        Dim StNewString As String
        StNewString = Replace(stReplace, "'", "''")
        Return StNewString
    End Function

    Public Function funFechaSql(ByVal Fecha As String, Optional ByVal bSoloFecha As Boolean = False) As String
        'Devuelve un string de Fecha en el formato yyyymmdd
        Dim strResultado As String = ""
        If IsDate(Fecha) Then
            strResultado = CDate(Fecha).Year &
                            Format(CDate(Fecha).Month, "00") &
                            Format(CDate(Fecha).Day, "00")
            If bSoloFecha = False Then
                strResultado += Space(1) &
                            Format(CDate(Fecha).Hour, "00") & ":" &
                            Format(CDate(Fecha).Minute, "00") & ":" &
                            Format(CDate(Fecha).Second, "00") & "." &
                            Format(CDate(Fecha).Millisecond, "000")
            End If
        End If
        Return strResultado
    End Function

End Module
