Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Partial Class gui_buscarArticulo
    Inherits System.Web.UI.UserControl

    Public Event BuscarClicked As EventHandler

    Protected Overridable Sub OnBuscarClick(sender As Object)
        RaiseEvent BuscarClicked(sender, New EventArgs())
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        funUpdateGrid()
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        funUpdateGrid()
        OnBuscarClick(sender)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Protected Sub gvwResultado_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwResultado.PageIndexChanging

    End Sub

    Protected Sub gvwResultado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvwResultado.SelectedIndexChanged

    End Sub

    Protected Sub funUpdateGrid()
        gvwResultado.DataSource = clsArticulos.funGetLista_Articulos(21)
        gvwResultado.DataBind()
    End Sub
End Class
