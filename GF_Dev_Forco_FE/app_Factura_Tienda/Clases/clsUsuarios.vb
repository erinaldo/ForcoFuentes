Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SGA

    Public Class clsUsuarios

        'Public Shared Function BORRAR(ByVal strVariable As String) As DataSet
        '    Dim DBConn As SqlConnection
        '    Dim DBCommand As SqlDataAdapter
        '    Dim ds As New DataSet()
        '    DBConn = New SqlConnection(funConexion())
        '    DBCommand = New SqlDataAdapter("BORRAR", DBConn)

        '    DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        '    Dim _strVariable As New SqlParameter("@strVariable", SqlDbType.NVarChar)
        '    _strVariable.Value = strVariable
        '    DBCommand.SelectCommand.Parameters.Add(_strVariable)

        '    'Cerramos
        '    DBCommand.Fill(ds, "Tabla")
        '    DBConn.Close()

        '    Return ds
        'End Function

        Public Sub ResetPassword(ByVal nCode As Integer, ByVal strPassword As String)

            Dim cmd As SqlCommand = New SqlCommand("spUsuariosReset", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strPassword As New SqlParameter("@strPassword", SqlDbType.NVarChar)
            _strPassword.Value = strPassword
            cmd.Parameters.Add(_strPassword)

            Dim _nCode As SqlParameter = New SqlParameter("@nCode", SqlDbType.Int)
            _nCode.Value = nCode
            cmd.Parameters.Add(_nCode)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()

        End Sub

        Public Sub CambiarStatus(ByVal nUserID As Integer, ByVal nStatus As Integer, ByVal dtmInactivo As Date, ByVal strObservacion As String)

            Dim cmd As SqlCommand = New SqlCommand("spUsuarioCambiarStatus", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            cmd.Parameters.Add(_nUserID)

            Dim _nStatus As New SqlParameter("@nStatus", SqlDbType.Int)
            _nStatus.Value = nStatus
            cmd.Parameters.Add(_nStatus)

            Dim _dtmInactivo As New SqlParameter("@dtmInactivo", SqlDbType.DateTime)
            _dtmInactivo.Value = dtmInactivo
            cmd.Parameters.Add(_dtmInactivo)

            Dim _strObservacion As New SqlParameter("@strObservacion", SqlDbType.NVarChar)
            _strObservacion.Value = strObservacion
            cmd.Parameters.Add(_strObservacion)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()

        End Sub

        Public Sub Edit(ByVal nCode As Integer, ByVal strPNombre As String, ByVal strSNombre As String, _
                        ByVal strPApellido As String, ByVal strSApellido As String, _
                        ByVal strCedula As String, ByVal strNSS As String, _
                        ByVal dtmNacimiento As Date, ByVal dtmCaducidad As Date, _
                        ByVal strLogin As String, ByVal strPassword As String, _
                        ByVal nBodega As Integer, ByVal nArea As Integer)

            Dim cmd As SqlCommand = New SqlCommand("spUsuariosEdit", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strPNombre As New SqlParameter("@strPNombre", SqlDbType.NVarChar)
            _strPNombre.Value = strPNombre
            cmd.Parameters.Add(_strPNombre)

            Dim _strSNombre As New SqlParameter("@strSNombre", SqlDbType.NVarChar)
            _strSNombre.Value = strSNombre
            cmd.Parameters.Add(_strSNombre)

            Dim _strPApellido As New SqlParameter("@strPApellido", SqlDbType.NVarChar)
            _strPApellido.Value = strPApellido
            cmd.Parameters.Add(_strPApellido)

            Dim _strSApellido As New SqlParameter("@strSApellido", SqlDbType.NVarChar)
            _strSApellido.Value = strSApellido
            cmd.Parameters.Add(_strSApellido)

            Dim _strCedula As New SqlParameter("@strCedula", SqlDbType.NVarChar)
            _strCedula.Value = strCedula
            cmd.Parameters.Add(_strCedula)

            Dim _strNSS As New SqlParameter("@strNSS", SqlDbType.NVarChar)
            _strNSS.Value = strNSS
            cmd.Parameters.Add(_strNSS)

            Dim _dtmNacimiento As New SqlParameter("@dtmNacimiento", SqlDbType.DateTime)
            _dtmNacimiento.Value = dtmNacimiento
            cmd.Parameters.Add(_dtmNacimiento)

            Dim _dtmCaducidad As New SqlParameter("@dtmCaducidad", SqlDbType.DateTime)
            _dtmCaducidad.Value = dtmCaducidad
            cmd.Parameters.Add(_dtmCaducidad)

            Dim _nBodega As New SqlParameter("@nBodega", SqlDbType.Int)
            _nBodega.Value = nBodega
            cmd.Parameters.Add(_nBodega)

            Dim _nArea As New SqlParameter("@nArea", SqlDbType.Int)
            _nArea.Value = nArea
            cmd.Parameters.Add(_nArea)

            Dim _strLogin As New SqlParameter("@strLogin", SqlDbType.NVarChar)
            _strLogin.Value = strLogin
            cmd.Parameters.Add(_strLogin)

            Dim _strPassword As New SqlParameter("@strPassword", SqlDbType.NVarChar)
            _strPassword.Value = strPassword
            cmd.Parameters.Add(_strPassword)

            Dim _nCode As SqlParameter = New SqlParameter("@nCode", SqlDbType.Int)
            _nCode.Value = nCode
            cmd.Parameters.Add(_nCode)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()

        End Sub

        Public Function RolesPorUsuarios(ByVal nUserID As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spRolesPorUsuarios", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Sub RolMenuAdd(ByVal nRolID As Integer, ByVal strMenu As String, _
                              ByVal strModulo As String, ByVal nTipo As Integer, _
                              ByVal strMenuPadre As String, ByVal strForm As String, _
                              ByVal strFormPadre As String)

            Dim cmd As SqlCommand = New SqlCommand("spRolMenuAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nRolID As New SqlParameter("@nRolID", SqlDbType.Int)
            _nRolID.Value = nRolID
            cmd.Parameters.Add(_nRolID)

            Dim _strMenu As New SqlParameter("@strMenu", SqlDbType.NVarChar)
            _strMenu.Value = strMenu
            cmd.Parameters.Add(_strMenu)

            Dim _strModulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _strModulo.Value = strModulo
            cmd.Parameters.Add(_strModulo)

            Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
            _nTipo.Value = nTipo
            cmd.Parameters.Add(_nTipo)

            Dim _strMenuPadre As New SqlParameter("@strMenuPadre", SqlDbType.NVarChar)
            _strMenuPadre.Value = strMenuPadre
            cmd.Parameters.Add(_strMenuPadre)

            Dim _strForm As New SqlParameter("@strForm", SqlDbType.NVarChar)
            _strForm.Value = strForm
            cmd.Parameters.Add(_strForm)

            Dim _strFormPadre As New SqlParameter("@strFormPadre", SqlDbType.NVarChar)
            _strFormPadre.Value = strFormPadre
            cmd.Parameters.Add(_strFormPadre)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Sub UsuarioRolesAdd(ByVal nUserID As String, ByVal nRolID As Integer, ByVal nTipo As Boolean)

            Dim cmd As SqlCommand = New SqlCommand("spUsuarioRolesAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            cmd.Parameters.Add(_nUserID)

            Dim _nRolID As New SqlParameter("@nRolID", SqlDbType.Int)
            _nRolID.Value = nRolID
            cmd.Parameters.Add(_nRolID)

            Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Bit)
            _nTipo.Value = nTipo
            cmd.Parameters.Add(_nTipo)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Function UsuariosRoles(ByVal nUserID As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuariosRoles", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function RolMenu(ByVal nUserID As Integer, ByVal Modulo As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spRolMenu", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            Dim _Modulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _Modulo.Value = Modulo
            DBCommand.SelectCommand.Parameters.Add(_Modulo)

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Sub UsuariosModulosAdd(ByVal strUsuario As String, ByVal strModulo As String)

            Dim cmd As SqlCommand = New SqlCommand("spUsuariosModulosAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strUser As New SqlParameter("@strUser", SqlDbType.NVarChar)
            _strUser.Value = strUsuario
            cmd.Parameters.Add(_strUser)

            Dim _strModulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _strModulo.Value = strModulo
            cmd.Parameters.Add(_strModulo)

            Dim _strUserAdd As New SqlParameter("@strUserAdd", SqlDbType.NVarChar)
            _strUserAdd.Value = strUser
            cmd.Parameters.Add(_strUserAdd)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Function Add(ByVal strPNombre As String, ByVal strSNombre As String, _
                        ByVal strPApellido As String, ByVal strSApellido As String, _
                        ByVal strCedula As String, ByVal strNSS As String, _
                        ByVal dtmNacimiento As Date, ByVal dtmCaducidad As Date, _
                        ByVal strLogin As String, ByVal strPassword As String, _
                        ByVal nBodega As Integer, ByVal nArea As Integer) As Integer

            Dim cmd As SqlCommand = New SqlCommand("spUsuariosAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strPNombre As New SqlParameter("@strPNombre", SqlDbType.NVarChar)
            _strPNombre.Value = strPNombre
            cmd.Parameters.Add(_strPNombre)

            Dim _strSNombre As New SqlParameter("@strSNombre", SqlDbType.NVarChar)
            _strSNombre.Value = strSNombre
            cmd.Parameters.Add(_strSNombre)

            Dim _strPApellido As New SqlParameter("@strPApellido", SqlDbType.NVarChar)
            _strPApellido.Value = strPApellido
            cmd.Parameters.Add(_strPApellido)

            Dim _strSApellido As New SqlParameter("@strSApellido", SqlDbType.NVarChar)
            _strSApellido.Value = strSApellido
            cmd.Parameters.Add(_strSApellido)

            Dim _strCedula As New SqlParameter("@strCedula", SqlDbType.NVarChar)
            _strCedula.Value = strCedula
            cmd.Parameters.Add(_strCedula)

            Dim _strNSS As New SqlParameter("@strNSS", SqlDbType.NVarChar)
            _strNSS.Value = strNSS
            cmd.Parameters.Add(_strNSS)

            Dim _dtmNacimiento As New SqlParameter("@dtmNacimiento", SqlDbType.DateTime)
            _dtmNacimiento.Value = dtmNacimiento
            cmd.Parameters.Add(_dtmNacimiento)

            Dim _dtmCaducidad As New SqlParameter("@dtmCaducidad", SqlDbType.DateTime)
            _dtmCaducidad.Value = dtmCaducidad
            cmd.Parameters.Add(_dtmCaducidad)

            Dim _nBodega As New SqlParameter("@nBodega", SqlDbType.Int)
            _nBodega.Value = nBodega
            cmd.Parameters.Add(_nBodega)

            Dim _nArea As New SqlParameter("@nArea", SqlDbType.Int)
            _nArea.Value = nArea
            cmd.Parameters.Add(_nArea)

            Dim _strLogin As New SqlParameter("@strLogin", SqlDbType.NVarChar)
            _strLogin.Value = strLogin
            cmd.Parameters.Add(_strLogin)

            Dim _strPassword As New SqlParameter("@strPassword", SqlDbType.NVarChar)
            _strPassword.Value = strPassword
            cmd.Parameters.Add(_strPassword)

            Dim _nRecNo As SqlParameter = New SqlParameter("@nRecNo", SqlDbType.Int)
            _nRecNo.Direction = ParameterDirection.Output
            cmd.Parameters.Add(_nRecNo)
            funSqlParametro("strUsuario", strUser, SqlDbType.NVarChar, cmd, 2)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()

            Return _nRecNo.Value
        End Function

        Public Function Detalle(ByVal nUserID As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuariosDetalle", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function DetalleLogin(ByVal strUser As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuariosDetalleLogin", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _strUser As New SqlParameter("@strUser", SqlDbType.NVarChar)
            _strUser.Value = strUser
            DBCommand.SelectCommand.Parameters.Add(_strUser)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Sub EmpresasPorUsuarioAdd(ByVal nUserID As Integer, ByVal nEmpresa As Integer, ByVal nStatus As Boolean)

            Dim cmd As SqlCommand = New SqlCommand("spEmpresasPorUsuarioAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            cmd.Parameters.Add(_nUserID)

            Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
            _nEmpresa.Value = nEmpresa
            cmd.Parameters.Add(_nEmpresa)

            Dim _nStatus As New SqlParameter("@nStatus", SqlDbType.Bit)
            _nStatus.Value = nStatus
            cmd.Parameters.Add(_nStatus)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Function EmpresasPorUsuario(ByVal nUserID As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())

            DBCommand = New SqlDataAdapter("spEmpresasPorUsuario", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function List(ByVal strNombre As String, ByVal nStatus As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuariosList", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _strNombre As New SqlParameter("@strNombre", SqlDbType.NVarChar)
            _strNombre.Value = strNombre
            DBCommand.SelectCommand.Parameters.Add(_strNombre)

            Dim _nStatus As New SqlParameter("@nStatus", SqlDbType.Int)
            _nStatus.Value = nStatus
            DBCommand.SelectCommand.Parameters.Add(_nStatus)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Sub UsuarioMenuAdd(ByVal strUsuario As String, ByVal strMenu As String, ByVal strModulo As String, ByVal nTipo As Integer)

            Dim cmd As SqlCommand = New SqlCommand("spUsuarioMenuAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strUsuario As New SqlParameter("@strUsuario", SqlDbType.NVarChar)
            _strUsuario.Value = strUsuario
            cmd.Parameters.Add(_strUsuario)

            Dim _strMenu As New SqlParameter("@strMenu", SqlDbType.NVarChar)
            _strMenu.Value = strMenu
            cmd.Parameters.Add(_strMenu)

            Dim _strModulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _strModulo.Value = strModulo
            cmd.Parameters.Add(_strModulo)

            Dim _nTipo As New SqlParameter("@nTipo", SqlDbType.Int)
            _nTipo.Value = nTipo
            cmd.Parameters.Add(_nTipo)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Function Menu(ByVal nRolID As String, ByVal strMenuPadre As String, ByVal strModulo As String, ByVal strForm As String, _
                             ByVal strFormPadre As String) As DataSet

            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spMenuList", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nRolID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            Dim _strMenuPadre As New SqlParameter("@strMenuPadre", SqlDbType.NVarChar)
            _strMenuPadre.Value = strMenuPadre
            DBCommand.SelectCommand.Parameters.Add(_strMenuPadre)

            Dim _strModulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _strModulo.Value = strModulo
            DBCommand.SelectCommand.Parameters.Add(_strModulo)

            Dim _strForm As New SqlParameter("@strForm", SqlDbType.NVarChar)
            _strForm.Value = strForm
            DBCommand.SelectCommand.Parameters.Add(_strForm)

            Dim _strFormPadre As New SqlParameter("@strFormPadre", SqlDbType.NVarChar)
            _strFormPadre.Value = strFormPadre
            DBCommand.SelectCommand.Parameters.Add(_strFormPadre)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function UsuarioPorModulo(ByVal Modulo As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuariosPorModulo", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _Modulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _Modulo.Value = Modulo
            DBCommand.SelectCommand.Parameters.Add(_Modulo)

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Sub MenuAdd(ByVal nOrden As Integer, ByVal strMenu As String, ByVal strModulo As String, ByVal strData As String, _
                            ByVal nNivel As Integer, ByVal strMenuPadre As String)

            Dim cmd As SqlCommand = New SqlCommand("spCtrl_MenuAdd", DBConnGlobal)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nOrden As New SqlParameter("@nOrden", SqlDbType.NVarChar)
            _nOrden.Value = nOrden
            cmd.Parameters.Add(_nOrden)

            Dim _strMenu As New SqlParameter("@strMenu", SqlDbType.NVarChar)
            _strMenu.Value = strMenu
            cmd.Parameters.Add(_strMenu)

            Dim _strModulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _strModulo.Value = strModulo
            cmd.Parameters.Add(_strModulo)

            Dim _strData As New SqlParameter("@strData", SqlDbType.NVarChar)
            _strData.Value = strData
            cmd.Parameters.Add(_strData)

            Dim _nNivel As New SqlParameter("@nNivel", SqlDbType.Int)
            _nNivel.Value = nNivel
            cmd.Parameters.Add(_nNivel)

            Dim _strMenuPadre As New SqlParameter("@strMenuPadre", SqlDbType.NVarChar)
            _strMenuPadre.Value = strMenuPadre
            cmd.Parameters.Add(_strMenuPadre)

            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
        End Sub

        Public Function UsuarioMenu(ByVal Usuario As String, ByVal Modulo As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuarioMenu", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _Usuario As New SqlParameter("@Usuario", SqlDbType.NVarChar)
            _Usuario.Value = Usuario
            DBCommand.SelectCommand.Parameters.Add(_Usuario)

            Dim _Modulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _Modulo.Value = Modulo
            DBCommand.SelectCommand.Parameters.Add(_Modulo)

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function UsuarioNombre(ByVal Usuario As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuarioNombre", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _Usuario As New SqlParameter("@Usuario", SqlDbType.NVarChar)
            _Usuario.Value = Usuario
            DBCommand.SelectCommand.Parameters.Add(_Usuario)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()
            Return ds
        End Function

        Public Sub CambiarEmpresa(ByVal nUserID As Integer, ByVal nEmpresa As Integer)
            Dim DBConn As SqlConnection
            DBConn = New SqlConnection(funConexion())
            Dim cmd As SqlCommand = New SqlCommand("spCambiarEmpresa", DBConn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            cmd.Parameters.Add(_nUserID)

            Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
            _nEmpresa.Value = nEmpresa
            cmd.Parameters.Add(_nEmpresa)

            cmd.Connection = DBConn
            DBConn.Open()
            cmd.ExecuteNonQuery()
        End Sub

        Public Function UsuariosEmpresas() As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())

            DBCommand = New SqlDataAdapter("spUsuariosEmpresas", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function EmpresaActiva(ByVal strUser As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())

            DBCommand = New SqlDataAdapter("spEmpresaActiva", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nUserID As New SqlParameter("@nUserID", SqlDbType.Int)
            _nUserID.Value = nUserID
            DBCommand.SelectCommand.Parameters.Add(_nUserID)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function UsuarioModulos(ByVal Usuario As String, ByVal Modulo As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuarioModulos", DBConn)

            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _Usuario As New SqlParameter("@Usuario", SqlDbType.NVarChar)
            _Usuario.Value = Usuario
            DBCommand.SelectCommand.Parameters.Add(_Usuario)

            Dim _Modulo As New SqlParameter("@strModulo", SqlDbType.NVarChar)
            _Modulo.Value = Modulo
            DBCommand.SelectCommand.Parameters.Add(_Modulo)

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()

            Return ds
        End Function

        Public Function Login(ByVal Usuario As String, ByVal Password As String, ByVal nEmpresa As Integer, ByRef strMsj As String) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(funConexion())
            DBCommand = New SqlDataAdapter("spUsuarioLogin", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim _Usuario As New SqlParameter("@Usuario", SqlDbType.NVarChar)
            _Usuario.Value = Usuario
            DBCommand.SelectCommand.Parameters.Add(_Usuario)

            Dim _Password As New SqlParameter("@Password", SqlDbType.NVarChar)
            _Password.Value = Password
            DBCommand.SelectCommand.Parameters.Add(_Password)

            'Pasa el codigo del usuario
            Dim _nUsuario As SqlParameter = New SqlParameter("@nUsuario", SqlDbType.Int)
            _nUsuario.Direction = ParameterDirection.Output
            DBCommand.SelectCommand.Parameters.Add(_nUsuario)
            'Pasa el codigo de Area
            Dim _nArea As SqlParameter = New SqlParameter("@nArea", SqlDbType.Int)
            _nArea.Direction = ParameterDirection.Output
            DBCommand.SelectCommand.Parameters.Add(_nArea)
            'Pasa el nombre de Area
            Dim _strArea As SqlParameter = New SqlParameter("@strArea", SqlDbType.NVarChar, 50)
            _strArea.Direction = ParameterDirection.Output
            DBCommand.SelectCommand.Parameters.Add(_strArea)

            Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.NVarChar)
            _nEmpresa.Value = nEmpresa
            DBCommand.SelectCommand.Parameters.Add(_nEmpresa)

            Dim _nStatus As SqlParameter = New SqlParameter("@nStatus", SqlDbType.Int)
            _nStatus.Direction = ParameterDirection.Output
            DBCommand.SelectCommand.Parameters.Add(_nStatus)

            Dim _strMsj As SqlParameter = New SqlParameter("@strMsj", SqlDbType.NVarChar, 50)
            _strMsj.Direction = ParameterDirection.Output
            DBCommand.SelectCommand.Parameters.Add(_strMsj)

            'strMsjLogin = _msj.Value

            'Cerramos
            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()
            'Asignamos las variables
            'nUsuario = _nUsuario.Value.ToString
            'nArea = _nArea.Value.ToString
            'strArea = _strArea.Value.ToString

            If _nStatus.Value Is DBNull.Value Then
                intStatus = 0
            Else
                intStatus = _nStatus.Value.ToString
            End If

            If _nUsuario.Value Is DBNull.Value Then
                nUser = 0
            Else
                nUser = _nUsuario.Value.ToString
            End If

            If _nArea.Value Is DBNull.Value Then
                nDepto = 0
            Else
                nDepto = _nArea.Value.ToString
            End If

            If _nUsuario.Value Is DBNull.Value Then
                nUserID = 0
            Else
                nUserID = _nUsuario.Value
            End If

            strDepto = _strArea.Value.ToString
            strMsj = _strMsj.Value.ToString

            Return ds
        End Function

        Public Sub CambiarPassword(ByVal strLogin As String, ByVal strPassword As String)
            Dim DBConn As SqlConnection
            DBConn = New SqlConnection(funConexion())
            Dim cmd As SqlCommand = New SqlCommand("spCambiarPassword", DBConn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim _strLogin As New SqlParameter("@strLogin", SqlDbType.NVarChar)
            _strLogin.Value = strLogin
            cmd.Parameters.Add(_strLogin)

            Dim _strPassword As New SqlParameter("@strPassword", SqlDbType.NVarChar)
            _strPassword.Value = strPassword
            cmd.Parameters.Add(_strPassword)

            cmd.Connection = DBConn
            DBConn.Open()
            cmd.ExecuteNonQuery()
        End Sub

    End Class

End Namespace
