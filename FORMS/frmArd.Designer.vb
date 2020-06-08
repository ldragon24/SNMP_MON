<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArd
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArd))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblH = New System.Windows.Forms.Label()
        Me.ARD_THEMP = New SNMP_BKO_MON.ProgBar_VerticalTEXT()
        Me.v_n_t = New SNMP_BKO_MON.ProgBar_Vert_notext()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(163, 549)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblH
        '
        Me.lblH.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblH.BackColor = System.Drawing.Color.Transparent
        Me.lblH.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblH.Location = New System.Drawing.Point(56, 456)
        Me.lblH.Name = "lblH"
        Me.lblH.Size = New System.Drawing.Size(49, 25)
        Me.lblH.TabIndex = 4
        Me.lblH.Text = "50%"
        Me.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ARD_THEMP
        '
        Me.ARD_THEMP.Location = New System.Drawing.Point(71, 71)
        Me.ARD_THEMP.Maximum = 55
        Me.ARD_THEMP.Name = "ARD_THEMP"
        Me.ARD_THEMP.Size = New System.Drawing.Size(20, 231)
        Me.ARD_THEMP.TabIndex = 1
        '
        'v_n_t
        '
        Me.v_n_t.Location = New System.Drawing.Point(71, 297)
        Me.v_n_t.Name = "v_n_t"
        Me.v_n_t.Size = New System.Drawing.Size(20, 147)
        Me.v_n_t.TabIndex = 3
        '
        'frmArd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(159, 550)
        Me.Controls.Add(Me.lblH)
        Me.Controls.Add(Me.ARD_THEMP)
        Me.Controls.Add(Me.v_n_t)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmArd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmArd"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ARD_THEMP As SNMP_BKO_MON.ProgBar_VerticalTEXT
    Friend WithEvents v_n_t As SNMP_BKO_MON.ProgBar_Vert_notext
    Friend WithEvents lblH As System.Windows.Forms.Label
End Class
