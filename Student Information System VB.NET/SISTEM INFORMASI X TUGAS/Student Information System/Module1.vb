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
            .Columns.Add("nosiswa", 120)
            .Columns.Add("namadepan", 150)
            .Columns.Add("namabelakang", 180)
            .Columns.Add("pelajaran", 120)
            .FullRowSelect = True
            .MultiSelect = True
            .GridLines = True
            .HideSelection = False
            .View = View.Details
        End With
    End Sub
    Public Sub ListGuruColumns(ByVal Lv As ListView)
        With Lv
            .Columns.Add("idguru", 120)
            .Columns.Add("namaguru", 150)
            .Columns.Add("alamat", 180)
            .Columns.Add("notelp", 120)
            .Columns.Add("status", 180)
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
    Public Sub tabels()
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "Select * from tbguru"
        OleDa.SelectCommand.Connection = OleCn
    End Sub
End Module
