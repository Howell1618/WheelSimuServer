Public Module CommonCode

    Public Sub Sleep(ByVal Interval)
        Dim __time As DateTime = DateTime.Now
        Dim __Span As Int64 = Interval * 10000 '因为时间是以100纳秒为单位。
        While (DateTime.Now.Ticks - __time.Ticks < __Span)
            Application.DoEvents()
        End While
    End Sub


End Module
