Imports System.Data.OleDb
Public Class frmedit

    Private Sub frmedit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call cleartext()
        txtsn.Focus()
        frmmain.lststudent.SelectedItems.Clear()
    End Sub

    Private Sub frmedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call openconnection()
        Call Initialized()
        txtsn.Text = CStr(frmmain.lststudent.SelectedItems(0).Text)
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
        OleDa.SelectCommand.CommandText = "SELECT * From tblstudent WHERE nosiswa = @nosiswa"
        OleDa.SelectCommand.Parameters.Add("@nosiswa", OleDbType.VarWChar, 50, "nosiswa").Value = txtsn.Text
        OleDa.SelectCommand.Connection = OleCn
        OleDr = OleDa.SelectCommand.ExecuteReader()

        If OleDr.HasRows() Then
            OleDr.Read()
            txtsn.Text = OleDr("nosiswa").ToString()
            txtfn.Text = OleDr("namadepan").ToString()
            txtln.Text = OleDr("namabelakang").ToString()
            cmbcourse.Text = OleDr("pelajaran").ToString()
        End If
        OleDr.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtsn.Text = "" Or txtfn.Text = "" Or txtln.Text = "" Or cmbcourse.Text = "" Then
            MsgBox("ojo dikosongi")
            Exit Sub
        End If
        Try
            Call openconnection()
            OleDa.UpdateCommand = New OleDbCommand()
            OleDa.UpdateCommand.CommandText = "UPDATE tblstudent SET nosiswa = @nosiswa, namadepan = @namadepan, namabelakang = @namabelakang, pelajaran = @pelajaran WHERE nosiswa = ?"
            OleDa.UpdateCommand.Connection = OleCn
            OleDa.UpdateCommand.Parameters.Add("@nosiswa", OleDbType.VarWChar, 50, "nosiswa").Value = txtsn.Text
            OleDa.UpdateCommand.Parameters.Add("@namadepan", OleDbType.VarWChar, 50, "namadepan").Value = txtfn.Text
            OleDa.UpdateCommand.Parameters.Add("@namabelakang", OleDbType.VarWChar, 50, "namabelakang").Value = txtln.Text
            OleDa.UpdateCommand.Parameters.Add("@pelajaran", OleDbType.VarWChar, 50, "pelajaran").Value = cmbcourse.Text

            OleDa.UpdateCommand.Parameters.Add(New System.Data.OleDb.OleDbParameter("EmpID", System.Data.OleDb.OleDbType.VarWChar, 50, _
                                                System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "studentno", _
                                                System.Data.DataRowVersion.Original, Nothing)).Value = frmmain.lststudent.SelectedItems(0).Text

            OleDa.UpdateCommand.ExecuteNonQuery()
            Call frmmain.LoadListView()
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