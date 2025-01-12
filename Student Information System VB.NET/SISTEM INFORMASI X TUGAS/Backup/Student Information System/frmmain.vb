Imports System.Data.OleDb
Public Class frmmain
    Dim Oledr As OleDbDataReader
    Dim Item As New ListViewItem()
    Dim ItemSearch As New ListViewItem
    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListStudentColumns(lststudent)
        Call openconnection()
        Call Initialized()
        Call LoadListView()
        Call closeconnection()
    End Sub
    Public Sub LoadListView()
        lststudent.Items.Clear()
        Call Initialized()
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            Item = lststudent.Items.Add(Oledr("studentno").ToString())
            Item.SubItems.Add(Oledr("firstname").ToString())
            Item.SubItems.Add(Oledr("lastname").ToString())
            Item.SubItems.Add(Oledr("course").ToString())

        Loop
        Oledr.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmadd.ShowDialog()
    End Sub
    Private Function UpdateValidateStudent() As Boolean
        If lststudent.Items.Count = 0 Then
            MsgBox("No records.", MsgBoxStyle.Information, "No Records")
            Return True
            Exit Function
        End If
        If lststudent.SelectedItems.Count > 1 Then
            MsgBox("Double click the record", MsgBoxStyle.Information)
            lststudent.SelectedItems.Clear()
            Return True
            Exit Function
        End If
        If lststudent.SelectedItems.Count = 0 Then
            MsgBox("Please choose the record you want to edit", MsgBoxStyle.Information)
            Return True
            Exit Function
        End If
    End Function

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If UpdateValidateStudent() = True Then
            Return
        End If
        frmedit.ShowDialog()
    End Sub
    Private Function DeleteStudentValidate() As Boolean
        If lststudent.Items.Count = 0 Then
            MsgBox("No Records to delete")
            Return True
            Exit Function
        End If
        If lststudent.SelectedItems.Count = 0 Then
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
            lststudent.SelectedItems.Clear()
            Exit Sub
        End If
        For Each Item As ListViewItem In lststudent.SelectedItems
            Item.Remove()
            OleDa.DeleteCommand = New OleDbCommand()
            Call openconnection()
            OleDa.DeleteCommand.CommandText = "DELETE FROM tblstudent WHERE studentno = @studentno"
            OleDa.DeleteCommand.Connection = OleCn
            OleDa.DeleteCommand.Parameters.Add("@studentno", OleDbType.VarChar, 50, "studentno").Value = Item.Text.ToString()
            OleDa.DeleteCommand.ExecuteNonQuery()
            Call LoadListView()
            Call closeconnection()
        Next
        MsgBox("Record Deleted")
        lststudent.SelectedItems.Clear()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call openconnection()
        Call Initialized()
        Call LoadListView()
        Call closeconnection()
        txtSearch.Clear()
        MsgBox("Total Records = " & lststudent.Items.Count, MsgBoxStyle.Information, "Record")
    End Sub
    Private Sub SearchStudent()
        lststudent.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tblstudent WHERE studentno Like '%%" & txtSearch.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            ItemSearch = lststudent.Items.Add(Oledr("studentno").ToString())
            ItemSearch.SubItems.Add(Oledr("firstname").ToString())
            ItemSearch.SubItems.Add(Oledr("lastname").ToString())
            ItemSearch.SubItems.Add(Oledr("course").ToString())

        Loop
        Oledr.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tblstudent WHERE studentno Like '%%'"
        OleDa.SelectCommand.Connection = OleCn
        Call openconnection()
        OleDa.SelectCommand.ExecuteNonQuery()
        Call SearchStudent()
        Call closeconnection()
    End Sub
End Class