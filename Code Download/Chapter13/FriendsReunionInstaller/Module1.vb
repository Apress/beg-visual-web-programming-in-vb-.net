Imports System.Diagnostics
Imports System.IO

Module Module1

  Sub Main(ByVal args As String())

    Dim patharg As String = args(0)
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

End Module
