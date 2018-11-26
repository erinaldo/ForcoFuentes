Imports Microsoft.VisualBasic
Imports System.Uri

Public Class URLString

    Private _path As String
    Private _params As ArrayList

    Public Sub UpdateParameter(ByVal name As String, ByVal value As String)

        RemoveParameter(name)

        AddParameter(name, value)

    End Sub

    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property

    Public Sub RemoveParameter(ByVal name As String)
        Dim indexToRemove As Integer = -1
        For i As Integer = 0 To _params.Count - 1 Step +1
            Dim param As Parameter = _params(i)
            If param.name = name Then
                indexToRemove = i
                Exit For
            End If
        Next

        If indexToRemove >= 0 Then
            _params.RemoveAt(indexToRemove)
        End If
    End Sub

    Private Structure Parameter
        Public name As String
        Public value As String
    End Structure

    Public Sub New(ByVal pPath As String)
        Path = pPath
        _params = New ArrayList()
    End Sub

    Public Sub AddParameter(ByVal name As String, ByVal value As String)
        Dim param As Parameter

        If value <> "" Then
            value = Util.NameToParameter(value)
            param.name = name
            param.value = Util.NameToParameter(value)

            _params.Add(param)
        End If
    End Sub
    Public Function ParseURL() As String

        Dim url As String
        Dim param As Parameter

        url = Path
        If _params.Count > 0 Then
            url = String.Concat(url, "?")

            For Each param In _params
                url = String.Concat(url, param.name, "=", param.value)
                url = String.Concat(url, "&")
            Next

            url = url.Remove(url.LastIndexOf("&"), 1)
        End If

        url = Uri.EscapeUriString(url)

        Return url

    End Function

    Public Overrides Function ToString() As String
        Return ParseURL()
    End Function

End Class
