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
            MsgBox("jangan dikosongin", MsgBoxStyle.Information, "Missing data")
            Exit Sub
        End If
        Try
            Call openconnection()
            OleDa.InsertCommand = New OleDbCommand()
            OleDa.InsertCommand.CommandText = "INSERT INTO tblstudent (nosiswa, namadepan, namabelakang, pelajaran)" &
            "VALUES (@nosiswa , @namadepan, @namabelakang, @pelajaran)"
            OleDa.InsertCommand.Connection = OleCn
            OleDa.InsertCommand.Parameters.Add("@nosiswa", OleDbType.VarWChar, 50, "nosiswa").Value = txtsn.Text
            OleDa.InsertCommand.Parameters.Add("@namadepan", OleDbType.VarWChar, 50, "namadepan").Value = txtfn.Text
            OleDa.InsertCommand.Parameters.Add("@namabelakang", OleDbType.VarWChar, 50, "namabelakang").Value = txtln.Text
            OleDa.InsertCommand.Parameters.Add("@pelajaran", OleDbType.VarWChar, 50, "pelajaran").Value = cmbcourse.Text

            OleDa.InsertCommand.ExecuteNonQuery()
            Call frmmain.LoadListView()
            Call closeconnection()

            MsgBox("Records Saved", MsgBoxStyle.Information, "Saved")
            Me.Close()

        Catch ex As Exception
            MsgBox("ERORr", MsgBoxStyle.Information, "Error")

            Call closeconnection()

            txtsn.Focus()
            txtsn.SelectAll()

        End Try
    End Sub

    Private Sub cmbcourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcourse.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class