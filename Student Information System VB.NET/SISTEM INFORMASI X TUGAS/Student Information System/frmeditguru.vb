Imports System.Data.OleDb
Public Class frmeditguru
    Private Sub frmeditguru_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call cleartext()
        txtsn.Focus()
        frmutamaguru.lstguru.SelectedItems.Clear()
    End Sub

    Private Sub frmeditguru_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call openconnection()
        Call tabels()
        txtsn.Text = CStr(frmutamaguru.lstguru.SelectedItems(0).Text)
        Call Fill()
        Call closeconnection()
    End Sub
    Private Sub cleartext()
        Me.txtsn.Clear()
        Me.txtfn.Clear()
        Me.txtln.Clear()
    End Sub
    Private Sub Fill()
        Dim OleDr As OleDbDataReader
        OleDa.SelectCommand = New OleDbCommand()
        OleDa.SelectCommand.CommandText = "SELECT * From tbguru WHERE idguru = @idguru"
        OleDa.SelectCommand.Parameters.Add("@idguru", OleDbType.VarWChar, 50, "idguru").Value = txtsn.Text
        OleDa.SelectCommand.Connection = OleCn
        OleDr = OleDa.SelectCommand.ExecuteReader()

        If OleDr.HasRows() Then
            OleDr.Read()
            txtsn.Text = OleDr("idguru").ToString()
            txtfn.Text = OleDr("namaguru").ToString()
            txtln.Text = OleDr("alamat").ToString()
            tbtelp.Text = OleDr("notelp").ToString()
            cmbstatus.Text = OleDr("status").ToString()
        End If
        OleDr.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtsn.Text = "" Or txtfn.Text = "" Or txtln.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("ojo dikosongi")
            Exit Sub
        End If
        Try
            Call openconnection()
            OleDa.UpdateCommand = New OleDbCommand()
            OleDa.UpdateCommand.CommandText = "UPDATE tbguru SET idguru = @idguru, namaguru = @namaguru, alamat = @alamat, notelp = @notelp WHERE idguru = ?"
            OleDa.UpdateCommand.Connection = OleCn
            OleDa.UpdateCommand.Parameters.Add("@idguru", OleDbType.VarWChar, 50, "idguru").Value = txtsn.Text
            OleDa.UpdateCommand.Parameters.Add("@namaguru", OleDbType.VarWChar, 50, "namaguru").Value = txtfn.Text
            OleDa.UpdateCommand.Parameters.Add("@alamat", OleDbType.VarWChar, 50, "alamat").Value = txtln.Text
            OleDa.UpdateCommand.Parameters.Add("@notelp", OleDbType.Numeric, 50, "notelp").Value = tbtelp.Text
            OleDa.UpdateCommand.Parameters.Add("@status", OleDbType.VarWChar, 50, "status").Value = cmbstatus.Text

            OleDa.UpdateCommand.Parameters.Add(New System.Data.OleDb.OleDbParameter("EmpID", System.Data.OleDb.OleDbType.VarWChar, 50,
                                                System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "idguru",
                                                System.Data.DataRowVersion.Original, Nothing)).Value = frmutamaguru.lstguru.SelectedItems(0).Text

            OleDa.UpdateCommand.ExecuteNonQuery()
            Call frmutamaguru.LoadListView()
            Call closeconnection()

            MsgBox("DATA DIPERBARUI")
            Me.Close()

        Catch ex As Exception
            MsgBox("Cannot Update StudentNo is present")
            Call closeconnection()
            txtsn.Focus()
            txtsn.SelectAll()
        End Try
    End Sub
End Class