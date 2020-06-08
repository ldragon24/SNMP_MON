<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdit_Dev_spr
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
        Me.components = New System.ComponentModel.Container()
        Me.lstDevice = New System.Windows.Forms.ListView()
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.РедактироватьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstDevice
        '
        Me.lstDevice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstDevice.FullRowSelect = True
        Me.lstDevice.GridLines = True
        Me.lstDevice.Location = New System.Drawing.Point(0, 0)
        Me.lstDevice.Name = "lstDevice"
        Me.lstDevice.Size = New System.Drawing.Size(599, 353)
        Me.lstDevice.TabIndex = 47
        Me.lstDevice.UseCompatibleStateImageBehavior = False
        Me.lstDevice.View = System.Windows.Forms.View.Details
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.РедактироватьToolStripMenuItem, Me.УдалитьToolStripMenuItem})
        Me.cmenu.Name = "cmenu"
        Me.cmenu.Size = New System.Drawing.Size(155, 48)
        '
        'РедактироватьToolStripMenuItem
        '
        Me.РедактироватьToolStripMenuItem.Image = Global.SNMP_BKO_MON.My.Resources.Resources.editservice
        Me.РедактироватьToolStripMenuItem.Name = "РедактироватьToolStripMenuItem"
        Me.РедактироватьToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.РедактироватьToolStripMenuItem.Text = "Редактировать"
        '
        'УдалитьToolStripMenuItem
        '
        Me.УдалитьToolStripMenuItem.Image = Global.SNMP_BKO_MON.My.Resources.Resources.delete
        Me.УдалитьToolStripMenuItem.Name = "УдалитьToolStripMenuItem"
        Me.УдалитьToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.УдалитьToolStripMenuItem.Text = "Удалить"
        '
        'frmEdit_Dev_spr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 353)
        Me.Controls.Add(Me.lstDevice)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEdit_Dev_spr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Редактирование моделей устройств"
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstDevice As System.Windows.Forms.ListView
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents РедактироватьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents УдалитьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
