' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gnet.com/webboard
' / 
' / Purpose: Monitor CPU Temperatures with BackgroundWorker.
' / Microsoft Visual Basic .NET (2010)
' /
' / This is open source code under @CopyLeft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------------------

' / Special Thanks: https://openhardwaremonitor.org/
Imports OpenHardwareMonitor.Hardware

Public Class frmCpuTemperature
    '// List of CPUs
    Dim MyList As New List(Of String)()

    '// Toggle Switch On/Off.
    Dim blnSucceed As Boolean = False

    ' / --------------------------------------------------------------------------------
    '// S T A R T ----- H E R E
    Private Sub frmCPUTemperature_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '// Initialized Timer Interval
        For i As Byte = 1 To 60
            cmbInterval.Items.Add(i)
        Next
        With cmbInterval
            .MaxDropDownItems = 10
            .IntegralHeight = False
            .SelectedIndex = 0
        End With
        '//
        '// Initialized ListView
        Call InitListView()
        '// Create ProgressBae Control @Runtime.
        Call CreateCPUProgress()

        '// Initialized BackGroundWorker.
        With BackgroundWorker1
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True
        End With
        '//
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
        '// Initialized and start Timer1
        Timer1.Interval = 1000
        Timer1.Enabled = True
        '//
    End Sub

    '// Create ProgressBae Control @Runtime.
    Private Sub CreateCPUProgress()
        Dim cp As New Computer()
        cp.Open()
        cp.CPUEnabled = True
        '//
        Dim cpu = cp.Hardware.Where(Function(h) h.HardwareType = HardwareType.CPU).FirstOrDefault()
        Dim tempSensors = cpu.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature)
        tempSensors.ToList.ForEach(Sub(s) MyList.Add(s.Name))
        cp.CPUEnabled = False
        cp.Close()

        '// Create ProgressBar @Run Time
        Dim pgbX As Integer = 21
        Dim pgbY As Integer = 216
        Dim MyHeight As Integer = Me.Height
        For i As Integer = 0 To MyList.Count - 1
            Dim p As New ProgressBar
            With p
                .Name = MyList(i).ToString
                .Size = New Size(653, 23)
                .Maximum = 100
                .Minimum = 0
                .Location = New Point(pgbX, pgbY)
                .Visible = True
            End With
            Me.Controls.Add(p)
            '// Label show CPU Name
            Dim L1 As New Label
            With L1
                .Name = "CPU" & i
                .Location = New Point(pgbX, pgbY - p.Height + 6)
                .Text = MyList(i).ToString
                .Visible = True
            End With
            Me.Controls.Add(L1)
            '// Label show percent.
            Dim L2 As New Label
            With L2
                .Name = "C" & i
                .Location = New Point(p.Width - 10, pgbY - p.Height + 6)
                .Text = "0C"
                .Visible = True
            End With
            Me.Controls.Add(L2)
            '//
            pgbY += 40
            Me.Height = MyHeight + p.Height + 60
        Next
    End Sub

    '// BackgroundWorker - Events DoWork
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '// Refer OpenHardwareMonitor
        Dim cp As New Computer()
        cp.Open()
        cp.CPUEnabled = True
        '// Additional.
        cp.GPUEnabled = True
        'cp.HDDEnabled = True
        'cp.RAMEnabled = True
        'cp.FanControllerEnabled = True
        'cp.MainboardEnabled = True
        '//
        lvwData.Items.Clear()
        For Each hardwareItem In cp.Hardware
            hardwareItem.Update()
            '// Detect Sensor only.
            For Each sensor In hardwareItem.Sensors
                If (sensor.SensorType = SensorType.Temperature) Then
                    Dim LV As ListViewItem
                    LV = lvwData.Items.Add(sensor.Name)
                    '// Split name --> OpenHardwareMonitor.Hardware.CPU.IntelCPU --> Get IntelCPU (or AMD)
                    Dim hw() As String = Split(sensor.Hardware.ToString, ".")
                    LV.SubItems.Add(hw(UBound(hw)))
                    '// Sensor Value.
                    LV.SubItems.Add(Format(sensor.Value, "0.0"))
                    '// Display value on the ProgressBar.
                    For i As Byte = 0 To MyList.Count - 1
                        If MyList(i).ToString = sensor.Name Then
                            '// Access it indirectly through a new control.
                            Dim pgb As ProgressBar = Me.Controls(MyList(i).ToString)
                            pgb.Value = sensor.Value
                            Dim lbl As Label = Me.Controls("C" & i)
                            lbl.Text = sensor.Value & "C"
                        End If
                    Next
                End If
            Next
        Next
    End Sub

    '// When change occurs.
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '// 
        '// Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    '// When finished.
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        '// ON
        blnSucceed = True
    End Sub

    '// Switch On/Off
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If blnSucceed Then
            BackgroundWorker1.RunWorkerAsync()
            '// OFF
            blnSucceed = False
            '//
        End If
    End Sub

    Private Sub frmCpuTemperature_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        BackgroundWorker1.Dispose()
        Timer1.Enabled = False
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub

    '/ Initialize ListView Control
    Private Sub InitListView()
        With lvwData
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = False
            '/ Use 2 Columns, with the first digit having Index = 0
            .Columns.Add("Sensor.Name", lvwData.Width \ 3)
            .Columns.Add("Sensor.Hardware", lvwData.Width \ 3 - 30)
            .Columns.Add("Sensor.Value (Celsius)", lvwData.Width \ 3 - 30)
        End With
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://openhardwaremonitor.org/")
    End Sub

    Private Sub cmbInterval_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbInterval.SelectedIndexChanged
        '// 1 Second = 1000 millisecond.
        Timer1.Interval = Val(cmbInterval.Text) * 1000
    End Sub
End Class
