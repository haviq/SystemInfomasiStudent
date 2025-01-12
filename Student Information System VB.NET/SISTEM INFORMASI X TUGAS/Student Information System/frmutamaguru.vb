Imports System.Data.OleDb
Public Class frmutamaguru
    Dim Oledr As OleDbDataReader
    Dim Item As New ListViewItem()
    Dim ItemSearch As New ListViewItem

    Private Sub frmutamaguru_Load(sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListGuruColumns(lstguru)
        Call openconnection()
        Call tabels()
        Call LoadListView()
        Call closeconnection()
    End Sub
    Public Sub LoadListView()
        lstguru.Items.Clear()
        Call tabels()
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            Item = lstguru.Items.Add(Oledr("idguru").ToString())
            Item.SubItems.Add(Oledr("namaguru").ToString())
            Item.SubItems.Add(Oledr("alamat").ToString())
            Item.SubItems.Add(Oledr("notelp").ToString())
            Item.SubItems.Add(Oledr("status").ToString())


        Loop
        Oledr.Close()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmaddguru.ShowDialog()
    End Sub
    Private Function UpdateValidateStudent() As Boolean
        If lstguru.Items.Count = 0 Then
            MsgBox("No records.", MsgBoxStyle.Information, "No Records")
            Return True
            Exit Function
        End If
        If lstguru.SelectedItems.Count > 1 Then
            MsgBox("Double click the record", MsgBoxStyle.Information)
            lstguru.SelectedItems.Clear()
            Return True
            Exit Function
        End If
        If lstguru.SelectedItems.Count = 0 Then
            MsgBox("Please choose the record you want to edit", MsgBoxStyle.Information)
            Return True
            Exit Function
        End If
    End Function
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If UpdateValidateStudent() = True Then
            Return
        End If
        frmeditguru.ShowDialog()
    End Sub
    Private Function DeleteStudentValidate() As Boolean
        If lstguru.Items.Count = 0 Then
            MsgBox("No Records to delete")
            Return True
            Exit Function
        End If
        If lstguru.SelectedItems.Count = 0 Then
            MsgBox("Please choose the record you want to delete.")
            Return True
            Exit Function
        End If
    End Function
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If DeleteStudentValidate() = True Then
            Return
        End If

        If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete?") = MsgBoxResult.No Then
            MsgBox("Delete Cancelled.", MsgBoxStyle.Information)
            lstguru.SelectedItems.Clear()
            Exit Sub
        End If
        For Each Item As ListViewItem In lstguru.SelectedItems
            Item.Remove()
            OleDa.DeleteCommand = New OleDbCommand()
            Call openconnection()
            OleDa.DeleteCommand.CommandText = "DELETE FROM tbguru WHERE idguru = @idguru"
            OleDa.DeleteCommand.Connection = OleCn
            OleDa.DeleteCommand.Parameters.Add("@idguru", OleDbType.VarChar, 50, "idguru").Value = Item.Text.ToString()
            OleDa.DeleteCommand.ExecuteNonQuery()
            Call LoadListView()
            Call closeconnection()
        Next
        MsgBox("DATA BERHASIL DIHAPUS")
        lstguru.SelectedItems.Clear()
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call openconnection()
        Call Initialized()
        Call LoadListView()
        Call closeconnection()
        txtSearch.Clear()
        MsgBox("Total Data = " & lstguru.Items.Count, MsgBoxStyle.Information, "Record")
    End Sub
    Private Sub SearchStudent()
        lstguru.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tbguru WHERE idguru Like '%%" & txtSearch.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            ItemSearch = lstguru.Items.Add(Oledr("idguru").ToString())
            ItemSearch.SubItems.Add(Oledr("namaguru").ToString())
            ItemSearch.SubItems.Add(Oledr("alamat").ToString())
            ItemSearch.SubItems.Add(Oledr("notelp").ToString())
            ItemSearch.SubItems.Add(Oledr("status").ToString())


        Loop
        Oledr.Close()
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tbguru WHERE idguru Like '%%'"
        OleDa.SelectCommand.Connection = OleCn
        Call openconnection()
        OleDa.SelectCommand.ExecuteNonQuery()
        Call SearchStudent()
        Call closeconnection()
    End Sub
End Class