Imports System.Data
Module modParametros

    Public Sub subConfiguraParametros()
        '-- Configura parametros
        Dim dtParametro As New DataTable
        dtParametro = TraerDatos("", , "*", "RecCobroParametro")
        If dtParametro.Rows.Count >= 1 Then
            With dtParametro
                bolPermiteRegFechaAnterior = .Rows(0)("bPermiteFechaAnterior")
                bolPermiteBotDebitoDirecto = .Rows(0)("bPermiteDebitoDirecto")
            End With
        End If
    End Sub
End Module
