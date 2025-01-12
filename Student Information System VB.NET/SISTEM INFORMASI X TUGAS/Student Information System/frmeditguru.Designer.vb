<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmeditguru
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbstatus = New System.Windows.Forms.ComboBox()
        Me.tbtelp = New System.Windows.Forms.TextBox()
        Me.txtln = New System.Windows.Forms.TextBox()
        Me.txtfn = New System.Windows.Forms.TextBox()
        Me.txtsn = New System.Windows.Forms.TextBox()
        Me.txttelp = New System.Windows.Forms.Label()
        Me.txtstatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(225, 268)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(116, 268)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbstatus
        '
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"TETAP", "HONORER"})
        Me.cmbstatus.Location = New System.Drawing.Point(177, 221)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbstatus.TabIndex = 29
        '
        'tbtelp
        '
        Me.tbtelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbtelp.Location = New System.Drawing.Point(177, 181)
        Me.tbtelp.Name = "tbtelp"
        Me.tbtelp.Size = New System.Drawing.Size(128, 20)
        Me.tbtelp.TabIndex = 27
        '
        'txtln
        '
        Me.txtln.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtln.Location = New System.Drawing.Point(177, 143)
        Me.txtln.Name = "txtln"
        Me.txtln.Size = New System.Drawing.Size(128, 20)
        Me.txtln.TabIndex = 28
        '
        'txtfn
        '
        Me.txtfn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfn.Location = New System.Drawing.Point(177, 96)
        Me.txtfn.Name = "txtfn"
        Me.txtfn.Size = New System.Drawing.Size(128, 20)
        Me.txtfn.TabIndex = 26
        '
        'txtsn
        '
        Me.txtsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsn.Location = New System.Drawing.Point(177, 50)
        Me.txtsn.Name = "txtsn"
        Me.txtsn.Size = New System.Drawing.Size(128, 20)
        Me.txtsn.TabIndex = 25
        '
        'txttelp
        '
        Me.txttelp.AutoSize = True
        Me.txttelp.Location = New System.Drawing.Point(100, 184)
        Me.txttelp.Name = "txttelp"
        Me.txttelp.Size = New System.Drawing.Size(63, 13)
        Me.txttelp.TabIndex = 22
        Me.txttelp.Text = "No Telepon"
        '
        'txtstatus
        '
        Me.txtstatus.AutoSize = True
        Me.txtstatus.Location = New System.Drawing.Point(100, 224)
        Me.txtstatus.Name = "txtstatus"
        Me.txtstatus.Size = New System.Drawing.Size(37, 13)
        Me.txtstatus.TabIndex = 24
        Me.txtstatus.Text = "Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Nama Guru"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Id Guru"
        '
        'frmeditguru
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 322)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbstatus)
        Me.Controls.Add(Me.tbtelp)
        Me.Controls.Add(Me.txtln)
        Me.Controls.Add(Me.txtfn)
        Me.Controls.Add(Me.txtsn)
        Me.Controls.Add(Me.txttelp)
        Me.Controls.Add(Me.txtstatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmeditguru"
        Me.Text = "frmeditguru"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbstatus As ComboBox
    Friend WithEvents tbtelp As TextBox
    Friend WithEvents txtln As TextBox
    Friend WithEvents txtfn As TextBox
    Friend WithEvents txtsn As TextBox
    Friend WithEvents txttelp As Label
    Friend WithEvents txtstatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
