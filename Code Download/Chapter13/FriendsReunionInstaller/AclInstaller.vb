Imports System.Collections
Imports System.Configuration.Install
Imports System.Diagnostics
Imports System.IO

<System.ComponentModel.RunInstaller(True)> _
Public Class AclInstaller
  Inherits Installer

  Public Overrides Sub Install(ByVal stateSaver As IDictionary)
    MyBase.Install(stateSaver)
    System.Diagnostics.Debugger.Break()
    Dim patharg As String = MyBase.Context.Parameters("path")
    Dim files As String() = MyBase.Context.Parameters("files").Split(","c)

    Dim info As New ProcessStartInfo("cacls")
    info.CreateNoWindow = True
    info.WindowStyle = ProcessWindowStyle.Hidden
    Dim file As String
    For Each file In files
      ' Assign permissions to everyone to read the file.
      info.Arguments = Path.Combine(patharg, file) + " /E /G Everyone:R"
      Process.Start(info)
    Next
  End Sub

End Class
