<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCiscoPort
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
        Me.lstComm = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'lstComm
        '
        Me.lstComm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstComm.FullRowSelect = True
        Me.lstComm.GridLines = True
        Me.lstComm.Location = New System.Drawing.Point(0, 0)
        Me.lstComm.Name = "lstComm"
        Me.lstComm.Size = New System.Drawing.Size(801, 431)
        Me.lstComm.TabIndex = 44
        Me.lstComm.UseCompatibleStateImageBehavior = False
        Me.lstComm.View = System.Windows.Forms.View.Details
        '
        'frmCiscoPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 431)
        Me.Controls.Add(Me.lstComm)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmCiscoPort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCiscoPort"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstComm As System.Windows.Forms.ListView
End Class
