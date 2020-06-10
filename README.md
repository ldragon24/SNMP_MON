# SNMP Monitor

Программа  «SNMP Monitor» предназначена для мониторинга состояния источников бесперебойного питания, сетевых коммутаторов, принтеров и других сетевых устройств по протоколу SNMP, ICMP и WMI. 

Возможности программы:
*	Не требует установки, запускается из любого места. Для запуска необходимы 3 файла: snmpapcmon.exe, snmpapcmon.mdb и SnmpSharpNet.dll
*	Запрашивает информацию о состоянии устройств по протоколу SNMP и WMI (для серверов и АРМов) и выводит её в лист.
*	В случае возникновения критического состояния устройства (такие как превышение температуры, переход на питание от батарей, недоступность устройства) программа выводит сообщение на экран монитора и\или высылает сообщение на электронную почту.

имеет следующие модули:
* Модуль «Источники бесперебойного питания»
  * RealTime мониторинг ИБП
  * Управление ИБП
* Модуль мониторинга коммутаторов
* Модуль мониторинга свободного пространства на жёстких дисках
* Модуль Ping
* Модуль Аппаратные (мониторинг температуры и влажности в аппаратных, протокол SNMP)
* Модуль Антивирус



Модуль «Источники бесперебойного питания»
  Отображает и сохраняет в БД различные параметры источников бесперебойного питания. Сохранённые данные можно просмотреть в виде графиков.
  
RealTime мониторинг ИБП
  Модуль отображения информации о состоянии ИБП в «реальном времени» (интервал обновления информации 1 секунда).
  
Управление ИБП
  Реализовано управление источником бесперебойного питания в плане:
1.	Отключение ИБП с отключением нагруженного оборудования до того, как будет отключён ИБП
2.	Включение ИБП
3.	Запуск самодиагностики ИБП
4.	Запуск калибровки батарей ИБП

---

SNMP Monitor is designed to monitor the status of uninterruptible power supplies, network switches, printers and other network devices via SNMP, ICMP and WMI. 

The program's capabilities:
* No installation required, runs from any place. It requires 3 files: snmpapcmon.exe, snmpapcmon.mdb and SnmpSharpNet.dll.
* Requests information about the state of devices via SNMP and WMI (for servers and workstations) and displays it in the list.
* In case of critical device state (such as excess temperature, switching to battery power, device unavailability) the program displays a message on the monitor screen и\или.

has the following modules:
* Module "Uninterruptible power supply"
  * RealTime UPS monitoring
  * UPS management
* Switch monitoring module
* Free space monitoring module on hard drives
* Ping module
* Hardware module (temperature and humidity monitoring in hardware, SNMP protocol)
* Antivirus module

Uninterruptible Power Supplies module
  Displays and saves to the database various parameters of uninterruptible power supplies. Saved data can be viewed as graphs.
  
RealTime UPS monitoring
  Module for displaying information about the UPS status in "real time" (information update interval 1 second).
  
UPS management
  Uninterruptible power supply management in plan has been implemented:
Disconnecting the UPS with shutdown of the loaded equipment before the UPS is disconnected.
2.	Turning on the UPS
3.	Launch of UPS self-diagnostics
4.	Start calibration of UPS batteries
---
