Public Class frmDev
    Public cID As Integer
    Public cEDT As Boolean = False

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'APC
        'EATON
        'CISCO

        ComboBox2.Items.Clear()
        ComboBox2.Text = ""

        Label20.Text = "Температура"
        Label13.Text = "В работе (UpTime)"
        Label4.Text = "Место нахождение"
        Label18.Text = "Статус (Сеть\Батарея)"


        Select Case ComboBox1.Text

            Case "Источник бесперебойного питания"

                ComboBox2.Items.Add("APC")
                ComboBox2.Items.Add("EATON")

                Label6.Visible = True
                Label8.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                Label11.Visible = True
                Label12.Visible = True
                Label15.Visible = True
                Label16.Visible = True
                Label17.Visible = True
                Label18.Visible = True
                Label19.Visible = True
                Label21.Visible = True
                Label22.Visible = True
                Label23.Visible = True
                Label24.Visible = True

                txtContact.Visible = True
                txtSerNum.Visible = True
                txtTimeBattery.Visible = True
                txtCharge.Visible = True
                txtBattaryStatus.Visible = True
                txtBattaryZ.Visible = True
                txtInU.Visible = True
                txtOutU.Visible = True
                txtMhzI.Visible = True
                txtStatus.Visible = True
                txtSelfTest.Visible = True
                txtThemperatureOut.Visible = True
                txtNagr.Visible = True
                txtDateSelfTest.Visible = True
                txtVbattery.Visible = True

                txtotclIBP.Visible = True
                txtVklIBP.Visible = True
                txtSelfTestIBP.Visible = True
                txtKalibrIBP.Visible = True
                Label25.Visible = True
                Label26.Visible = True
                Label27.Visible = True
                Label28.Visible = True

                txtFlash.Visible = False
                lblFlash.Visible = False

            Case "Коммутаторы"

                Label20.Text = "Температура"
                Label13.Text = "В работе (UpTime)"

                ComboBox2.Items.Add("CISCO")

                Label6.Visible = True
                Label8.Visible = True
                Label9.Visible = False
                Label10.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label17.Visible = False
                Label18.Visible = False
                Label19.Visible = False
                Label21.Visible = False
                Label22.Visible = False
                Label23.Visible = False
                Label24.Visible = False
                lblFlash.Visible = True

                txtContact.Visible = True
                txtSerNum.Visible = True
                txtTimeBattery.Visible = False
                txtCharge.Visible = False
                txtBattaryStatus.Visible = False
                txtBattaryZ.Visible = False
                txtInU.Visible = False
                txtOutU.Visible = False
                txtMhzI.Visible = False
                txtStatus.Visible = False
                txtSelfTest.Visible = False
                txtThemperatureOut.Visible = False
                txtNagr.Visible = False
                txtDateSelfTest.Visible = False
                txtVbattery.Visible = False
                txtFlash.Visible = True

                txtotclIBP.Visible = False
                txtVklIBP.Visible = False
                txtSelfTestIBP.Visible = False
                txtKalibrIBP.Visible = False
                Label25.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                Label28.Visible = False


            Case "Принтеры"
                ComboBox2.Items.Add("HP")
                ComboBox2.Items.Add("Aficio")

                'lvPrinter.Columns.Add("Имя в сети", 140, HorizontalAlignment.Left)
                'lvPrinter.Columns.Add("Модель", 140, HorizontalAlignment.Left)
                'lvPrinter.Columns.Add("Отпечатано страниц", 140, HorizontalAlignment.Left)
                'lvPrinter.Columns.Add("Уровень тонера", 140, HorizontalAlignment.Left)

                'lvPrinter.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
                'lvPrinter.Columns.Add("MAC адрес", 140, HorizontalAlignment.Left)

                Label6.Visible = False
                Label8.Visible = False
                Label9.Visible = False
                Label10.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label17.Visible = False
                'Label18.Visible = False
                Label19.Visible = False
                Label21.Visible = False
                Label22.Visible = False
                Label23.Visible = False
                Label24.Visible = False


                txtContact.Visible = False
                txtSerNum.Visible = False
                txtTimeBattery.Visible = False
                txtCharge.Visible = False
                txtBattaryStatus.Visible = False
                txtBattaryZ.Visible = False
                txtInU.Visible = False
                txtOutU.Visible = False
                txtMhzI.Visible = False
                'TextBox16.Visible = False
                txtSelfTest.Visible = False
                txtThemperatureOut.Visible = False
                txtNagr.Visible = False
                txtDateSelfTest.Visible = False
                txtVbattery.Visible = False

                txtotclIBP.Visible = False
                txtVklIBP.Visible = False
                txtSelfTestIBP.Visible = False
                txtKalibrIBP.Visible = False
                Label25.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                Label28.Visible = False


                Label20.Text = "Отпечатано страниц"
                Label13.Text = "Уровень тонера"
                Label4.Text = "Модель картриджа"
                Label18.Text = "Статус"

                txtFlash.Visible = False
                lblFlash.Visible = False


            Case "Arduino"

                ComboBox2.Items.Add("Self")

                Label5.Visible = False
                Label6.Visible = False
                Label7.Visible = False
                Label8.Visible = False
                Label9.Visible = False
                Label10.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label17.Visible = False
                Label18.Visible = False
                Label19.Visible = False
                Label20.Visible = False
                Label21.Visible = False
                Label22.Visible = False
                Label23.Visible = False
                Label24.Visible = False
                Label25.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                Label28.Visible = False

                txtContact.Visible = False
                txtModel.Visible = False
                txtNetName.Visible = False
                txtSerNum.Visible = False
                txtTimeBattery.Visible = False
                txtCharge.Visible = False
                txtBattaryStatus.Visible = False
                txtBattaryZ.Visible = False
                txtUptime.Visible = False
                txtMac.Visible = False
                txtInU.Visible = False
                txtOutU.Visible = False
                txtMhzI.Visible = False
                txtStatus.Visible = False
                txtSelfTest.Visible = False
                txtThemperature.Visible = False
                txtThemperatureOut.Visible = False
                txtNagr.Visible = False
                txtDateSelfTest.Visible = False
                txtVbattery.Visible = False
                txtotclIBP.Visible = False
                txtVklIBP.Visible = False
                txtSelfTestIBP.Visible = False
                txtKalibrIBP.Visible = False
                txtFlash.Visible = False
                lblFlash.Visible = False





                Label13.Visible = True
                txtUptime.Visible = True

                Label4.Visible = True
                txtMestoN.Visible = True

                Label6.Visible = True
                txtContact.Visible = True

                Label20.Visible = True
                txtThemperature.Visible = True

                Label21.Visible = True
                Label21.Text = "Влажность"
                txtThemperatureOut.Visible = True


        End Select


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        cEDT = False
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' On Error Resume Next

        'TBL_DEV_OID

        Dim sSQL As String

        sSQL = "select count(*) as t_n from TBL_DEV_OID"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        Dim sCOUNT As Integer

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        If sCOUNT = 0 Then


        Else

            If cEDT = False Then

                sSQL = "select count(*) as t_n from TBL_DEV_OID where Model='" & txtMod.Text & "'"

                Try

                    rs = New Recordset
                    rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs
                        sCOUNT = .Fields("t_n").Value
                    End With
                    rs.Close()
                    rs = Nothing

                Catch ex As Exception

                End Try

            End If

        End If


        If cEDT = False Then


            If sCOUNT = 0 Then

                Select Case ComboBox1.Text

                    Case "Источник бесперебойного питания"

                        sSQL = "INSERT INTO TBL_DEV_OID(Device,Developer,Model,LOCATION_OID,NETNAME_OID,CONTACT_OID,MODEL_OID,SER_NUM_OID,TIME_BATTERY_OID,ZARIAD_BATTARY_OID,SOST_BATTARY_OID,ZAMENA_BATTARY_OID,UPTIME_OID,MAC_OID,IN_TOK_OID,OUT_TOK_OID,OUTPUT_FREQ_OID,OUTPUT_STATUS_OID,SELFTEST_OID,TEMPERATURE_OID,TEMPERATURE2_OID,OUTPUT_LOAD_OID,SELFTEST_DAY_OID,BATTARY_VOLTAG_OID,UPS_OTKL_OID,UPS_VKL_OID,UPS_TEST_OID,UPS_KALIBR_OID) " &
                                "VALUES('" &
                                ComboBox1.Text & "','" &
                                ComboBox2.Text & "','" &
                                txtMod.Text & "','" &
                                txtMestoN.Text & "','" &
                                txtNetName.Text & "','" &
                                txtContact.Text & "','" &
                                txtModel.Text & "','" &
                                txtSerNum.Text & "','" &
                                txtTimeBattery.Text & "','" &
                                txtCharge.Text & "','" &
                                txtBattaryStatus.Text & "','" &
                                txtBattaryZ.Text & "','" &
                                txtUptime.Text & "','" &
                                txtMac.Text & "','" &
                                txtInU.Text & "','" &
                                txtOutU.Text & "','" &
                                txtMhzI.Text & "','" &
                                txtStatus.Text & "','" &
                                txtSelfTest.Text & "','" &
                                txtThemperature.Text & "','" &
                                txtThemperatureOut.Text & "','" &
                                txtNagr.Text & "','" &
                                txtDateSelfTest.Text & "','" &
                                txtVbattery.Text & "','" &
                                txtotclIBP.Text & "','" &
                                txtVklIBP.Text & "','" &
                                txtSelfTestIBP.Text & "','" &
                                txtKalibrIBP.Text & "')"

                    Case "Коммутаторы"

                        sSQL = "INSERT INTO TBL_DEV_OID(Device,Developer,Model,LOCATION_OID,NETNAME_OID,CONTACT_OID,MODEL_OID,SER_NUM_OID,UPTIME_OID,MAC_OID,TEMPERATURE_OID,FLASH_OID) " &
                                "VALUES('" &
                                ComboBox1.Text & "','" &
                                ComboBox2.Text & "','" &
                                txtMod.Text & "','" &
                                txtMestoN.Text & "','" &
                                txtNetName.Text & "','" &
                                txtContact.Text & "','" &
                                txtModel.Text & "','" &
                                txtSerNum.Text & "','" &
                                txtUptime.Text & "','" &
                                txtMac.Text & "','" &
                                txtThemperature.Text & "','" &
                                txtFlash.Text & "')"

                    Case "Принтеры"

                        sSQL = "INSERT INTO TBL_DEV_OID(Device,Developer,Model,LOCATION_OID,NETNAME_OID,MODEL_OID,UPTIME_OID,MAC_OID,TEMPERATURE_OID,OUTPUT_STATUS_OID) " &
                        "VALUES('" &
                                ComboBox1.Text & "','" &
                                ComboBox2.Text & "','" &
                                txtMod.Text & "','" &
                                txtMestoN.Text & "','" &
                                txtNetName.Text & "','" &
                                txtModel.Text & "','" &
                                txtUptime.Text & "','" &
                                txtMac.Text & "','" &
                                txtThemperature.Text & "','" &
                                txtStatus.Text & "')"



                    Case "Arduino"

                        sSQL = "INSERT INTO TBL_DEV_OID(Device,Developer,Model,LOCATION_OID,CONTACT_OID,UPTIME_OID,TEMPERATURE_OID,TEMPERATURE2_OID) " &
                        "VALUES('" &
                                ComboBox1.Text & "','" &
                                ComboBox2.Text & "','" &
                                txtMod.Text & "','" &
                                txtMestoN.Text & "','" &
                                txtContact.Text & "','" &
                                txtUptime.Text & "','" &
                                txtThemperature.Text & "','" &
                                txtThemperatureOut.Text & "')"



                End Select

            End If

            DB7.Execute(sSQL)

        Else

            Select Case ComboBox1.Text

                Case "Источник бесперебойного питания"

                    sSQL = "UPDATE TBL_DEV_OID SET " &
                    "Device='" & ComboBox1.Text & "'," &
                    "Developer='" & ComboBox2.Text & "'," &
                    "Model='" & txtMod.Text & "'," &
                    "LOCATION_OID='" & txtMestoN.Text & "'," &
                    "NETNAME_OID='" & txtNetName.Text & "'," &
                    "CONTACT_OID='" & txtContact.Text & "'," &
                    "MODEL_OID='" & txtModel.Text & "'," &
                    "SER_NUM_OID='" & txtSerNum.Text & "'," &
                    "TIME_BATTERY_OID='" & txtTimeBattery.Text & "'," &
                    "ZARIAD_BATTARY_OID='" & txtCharge.Text & "'," &
                    "SOST_BATTARY_OID='" & txtBattaryStatus.Text & "'," &
                    "ZAMENA_BATTARY_OID='" & txtBattaryZ.Text & "'," &
                    "UPTIME_OID='" & txtUptime.Text & "'," &
                    "MAC_OID='" & txtMac.Text & "'," &
                    "IN_TOK_OID='" & txtInU.Text & "'," &
                    "OUT_TOK_OID='" & txtOutU.Text & "'," &
                    "OUTPUT_FREQ_OID='" & txtMhzI.Text & "'," &
                    "OUTPUT_STATUS_OID='" & txtStatus.Text & "'," &
                    "SELFTEST_OID='" & txtSelfTest.Text & "'," &
                    "TEMPERATURE_OID='" & txtThemperature.Text & "'," &
                    "TEMPERATURE2_OID='" & txtThemperatureOut.Text & "'," &
                    "OUTPUT_LOAD_OID='" & txtNagr.Text & "'," &
                    "SELFTEST_DAY_OID='" & txtDateSelfTest.Text & "'," &
                    "BATTARY_VOLTAG_OID='" & txtVbattery.Text & "', " &
                    "UPS_OTKL_OID='" & txtotclIBP.Text & "', " &
                    "UPS_VKL_OID='" & txtVklIBP.Text & "', " &
                    "UPS_TEST_OID='" & txtSelfTestIBP.Text & "', " &
                    "UPS_KALIBR_OID='" & txtKalibrIBP.Text & "' " &
                    "WHERE id=" & cID

                Case "Коммутаторы"

                    sSQL = "UPDATE TBL_DEV_OID SET " &
                    "Device='" & ComboBox1.Text & "'," &
                    "Developer='" & ComboBox2.Text & "'," &
                    "Model='" & txtMod.Text & "'," &
                    "LOCATION_OID='" & txtMestoN.Text & "'," &
                    "NETNAME_OID='" & txtNetName.Text & "'," &
                    "CONTACT_OID='" & txtContact.Text & "'," &
                    "MODEL_OID='" & txtModel.Text & "'," &
                    "SER_NUM_OID='" & txtSerNum.Text & "'," &
                    "UPTIME_OID='" & txtUptime.Text & "'," &
                    "MAC_OID='" & txtMac.Text & "'," &
                    "TEMPERATURE_OID='" & txtThemperature.Text & "'," &
                    "FLASH_OID='" & txtThemperatureOut.Text & "' " &
                    "WHERE id=" & cID


                Case "Принтеры"

                    sSQL = "UPDATE TBL_DEV_OID SET " &
                   "Device='" & ComboBox1.Text & "'," &
                   "Developer='" & ComboBox2.Text & "'," &
                   "Model='" & txtMod.Text & "'," &
                   "LOCATION_OID='" & txtMestoN.Text & "'," &
                   "NETNAME_OID='" & txtNetName.Text & "'," &
                   "MODEL_OID='" & txtModel.Text & "'," &
                   "UPTIME_OID='" & txtUptime.Text & "'," &
                   "MAC_OID='" & txtMac.Text & "'," &
                   "TEMPERATURE_OID='" & txtThemperature.Text & "'," &
                   "OUTPUT_STATUS_OID='" & txtStatus.Text & "' " &
                   "WHERE id=" & cID



                Case "Arduino"



                    sSQL = "UPDATE TBL_DEV_OID SET " &
                  "Device='" & ComboBox1.Text & "'," &
                  "Developer='" & ComboBox2.Text & "'," &
                  "Model='" & txtMod.Text & "'," &
                  "LOCATION_OID='" & txtMestoN.Text & "'," &
                  "UPTIME_OID='" & txtUptime.Text & "'," &
                  "TEMPERATURE_OID='" & txtThemperature.Text & "'," &
                  "TEMPERATURE2_OID='" & txtThemperatureOut.Text & "' " &
                  "WHERE id=" & cID

            End Select

            DB7.Execute(sSQL)

            Call frmEdit_Dev_spr.LOAD_DEV_LST()


        End If

        '################################
        'Очищаем текстовые поля
        '################################
        txtMod.Text = ""
        txtMestoN.Text = ""
        txtNetName.Text = ""
        txtContact.Text = ""
        txtModel.Text = ""
        txtSerNum.Text = ""
        txtTimeBattery.Text = ""
        txtCharge.Text = ""
        txtBattaryStatus.Text = ""
        txtBattaryZ.Text = ""
        txtUptime.Text = ""
        txtMac.Text = ""
        txtInU.Text = ""
        txtOutU.Text = ""
        txtMhzI.Text = ""
        txtStatus.Text = ""
        txtSelfTest.Text = ""
        txtThemperature.Text = ""
        txtThemperatureOut.Text = ""
        txtNagr.Text = ""
        txtDateSelfTest.Text = ""
        txtVbattery.Text = ""
        txtotclIBP.Text = ""
        txtVklIBP.Text = ""
        txtSelfTestIBP.Text = ""
        txtKalibrIBP.Text = ""
        txtFlash.Text = ""

        'BATTARY_VOLTAG_OID
        cEDT = False
        Me.Close()


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        Select Case ComboBox2.Text

            Case "APC"

                txtMod.Text = ""
                txtMestoN.Text = "1.3.6.1.2.1.1.6.0"
                txtNetName.Text = "1.3.6.1.2.1.1.5.0"
                txtContact.Text = "1.3.6.1.2.1.1.4.0"
                txtModel.Text = "1.3.6.1.4.1.318.1.1.1.1.1.1.0"
                txtSerNum.Text = "1.3.6.1.4.1.318.1.1.1.1.2.3.0"
                txtTimeBattery.Text = "1.3.6.1.4.1.318.1.1.1.2.2.3.0"
                txtCharge.Text = "1.3.6.1.4.1.318.1.1.1.2.2.1.0"
                txtBattaryStatus.Text = "1.3.6.1.4.1.318.1.1.1.2.1.1.0"
                txtBattaryZ.Text = "1.3.6.1.4.1.318.1.1.1.2.2.4.0"
                txtUptime.Text = "1.3.6.1.2.1.1.3.0"
                txtMac.Text = "1.3.6.1.2.1.2.2.1.6.2"
                txtInU.Text = "1.3.6.1.4.1.318.1.1.1.3.2.1.0"
                txtOutU.Text = "1.3.6.1.4.1.318.1.1.1.3.2.3.0"
                txtMhzI.Text = "1.3.6.1.4.1.318.1.1.1.4.2.2.0"
                txtStatus.Text = "1.3.6.1.4.1.318.1.1.1.4.1.1.0"
                txtSelfTest.Text = "1.3.6.1.4.1.318.1.1.1.7.2.3.0"
                txtThemperature.Text = "1.3.6.1.4.1.318.1.1.1.2.2.2.0"
                txtThemperatureOut.Text = "1.3.6.1.4.1.318.1.1.25.1.2.1.6.1.1"
                txtNagr.Text = "1.3.6.1.4.1.318.1.1.1.4.2.3.0"
                txtDateSelfTest.Text = "1.3.6.1.4.1.318.1.1.1.7.2.4.0"

                txtotclIBP.Text = "1.3.6.1.4.1.318.1.1.1.6.2.1.0"
                txtVklIBP.Text = "1.3.6.1.4.1.318.1.1.1.6.2.6.0"
                txtSelfTestIBP.Text = "1.3.6.1.4.1.318.1.1.1.7.2.2.0"
                txtKalibrIBP.Text = "1.3.6.1.4.1.318.1.1.1.7.2.5.0"
            Case "EATON"

                txtMod.Text = ""
                txtMestoN.Text = "1.3.6.1.2.1.1.6.0"
                txtNetName.Text = "1.3.6.1.4.1.705.1.1.2.0"
                txtContact.Text = "1.3.6.1.4.705.1.1.5.0"
                txtModel.Text = "1.3.6.1.4.1.705.1.1.2.0"
                txtSerNum.Text = "1.3.6.1.4.1.705.1.1.7.0"
                txtTimeBattery.Text = "1.3.6.1.4.1.705.1.5.1.0"
                txtCharge.Text = "1.3.6.1.4.1.705.1.5.2.0"
                txtBattaryStatus.Text = "1.3.6.1.4.1.705.1.5.9.0"
                txtBattaryZ.Text = "1.3.6.1.4.1.705.1.5.11.0"
                txtUptime.Text = "1.3.6.1.2.1.1.3.0"
                txtMac.Text = "1.3.6.1.2.1.4.30.1.4.2"
                txtInU.Text = "1.3.6.1.4.1.705.1.6.2.1.2.1.0"
                txtOutU.Text = "1.3.6.1.4.1.705.1.7.2.1.2.1"
                txtMhzI.Text = "1.3.6.1.4.1.705.1.7.2.1.3.1"
                txtStatus.Text = "1.3.6.1.4.1.705.1.7.4.0"
                txtSelfTest.Text = "1.3.6.1.4.705.1.10.3.0"
                txtThemperature.Text = "1.3.6.1.4.705.1.5.7.0"
                txtThemperatureOut.Text = "1.3.6.1.4.1.705.1.8.1"
                txtNagr.Text = "1.3.6.1.4.1.318.1.1.1.4.2.3.0"
                txtDateSelfTest.Text = ""


            Case "CISCO"

                txtMod.Text = ""
                txtMestoN.Text = "1.3.6.1.2.1.1.6.0"
                txtNetName.Text = "1.3.6.1.2.1.1.5.0"
                txtContact.Text = "1.3.6.1.2.1.1.4.0"
                txtModel.Text = "1.3.6.1.2.1.47.1.1.1.1.13.1001"
                txtSerNum.Text = "1.3.6.1.4.1.9.5.1.2.19.0"
                txtUptime.Text = "1.3.6.1.2.1.1.3.0"
                txtMac.Text = "1.3.6.1.2.1.17.1.1.0"
                txtThemperature.Text = "1.3.6.1.4.1.9.9.13.1.3.1.3.1005"
                txtFlash.Text = "1.3.6.1.4.1.9.2.1.73.0"

            Case "HP"

                txtMod.Text = ""
                txtModel.Text = "1.3.6.1.2.1.25.3.2.1.3.1"
                txtMestoN.Text = "1.3.6.1.2.1.43.11.1.1.6.1.1"
                txtNetName.Text = "1.3.6.1.2.1.1.5.0"
                txtUptime.Text = "1.3.6.1.4.1.11.2.3.9.4.2.1.4.1.10.1.1.18.1.0"
                txtMac.Text = "1.3.6.1.4.1.11.2.4.3.1.12.1.2.5"
                txtThemperature.Text = "1.3.6.1.2.1.43.10.2.1.4.1.1"

            Case "Aficio"

                txtMod.Text = ""
                txtModel.Text = "1.3.6.1.2.1.25.3.2.1.3.1"
                txtMestoN.Text = ""
                txtNetName.Text = ""
                txtUptime.Text = ""
                txtMac.Text = ""
                txtThemperature.Text = ""


            Case "Self"

                txtUptime.Text = "1.3.6.1.2.1.1.3"
                txtMestoN.Text = ""
                txtContact.Text = ""
                txtThemperature.Text = "1.3.6.1.3.36582.0.4.0"
                txtThemperatureOut.Text = "1.3.6.1.3.36582.0.3.0"

        End Select





    End Sub

    Private Sub frmDev_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cEDT = False

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        txtMod.Text = ""
        txtMestoN.Text = ""
        txtNetName.Text = ""
        txtContact.Text = ""
        txtModel.Text = ""
        txtSerNum.Text = ""
        txtTimeBattery.Text = ""
        txtCharge.Text = ""
        txtBattaryStatus.Text = ""
        txtBattaryZ.Text = ""
        txtUptime.Text = ""
        txtMac.Text = ""
        txtInU.Text = ""
        txtOutU.Text = ""
        txtMhzI.Text = ""
        txtStatus.Text = ""
        txtSelfTest.Text = ""
        txtThemperature.Text = ""
        txtThemperatureOut.Text = ""
        txtNagr.Text = ""
        txtDateSelfTest.Text = ""
        txtVbattery.Text = ""
        txtotclIBP.Text = ""
        txtVklIBP.Text = ""
        txtSelfTestIBP.Text = ""
        txtKalibrIBP.Text = ""

        txtFlash.Text = ""

    End Sub

    Private Sub frmDev_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'lstDevice

        On Error Resume Next


        If cEDT = True Then

            Dim sCOUNT As Integer

            Dim sSQL As String

            sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

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
                rs.Open("SELECT * FROM TBL_DEV_OID WHERE ID=" & cID, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


                With rs

                    ComboBox1.Text = .Fields("Device").Value
                    ComboBox2.Text = .Fields("Developer").Value
                    txtMod.Text = .Fields("Model").Value
                    txtMestoN.Text = .Fields("LOCATION_OID").Value
                    txtNetName.Text = .Fields("NETNAME_OID").Value
                    txtContact.Text = .Fields("CONTACT_OID").Value
                    txtModel.Text = .Fields("MODEL_OID").Value
                    txtSerNum.Text = .Fields("SER_NUM_OID").Value
                    txtTimeBattery.Text = .Fields("TIME_BATTERY_OID").Value
                    txtCharge.Text = .Fields("ZARIAD_BATTARY_OID").Value
                    txtBattaryStatus.Text = .Fields("SOST_BATTARY_OID").Value
                    txtBattaryZ.Text = .Fields("ZAMENA_BATTARY_OID").Value
                    txtUptime.Text = .Fields("UPTIME_OID").Value
                    txtMac.Text = .Fields("MAC_OID").Value
                    txtInU.Text = .Fields("IN_TOK_OID").Value
                    txtOutU.Text = .Fields("OUT_TOK_OID").Value
                    txtMhzI.Text = .Fields("OUTPUT_FREQ_OID").Value
                    txtStatus.Text = .Fields("OUTPUT_STATUS_OID").Value
                    txtSelfTest.Text = .Fields("SELFTEST_OID").Value
                    txtThemperature.Text = .Fields("TEMPERATURE_OID").Value
                    txtThemperatureOut.Text = .Fields("TEMPERATURE2_OID").Value
                    txtNagr.Text = .Fields("OUTPUT_LOAD_OID").Value
                    txtDateSelfTest.Text = .Fields("SELFTEST_DAY_OID").Value
                    txtVbattery.Text = .Fields("BATTARY_VOLTAG_OID").Value



                    If Not IsDBNull(.Fields("UPS_OTKL_OID").Value) Then
                        txtotclIBP.Text = .Fields("UPS_OTKL_OID").Value
                    Else
                        txtotclIBP.Text = ""
                    End If

                    If Not IsDBNull(.Fields("UPS_VKL_OID").Value) Then
                        txtVklIBP.Text = .Fields("UPS_VKL_OID").Value
                    Else
                        txtVklIBP.Text = ""
                    End If

                    If Not IsDBNull(.Fields("UPS_TEST_OID").Value) Then
                        txtSelfTestIBP.Text = .Fields("UPS_TEST_OID").Value
                    Else
                        txtSelfTestIBP.Text = ""
                    End If

                    If Not IsDBNull(.Fields("UPS_KALIBR_OID").Value) Then
                        txtKalibrIBP.Text = .Fields("UPS_KALIBR_OID").Value
                    Else
                        txtKalibrIBP.Text = ""
                    End If

                End With
                rs.Close()
                rs = Nothing

            End If

        End If




    End Sub
End Class