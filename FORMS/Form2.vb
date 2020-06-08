'Public Class Form2

'    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

'    End Sub

'    Private Sub Display_Hours_Graph()
'        Me.Tbl_HoursTableAdapter.Fill(Me.PilotLogbookDataSet.tbl_Hours)

'        Dim myPane As GraphPane = zgcHours.GraphPane

'        zgcHours.IsEnableZoom = False

'        myPane.CurveList.Clear()

'        myPane.Title.Text = Application.ProductName & " - Hours / Year"
'        myPane.XAxis.Title.Text = "Year"
'        myPane.YAxis.Title.Text = "Hours"

'        Dim list As New PointPairList()

'        Dim intRowCount As Int32 = Me.PilotLogbookDataSet.tbl_Hours.Rows.Count - 1
'        Dim intColCount As Int32 = Me.PilotLogbookDataSet.tbl_Hours.Columns.Count - 1
'        Dim intRowIdx As Int32 = 0
'        Dim intColIdx As Int32 = 0
'        Dim dblRowTotal As Double = 0
'        Dim strYearListHours As New List(Of String)

'        ' Iterate past all DISTINCT Years, and Sum all the returned individual agregate (Sum) values
'        For intRowIdx = 0 To intRowCount

'            For intColIdx = 1 To intColCount
'                If Me.PilotLogbookDataSet.tbl_Hours.Rows(intRowIdx).Item(intColIdx).ToString <> Nothing Then
'                    dblRowTotal = dblRowTotal + CType(FormatNumber(Me.PilotLogbookDataSet.tbl_Hours.Rows(intRowIdx).Item(intColIdx).ToString, 1), Double)
'                End If
'            Next
'            ' Capture the X value (Years) and Y value, noting that the X values won't be used as Lables will be
'            list.Add(CType(Me.PilotLogbookDataSet.tbl_Hours.Rows(intRowIdx).Item(0).ToString, Double), dblRowTotal)
'            ' Capture the Year values to be used as the 'XAxis.Scale.TextLabels'
'            strYearListHours.Add(Me.PilotLogbookDataSet.tbl_Hours.Rows(intRowIdx).Item(0).ToString)
'            dblRowTotal = 0
'        Next

'        Dim myCurve As BarItem = myPane.AddBar("Hours", list, Nothing)
'        myCurve.Bar.Fill = New Fill(Color.Blue)
'        myCurve.Bar.Fill.Type = FillType.GradientByX

'        myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45)
'        myPane.Fill = New Fill(Color.White, Color.FromArgb(255, 255, 225), 45)

'        Dim strLabels(list.Count - 1) As String
'        For intIdx As Integer = 0 To list.Count - 1
'            strLabels(intIdx) = strYearListHours.Item(intIdx)
'        Next

'        myPane.XAxis.Scale.TextLabels = strLabels
'        myPane.XAxis.Type = AxisType.Text

'        ' Tell ZedGraph to calculate the axis ranges
'        zgcHours.AxisChange()

'        Hide_Display_Panels()
'        PanelGraphHours.Show()

'    End Sub

'End Class