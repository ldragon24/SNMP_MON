Public Class frm_printer


    Private Sub frm_printer_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        lvev.Columns.Clear()
        lvev.Columns.Add("id", 30, HorizontalAlignment.Left)
        lvev.Columns.Add("Сенсор", 240, HorizontalAlignment.Left)
        lvev.Columns.Add("Состояние", 240, HorizontalAlignment.Left)

    End Sub



    Public Sub load_sensors(ByVal ip As String, ByVal model As String)

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM models where FeatureValue='" & model & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        Me.Text = "НАйдено: " & sCOUNT

        Select Case sCOUNT

            Case 0



            Case Else

                Dim sModel As String
                Dim sProfile As Integer

                sSQL = "SELECT name,ProfileID  FROM models where FeatureValue='" & model & "'"

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    sModel = .Fields("name").Value
                    sProfile = .Fields("ProfileID").Value

                    Me.Text = "НАйдено: " & sCOUNT & " " & sProfile


                End With
                rs.Close()
                rs = Nothing

                Me.Text = "НАйдено: " & sCOUNT & " " & sProfile




        End Select




    End Sub










End Class