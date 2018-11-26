Imports System.Data
Imports System.Data.SqlClient

Public Class clsCombos

    Public Shared Function funGetLkSegmentoConMov() As String
        '-- Cargar el combo de Segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT CS.nCode as nCodigo, CS.strEspanol as strDescripcion " & _
                    " FROM Cat_Segmento CS INNER JOIN v_Inv_MasterInventario VM ON " & _
                    " CS.nCode = VM.nG1Segmento " & _
                    " WHERE VM.nEmpresa = " & intEmpresa & _
                    " GROUP BY cs.nCode, cs.strEspanol"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkFamiliaConMov(nparSegmento As Integer) As String
        '-- Cargar el combo de Segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT  Cat_Familia.nCode AS nCodigo, Cat_Familia.strEspanol AS strDescripcion " & _
                    " FROM Cat_Familia " & _
                    " INNER JOIN v_Inv_MasterInventario ON Cat_Familia.nCode = v_Inv_MasterInventario.nG2Familia " & _
                    " AND Cat_Familia.nCodeSeg = v_Inv_MasterInventario.nG1Segmento " & _
                    " WHERE v_Inv_MasterInventario.nEmpresa = " & intEmpresa & _
                    " AND Cat_Familia.nCodeSeg = " & nparSegmento & _
                    " GROUP BY Cat_Familia.nCode, Cat_Familia.strEspanol"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkClaseConMov(nparSegmento As Integer, nparFamilia As Integer) As String
        '-- Cargar el combo de Segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT  Cat_Clase.nCode as nCodigo, Cat_Clase.strEspanol AS strDescripcion " & _
                    " FROM    Cat_Clase " & _
                    " INNER JOIN v_Inv_MasterInventario ON Cat_Clase.nCodeSeg = v_Inv_MasterInventario.nG1Segmento " & _
                    " AND Cat_Clase.nCodeFam = v_Inv_MasterInventario.nG2Familia " & _
                    " AND Cat_Clase.nCode = v_Inv_MasterInventario.nG3Clase " & _
                    " WHERE v_Inv_MasterInventario.nEmpresa = " & intEmpresa & _
                    " AND Cat_Clase.nCodeSeg = " & nparSegmento & _
                    " AND Cat_Clase.nCodeFam = " & nparFamilia & _
                    " GROUP BY Cat_Clase.nCode, Cat_Clase.strEspanol, v_Inv_MasterInventario.nEmpresa, Cat_Clase.nCodeSeg, Cat_Clase.nCodeFam"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkArticuloConMov(nparSegmento As Integer, nparFamilia As Integer, nparClase As Integer) As String
        '-- Cargar el combo de Segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT  Cat_Articulo.nCode AS nCodigo, Cat_Articulo.strEspanol AS strDescripcion " & _
                    " FROM    Cat_Articulo " & _
                    " INNER JOIN v_Inv_MasterInventario ON Cat_Articulo.nCodeSeg = v_Inv_MasterInventario.nG1Segmento " & _
                    " AND Cat_Articulo.nCodeFam = v_Inv_MasterInventario.nG2Familia " & _
                    " AND Cat_Articulo.nCodeClase = v_Inv_MasterInventario.nG3Clase " & _
                    " AND Cat_Articulo.nCode = v_Inv_MasterInventario.nG4Articulo " & _
                    " WHERE v_Inv_MasterInventario.nEmpresa = " & intEmpresa & _
                    " AND Cat_Articulo.nCodeSeg = " & nparSegmento & _
                    " AND Cat_Articulo.nCodeFam = " & nparFamilia & _
                    " AND Cat_Articulo.nCodeClase = " & nparClase & _
                    " GROUP BY Cat_Articulo.nCode, Cat_Articulo.strEspanol, v_Inv_MasterInventario.nEmpresa, " & _
                    " Cat_Articulo.nCodeSeg,Cat_Articulo.nCodeFam, Cat_Articulo.nCodeClase"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkSegmentoFull() As String
        '-- Cargar el combo de Segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        '--
        Return strSQL
        '--
    End Function


    Public Shared Function funGetLkFamiliaFull() As String
        '-- Cargar el combo de Segmento
        '-- Selecciono todos en el segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkClaseFull() As String
        '-- Cargar el combo de Segmento
        '-- Selecciono todos en el segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkArticuloFull() As String
        '-- Cargar el combo de Segmento
        '-- Selecciono todos en el segmento
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkConceptoInventarioAll() As String
        '-- Cargar el combo de conceptos de inventario
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT nCode AS nCodigo, strData AS strDescripcion " & _
                    " FROM Inv_Concepto"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkEmpresas() As String
        '-- Cargar Empresa y/o programas
        strSQL = "SELECT NCODE AS nCodigo, STRNOMBRE AS strDescripcion " & _
                    " FROM Gen_Empresas " & _
                    " ORDER BY NCODE"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkProveedorConMov() As String
        '-- Cargar el combo de conceptos de inventario
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT  Gen_Clientes.nPersona as nCodigo, Gen_Clientes.strFullName as strDescripcion " & _
                        " FROM Gen_Clientes " & _
                        " INNER JOIN v_Inv_MasterInventario AS vm ON Gen_Clientes.nPersona = vm.nOrigenDestino " & _
                        " WHERE vm.nConcepto = 5 " & _
                        " AND vm.nEmpresa = " & intEmpresa & _
                        " GROUP BY Gen_Clientes.nPersona, Gen_Clientes.strFullName"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkFamiliaAuxAll() As String
        '-- Cargar el combo de familia auxiliar
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT nCode AS nCodigo, strData AS strDescripcion " & _
                    " FROM Cat_Familia2"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkDependenciaAll() As String
        '-- Cargar el combo de dependecias
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT nCode as nCodigo, strData as strDescripcion " & _
                        " FROM Cat_Est4Dependencia " & _
                        " WHERE nPrograma = " & intEmpresa
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkYearAll() As String
        '-- Cargar el combo de dependecias
        strSQL = "SELECT nID AS nCodigo, strDescripcion AS strDescripcion FROM TablaDeTablas " & _
                    " WHERE nCodTbl = 112 AND nEstatus = 1 AND nEmpresa = " & intEmpresa
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkEmpresaAll() As String
        '-- Cargar el combo de dependecias
        strSQL = "SELECT NCODE AS nCodigo, STRNOMBRE AS strDescripcion " & _
                    " FROM Gen_Empresas " & _
                    " ORDER BY NCODE"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkTipoConceptoSalida() As String
        '-- Cargar el combo de dependecias
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " & _
                    " FROM Inv_Concepto " & _
                    " WHERE nCode IN(11,12)"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetProductoConMov(nparEmpresa As Integer) As String
        '-- Productos con movimientos
        'strSQL = "SELECT  a.strClave as nCodigo, a.strData as strDescripcion " & _
        '            " FROM    Inv_Producto a " & _
        '            " INNER JOIN v_Inv_MasterInventario b ON a.nCode = b.nCode " & _
        '            " WHERE nEmpresa = " & intEmpresa
        '--
        strSQL = "SELECT  a.strClave AS nCodigo, a.strData AS strDescripcion " & _
                    " FROM    Inv_Producto a " & _
                    " INNER JOIN v_Inv_MasterInventario b ON a.nCode = b.nCode " & _
                    " WHERE b.nEmpresa = " & intEmpresa & _
                    " GROUP BY a.strClave, a.strData"
        '--
        Return strSQL
        '--
    End Function

    Public Shared Function funGetLkActividadAll() As String
        '-- Cargar el combo de dependecias
        strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
        strSQL += " UNION SELECT nCode as nCodigo, strData as strDescripcion " & _
                        " FROM Cat_Est3Actividad " & _
                        " WHERE nPrograma = " & intEmpresa
        '--
        Return strSQL
        '--
    End Function
End Class
