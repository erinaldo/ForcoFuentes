Public Class frmZoomImagen

    Private Sub frmZoomImagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Ptb_fotos.Image = Image.FromFile(codigo)
            Ptb_fotos.Refresh()
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Copiar_Click(sender As Object, e As EventArgs) Handles Copiar.Click
        Try
            Clipboard.SetImage(Ptb_fotos.Image)

            'Create a JPG on disk and add the location to the clipboard
            Dim TempName As String = "TempName.jpg"
            Dim TempPath As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, TempName)
            Using FS As New System.IO.FileStream(TempPath, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Read)
                Ptb_fotos.Image.Save(FS, System.Drawing.Imaging.ImageFormat.Jpeg)
            End Using
            Dim Paths As New System.Collections.Specialized.StringCollection()
            Paths.Add(TempPath)
            Clipboard.SetFileDropList(Paths)
        Catch ex As Exception

        End Try
    End Sub
End Class