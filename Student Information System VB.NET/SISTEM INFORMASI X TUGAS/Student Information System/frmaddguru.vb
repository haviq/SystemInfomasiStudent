Imports System.Data.OleDb
Public Class frmaddguru
    Private Sub frmadd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call cleartext()
        txtsn.Focus()
        frmutamaguru.lstguru.SelectedItems.Clear()
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
        If txtsn.Text = "" Or txtfn.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("jangan dikosongin", MsgBoxStyle.Information, "Missing data")
            Exit Sub
        End If
        Try
            Call openconnection()
            OleDa.InsertCommand = New OleDbCommand()
            OleDa.InsertCommand.CommandText = "INSERT INTO tbguru (idguru, namaguru, alamat, notelp, status)" &
            "VALUES (@idguru , @namaguru, @alamat, @notelp, @status)"
            OleDa.InsertCommand.Connection = OleCn
            OleDa.InsertCommand.Parameters.Add("@idguru", OleDbType.VarWChar, 50, "idguru").Value = txtsn.Text
            OleDa.InsertCommand.Parameters.Add("@namaguru", OleDbType.VarWChar, 50, "namaguru").Value = txtfn.Text
            OleDa.InsertCommand.Parameters.Add("@alamat", OleDbType.VarWChar, 50, "alamat").Value = txtln.Text
            OleDa.InsertCommand.Parameters.Add("@notelp", OleDbType.Numeric, 50, "notlp").Value = tbtelp.Text
            OleDa.InsertCommand.Parameters.Add("@status", OleDbType.VarWChar, 50, "status").Value = cmbstatus.Text

            OleDa.InsertCommand.ExecuteNonQuery()
            Call frmutamaguru.LoadListView()
            Call closeconnection()

            MsgBox("Data Disimpan", MsgBoxStyle.Information, "Disimpan")
            Me.Close()

        Catch ex As Exception
            MsgBox("EROR", MsgBoxStyle.Information, "Error")

            Call closeconnection()

            txtsn.Focus()
            txtsn.SelectAll()

        End Try
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class