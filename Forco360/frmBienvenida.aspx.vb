
Partial Class frmBienvenida

    Inherits PageCRM

#Region "Eventos"

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'CType(Me.Master, MasterCRM3).ObtenerValidacionUsuario = User.Identity.Name
            CType(Me.Master, MasterCRM3).PageTitle = ""
        End If
    End Sub
#End Region

#End Region

End Class
