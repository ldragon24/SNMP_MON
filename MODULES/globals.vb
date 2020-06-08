Module globals
    Public Function getEventLogStructure() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Category"))
        dt.Columns.Add(New DataColumn("ComputerName"))
        dt.Columns.Add(New DataColumn("EventCode"))
        dt.Columns.Add(New DataColumn("Message"))
        dt.Columns.Add(New DataColumn("TimeWritten"))
        dt.Columns.Add(New DataColumn("Type"))

        Return dt
    End Function

    Public Sub addEventLog(ByRef dt As DataTable, ByVal Category As String, ByVal ComputerName As String, ByVal EventCode As String, ByVal Message As String, ByVal TimeWritten As String, ByVal Type As String)
        Dim dr As DataRow
        dr = dt.NewRow
        dr("Category") = Category
        dr("ComputerName") = ComputerName
        dr("EventCode") = EventCode
        dr("Message") = Message
        dr("TimeWritten") = TimeWritten
        dr("Type") = Type
        dt.Rows.Add(dr)
    End Sub

    Public Sub addRow(ByRef dt As DataTable, ByVal p As String, ByVal v As String)
        Dim dr As DataRow
        dr = dt.NewRow
        dr("Property") = p
        dr("Value") = v
        dt.Rows.Add(dr)
    End Sub
    Public Function getStructure() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Property"))
        dt.Columns.Add(New DataColumn("Value"))
        Return dt
    End Function

End Module