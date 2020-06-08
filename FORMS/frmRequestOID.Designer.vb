<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRequestOID
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRequestOID))
        Me.ss1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEnableIbp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.МенюToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.enableIBP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ОпроситьУстройстваToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToExcellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИБПToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КоммутаторыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПринтерыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.СъемныеДискиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОпроситьHDDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СжатьБазуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОпроситьАнтивирусToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОпроситьОбновленияToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОПрограммеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ni = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmenuNI = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ОпроситьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.РазвернутьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetNextOIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.НастройкиToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ВыходToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.zg2 = New ZedGraph.ZedGraphControl()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstUPS = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstComm = New System.Windows.Forms.ListView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvPrinter = New System.Windows.Forms.ListView()
        Me.zgPrn = New ZedGraph.ZedGraphControl()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.zgApparat = New ZedGraph.ZedGraphControl()
        Me.lbApparat = New System.Windows.Forms.ListBox()
        Me.lvApparat = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.btnStopArduino = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvPing = New System.Windows.Forms.ListView()
        Me.lstPing_X = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.zg1 = New ZedGraph.ZedGraphControl()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.zg3 = New ZedGraph.ZedGraphControl()
        Me.lstSRV = New System.Windows.Forms.ListBox()
        Me.lvHDD = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.CheckBox2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.lvAnti = New System.Windows.Forms.ListView()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.lvSystem = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmenuLST = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ОткрытьВБраузереToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОткрытьВPuttyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОткрытьRDPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КачествоПингToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ibpRemoteControl = New System.Windows.Forms.ToolStripMenuItem()
        Me.ibpOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ibpOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ibpTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.calibrationIBP = New System.Windows.Forms.ToolStripMenuItem()
        Me.RealtimeIBP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВходноеНапряжениеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходноеНапряжениеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НагрузкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗарядБатареиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ТемператураToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВольтажБатареиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПингToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TracerouteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СканерПортовToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuWMI = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ОпроситьСерверToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EventLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НаличиеАнтивирусаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.il70 = New System.Windows.Forms.ImageList(Me.components)
        Me.ss1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.cmenuNI.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.cmenuLST.SuspendLayout()
        Me.MnuWMI.SuspendLayout()
        Me.SuspendLayout()
        '
        'ss1
        '
        Me.ss1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.lblEnableIbp})
        Me.ss1.Location = New System.Drawing.Point(0, 524)
        Me.ss1.Name = "ss1"
        Me.ss1.Size = New System.Drawing.Size(1212, 22)
        Me.ss1.TabIndex = 0
        Me.ss1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(22, 17)
        Me.ToolStripStatusLabel3.Text = "---"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'lblEnableIbp
        '
        Me.lblEnableIbp.Name = "lblEnableIbp"
        Me.lblEnableIbp.Size = New System.Drawing.Size(104, 17)
        Me.lblEnableIbp.Text = "Управление ИБП:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.МенюToolStripMenuItem, Me.ОПрограммеToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1212, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'МенюToolStripMenuItem
        '
        Me.МенюToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem, Me.enableIBP, Me.ToolStripMenuItem1, Me.ОпроситьУстройстваToolStripMenuItem, Me.GetNextToolStripMenuItem, Me.TrapsToolStripMenuItem, Me.ToExcellToolStripMenuItem, Me.ToolStripMenuItem5, Me.СъемныеДискиToolStripMenuItem, Me.ToolStripMenuItem2, Me.ВыходToolStripMenuItem, Me.ОпроситьHDDToolStripMenuItem, Me.СжатьБазуToolStripMenuItem, Me.ОпроситьАнтивирусToolStripMenuItem, Me.ОпроситьОбновленияToolStripMenuItem})
        Me.МенюToolStripMenuItem.Name = "МенюToolStripMenuItem"
        Me.МенюToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.МенюToolStripMenuItem.Text = "Меню"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'enableIBP
        '
        Me.enableIBP.Image = CType(resources.GetObject("enableIBP.Image"), System.Drawing.Image)
        Me.enableIBP.Name = "enableIBP"
        Me.enableIBP.Size = New System.Drawing.Size(248, 22)
        Me.enableIBP.Text = "Разрешить управление ИБП"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(245, 6)
        '
        'ОпроситьУстройстваToolStripMenuItem
        '
        Me.ОпроситьУстройстваToolStripMenuItem.Name = "ОпроситьУстройстваToolStripMenuItem"
        Me.ОпроситьУстройстваToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ОпроситьУстройстваToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ОпроситьУстройстваToolStripMenuItem.Text = "Опросить устройства"
        '
        'GetNextToolStripMenuItem
        '
        Me.GetNextToolStripMenuItem.Name = "GetNextToolStripMenuItem"
        Me.GetNextToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.GetNextToolStripMenuItem.Text = "Опрос MIB OID GetNext"
        '
        'TrapsToolStripMenuItem
        '
        Me.TrapsToolStripMenuItem.Name = "TrapsToolStripMenuItem"
        Me.TrapsToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.TrapsToolStripMenuItem.Text = "Traps"
        '
        'ToExcellToolStripMenuItem
        '
        Me.ToExcellToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ИБПToolStripMenuItem, Me.КоммутаторыToolStripMenuItem, Me.ПринтерыToolStripMenuItem})
        Me.ToExcellToolStripMenuItem.Image = CType(resources.GetObject("ToExcellToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ToExcellToolStripMenuItem.Name = "ToExcellToolStripMenuItem"
        Me.ToExcellToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ToExcellToolStripMenuItem.Text = "Передать в Excell"
        '
        'ИБПToolStripMenuItem
        '
        Me.ИБПToolStripMenuItem.Name = "ИБПToolStripMenuItem"
        Me.ИБПToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ИБПToolStripMenuItem.Text = "ИБП"
        '
        'КоммутаторыToolStripMenuItem
        '
        Me.КоммутаторыToolStripMenuItem.Name = "КоммутаторыToolStripMenuItem"
        Me.КоммутаторыToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.КоммутаторыToolStripMenuItem.Text = "Коммутаторы"
        '
        'ПринтерыToolStripMenuItem
        '
        Me.ПринтерыToolStripMenuItem.Name = "ПринтерыToolStripMenuItem"
        Me.ПринтерыToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ПринтерыToolStripMenuItem.Text = "Принтеры"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(245, 6)
        '
        'СъемныеДискиToolStripMenuItem
        '
        Me.СъемныеДискиToolStripMenuItem.Name = "СъемныеДискиToolStripMenuItem"
        Me.СъемныеДискиToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.СъемныеДискиToolStripMenuItem.Text = "Съемные диски"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(245, 6)
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ВыходToolStripMenuItem.Text = "Выход"
        '
        'ОпроситьHDDToolStripMenuItem
        '
        Me.ОпроситьHDDToolStripMenuItem.Name = "ОпроситьHDDToolStripMenuItem"
        Me.ОпроситьHDDToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F10), System.Windows.Forms.Keys)
        Me.ОпроситьHDDToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ОпроситьHDDToolStripMenuItem.Text = "Опросить HDD"
        Me.ОпроситьHDDToolStripMenuItem.Visible = False
        '
        'СжатьБазуToolStripMenuItem
        '
        Me.СжатьБазуToolStripMenuItem.Name = "СжатьБазуToolStripMenuItem"
        Me.СжатьБазуToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.СжатьБазуToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.СжатьБазуToolStripMenuItem.Text = "Сжать базу"
        Me.СжатьБазуToolStripMenuItem.Visible = False
        '
        'ОпроситьАнтивирусToolStripMenuItem
        '
        Me.ОпроситьАнтивирусToolStripMenuItem.Name = "ОпроситьАнтивирусToolStripMenuItem"
        Me.ОпроситьАнтивирусToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.ОпроситьАнтивирусToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ОпроситьАнтивирусToolStripMenuItem.Text = "Опросить Антивирус"
        Me.ОпроситьАнтивирусToolStripMenuItem.Visible = False
        '
        'ОпроситьОбновленияToolStripMenuItem
        '
        Me.ОпроситьОбновленияToolStripMenuItem.Name = "ОпроситьОбновленияToolStripMenuItem"
        Me.ОпроситьОбновленияToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.ОпроситьОбновленияToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ОпроситьОбновленияToolStripMenuItem.Text = "Опросить Обновления"
        Me.ОпроситьОбновленияToolStripMenuItem.Visible = False
        '
        'ОПрограммеToolStripMenuItem
        '
        Me.ОПрограммеToolStripMenuItem.Name = "ОПрограммеToolStripMenuItem"
        Me.ОПрограммеToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.ОПрограммеToolStripMenuItem.Text = "&О программе"
        '
        'ni
        '
        Me.ni.ContextMenuStrip = Me.cmenuNI
        Me.ni.Icon = CType(resources.GetObject("ni.Icon"), System.Drawing.Icon)
        Me.ni.Text = "SNMP APC Monitor"
        Me.ni.Visible = True
        '
        'cmenuNI
        '
        Me.cmenuNI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОпроситьToolStripMenuItem, Me.РазвернутьToolStripMenuItem, Me.GetNextOIDToolStripMenuItem, Me.ToolStripMenuItem3, Me.НастройкиToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ВыходToolStripMenuItem1})
        Me.cmenuNI.Name = "cmenuNI"
        Me.cmenuNI.Size = New System.Drawing.Size(140, 126)
        '
        'ОпроситьToolStripMenuItem
        '
        Me.ОпроситьToolStripMenuItem.Name = "ОпроситьToolStripMenuItem"
        Me.ОпроситьToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ОпроситьToolStripMenuItem.Text = "Опросить"
        '
        'РазвернутьToolStripMenuItem
        '
        Me.РазвернутьToolStripMenuItem.Name = "РазвернутьToolStripMenuItem"
        Me.РазвернутьToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.РазвернутьToolStripMenuItem.Text = "Развернуть"
        '
        'GetNextOIDToolStripMenuItem
        '
        Me.GetNextOIDToolStripMenuItem.Name = "GetNextOIDToolStripMenuItem"
        Me.GetNextOIDToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.GetNextOIDToolStripMenuItem.Text = "GetNext OID"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(136, 6)
        '
        'НастройкиToolStripMenuItem1
        '
        Me.НастройкиToolStripMenuItem1.Name = "НастройкиToolStripMenuItem1"
        Me.НастройкиToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.НастройкиToolStripMenuItem1.Text = "Настройки"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(136, 6)
        '
        'ВыходToolStripMenuItem1
        '
        Me.ВыходToolStripMenuItem1.Name = "ВыходToolStripMenuItem1"
        Me.ВыходToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.ВыходToolStripMenuItem1.Text = "Выход"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1212, 500)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Источники бесперебойного питания"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox3, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1198, 468)
        Me.TableLayoutPanel4.TabIndex = 46
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 190)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1192, 275)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Графики"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.zg2, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ComboBox2, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.RadioButton1, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.RadioButton2, 2, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1186, 256)
        Me.TableLayoutPanel5.TabIndex = 54
        '
        'zg2
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.zg2, 3)
        Me.zg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg2.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zg2.IsAntiAlias = True
        Me.zg2.Location = New System.Drawing.Point(3, 30)
        Me.zg2.Name = "zg2"
        Me.zg2.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zg2.ScrollGrace = 0R
        Me.zg2.ScrollMaxX = 0R
        Me.zg2.ScrollMaxY = 0R
        Me.zg2.ScrollMaxY2 = 0R
        Me.zg2.ScrollMinX = 0R
        Me.zg2.ScrollMinY = 0R
        Me.zg2.ScrollMinY2 = 0R
        Me.zg2.Size = New System.Drawing.Size(1180, 223)
        Me.zg2.TabIndex = 56
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Состояние батарей", "Замена батарей", "Входное напряжение", "Выходное напряжение", "Исходящая частота", "Нагрузка", "Температура", "Вольтаж батареи"})
        Me.ComboBox2.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox2.TabIndex = 53
        Me.ComboBox2.Text = "Температура"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(159, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton1.TabIndex = 54
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Сутки"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(219, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton2.TabIndex = 55
        Me.RadioButton2.Text = "Все"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstUPS)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1192, 181)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Данные ИБП"
        '
        'lstUPS
        '
        Me.lstUPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUPS.FullRowSelect = True
        Me.lstUPS.GridLines = True
        Me.lstUPS.Location = New System.Drawing.Point(3, 16)
        Me.lstUPS.Name = "lstUPS"
        Me.lstUPS.Size = New System.Drawing.Size(1186, 162)
        Me.lstUPS.TabIndex = 43
        Me.lstUPS.UseCompatibleStateImageBehavior = False
        Me.lstUPS.View = System.Windows.Forms.View.Details
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstComm)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Коммутаторы"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstComm
        '
        Me.lstComm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstComm.FullRowSelect = True
        Me.lstComm.GridLines = True
        Me.lstComm.Location = New System.Drawing.Point(3, 3)
        Me.lstComm.Name = "lstComm"
        Me.lstComm.Size = New System.Drawing.Size(1198, 468)
        Me.lstComm.TabIndex = 43
        Me.lstComm.UseCompatibleStateImageBehavior = False
        Me.lstComm.View = System.Windows.Forms.View.Details
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Принтеры"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.lvPrinter, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.zgPrn, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1204, 474)
        Me.TableLayoutPanel8.TabIndex = 45
        '
        'lvPrinter
        '
        Me.lvPrinter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvPrinter.FullRowSelect = True
        Me.lvPrinter.GridLines = True
        Me.lvPrinter.Location = New System.Drawing.Point(3, 3)
        Me.lvPrinter.Name = "lvPrinter"
        Me.lvPrinter.Size = New System.Drawing.Size(1198, 252)
        Me.lvPrinter.TabIndex = 44
        Me.lvPrinter.UseCompatibleStateImageBehavior = False
        Me.lvPrinter.View = System.Windows.Forms.View.Details
        '
        'zgPrn
        '
        Me.zgPrn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgPrn.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zgPrn.IsAntiAlias = True
        Me.zgPrn.IsAutoScrollRange = True
        Me.zgPrn.Location = New System.Drawing.Point(3, 261)
        Me.zgPrn.Name = "zgPrn"
        Me.zgPrn.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zgPrn.ScrollGrace = 0R
        Me.zgPrn.ScrollMaxX = 0R
        Me.zgPrn.ScrollMaxY = 0R
        Me.zgPrn.ScrollMaxY2 = 0R
        Me.zgPrn.ScrollMinX = 0R
        Me.zgPrn.ScrollMinY = 0R
        Me.zgPrn.ScrollMinY2 = 0R
        Me.zgPrn.Size = New System.Drawing.Size(1198, 210)
        Me.zgPrn.TabIndex = 59
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.TableLayoutPanel9)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Аппаратные"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Controls.Add(Me.zgApparat, 0, 1)
        Me.TableLayoutPanel9.Controls.Add(Me.lbApparat, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.lvApparat, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.TableLayoutPanel10, 0, 1)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 4
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.3242!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.6758!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(1198, 468)
        Me.TableLayoutPanel9.TabIndex = 53
        '
        'zgApparat
        '
        Me.TableLayoutPanel9.SetColumnSpan(Me.zgApparat, 4)
        Me.zgApparat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zgApparat.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zgApparat.IsAntiAlias = True
        Me.zgApparat.IsAutoScrollRange = True
        Me.zgApparat.Location = New System.Drawing.Point(3, 209)
        Me.zgApparat.Name = "zgApparat"
        Me.zgApparat.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.TableLayoutPanel9.SetRowSpan(Me.zgApparat, 2)
        Me.zgApparat.ScrollGrace = 0R
        Me.zgApparat.ScrollMaxX = 0R
        Me.zgApparat.ScrollMaxY = 0R
        Me.zgApparat.ScrollMaxY2 = 0R
        Me.zgApparat.ScrollMinX = 0R
        Me.zgApparat.ScrollMinY = 0R
        Me.zgApparat.ScrollMinY2 = 0R
        Me.zgApparat.Size = New System.Drawing.Size(1198, 256)
        Me.zgApparat.TabIndex = 58
        '
        'lbApparat
        '
        Me.lbApparat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbApparat.FormattingEnabled = True
        Me.lbApparat.Location = New System.Drawing.Point(3, 3)
        Me.lbApparat.Name = "lbApparat"
        Me.lbApparat.Size = New System.Drawing.Size(244, 164)
        Me.lbApparat.TabIndex = 46
        '
        'lvApparat
        '
        Me.TableLayoutPanel9.SetColumnSpan(Me.lvApparat, 2)
        Me.lvApparat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvApparat.FullRowSelect = True
        Me.lvApparat.GridLines = True
        Me.lvApparat.Location = New System.Drawing.Point(253, 3)
        Me.lvApparat.Name = "lvApparat"
        Me.lvApparat.Size = New System.Drawing.Size(948, 164)
        Me.lvApparat.TabIndex = 44
        Me.lvApparat.UseCompatibleStateImageBehavior = False
        Me.lvApparat.View = System.Windows.Forms.View.Details
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 7
        Me.TableLayoutPanel9.SetColumnSpan(Me.TableLayoutPanel10, 2)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 570.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.RadioButton7, 5, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RadioButton8, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RadioButton9, 3, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RadioButton10, 4, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.btnStopArduino, 6, 0)
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(3, 173)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(893, 30)
        Me.TableLayoutPanel10.TabIndex = 48
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Checked = True
        Me.RadioButton7.Location = New System.Drawing.Point(262, 3)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(69, 17)
        Me.RadioButton7.TabIndex = 55
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "За сутки"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(89, 17)
        Me.RadioButton8.TabIndex = 53
        Me.RadioButton8.Text = "Весь период"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(98, 3)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton9.TabIndex = 54
        Me.RadioButton9.Text = "За месяц"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Location = New System.Drawing.Point(177, 3)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton10.TabIndex = 56
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "За неделю"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'btnStopArduino
        '
        Me.btnStopArduino.Location = New System.Drawing.Point(337, 3)
        Me.btnStopArduino.Name = "btnStopArduino"
        Me.btnStopArduino.Size = New System.Drawing.Size(75, 23)
        Me.btnStopArduino.TabIndex = 59
        Me.btnStopArduino.Text = "Стоп"
        Me.btnStopArduino.UseVisualStyleBackColor = True
        Me.btnStopArduino.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Пинг"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.48859!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.51142!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lvPing, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstPing_X, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.96624!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.03375!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1204, 474)
        Me.TableLayoutPanel1.TabIndex = 46
        '
        'lvPing
        '
        Me.lvPing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvPing.FullRowSelect = True
        Me.lvPing.GridLines = True
        Me.lvPing.Location = New System.Drawing.Point(3, 3)
        Me.lvPing.Name = "lvPing"
        Me.lvPing.Size = New System.Drawing.Size(913, 154)
        Me.lvPing.TabIndex = 44
        Me.lvPing.UseCompatibleStateImageBehavior = False
        Me.lvPing.View = System.Windows.Forms.View.Details
        '
        'lstPing_X
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstPing_X, 2)
        Me.lstPing_X.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPing_X.FormattingEnabled = True
        Me.lstPing_X.Location = New System.Drawing.Point(922, 3)
        Me.lstPing_X.Name = "lstPing_X"
        Me.lstPing_X.Size = New System.Drawing.Size(279, 154)
        Me.lstPing_X.TabIndex = 46
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1044, 308)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Статистика"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.880666!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.11933!))
        Me.TableLayoutPanel6.Controls.Add(Me.RadioButton3, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.zg1, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.RadioButton4, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1038, 289)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton3.TabIndex = 56
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Сутки"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'zg1
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.zg1, 2)
        Me.zg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zg1.IsAntiAlias = True
        Me.zg1.Location = New System.Drawing.Point(3, 26)
        Me.zg1.Name = "zg1"
        Me.zg1.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zg1.ScrollGrace = 0R
        Me.zg1.ScrollMaxX = 0R
        Me.zg1.ScrollMaxY = 0R
        Me.zg1.ScrollMaxY2 = 0R
        Me.zg1.ScrollMinX = 0R
        Me.zg1.ScrollMinY = 0R
        Me.zg1.ScrollMinY2 = 0R
        Me.zg1.Size = New System.Drawing.Size(1032, 260)
        Me.zg1.TabIndex = 1
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(95, 3)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton4.TabIndex = 57
        Me.RadioButton4.Text = "Все"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1053, 452)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 19)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "Ping"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Объем жестких дисков"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.zg3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lstSRV, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lvHDD, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.3242!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.6758!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1204, 474)
        Me.TableLayoutPanel2.TabIndex = 52
        '
        'zg3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.zg3, 4)
        Me.zg3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zg3.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zg3.IsAntiAlias = True
        Me.zg3.IsAutoScrollRange = True
        Me.zg3.Location = New System.Drawing.Point(3, 211)
        Me.zg3.Name = "zg3"
        Me.zg3.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.TableLayoutPanel2.SetRowSpan(Me.zg3, 2)
        Me.zg3.ScrollGrace = 0R
        Me.zg3.ScrollMaxX = 0R
        Me.zg3.ScrollMaxY = 0R
        Me.zg3.ScrollMaxY2 = 0R
        Me.zg3.ScrollMinX = 0R
        Me.zg3.ScrollMinY = 0R
        Me.zg3.ScrollMinY2 = 0R
        Me.zg3.Size = New System.Drawing.Size(1198, 260)
        Me.zg3.TabIndex = 58
        '
        'lstSRV
        '
        Me.lstSRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSRV.FormattingEnabled = True
        Me.lstSRV.Location = New System.Drawing.Point(3, 3)
        Me.lstSRV.Name = "lstSRV"
        Me.lstSRV.Size = New System.Drawing.Size(244, 166)
        Me.lstSRV.TabIndex = 46
        '
        'lvHDD
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.lvHDD, 2)
        Me.lvHDD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvHDD.FullRowSelect = True
        Me.lvHDD.GridLines = True
        Me.lvHDD.Location = New System.Drawing.Point(253, 3)
        Me.lvHDD.Name = "lvHDD"
        Me.lvHDD.Size = New System.Drawing.Size(948, 166)
        Me.lvHDD.TabIndex = 44
        Me.lvHDD.UseCompatibleStateImageBehavior = False
        Me.lvHDD.View = System.Windows.Forms.View.Details
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 323.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RadioButton5, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBox2, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBox3, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RadioButton6, 4, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 175)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(893, 30)
        Me.TableLayoutPanel3.TabIndex = 48
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Кривая", "Гистограмма"})
        Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(241, 21)
        Me.ComboBox1.TabIndex = 49
        Me.ComboBox1.Text = "Гистограмма"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(488, 3)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton5.TabIndex = 55
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "За неделю"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(250, 3)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox2.TabIndex = 53
        Me.CheckBox2.Text = "Весь период"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(345, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(58, 17)
        Me.CheckBox3.TabIndex = 54
        Me.CheckBox3.Text = "За год"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(409, 3)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton6.TabIndex = 56
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "За месяц"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.lvAnti)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Антивирус"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'lvAnti
        '
        Me.lvAnti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAnti.FullRowSelect = True
        Me.lvAnti.GridLines = True
        Me.lvAnti.Location = New System.Drawing.Point(0, 0)
        Me.lvAnti.Name = "lvAnti"
        Me.lvAnti.Size = New System.Drawing.Size(1204, 474)
        Me.lvAnti.TabIndex = 44
        Me.lvAnti.UseCompatibleStateImageBehavior = False
        Me.lvAnti.View = System.Windows.Forms.View.Details
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.TableLayoutPanel7)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(1204, 474)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Системные обновления"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.lvSystem, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1198, 468)
        Me.TableLayoutPanel7.TabIndex = 46
        '
        'lvSystem
        '
        Me.lvSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSystem.FullRowSelect = True
        Me.lvSystem.GridLines = True
        Me.lvSystem.Location = New System.Drawing.Point(3, 3)
        Me.lvSystem.Name = "lvSystem"
        Me.lvSystem.Size = New System.Drawing.Size(1192, 432)
        Me.lvSystem.TabIndex = 45
        Me.lvSystem.UseCompatibleStateImageBehavior = False
        Me.lvSystem.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 446)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1192, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Опрашивается ----"
        '
        'cmenuLST
        '
        Me.cmenuLST.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОткрытьВБраузереToolStripMenuItem, Me.ОткрытьВPuttyToolStripMenuItem, Me.ОткрытьRDPToolStripMenuItem, Me.КачествоПингToolStripMenuItem, Me.ibpRemoteControl, Me.RealtimeIBP, Me.СканерПортовToolStripMenuItem})
        Me.cmenuLST.Name = "cmenuLST"
        Me.cmenuLST.Size = New System.Drawing.Size(263, 158)
        '
        'ОткрытьВБраузереToolStripMenuItem
        '
        Me.ОткрытьВБраузереToolStripMenuItem.Name = "ОткрытьВБраузереToolStripMenuItem"
        Me.ОткрытьВБраузереToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ОткрытьВБраузереToolStripMenuItem.Text = "Открыть в браузере"
        '
        'ОткрытьВPuttyToolStripMenuItem
        '
        Me.ОткрытьВPuttyToolStripMenuItem.Name = "ОткрытьВPuttyToolStripMenuItem"
        Me.ОткрытьВPuttyToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ОткрытьВPuttyToolStripMenuItem.Text = "Открыть в Putty"
        '
        'ОткрытьRDPToolStripMenuItem
        '
        Me.ОткрытьRDPToolStripMenuItem.Name = "ОткрытьRDPToolStripMenuItem"
        Me.ОткрытьRDPToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ОткрытьRDPToolStripMenuItem.Text = "Открыть RDP"
        '
        'КачествоПингToolStripMenuItem
        '
        Me.КачествоПингToolStripMenuItem.Name = "КачествоПингToolStripMenuItem"
        Me.КачествоПингToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.КачествоПингToolStripMenuItem.Text = "Качество Пинг"
        '
        'ibpRemoteControl
        '
        Me.ibpRemoteControl.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ibpOff, Me.ibpOn, Me.ibpTest, Me.calibrationIBP})
        Me.ibpRemoteControl.Name = "ibpRemoteControl"
        Me.ibpRemoteControl.Size = New System.Drawing.Size(262, 22)
        Me.ibpRemoteControl.Text = "Управление ИБП"
        '
        'ibpOff
        '
        Me.ibpOff.Image = CType(resources.GetObject("ibpOff.Image"), System.Drawing.Image)
        Me.ibpOff.Name = "ibpOff"
        Me.ibpOff.Size = New System.Drawing.Size(179, 22)
        Me.ibpOff.Text = "Отключить ИБП"
        '
        'ibpOn
        '
        Me.ibpOn.Image = CType(resources.GetObject("ibpOn.Image"), System.Drawing.Image)
        Me.ibpOn.Name = "ibpOn"
        Me.ibpOn.Size = New System.Drawing.Size(179, 22)
        Me.ibpOn.Text = "Включить ИБП"
        '
        'ibpTest
        '
        Me.ibpTest.Image = CType(resources.GetObject("ibpTest.Image"), System.Drawing.Image)
        Me.ibpTest.Name = "ibpTest"
        Me.ibpTest.Size = New System.Drawing.Size(179, 22)
        Me.ibpTest.Text = "Тестирование ИБП"
        '
        'calibrationIBP
        '
        Me.calibrationIBP.Image = CType(resources.GetObject("calibrationIBP.Image"), System.Drawing.Image)
        Me.calibrationIBP.Name = "calibrationIBP"
        Me.calibrationIBP.Size = New System.Drawing.Size(179, 22)
        Me.calibrationIBP.Text = "Калибровка ИБП"
        '
        'RealtimeIBP
        '
        Me.RealtimeIBP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ВходноеНапряжениеToolStripMenuItem, Me.ВыходноеНапряжениеToolStripMenuItem, Me.НагрузкаToolStripMenuItem, Me.ЗарядБатареиToolStripMenuItem, Me.ТемператураToolStripMenuItem, Me.ВольтажБатареиToolStripMenuItem, Me.ПингToolStripMenuItem, Me.TracerouteToolStripMenuItem})
        Me.RealtimeIBP.Name = "RealtimeIBP"
        Me.RealtimeIBP.Size = New System.Drawing.Size(262, 22)
        Me.RealtimeIBP.Text = "Графики реального времени ИБП"
        '
        'ВходноеНапряжениеToolStripMenuItem
        '
        Me.ВходноеНапряжениеToolStripMenuItem.Name = "ВходноеНапряжениеToolStripMenuItem"
        Me.ВходноеНапряжениеToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ВходноеНапряжениеToolStripMenuItem.Text = "Входное напряжение"
        '
        'ВыходноеНапряжениеToolStripMenuItem
        '
        Me.ВыходноеНапряжениеToolStripMenuItem.Name = "ВыходноеНапряжениеToolStripMenuItem"
        Me.ВыходноеНапряжениеToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ВыходноеНапряжениеToolStripMenuItem.Text = "Выходное напряжение"
        '
        'НагрузкаToolStripMenuItem
        '
        Me.НагрузкаToolStripMenuItem.Name = "НагрузкаToolStripMenuItem"
        Me.НагрузкаToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.НагрузкаToolStripMenuItem.Text = "Нагрузка"
        '
        'ЗарядБатареиToolStripMenuItem
        '
        Me.ЗарядБатареиToolStripMenuItem.Name = "ЗарядБатареиToolStripMenuItem"
        Me.ЗарядБатареиToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ЗарядБатареиToolStripMenuItem.Text = "Заряд батареи"
        '
        'ТемператураToolStripMenuItem
        '
        Me.ТемператураToolStripMenuItem.Name = "ТемператураToolStripMenuItem"
        Me.ТемператураToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ТемператураToolStripMenuItem.Text = "Температура"
        '
        'ВольтажБатареиToolStripMenuItem
        '
        Me.ВольтажБатареиToolStripMenuItem.Name = "ВольтажБатареиToolStripMenuItem"
        Me.ВольтажБатареиToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ВольтажБатареиToolStripMenuItem.Text = "Вольтаж батареи"
        '
        'ПингToolStripMenuItem
        '
        Me.ПингToolStripMenuItem.Name = "ПингToolStripMenuItem"
        Me.ПингToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ПингToolStripMenuItem.Text = "Пинг"
        '
        'TracerouteToolStripMenuItem
        '
        Me.TracerouteToolStripMenuItem.Name = "TracerouteToolStripMenuItem"
        Me.TracerouteToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.TracerouteToolStripMenuItem.Text = "Traceroute"
        Me.TracerouteToolStripMenuItem.Visible = False
        '
        'СканерПортовToolStripMenuItem
        '
        Me.СканерПортовToolStripMenuItem.Name = "СканерПортовToolStripMenuItem"
        Me.СканерПортовToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.СканерПортовToolStripMenuItem.Text = "Сканер портов"
        '
        'MnuWMI
        '
        Me.MnuWMI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОпроситьСерверToolStripMenuItem, Me.EventLogToolStripMenuItem, Me.НаличиеАнтивирусаToolStripMenuItem})
        Me.MnuWMI.Name = "ContextMenuStrip1"
        Me.MnuWMI.Size = New System.Drawing.Size(190, 70)
        '
        'ОпроситьСерверToolStripMenuItem
        '
        Me.ОпроситьСерверToolStripMenuItem.Name = "ОпроситьСерверToolStripMenuItem"
        Me.ОпроситьСерверToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ОпроситьСерверToolStripMenuItem.Text = "Опросить сервер"
        '
        'EventLogToolStripMenuItem
        '
        Me.EventLogToolStripMenuItem.Name = "EventLogToolStripMenuItem"
        Me.EventLogToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.EventLogToolStripMenuItem.Text = "EventLog"
        '
        'НаличиеАнтивирусаToolStripMenuItem
        '
        Me.НаличиеАнтивирусаToolStripMenuItem.Name = "НаличиеАнтивирусаToolStripMenuItem"
        Me.НаличиеАнтивирусаToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.НаличиеАнтивирусаToolStripMenuItem.Text = "Наличие антивируса"
        Me.НаличиеАнтивирусаToolStripMenuItem.Visible = False
        '
        'il70
        '
        Me.il70.ImageStream = CType(resources.GetObject("il70.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.il70.TransparentColor = System.Drawing.Color.Transparent
        Me.il70.Images.SetKeyName(0, "B8.png")
        Me.il70.Images.SetKeyName(1, "servnz.png")
        Me.il70.Images.SetKeyName(2, "ok.png")
        '
        'frmRequestOID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1212, 546)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ss1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmRequestOID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SNMP Monitor"
        Me.ss1.ResumeLayout(False)
        Me.ss1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.cmenuNI.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.cmenuLST.ResumeLayout(False)
        Me.MnuWMI.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ss1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents МенюToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ОпроситьУстройстваToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ВыходToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ni As System.Windows.Forms.NotifyIcon
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lstUPS As System.Windows.Forms.ListView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lstComm As System.Windows.Forms.ListView
    Friend WithEvents cmenuNI As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ОпроситьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents РазвернутьToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents НастройкиToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ВыходToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenuLST As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ОткрытьВБраузереToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lvPrinter As System.Windows.Forms.ListView
    Friend WithEvents GetNextOIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ОткрытьВPuttyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToExcellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ИБПToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents КоммутаторыToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПринтерыToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents lvHDD As System.Windows.Forms.ListView
    Friend WithEvents lstSRV As System.Windows.Forms.ListBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ОткрытьRDPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОПрограммеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ОпроситьHDDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents КачествоПингToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvPing As System.Windows.Forms.ListView
    Friend WithEvents lstPing_X As System.Windows.Forms.ListBox
    Friend WithEvents ibpRemoteControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ibpOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ibpOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ibpTest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents calibrationIBP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents enableIBP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEnableIbp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RealtimeIBP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВходноеНапряжениеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВыходноеНапряжениеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НагрузкаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ЗарядБатареиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ТемператураToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВольтажБатареиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents zg1 As ZedGraph.ZedGraphControl
    Friend WithEvents zg2 As ZedGraph.ZedGraphControl
    Friend WithEvents ПингToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TracerouteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents zg3 As ZedGraph.ZedGraphControl
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents СжатьБазуToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuWMI As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ОпроситьСерверToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents НаличиеАнтивирусаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents lvAnti As System.Windows.Forms.ListView
    Friend WithEvents il70 As System.Windows.Forms.ImageList
    Friend WithEvents TrapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents lvSystem As System.Windows.Forms.ListView
    Friend WithEvents ОпроситьАнтивирусToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОпроситьОбновленияToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents СканерПортовToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents СъемныеДискиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBox2 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents zgPrn As ZedGraph.ZedGraphControl
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents zgApparat As ZedGraph.ZedGraphControl
    Friend WithEvents lbApparat As System.Windows.Forms.ListBox
    Friend WithEvents lvApparat As System.Windows.Forms.ListView
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents btnStopArduino As System.Windows.Forms.Button
End Class
