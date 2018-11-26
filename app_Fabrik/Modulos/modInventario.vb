Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net

Module modInventario
    '-- 08/01/2009
    Public vnpFactura As Integer
    'Public vnpCode, vnpPieza, vnpMedida As Integer
    Public vcpClave, vcpData As String
    Public vnpCode, vnpGrueso, vnpAncho, vnpLargo As Double
    Public vnpCantidad, vnpPrecio, vnpTotal, vnpCantidadPT, vnpCantidadM3 As Double
    Public vnpTotalM3, vnpTotalPt As Double
    Public bolPrintTitulo As Boolean = True

    Function funNuevoMovInventario(ByVal vnConceptoInv As Integer)
        '-- Calcular el numero numero de documento del Movimiento de Inventario
        strSQL = "SELECT ISNULL(MAX(nNumero), 0) + 1 " &
                    "FROM Inv_Movto_Inventario " &
                    "WHERE nConcepto = " & vnConceptoInv &
                    " AND nEmpresa = " & intEmpresa
        '--
        Dim vnNumeroMovInv As Integer = funGetValor(strSQL)
        Return vnNumeroMovInv
    End Function

    'Function funNuevoOrden(ByVal vnOrden As Integer)
    '    '-- Calcular el numero numero de documento del Movimiento de Inventario
    '    strSQL = "SELECT ISNULL(MAX(nOrden), 0) + 1 " &
    '                "FROM Orden "
    '    '--
    '    Dim vnNumeroMovInv As Integer = funGetValor(strSQL)
    '    Return vnNumeroMovInv
    'End Function

    Function funNuevoReceta()
        '-- Calcular el numero numero de documento del Movimiento de Inventario
        strSQL = "SELECT ISNULL(MAX(nNumero), 0) + 1 " &
                    "FROM Pro_Receta " &
                    "WHERE nEmpresa = " & intEmpresa
        '--
        Dim vnNumeroMovInv As Integer = funGetValor(strSQL)
        Return vnNumeroMovInv
    End Function

    Function funNuevoMovInventarioPorEmpresa(ByVal vnConceptoInv As Integer,
                                             ByVal parEmpresa As Integer)
        '-- Calcular el numero numero de documento del Movimiento de Inventario
        strSQL = "SELECT ISNULL(MAX(nNumero), 0) + 1 " &
                    "FROM Inv_Movto_Inventario " &
                    "WHERE nConcepto = " & vnConceptoInv &
                    " AND nEmpresa = " & parEmpresa
        '--
        Dim vnNumeroMovInv As Integer = funGetValor(strSQL)
        Return vnNumeroMovInv
    End Function

    Function funNuevoOrden(ByVal parEmpresa As Integer)
        '-- 
        strSQL = "SELECT ISNULL(MAX(nOrden), 0) + 1 " &
                    "FROM Orden " &
                    "WHERE nEmpresa = " & intEmpresa
        '--
        Dim vnNumeroMovInv As Integer = funGetValor(strSQL)
        Return vnNumeroMovInv
    End Function

End Module
