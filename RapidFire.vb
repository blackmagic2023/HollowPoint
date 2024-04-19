Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient
Imports System.Diagnostics

Public Class RapidFire
    Private myConn As New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True")
    Public myCmd As SqlClient.SqlCommand
    Private myReader As SqlClient.SqlDataReader
    Private results As String
    Private da As SqlClient.SqlDataAdapter
    Private dt As DataTable
    Private sql As String
    Async Sub Ping()
        Dim apiKey As String = "Your_API_Key"

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line As String
        Do
            line = fileReader.ReadLine()
            If Not (line Is Nothing) Then
                Dim host As String = line
                Dim url As String = $"https://api.c99.nl/ping?key={apiKey}&host={host}"
                Using client As New HttpClient()
                    Dim response As HttpResponseMessage = Await client.GetAsync(url)
                    Dim content As String = Await response.Content.ReadAsStringAsync()

                    Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)

                    End Using
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub

    Async Function ProxyDetectionAsync() As Task

        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/proxydetector?key={apiKey}&ip={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else

            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/proxydetector?key={apiKey}&ip={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using
                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()



                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        End If






    End Function
    Async Sub GEOIP()

        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/geoip?key={apiKey}&host={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else

            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/geoip?key={apiKey}&host={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using
                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()

                        Dim match As Match = Regex.Match(content, "Country Code: ([A-Z]+)")
                        If match.Success Then
                            Dim countryCode As String = match.Groups(1).Value
                            content = countryCode

                            mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [location] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                            mycommand.ExecuteNonQuery()
                            myconnection.Close()

                        Else

                            Dim countryCode As String = match.Groups(1).Value
                            content = countryCode

                            mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [location] = 'NA!' WHERE [ipaddr] = '" + host + "'", myconnection)
                            mycommand.ExecuteNonQuery()
                            myconnection.Close()

                        End If



                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        End If

    End Sub
    Async Sub IP2Domain()


        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/ip2domains?key={apiKey}&ip={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else

            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/ip2domains?key={apiKey}&ip={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using
                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [domains] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        End If


    End Sub
    Async Sub PortScanner()

        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/portscanner?key={apiKey}&host={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else


            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/portscanner?key={apiKey}&host={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using
                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [ports] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()


        End If

    End Sub
    Async Sub TORCheck()

        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/torchecker?key={apiKey}&ip={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else




            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/torchecker?key={apiKey}&ip={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [usingtor] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()


        End If


    End Sub
    Async Sub IPtoHost()

        If My.Settings.ProxyEnabled = True Then

            Dim apiKey As String = "Your_API_Key"
            Dim proxyAddress As String = My.Settings.ProxyAddress
            Dim proxyPort As Integer = My.Settings.ProxyPort

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String

            Do
                line = fileReader.ReadLine()
                If Not (line IsNot Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/gethostname?key={apiKey}&host={host}"

                    ' Create a proxy object with the appropriate proxy address and port
                    Dim proxy As New WebProxy(proxyAddress, proxyPort)

                    ' Create a request to the desired URL
                    Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)

                    ' Assign the proxy to the request
                    request.Proxy = proxy

                    If My.Settings.ProxyCredentials = True Then
                        request.Proxy.Credentials = New NetworkCredential(My.Settings.ProxyUsername, My.Settings.ProxyPassword)
                    End If


                    Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
                        Dim dataStream As System.IO.Stream = response.GetResponseStream()
                        Dim reader As New System.IO.StreamReader(dataStream)
                        Dim content As String = reader.ReadToEnd()

                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()

        Else

            Dim apiKey As String = "Your_API_Key"

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim line As String
            Do
                line = fileReader.ReadLine()
                If Not (line Is Nothing) Then
                    Dim host As String = line
                    Dim url As String = $"https://api.c99.nl/gethostname?key={apiKey}&host={host}"
                    Using client As New HttpClient()
                        Dim response As HttpResponseMessage = Await client.GetAsync(url)
                        Dim content As String = Await response.Content.ReadAsStringAsync()

                        ' Process the response here, for example, display it in a MessageBox.
                        'MessageBox.Show(content, "API Response", MessageBoxButtons.OK)
                        Console.Text = Console.Text + "$ " + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Console.SelectionStart = Console.Text.Length
                        Console.ScrollToCaret()
                        Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                        Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                            writer.WriteLine(textToWrite)
                        End Using
                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [hostname] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()
                    End Using
                End If
            Loop Until line Is Nothing

            fileReader.Close()


        End If

    End Sub


    Private Sub RapidFire_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line As String
        Do
            line = fileReader.ReadLine()
            If Not (line Is Nothing) Then
                Dim itm As String = line
                Dim id As Integer = My.Settings.DBentryid + 1

                ' Increment the DBentryid before saving it
                My.Settings.DBentryid = id
                My.Settings.Save()

                ' Check if the IP address already exists in the database
                If Not IsIpExistsInDatabase(itm) Then
                    ' Create a new connection to the database
                    Using mycon2 As New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        ' Open the connection
                        mycon2.Open()

                        ' Create a parameterized SQL command to insert data
                        Dim query As String = "INSERT INTO [targetinfo] ([id],[ipaddr]) VALUES (@id, @ipaddr)"
                        Using mycomm As New SqlClient.SqlCommand(query, mycon2)
                            ' Add parameters to the command
                            mycomm.Parameters.AddWithValue("@id", id)
                            mycomm.Parameters.AddWithValue("@ipaddr", itm)

                            ' Execute the command
                            mycomm.ExecuteNonQuery()
                        End Using

                        ' Close the connection
                        mycon2.Close()
                    End Using
                End If
            End If
        Loop Until line Is Nothing



        Dim myconnection As SqlClient.SqlConnection
        Dim mycommand As SqlClient.SqlCommand

        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
        myconnection.Open()
        mycommand = New SqlClient.SqlCommand("SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[osystem],[location],[domains] FROM [targetinfo]", myconnection)
        mycommand.ExecuteNonQuery()


        '"SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[location] FROM [targetinfo]"


        Dim reader As SqlClient.SqlDataReader = mycommand.ExecuteReader()

        ' Clear any existing items in the ListView
        ListView2.Items.Clear()

        ' Add columns to the ListView
        ListView2.Columns.Add("id", 1)
        ListView2.Columns.Add("IP", 100)
        ListView2.Columns.Add("Hostname", 175)
        ListView2.Columns.Add("Tor")
        ListView2.Columns.Add("Proxy")
        ListView2.Columns.Add("Ports", 100)
        ListView2.Columns.Add("osystem", 100)
        ListView2.Columns.Add("XYZ", 30)
        ListView2.Columns.Add("Domains")




        ' Read the data and add it to the ListView
        While reader.Read()
            Dim row As New ListViewItem()
            For i As Integer = 1 To reader.FieldCount - 1
                row.SubItems.Add(reader(i).ToString())
            Next
            ListView2.Items.Add(row)
        End While

        ' Close the data reader and the connection

        reader.Close()

        myconnection.Close()

        fileReader.Close()

        Button2.PerformClick()

    End Sub
    ' Function to check if the IP address already exists in the database
    Private Function IsIpExistsInDatabase(ipAddress As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM [targetinfo] WHERE [ipaddr] = @ipaddr"
        Using connection As New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
            Using command As New SqlClient.SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ipaddr", ipAddress)
                connection.Open()
                Dim count As Integer = CInt(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function
    Sub OSDetection()


        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line As String
        Do
            line = fileReader.ReadLine()
            If Not (line Is Nothing) Then
                Dim host As String = line
                Console.Text = Console.Text + TimeOfDay + ": OS SCAN STARTED... PLEASE WAIT!!!"

                ' Construct the PowerShell command
                Dim command As String = "nmap -O -A -Pn " + host + " | Out-File C:\Users\tyler\Documents\hollowpoint\dll\OSDump.txt"

                ' Create process info object
                Dim psi As New ProcessStartInfo()
                psi.FileName = "powershell.exe"
                psi.Arguments = "-Command """ + command + """"
                psi.Verb = "runas" ' Request admin privileges
                psi.UseShellExecute = True

                ' Start the process
                Dim process As Process = Process.Start(psi)
                ' Wait for the process to exit
                process.WaitForExit()


                Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": Complete!" + Environment.NewLine
                Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                    writer.WriteLine(textToWrite)
                End Using

                Dim filePath As String = "C:\Users\" + Environment.UserName + "\Documents\hollowpoint\dll\OSDump.txt"

                Try
                    ' Read all text from the file
                    Dim os As String = File.ReadAllText(filePath)
                    'Console.Text = Console.Text + "$ " + TimeOfDay + ": OS: " + os + Environment.NewLine
                    'Console.SelectionStart = Console.Text.Length
                    'Console.ScrollToCaret()
                    'MsgBox(os)

                    Dim datastring As String = os
                    Dim pattern As String = "Running \(JUST GUESSING\): ([\w\s.-]+)"
                    Dim pattern2 As String = "Running: ([\w\s.,|-]+)"
                    ' Use Regex.Match to find the match
                    Dim match As Match = Regex.Match(datastring, pattern)
                    Dim match2 As Match = Regex.Match(datastring, pattern2)
                    ' If a match is found, extract the operating system information

                    If match.Success Then

                        Dim operatingSystem As String = match.Groups(1).Value
                        'MsgBox(operatingSystem)

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [osystem] = '" + operatingSystem + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()





                        Console.Text = Console.Text + "Operating System: " & operatingSystem
                    Else

                    End If

                    If match2.Success Then
                        Dim operatingSystem2 As String = match2.Groups(1).Value
                        'MsgBox(operatingSystem2)

                        Dim myconnection As SqlClient.SqlConnection
                        Dim mycommand As SqlClient.SqlCommand

                        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                        myconnection.Open()
                        mycommand = New SqlClient.SqlCommand("UPDATE targetinfo SET [osystem] = '" + operatingSystem2 + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                        mycommand.ExecuteNonQuery()
                        myconnection.Close()

                        Console.Text = Console.Text + "Operating System: " & operatingSystem2
                    Else
                        Console.Text = Console.Text + "Operating system information not found."
                    End If

                Catch ex As Exception
                    Console.Text = Console.Text + "An error occurred: " & ex.Message
                End Try


                ' Wait for 5 minutes before starting the next scan
                'Threading.Thread.Sleep(300000) ' 300000 milliseconds = 5 minutes
            End If
        Loop Until line Is Nothing

        fileReader.Close()



    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            IPtoHost()
        End If

        If CheckBox2.Checked = True Then
            TORCheck()
        End If

        If CheckBox3.Checked = True Then
            PortScanner()
        End If

        If CheckBox4.Checked = True Then
            IP2Domain()
        End If

        If CheckBox5.Checked = True Then
            GEOIP()
        End If

        If CheckBox6.Checked = True Then
            ProxyDetectionAsync()
        End If

        If CheckBox7.Checked = True Then
            Ping()
        End If

        If CheckBox8.Checked = True Then
            OSDetection()
        End If


    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line As String
        ListView1.Items.Clear()

        Do
            line = fileReader.ReadLine()
            If Not (line Is Nothing) Then
                Dim item As New ListViewItem(line)
                ListView1.Items.Add(item)
            End If
        Loop Until line Is Nothing

        Dim myconnection As SqlClient.SqlConnection
        Dim mycommand As SqlClient.SqlCommand

        myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
        myconnection.Open()
        mycommand = New SqlClient.SqlCommand("SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[osystem],[location],[domains] FROM [targetinfo]", myconnection)
        mycommand.ExecuteNonQuery()

        If My.Settings.FilterProxy = True Then
            'DELETE FROM [targetinfo] WHERE proxy<>'No proxy detected.'
            mycommand = New SqlClient.SqlCommand("DELETE FROM [targetinfo] WHERE proxy<>'No proxy detected.'", myconnection)
            mycommand.ExecuteNonQuery()
        End If

        If My.Settings.FilterTOR = True Then
            'DELETE FROM [targetinfo] WHERE usingtor<>'No TOR Detected!'
            mycommand = New SqlClient.SqlCommand("DELETE FROM [targetinfo] WHERE usingtor<>'No TOR Detected!'", myconnection)
            mycommand.ExecuteNonQuery()
        End If

        If My.Settings.FilterPorts = True Then
            'DELETE FROM [targetinfo] WHERE ports='No open ports'
            mycommand = New SqlClient.SqlCommand("DELETE FROM [targetinfo] WHERE ports='No open ports'", myconnection)
            mycommand.ExecuteNonQuery()
        End If

        If My.Settings.FilterDomains = True Then
            'DELETE FROM [targetinfo] WHERE domains<>''
            mycommand = New SqlClient.SqlCommand("DELETE FROM [targetinfo] WHERE domains<>''", myconnection)
            mycommand.ExecuteNonQuery()
        End If






        '"SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[location] FROM [targetinfo]"


        Dim reader As SqlClient.SqlDataReader = mycommand.ExecuteReader()

        ' Clear any existing items in the ListView
        ListView2.Items.Clear()

        ' Read the data and add it to the ListView
        While reader.Read()
            Dim row As ListViewItem = New ListViewItem()
            For i As Integer = 1 To reader.FieldCount - 1
                row.SubItems.Add(reader(i).ToString())
            Next
            ListView2.Items.Add(row)
        End While




        ' Close the data reader and the connection
        Dim fileReader1 As System.IO.StreamReader
        fileReader1 = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line1 As String
        ListView1.Items.Clear()

        Do
            line1 = fileReader1.ReadLine()
            If Not (line1 Is Nothing) Then
                Dim item1 As New ListViewItem(line1)
                ListView1.Items.Add(item1)
            End If
        Loop Until line1 Is Nothing

        Dim myconnection1 As SqlClient.SqlConnection
        Dim mycommand1 As SqlClient.SqlCommand

        myconnection1 = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
        myconnection1.Open()
        mycommand1 = New SqlClient.SqlCommand("SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[osystem],[location],[domains] FROM [targetinfo]", myconnection1)
        mycommand1.ExecuteNonQuery()


        '"SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[location] FROM [targetinfo]"


        Dim reader1 As SqlClient.SqlDataReader = mycommand1.ExecuteReader()

        ' Clear any existing items in the ListView
        ListView2.Items.Clear()

        ' Read the data and add it to the ListView
        While reader1.Read()
            Dim row1 As ListViewItem = New ListViewItem()
            For i As Integer = 1 To reader1.FieldCount - 1
                row1.SubItems.Add(reader1(i).ToString())
            Next
            ListView2.Items.Add(row1)
        End While

        ' Close the data reader and the connection


        reader.Close()

        myconnection.Close()

        fileReader.Close()


        reader1.Close()

        myconnection1.Close()

        fileReader1.Close()
    End Sub

    Public Sub ApplyScanCycleBtn_Click(sender As Object, e As EventArgs) Handles ApplyScanCycleBtn.Click
        If CommandBox.Text <> "-$" Then
            If CommandBox.Text.Contains("zenmap") Then
                Console.Text = Console.Text + "-$" + CommandBox.Text + ": " + TimeOfDay + ": Starting NMAP.GUI.ZENMAP..." + Environment.NewLine
                Console.Text = Console.Text &
                    Environment.NewLine &
                 "                    ___.-------.___" & vbCrLf &
                 "                _.-' ___.--;--.___ `-." & vbCrLf &
                 "             .-' _.-'  /  .+.  \  `-._ `-." & vbCrLf &
                 "           .' .-'      |-|-o-|-|      `-. `." & vbCrLf &
                 "          (_ <O__      \  `+'  /      __O> _)" & vbCrLf &
                 "            `--._``-..__`._|_.'__..-''_.--'" & vbCrLf &
                 "                  ``--._________.--''" & vbCrLf &
                 "   ____  _____  ____    ____       _       _______" & vbCrLf &
                 "  |_   \|_   _||_   \  /   _|     / \     |_   __ \" & vbCrLf &
                 "    |   \ | |    |   \/   |      / _ \      | |__) |" & vbCrLf &
                 "    | |\ \| |    | |\  /| |     / ___ \     |  ___/" & vbCrLf &
                 "   _| |_\   |_  _| |_\/_| |_  _/ /   \ \_  _| |_" & vbCrLf &
                 "  |_____|\____||_____||_____||____| |____||_____|" & Environment.NewLine
                Console.SelectionStart = Console.Text.Length
                Console.ScrollToCaret()



                'Application.Restart()

                Dim psi As New ProcessStartInfo()
                psi.FileName = "powershell"
                psi.RedirectStandardOutput = True
                psi.RedirectStandardError = True
                psi.RedirectStandardInput = True
                psi.CreateNoWindow = True
                psi.UseShellExecute = False

                Dim command As String = "cd ""C:\Program Files (x86)\Nmap\zenmap\bin\"""
                Dim command2 As String = "./pythonw.exe -c ""from zenmapGUI.App import run;run()"""
                Dim process As Process = Process.Start(psi)
                process.StandardInput.WriteLine(command)
                process.StandardInput.WriteLine(command2)
                process.StandardInput.Close()
                process.Close()

            ElseIf CommandBox.Text <> "" Then

                Dim command As String = CommandBox.Text.Trim()

                ' Specify the path to WSL and the command to be executed
                Dim processInfo As New ProcessStartInfo("wsl", command)
                processInfo.RedirectStandardOutput = True
                processInfo.RedirectStandardError = True
                processInfo.UseShellExecute = False
                processInfo.CreateNoWindow = True

                ' Start the process
                Dim process As Process = Process.Start(processInfo)

                ' Read the output and error streams asynchronously
                Dim outputTask As Task(Of String) = process.StandardOutput.ReadToEndAsync()
                Dim errorTask As Task(Of String) = process.StandardError.ReadToEndAsync()

                ' Update the console with the output
                UpdateConsole(outputTask.Result)
                UpdateConsole(errorTask.Result)



            Else
                Console.Text = Console.Text + "-$" + CommandBox.Text + ": " + TimeOfDay + ": Command not found!" + Environment.NewLine
                Console.SelectionStart = Console.Text.Length
                Console.ScrollToCaret()
            End If
            CommandBox.Text = "-$"

        End If

    End Sub
    Private Sub UpdateConsole(text As String)
        ' Invoke on the UI thread to update the RichTextBox
        If Console.InvokeRequired Then
            Console.Invoke(Sub() UpdateConsole(text))
        Else
            Console.AppendText(text)
            Console.ScrollToCaret()
        End If
    End Sub

    Private Sub AddIPBtn_Click(sender As Object, e As EventArgs) Handles AddIPBtn.Click

        Dim ip As String = AddIPBox.Text

        ' Check if the IP already exists in the Online.txt file
        Dim existingIPs As New List(Of String)(File.ReadAllLines("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt"))
        If Not existingIPs.Contains(ip) Then
            If My.Computer.Network.Ping(ip) Then
                ListView1.Items.Add(ip)
                Dim textToWrite As String = ip
                Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
                    writer.WriteLine(textToWrite)
                End Using

                ' Check if the IP already exists in the database table
                Dim ipExistsInDatabase As Boolean = False
                Using myconnection As New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    Dim command As New SqlClient.SqlCommand("SELECT COUNT(*) FROM targetinfo WHERE ipaddr = @ip", myconnection)
                    command.Parameters.AddWithValue("@ip", ip)
                    Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                    If result > 0 Then
                        ipExistsInDatabase = True
                    End If
                End Using

                ' If the IP doesn't exist in the database, insert it
                If Not ipExistsInDatabase Then
                    Dim myconnection As SqlClient.SqlConnection
                    Dim mycommand As SqlClient.SqlCommand
                    Dim id As Integer = My.Settings.DBentryid + 1
                    My.Settings.DBentryid = id
                    My.Settings.Save()

                    myconnection = New SqlClient.SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlClient.SqlCommand("INSERT INTO [targetinfo]([id],[ipaddr]) VALUES('" + Str(id) + "','" + ip + "')", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                    AddIPBox.Clear()
                Else
                    MsgBox("The provided IP already exists in the database table!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Add IP Error!")
                End If
            Else
                MsgBox("The provided IP is either invalid or offline!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Add IP Error!")
            End If
        Else
            MsgBox("The provided IP already exists in the list!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Add IP Error!")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FilterSettings.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Exploitation.Show()
    End Sub
End Class
