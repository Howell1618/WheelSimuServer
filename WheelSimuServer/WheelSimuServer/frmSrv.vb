Imports System.Reflection, System.Threading, System.ComponentModel, System.Runtime.InteropServices
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports vJoyInterfaceWrap.vJoy


Public Class frmSrv

    Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    <DllImport("user32.dll", EntryPoint:="keybd_event")>
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)
    End Sub

    Public Const MOUSEEVENTF_LEFTDOWN = &H2 '模拟鼠标左键按下
    Public Const MOUSEEVENTF_LEFTUP = &H4 '模拟鼠标左键释放
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 '模拟鼠标中间键按下
    Public Const MOUSEEVENTF_MIDDLEUP = &H40 '模拟鼠标中间键释放
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8 '模拟鼠标右键按下
    Public Const MOUSEEVENTF_RIGHTUP = &H10 '模拟鼠标右键释放
    Public Const MOUSEEVENTF_MOVE = &H1 '模拟鼠标指针移动

    Public Const KEYEVENTF_KEYUP = &H2 'Key Up

    Dim s(1) As Socket
    Dim t(2) As Thread
    Dim ss As Socket

    Structure IPFormat
        Dim IP As String
        Dim Port As Integer
    End Structure
    Dim IPData(1) As IPFormat

    Dim TryTimes As Integer = 1

    Dim MaxX As Integer
    Dim MaxY As Integer
    Dim MidX As Integer
    Dim MidY As Integer
    Dim SingleX As Double
    Dim InitSingleX As Double = 1

    Dim Throttle As Integer
    Dim Brake As Integer
    Dim tmpBrake, tmpThrottle As Integer
    Dim Angle As Double
    Dim TmpAngle As Double    'DEBUG  还未输出的转向角
    Dim ShakeRange As Double  'vJoy模式中转向角防抖参数
    Dim sSet As Integer
    Dim sGear As Integer
    Dim sGearUp As Integer
    Dim sGearDn As Integer
    Dim sSetSR As Integer
    Dim TmpSetSR As Integer
    'Dim sClearAngle As Integer
    Dim TmpGear As Integer
    Dim TmpSet As Integer
    Dim TimsUp As Integer = 0
    Dim TimsDn As Integer = 0
    Dim LastThrottle, LastBrake As Integer

    '------- 方向盘模拟类型 -------
    '0 --- GTA5
    '1 --- 神力科莎 键盘鼠标
    '2 --- 神力科莎 vJoy
    Dim WheelType As Integer = 2
    'Dim WheelOffset As Double

    'Dim MousePosition As Integer
    Dim LastAngle As Double
    Dim XTotalMove As Double   'vJoy模式中为稳定转向角
    Dim TAmax, TAmin As Double  'DEBUG 最大/最小转向角
    Dim Kup As Integer
    Dim Kdn As Integer
    Delegate Sub wt_chaozuoLBox(ByVal TmpStr As String, ByRef LBox As ListBox)
    Delegate Sub wt_chaozuoTBox(ByVal TmpStr As String, ByRef TBox As Object)
    Delegate Sub wt_chaozuoKey(ByVal TmpStr As String, ByVal Act As Integer)


    Dim vJoy As New vJoyInterfaceWrap.vJoy
    Dim vJoyDeviceList As New ListBox
    Dim ReportId As Integer
    Dim WheelMaxAngle As Integer = 900
    Dim vJoyAxisMax As Integer = 32768

    Private Sub frmSrv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strHostName As String = System.Net.Dns.GetHostName()

            lblVersionNo.Text = "Ver " & My.Application.Info.Version.ToString
            IPData(1).IP = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString()  '获取本机IP地址
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "请在App上输入IP地址：" & IPData(1).IP, ListBox1)
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "请确认IPv4地址正确，否则请手动更改！", ListBox1)
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "点击 START 后再App上点击 CONNECT", ListBox1)

            '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            '---------------------- 开始初始化vJoy设备 ----------------------

            If Not vJoy.vJoyEnabled Then
                Err.Raise("vJoy驱动启动失败！")
            End If

            If Not GetExistingDevices() Then
                Err.Raise("未找到可用设备！")
            End If

            If Not vJoy.AcquireVJD(GetCurrentReportId()) Then
                Err.Raise("无法开启vJoy设备！")
            End If

            If Not js_update("INIT") Then
                Err.Raise("vJoy设备初始化失败！")
            End If
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "vJoy设备初始化成功！", ListBox1)
            'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        Catch ex As Exception
            Dim StackFrame As New StackFrame()
            Dim MethodBase As MethodBase = StackFrame.GetMethod()
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try

    End Sub

    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    '----------------------------- vJoy Function -----------------------------
    Private Function GetExistingDevices() As Boolean
        'Populate the list of target devices with the Report IDs Of all existing devices
        Dim exist As Boolean = False

        For i As Integer = 1 To 16
            If (vJoy.GetVJDStatus(i) = VjdStat.VJD_STAT_FREE) Then
                exist = True
                vJoyDeviceList.Items.Add(i)
            End If

        Next

        If (exist) Then
            vJoyDeviceList.SelectedIndex = 0
        End If

        Return exist
    End Function

    Private Function GetCurrentReportId() As Integer
        'Get the selected value from the target's listbox
        If (vJoyDeviceList.SelectedIndex < 0) Then
            Return -1
        End If

        Dim str As String = vJoyDeviceList.SelectedItem.ToString()
        If Not IsNothing(str) Then
            ReportId = Val(vJoyDeviceList.SelectedItem.ToString())
        End If

        Return ReportId
    End Function

    'Fill the data structure with data collected from the controls
    'Then send to vJoy Device
    Private Function js_update(ByVal Action As String) As Boolean
        Dim Report As vJoyInterfaceWrap.vJoy.JoystickState
        Dim ButtonCount As Integer = 2
        Dim TmpButton(ButtonCount) As Integer


        Try
            ' If no target selected then NO-OP
            If vJoyDeviceList.SelectedIndex = -1 Then
                Err.Raise("未找到可用设备！")
            End If

            ' Report Id
            Report.bDevice = vJoyDeviceList.SelectedItem.ToString()

            Select Case Action

                Case "UPDATE"
                    ' Axes
                    'Value in the range 0x1-0x8000
                    '非线性
                    'tmpBrake = Brake * (tmpBrake + 300)
                    'tmpThrottle = Throttle * (tmpThrottle + 300)
                    'If tmpBrake > vJoyAxisMax Then tmpBrake = vJoyAxisMax
                    'If tmpThrottle > vJoyAxisMax Then tmpThrottle = vJoyAxisMax

                    tmpBrake = CInt(Brake * vJoyAxisMax / 100)
                    tmpThrottle = CInt(Throttle * vJoyAxisMax / 100)

                    Report.AxisX = tmpBrake
                    Report.AxisY = tmpThrottle

                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^转向角防抖^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    If Math.Abs(Angle - XTotalMove) > ShakeRange Then
                        XTotalMove = Angle
                    End If
                    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
                    Report.Dial = 16384 + XTotalMove * SingleX  '(vJoyAxisMax /2) + (CInt(Angle) - WheelOffset) * SingleX

                    'Report.Throttle = Throttle * vJoyAxisMax
                    'Report.Wheel = vJoyAxisMax / 2 + Angle * SingleX


                    'Buttons   Button1按下 0001 - Button1弹起 0000
                    If (sGearUp = 1) Then TmpButton(0) = 1 Else TmpButton(0) = 0 '升档
                    If (sGearDn = 1) Then TmpButton(1) = 1 Else TmpButton(1) = 0 '降档

                Case "INIT"
                    ' Axes
                    Report.AxisX = 0
                    Report.AxisY = 0
                    Report.AxisZ = 0
                    Report.AxisXRot = 0
                    Report.AxisYRot = 0
                    Report.AxisZRot = 0
                    Report.Slider = 0
                    Report.Dial = 0

                    'Not implemented
                    Report.AxisVBRX = 0
                    Report.AxisVBRY = 0
                    Report.AxisVBRZ = 0
                    Report.AxisVX = 0
                    Report.AxisVY = 0
                    Report.AxisVZ = 0
                    Report.Aileron = 0
                    Report.Rudder = 0
                    Report.Throttle = 0
                    Report.Wheel = 0


            End Select

            '计算发给vJoy的Button值
            Report.Buttons = 0
            For i As Integer = 0 To ButtonCount - 1
                Report.Buttons += TmpButton(i) * (2 ^ i)
            Next

            'Send info to selected vJoy Device
            vJoy.UpdateVJD(ReportId, Report)
            js_update = True

        Catch ex As Exception
            js_update = False
            Dim StackFrame As New StackFrame()
            Dim MethodBase As MethodBase = StackFrame.GetMethod()
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try

    End Function

    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

    '服务端
    Public Sub Child_WaitData(ByVal i As Integer)


        Dim TmpStr As String
        Dim ShowStr As String
        Dim RcvStr As String
        Dim bytes() As Byte ' 用来存储接收到的字节
        Dim SplitFlag As Integer
        Try

            IPData(i).Port = GetPort()
            s(i) = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) '使用TCP协议
            Dim localEndPoint As New IPEndPoint(IPAddress.Parse(IPData(i).IP), IPData(i).Port) ' 指定IP和Port (应该是本机IP)
            s(i).Bind(localEndPoint)  ' 绑定到该Socket

            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "当前电脑使用的端口为：" & IPData(i).Port, ListBox1)

            s(i).Listen(10)  ' 侦听，同时最多接受100个连接
            ss = s(i).Accept()  '若接收到,则创建一个新的Socket与之连接
            While (True)
                ReDim bytes(256)
                ss.Receive(bytes)  ' 接收数据，若用ss.send(Byte()),则发送数据
                TmpStr = Encoding.Unicode.GetString(bytes)
                TmpStr = Trim(Mid(TmpStr, 1, TmpStr.Length - 1))
                SplitFlag = InStr(TmpStr, "0@")
                Do Until SplitFlag = 0
                    RcvStr = Mid(TmpStr, 1, SplitFlag - 1)
                    Call ProcessStr(RcvStr)
                    ShowStr = DirectCast((ss.RemoteEndPoint), System.Net.IPEndPoint).ToString & " ：" & RcvStr
                    'Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), ShowStr, ListBox1)   'DEBUG 将收到的控制信号显示到ListBox上
                    TmpStr = Mid(TmpStr, SplitFlag + 2)
                    SplitFlag = InStr(TmpStr, "0@")
                Loop

            End While


        Catch ex As Exception
            'Dim StackFrame As New StackFrame()
            'Dim MethodBase As MethodBase = StackFrame.GetMethod()
            'Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)

            TryTimes += 1
            If TryTimes = 10 Then TryTimes = 1
        End Try
    End Sub


    Private Sub ProcessStr(ByVal RcvStr As String)

        Dim array() As String
        Dim MouseX, MouseY As Integer


        Try

            array = RcvStr.Split(",")
            For Each tmpdata In array
                If tmpdata.StartsWith("A=") Then              '
                    Angle = Format(Val(Mid(tmpdata, 3)), "0.00")  '转向 
                ElseIf tmpdata.StartsWith("T=") Then
                    Throttle = Val(Mid(tmpdata, 3))               '油门
                ElseIf tmpdata.StartsWith("B=") Then              '
                    Brake = Val(Mid(tmpdata, 3))                  '刹车
                ElseIf tmpdata.StartsWith("Gu=") Then             '
                    sGearUp = Val(Mid(tmpdata, 4))                '升挡
                ElseIf tmpdata.StartsWith("Gd=") Then             '
                    sGearDn = Val(Mid(tmpdata, 4))                '降挡
                ElseIf tmpdata.StartsWith("G=") Then              '
                    sGear = Val(Mid(tmpdata, 3))                  '换挡
                ElseIf tmpdata.StartsWith("S=") Then              '
                    sSet = Val(Mid(tmpdata, 3))                   '设置灵敏度
                ElseIf tmpdata.StartsWith("SR=") Then             '
                    sSetSR = Val(Mid(tmpdata, 4))                 '设置抖动值
                    'ElseIf tmpdata.StartsWith("C=") Then              '
                    '    sClearAngle = Val(Mid(tmpdata, 3))            '键鼠:回正方向  vJoy:偏移补偿
                End If
            Next


            Select Case WheelType
                Case 0, 1  '键鼠控制
                    Angle = CInt(Angle)


                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^加减档^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                    If sGear <> 0 Then
                        If sGear = 1 And sGear <> TmpGear Then
                            Me.Invoke(New wt_chaozuoKey(AddressOf Main_KeyPress), "GearUp", 0)
                            TimsUp += 1  'DEBUG
                        ElseIf sGear = -1 And sGear <> TmpGear Then
                            Me.Invoke(New wt_chaozuoKey(AddressOf Main_KeyPress), "GearDown", 0)
                            TimsDn += 1  'DEBUG
                        End If

                    End If
                    TmpGear = sGear '换过一次档后的间隔期间 TmpGear 重置为0，避免按一次换挡触发多次换挡



                    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv加减档vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv


                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^油门刹车^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                    If Throttle <> LastThrottle Then
                        Me.Invoke(New wt_chaozuoKey(AddressOf Main_KeyPress), "{UP}", Throttle)
                    End If
                    If Brake = LastBrake Then
                        Me.Invoke(New wt_chaozuoKey(AddressOf Main_KeyPress), "{DOWN}", Brake)
                    End If
                    LastThrottle = Throttle
                    LastBrake = Brake



                    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv油门刹车vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv



                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^方向控制^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                    '先获取当前鼠标位置
                    MouseX = System.Windows.Forms.Cursor.Position.X
                    MouseY = System.Windows.Forms.Cursor.Position.Y

                    If sSet <> 0 Then
                        If sSet = -1 Then
                            Select Case WheelType
                                Case 0
                                    SingleX = (MouseX - MidX) / 90

                                Case 1
                                    '90度时鼠标偏移的位置/90 = 新的转向比
                                    SingleX = XTotalMove / 90
                            End Select
                        Else 'reset
                            SingleX = InitSingleX
                        End If
                    End If


                    Select Case WheelType
                        Case 0
                            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                            SetMouseXY(MidX + Val(SingleX * Angle), 980)
                            'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), "X=" & MouseX & " Y=" & MouseY, tboxMousePosition)

                            'Case 1
                            '    If sSet = -1 Then
                            '        '设定方向盘比例后（默认在游戏中方向盘图像90度时设定），调整到手机当前在的角度
                            '        TmpAngle = Angle - 90
                            '    Else
                            '        If sClearAngle = 0 Then
                            '            TmpAngle = Format(Angle - LastAngle, "0.00")
                            '            If TmpAngle.ToString.Length > 7 Then
                            '                TmpAngle = 0
                            '            End If
                            '        Else
                            '            'Angle = 0
                            '            TmpAngle = 0
                            '        End If
                            '    End If

                            '    Dim Move As Integer = Val(SingleX * TmpAngle)
                            '    XTotalMove += Move
                            '    LastAngle = Angle

                            '    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^DEBUG^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                            '    If TAmax < TmpAngle Then
                            '        TAmax = TmpAngle
                            '    End If
                            '    If TAmin > TmpAngle Then
                            '        TAmin = TmpAngle
                            '    End If

                            '    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvDEBUGvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv


                            '    'While (MouseX <> MidX)
                            '    MouseX = System.Windows.Forms.Cursor.Position.X
                            '    'End While
                            '    SetMouseXY(MouseX + Move, 980)
                            '    'For i As Integer = 1 To TmpAngle
                            '    '    SetMouseXY(MouseX + SingleX, 980)
                            '    'Next

                            '    'MousePosition = MidX + SingleX * Angle
                    End Select
                    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv方向控制vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

                Case 2  'vJoy

                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    '------------------------------使用vJoy输出控制信号--------------------------

                    '调节转向比
                    If sSet <> 0 AndAlso sSet <> TmpSet Then
                        SingleX += sSet * 0.5
                    End If
                    TmpSet = sSet

                    '调节抖动值
                    If sSetSR <> 0 AndAlso sSetSR <> TmpSetSR Then
                        ShakeRange += sSetSR * 0.01
                    End If
                    TmpSetSR = sSetSR

                    ''偏移补偿
                    'If sClearAngle <> 0 Then
                    '    WheelOffset = Angle
                    'End If

                    If Not js_update("UPDATE") Then
                        Err.Raise("向vJoy设备发送信号失败！")
                    End If

                    'vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

            End Select






        Catch ex As Exception
            Dim StackFrame As New StackFrame()
            Dim MethodBase As MethodBase = StackFrame.GetMethod()
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try

    End Sub


    Public Sub Child_ShowData(ByVal i As Integer)
        Try
            While (True)
                '键鼠模式
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), GetMouseXY, lblMousePosition)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Angle.ToString, lblSteering)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Brake.ToString, lblBrake)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Throttle.ToString, lblThrottle)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), TimsDn.ToString, lblGearDown)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), TimsUp.ToString, lblGearUp)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(TmpAngle, "0.0").ToString, lblTmpSteer)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), TAmax.ToString, lblTMax)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), TAmin.ToString, lblTMin)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), XTotalMove.ToString, lblSteerData)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), SingleX.ToString, lblSteerRatio)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), WheelOffset.ToString, lblOffset)

                'vJoy模式
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(Angle, "0.00").ToString, lblSteering)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(XTotalMove, "0.00").ToString, lblSteerData)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), tmpBrake.ToString, lblBrake)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), tmpThrottle.ToString, lblThrottle)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), sGearDn.ToString, lblGearDown)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), sGearUp.ToString, lblGearUp)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(ShakeRange, "0.00").ToString, lblShakeRange)
                Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(SingleX, "0.00").ToString, lblSteerRatio)
                'Me.Invoke(New wt_chaozuoTBox(AddressOf Main_ShowinTextBox), Format(WheelOffset, "0.00").ToString, lblOffset)

            End While
        Catch ex As Exception
            '软件关闭时会导致电脑卡死
            'Dim StackFrame As New StackFrame()
            'Dim MethodBase As MethodBase = StackFrame.GetMethod()
            'Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try

    End Sub



    'Private Function GetPort(ByVal IP As String, ByVal i As Integer) As Integer
    '    Dim TmpStr() As String

    '    GetPort = 0
    '    TmpStr = IP.Split(".")
    '    For j As Integer = 0 To TmpStr.Length - 1
    '        GetPort += Val(TmpStr(j)) * (j + i) * (TryTimes + 7) + TryTimes
    '    Next
    '    While GetPort > 10000
    '        GetPort -= TryTimes * 777
    '    End While

    'End Function
    Private Function GetPort() As Integer

        GetPort = 5050 '+ TryTimes

        While GetPort > 10000
            GetPort -= TryTimes * 777
        End While

    End Function

    Private Sub Main_ShowinListBox(ByVal TmpStr As String, ByRef LBox As ListBox)
        LBox.Items.Add(TmpStr)
        LBox.Items.Add("")
    End Sub

    Private Sub Main_ShowinTextBox(ByVal TmpStr As String, ByRef TBox As Object)
        TBox.Text = TmpStr
    End Sub
    Private Sub Main_KeyPress(ByVal TmpStr As String, ByVal Act As Integer)
        'SendKeys.Send(TmpStr)
        Try


            Select Case TmpStr
                Case "{UP}"      '油门
                    If Act = 1 Then 'Act=1 表示按下
                        keybd_event(CByte(Kup), 0, 0, 0)
                    Else            'Act=0 表示弹起
                        keybd_event(CByte(Kup), 0, KEYEVENTF_KEYUP, 0)
                    End If

                Case "{DOWN}"    '刹车
                    If Act = 1 Then
                        keybd_event(CByte(Kdn), 0, 0, 0)
                    Else
                        keybd_event(CByte(Kdn), 0, KEYEVENTF_KEYUP, 0)
                    End If

                Case "GearUp"    '升档
                    keybd_event(CByte(Keys.RControlKey), 0, 0, 0)
                    keybd_event(CByte(Keys.RControlKey), 0, KEYEVENTF_KEYUP, 0)

                Case "GearDown"  '降档
                    keybd_event(CByte(Keys.RShiftKey), 0, 0, 0)
                    keybd_event(CByte(Keys.RShiftKey), 0, KEYEVENTF_KEYUP, 0)


            End Select

        Catch ex As Exception
            Dim StackFrame As New StackFrame()
            Dim MethodBase As MethodBase = StackFrame.GetMethod()
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try


    End Sub

    Function GetMouseXY() As String
        Return System.Windows.Forms.Cursor.Position.X.ToString() & ":" & System.Windows.Forms.Cursor.Position.Y.ToString()
    End Function

    Private Sub SetMouseXY(ByVal x As Integer, ByVal y As Integer)
        System.Windows.Forms.Cursor.Position = New Point(x, y)
    End Sub


    Public WithEvents MyHook As New SystemHook()

    'Private Sub ActionMouse(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyHook.MouseActivity
    '    lblMousePosition.Text = e.Location.ToString
    'End Sub


    Private Sub btnStartSrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartSrv.Click
        Try

            If btnStartSrv.Text = "START" Then
                btnStartSrv.Text = "STOP"

                Select Case WheelType
                    Case 0   'GTA5
                        InitSingleX = 5
                        MaxX = System.Windows.SystemParameters.FullPrimaryScreenWidth
                        MidX = MaxX / 2
                        Kup = Keys.W
                        Kdn = Keys.S
                        'Case 1   '神力科莎
                        '    InitSingleX = 50
                        '    MidX = 960
                        '    XTotalMove = 0
                        '    Kup = Keys.Up
                        '    Kdn = Keys.Down
                    Case 2
                        InitSingleX = (vJoyAxisMax / WheelMaxAngle)
                        XTotalMove = 0
                        ShakeRange = 0
                        'WheelOffset = 0
                End Select

                SingleX = InitSingleX

                If WheelType = 0 OrElse WheelType = 1 Then
                    MyHook.KeyHookEnabled = True
                    MyHook.MouseHookEnabled = True
                End If


                t(1) = New Thread(AddressOf Child_WaitData) '建立新的线程
                t(1).Start(1)  '启动线程
                t(2) = New Thread(AddressOf Child_ShowData) '建立新的线程  监听鼠标位置
                t(2).Start(1)  '启动线程
            Else
                btnStartSrv.Text = "START"

                If WheelType = 0 OrElse WheelType = 1 Then
                    MyHook.KeyHookEnabled = False
                    MyHook.MouseHookEnabled = False
                End If


                s(1).Dispose()
                s(1).Close()  '关闭Socket
                t(1).Abort(1)
                t(2).Abort(1)

                TryTimes -= 1

            End If

        Catch ex As Exception
            Dim StackFrame As New StackFrame()
            Dim MethodBase As MethodBase = StackFrame.GetMethod()
            Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        End Try

    End Sub

    Private Sub Form_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If btnStartSrv.Text = "STOP" Then
                s(1).Dispose()
                s(1).Close()  '关闭Socket
                ss.Disconnect(False)
                ss.Dispose()
                ss.Close()
                t(1).Abort(1)
                t(2).Abort(1)
            End If

        Catch ex As Exception
            'Dim StackFrame As New StackFrame()
            'Dim MethodBase As MethodBase = StackFrame.GetMethod()
            'Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), MethodBase.Name & ": " & ex.Message, ListBox1)
        Finally

        End Try
    End Sub


    Private Sub btnSetSingleX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSingleX.Click
        SingleX = Val(tboxSetSingleX.Text)
        If SingleX < 0 Then SingleX = 0
    End Sub


    'Private Sub btnOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffset.Click
    '    WheelOffset = Val(tboxOffset.Text)
    'End Sub

    Private Sub btnIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIP.Click
        IPData(1).IP = tboxIP.Text
        Me.Invoke(New wt_chaozuoLBox(AddressOf Main_ShowinListBox), "请在App上输入IP地址：" & IPData(1).IP, ListBox1)
    End Sub

    Private Sub btnSetSR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSR.Click
        ShakeRange = Val(tboxSetSR.Text)
        If ShakeRange < 0 Then ShakeRange = 0
    End Sub
End Class
