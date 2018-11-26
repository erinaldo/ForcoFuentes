Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports clsEmpleado
Imports Util
Imports DevExpress.Web

Partial Class frmOC_Detalle

    Inherits System.Web.UI.Page

    Dim strSQL As String
    Dim Mensaje As String
    Dim strScript As String
    Dim sDS As SqlDataSource
    Dim strUsuario As String = Me.Page.User.Identity.Name
    Dim ds As DataSet
    Dim dt As DataTable
    Dim strNombreEmpleado As String
    '-- datos
    Dim vnTipo As Integer
    Dim vnTipoSub As Integer
    Dim vnStatus As Integer
    Dim varToday As Date
    Dim vnUsuario As Integer
    Public vdFecha_Ini As Date

    Private Sub InitialInformation()
        '-- Validamos la variable de session, en el futuro usar cross post
        If Request.Params("nOrden") IsNot Nothing Then
            funCargaCombos()
            funCargaData()
        End If
    End Sub
    Private Sub funCargaCombos()
        '-- Estados
        dt = clsOrdenCompra.funGetLista_Estado_Solicitud_Compra()
        Me.LoadDropDownList(Me.lkEstado, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
        '--
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Orden de Compra de Suministros - Autorización ::"
            Me.InitialInformation()
        End If
    End Sub
    Private Sub LoadDropDownList(ByVal cDropDownList As DropDownList, ByVal dt As DataTable, ByVal strDataValueField As String, ByVal strDataTextField As String)
        For i As Integer = 0 To dt.Columns.Count - 1
            For i2 As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i2)(i) IsNot DBNull.Value Then
                    dt.Rows(i2)(i) = dt.Rows(i2)(i).ToString.ToUpper
                End If
            Next
        Next
        With cDropDownList
            .DataSource = dt
            .DataValueField = strDataValueField
            .DataTextField = strDataTextField
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub funUpdateGrid()
        '-- 
        dt = clsOrdenCompra.funGetLista_Orden_Compra_Detalle_LD(txtOrden.Text)
        With Me.gvContactos
            .DataKeyNames = New String() {"Detalle_Id"}
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Private Sub funCargaData()
        '-- Variable de session
        Session("nOrden") = Request.Params("nOrden").ToString
        '-- Filtramos el registro
        strSQL = "SELECT * FROM vw_GB_CL_Encabezado WHERE Orden_Id = " & Session("nOrden")
        '-- Cargamos el DS
        ds = clsForcoHelper.funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.txtOrden.Text = Session("nOrden")
            Me.txtSolicita.Text = ds.Tables("Tabla").Rows(0)("Usuario_Crea").ToString
            Me.txtFecha.Text = String.Format("{0:d}", ds.Tables("Tabla").Rows(0)("Orden_Fecha_Crea"))
            Me.txtNotas.Text = ""
            Me.txtProveedor.Text = ds.Tables("Tabla").Rows(0)("Prov_Nombre").ToString
            Me.txtProv_Cedula.Text = ds.Tables("Tabla").Rows(0)("Prov_Cedula").ToString
            Me.txtProv_Correo.Text = ds.Tables("Tabla").Rows(0)("Prov_Email").ToString
            Me.txtProv_Direccion.Text = ds.Tables("Tabla").Rows(0)("Prov_Direccion").ToString
            Me.txtProv_Telefono.Text = ds.Tables("Tabla").Rows(0)("Prov_Telefono").ToString
            Me.txtProv_Cuenta.Text = ""
            Me.txtSubTotal.Text = String.Format("{0:0,0.00}", ds.Tables("Tabla").Rows(0)("Orden_Costo_Bruto"))
            Me.txtDescuento.Text = String.Format("{0:0,0.00}", ds.Tables("Tabla").Rows(0)("Orden_Descuento"))
            Me.txtImpuesto.Text = String.Format("{0:0,0.00}", ds.Tables("Tabla").Rows(0)("Orden_Impuesto"))
            Me.txtTotal.Text = String.Format("{0:0,0.00}", ds.Tables("Tabla").Rows(0)("Orden_Costo_Neto"))
            Me.lkEstado.SelectedValue = ds.Tables("Tabla").Rows(0)("nCompra_Status")
            If Me.lkEstado.SelectedValue = 2 Or lkEstado.SelectedValue = 3 Or lkEstado.SelectedValue = 4 Then
                Me.btnAutorizar.Visible = False
                Me.btnRechazar.Visible = False
            End If
            '-- Cargar el Grid
            Me.funUpdateGrid()
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Protected Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        '-- Autoriza status
        funUpdate_Autoriza()
        '-- Desactivamos boton
        Me.btnAutorizar.Visible = False
        funCargaCombos()
        funCargaData()
    End Sub
    Protected Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        '-- Autoriza status
        funUpdate_Rechaza()
        '-- Desactivamos boton
        Me.btnRechazar.Visible = False
        funCargaCombos()
        funCargaData()
    End Sub

    Protected Sub funUpdate_Autoriza()
        '-- Obtenemos la fecha de hoy
        varToday = clsForcoHelper.funFechaServer()
        '-- Obtenemos el Usuario_Id
        ds = clsUsuario.funGet_Usuario_Id(Page.User.Identity.Name)
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            vnUsuario = ds.Tables("Tabla").Rows(0)("Usuario_Id").ToString
        End If
        '-- Iniciamos actualizacion
        clsForcoHelper.AbrirConexionGlobal()
        Session("nOrden") = Request.Params("nOrden").ToString
        Dim vnCompra_Stauts As Integer = 2
        '--
        strSQL = String.Format("UPDATE Orden_Local_Encabezado SET nCompra_Status={0}, dtmFecha_Auto='{1}', " &
                                    "nUsuario_Auto={2}, strUsuario_Auto='{3}' WHERE Emp_ID ={4} AND Suc_Id ={5} AND Orden_Id={6}",
                                    vnCompra_Stauts, clsForcoHelper.funFechaSql(varToday, True), vnUsuario, Page.User.Identity.Name, 1, 1001, Session("nOrden"))
        '--
        clsForcoHelper.funRunSQLTransaccion(strSQL)
        '-- insertamos la copia de los registros autorizados
        strSQL = "INSERT INTO Orden_Local_Detalle_Auto SELECT * FROM dbo.Orden_Local_Detalle" &
                    " WHERE Emp_Id = 1 " &
                    " AND Suc_Id = 1001 " &
                    " AND Orden_Id = " & Session("nOrden")
        '--
        clsForcoHelper.funRunSQLTransaccion(strSQL)
        '--
        clsForcoHelper.transaccionGlobal.Commit()
        clsForcoHelper.DBConnGlobal.Close()
    End Sub

    Protected Sub funUpdate_Rechaza()
        '-- Obtenemos la fecha de hoy
        varToday = clsForcoHelper.funFechaServer()
        '-- Obtenemos el Usuario_Id
        ds = clsUsuario.funGet_Usuario_Id(Page.User.Identity.Name)
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            vnUsuario = ds.Tables("Tabla").Rows(0)("Usuario_Id").ToString
        End If
        '-- Iniciamos actualizacion
        clsForcoHelper.AbrirConexionGlobal()
        Session("nOrden") = Request.Params("nOrden").ToString
        Dim vnCompra_Stauts As Integer = 3
        '--
        strSQL = String.Format("UPDATE Orden_Local_Encabezado SET nCompra_Status={0}, dtmFecha_Auto='{1}', " &
                                    "nUsuario_Auto={2}, strUsuario_Auto='{3}' WHERE Emp_ID ={4} AND Suc_Id ={5} AND Orden_Id={6}",
                                    vnCompra_Stauts, clsForcoHelper.funFechaSql(varToday, True), vnUsuario, Page.User.Identity.Name, 1, 1001, Session("nOrden"))
        '--
        clsForcoHelper.funRunSQLTransaccion(strSQL)
        '--
        clsForcoHelper.transaccionGlobal.Commit()
        clsForcoHelper.DBConnGlobal.Close()
    End Sub


    Protected Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Session("Editando") = Nothing
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Session("Editando") = 1
        Response.Redirect("~/frmOC_Sum_Open.aspx")
    End Sub
End Class
