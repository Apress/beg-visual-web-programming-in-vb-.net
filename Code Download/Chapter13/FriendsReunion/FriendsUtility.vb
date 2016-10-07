Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Caching

Friend Class FriendsUtility
  Public Shared Function GetPlacesDataSet() As DataSet
    ' If it's already cached, return it.
    Dim ds As DataSet = CType(HttpContext.Current.Cache("Places"), DataSet)
    If Not (ds Is Nothing) Then
      Return ds
    End If
    ' Generate the new dataset.
    Dim con As New SqlConnection( _
      ConfigurationSettings.AppSettings("cnFriends.ConnectionString"))

    Dim adPlaces As SqlDataAdapter
    adPlaces = New SqlDataAdapter("SELECT * FROM Place ORDER BY TypeID", con)
    adPlaces.Fill(ds, "Places")

    ' Reset the dependency flag.
    HttpContext.Current.Cache("PlacesChanged") = False

    ' Create a dependency based on the "PlacesChanged" cache key
    Dim dependencyKeys() As String = {"PlacesChanged"}
    Dim dependency As New CacheDependency(Nothing, dependencyKeys)

    ' Insert the dataset into the cache, 
    ' with a dependency to the "PlacesChanged" key
    HttpContext.Current.Cache.Insert("Places", ds, dependency)

    Return ds
  End Function

End Class
