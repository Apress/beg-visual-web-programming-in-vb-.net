﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class PlaceData
    Inherits DataSet
    
    Private tablePlace As PlaceDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Place")) Is Nothing) Then
                Me.Tables.Add(New PlaceDataTable(ds.Tables("Place")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Place As PlaceDataTable
        Get
            Return Me.tablePlace
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As PlaceData = CType(MyBase.Clone,PlaceData)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Place")) Is Nothing) Then
            Me.Tables.Add(New PlaceDataTable(ds.Tables("Place")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tablePlace = CType(Me.Tables("Place"),PlaceDataTable)
        If (Not (Me.tablePlace) Is Nothing) Then
            Me.tablePlace.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "PlaceData"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/PlaceData.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tablePlace = New PlaceDataTable
        Me.Tables.Add(Me.tablePlace)
    End Sub
    
    Private Function ShouldSerializePlace() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub PlaceRowChangeEventHandler(ByVal sender As Object, ByVal e As PlaceRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class PlaceDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnPlaceID As DataColumn
        
        Private columnTypeID As DataColumn
        
        Private columnName As DataColumn
        
        Private columnAddress As DataColumn
        
        Private columnNotes As DataColumn
        
        Private columnAdministratorID As DataColumn
        
        Private columnTypeName As DataColumn
        
        Friend Sub New()
            MyBase.New("Place")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property PlaceIDColumn As DataColumn
            Get
                Return Me.columnPlaceID
            End Get
        End Property
        
        Friend ReadOnly Property TypeIDColumn As DataColumn
            Get
                Return Me.columnTypeID
            End Get
        End Property
        
        Friend ReadOnly Property NameColumn As DataColumn
            Get
                Return Me.columnName
            End Get
        End Property
        
        Friend ReadOnly Property AddressColumn As DataColumn
            Get
                Return Me.columnAddress
            End Get
        End Property
        
        Friend ReadOnly Property NotesColumn As DataColumn
            Get
                Return Me.columnNotes
            End Get
        End Property
        
        Friend ReadOnly Property AdministratorIDColumn As DataColumn
            Get
                Return Me.columnAdministratorID
            End Get
        End Property
        
        Friend ReadOnly Property TypeNameColumn As DataColumn
            Get
                Return Me.columnTypeName
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As PlaceRow
            Get
                Return CType(Me.Rows(index),PlaceRow)
            End Get
        End Property
        
        Public Event PlaceRowChanged As PlaceRowChangeEventHandler
        
        Public Event PlaceRowChanging As PlaceRowChangeEventHandler
        
        Public Event PlaceRowDeleted As PlaceRowChangeEventHandler
        
        Public Event PlaceRowDeleting As PlaceRowChangeEventHandler
        
        Public Overloads Sub AddPlaceRow(ByVal row As PlaceRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddPlaceRow(ByVal PlaceID As String, ByVal TypeID As String, ByVal Name As String, ByVal Address As String, ByVal Notes As String, ByVal AdministratorID As String, ByVal TypeName As String) As PlaceRow
            Dim rowPlaceRow As PlaceRow = CType(Me.NewRow,PlaceRow)
            rowPlaceRow.ItemArray = New Object() {PlaceID, TypeID, Name, Address, Notes, AdministratorID, TypeName}
            Me.Rows.Add(rowPlaceRow)
            Return rowPlaceRow
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As PlaceDataTable = CType(MyBase.Clone,PlaceDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New PlaceDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnPlaceID = Me.Columns("PlaceID")
            Me.columnTypeID = Me.Columns("TypeID")
            Me.columnName = Me.Columns("Name")
            Me.columnAddress = Me.Columns("Address")
            Me.columnNotes = Me.Columns("Notes")
            Me.columnAdministratorID = Me.Columns("AdministratorID")
            Me.columnTypeName = Me.Columns("TypeName")
        End Sub
        
        Private Sub InitClass()
            Me.columnPlaceID = New DataColumn("PlaceID", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnPlaceID)
            Me.columnTypeID = New DataColumn("TypeID", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnTypeID)
            Me.columnName = New DataColumn("Name", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnName)
            Me.columnAddress = New DataColumn("Address", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnAddress)
            Me.columnNotes = New DataColumn("Notes", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnNotes)
            Me.columnAdministratorID = New DataColumn("AdministratorID", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnAdministratorID)
            Me.columnTypeName = New DataColumn("TypeName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnTypeName)
            Me.columnPlaceID.AllowDBNull = false
            Me.columnTypeID.AllowDBNull = false
            Me.columnName.AllowDBNull = false
            Me.columnAdministratorID.AllowDBNull = false
            Me.columnTypeName.AllowDBNull = false
        End Sub
        
        Public Function NewPlaceRow() As PlaceRow
            Return CType(Me.NewRow,PlaceRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New PlaceRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(PlaceRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.PlaceRowChangedEvent) Is Nothing) Then
                RaiseEvent PlaceRowChanged(Me, New PlaceRowChangeEvent(CType(e.Row,PlaceRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.PlaceRowChangingEvent) Is Nothing) Then
                RaiseEvent PlaceRowChanging(Me, New PlaceRowChangeEvent(CType(e.Row,PlaceRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.PlaceRowDeletedEvent) Is Nothing) Then
                RaiseEvent PlaceRowDeleted(Me, New PlaceRowChangeEvent(CType(e.Row,PlaceRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.PlaceRowDeletingEvent) Is Nothing) Then
                RaiseEvent PlaceRowDeleting(Me, New PlaceRowChangeEvent(CType(e.Row,PlaceRow), e.Action))
            End If
        End Sub
        
        Public Sub RemovePlaceRow(ByVal row As PlaceRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class PlaceRow
        Inherits DataRow
        
        Private tablePlace As PlaceDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tablePlace = CType(Me.Table,PlaceDataTable)
        End Sub
        
        Public Property PlaceID As String
            Get
                Return CType(Me(Me.tablePlace.PlaceIDColumn),String)
            End Get
            Set
                Me(Me.tablePlace.PlaceIDColumn) = value
            End Set
        End Property
        
        Public Property TypeID As String
            Get
                Return CType(Me(Me.tablePlace.TypeIDColumn),String)
            End Get
            Set
                Me(Me.tablePlace.TypeIDColumn) = value
            End Set
        End Property
        
        Public Property Name As String
            Get
                Return CType(Me(Me.tablePlace.NameColumn),String)
            End Get
            Set
                Me(Me.tablePlace.NameColumn) = value
            End Set
        End Property
        
        Public Property Address As String
            Get
                Try 
                    Return CType(Me(Me.tablePlace.AddressColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tablePlace.AddressColumn) = value
            End Set
        End Property
        
        Public Property Notes As String
            Get
                Try 
                    Return CType(Me(Me.tablePlace.NotesColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tablePlace.NotesColumn) = value
            End Set
        End Property
        
        Public Property AdministratorID As String
            Get
                Return CType(Me(Me.tablePlace.AdministratorIDColumn),String)
            End Get
            Set
                Me(Me.tablePlace.AdministratorIDColumn) = value
            End Set
        End Property
        
        Public Property TypeName As String
            Get
                Return CType(Me(Me.tablePlace.TypeNameColumn),String)
            End Get
            Set
                Me(Me.tablePlace.TypeNameColumn) = value
            End Set
        End Property
        
        Public Function IsAddressNull() As Boolean
            Return Me.IsNull(Me.tablePlace.AddressColumn)
        End Function
        
        Public Sub SetAddressNull()
            Me(Me.tablePlace.AddressColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsNotesNull() As Boolean
            Return Me.IsNull(Me.tablePlace.NotesColumn)
        End Function
        
        Public Sub SetNotesNull()
            Me(Me.tablePlace.NotesColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class PlaceRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As PlaceRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As PlaceRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As PlaceRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
