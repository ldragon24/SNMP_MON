Imports System.Management


Public Class frm_removable_device

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        On Error GoTo err_

        TextBox1.Text = ""


        '#####################################################################################
        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_DiskDrive where interfacetype='USB'")
        ' Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_USBDevice where Service = 'disk' or Service = 'WUDFRd")


        'SELECT * FROM Win32_USBDevice where Service = 'disk' or Service = 'WUDFRd

        For Each queryObj As ManagementObject In searcher.Get()

            If Len(TextBox1.Text) = 0 Then

                TextBox1.Text = "PID: " & queryObj("PNPDeviceID") & vbCrLf & "Модель накопителя: " & queryObj("Model") & vbCrLf & "Серийный номер: " & queryObj("SerialNumber") & vbCrLf & vbCrLf & "############################" & vbCrLf

            Else

                TextBox1.Text = TextBox1.Text & vbCrLf & "PID: " & queryObj("PNPDeviceID") & vbCrLf & "Модель накопителя: " & queryObj("Model") & vbCrLf & "Серийный номер: " & queryObj("SerialNumber") & vbCrLf & vbCrLf & "############################" & vbCrLf


            End If

        Next

        Dim searcher2 As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_USBDevice where Service = 'WUDFRd'")

        For Each queryObj As ManagementObject In searcher2.Get()

            If Len(TextBox1.Text) = 0 Then

                TextBox1.Text = "PID: " & queryObj("PNPDeviceID") & vbCrLf & "Модель накопителя: " & queryObj("Name") & vbCrLf & "############################" & vbCrLf

            Else

                TextBox1.Text = TextBox1.Text & vbCrLf & "PID: " & queryObj("PNPDeviceID") & vbCrLf & "Модель накопителя: " & queryObj("Name") & vbCrLf & "############################" & vbCrLf


            End If

        Next



err_:
    End Sub



End Class