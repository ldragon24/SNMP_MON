<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_printer
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
        Me.lvev = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lvev
        '
        Me.lvev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvev.FullRowSelect = True
        Me.lvev.GridLines = True
        Me.lvev.Location = New System.Drawing.Point(0, 0)
        Me.lvev.MultiSelect = False
        Me.lvev.Name = "lvev"
        Me.lvev.Size = New System.Drawing.Size(790, 364)
        Me.lvev.TabIndex = 51
        Me.lvev.UseCompatibleStateImageBehavior = False
        Me.lvev.View = System.Windows.Forms.View.Details
        '
        'frm_printer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 364)
        Me.Controls.Add(Me.lvev)
        Me.Name = "frm_printer"
        Me.Text = "frm_printer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvev As System.Windows.Forms.ListView
End Class
