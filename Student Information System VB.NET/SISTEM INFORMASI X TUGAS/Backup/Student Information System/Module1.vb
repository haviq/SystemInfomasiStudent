Imports System.Data.OleDb
Module Module1
    Dim Provider As String
    Public OleCn As New OleDbConnection()
    Public OleDa As New OleDbDataAdapter()
    Public Function OledbConnectionString() As String
        Provider = "Provider= Microsoft.Jet.oledb.4.0; Data Source = ..\Database1.mdb"
        Return Provider
    End Function
    Public Sub ListStudentColumns(ByVal Lv As ListView)
        With Lv
            .Columns.Add("studentno", 120)
            .Columns.Add("firstname", 150)
            .Columns.Add("lastname", 180)
            .Columns.Add("course", 120)
            .FullRowSelect = True
            .MultiSelect = True
            .GridLines = True
            .HideSelection = False
            .View = View.Details
        End With
    End Sub
    Public Sub openconnection()
        If OleCn.State <> ConnectionState.Open Then
            OleCn.ConnectionString = OledbConnectionString()
            OleCn.Open()
        End If
    End Sub
    Public Sub closeconnection()
        OleCn.Close()
    End Sub
    Public Sub Initialized()
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "Select * from tblstudent"
        OleDa.SelectCommand.Connection = OleCn
    End Sub
End Module
