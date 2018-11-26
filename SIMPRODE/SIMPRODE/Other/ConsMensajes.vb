Public Class ConsMensajes
    Public Const SUCCESS As String = "Accion Exitosa."
    Public Const FAILURE As String = "Accion No Exitosa: "
    Public Const NOT_ALLOWED As String = "Usted no esta habilitado para ejecutar esta accion."
    Public Const FORMAT_NOT_SUPPORTED As String = "El formato no esta soportado."
    Public Const NO_MATCHES_FOUND As String = "No hay correspondencias para los valores suministrados."

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
