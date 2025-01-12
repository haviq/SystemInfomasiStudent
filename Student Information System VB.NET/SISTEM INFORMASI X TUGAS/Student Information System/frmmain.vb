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
            Item = lststudent.Items.Add(Oledr("nosiswa").ToString())
            Item.SubItems.Add(Oledr("namadepan").ToString())
            Item.SubItems.Add(Oledr("namabelakang").ToString())
            Item.SubItems.Add(Oledr("pelajaran").ToString())

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
            OleDa.DeleteCommand.CommandText = "DELETE FROM tblstudent WHERE nosiswa = @nosiswa"
            OleDa.DeleteCommand.Connection = OleCn
            OleDa.DeleteCommand.Parameters.Add("@nosiswa", OleDbType.VarChar, 50, "nosiswa").Value = Item.Text.ToString()
            OleDa.DeleteCommand.ExecuteNonQuery()
            Call LoadListView()
            Call closeconnection()
        Next
        MsgBox("DATA BERHASIL DIHAPUS")
        lststudent.SelectedItems.Clear()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call openconnection()
        Call Initialized()
        Call LoadListView()
        Call closeconnection()
        txtSearch.Clear()
        MsgBox("Total Data = " & lststudent.Items.Count, MsgBoxStyle.Information, "Record")
    End Sub
    Private Sub SearchStudent()
        lststudent.Items.Clear()
        Call Initialized()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tblstudent WHERE nosiswa Like '%%" & txtSearch.Text.Trim.ToString() & "%%'"

        OleDa.SelectCommand.Connection = OleCn
        Oledr = OleDa.SelectCommand.ExecuteReader()
        Do While Oledr.Read()
            ItemSearch = lststudent.Items.Add(Oledr("nosiswa").ToString())
            ItemSearch.SubItems.Add(Oledr("namadepan").ToString())
            ItemSearch.SubItems.Add(Oledr("namabelakang").ToString())
            ItemSearch.SubItems.Add(Oledr("pelajaran").ToString())

        Loop
        Oledr.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * FROM tblstudent WHERE nosiswa Like '%%'"
        OleDa.SelectCommand.Connection = OleCn
        Call openconnection()
        OleDa.SelectCommand.ExecuteNonQuery()
        Call SearchStudent()
        Call closeconnection()
    End Sub
    Private Sub btnTentang_Click(sender As Object, e As EventArgs) Handles btnTentang.Click
        aboutform.ShowDialog()
    End Sub

    Private Sub Bntguru_Click(sender As Object, e As EventArgs) Handles Bntguru.Click
        frmutamaguru.ShowDialog()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class