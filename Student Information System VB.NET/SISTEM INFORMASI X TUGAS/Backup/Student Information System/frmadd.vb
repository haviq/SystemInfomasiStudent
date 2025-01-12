Imports System.Data.OleDb
Public Class frmadd

    Private Sub frmadd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call cleartext()
        txtsn.Focus()
        frmmain.lststudent.SelectedItems.Clear()
    End Sub

    Private Sub frmadd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub cleartext()
        Me.txtsn.Clear()
        Me.txtfn.Clear()
        Me.txtln.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtsn.Text = "" Or txtfn.Text = "" Or cmbcourse.Text = "" Then
            MsgBox("Please don't leave blank textfields", MsgBoxStyle.Information, "Missing data")
            Exit Sub
        End If
        Try
            Call openconnection()
            OleDa.InsertCommand = New OleDbCommand()
            OleDa.InsertCommand.CommandText = "INSERT INTO tblstudent (studentno, firstname, lastname, course)" & _
            "VALUES (@studentno , @firstname, @lastname, @course)"
            OleDa.InsertCommand.Connection = OleCn
            OleDa.InsertCommand.Parameters.Add("@studentno", OleDbType.VarWChar, 50, "studentno").Value = txtsn.Text
            OleDa.InsertCommand.Parameters.Add("@firstname", OleDbType.VarWChar, 50, "firstname").Value = txtfn.Text
            OleDa.InsertCommand.Parameters.Add("@lastname", OleDbType.VarWChar, 50, "lastname").Value = txtln.Text
            OleDa.InsertCommand.Parameters.Add("@course", OleDbType.VarWChar, 50, "course").Value = cmbcourse.Text

            OleDa.InsertCommand.ExecuteNonQuery()
            Call frmmain.LoadListView()
            Call closeconnection()

            MsgBox("Records Saved", MsgBoxStyle.Information, "Saved")
            Me.Close()

        Catch ex As Exception
            MsgBox("Cannot Save this record, Existing Student Number", MsgBoxStyle.Information, "Error")

            Call closeconnection()

            txtsn.Focus()
            txtsn.SelectAll()

        End Try
    End Sub
End Class