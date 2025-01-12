Public Class frmprog
    Private Sub frmProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < ProgressBar1.Maximum Then
            ProgressBar1.Value += ProgressBar1.Step
        Else
            Timer1.Stop()
            Timer1.Enabled = False
            Me.Hide()
            frmmain.Show()
            Me.Close()
        End If
    End Sub
End Class