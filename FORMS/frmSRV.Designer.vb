<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSRV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSRV))
        Me.il70 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbSystem = New System.Windows.Forms.RadioButton()
        Me.rbApplication = New System.Windows.Forms.RadioButton()
        Me.rbSecurity = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.lvev = New System.Windows.Forms.ListView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkErr = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'il70
        '
        Me.il70.ImageStream = CType(resources.GetObject("il70.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.il70.TransparentColor = System.Drawing.Color.Transparent
        Me.il70.Images.SetKeyName(0, "B8.png")
        Me.il70.Images.SetKeyName(1, "servnz.png")
        Me.il70.Images.SetKeyName(2, "ok.png")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 9000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.rbSystem, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbApplication, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbSecurity, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RadioButton1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lvev, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkErr, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1028, 535)
        Me.TableLayoutPanel1.TabIndex = 46
        '
        'rbSystem
        '
        Me.rbSystem.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbSystem.AutoSize = True
        Me.rbSystem.Checked = True
        Me.rbSystem.Location = New System.Drawing.Point(3, 9)
        Me.rbSystem.Name = "rbSystem"
        Me.rbSystem.Size = New System.Drawing.Size(69, 17)
        Me.rbSystem.TabIndex = 46
        Me.rbSystem.TabStop = True
        Me.rbSystem.Text = "Система"
        Me.rbSystem.UseVisualStyleBackColor = True
        '
        'rbApplication
        '
        Me.rbApplication.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbApplication.AutoSize = True
        Me.rbApplication.Location = New System.Drawing.Point(78, 9)
        Me.rbApplication.Name = "rbApplication"
        Me.rbApplication.Size = New System.Drawing.Size(89, 17)
        Me.rbApplication.TabIndex = 47
        Me.rbApplication.Text = "Приложения"
        Me.rbApplication.UseVisualStyleBackColor = True
        '
        'rbSecurity
        '
        Me.rbSecurity.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbSecurity.AutoSize = True
        Me.rbSecurity.Location = New System.Drawing.Point(173, 9)
        Me.rbSecurity.Name = "rbSecurity"
        Me.rbSecurity.Size = New System.Drawing.Size(97, 17)
        Me.rbSecurity.TabIndex = 48
        Me.rbSecurity.Text = "Безопасность"
        Me.rbSecurity.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(276, 9)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(119, 17)
        Me.RadioButton1.TabIndex = 51
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Список процессов"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'lvev
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lvev, 10)
        Me.lvev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvev.FullRowSelect = True
        Me.lvev.GridLines = True
        Me.lvev.Location = New System.Drawing.Point(3, 67)
        Me.lvev.MultiSelect = False
        Me.lvev.Name = "lvev"
        Me.lvev.Size = New System.Drawing.Size(1022, 465)
        Me.lvev.TabIndex = 50
        Me.lvev.UseCompatibleStateImageBehavior = False
        Me.lvev.View = System.Windows.Forms.View.Details
        '
        'DateTimePicker1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.DateTimePicker1, 2)
        Me.DateTimePicker1.Location = New System.Drawing.Point(3, 38)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(162, 20)
        Me.DateTimePicker1.TabIndex = 52
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(401, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 29)
        Me.Button1.TabIndex = 49
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkErr
        '
        Me.chkErr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkErr.AutoSize = True
        Me.chkErr.Location = New System.Drawing.Point(173, 41)
        Me.chkErr.Name = "chkErr"
        Me.chkErr.Size = New System.Drawing.Size(97, 17)
        Me.chkErr.TabIndex = 54
        Me.chkErr.Text = "Error, Warning"
        Me.chkErr.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(276, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 23)
        Me.Button2.TabIndex = 53
        Me.Button2.Text = "Запросить"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmSRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 535)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmSRV"
        Me.Text = "Журналы событий"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents il70 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbSystem As System.Windows.Forms.RadioButton
    Friend WithEvents rbApplication As System.Windows.Forms.RadioButton
    Friend WithEvents rbSecurity As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvev As System.Windows.Forms.ListView
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkErr As System.Windows.Forms.CheckBox
End Class
