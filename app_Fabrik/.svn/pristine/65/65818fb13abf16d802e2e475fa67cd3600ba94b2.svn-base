'Connection string for ASP (using ADO):
'Provider=SQLOLEDB.1;Persist Security Info=True;User ID=syscontab;Password=66cc9588;Initial Catalog=syscontab;Data Source=sql15.hostbasket.com

'Connection string for ASP.NET (using ADO.NET with System.Data.SqlClient namespace):
'Persist Security Info=True;User ID=syscontab;Password=66cc9588;Initial Catalog=syscontab;Data Source=sql15.hostbasket.com

Option Strict Off
Option Explicit On 

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net

Imports System.Text
Imports System.Security.Cryptography

Namespace SGA

    Public Class Rutinas

        Public Shared Function Image2Bytes(ByVal img As Image) As Byte()
            Dim sTemp As String = Path.GetTempFileName()
            Dim fs As New FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
            fs.Position = 0
            '
            Dim imgLength As Integer = CInt(fs.Length)
            Dim bytes(0 To imgLength - 1) As Byte
            fs.Read(bytes, 0, imgLength)
            fs.Close()
            Return bytes
        End Function

        Public Shared Sub ColorFondoFormulario(ByRef Form As Form)
            Form.BackColor = Color.FromArgb(211, 226, 233)
        End Sub

        Public Shared Sub DataGridRowStyle(ByRef dgv As DataGridView)
            With dgv
                .RowsDefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(199, 220, 244) 'Color.FromArgb(158, 195, 237)
                .RowTemplate.Height = 15
                .BackgroundColor = Color.FromArgb(227, 241, 254)
                .ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
                '.GridColor = Color.SteelBlue
                .BorderStyle = BorderStyle.Fixed3D

                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False

                .RowTemplate.Resizable = DataGridViewTriState.False
                .RowHeadersWidth = 25
                .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing

                '.CellBorderStyle = DataGridViewCellBorderStyle.None
                .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            End With
        End Sub

        Public Shared Sub Imagen(ByRef ds As DataSet, ByVal Imagen As String)
            'Dim Tabla As New DataTable
            'Dim dr As DataRow
            'Dim i As Integer

            'Tabla.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
            ds.Tables("Tabla").Columns.Add(New DataColumn("Imagen", GetType(Byte())))

            'dr = Tabla.NewRow()
            'dr = ds.Tables("Tabla").NewRow()
            'SGA.Rutinas.ImageToByte(Image.FromFile(Imagen))
            'dr("Imagen") = SGA.Rutinas.ImageToByte(Image.FromFile(Imagen))
            'ds.Tables("Tabla").Rows.Add(dr)
            'Tabla.Rows.Add(dr)

            ds.Tables("Tabla").Rows(0).Item("Imagen") = SGA.Rutinas.ImageToByte(Image.FromFile(Imagen))

            'ds.Tables.Add(Tabla)
            ds.Tables("Tabla").TableName = "Tabla"
        End Sub

        Public Shared Function ImageToByte(ByVal pImagen As Image) As Byte()
            Dim mImage() As Byte
            Try
                If Not IsNothing(pImagen) Then
                    Dim ms As New System.IO.MemoryStream
                    pImagen.Save(ms, pImagen.RawFormat)
                    mImage = ms.GetBuffer
                    ms.Close()
                    Return mImage
                End If
            Catch
            End Try
        End Function

        Public Shared Function IP() As String
            'Dim i_cont As Integer
            Dim Host As String

            ' Si no se pasa como parametro un nombre, muestra las ip locales
            'If Environment.GetCommandLineArgs().Length > 1 Then
            '    Host = Environment.GetCommandLineArgs(1)
            'Else
            '    Host = Dns.GetHostName
            'End If

            Host = Dns.GetHostName

            Dim IPs As IPHostEntry = Dns.GetHostEntry(Host)
            'Dim IPs As IPHostEntry = Dns.GetHostEntry(Host)
            Dim Direcciones As IPAddress() = IPs.AddressList
            Return Direcciones(0).ToString()

            'Se despliega la lista de IP's
            'For i_cont = 0 To i_cont = Direcciones.Length
            '    Console.WriteLine("IP {0}: {1} ", i_cont + 1, Direcciones(i_cont).ToString())
            'Next
            'Console.Read()
        End Function

        Public Shared Function Conexion() As String
            Dim Servidor As String
            Dim Usuario As String
            Dim Password As String
            Dim Base As String

            If Not File.Exists(Application.StartupPath & "\Server.ini") Then
                MsgBox("No se encontró el archivo: Server.ini", MsgBoxStyle.Information)
                Return "Nothing"
                Exit Function
            End If

            Dim ConnectionFile As New System.IO.StreamReader(Application.StartupPath & "\Server.ini")

            Servidor = ConnectionFile.ReadLine.ToString()
            Usuario = ConnectionFile.ReadLine.ToString()
            Password = ConnectionFile.ReadLine.ToString()
            Base = ConnectionFile.ReadLine.ToString()

            '-- strIP = ConnectionFile.ReadLine.ToString()

            Conexion = "server=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & _
                        Usuario & ";Password=" & Password & ";"

            'Conexion = "server=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & _
            '            Usuario & ";Password=" & Password & ";" & _
            '            "Trusted_Connection=false;"

            'server=sql-data;uid=YOUR_NAME;pwd=YOUR_PAS SWORD;Trusted_Connection=false;database=WorkWithIt

            Return Conexion

        End Function

        'Public Function GetUsers() As DataSet
        '    Dim MyConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection("server=sql-data;uid=YOUR_NAME;pwd=YOUR_PAS SWORD;Trusted_Connection=false;database=WorkWithIt")
        '    Dim MyCommand As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter("SELECT Email FROM Users", MyConnection)
        '    Dim DS As DataSet = New DataSet
        '    MyCommand.Fill(DS, "Users")
        '    MyConnection.Close()
        '    Return DS
        'End Function

        Public Shared Function Meses(ByVal Mes As Integer) As DataSet
            Dim DBConn As SqlConnection
            Dim DBCommand As SqlDataAdapter
            Dim ds As New DataSet()
            DBConn = New SqlConnection(SGA.Rutinas.Conexion())
            DBCommand = New SqlDataAdapter("spGen_Meses", DBConn)
            DBCommand.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim _nMesInicio As New SqlParameter("@nMesInicio", SqlDbType.Int)
            _nMesInicio.Value = Mes
            DBCommand.SelectCommand.Parameters.Add(_nMesInicio)

            DBCommand.Fill(ds, "Tabla")
            DBConn.Close()
            Return ds
        End Function

        Public Shared Function Fecha() As String

            Dim DBConn As SqlConnection
            'Dim conexion As New SGA.Rutinas()
            'Try

            DBConn = New SqlConnection(Conexion())
            Dim cmd As SqlCommand = New SqlCommand("spFechaServer", DBConn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim pFecha As SqlParameter = New SqlParameter("@Fecha", SqlDbType.DateTime, 50)
            pFecha.Direction = ParameterDirection.Output
            cmd.Parameters.Add(pFecha)

            DBConn.Open()
            cmd.ExecuteNonQuery()
            DBConn.Close()

            Return pFecha.Value

            'Catch ex As Exception
            'MsgBox("Se ha producido el siguiente error: " + ex.Message, _
            '    MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '--
            'Throw
            'End Try

        End Function

    End Class

    Friend Class cTripleDES

        ' define the triple des provider
        Private m_des As New TripleDESCryptoServiceProvider

        ' define the string handler
        Private m_utf8 As New UTF8Encoding

        ' define the local property arrays
        Private m_key() As Byte
        Private m_iv() As Byte

        Public Sub New(ByVal key() As Byte, ByVal iv() As Byte)
            Me.m_key = key
            Me.m_iv = iv
        End Sub

        Public Function Encrypt(ByVal input() As Byte) As Byte()
            Return Transform(input, m_des.CreateEncryptor(m_key, m_iv))
        End Function

        Public Function Decrypt(ByVal input() As Byte) As Byte()
            Return Transform(input, m_des.CreateDecryptor(m_key, m_iv))
        End Function

        Public Function Encrypt(ByVal text As String) As String
            Dim input() As Byte = m_utf8.GetBytes(text)
            Dim output() As Byte = Transform(input, _
                            m_des.CreateEncryptor(m_key, m_iv))
            Return Convert.ToBase64String(output)
        End Function

        Public Function Decrypt(ByVal text As String) As String
            Dim input() As Byte = Convert.FromBase64String(text)
            Dim output() As Byte = Transform(input, _
                             m_des.CreateDecryptor(m_key, m_iv))
            Return m_utf8.GetString(output)
        End Function

        Private Function Transform(ByVal input() As Byte, _
            ByVal CryptoTransform As ICryptoTransform) As Byte()
            ' create the necessary streams
            Dim memStream As MemoryStream = New MemoryStream
            Dim cryptStream As CryptoStream = New _
                CryptoStream(memStream, CryptoTransform, _
                CryptoStreamMode.Write)
            ' transform the bytes as requested
            cryptStream.Write(input, 0, input.Length)
            cryptStream.FlushFinalBlock()
            ' Read the memory stream and convert it back into byte array
            memStream.Position = 0
            Dim result(CType(memStream.Length - 1, System.Int32)) As Byte
            memStream.Read(result, 0, CType(result.Length, System.Int32))
            ' close and release the streams
            memStream.Close()
            cryptStream.Close()
            ' hand back the encrypted buffer
            Return result
        End Function

    End Class

End Namespace