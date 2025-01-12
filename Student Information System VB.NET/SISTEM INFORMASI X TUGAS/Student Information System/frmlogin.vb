Imports System.Data.OleDb
Public Class frmlogin
    Dim con As New OleDbConnection
    Dim passwordtrials As Integer
    Private Sub frmlogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Provider= Microsoft.Jet.oledb.4.0; Data Source = ..\Database1.mdb"
    End Sub
    Public Function verify()
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        con.Open()
        Dim da As New OleDbDataAdapter("select * from tbluser", con)
        da.Fill(dt)

        For Each DataRow In dt.Rows
            If txtuser.Text = DataRow.Item(0) And txtpass.Text = DataRow(1) Then   'Row 0 = username Row 1 = password
                con.Close() 'close the connection
                Return True
            End If
        Next
        con.Close()
        Return False
    End Function

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If verify() = True Then
            Dim progressform As New frmprog()
            progressform.Show()
            Me.Hide()
        Else
            MessageBox.Show("INVALID USERNAME OR PASSWORD")
            passwordtrials = passwordtrials + 1
            txtuser.Text = "123"
            txtpass.Text = "123"
            If passwordtrials >= 3 Then '
                MsgBox("You have reached 3 login attempts. This program will be terminated.")
                End
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
