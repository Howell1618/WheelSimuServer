<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSrv
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnStartSrv = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lblSteerData = New System.Windows.Forms.Label()
        Me.lblMousePosition = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblBrake = New System.Windows.Forms.Label()
        Me.lblThrottle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSteering = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblGearDown = New System.Windows.Forms.Label()
        Me.lblGearUp = New System.Windows.Forms.Label()
        Me.lblTmpSteer = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTMin = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTMax = New System.Windows.Forms.Label()
        Me.lblVersionNo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSteerRatio = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSetSingleX = New System.Windows.Forms.Button()
        Me.tboxSetSingleX = New System.Windows.Forms.TextBox()
        Me.btnOffset = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.tboxOffset = New System.Windows.Forms.TextBox()
        Me.btnIP = New System.Windows.Forms.Button()
        Me.tboxIP = New System.Windows.Forms.TextBox()
        Me.lblShakeRange = New System.Windows.Forms.Label()
        Me.tboxSetSR = New System.Windows.Forms.TextBox()
        Me.btnSetSR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStartSrv
        '
        Me.btnStartSrv.Location = New System.Drawing.Point(12, 169)
        Me.btnStartSrv.Name = "btnStartSrv"
        Me.btnStartSrv.Size = New System.Drawing.Size(225, 43)
        Me.btnStartSrv.TabIndex = 1
        Me.btnStartSrv.Text = "START"
        Me.btnStartSrv.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(240, 148)
        Me.ListBox1.TabIndex = 8
        '
        'lblSteerData
        '
        Me.lblSteerData.AutoSize = True
        Me.lblSteerData.Location = New System.Drawing.Point(439, 12)
        Me.lblSteerData.Name = "lblSteerData"
        Me.lblSteerData.Size = New System.Drawing.Size(11, 12)
        Me.lblSteerData.TabIndex = 13
        Me.lblSteerData.Text = "0"
        '
        'lblMousePosition
        '
        Me.lblMousePosition.AutoSize = True
        Me.lblMousePosition.Enabled = False
        Me.lblMousePosition.Location = New System.Drawing.Point(613, 12)
        Me.lblMousePosition.Name = "lblMousePosition"
        Me.lblMousePosition.Size = New System.Drawing.Size(23, 12)
        Me.lblMousePosition.TabIndex = 14
        Me.lblMousePosition.Text = "0:0"
        Me.lblMousePosition.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(542, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "鼠标位置："
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "油门踏板："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "刹车踏板："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "降档拨片："
        '
        'lblBrake
        '
        Me.lblBrake.AutoSize = True
        Me.lblBrake.Location = New System.Drawing.Point(329, 33)
        Me.lblBrake.Name = "lblBrake"
        Me.lblBrake.Size = New System.Drawing.Size(11, 12)
        Me.lblBrake.TabIndex = 19
        Me.lblBrake.Text = "0"
        '
        'lblThrottle
        '
        Me.lblThrottle.AutoSize = True
        Me.lblThrottle.Location = New System.Drawing.Point(439, 33)
        Me.lblThrottle.Name = "lblThrottle"
        Me.lblThrottle.Size = New System.Drawing.Size(11, 12)
        Me.lblThrottle.TabIndex = 20
        Me.lblThrottle.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(258, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "转 向 角："
        '
        'lblSteering
        '
        Me.lblSteering.AutoSize = True
        Me.lblSteering.Location = New System.Drawing.Point(329, 12)
        Me.lblSteering.Name = "lblSteering"
        Me.lblSteering.Size = New System.Drawing.Size(11, 12)
        Me.lblSteering.TabIndex = 22
        Me.lblSteering.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "升档拨片："
        '
        'lblGearDown
        '
        Me.lblGearDown.AutoSize = True
        Me.lblGearDown.Location = New System.Drawing.Point(329, 54)
        Me.lblGearDown.Name = "lblGearDown"
        Me.lblGearDown.Size = New System.Drawing.Size(11, 12)
        Me.lblGearDown.TabIndex = 24
        Me.lblGearDown.Text = "0"
        '
        'lblGearUp
        '
        Me.lblGearUp.AutoSize = True
        Me.lblGearUp.Location = New System.Drawing.Point(439, 54)
        Me.lblGearUp.Name = "lblGearUp"
        Me.lblGearUp.Size = New System.Drawing.Size(11, 12)
        Me.lblGearUp.TabIndex = 25
        Me.lblGearUp.Text = "0"
        '
        'lblTmpSteer
        '
        Me.lblTmpSteer.AutoSize = True
        Me.lblTmpSteer.Enabled = False
        Me.lblTmpSteer.Location = New System.Drawing.Point(613, 99)
        Me.lblTmpSteer.Name = "lblTmpSteer"
        Me.lblTmpSteer.Size = New System.Drawing.Size(11, 12)
        Me.lblTmpSteer.TabIndex = 26
        Me.lblTmpSteer.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "稳定转角："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(542, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "最大转角："
        Me.Label8.Visible = False
        '
        'lblTMin
        '
        Me.lblTMin.AutoSize = True
        Me.lblTMin.Enabled = False
        Me.lblTMin.Location = New System.Drawing.Point(613, 54)
        Me.lblTMin.Name = "lblTMin"
        Me.lblTMin.Size = New System.Drawing.Size(11, 12)
        Me.lblTMin.TabIndex = 29
        Me.lblTMin.Text = "0"
        Me.lblTMin.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(542, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "最小转角："
        Me.Label10.Visible = False
        '
        'lblTMax
        '
        Me.lblTMax.AutoSize = True
        Me.lblTMax.Enabled = False
        Me.lblTMax.Location = New System.Drawing.Point(613, 33)
        Me.lblTMax.Name = "lblTMax"
        Me.lblTMax.Size = New System.Drawing.Size(11, 12)
        Me.lblTMax.TabIndex = 31
        Me.lblTMax.Text = "0"
        Me.lblTMax.Visible = False
        '
        'lblVersionNo
        '
        Me.lblVersionNo.AutoSize = True
        Me.lblVersionNo.Location = New System.Drawing.Point(391, 210)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(59, 12)
        Me.lblVersionNo.TabIndex = 32
        Me.lblVersionNo.Text = "VersionNo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(368, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "转 向 比："
        '
        'lblSteerRatio
        '
        Me.lblSteerRatio.AutoSize = True
        Me.lblSteerRatio.Location = New System.Drawing.Point(439, 75)
        Me.lblSteerRatio.Name = "lblSteerRatio"
        Me.lblSteerRatio.Size = New System.Drawing.Size(11, 12)
        Me.lblSteerRatio.TabIndex = 35
        Me.lblSteerRatio.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(258, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "防抖参数："
        '
        'btnSetSingleX
        '
        Me.btnSetSingleX.Location = New System.Drawing.Point(370, 126)
        Me.btnSetSingleX.Name = "btnSetSingleX"
        Me.btnSetSingleX.Size = New System.Drawing.Size(80, 33)
        Me.btnSetSingleX.TabIndex = 37
        Me.btnSetSingleX.Text = "设定转向比"
        Me.btnSetSingleX.UseVisualStyleBackColor = True
        '
        'tboxSetSingleX
        '
        Me.tboxSetSingleX.Location = New System.Drawing.Point(370, 99)
        Me.tboxSetSingleX.Name = "tboxSetSingleX"
        Me.tboxSetSingleX.Size = New System.Drawing.Size(80, 21)
        Me.tboxSetSingleX.TabIndex = 38
        Me.tboxSetSingleX.Text = "15"
        Me.tboxSetSingleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOffset
        '
        Me.btnOffset.Enabled = False
        Me.btnOffset.Location = New System.Drawing.Point(643, 44)
        Me.btnOffset.Name = "btnOffset"
        Me.btnOffset.Size = New System.Drawing.Size(80, 33)
        Me.btnOffset.TabIndex = 39
        Me.btnOffset.Text = "偏移补偿"
        Me.btnOffset.UseVisualStyleBackColor = True
        Me.btnOffset.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(542, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "偏移补偿："
        Me.Label11.Visible = False
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Enabled = False
        Me.lblOffset.Location = New System.Drawing.Point(613, 75)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(11, 12)
        Me.lblOffset.TabIndex = 41
        Me.lblOffset.Text = "0"
        Me.lblOffset.Visible = False
        '
        'tboxOffset
        '
        Me.tboxOffset.Enabled = False
        Me.tboxOffset.Location = New System.Drawing.Point(643, 17)
        Me.tboxOffset.Name = "tboxOffset"
        Me.tboxOffset.Size = New System.Drawing.Size(80, 21)
        Me.tboxOffset.TabIndex = 42
        Me.tboxOffset.Text = "0"
        Me.tboxOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tboxOffset.Visible = False
        '
        'btnIP
        '
        Me.btnIP.Location = New System.Drawing.Point(370, 169)
        Me.btnIP.Name = "btnIP"
        Me.btnIP.Size = New System.Drawing.Size(80, 33)
        Me.btnIP.TabIndex = 43
        Me.btnIP.Text = "更改IP地址"
        Me.btnIP.UseVisualStyleBackColor = True
        '
        'tboxIP
        '
        Me.tboxIP.Location = New System.Drawing.Point(260, 176)
        Me.tboxIP.Name = "tboxIP"
        Me.tboxIP.Size = New System.Drawing.Size(104, 21)
        Me.tboxIP.TabIndex = 44
        Me.tboxIP.Text = "192.168.1.111"
        Me.tboxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblShakeRange
        '
        Me.lblShakeRange.AutoSize = True
        Me.lblShakeRange.Location = New System.Drawing.Point(329, 75)
        Me.lblShakeRange.Name = "lblShakeRange"
        Me.lblShakeRange.Size = New System.Drawing.Size(11, 12)
        Me.lblShakeRange.TabIndex = 45
        Me.lblShakeRange.Text = "0"
        '
        'tboxSetSR
        '
        Me.tboxSetSR.Location = New System.Drawing.Point(260, 99)
        Me.tboxSetSR.Name = "tboxSetSR"
        Me.tboxSetSR.Size = New System.Drawing.Size(80, 21)
        Me.tboxSetSR.TabIndex = 47
        Me.tboxSetSR.Text = "0.5"
        Me.tboxSetSR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSetSR
        '
        Me.btnSetSR.Location = New System.Drawing.Point(260, 126)
        Me.btnSetSR.Name = "btnSetSR"
        Me.btnSetSR.Size = New System.Drawing.Size(80, 33)
        Me.btnSetSR.TabIndex = 46
        Me.btnSetSR.Text = "设定防抖值"
        Me.btnSetSR.UseVisualStyleBackColor = True
        '
        'frmSrv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 224)
        Me.Controls.Add(Me.tboxSetSR)
        Me.Controls.Add(Me.btnSetSR)
        Me.Controls.Add(Me.lblShakeRange)
        Me.Controls.Add(Me.tboxIP)
        Me.Controls.Add(Me.btnIP)
        Me.Controls.Add(Me.tboxOffset)
        Me.Controls.Add(Me.lblOffset)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnOffset)
        Me.Controls.Add(Me.tboxSetSingleX)
        Me.Controls.Add(Me.btnSetSingleX)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblSteerRatio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblVersionNo)
        Me.Controls.Add(Me.lblTMax)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblTMin)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTmpSteer)
        Me.Controls.Add(Me.lblGearUp)
        Me.Controls.Add(Me.lblGearDown)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSteering)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblThrottle)
        Me.Controls.Add(Me.lblBrake)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMousePosition)
        Me.Controls.Add(Me.lblSteerData)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnStartSrv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSrv"
        Me.Text = "WheelSimuServer"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStartSrv As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lblSteerData As System.Windows.Forms.Label
    Friend WithEvents lblMousePosition As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblBrake As System.Windows.Forms.Label
    Friend WithEvents lblThrottle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSteering As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGearDown As System.Windows.Forms.Label
    Friend WithEvents lblGearUp As System.Windows.Forms.Label
    Friend WithEvents lblTmpSteer As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTMin As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblTMax As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSteerRatio As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnSetSingleX As System.Windows.Forms.Button
    Friend WithEvents tboxSetSingleX As System.Windows.Forms.TextBox
    Friend WithEvents btnOffset As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblOffset As System.Windows.Forms.Label
    Friend WithEvents tboxOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnIP As System.Windows.Forms.Button
    Friend WithEvents tboxIP As System.Windows.Forms.TextBox
    Friend WithEvents lblShakeRange As System.Windows.Forms.Label
    Friend WithEvents tboxSetSR As System.Windows.Forms.TextBox
    Friend WithEvents btnSetSR As System.Windows.Forms.Button

End Class
