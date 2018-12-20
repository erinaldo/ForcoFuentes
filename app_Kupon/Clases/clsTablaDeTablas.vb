Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class clsTablaDeTablas

    Public Sub Borrar(ByVal nCodTbl As Integer, ByVal nId As String, ByRef strMsj As String)
        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasBorrar", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nId
        cmd.Parameters.Add(_nID)

        Dim _strMsj As SqlParameter = New SqlParameter("@strMsj", SqlDbType.NVarChar, 50)
        _strMsj.Direction = ParameterDirection.Output
        cmd.Parameters.Add(_strMsj)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()

        strMsj = _strMsj.Value
    End Sub

    Public Sub EmpresasAddDatos(ByVal nCodTbl As Integer, ByVal nID As Integer, ByVal strDescripcion As String, ByVal strConcepto As String, ByVal nGrupo As Integer, ByVal nEmpresa As Integer)
        Dim cmd As SqlCommand = New SqlCommand("spEmpresasAddDatos", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nID
        cmd.Parameters.Add(_nID)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = nEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _strDescripcion As New SqlParameter("@strDescripcion", SqlDbType.NVarChar)
        _strDescripcion.Value = strDescripcion
        cmd.Parameters.Add(_strDescripcion)

        Dim _strConcepto As New SqlParameter("@strConcepto", SqlDbType.NVarChar)
        _strConcepto.Value = strConcepto
        cmd.Parameters.Add(_strConcepto)

        Dim _nGrupo As New SqlParameter("@nGrupo", SqlDbType.Int)
        _nGrupo.Value = nGrupo
        cmd.Parameters.Add(_nGrupo)

        Dim _nRecNo As SqlParameter = New SqlParameter("@nRecNo", SqlDbType.Int)
        _nRecNo.Direction = ParameterDirection.Output
        cmd.Parameters.Add(_nRecNo)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
    End Sub

    Public Function Status(ByVal nID As Integer, ByVal nCodTbl As Integer) As DataSet
        Dim DBConn As SqlConnection
        Dim DBCommand As SqlDataAdapter
        Dim ds As New DataSet()

        DBConn = New SqlConnection(funConexion())
        DBCommand = New SqlDataAdapter("spTablaDeTablasStatus", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nID
        DBCommand.SelectCommand.Parameters.Add(_nID)

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        DBCommand.SelectCommand.Parameters.Add(_nCodTbl)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Function Update(ByVal nCodTbl As Integer, ByVal nID As Integer, ByVal nStatus As Boolean, ByVal nEmpresa As Integer) As String
        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasUpdateStatus", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nID
        cmd.Parameters.Add(_nID)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = nEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _nStatus As New SqlParameter("@nStatus", SqlDbType.Bit)
        _nStatus.Value = nStatus
        cmd.Parameters.Add(_nStatus)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function List(ByVal nID As Integer, ByVal strDescripcion As String, ByVal nCodTbl As Integer, ByVal nTipo As Integer, ByVal strCampo As String) As DataSet
        Dim DBConn As SqlConnection
        Dim DBCommand As SqlDataAdapter
        Dim ds As New DataSet()

        DBConn = New SqlConnection(funConexion())
        DBCommand = New SqlDataAdapter("spTablaDeTablasList", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nID
        DBCommand.SelectCommand.Parameters.Add(_nID)

        Dim _strDescripcion As New SqlParameter("@strDescripcion", SqlDbType.NVarChar)
        _strDescripcion.Value = strDescripcion
        DBCommand.SelectCommand.Parameters.Add(_strDescripcion)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = intEmpresa
        DBCommand.SelectCommand.Parameters.Add(_nEmpresa)

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        DBCommand.SelectCommand.Parameters.Add(_nCodTbl)

        Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
        _nTipo.Value = nTipo
        DBCommand.SelectCommand.Parameters.Add(_nTipo)

        Dim _strCampo As New SqlParameter("@strCampo", SqlDbType.NVarChar)
        _strCampo.Value = strCampo
        DBCommand.SelectCommand.Parameters.Add(_strCampo)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Function Agregar(ByVal nCodTbl As Integer, ByVal nID As Integer, ByVal strDescripcion As String _
                            , ByVal strConcepto As String, ByVal nGrupo As Integer, ByVal nEmpresa As Integer _
                            , ByVal nGrupoComp As Integer, ByVal nTransaccion As Integer) As String

        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasAdd", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nID
        cmd.Parameters.Add(_nID)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = nEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _strDescripcion As New SqlParameter("@strDescripcion", SqlDbType.NVarChar)
        _strDescripcion.Value = strDescripcion
        cmd.Parameters.Add(_strDescripcion)

        Dim _strConcepto As New SqlParameter("@strConcepto", SqlDbType.NVarChar)
        _strConcepto.Value = strConcepto
        cmd.Parameters.Add(_strConcepto)

        Dim _nGrupo As New SqlParameter("@nGrupo", SqlDbType.Int)
        _nGrupo.Value = nGrupo
        cmd.Parameters.Add(_nGrupo)

        Dim _nGrupoComp As New SqlParameter("@nGrupoComp", SqlDbType.Int)
        _nGrupoComp.Value = nGrupoComp
        cmd.Parameters.Add(_nGrupoComp)

        Dim _nTransaccion As New SqlParameter("@nTransaccion", SqlDbType.Int)
        _nTransaccion.Value = nTransaccion
        cmd.Parameters.Add(_nTransaccion)

        Dim _nRecNo As SqlParameter = New SqlParameter("@nRecNo", SqlDbType.Int)
        _nRecNo.Direction = ParameterDirection.Output
        cmd.Parameters.Add(_nRecNo)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()

        Return _nRecNo.Value

    End Function

    Public Sub Edit(ByVal nRecNo As Integer, ByVal nCodTbl As Integer, ByVal strDescripcion As String _
                    , ByVal strConcepto As String, ByVal nGrupo As Integer, ByVal nId As String _
                    , ByVal nGrupoComp As Integer, ByVal nTransaccion As Integer)

        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasEdit", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nRecNo As New SqlParameter("@nRecNo", SqlDbType.Int)
        _nRecNo.Value = nRecNo
        cmd.Parameters.Add(_nRecNo)

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        'Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        '_nEmpresa.Value = nEmpresa
        'cmd.Parameters.Add(_nEmpresa)

        Dim _strDescripcion As New SqlParameter("@strDescripcion", SqlDbType.NVarChar)
        _strDescripcion.Value = strDescripcion
        cmd.Parameters.Add(_strDescripcion)

        Dim _strConcepto As New SqlParameter("@strConcepto", SqlDbType.NVarChar)
        _strConcepto.Value = strConcepto
        cmd.Parameters.Add(_strConcepto)

        Dim _nGrupo As New SqlParameter("@nGrupo", SqlDbType.Int)
        _nGrupo.Value = nGrupo
        cmd.Parameters.Add(_nGrupo)

        Dim _nID As New SqlParameter("@nID", SqlDbType.Int)
        _nID.Value = nId
        cmd.Parameters.Add(_nID)

        Dim _nGrupoComp As New SqlParameter("@nGrupoComp", SqlDbType.Int)
        _nGrupoComp.Value = nGrupoComp
        cmd.Parameters.Add(_nGrupoComp)

        Dim _nTransaccion As New SqlParameter("@nTransaccion", SqlDbType.Int)
        _nTransaccion.Value = nTransaccion
        cmd.Parameters.Add(_nTransaccion)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
    End Sub

    Public Function Numero(ByVal nCodTbl As Integer) As Integer
        Dim DBConn As SqlConnection
        DBConn = New SqlConnection(funConexion())
        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasID", DBConn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _Numero As SqlParameter = New SqlParameter("@Numero", SqlDbType.Int)
        _Numero.Direction = ParameterDirection.Output
        cmd.Parameters.Add(_Numero)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = intEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _nCodTbl As New SqlParameter("@nCodTbl", SqlDbType.Int)
        _nCodTbl.Value = nCodTbl
        cmd.Parameters.Add(_nCodTbl)

        cmd.Connection = DBConn
        DBConn.Open()
        cmd.ExecuteNonQuery()

        Return _Numero.Value
    End Function

    Public Function CodTbl() As Integer
        Dim DBConn As SqlConnection
        DBConn = New SqlConnection(funConexion())
        Dim cmd As SqlCommand = New SqlCommand("spTablaDeTablasCodTbl", DBConn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _Numero As SqlParameter = New SqlParameter("@Numero", SqlDbType.Int)
        _Numero.Direction = ParameterDirection.Output
        cmd.Parameters.Add(_Numero)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = intEmpresa
        cmd.Parameters.Add(_nEmpresa)

        cmd.Connection = DBConn
        DBConn.Open()
        cmd.ExecuteNonQuery()

        Return _Numero.Value
    End Function

    Function funPilasPorGranja(ByVal intGranja As Integer) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter("spPilasPorGranja", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        funSqlParametro("@NGRANJA", intGranja, SqlDbType.Int, DBCommand, 1)
        'Dim _Granja As New SqlParameter("@NGRANJA", SqlDbType.Int)
        '_Granja.Value = intGranja
        'DBCommand.SelectCommand.Parameters.Add(_Granja)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Function funDestinosPorAreaFamilia(ByVal intArea As Integer, ByVal nFamilia As Integer) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter("spDestinosPorAreaFamilia", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        funSqlParametro("@NEMPRESA", intEmpresa, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@NAREA", intArea, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@nFamilia", nFamilia, SqlDbType.Int, DBCommand, 1)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Function funDestinosPorArea(ByVal intArea As Integer) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter("spDestinosPorArea", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        funSqlParametro("@NEMPRESA", intEmpresa, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@NAREA", intArea, SqlDbType.Int, DBCommand, 1)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Function funDestinosNoAreaFamilia(ByVal intArea As Integer, ByVal nFamilia As Integer) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter("spDestinosNoAreaFamilia", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        funSqlParametro("@NEMPRESA", intEmpresa, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@NAREA", intArea, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@nFamilia", nFamilia, SqlDbType.Int, DBCommand, 1)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Function funDestinosNoArea(ByVal intArea As Integer) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter("spDestinosNoArea", DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        funSqlParametro("@NEMPRESA", intEmpresa, SqlDbType.Int, DBCommand, 1)
        funSqlParametro("@NAREA", intArea, SqlDbType.Int, DBCommand, 1)

        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Function funDestinosPorAreaFamiliaAdd(ByVal intArea As Integer, ByVal nDestino As Integer, _
                                          ByVal nTipo As Integer, ByVal nFamilia As Integer, _
                                          ByVal strCuenta As String)
        Dim cmd As SqlCommand = New SqlCommand("spDestinosPorAreaFamiliaAdd", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nArea As New SqlParameter("@nArea", SqlDbType.Int)
        _nArea.Value = intArea
        cmd.Parameters.Add(_nArea)

        Dim _nDestino As New SqlParameter("@nDestino", SqlDbType.Int)
        _nDestino.Value = nDestino
        cmd.Parameters.Add(_nDestino)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = intEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
        _nTipo.Value = nTipo
        cmd.Parameters.Add(_nTipo)

        Dim _nFamilia As New SqlParameter("@nFamilia", SqlDbType.Int)
        _nFamilia.Value = nFamilia
        cmd.Parameters.Add(_nFamilia)

        Dim _strCuenta As New SqlParameter("@strCuenta", SqlDbType.NVarChar)
        _strCuenta.Value = strCuenta
        cmd.Parameters.Add(_strCuenta)

        Dim _strUser As New SqlParameter("@strUser", SqlDbType.NVarChar)
        _strUser.Value = strUser
        cmd.Parameters.Add(_strUser)

        'Fin parametros
        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Function funDestinosPorAreaAdd(ByVal intArea As Integer, ByVal nDestino As Integer, ByVal nTipo As Integer)
        Dim cmd As SqlCommand = New SqlCommand("spDestinosPorAreaAdd", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nArea As New SqlParameter("@nArea", SqlDbType.Int)
        _nArea.Value = intArea
        cmd.Parameters.Add(_nArea)

        Dim _nDestino As New SqlParameter("@nDestino", SqlDbType.Int)
        _nDestino.Value = nDestino
        cmd.Parameters.Add(_nDestino)

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = intEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
        _nTipo.Value = nTipo
        cmd.Parameters.Add(_nTipo)

        'Fin parametros
        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function
End Class
