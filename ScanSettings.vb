Imports System.IO
Imports System.Text

' SHOUTOUT B2ac9 for helping with the region range's!

Public Class ScanSettings
    Private Sub ApplyScanCycleBtn_Click(sender As Object, e As EventArgs) Handles ApplyScanCycleBtn.Click
        If ScanCyclyBox.Text <> "" Then
            'Save scan cycle number
            My.Settings.ScanCycle = ScanCyclyBox.Text
            My.Settings.Save()
            MsgBox("Scan cycle has been successfully updated to: " + Str(My.Settings.ScanCycle), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ScanCycle Updated!")
            Application.Restart()
        Else
            MsgBox("Please input a number in the input feild!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End If

    End Sub

    Private Sub RegionScanCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles RegionScanCheckBox.CheckedChanged
        If RegionScanCheckBox.Checked = True Then
            My.Settings.RegionScanning = True
            My.Settings.Save()
            SpecifyRegionRadio.Enabled = True
            SelectRegionRadio.Enabled = True
            MsgBox("Region scanning enabled! This will be disabled every time you re launch HollowPoint.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information!")
        Else
            My.Settings.RegionScanning = False
            My.Settings.RegionScanModeSpecify = False
            My.Settings.Save()
            SpecifyRegionRadio.Enabled = False
            SelectRegionRadio.Enabled = False
            SpecifyRegonGB.Enabled = False
            SelectRegionGB.Enabled = False
            MsgBox("Region scanning disabled!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information!")
        End If
    End Sub

    Private Sub SelectRegionRadio_CheckedChanged(sender As Object, e As EventArgs) Handles SelectRegionRadio.CheckedChanged
        My.Settings.RegionScanModeSpecify = False
        My.Settings.Save()
        SelectRegionGB.Enabled = True
        SpecifyRegonGB.Enabled = False

    End Sub

    Private Sub SpecifyRegionRadio_CheckedChanged(sender As Object, e As EventArgs) Handles SpecifyRegionRadio.CheckedChanged

        My.Settings.RegionScanModeSpecify = True
        My.Settings.Save()
        SpecifyRegonGB.Enabled = True
        SelectRegionGB.Enabled = False
    End Sub


    Private Sub ScanSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataDirectoryBox.Text = My.Settings.ScanDataDirectory
        ScanCyclyBox.Text = My.Settings.ScanCycle
    End Sub

    Private Sub SetDataDirectoryBtn_Click(sender As Object, e As EventArgs) Handles SetDataDirectoryBtn.Click

        If DataDirectoryBox.Text <> "" Then
            'create and set directory to save scan data
            Dim path As String = DataDirectoryBox.Text
            Dim fs As FileStream = File.Create(path + "\candidate.txt")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("Created Dump File: " + Date.Now)
            fs.Write(info, 0, info.Length)
            fs.Close()
            My.Settings.ScanDataDirectory = path + "\candidate.txt"
            My.Settings.Save()
            MsgBox("Scan data dump directory has been successfully updated to: " + path + "\candidate.txt")
        Else
            MsgBox("You must type a valid directory in this format: C:\Users\Desktop\Folder1\dumpfile.txt", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Error")
        End If





    End Sub

    Private Sub RegionSpecificationBtn_Click(sender As Object, e As EventArgs) Handles RegionSpecificationBtn.Click
        If Q1min.Text <> "" And Q1max.Text <> "" And Q2min.Text <> "" And Q2max.Text <> "" And Q3min.Text <> "" And Q3max.Text <> "" And Q4min.Text <> "" And Q4max.Text <> "" Then
            If Int(Q1min.Text) >= 0 And Int(Q1min.Text) <= 255 And Int(Q1max.Text) >= 0 And Int(Q1max.Text) <= 255 And Int(Q1min.Text) < Int(Q1max.Text) And Int(Q2min.Text) >= 0 And Int(Q2min.Text) <= 255 And Int(Q2max.Text) >= 0 And Int(Q2max.Text) <= 255 And Int(Q2min.Text) < Int(Q2max.Text) And Int(Q3min.Text) >= 0 And Int(Q3min.Text) <= 255 And Int(Q3max.Text) >= 0 And Int(Q3max.Text) <= 255 And Int(Q3min.Text) < Int(Q3max.Text) And Int(Q4min.Text) >= 0 And Int(Q4min.Text) <= 255 And Int(Q4max.Text) >= 0 And Int(Q4max.Text) <= 255 And Int(Q4min.Text) < Int(Q4max.Text) Then
                'user did not break the rules / set corrosponding internet protocol quadredents
                My.Settings.Q1Min = Int(Q1min.Text)
                My.Settings.Q1Max = Int(Q1max.Text)
                My.Settings.Q2Min = Int(Q2min.Text)
                My.Settings.Q2Max = Int(Q2max.Text)
                My.Settings.Q3Min = Int(Q3min.Text)
                My.Settings.Q3Max = Int(Q3max.Text)
                My.Settings.Q4Min = Int(Q4min.Text)
                My.Settings.Q4Max = Int(Q4max.Text)
                My.Settings.Save()
                MsgBox("Using specified region set!" + Environment.NewLine + "Q1: " + Str(My.Settings.Q1Min) + "-" + Str(My.Settings.Q1Max) + " Q2: " + Str(My.Settings.Q2Min) + "-" + Str(My.Settings.Q2Max) + " Q3: " + Str(My.Settings.Q3Min) + "-" + Str(My.Settings.Q3Max) + " Q4: " + Str(My.Settings.Q4Min) + "-" + Str(My.Settings.Q4Max), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
            Else
                MsgBox("Please make sure all numbers entered in the input feilds are less than 255 and greater than a negitive number", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
            End If
        Else
            MsgBox("None of the required feilds can be left blank! Please input a number between 1 and 255.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End If

    End Sub

    Private Sub RegionUSARaido_CheckedChanged(sender As Object, e As EventArgs) Handles RegionUSARaido.CheckedChanged
        'USA
        'Q1 12 - 68
        'Q2 0 - 245
        'Q3 2 - 251
        'Q4 0 - 255

        'user selected USA
        If RegionUSARaido.Checked = True Then
            My.Settings.Q1Min = 12
            My.Settings.Q1Max = 68
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 245
            My.Settings.Q3Min = 2
            My.Settings.Q3Max = 251
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region USA!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.ScanPropogateAutomation = True
            My.Settings.Save()
            MsgBox("Automation Enabled!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Auto ON!")
        Else
            My.Settings.ScanPropogateAutomation = False
            My.Settings.Save()
            MsgBox("Automation Disabled!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Auto OFF!")
        End If


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            My.Settings.Q1Min = 3
            My.Settings.Q1Max = 217
            My.Settings.Q2Min = 6
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Canada!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            My.Settings.Q1Min = 1
            My.Settings.Q1Max = 185
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 238
            My.Settings.Q3Min = 2
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Spain!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            My.Settings.Q1Min = 95
            My.Settings.Q1Max = 217
            My.Settings.Q2Min = 12
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Russia!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            My.Settings.Q1Min = 5
            My.Settings.Q1Max = 217
            My.Settings.Q2Min = 1
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 1
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Germany!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            My.Settings.Q1Min = 5
            My.Settings.Q1Max = 217
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 249
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region UK!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            My.Settings.Q1Min = 1
            My.Settings.Q1Max = 223
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region China!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        If RadioButton9.Checked = True Then
            My.Settings.Q1Min = 1
            My.Settings.Q1Max = 223
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Australia!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked = True Then
            My.Settings.Q1Min = 1
            My.Settings.Q1Max = 223
            My.Settings.Q2Min = 0
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Japan!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then
            My.Settings.Q1Min = 23
            My.Settings.Q1Max = 217
            My.Settings.Q2Min = 1
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region Mexico!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        If RadioButton10.Checked = True Then
            My.Settings.Q1Min = 1
            My.Settings.Q1Max = 223
            My.Settings.Q2Min = 1
            My.Settings.Q2Max = 255
            My.Settings.Q3Min = 0
            My.Settings.Q3Max = 255
            My.Settings.Q4Min = 0
            My.Settings.Q4Max = 255
            My.Settings.Save()
            MsgBox("Selected and using region India!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Region Set")
        End If
    End Sub
End Class
