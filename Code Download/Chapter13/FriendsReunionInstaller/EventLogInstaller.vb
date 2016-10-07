Imports System.Collections
Imports System.Configuration.Install
Imports System.Diagnostics

<System.ComponentModel.RunInstaller(True)> _
Public Class EventLogInstaller
  Inherits Installer

  Public Overrides Sub Install(ByVal stateSaver As IDictionary)
    MyBase.Install(stateSaver)
    Try
      EventLog.CreateEventSource("FriendsReunion", "Application")
    Catch ex As ArgumentException
      Context.LogMessage(ex.Message)
    End Try
  End Sub

  Public Overrides Sub Uninstall(ByVal savedState As IDictionary)
    EventLog.DeleteEventSource("FriendsReunion")
    MyBase.Uninstall(savedState)
  End Sub

End Class
