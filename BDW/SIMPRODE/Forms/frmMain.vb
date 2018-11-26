Public Class frmMain

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim f As New frmDespachos
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ReImprimirPedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReImprimirPedidosToolStripMenuItem.Click
        Dim f As New frmDespachos_Re
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PorChequeadorAsignarToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ChequeadorRecibirToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EntregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregarToolStripMenuItem.Click
        Dim f As New frmDespacho_Alista
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub RecibirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibirToolStripMenuItem.Click
        Dim f As New frmDespacho_Alista
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub


End Class