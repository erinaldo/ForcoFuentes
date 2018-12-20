Imports System.Data
Imports System.Data.SqlClient

Public Class clsSucursal

    Public Shared Function funListaSucursal() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " &
                    "Suc_Id, " &
                    "Suc_Nombre " &
                    "FROM dbo.Sucursal ORDER BY Suc_Nombre"

        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

    Public Shared Function funListaSucursal_Shoppers() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " &
                    "Suc_Id, " &
                    "Suc_Nombre " &
                    "FROM dbo.Sucursal WHERE Suc_Id = 801 ORDER BY Suc_Nombre"

        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

    Public Shared Function funListaSucursal2() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " &
                    "Suc_Id, " &
                    "Suc_Nombre " &
                    "FROM dbo.Sucursal WHERE Suc_Id = 1100 ORDER BY Suc_Nombre"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

    Public Shared Function funListaSucursalSinCEDI() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " &
                    "Suc_Id, " &
                    "Suc_Nombre " &
                    "FROM dbo.Sucursal " &
                    "WHERE Suc_Id <> 1001 " &
                    "ORDER BY Suc_Nombre"

        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

End Class
