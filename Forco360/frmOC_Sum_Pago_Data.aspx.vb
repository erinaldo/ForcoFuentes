Imports System.IO
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

    Private Sub InitialInformation()
        '-- Validamos la variable de session, en el futuro usar cross post
        If Request.Params("nOrden") IsNot Nothing Then
            funCargaCombos()
            funCargaData()
        End If
    End Sub
    Private Sub funCargaCombos()
        '-- Estados
        dt = clsOrdenCompra.funGetLista_Estado_Solicitud_Pago()
        Me.LoadDropDownList(Me.lkEstado, dt, dt.Columns(0).ColumnName, dt.Columns(1).ColumnName)
        '--
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Metodo
            CType(Me.Master, MasterCRM3).PageTitle = ":: Solicitud Pago de Suministros - Solicitar ::"
            Me.InitialInformation()
            '--
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
        With Me.gvActual
            .DataKeyNames = New String() {"Detalle_Id"}
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Private Sub funUpdateGrid_Auto()
        '-- 
        dt = clsOrdenCompra.funGetLista_Orden_Compra_Detalle_LD(txtOrden.Text)
        With Me.gvAuto
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
            Me.lkEstado.SelectedValue = ds.Tables("Tabla").Rows(0)("nPago_Status")
            If Me.lkEstado.SelectedValue >= 2 Then
                Me.btnSolicita.Visible = False
            End If
            '-- Cargar el Grid
            Me.funUpdateGrid()
            Me.funUpdateGrid_Auto()
            Me.funUpdateGridPicture()
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Protected Sub upload_Click(sender As Object, e As EventArgs)
        Try
            Dim filename As String = Path.GetFileName(fileupload.PostedFile.FileName)
            Dim image As String = Convert.ToString("Images/") & filename
            fileupload.SaveAs(Server.MapPath(Convert.ToString("~/Images/") & filename))
            funGuardar(filename, image)
            'con = New SqlConnection(connStr)
            'con.Open()
            'cmd = New SqlCommand("insert into Image_Details (ImageName,Image) values(@ImageName,@Image)", con)
            'cmd.Parameters.AddWithValue("@ImageName", filename)
            'cmd.Parameters.AddWithValue("@Image", Convert.ToString("Images/") & filename)
            'cmd.ExecuteNonQuery()
            'ImageData()
            funUpdateGridPicture()
        Catch ex As Exception
            upload.Text = ex.Message
        End Try
    End Sub

    Dim intTipoRegistro As Integer
    Dim strLlave As String
    Protected Sub funGuardar(ByVal filename As String, ByVal Image As String)
        clsForcoHelper.AbrirConexionGlobal()
        Try
            Session("nOrden") = Request.Params("nOrden").ToString
            '-- Datos de la imagen
            Dim dsAgregar As DataSet = clsOrdenCompra.funGet_Imagen(Session("nOrden"), vnCodigo)
            '--
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                funNuevoNumero()
                dsAgregar.Tables("Tabla").Rows.Add()
            End If
            '--
            With dsAgregar.Tables("Tabla").Rows(0)
                '-- Tomamos el nRecno
                Dim vnRecno = clsForcoHelper.funNull2Val(.Item("ImageId"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                intTipoRegistro = IIf(clsForcoHelper.funNull2Val(.Item("ImageId")) = 0, 1, 2)
                '--
                If intTipoRegistro = 1 Then
                    '-- Agregando
                    'clsForcoHelper.funAddCampo("ImageId", vnCodigo, vnCodigo)
                    clsForcoHelper.funAddCampo("nOrden", Session("nOrden"), "")
                    clsForcoHelper.funAddCampo("ImageName", filename, "")
                    clsForcoHelper.funAddCampo("Image", Image, "")
                End If
                '-- Definimos la llave
                strLlave = " nOrden = " & Session("nOrden") & " " &
                            "AND ImageId = " & vnCodigo
                '-- Pasamos los parametros de grabación
                clsForcoHelper.funParametrosGrabacionTransaccion("Image_Details", strLlave, intTipoRegistro, vnRecno)
                '--
                clsForcoHelper.transaccionGlobal.Commit()
                clsForcoHelper.DBConnGlobal.Close()
            End With
        Catch ex As Exception
            clsForcoHelper.LimpiarCampos()
            clsForcoHelper.transaccionGlobal.Rollback()
            clsForcoHelper.DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Dim vnCodigo As Integer
    Protected Sub funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(ImageId), 0) + 1 FROM Image_Details"
        '--
        vnCodigo = clsForcoHelper.funGetValor(strSQL)
    End Sub

    Protected Sub funUpdateGridPicture()
        '-- 
        dt = clsOrdenCompra.funGetLista_Orden_Compra_Picture_LD(txtOrden.Text)
        With Me.gvImage
            .EmptyDataText = "Actualmente no existen registros"
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/frmOC_Sum_Pago_Open.aspx")
    End Sub
    Protected Sub btnSolicita_Click(sender As Object, e As EventArgs) Handles btnSolicita.Click
        '-- Autoriza status
        funUpdate_Solicita()
        '-- Desactivamos boton
        Me.btnSolicita.Visible = False
        funCargaCombos()
        funCargaData()
    End Sub

    Protected Sub funUpdate_Solicita()
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
        Dim vnPago_Stauts As Integer = 2
        '--
        strSQL = String.Format("UPDATE Orden_Local_Encabezado SET nPago_Status={0}, dtmFecha_SolPago='{1}', " &
                                    "nUsuario_SolPago={2}, strUsuario_SolPago='{3}' WHERE Emp_ID ={4} AND Suc_Id ={5} AND Orden_Id={6}",
                                    vnPago_Stauts, clsForcoHelper.funFechaSql(varToday, True), vnUsuario, Page.User.Identity.Name, 1, 1001, Session("nOrden"))
        '--
        clsForcoHelper.funRunSQLTransaccion(strSQL)
        '--
        clsForcoHelper.transaccionGlobal.Commit()
        clsForcoHelper.DBConnGlobal.Close()
    End Sub
    Protected Sub gvImage_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvImage.RowCancelingEdit

    End Sub
    Protected Sub gvImage_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvImage.RowDeleting

    End Sub
    Protected Sub gvImage_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvImage.RowEditing

    End Sub
    Protected Sub gvImage_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvImage.RowUpdating

    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Session("Editando") = Nothing
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub

End Class
