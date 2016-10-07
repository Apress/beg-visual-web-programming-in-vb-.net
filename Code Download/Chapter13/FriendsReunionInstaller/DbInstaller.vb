Imports System.Configuration.Install
Imports System.Collections
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

<System.ComponentModel.RunInstaller(True)> _
Public Class DbInstaller
  Inherits Installer

  Public Overrides Sub Install(ByVal stateSaver As IDictionary)
    MyBase.Install(stateSaver)
    ' Warn the user that we need the service to be running.
    MessageBox.Show( _
      "Ensure the SQL Server / MSDE service is running " + _
      "for a proper installation.", _
      "Database Service", MessageBoxButtons.OK, _
      MessageBoxIcon.Warning)
    Dim patharg As String = MyBase.Context.Parameters("db")

    Dim cmd As String = String.Format( _
      "-S (local) -E -Q ""sp_attach_db N'FriendsData', N'{0}', N'{1}'", _
      Path.Combine(patharg, "Friends_Data.mdf"), _
      Path.Combine(patharg, "Friends_Log.ldf"))

    ' Execute the attach DB command.
    Dim p As Process = Process.Start("osql", cmd)
    p.WaitForExit()

    ' Create the apress user
    p = Process.Start("osql", _
      "-S (local) -E -Q ""sp_addlogin @loginame='apress', " + _
      "@passwd='apress', @defdb='FriendsData'""")
    p.WaitForExit()

    ' Set the apress user as owner of the database
    p = Process.Start("osql", _
      "-S (local) -E -d ""FriendsData"" -Q ""sp_adduser 'apress', " + _
      "null, 'db_owner'""")
    p.WaitForExit()
  End Sub

  Public Overrides Sub Uninstall(ByVal savedState As IDictionary)
    ' Warn the user that we need the service to be running.
    MessageBox.Show( _
      "Ensure the SQL Server / MSDE service is running " + _
      "for a proper uninstallation.", _
      "Database Service", MessageBoxButtons.OK, _
      MessageBoxIcon.Warning)
    Process.Start("osql", _
      "-S (local) -E -Q ""sp_detach_db N'FriendsData'""")
    MyBase.Uninstall(savedState)
  End Sub

  Public Overrides Sub Rollback(ByVal savedState As IDictionary)
    MyBase.Uninstall(savedState)
  End Sub
End Class
