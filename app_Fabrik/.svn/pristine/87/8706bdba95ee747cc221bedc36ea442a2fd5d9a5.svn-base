

' The SqlHelper class is intended to encapsulate high performance, scalable best practices for 
' common uses of SqlClient.

' ===============================================================================
' Release history
' VERSION	DESCRIPTION
'   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
'
' ===============================================================================

Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
'Imports System.



Public NotInheritable Class SqlHelper
    

#Region "Elaborado para Promitools"

    Public Shared Sub ExportToExcel(ByVal pDataTable As DataTable, ByVal pFileName As String, ByVal pFields As Hashtable, Optional ByVal pIncluirEncabezado As Boolean = True)
        'Exporta el contenido de un Datatable a Excel.
        'Los Fields de la tabla que se van a exportar se deben mandar dentro de un hashtable

        Dim R As DataRow
        'Dim C As DataColumn
        Dim i As Integer
        Dim sCadena As String = Nothing
        Dim sTmp As String
        Dim Encod As New System.Text.UnicodeEncoding
        Dim FDatos As New StreamWriter(pFileName, False, Encod)



        'Primero se exporta el encabezado
        If pIncluirEncabezado Then
            For i = 0 To pDataTable.Columns.Count - 1
                If pFields.ContainsKey(pDataTable.Columns(i).ColumnName) Then
                    sTmp = pFields(pDataTable.Columns(i).ColumnName)
                    sCadena += CStr(sTmp.Replace(vbTab, " ")) & vbTab
                End If
            Next
            FDatos.WriteLine(sCadena)
        End If
        For Each R In pDataTable.Rows
            sCadena = ""
            For i = 0 To pDataTable.Columns.Count - 1
                If pFields.Contains(pDataTable.Columns(i).ColumnName) Then
                    sTmp = IIf(IsDBNull(R(pDataTable.Columns(i).ColumnName)), "", R(pDataTable.Columns(i).ColumnName))
                    sCadena += CStr(sTmp.Replace(vbTab, " ")) & vbTab
                End If
            Next
            FDatos.WriteLine(sCadena)
        Next
        FDatos.Flush()
        FDatos.Close()
        FDatos = Nothing
    End Sub

    Public Shared Function GetCommaSeparatedFromArray(ByVal pArray() As Long, ByVal pUseCuoted As Boolean) As String
        ' esta funcion regresa una cadena que contiene todos los valores table.Field separados por coma
        Dim i As Integer
        Dim s As String = ""

        For i = 0 To pArray.Length - 1
            s = s & IIf(pUseCuoted, """", "") & pArray(i) & IIf(pUseCuoted, """", "") & ","
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Shared Function GetCommaSeparatedFromArray(ByVal pArray() As String, ByVal pUseCuoted As Boolean) As String
        ' esta funcion regresa una cadena que contiene todos los valores table.Field separados por coma
        Dim i As Integer
        Dim s As String = ""

        For i = 0 To pArray.Length - 1
            s = s & IIf(pUseCuoted, """", "") & pArray(i) & IIf(pUseCuoted, """", "") & ","
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Shared Function GetCommaSeparatedFromArray(ByVal pArray() As Integer, ByVal pUseCuoted As Boolean) As String
        ' esta funcion regresa una cadena que contiene todos los valores table.Field separados por coma
        Dim i As Integer
        Dim s As String = ""

        For i = 0 To pArray.Length - 1
            s = s & IIf(pUseCuoted, """", "") & pArray(i) & IIf(pUseCuoted, """", "") & ","
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Shared Function GetCommaSeparatedField(ByVal pTable As DataTable, ByVal pField As String, ByVal pUseCuoted As Boolean) As String
        ' esta funcion regresa una cadena que contiene todos los valores table.Field separados por coma
        Dim i As Integer
        Dim s As String = ""

        For i = 0 To pTable.Rows.Count - 1
            s = s & IIf(pUseCuoted, """", "") & pTable.Rows(i).Item(pField) & IIf(pUseCuoted, """", "") & ","
        Next
        Return s.Substring(1, s.Length - 1)
    End Function

    Public Shared Function GetCommaSeparatedField(ByVal pDataReader As SqlDataReader, ByVal pField As String, ByVal pUseCuoted As Boolean) As String
        ' A partir de un sqlDataReader genera una cadena de valores separados por coma
        Dim i As Integer = Nothing
        Dim s As String = ""

        While pDataReader.Read
            s = s & IIf(pUseCuoted, """", "") & pDataReader.Item(pField) & IIf(pUseCuoted, """", "") & ","
        End While


        Return s.Substring(1, s.Length - 1)
    End Function

#End Region

#Region "Elaborado para Promitools"

    Public Class PROMITOOLSField
        Private _FieldName As String
        Private _FielValue As Object

        Public Sub New(ByVal pFieldName As String)
            _FieldName = pFieldName
            _FielValue = DBNull.Value
        End Sub

        Public Sub New(ByVal pFieldName As String, ByVal pFielValue As Object)
            _FieldName = pFieldName
            _FielValue = pFielValue
        End Sub

        Public Property FieldName() As String
            Get
                Return (_FieldName)
            End Get
            Set(ByVal Value As String)
                _FieldName = Value
            End Set
        End Property

        Public Property FielValue() As Object
            Get
                Return (_FielValue)
            End Get
            Set(ByVal Value As Object)
                _FielValue = Value
            End Set
        End Property

        Public ReadOnly Property IsNull() As Boolean
            Get
                Return IsDBNull(_FielValue)
            End Get
        End Property
    End Class

    Public Class PROMITOOLSFieldCollection
        Inherits System.Collections.CollectionBase

        Public Sub Add(ByVal aField As PROMITOOLSField)
            List.Add(aField)
        End Sub

        Public Sub Remove(ByVal index As Integer)
            If index > Count - 1 Or index < 0 Then
                Throw New Exception("Indice inválido en PromiFieldCollection.")
            Else
                List.RemoveAt(index)
            End If
        End Sub

        Default Public Property Item(ByVal index As Integer) As PROMITOOLSField
            Get
                Return CType(List.Item(index), PROMITOOLSField)
            End Get
            Set(ByVal Value As PROMITOOLSField)
                List.Item(index) = Value
            End Set
        End Property

        Default Public Property Item(ByVal key As String) As PROMITOOLSField

            Get
                Dim vPROMITOOLSField As PROMITOOLSField
                For Each vPROMITOOLSField In List
                    If vPROMITOOLSField.FieldName = key Then
                        Return vPROMITOOLSField
                    End If
                Next
                Return CType(List.Item(key), PROMITOOLSField)
            End Get

            Set(ByVal Value As PROMITOOLSField)
                Dim idx As Integer

                For idx = 0 To List.Count - 1
                    If CType(List.Item(idx), PROMITOOLSField).FieldName = key Then
                        List.Item(idx) = Value
                    End If
                Next
            End Set
        End Property
    End Class

#End Region

#Region "private utility methods & constructors"
    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new SqlHelper()".
    Private Sub New()
    End Sub ' New

    Private Shared Function GetConnectString() As String
        Dim s As String = funConexion()
        'Dim s As String = AppSettings.Item("ConnectString")
        'Dim s As String = System.Configuration.ConfigurationManager.AppSettings.Item("Data Source=PERSONAL\PENTIUM;Initial Catalog=PROMITOOLS;Integrated Security=True;Connect Timeout=5")
        'Dim s As String = Settings.PROMITOOLSConnectionString
        Return s
    End Function


    ' This method is used to attach array of SqlParameters to a SqlCommand.
    ' This method will assign a value of DbNull to any parameter with a direction of
    ' InputOutput and a value of null.  
    ' This behavior will prevent default values from being used, but
    ' this will be the less common case than an intended pure output parameter (derived as InputOutput)
    ' where the user provided no input value.
    ' Parameters:
    ' -command - The command to which the parameters will be added
    ' -commandParameters - an array of SqlParameters to be added to command
    Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
        If (command Is Nothing) Then Throw New ArgumentNullException("command")
        If (Not commandParameters Is Nothing) Then
            Dim p As SqlParameter
            For Each p In commandParameters
                If (Not p Is Nothing) Then
                    ' Check for derived output value with no value assigned
                    If (p.Direction = ParameterDirection.InputOutput OrElse p.Direction = ParameterDirection.Input) AndAlso p.Value Is Nothing Then
                        p.Value = DBNull.Value
                    End If
                    command.Parameters.Add(p)
                End If
            Next p
        End If
    End Sub ' AttachParameters

    ' This method assigns dataRow column values to an array of SqlParameters.
    ' Parameters:
    ' -commandParameters: Array of SqlParameters to be assigned values
    ' -dataRow: the dataRow used to hold the stored procedure' s parameter values
    Private Overloads Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal dataRow As DataRow)

        If commandParameters Is Nothing OrElse dataRow Is Nothing Then
            ' Do nothing if we get no data    
            Exit Sub
        End If

        ' Set the parameters values
        Dim commandParameter As SqlParameter
        Dim i As Integer
        For Each commandParameter In commandParameters
            ' Check the parameter name
            If (commandParameter.ParameterName Is Nothing OrElse commandParameter.ParameterName.Length <= 1) Then
                Throw New Exception(String.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: ' {1}' .", i, commandParameter.ParameterName))
            End If
            If dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) <> -1 Then
                commandParameter.Value = dataRow(commandParameter.ParameterName.Substring(1))
            End If
            i = i + 1
        Next
    End Sub

    ' This method assigns an array of values to an array of SqlParameters.
    ' Parameters:
    ' -commandParameters - array of SqlParameters to be assigned values
    ' -array of objects holding the values to be assigned
    Private Overloads Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

        Dim i As Integer
        Dim j As Integer

        If (commandParameters Is Nothing) AndAlso (parameterValues Is Nothing) Then
            ' Do nothing if we get no data
            Return
        End If

        ' We must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        ' Value array
        j = commandParameters.Length - 1
        For i = 0 To j
            ' If the current array value derives from IDbDataParameter, then assign its Value property
            If TypeOf parameterValues(i) Is IDbDataParameter Then
                Dim paramInstance As IDbDataParameter = CType(parameterValues(i), IDbDataParameter)
                If (paramInstance.Value Is Nothing) Then
                    commandParameters(i).Value = DBNull.Value
                Else
                    commandParameters(i).Value = paramInstance.Value
                End If
            ElseIf (parameterValues(i) Is Nothing) Then
                commandParameters(i).Value = DBNull.Value
            Else
                commandParameters(i).Value = parameterValues(i)
            End If
        Next
    End Sub ' AssignParameterValues

    ' This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    ' to the provided command.
    ' Parameters:
    ' -command - the SqlCommand to be prepared
    ' -connection - a valid SqlConnection, on which to execute this command
    ' -transaction - a valid SqlTransaction, or ' null' 
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' -commandParameters - an array of SqlParameters to be associated with the command or ' null' if no parameters are required
    Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                      ByVal connection As SqlConnection, _
                                      ByVal transaction As SqlTransaction, _
                                      ByVal commandType As CommandType, _
                                      ByVal commandText As String, _
                                      ByVal commandParameters() As SqlParameter, ByRef mustCloseConnection As Boolean)

        If (command Is Nothing) Then Throw New ArgumentNullException("command")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        ' If the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            connection.Open()
            mustCloseConnection = True
        Else
            mustCloseConnection = False
        End If

        ' Associate the connection with the command
        command.Connection = connection

        ' Set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        ' If we were provided a transaction, assign it.
        If Not (transaction Is Nothing) Then
            If transaction.Connection Is Nothing Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
            command.Transaction = transaction
        End If

        ' Set the command type
        command.CommandType = commandType

        ' Attach the command parameters if they are provided
        If Not (commandParameters Is Nothing) Then
            AttachParameters(command, commandParameters)
        End If
        command.CommandTimeout = 0 'Infinito
        Return
    End Sub ' PrepareCommand



#End Region

#Region "ExecuteNonQuery"

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteNonQuery(ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As Integer
        'pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(GetConnectString(), commandType, commandText, CType(Nothing, SqlParameter()))
    End Function 'ExecuteNonQuery

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteNonQuery(ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer
        'create & open a SqlConnection, and dispose of it after we are done.
        Dim cn As New SqlConnection
        Try
            cn = New SqlConnection(GetConnectString())
            'cn = New SqlConnection(Settings.PROMITOOLSConnectionString)
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteNonQuery(cn, commandType, commandText, commandParameters)
            cn.Close()
        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteNonQuery

    'Overload para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteNonQuery(ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        Dim commandParameters As SqlParameter()
        Dim sCnnStr As String = GetConnectString()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

            commandParameters = SqlHelperParameterCache.GetSpParameterSet(sCnnStr, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(sCnnStr, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteNonQuery(sCnnStr, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    '  Dim result As Integer =  ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders")
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' Returns: An int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim result As Integer = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' -commandParameters - an array of SqlParamters used to execute the command
    ' Returns: An int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As New SqlConnection
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteNonQuery(connection, commandType, commandText, commandParameters)
            connection.Close()
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteNonQuery

    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    '  Dim result As Integer = ExecuteNonQuery(connString, "PublishOrders", 24, 36)
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -spName - the name of the stored procedure
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    ' Returns: An int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    ' Dim result As Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders")
    ' Parameters:
    ' -connection - a valid SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(connection, commandType, commandText, CType(Nothing, SqlParameter()))

    End Function ' ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    '  Dim result As Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An int representing the number of rows affected by the command 
    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Integer
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        ' Finally, execute the command
        Try
            retval = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        If (mustCloseConnection) Then
            connection.Close()
            connection.Dispose()
        End If

        Return retval
    End Function ' ExecuteNonQuery

    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    '  Dim result As integer = ExecuteNonQuery(conn, "PublishOrders", 24, 36)
    ' Parameters:
    ' -connection - a valid SqlConnection
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An int representing the number of rows affected by the command 
    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction.
    ' e.g.:  
    '  Dim result As Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders")
    ' Parameters:
    ' -transaction - a valid SqlTransaction associated with the connection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An int representing the number of rows affected by the command 
    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteNonQuery

    ' Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    ' Dim result As Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An int representing the number of rows affected by the command 
    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Integer
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Finally, execute the command
        retval = cmd.ExecuteNonQuery()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval
    End Function ' ExecuteNonQuery

    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlTransaction 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim result As Integer = SqlHelper.ExecuteNonQuery(trans, "PublishOrders", 24, 36)
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An int representing the number of rows affected by the command 
    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteNonQuery





#End Region

#Region "ExecuteDataset"

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteDataset(ByVal commandType As CommandType, _
                                                        ByVal commandText As String) As DataSet
        'pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(GetConnectString(), commandType, commandText, CType(Nothing, SqlParameter()))
    End Function 'ExecuteDataset

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteDataset(ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        'create & open a SqlConnection, and dispose of it after we are done.
        Dim cn As New SqlConnection(GetConnectString())
        Try
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(cn, commandType, commandText, commandParameters)
            cn.Close()
        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteDataset

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteDataset(ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        Dim commandParameters As SqlParameter()
        Dim sCnnStr As String = GetConnectString()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(sCnnStr, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteDataset(sCnnStr, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteDataset(sCnnStr, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    ' Dim ds As DataSet = SqlHelper.ExecuteDataset("", commandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' -commandParameters - an array of SqlParamters used to execute the command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(connection, commandType, commandText, commandParameters)
            connection.Close()
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteDataset

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim ds As Dataset= ExecuteDataset(connString, "GetOrders", 24, 36)
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -spName - the name of the stored procedure
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -connection - a valid SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet

        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection - a valid SqlConnection
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' -commandParameters - an array of SqlParamters used to execute the command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim dataAdatpter As SqlDataAdapter
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        dataAdatpter = New SqlDataAdapter(cmd)
        Try

            ' Create the DataAdapter & DataSet


            ' Fill the DataSet using default values for DataTable names, etc
            dataAdatpter.Fill(ds)

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()
        Catch ex As Exception
            'MsgBox(ex.Message)

        Finally
            If (Not dataAdatpter Is Nothing) Then dataAdatpter.Dispose()
        End Try
        If (mustCloseConnection) Then
            connection.Close()
            connection.Dispose()
        End If

        ' Return the dataset
        Return ds
    End Function ' ExecuteDataset

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(conn, "GetOrders", 24, 36)
    ' Parameters:
    ' -connection - a valid SqlConnection
    ' -spName - the name of the stored procedure
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders")
    ' Parameters
    ' -transaction - a valid SqlTransaction
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters
    ' -transaction - a valid SqlTransaction 
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command
    ' -commandParameters - an array of SqlParamters used to execute the command
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim dataAdatpter As SqlDataAdapter
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)
        dataAdatpter = New SqlDataAdapter(cmd)

        Try
            ' Create the DataAdapter & DataSet
            
            ' Fill the DataSet using default values for DataTable names, etc
            dataAdatpter.Fill(ds)

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()
        Finally
            If (Not dataAdatpter Is Nothing) Then dataAdatpter.Dispose()
        End Try

        ' Return the dataset
        Return ds

    End Function ' ExecuteDataset

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified
    ' SqlTransaction using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim ds As Dataset = ExecuteDataset(trans, "GetOrders", 24, 36)
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -spName - the name of the stored procedure
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteDataset

#End Region

#Region "ExecuteReader"
    ' this enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
    ' we can set the appropriate CommandBehavior when calling ExecuteReader()
    Private Enum SqlConnectionOwnership
        ' Connection is owned and managed by SqlHelper
        Internal
        ' Connection is owned and managed by the caller
        [External]

    End Enum ' SqlConnectionOwnership



    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteReader(ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader
        'pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(GetConnectString(), commandType, commandText, CType(Nothing, SqlParameter()))
    End Function 'ExecuteReader

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteReader(ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        'create & open a SqlConnection
        Dim cn As New SqlConnection(GetConnectString())
        cn.Open()

        Try
            'call the private overload that takes an internally owned connection in place of the connection string
            Return ExecuteReader(cn, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.Internal)
        Catch
            'if we fail to return the SqlDatReader, we need to close the connection ourselves
            cn.Dispose()
        End Try
        Return ExecuteReader(cn, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.Internal)
    End Function 'ExecuteReader


    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteReader(ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        Dim commandParameters As SqlParameter()
        Dim sCnnStr As String = GetConnectString()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(sCnnStr, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteReader(sCnnStr, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteReader(sCnnStr, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteReader


    ' Create and prepare a SqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
    ' If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
    ' If the caller provided the connection, we want to leave it to them to manage.
    ' Parameters:
    ' -connection - a valid SqlConnection, on which to execute this command 
    ' -transaction - a valid SqlTransaction, or ' null' 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParameters to be associated with the command or ' null' if no parameters are required 
    ' -connectionOwnership - indicates whether the connection parameter was provided by the caller, or created by SqlHelper 
    ' Returns: SqlDataReader containing the results of the command 
    Private Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                    ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal commandParameters() As SqlParameter, _
                                                    ByVal connectionOwnership As SqlConnectionOwnership) As SqlDataReader

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        Dim mustCloseConnection As Boolean = False
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Try
            ' Create a reader
            Dim dataReader As SqlDataReader

            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

            ' Call ExecuteReader with the appropriate CommandBehavior
            If connectionOwnership = SqlConnectionOwnership.External Then
                dataReader = cmd.ExecuteReader()
            Else
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            ' Detach the SqlParameters from the command object, so they can be used again
            Dim canClear As Boolean = True
            Dim commandParameter As SqlParameter
            For Each commandParameter In cmd.Parameters
                If commandParameter.Direction <> ParameterDirection.Input Then
                    canClear = False
                End If
            Next

            If (canClear) Then cmd.Parameters.Clear()

            Return dataReader
        Catch
            If (mustCloseConnection) Then connection.Close()
            Throw
        End Try
    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")

        ' Create & open a SqlConnection
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()
            ' Call the private overload that takes an internally owned connection in place of the connection string
            Return ExecuteReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.Internal)
        Catch
            ' If we fail to return the SqlDatReader, we need to close the connection ourselves
            If Not connection Is Nothing Then connection.Dispose()
            Throw
        End Try
    End Function ' ExecuteReader

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(connString, "GetOrders", 24, 36)
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader

        Return ExecuteReader(connection, commandType, commandText, CType(Nothing, SqlParameter()))

    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        ' Pass through the call to private overload using a null transaction value
        Return ExecuteReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.External)

    End Function ' ExecuteReader

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(conn, "GetOrders", 24, 36)
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()
        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -transaction - a valid SqlTransaction  
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -commandType - the CommandType (stored procedure, text, etc.)
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        ' Pass through to private overload, indicating that the connection is owned by the caller
        Return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External)
    End Function ' ExecuteReader

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(trans, "GetOrders", 24, 36)
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure
    ' Returns: A SqlDataReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteReader


#End Region

#Region "ExecuteScalar"

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteScalar(ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        'pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(GetConnectString(), commandType, commandText, CType(Nothing, SqlParameter()))
    End Function 'ExecuteScalar

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteScalar(ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        'create & open a SqlConnection, and dispose of it after we are done.
        Dim cn As New SqlConnection(GetConnectString())
        Try
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(cn, commandType, commandText, commandParameters)
        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteScalar

    'Overload agregado por VG, 23-01-2003, para no necesitar pasar ConnectString
    'Este es devuelto por SnipNET.Config
    Public Overloads Shared Function ExecuteScalar(ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        Dim commandParameters As SqlParameter()
        Dim sCnnStr As String = GetConnectString()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(sCnnStr, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteScalar(sCnnStr, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteScalar(sCnnStr, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount"))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command
    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim orderCount As Integer = Cint(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        ' Create & open a SqlConnection, and dispose of it after we are done.
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(connection, commandType, commandText, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteScalar

    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(connString, "GetOrderCount", 24, 36))
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount"))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Object
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        retval = cmd.ExecuteScalar()

        cmd.Parameters.Clear()

        If (mustCloseConnection) Then connection.Close()

        Return retval

    End Function ' ExecuteScalar

    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(conn, "GetOrderCount", 24, 36))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlTransaction.
    ' e.g.:  
    ' Dim orderCount As Integer  = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount"))
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
    ' Parameters:
    ' -transaction - a valid SqlTransaction  
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Object
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Execute the command & return the results
        retval = cmd.ExecuteScalar()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval
    End Function ' ExecuteScalar

    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim orderCount As Integer = CInt(ExecuteScalar(trans, "GetOrderCount", 24, 36))
    ' Parameters:
    ' -transaction - a valid SqlTransaction 
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An object containing the value in the 1x1 resultset generated by the command 
    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()
        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteScalar

#End Region

#Region "ExecuteXmlReader"

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    ' Returns: An XmlReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String) As XmlReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteXmlReader(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteXmlReader

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An XmlReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String, _
                                                      ByVal ParamArray commandParameters() As SqlParameter) As XmlReader
        ' Pass through the call using a null transaction value
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim mustCloseConnection As Boolean = False
        Try
            Dim retval As XmlReader

            PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

            ' Create the DataAdapter & DataSet
            retval = cmd.ExecuteXmlReader()

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            Return retval
        Catch
            If (mustCloseConnection) Then connection.Close()
            Throw
        End Try

    End Function ' ExecuteXmlReader

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(conn, "GetOrders", 24, 36)
    ' Parameters:
    ' -connection - a valid SqlConnection 
    ' -spName - the name of the stored procedure using "FOR XML AUTO" 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: An XmlReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal spName As String, _
                                                      ByVal ParamArray parameterValues() As Object) As XmlReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteXmlReader


    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -transaction - a valid SqlTransaction
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    ' Returns: An XmlReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String) As XmlReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteXmlReader(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteXmlReader

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -transaction - a valid SqlTransaction
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command using "FOR XML AUTO" 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: An XmlReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String, _
                                                      ByVal ParamArray commandParameters() As SqlParameter) As XmlReader
        ' Create a command and prepare it for execution
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        Dim cmd As New SqlCommand

        Dim retval As XmlReader
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Create the DataAdapter & DataSet
        retval = cmd.ExecuteXmlReader()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval

    End Function ' ExecuteXmlReader

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    ' using the provided parameter values.  This method will discover the parameters for the 
    ' stored procedure, and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' Dim r As XmlReader = ExecuteXmlReader(trans, "GetOrders", 24, 36)
    ' Parameters:
    ' -transaction - a valid SqlTransaction
    ' -spName - the name of the stored procedure 
    ' -parameterValues - an array of objects to be assigned as the input values of the stored procedure 
    ' Returns: A dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal spName As String, _
                                                      ByVal ParamArray parameterValues() As Object) As XmlReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteXmlReader

#End Region

#Region "FillDataset"
    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    '   FillDataset (connString, CommandType.StoredProcedure, "GetOrders", ds, new String() {"orders"})
    ' Parameters:    
    ' -connectionString: A valid connection string for a SqlConnection
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '               by a user defined name (probably the actual table name)
    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    '   FillDataset (connString, CommandType.StoredProcedure, "GetOrders", ds, new String() = {"orders"}, new SqlParameter("@prodid", 24))
    ' Parameters:    
    ' -connectionString: A valid connection string for a SqlConnection
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '               by a user defined name (probably the actual table name)
    ' -commandParameters: An array of SqlParamters used to execute the command
    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, _
        ByVal tableNames() As String, ByVal ParamArray commandParameters() As SqlParameter)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    '   FillDataset (connString, CommandType.StoredProcedure, "GetOrders", ds, new String() {"orders"}, 24)
    ' Parameters:
    ' -connectionString: A valid connection string for a SqlConnection
    ' -spName: the name of the stored procedure
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '             by a user defined name (probably the actual table name)
    ' -parameterValues: An array of objects to be assigned As the input values of the stored procedure
    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal spName As String, _
        ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray parameterValues() As Object)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As New SqlConnection(connectionString)
        Try
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, spName, dataSet, tableNames, parameterValues)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
    ' e.g.:  
    '   FillDataset (conn, CommandType.StoredProcedure, "GetOrders", ds, new String() {"orders"})
    ' Parameters:
    ' -connection: A valid SqlConnection
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    ' by a user defined name (probably the actual table name)
    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String())

        FillDataset(connection, commandType, commandText, dataSet, tableNames, Nothing)

    End Sub

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' e.g.:  
    '   FillDataset (conn, CommandType.StoredProcedure, "GetOrders", ds, new String() {"orders"}, new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection: A valid SqlConnection
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    ' by a user defined name (probably the actual table name)
    ' -commandParameters: An array of SqlParamters used to execute the command
    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal commandType As CommandType, _
    ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), _
        ByVal ParamArray commandParameters() As SqlParameter)

        FillDataset(connection, Nothing, commandType, commandText, dataSet, tableNames, commandParameters)

    End Sub

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    ' FillDataset (conn, "GetOrders", ds, new string() {"orders"}, 24, 36)
    ' Parameters:
    ' -connection: A valid SqlConnection
    ' -spName: the name of the stored procedure
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '             by a user defined name (probably the actual table name)
    ' -parameterValues: An array of objects to be assigned as the input values of the stored procedure
    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataSet As DataSet, _
        ByVal tableNames() As String, ByVal ParamArray parameterValues() As Object)

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If we receive parameter values, we need to figure out where they go
        If Not parameterValues Is Nothing AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else ' Otherwise we can just call the SP without params
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If

    End Sub

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
    ' e.g.:  
    '   FillDataset (trans, CommandType.StoredProcedure, "GetOrders", ds, new string() {"orders"})
    ' Parameters:
    ' -transaction: A valid SqlTransaction
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '             by a user defined name (probably the actual table name)
    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String)

        FillDataset(transaction, commandType, commandText, dataSet, tableNames, Nothing)
    End Sub

    ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
    ' using the provided parameters.
    ' e.g.:  
    '   FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string() {"orders"}, new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -transaction: A valid SqlTransaction
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    ' by a user defined name (probably the actual table name)
    ' -commandParameters: An array of SqlParamters used to execute the command
    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String, _
        ByVal ParamArray commandParameters() As SqlParameter)

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters)

    End Sub

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified 
    ' SqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' This method provides no access to output parameters or the stored procedure' s return value parameter.
    ' e.g.:  
    '   FillDataset(trans, "GetOrders", ds, new String(){"orders"}, 24, 36)
    ' Parameters:
    ' -transaction: A valid SqlTransaction
    ' -spName: the name of the stored procedure
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '             by a user defined name (probably the actual table name)
    ' -parameterValues: An array of objects to be assigned as the input values of the stored procedure
    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal spName As String, _
        ByVal dataSet As DataSet, ByVal tableNames() As String, ByVal ParamArray parameterValues() As Object)

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If we receive parameter values, we need to figure out where they go
        If Not parameterValues Is Nothing AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else ' Otherwise we can just call the SP without params
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If
    End Sub

    ' Private helper method that execute a SqlCommand (that returns a resultset) against the specified SqlTransaction and SqlConnection
    ' using the provided parameters.
    ' e.g.:  
    '   FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new String() {"orders"}, new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -connection: A valid SqlConnection
    ' -transaction: A valid SqlTransaction
    ' -commandType: the CommandType (stored procedure, text, etc.)
    ' -commandText: the stored procedure name or T-SQL command
    ' -dataSet: A dataset wich will contain the resultset generated by the command
    ' -tableNames: this array will be used to create table mappings allowing the DataTables to be referenced
    '             by a user defined name (probably the actual table name)
    ' -commandParameters: An array of SqlParamters used to execute the command
    Private Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String, _
        ByVal ParamArray commandParameters() As SqlParameter)

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create a command and prepare it for execution
        Dim command As New SqlCommand

        Dim mustCloseConnection As Boolean = False
        PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Create the DataAdapter & DataSet
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)

        Try
            ' Add the table mappings specified by the user
            If Not tableNames Is Nothing AndAlso tableNames.Length > 0 Then

                Dim tableName As String = "Table"
                Dim index As Integer

                For index = 0 To tableNames.Length - 1
                    If (tableNames(index) Is Nothing OrElse tableNames(index).Length = 0) Then Throw New ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames")
                    dataAdapter.TableMappings.Add(tableName, tableNames(index))
                    tableName = tableName & (index + 1).ToString()
                Next
            End If

            ' Fill the DataSet using default values for DataTable names, etc
            dataAdapter.Fill(dataSet)

            ' Detach the SqlParameters from the command object, so they can be used again
            command.Parameters.Clear()
        Finally
            If (Not dataAdapter Is Nothing) Then dataAdapter.Dispose()
        End Try

        If (mustCloseConnection) Then connection.Close()

    End Sub
#End Region

#Region "UpdateDataset"
    ' Executes the respective command for each inserted, updated, or deleted row in the DataSet.
    ' e.g.:  
    '   UpdateDataset(conn, insertCommand, deleteCommand, updateCommand, dataSet, "Order")
    ' Parameters:
    ' -insertCommand: A valid transact-SQL statement or stored procedure to insert new records into the data source
    ' -deleteCommand: A valid transact-SQL statement or stored procedure to delete records from the data source
    ' -updateCommand: A valid transact-SQL statement or stored procedure used to update records in the data source
    ' -dataSet: the DataSet used to update the data source
    ' -tableName: the DataTable used to update the data source
    Public Overloads Shared Sub UpdateDataset(ByVal insertCommand As SqlCommand, ByVal deleteCommand As SqlCommand, ByVal updateCommand As SqlCommand, ByVal dataSet As DataSet, ByVal tableName As String)

        If (insertCommand Is Nothing) Then Throw New ArgumentNullException("insertCommand")
        If (deleteCommand Is Nothing) Then Throw New ArgumentNullException("deleteCommand")
        If (updateCommand Is Nothing) Then Throw New ArgumentNullException("updateCommand")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (tableName Is Nothing OrElse tableName.Length = 0) Then Throw New ArgumentNullException("tableName")

        'Create a SqlDataAdapter, and dispose of it after we are done
        If updateCommand.Connection Is Nothing Then
            updateCommand.Connection = GetConnection()
        End If
        If insertCommand.Connection Is Nothing Then
            insertCommand.Connection = GetConnection()
        End If
        If deleteCommand.Connection Is Nothing Then
            deleteCommand.Connection = GetConnection()
        End If
        Dim dataAdapter As New SqlDataAdapter

        Try
            ' Set the data adapter commands
            dataAdapter.UpdateCommand = updateCommand
            dataAdapter.InsertCommand = insertCommand
            dataAdapter.DeleteCommand = deleteCommand

            ' Update the dataset changes in the data source
            dataAdapter.Update(dataSet, tableName)

            ' Commit all the changes made to the DataSet
            dataSet.AcceptChanges()

        Finally
            If (Not dataAdapter Is Nothing) Then dataAdapter.Dispose()
        End Try
    End Sub
#End Region

#Region "CreateCommand"
    ' Simplify the creation of a Sql command object by allowing
    ' a stored procedure and optional parameters to be provided
    ' e.g.:  
    ' Dim command As SqlCommand = CreateCommand(conn, "AddCustomer", "CustomerID", "CustomerName")
    ' Parameters:
    ' -connection: A valid SqlConnection object
    ' -spName: the name of the stored procedure
    ' -sourceColumns: An array of string to be assigned as the source columns of the stored procedure parameters
    ' Returns:
    ' a valid SqlCommand object
    Public Overloads Shared Function CreateCommand(ByVal connection As SqlConnection, ByVal spName As String, ByVal ParamArray sourceColumns() As String) As SqlCommand

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a SqlCommand
        Dim cmd As New SqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure

        ' If we receive parameter values, we need to figure out where they go
        If Not sourceColumns Is Nothing AndAlso sourceColumns.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided source columns to these parameters based on parameter order
            Dim index As Integer
            For index = 0 To sourceColumns.Length - 1
                commandParameters(index).SourceColumn = sourceColumns(index)
            Next

            ' Attach the discovered parameters to the SqlCommand object
            AttachParameters(cmd, commandParameters)
        End If
        CreateCommand = cmd
    End Function
#End Region

#Region "ExecuteNonQueryTypedParams"
    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
    ' the connection string using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -connectionString: A valid connection string for a SqlConnection
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values
    ' Returns:
    ' an int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As Integer
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the dataRow column values as the stored procedure' s parameters values.  
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -connection:a valid SqlConnection object
    ' -spName: the name of the stored procedure
    ' -dataRow:The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' an int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As Integer
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the specified
    ' SqlTransaction using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -transaction:a valid SqlTransaction object
    ' -spName:the name of the stored procedure
    ' -dataRow:The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' an int representing the number of rows affected by the command
    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As Integer

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "ExecuteDatasetTypedParams"
    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -connectionString: A valid connection string for a SqlConnection
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As DataSet
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the dataRow column values as the store procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -connection: A valid SqlConnection object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As DataSet

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ' Parameters:
    ' -transaction: A valid SqlTransaction object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a dataset containing the resultset generated by the command
    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As DataSet
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "ExecuteReaderTypedParams"
    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -connectionString: A valid connection string for a SqlConnection
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a SqlDataReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -connection: A valid SqlConnection object
    ' -spName: The name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a SqlDataReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -transaction: A valid SqlTransaction object
    ' -spName" The name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' a SqlDataReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "ExecuteScalarTypedParams"
    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the database specified in 
    ' the connection string using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -connectionString: A valid connection string for a SqlConnection
    ' -spName: The name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns:
    ' An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -connection: A valid SqlConnection object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns: 
    ' an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -transaction: A valid SqlTransaction object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns: 
    ' an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "ExecuteXmlReaderTypedParams"
    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -connection: A valid SqlConnection object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns: 
    ' an XmlReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteXmlReaderTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As XmlReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the specified SqlTransaction 
    ' using the dataRow column values as the stored procedure' s parameters values.
    ' This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' Parameters:
    ' -transaction: A valid SqlTransaction object
    ' -spName: the name of the stored procedure
    ' -dataRow: The dataRow used to hold the stored procedure' s parameter values.
    ' Returns: 
    ' an XmlReader containing the resultset generated by the command
    Public Overloads Shared Function ExecuteXmlReaderTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As XmlReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' if the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region " GetConnection "

    Public Overloads Shared Function GetConnection() As SqlConnection
        Dim cnn As New SqlConnection(GetConnectString())
        Return cnn
    End Function

    Public Overloads Shared Function GetConnection(ByVal ConnectionString As String) As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
#End Region

End Class ' SqlHelper

' SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
' ability to discover parameters for stored procedures at run-time.
Public NotInheritable Class SqlHelperParameterCache

#Region "private methods, variables, and constructors"


    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new SqlHelperParameterCache()".
    Private Sub New()
    End Sub ' New 

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    ' resolve at run time the appropriate set of SqlParameters for a stored procedure
    ' Parameters:
    ' - connectionString - a valid connection string for a SqlConnection
    ' - spName - the name of the stored procedure
    ' - includeReturnValueParameter - whether or not to include their return value parameter>
    ' Returns: SqlParameter()
    Private Shared Function DiscoverSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean, _
                                                       ByVal ParamArray parameterValues() As Object) As SqlParameter()

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim cmd As New SqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim discoveredParameters() As SqlParameter
        connection.Open()
        SqlCommandBuilder.DeriveParameters(cmd)
        connection.Close()
        If Not includeReturnValueParameter Then
            cmd.Parameters.RemoveAt(0)
        End If

        discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
        cmd.Parameters.CopyTo(discoveredParameters, 0)

        ' Init the parameters with a DBNull value
        Dim discoveredParameter As SqlParameter
        For Each discoveredParameter In discoveredParameters
            discoveredParameter.Value = DBNull.Value
        Next

        Return discoveredParameters

    End Function ' DiscoverSpParameterSet

    ' Deep copy of cached SqlParameter array
    Private Shared Function CloneParameters(ByVal originalParameters() As SqlParameter) As SqlParameter()

        Dim i As Integer
        Dim j As Integer = originalParameters.Length - 1
        Dim clonedParameters(j) As SqlParameter

        For i = 0 To j
            clonedParameters(i) = CType(CType(originalParameters(i), ICloneable).Clone, SqlParameter)
        Next

        Return clonedParameters
    End Function ' CloneParameters

#End Region

#Region "caching functions"

    ' add parameter array to the cache
    ' Parameters
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters to be cached 
    Public Shared Sub CacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String, _
                                        ByVal ParamArray commandParameters() As SqlParameter)
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        Dim hashKey As String = connectionString + ":" + commandText

        paramCache(hashKey) = commandParameters
    End Sub ' CacheParameterSet

    ' retrieve a parameter array from the cache
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: An array of SqlParamters 
    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As SqlParameter()
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        Dim hashKey As String = connectionString + ":" + commandText
        Dim cachedParameters As SqlParameter() = CType(paramCache(hashKey), SqlParameter())

        If cachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(cachedParameters)
        End If
    End Function ' GetCachedParameterSet

#End Region

#Region "Parameter Discovery Functions"
    ' Retrieves the set of SqlParameters appropriate for the stored procedure.
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection 
    ' -spName - the name of the stored procedure 
    ' Returns: An array of SqlParameters
    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As SqlParameter()
        Return GetSpParameterSet(connectionString, spName, False)
    End Function ' GetSpParameterSet 

    ' Retrieves the set of SqlParameters appropriate for the stored procedure.
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' Parameters:
    ' -connectionString - a valid connection string for a SqlConnection
    ' -spName - the name of the stored procedure 
    ' -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
    ' Returns: An array of SqlParameters 
    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        Dim connection As New SqlConnection(connectionString)
        Try
            'connection.Open()
            GetSpParameterSet = GetSpParameterSetInternal(connection, spName, includeReturnValueParameter)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' GetSpParameterSet

    ' Retrieves the set of SqlParameters appropriate for the stored procedure.
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' Parameters:
    ' -connection - a valid SqlConnection object
    ' -spName - the name of the stored procedure 
    ' -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
    ' Returns: An array of SqlParameters 
    Public Overloads Shared Function GetSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String) As SqlParameter()

        GetSpParameterSet = GetSpParameterSet(connection, spName, False)
    End Function ' GetSpParameterSet

    ' Retrieves the set of SqlParameters appropriate for the stored procedure.
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' Parameters:
    ' -connection - a valid SqlConnection object
    ' -spName - the name of the stored procedure 
    ' -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
    ' Returns: An array of SqlParameters 
    Public Overloads Shared Function GetSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        Dim clonedConnection As New SqlConnection
        Try
            clonedConnection = CType((CType(connection, ICloneable).Clone), SqlConnection)
            GetSpParameterSet = GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter)
        Finally
            If Not clonedConnection Is Nothing Then clonedConnection.Dispose()
        End Try
    End Function ' GetSpParameterSet

    ' Retrieves the set of SqlParameters appropriate for the stored procedure.
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' Parameters:
    ' -connection - a valid SqlConnection object
    ' -spName - the name of the stored procedure 
    ' -includeReturnValueParameter - a bool value indicating whether the return value parameter should be included in the results 
    ' Returns: An array of SqlParameters 
    Private Overloads Shared Function GetSpParameterSetInternal(ByVal connection As SqlConnection, _
                                                    ByVal spName As String, _
                                                    ByVal includeReturnValueParameter As Boolean) As SqlParameter()

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        Dim cachedParameters() As SqlParameter
        Dim hashKey As String

        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        hashKey = connection.ConnectionString + ":" + spName + IIf(includeReturnValueParameter = True, ":include ReturnValue Parameter", "").ToString

        cachedParameters = CType(paramCache(hashKey), SqlParameter())

        If (cachedParameters Is Nothing) Then
            Dim spParameters() As SqlParameter = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter)
            paramCache(hashKey) = spParameters
            cachedParameters = spParameters

        End If

        Return CloneParameters(cachedParameters)

    End Function ' GetSpParameterSet
#End Region

End Class ' SqlHelperParameterCache 