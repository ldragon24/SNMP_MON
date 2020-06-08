Imports System.IO


Public Class frmTraps

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim ary(0) As String


        'WindowsUpdate
        'C:\Windows\SoftwareDistribution\ReportingEvents.log
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\Windows\WindowsUpdate.log")

        textfilereader.TextFieldType = FileIO.FieldType.Delimited
        textfilereader.SetDelimiters(vbTab)

        Dim TextFileTable As DataTable = Nothing
        Dim Column As DataColumn
        Dim Row As DataRow
        Dim UpperBound As Int32
        Dim ColumnCount As Int32
        Dim currentRow As String()
        While Not TextFileReader.EndOfData

            Try

                currentRow = TextFileReader.ReadFields()
                If Not currentRow Is Nothing Then

                    If TextFileTable Is Nothing Then

                        TextFileTable = New DataTable("TextFileTable")
                        UpperBound = currentRow.GetUpperBound(0)

                        For ColumnCount = 0 To UpperBound
                            Column = New DataColumn()
                            Column.DataType = System.Type.GetType("System.String")
                            Column.ColumnName = "Column" & ColumnCount
                            Column.Caption = "Column" & ColumnCount
                            Column.ReadOnly = True
                            Column.Unique = False
                            TextFileTable.Columns.Add(Column)

                        Next

                    End If

                    Row = TextFileTable.NewRow
                    For col = 0 To UpperBound

                        Row("Column" & col) = currentRow(col).ToString

                    Next
                    TextFileTable.Rows.Add(Row)

                End If

            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & "is not valid and will be skiped.")

            End Try



        End While

        TextFileReader.Dispose()
        DataGrid1.DataSource = TextFileTable







    End Sub
End Class