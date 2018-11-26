Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.Script.Services
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<System.ComponentModel.ToolboxItem(False)>
Public Class WS_Forco
    Inherits System.Web.Services.WebService

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Day()
        '--
        Dim sql As String = "SELECT FORMATO, SUC_ID, SUC_NOMBRE, TOTAL FROM dbo.VTA_Ticket_Dia ORDER BY SUC_NOMBRE"
        '--
        Dim da As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("Connection").ToString())
        Dim ds As New DataSet()
        da.Fill(ds)
        '--
        Dim dt As DataTable = ds.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Day2(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Ventas_Day2_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_DayGrupoForco(ByVal parFormato As String, ByVal parCadena As String)
        '-- Similar a Ventas_Day2
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Ventas_Day2_Rep_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Mes()
        '--
        Dim sql As String = "SELECT FORMATO, SUC_ID, SUC_NOMBRE, TOTAL FROM dbo.VTA_Factura_Mes ORDER BY SUC_NOMBRE"
        '--
        Dim da As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("Connection").ToString())
        Dim ds As New DataSet()
        da.Fill(ds)
        '--
        Dim dt As DataTable = ds.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Mes2(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Ventas_Mes2_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_MesGrupoForco(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Ventas_Mes2_Rep_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Historia(ByVal parFecha As String)
        '-- Convertimos a fecha el parametro texto
        Dim oDate As Date = Convert.ToDateTime(parFecha)

        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Facturas_Historia"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(oDate, True)
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@fechacorte", SqlDbType.NVarChar, 11).Value = strRango1
        '--
        dsReporte = ExecuteCMD(CMD)
        '-
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Historia2(ByVal parFecha1 As String,
                                ByVal parFecha2 As String,
                                ByVal parFormato As String,
                                ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim oDate1 As Date = Convert.ToDateTime(parFecha1)
        Dim oDate2 As Date = Convert.ToDateTime(parFecha2)
        '--
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Facturas_Historia2"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(oDate1, True)
        Dim strRango2 As String = funFechaSql(oDate2, True)
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@fechacorte1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@fechacorte2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_HistoriaGrupoForco(ByVal parFecha1 As String,
                                ByVal parFecha2 As String,
                                ByVal parFormato As String,
                                ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim oDate1 As Date = Convert.ToDateTime(parFecha1)
        Dim oDate2 As Date = Convert.ToDateTime(parFecha2)
        '--
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Facturas_Historia2_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(oDate1, True)
        Dim strRango2 As String = funFechaSql(oDate2, True)
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@fechacorte1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@fechacorte2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Listado_Sucursales(ByVal parFormato As String)
        '--
        Dim strFormato As String = parFormato
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Lista_Sucursales"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        '--
        dsReporte = ExecuteCMD(CMD)
        '-
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Listado_SucursalesGrupoForco(ByVal parFormato As String)
        '--
        Dim strFormato As String = parFormato
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Lista_Sucursales_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        '--
        dsReporte = ExecuteCMD(CMD)
        '-
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Articulo_Existencia(ByVal parArticulo As String, ByVal parFormato As String)
        '--
        Dim strArticulo As String = parArticulo
        Dim strFormato As String = parFormato
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Articulo"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = strArticulo
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        '--
        dsReporte = ExecuteCMD(CMD)
        '-
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_TopDay(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_VentasTopDay_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_TopMes(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_VentasTopMes_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_TopMes_GF(ByVal parFormato As String, ByVal parCadena As String)
        '-- Convertimos a fecha el parametro texto
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_VentasTopMes_Rep_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ofertas(ByVal parCode As Integer)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_MC_Ofertas_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@code", SqlDbType.Int).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pending()
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pen_Pending"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)

        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Bajas_Mes_GF(ByVal parFormato As String, ByVal parCadena As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '-- 
        strProcedimiento = "sp_Apps_Vtas_Bajas_Mes_Rep_GF"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Ventas_Bajas_Mes(ByVal parFormato As String, ByVal parCadena As String)
        '-- 02-11-2017
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        '-- 
        strProcedimiento = "sp_Apps_Vtas_Bajas_Mes_Rep"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Presupuesto(ByVal parFormato As String,
                           ByVal parCadena As String,
                           ByVal parYear As Integer,
                           ByVal parMes As Integer)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '--
        Dim strFormato As String = parFormato
        Dim strCadena As String = parCadena
        Dim nYear As Integer = parYear
        Dim nMes As Integer = parMes
        '-- 
        strProcedimiento = "[sp_Apps_Presupuesto]"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 250).Value = strCadena
        CMD.Parameters.Add("@anno", SqlDbType.Int).Value = nYear
        CMD.Parameters.Add("@mes", SqlDbType.Int).Value = nMes
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Seguridad(ByVal parUsuario As String,
                           ByVal parClave As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '--
        Dim strUsuario As String = parUsuario
        Dim strClave As String = parClave
        '-- 
        strProcedimiento = "[sp_Apps_Seguridad]"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = strUsuario
        CMD.Parameters.Add("@clave", SqlDbType.NVarChar, 50).Value = strClave
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Listado_Sucursal_Usuario(ByVal parFormato As String,
                                        ByVal parSucursal As Integer)
        '--
        Dim strFormato As String = parFormato
        Dim intSucursal As Integer = parSucursal
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Apps_Lista_Sucursal_Usuario"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.NVarChar, 5).Value = strFormato
        CMD.Parameters.Add("@sucursal", SqlDbType.Int).Value = intSucursal
        '--
        dsReporte = ExecuteCMD(CMD)
        '-
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    '-- PositionApp
    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Articulos_List()
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Articulos_List"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)

        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Articulos_Buscar(ByVal parCode As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Articulos_Buscar"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Articulos_Buscar_BarCode(ByVal parCode As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Articulos_Buscar_BarCode"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Pasillo_List()
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Pasillo"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)

        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Posicion_List(ByVal parCode As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Posicion"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        '-- Cargar con timeout
        CMD.Parameters.Add("@pasillo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    Public Sub Pos_Mov_Guardar(ByVal parTipo As Integer,
                                 ByVal parCode As String,
                                 ByVal parCantidad As Integer,
                                 ByVal parUbicacion As String,
                                 ByVal parNivel As Integer)
        '-- 
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim constr As String = funConexion()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO POS_Movimientos (nTipo, cArticulo_Id, nCantidad, cUbicacion, nNivel) VALUES (@tipo, @articulo, @cantidad, @ubicacion, @nivel)")
                cmd.Parameters.AddWithValue("@tipo", parTipo)
                cmd.Parameters.AddWithValue("@articulo", parCode)
                cmd.Parameters.AddWithValue("@cantidad", parCantidad)
                cmd.Parameters.AddWithValue("@ubicacion", parUbicacion)
                cmd.Parameters.AddWithValue("@nivel", parNivel)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Pedidos_List()
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Pedidos_List"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)

        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    Public Sub Pos_Pedido_Head_Save(ByVal parPedido As Integer)
        '-- 
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim constr As String = funConexion()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO POS_Pedido_Encabezado (nPedido) VALUES (@pedido)")
                cmd.Parameters.AddWithValue("@pedido", parPedido)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        '--
    End Sub

    <WebMethod>
    Public Sub Pos_Pedido_Detail_Save(ByVal parPedido As Integer,
                                 ByVal parCode As String,
                                 ByVal parCantidad As Integer)
        '-- 
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim constr As String = funConexion()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO POS_Pedido_Detalle (nPedido, cArticulo_Id, nCantidad) VALUES (@pedido, @articulo, @cantidad)")
                cmd.Parameters.AddWithValue("@pedido", parPedido)
                cmd.Parameters.AddWithValue("@articulo", parCode)
                cmd.Parameters.AddWithValue("@cantidad", parCantidad)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Pedido_Get_New()
        '--
        Dim sql As String = "SELECT ISNULL(MAX(nPedido), 0) + 1 AS nPedido FROM dbo.POS_Pedido_Encabezado"
        '--
        Dim da As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("Connection").ToString())
        Dim ds As New DataSet()
        da.Fill(ds)
        '--
        Dim dt As DataTable = ds.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Pedido_Detalle_List(ByVal parPedido As Integer)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Pedido_Detalle_List"
        '--        
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@pedido", SqlDbType.Int).Value = parPedido
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Existencia_Pos_List(ByVal parCode As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "[sp_Pos_Existencia_Pos_List]"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    Public Sub Pos_Mov_Traslado_Guardar(ByVal parTipo As Integer,
                                 ByVal parCode As String,
                                 ByVal parCantidad As Integer,
                                 ByVal parUbicacion_Origen As String,
                                 ByVal parUbicacion_Destino As String,
                                 ByVal parPedido As Integer,
                                 ByVal parNivel_Origen As Integer,
                                 ByVal parNivel_Destino As Integer)
        '-- 
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        '-- parNivel_Origen = en la tabla es nNivel_Origen
        '-- parNivel_Destino = en la tabla es nNivel
        Dim constr As String = funConexion()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO POS_Movimientos (nTipo, cArticulo_Id, nCantidad, cUbicacion_Origen, cUbicacion, nPedido, nNivel_Origen, nNivel) VALUES (@tipo, @articulo, @cantidad, @ubicacion_origen, @ubicacion_destino, @pedido, @nivel_origen, @nivel_destino )")
                cmd.Parameters.AddWithValue("@tipo", parTipo)
                cmd.Parameters.AddWithValue("@articulo", parCode)
                cmd.Parameters.AddWithValue("@cantidad", parCantidad)
                cmd.Parameters.AddWithValue("@ubicacion_origen", parUbicacion_Origen)
                cmd.Parameters.AddWithValue("@ubicacion_destino", parUbicacion_Destino)
                cmd.Parameters.AddWithValue("@pedido", parPedido)
                cmd.Parameters.AddWithValue("@nivel_origen", parNivel_Origen)
                cmd.Parameters.AddWithValue("@nivel_destino", parNivel_Destino)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Pedidos_Alisto_List()
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Pedidos_Alisto_List"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)

        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    Public Sub Pos_Pedido_Update(ByVal parPedido As Integer,
                                 ByVal parCode As String)
        '-- 
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        '-- Estado actual es 1 para filtrar los pendientes
        '-- Estado Nuevo es 2 para marcar que ya fue entregado
        Dim estado_actual As Integer = 1
        Dim estado_nuevo As Integer = 2
        '--
        Dim constr As String = funConexion()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UPDATE POS_Pedido_Detalle SET nEstado = @estado_nuevo WHERE nPedido = @pedido AND cArticulo_Id = @articulo AND nEstado = @estado_actual")
                cmd.Parameters.AddWithValue("@pedido", parPedido)
                cmd.Parameters.AddWithValue("@articulo", parCode)
                cmd.Parameters.AddWithValue("@estado_actual", estado_actual)
                cmd.Parameters.AddWithValue("@estado_nuevo", estado_nuevo)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_ConsultaPorPasillo_List(ByVal parPasillo As String)
        '-- 
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "[sp_Pos_ConsultaPorPasillo_List]"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@pasillo", SqlDbType.NVarChar, 5).Value = parPasillo
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Existencia_Pos_List_CEDI(ByVal parCode As String)
        '-- Existencia y ubiacion del CEDI
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Existencia_Pos_List_CEDI"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Pos_Ubicacion_List_CEDI(ByVal parCode As String)
        '-- Existencia y ubiacion del CEDI
        Dim dsReporte As DataSet
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_Pos_Ubicacion_CEDI"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '-- Cargar con timeout
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = parCode
        '--
        dsReporte = ExecuteCMD(CMD)
        '--
        Dim dt As DataTable = dsReporte.Tables(0)
        '--
        Dim JSONresult As String
        JSONresult = JsonConvert.SerializeObject(dt)
        Context.Response.Write(JSONresult)
        '--
    End Sub

    Function ExecuteCMD(ByRef CMD As SqlCommand) As DataSet
        '--
        Dim connectionString As String = funConexion()
        Dim ds As New DataSet()
        Try
            Dim connection As New SqlConnection(connectionString)
            CMD.Connection = connection
            'Assume that it's a stored procedure command type if there is no space in the command text. Example: "sp_Select_Customer" vs. "select * from Customers"
            If CMD.CommandText.Contains(" ") Then
                CMD.CommandType = CommandType.Text
            Else
                CMD.CommandType = CommandType.StoredProcedure
            End If
            Dim adapter As New SqlDataAdapter(CMD)
            adapter.SelectCommand.CommandTimeout = 900
            'fill the dataset
            adapter.Fill(ds)
            connection.Close()
        Catch ex As Exception
            ' The connection failed. Display an error message.
            Throw New Exception("Database Error: " & ex.Message)
        End Try
        Return ds
    End Function
End Class