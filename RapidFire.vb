Imports System.IO
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports System.Text.RegularExpressions
Imports System.Reflection.Metadata
Imports System.Diagnostics

Public Class RapidFire
    Private myConn As New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True")
    Public myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private da As SqlDataAdapter
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

                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
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
    Async Sub ProxyDetection()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using


                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("UPDATE targetinfo SET [proxy] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()

                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub
    Async Sub GEOIP()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using
                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()

                    Dim match As Match = Regex.Match(content, "Country Code: ([A-Z]+)")
                    If match.Success Then
                        Dim countryCode As String = match.Groups(1).Value
                        content = countryCode
                    End If



                    mycommand = New SqlCommand("UPDATE targetinfo SET [location] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub
    Async Sub IP2Domain()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using
                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("UPDATE targetinfo SET [domains] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub
    Async Sub PortScanner()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using
                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("UPDATE targetinfo SET [ports] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub
    Async Sub TORCheck()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using
                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("UPDATE targetinfo SET [usingtor] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub
    Async Sub IPtoHost()
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
                    Console.Text = Console.Text + "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Console.SelectionStart = Console.Text.Length
                    Console.ScrollToCaret()
                    Dim textToWrite As String = "$" + host + ": " + TimeOfDay + ": " + content + Environment.NewLine
                    Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\TargetDump\TargetDump.txt")
                        writer.WriteLine(textToWrite)
                    End Using
                    Dim myconnection As SqlConnection
                    Dim mycommand As SqlCommand

                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("UPDATE targetinfo SET [hostname] = '" + content + "' WHERE [ipaddr] = '" + host + "'", myconnection)
                    mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End Using
            End If
        Loop Until line Is Nothing

        fileReader.Close()


    End Sub


    Private Sub RapidFire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
        Dim line As String
        Do
            line = fileReader.ReadLine()
            If Not (line Is Nothing) Then
                Dim item As New ListViewItem(line)
                ListView1.Items.Add(item)
            End If
        Loop Until line Is Nothing

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand

        myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
        myconnection.Open()
        mycommand = New SqlCommand("SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[domains],[location] FROM [targetinfo]", myconnection)
        mycommand.ExecuteNonQuery()


        '"SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[location] FROM [targetinfo]"


        Dim reader As SqlDataReader = mycommand.ExecuteReader()

        ' Clear any existing items in the ListView
        ListView2.Items.Clear()

        ' Add columns to the ListView
        ListView2.Columns.Add("")
        ListView2.Columns.Add("IP")
        ListView2.Columns.Add("Hostname")
        ListView2.Columns.Add("Tor")
        ListView2.Columns.Add("Proxy")
        ListView2.Columns.Add("Ports")
        ListView2.Columns.Add("Domains")
        ListView2.Columns.Add("XYZ")

        ' Read the data and add it to the ListView
        While reader.Read()
            Dim row As ListViewItem = New ListViewItem()
            For i As Integer = 1 To reader.FieldCount - 1
                row.SubItems.Add(reader(i).ToString())
            Next
            ListView2.Items.Add(row)
        End While

        ' Close the data reader and the connection

        reader.Close()

        myconnection.Close()

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
            ProxyDetection()
        End If

        If CheckBox7.Checked = True Then
            Ping()
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

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand

        myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
        myconnection.Open()
        mycommand = New SqlCommand("SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[domains],[location] FROM [targetinfo]", myconnection)
        mycommand.ExecuteNonQuery()


        '"SELECT [id],[ipaddr],[hostname],[usingtor],[proxy],[ports],[location] FROM [targetinfo]"


        Dim reader As SqlDataReader = mycommand.ExecuteReader()

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

        reader.Close()

        myconnection.Close()

        fileReader.Close()
    End Sub

    Private Sub ApplyScanCycleBtn_Click(sender As Object, e As EventArgs) Handles ApplyScanCycleBtn.Click
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

            ElseIf CommandBox.Text.Contains("term") Then

            Else
                Console.Text = Console.Text + "-$" + CommandBox.Text + ": " + TimeOfDay + ": Command not found!" + Environment.NewLine
                Console.SelectionStart = Console.Text.Length
                Console.ScrollToCaret()
            End If
            CommandBox.Text = "-$"

        End If
    End Sub

    Private Sub AddIPBtn_Click(sender As Object, e As EventArgs) Handles AddIPBtn.Click

        If My.Computer.Network.Ping(AddIPBox.Text) Then
            ListView1.Items.Add(AddIPBox.Text)
            Dim textToWrite As String = AddIPBox.Text
            Using writer As StreamWriter = File.AppendText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
                writer.WriteLine(textToWrite + Environment.NewLine)
            End Using
            Dim myconnection As SqlConnection
            Dim mycommand As SqlCommand
            Dim id As Integer = My.Settings.DBentryid + 1
            My.Settings.DBentryid = My.Settings.DBentryid + 1
            My.Settings.Save()

            myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
            myconnection.Open()
            mycommand = New SqlCommand("INSERT INTO [targetinfo]([id],[ipaddr]) VALUES('" + Str(id) + "','" + AddIPBox.Text + "')", myconnection)
            mycommand.ExecuteNonQuery()
            myconnection.Close()
            AddIPBox.Clear()

        Else
            MsgBox("The provided IP is either invalid or offline!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Add IP Error!")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FilterSettings.Show()
    End Sub
End Class
