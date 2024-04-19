Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Dim ip1 As String
    Dim max As Integer = My.Settings.ScanCycle
    Dim x As Integer = 0
    Dim path As String = My.Settings.ScanDataDirectory
    Dim p() As Process

    Private Sub CheckIfRunning()
        ' Check if propogation complete messagebox has appeared indicating a complete propogation cycle from the batch binary
        p = Process.GetProcessesByName("mshta")
        If p.Count > 0 Then
            ' If Process is running
            CheckProp.Stop()
            SendKeys.SendWait("{ENTER}")

            If My.Settings.ScanPropogateAutomation = True Then ' Check if user has selected to use a specified region
                RapidFire.CheckBox1.Checked = True
                RapidFire.Show()
            End If

            ' Count propogated targets
            Dim lineCount = File.ReadAllLines("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt").Length
            Label3.Text = Str(lineCount)
            ' Add targets to listbox
            Dim a As String = My.Computer.FileSystem.ReadAllText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim b As String() = a.Split(Environment.NewLine)
            ListBox2.Items.Clear()
            ListBox2.Items.AddRange(b)
            ' Add each propogated target to MySQL DataBase from propogated target list
            For Each Line As String In File.ReadLines("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
                Dim myconnection As SqlConnection
                Dim mycommand As SqlCommand
                Dim id As Integer = My.Settings.DBentryid + 1
                My.Settings.DBentryid = My.Settings.DBentryid + 1
                My.Settings.Save()
                'MsgBox(Line)
                If Line <> "" Then
                    myconnection = New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=HPtargets;Integrated Security=True;TrustServerCertificate=True")
                    myconnection.Open()
                    mycommand = New SqlCommand("INSERT INTO [targetinfo]([id],[ipaddr]) VALUES('" + Str(id) + "','" + Line + "')", myconnection)
                    'mycommand.ExecuteNonQuery()
                    myconnection.Close()
                End If

            Next

            Loader.Hide() ' Hide loading animation

        Else
            ' Process is not running, do nothing
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if user has internet access
        'My.Settings.DBentryid = 0
        If My.Computer.Network.Ping("1.1.1.1") Then
            ' Load candidates into listbox on form spawn
            Dim lineCount = File.ReadAllLines(My.Settings.ScanDataDirectory).Length
            Label2.Text = Str(lineCount) ' Add number of candidates to label display
            Dim a As String = My.Computer.FileSystem.ReadAllText(My.Settings.ScanDataDirectory)
            Dim b As String() = a.Split(Environment.NewLine)
            ListBox1.Items.AddRange(b)
            ' Load targets into listbox on form spawn
            Dim lineCount1 = File.ReadAllLines("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt").Length
            Label3.Text = Str(lineCount1) ' Add number of targets to label display
            Dim a1 As String = My.Computer.FileSystem.ReadAllText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt")
            Dim b1 As String() = a1.Split(Environment.NewLine)
            ListBox2.Items.AddRange(b1)
            ' Reset settings for new load
            My.Settings.RegionScanning = False
            My.Settings.ScanPropogateAutomation = False
            My.Settings.Save()
        Else ' User does not have internet access
            MsgBox("Connect to a network to use HollowPoint!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "No Internet!")
            Me.Enabled = False

        End If

    End Sub
    Public Sub gencusip() ' Generate Internet protocols as defined by user settings or region selection

        Randomize()
        Dim r As New Random
        ' Generate IP's based on quaderent range definition
        Dim one As String = Str(r.Next(My.Settings.Q1Min, My.Settings.Q1Max))
        Dim two As String = Str(r.Next(My.Settings.Q2Min, My.Settings.Q2Max))
        Dim thr As String = Str(r.Next(My.Settings.Q3Min, My.Settings.Q3Max))
        Dim fou As String = Str(r.Next(My.Settings.Q4Min, My.Settings.Q4Max))
        Dim ip As String = one + "." + two + "." + thr + "." + fou ' String generated quaderents together 
        Dim ip1 As String = ip.Replace(" ", "") ' Remove white space
        ' Write generated IP's to candadite file
        Dim textToWrite As String = ip1
        Using writer As StreamWriter = File.AppendText(path)
            writer.WriteLine(textToWrite)
            ListBox1.Items.Insert(0, ip1) ' List generated contents in listbox
        End Using

    End Sub
    Public Sub genip() ' Generate IP's based on random quaderent range definition by randomization algorythem

        Randomize()
        Dim r As New Random
        Dim one As String = Str(r.Next(1, 255))
        Dim two As String = Str(r.Next(0, 255))
        Dim thr As String = Str(r.Next(0, 255))
        Dim fou As String = Str(r.Next(1, 255))
        Dim ip As String = one + "." + two + "." + thr + "." + fou
        Dim ip1 As String = ip.Replace(" ", "")
        Dim textToWrite As String = ip1
        Using writer As StreamWriter = File.AppendText(path)
            writer.WriteLine(textToWrite)
            ListBox1.Items.Insert(0, ip1)
        End Using


    End Sub

    Private Sub Generate_Tick(sender As Object, e As EventArgs) Handles Generate.Tick
        ' Activate candidate generation after button press
        Button1.Enabled = False ' Disable generate candidate button while generation is in progress
        If x < max Then ' Generate addresses from 0 to max scan cycle as defined by user
            x += 1 ' Increase value for every cycle
            Label2.Text = Str(x) ' Display number of generated addresses as they get generated
            genip() ' Call function to generate addresses
        Else ' When generation is complete
            ' Show total number of generated addresses
            Dim lineCount = File.ReadAllLines(My.Settings.ScanDataDirectory).Length
            Label2.Text = Str(lineCount)
            Generate.Stop() ' Stop generation loop
            Button1.Enabled = True ' Re-enable generation button
            If My.Settings.ScanPropogateAutomation = True Then ' If user has selected to automate propogation process
                Button3.PerformClick() ' Click porpogate button
            End If

            Loader.Hide()
            x = 1 ' Reset count
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Generate candidates click
        If My.Settings.RegionScanning = True Then ' If user is using a pre defined propogation range

            CustomGenerate.Start()
            Loader.Show()

        Else ' User is using random propogation range

            Generate.Start()
            Loader.Show()

        End If

    End Sub


    Private Sub CustomGenerate_Tick(sender As Object, e As EventArgs) Handles CustomGenerate.Tick
        ' Same as random propogation but with the added pre defined values
        If x < max Then
            x += 1
            Label2.Text = Str(x)
            gencusip()
        Else
            Dim lineCount = File.ReadAllLines(My.Settings.ScanDataDirectory).Length
            Label2.Text = Str(lineCount)
            CustomGenerate.Stop()
            Button1.Enabled = True
            Loader.Hide()
            x = 1
        End If
    End Sub

    Private Sub ScanSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanSettingsToolStripMenuItem.Click
        ScanSettings.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear candidate list and listbox
        ListBox1.Items.Clear()
        System.IO.File.WriteAllText(My.Settings.ScanDataDirectory, "")
        Label2.Text = "0"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Propogate targets click
        ' Check for existing propogation script
        If System.IO.File.Exists("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\dll\propogate.bat") Then
            Process.Start("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\dll\propogate.bat")
            Loader.Show()
            CheckProp.Start()
        Else ' If file does not exist, create one
            Dim sb As New System.Text.StringBuilder

            sb.AppendLine("@echo off")
            sb.AppendLine("title HP_Propogation")
            sb.AppendLine("set inputFile=C:\Users\%username%\Documents\hollowpoint\Candidate.txt")
            sb.AppendLine("set outputFile=C:\Users\%username%\Documents\hollowpoint\Online.txt")
            sb.AppendLine("for /F ""tokens=*"" %%A in (%inputfile%) do (")
            sb.AppendLine("    echo %%A")
            sb.AppendLine("    ping -n 1 %%A | find ""TTL="" >nul")
            sb.AppendLine("    if errorlevel 1 (")
            sb.AppendLine("        echo %%A is not reachable.")
            sb.AppendLine("    ) else (")
            sb.AppendLine("        echo %%A is reachable.")
            sb.AppendLine("        echo %%A >> %outputFile%")
            sb.AppendLine("    )")
            sb.AppendLine(")")
            sb.AppendLine("mshta ""about:<script>alert('Propogation Completed!');close()</script>""")
            ' Write data to batch file
            IO.File.WriteAllText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\dll\propogate.bat", sb.ToString())
            Process.Start("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\dll\propogate.bat")
            Loader.Show()
            CheckProp.Start()
        End If



    End Sub

    Private Sub CheckProp_Tick(sender As Object, e As EventArgs) Handles CheckProp.Tick
        CheckIfRunning()
    End Sub

    Private Sub RapidFireToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RapidFireToolStripMenuItem.Click
        RapidFire.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Clear propogation list and listbox
        ListBox2.Items.Clear()
        System.IO.File.WriteAllText("C:\Users\" + Environment.UserName + "\Documents\hollowpoint\Online.txt", "")
        Label3.Text = "0"
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub
End Class
