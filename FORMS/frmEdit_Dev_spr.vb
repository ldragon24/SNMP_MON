Public Class frmEdit_Dev_spr
    Private m_SortingColumn As ColumnHeader

    Private Sub frmEdit_Dev_spr_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        lstDevice.Columns.Add("id", 1, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Тип устройства", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Производитель устройства", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Модель", 140, HorizontalAlignment.Left)

        Call LOAD_DEV_LST()

    End Sub

    Public Sub LOAD_DEV_LST()

        lstDevice.Items.Clear()
        lstDevice.ListViewItemSorter = Nothing
        lstDevice.Sorting = SortOrder.None

        Dim intj As Integer = 0
        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV_oid"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        If sCOUNT = 0 Then

        Else

            rs = New Recordset
            rs.Open("SELECT * FROM TBL_DEV_oid", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

            With rs
                .MoveFirst()
                Do While Not .EOF

                    lstDevice.Items.Add(.Fields("id").Value) 'col no. 1
                    lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("Device").Value)
                    lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("Developer").Value)
                    lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("MODEL").Value)
                    intj = intj + 1
                    .MoveNext()
                Loop
            End With
            rs.Close()
            rs = Nothing

            '([TipDev],[DevelopDev],[IPDev],[CommunityDev]

        End If
    End Sub

    Private Sub lstDevice_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstDevice.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
         lstDevice.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lstDevice.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lstDevice.Sort()
    End Sub

    Private Sub lstDevice_DoubleClick(sender As Object, e As System.EventArgs) Handles lstDevice.DoubleClick
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
        Next

        frmDev.cID = rCOUNT
        frmDev.cEDT = True

        frmDev.ShowDialog(Me)
    End Sub

    Private Sub lstDevice_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstDevice.MouseUp
        If lstDevice.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmenu.Show(CType(sender, Control), e.Location)

        Else

        End If
    End Sub

    Private Sub lstDevice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstDevice.SelectedIndexChanged

    End Sub

    Private Sub УдалитьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles УдалитьToolStripMenuItem.Click
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
        Next

        If MsgBox("Будет удалена запись" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            DB7.Execute("Delete FROM TBL_DEV_OID WHERE id=" & rCOUNT)

        Else

        End If

        Call LOAD_DEV_LST()
    End Sub

    Private Sub РедактироватьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles РедактироватьToolStripMenuItem.Click
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
        Next

        frmDev.cID = rCOUNT
        frmDev.cEDT = True
        frmDev.ShowDialog(Me)


        'Call LOAD_DEV_LST()
    End Sub
End Class