Imports System.Data
Imports MailHelper
Imports System.Security.Principal

Partial Class MasterCRM3

    Inherits System.Web.UI.MasterPage

    Public Property PageTitle() As String
        Get
            Return Me.lblTitle.Text
        End Get
        Set(ByVal value As String)
            Me.lblTitle.Text = value
        End Set
    End Property

    Public Property PageSubTitleVisible() As Boolean
        Get
            Return Me.lblUserName.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.lblUserName.Visible = value
        End Set
    End Property

    'Public Property ObtenerValidacionUsuario() As String
    '    Get
    '        Return True
    '    End Get
    '    Set(ByVal value As String)
    '        If GestorDatos.GetUsuarioActivo(value) Then
    '            Response.Redirect("~/frmAccessDenied.aspx")
    '        Else
    '            Me.ValidarBotones(value)
    '        End If
    '    End Set
    'End Property

    'Private Sub ValidarBotones(ByVal value As String)
    '    If GestorDatos.GetUsuarioPagina(value) Then
    '        'Me.btnMantenimientos.Visible = False
    '        'Me.mvMantenimientos.Visible = False
    '        'Me.btnMantenimientos.Visible = False
    '        'Me.btnMantenimientos.Visible = False
    '    End If
    'End Sub

    Dim strSQL As String
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Context.Request.Browser.Adapters.Clear()
        Dim ReqAdministrador As Boolean = False
        '-- Verifica los pendientes de usuarios
        'Dim cant As Integer = GetCantPendientesXUsuario(Me.Page.User.Identity.Name)
        'Dim dtPenditesVerificar As DataTable = GetPendientesAVerificar()
        'EscalarIncidente(dtPenditesVerificar)
        Dim cant As Integer = 0
        If cant > 0 Then
            Me.lblNotification.Text = Convert.ToString(cant)
        End If
        If Not IsPostBack Then
            Dim etiquetaUsuario As String = ""
            Select Case System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath)
                Case "Mensaje.aspx"
                    etiquetaUsuario = Me.Page.User.Identity.Name
                Case "frmMantenimientoUsuarios.aspx", "frmMantenimientoMaquinas.aspx"
                    ReqAdministrador = True
                    etiquetaUsuario = String.Concat(Me.Page.User.Identity.Name)
                Case Else
                    etiquetaUsuario = String.Concat(Me.Page.User.Identity.Name)
            End Select
            '-- OJO: Lo quite el 18/11/2016
            'Me.lblUserName.Text = etiquetaUsuario
            'Dim dt As DataTable
            'Dim esAdmin As Boolean = False
            'dt = GestorDatos.ObtenerRolUsuario(etiquetaUsuario)
            'For i As Integer = 0 To (dt.Rows.Count - 1)
            '    If dt.Rows(0)(1).ToString = "adming" Then
            '        esAdmin = True
            '    End If
            'Next
            'If esAdmin = False Then
            '    If ReqAdministrador Then
            '        Response.Redirect("~/frmBienvenida.aspx")
            '        'NavigationMenu.Items(4).Enabled = False
            '    End If
            'End If
        End If
        '-- GB (07-01-2017): 0btenemos el rol
        strSQL = String.Format("SELECT * FROM vw_GB_Usuarios WHERE Usuario_Login = '{0}';", Page.User.Identity.Name)
        '-- strSQL = "SELECT * FROM vw_GB_Usuarios WHERE Usuario_Login = '" & Me.Page.User.Identity.Name "'"
        '-- Cargamos el DS
        ds = clsForcoHelper.funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            If ds.Tables("Tabla").Rows(0)("nRol") = 1 Then
                '-- Administrador
                accion.Visible = True
                constancia.Visible = True
                cupon.Visible = True
                sumopen.Visible = True
                sumpago.Visible = True
            ElseIf ds.Tables("Tabla").Rows(0)("nRol") = 2 Then
                '-- Comprador
                accion.Visible = False
                constancia.Visible = False
                cupon.Visible = False
                sumopen.Visible = True
                sumpago.Visible = True
            Else
                '-- Pagador
                accion.Visible = False
                constancia.Visible = False
                cupon.Visible = False
                sumopen.Visible = False
                sumpago.Visible = True
            End If

        End If
    End Sub

    Protected Sub imgBtnPendientes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnPendientes.Click
        Response.Redirect("~/frmBuscarPendientes.aspx?flag=" & True)
    End Sub

    Protected Sub btnCerrarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarSesion.Click
        '-
        'lblUserName.Text = ""
        'FormsAuthentication.SignOut()
        'Session("NombreUsuario") = Nothing
        'FormsAuthentication.RedirectToLoginPage()
        '-
    End Sub
End Class






