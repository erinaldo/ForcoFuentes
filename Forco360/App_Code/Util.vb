Imports Microsoft.VisualBasic
Imports System.Web.UI.WebControls
Imports Dundas.Charting.WebControl
Imports System.IO
Imports System.Uri
Imports System.Configuration
Imports System.Data

Public Class Util

    Public Shared vFechaSelect As Date

    Private Const _ampersand As String = "__ampersand__"
    Public Const _Dominio As String = "ALPISTE"
    Public Const _All As String = "[All]"
    Public Const _Todos As String = "[Todos]"
    Public Const _Seleccione As String = "-- Seleccionar Opción --"
    Public Const _comparativeCommandId As Integer = 400
    Public Const NumberFormat As String = "{0:#,#}"
    Public Const DecimalFormat As String = "{0:#,#.##}"
    Public Const NumberFormatMil As String = "{0:#,#,}"
    Public Const PercentageFormat As String = "{0:#,#.00%}"
    Public Shared Semana As String = "Semana"
    Public Shared Number1 As String = "{0:N0}"
    Public Shared Total As String = "Total"
    Public Shared Cien As String = "100%"
    Public Shared Separador As String = " - "

    '' TIPOS DE USUARIOS
    '' 0 - Administrador General
    '' 1 - Administrador Regional
    '' 2 - Gerente
    '' 3 - Consultor
    '' 4 - Consultor BD
    '' 5 - Agendadora

    Public Const _NivelAdmin_General As String = "0"
    Public Const _NivelAdmins As String = "0-1"
    Public Const _NivelAdmin_Gerente As String = "0-1-2"
    Public Const _NivelAdmin As String = "1"
    Public Const _NivelGerente As String = "2"
    Public Const _NivelAgendador As String = "3"
    Public Const _NivelConsultores As String = "4-5"

    ' TIPOS DE ACTIVIDAD
    Public Const _Tipo_Actividad_Evento As String = "1"

    ' TIPOS DE ESTADO
    Public Const _Tipo_Estado_Activos As String = "1"
    Public Const _Tipo_Estado_Muestras As String = "2"
    Public Const _Tipo_Estado_Pendientes As String = "3"

    ''Enumeración de los meses 
    Public Enum enumMeses

        Enero = 1
        Febrero = 2
        Marzo = 3
        Abril = 4
        Mayo = 5
        Junio = 6
        Julio = 7
        Agosto = 8
        Setiembre = 9
        Octubre = 10
        Noviembre = 11
        Diciembre = 12

    End Enum

    Public Shared Edicion_AgendaActividad As Boolean
    Public Shared EdicionFecha As Date
    Public Shared EdicionView As Integer
    Public Shared ModifPaisAgendadora As String = ""
    Public Shared ModifZonaAgendadora As String = ""
    Public Shared ModifUsuarioAgendadora As String = ""

    Public Overloads Shared Function IsNull(ByVal arg As Object, ByVal returnIfEmpty As String) As String

        Dim returnValue As String

        If (arg Is DBNull.Value) OrElse (arg Is Nothing) OrElse (arg Is String.Empty) Then
            returnValue = returnIfEmpty

        Else

            Try

                returnValue = CStr(arg)

            Catch

                returnValue = returnIfEmpty

            End Try

        End If

        Return returnValue

    End Function

    Shared Function toStringMes(ByVal Mes As enumMeses) As String

        Dim mesnombre As String = ""

        Select Case Mes

            Case enumMeses.Enero

                mesnombre = "Enero"

            Case enumMeses.Febrero

                mesnombre = "Febrero"

            Case enumMeses.Marzo

                mesnombre = "Marzo"

            Case enumMeses.Abril

                mesnombre = "Abril"

            Case enumMeses.Mayo

                mesnombre = "Mayo"

            Case enumMeses.Junio

                mesnombre = "Junio"

            Case enumMeses.Julio

                mesnombre = "Julio"

            Case enumMeses.Agosto

                mesnombre = "Agosto"

            Case enumMeses.Setiembre

                mesnombre = "Setiembre"

            Case enumMeses.Octubre

                mesnombre = "Octubre"

            Case enumMeses.Noviembre

                mesnombre = "Noviembre"

            Case enumMeses.Diciembre

                mesnombre = "Diciembre"

        End Select

        Return mesnombre

    End Function

    Shared Function ValidarStringDBNull(ByVal dt As DataTable, ByVal intRow As Integer, _
ByVal NameColumn As String, ByVal strNull As String) As String

        Dim dato As String

        If (dt.Rows.Count - 1) >= 0 Then

            If dt.Rows(intRow)(NameColumn) IsNot DBNull.Value Then

                dato = dt.Rows(intRow)(NameColumn).ToString

            Else

                dato = strNull

            End If

        Else

            dato = strNull

        End If

        Return dato

    End Function


    Public Shared Function DecToHex(ByVal DecNum As Double) As String

        Dim remainder As Integer
        Dim HexStr As String = ""

        Do While DecNum <> 0

            remainder = DecNum Mod 16

            If remainder <= 9 Then

                HexStr = Chr(Asc(remainder)) & HexStr

            Else

                HexStr = Chr(Asc("A") + remainder - 10) & HexStr
            End If

            DecNum = DecNum \ 16

        Loop

        If HexStr = "" Then HexStr = "00"

        DecToHex = HexStr

    End Function

    Public Shared Function ReturnEmptyStringIfDbNull(ByRef sqlVar As Object) As String

        Dim ret As String

        If TypeOf sqlVar Is DBNull Then

            ret = String.Empty

        Else

            ret = CStr(sqlVar)

        End If

        Return ret

    End Function

    Public Shared Function ReturnEmptyStringIfNull(ByRef var As String) As String

        Dim ret As String

        If var Is Nothing Then

            ret = String.Empty

        Else

            ret = var

        End If

        Return ret

    End Function

    Public Shared Sub ReplaceString(ByRef stringToReplace As String, ByVal oldValue As String,
    ByVal newValue As String)

        stringToReplace = Strings.Replace(stringToReplace, oldValue, newValue, 1, -1, Microsoft.VisualBasic.CompareMethod.Text)

    End Sub

    Shared Function ValidateSelection(ByVal ddList As DropDownList, ByVal allItem As String) As String
        Dim value As String

        value = ddList.SelectedValue
        If value = allItem Then
            value = ""
        End If

        Return value
    End Function

    Shared Function ValidateStringURLValue(ByVal StringURLValue As String) As String

        StringURLValue = StringURLValue.Replace("&", "@_")

        Return StringURLValue

    End Function

    Shared Function ValidateURLValue(ByVal StringURL As String) As String

        StringURL = StringURL.Replace("@_", "&")

        Return StringURL

    End Function

    Shared Function NameToParameter(ByVal name As String) As String
        Dim parameter As String

        If name Is Nothing Then
            parameter = ""
        Else
            parameter = HttpUtility.HtmlDecode(name)
            parameter = parameter.Replace("&", _ampersand)
        End If

        Return parameter
    End Function

    Shared Function ParameterToName(ByVal parameter As String) As String
        Dim name As String

        If parameter Is Nothing Then
            name = ""
        Else
            name = parameter.Replace(_ampersand, "&")
            name = Uri.UnescapeDataString(name)
        End If

        Return name
    End Function

    Shared Function GetMonthQuarter(ByVal month As Integer) As Integer
        Dim quarter As Integer

        If month >= 1 And month <= 3 Then
            quarter = 1
        ElseIf month >= 4 And month <= 6 Then
            quarter = 2
        ElseIf month >= 7 And month <= 9 Then
            quarter = 3
        Else
            quarter = 4
        End If

        Return quarter
    End Function

    Shared Function GetMonthQuarter(ByVal month As String) As String

        Dim quarter As String

        If month = "January" Or month = "Enero" Or month = "1" Or month = "01" Then

            quarter = "1"

        ElseIf month = "February" Or month = "Febrero" Or month = "2" Or month = "02" Then

            quarter = "1"

        ElseIf month = "March" Or month = "Marzo" Or month = "3" Or month = "03" Then

            quarter = "1"

        ElseIf month = "April" Or month = "Abril" Or month = "4" Or month = "04" Then

            quarter = "2"

        ElseIf month = "May" Or month = "Mayo" Or month = "5" Or month = "05" Then

            quarter = "2"

        ElseIf month = "June" Or month = "Junio" Or month = "6" Or month = "06" Then

            quarter = "2"

        ElseIf month = "July" Or month = "Julio" Or month = "7" Or month = "07" Then

            quarter = "3"

        ElseIf month = "August" Or month = "Agosto" Or month = "8" Or month = "08" Then

            quarter = "3"

        ElseIf month = "September" Or month = "Septiembre" Or month = "9" Or month = "09" Then

            quarter = "3"

        ElseIf month = "October" Or month = "Octubre" Or month = "10" Then

            quarter = "4"

        ElseIf month = "November" Or month = "Noviembre" Or month = "11" Then

            quarter = "4"

        ElseIf month = "December" Or month = "Diciembre" Or month = "12" Then

            quarter = "4"

        Else

            quarter = "1"

        End If

        Return quarter

    End Function

    Shared Function GetMonthValue(ByVal month As String) As String

        Dim stringMonth As String

        If month = "January" Or month = "Enero" Or month = "1" Or month = "01" Then

            stringMonth = "1"

        ElseIf month = "February" Or month = "Febrero" Or month = "2" Or month = "02" Then

            stringMonth = "2"

        ElseIf month = "March" Or month = "Marzo" Or month = "3" Or month = "03" Then

            stringMonth = "3"

        ElseIf month = "April" Or month = "Abril" Or month = "4" Or month = "04" Then

            stringMonth = "4"

        ElseIf month = "May" Or month = "Mayo" Or month = "5" Or month = "05" Then

            stringMonth = "5"

        ElseIf month = "June" Or month = "Junio" Or month = "6" Or month = "06" Then

            stringMonth = "6"

        ElseIf month = "July" Or month = "Julio" Or month = "7" Or month = "07" Then

            stringMonth = "7"

        ElseIf month = "August" Or month = "Agosto" Or month = "8" Or month = "08" Then

            stringMonth = "8"

        ElseIf month = "September" Or month = "Septiembre" Or month = "9" Or month = "09" Then

            stringMonth = "9"

        ElseIf month = "October" Or month = "Octubre" Or month = "10" Then

            stringMonth = "10"

        ElseIf month = "November" Or month = "Noviembre" Or month = "11" Then

            stringMonth = "11"

        ElseIf month = "December" Or month = "Diciembre" Or month = "12" Then

            stringMonth = "12"

        Else

            stringMonth = "1"

        End If

        Return stringMonth

    End Function

    Shared Function GetMonthName(ByVal month As String, Optional ByVal lenguage As String = "I") As String

        Dim stringMonth As String

        If month = "January" Or month = "Enero" Or month = "1" Or month = "01" Then

            If lenguage = "I" Then

                stringMonth = "January"

            Else

                stringMonth = "Enero"

            End If

        ElseIf month = "February" Or month = "Febrero" Or month = "2" Or month = "02" Then

            If lenguage = "I" Then

                stringMonth = "February"

            Else

                stringMonth = "Febrero"

            End If

        ElseIf month = "March" Or month = "Marzo" Or month = "3" Or month = "03" Then

            If lenguage = "I" Then

                stringMonth = "March"

            Else

                stringMonth = "Marzo"

            End If

        ElseIf month = "April" Or month = "Abril" Or month = "4" Or month = "04" Then

            If lenguage = "I" Then

                stringMonth = "April"

            Else

                stringMonth = "Abril"

            End If

        ElseIf month = "May" Or month = "Mayo" Or month = "5" Or month = "05" Then

            If lenguage = "I" Then

                stringMonth = "May"

            Else

                stringMonth = "Mayo"

            End If

        ElseIf month = "June" Or month = "Junio" Or month = "6" Or month = "06" Then

            If lenguage = "I" Then

                stringMonth = "June"

            Else

                stringMonth = "Junio"

            End If

        ElseIf month = "July" Or month = "Julio" Or month = "7" Or month = "07" Then

            If lenguage = "I" Then

                stringMonth = "July"

            Else

                stringMonth = "Julio"

            End If

        ElseIf month = "August" Or month = "Agosto" Or month = "8" Or month = "08" Then

            If lenguage = "I" Then

                stringMonth = "August"

            Else

                stringMonth = "Agosto"

            End If

        ElseIf month = "September" Or month = "Septiembre" Or month = "9" Or month = "09" Then

            If lenguage = "I" Then

                stringMonth = "September"

            Else

                stringMonth = "Septiembre"

            End If

        ElseIf month = "October" Or month = "Octubre" Or month = "10" Then

            If lenguage = "I" Then

                stringMonth = "October"

            Else

                stringMonth = "Octubre"

            End If

        ElseIf month = "November" Or month = "Noviembre" Or month = "11" Then

            If lenguage = "I" Then

                stringMonth = "November"

            Else

                stringMonth = "Noviembre"

            End If

        ElseIf month = "December" Or month = "Diciembre" Or month = "12" Then

            If lenguage = "I" Then

                stringMonth = "December"

            Else

                stringMonth = "Diciembre"

            End If

        Else

            If lenguage = "I" Then

                stringMonth = "January"

            Else

                stringMonth = "Enero"

            End If

        End If

        Return stringMonth

    End Function

    Shared Function GetNumberOfMonths(ByVal year As String, ByVal includeCurrentMonth As Boolean, Optional ByVal includeWholeYear As Boolean = False) As Integer
        Dim numberOfMonths As Integer

        If CInt(year) = Now.Year And Not includeWholeYear Then
            numberOfMonths = Now.Month
            If Not includeCurrentMonth Then
                If numberOfMonths > 1 Then
                    numberOfMonths = numberOfMonths - 1
                End If
            End If
        Else
            numberOfMonths = 12
        End If

        Return numberOfMonths
    End Function

    Shared Function GetYearsLastMonthName(ByVal year As String, ByVal includeCurrentMonth As Boolean, Optional ByVal includeWholeYear As Boolean = False) As String
        Dim mes As Integer
        Dim result As String

        mes = GetNumberOfMonths(year, includeCurrentMonth, includeWholeYear)
        result = String.Concat(MonthName(mes), " ", year)
        Return result
    End Function

    Shared Sub EnableScableBreaks(ByRef axisY As Axis)
        With axisY.ScaleBreakStyle
            .Enabled = True
            .BreakLineType = Dundas.Charting.WebControl.BreakLineType.Wave
            .LineStyle = Dundas.Charting.WebControl.ChartDashStyle.Solid
            .LineWidth = 1
            .MaxNumberOfBreaks = 4
            .Spacing = 3
        End With
    End Sub

    Shared Function FileToString(ByVal fileName As String) As String
        Dim objStreamReader As StreamReader
        Dim contents As String

        objStreamReader = File.OpenText(fileName)
        contents = objStreamReader.ReadToEnd()
        objStreamReader.Close()

        contents = contents.Replace(ControlChars.NewLine, " ")
        Return contents
    End Function

    Shared Function StringToDouble(ByVal strValue As String) As Double
        Dim dblValue As Double

        If Not Double.TryParse(strValue, dblValue) Then
            dblValue = 0
        End If
        Return dblValue
    End Function

    Public Overloads Shared Function IsNull(ByVal arg As Object, ByVal returnIfEmpty As Double) As Double
        Dim returnValue As Double
        If (arg Is DBNull.Value) OrElse (arg Is Nothing) OrElse (arg Is String.Empty) Then
            returnValue = returnIfEmpty
        Else
            Try
                returnValue = CDbl(arg)
            Catch
                returnValue = returnIfEmpty
            End Try
        End If
        Return returnValue
    End Function

    Public Shared Function GetDataSource(Optional ByVal query As String = "") As SqlDataSource
        Dim ds As New SqlDataSource()
        Const csName As String = "Cube_CRBLAS12"

        With ds
            .ConnectionString = ConfigurationManager.ConnectionStrings(csName).ConnectionString
            .ProviderName = ConfigurationManager.ConnectionStrings(csName).ProviderName
            If query <> "" Then
                .SelectCommand = query
            End If
        End With

        Return ds
    End Function

    Public Shared Function GetDataSourceDetail(Optional ByVal query As String = "") As SqlDataSource
        Dim ds As New SqlDataSource()
        Const csName As String = "ConDatawareHouse"

        With ds
            .ConnectionString = ConfigurationManager.ConnectionStrings(csName).ConnectionString
            .ProviderName = ConfigurationManager.ConnectionStrings(csName).ProviderName
            If query <> "" Then
                .SelectCommand = query
            End If
        End With

        Return ds

    End Function



End Class
