Module ThreadHelperClass
    Delegate Sub SetTextCallback(ByVal f As Form, ByVal ctrl As Control, ByVal text As String)
    Sub SetText(ByVal form As Form, ByVal ctrl As Control, ByVal text As String)
        If ctrl.InvokeRequired Then
            Dim d As SetTextCallback = New SetTextCallback(AddressOf SetText)
            form.Invoke(d, New Object() {form, ctrl, text})
        Else
            ctrl.Text = text
        End If
    End Sub

    Delegate Sub SetCellTextDelegate(ByVal control As DataGridView, ByVal x As Integer, ByVal y As Integer, ByVal text As String)

    Sub SetCellText(ByVal control As DataGridView, ByVal x As Integer, ByVal y As Integer, ByVal text As String)
        If control.InvokeRequired Then
            Dim d As SetCellTextDelegate = New SetCellTextDelegate(AddressOf SetCellText)
            control.Invoke(d, New Object() {control, x, y, text})
        Else
            control(x, y).Value = text
        End If
    End Sub

    Delegate Sub SetTextStringDelegate(ByVal f As Form, ByVal text1 As String, ByVal text As String)

    Sub SetTextString(ByVal form As Form, ByVal text1 As String, ByVal text As String)
        If form.InvokeRequired Then
            Dim d As SetTextStringDelegate = New SetTextStringDelegate(AddressOf SetTextString)
            form.Invoke(d, New Object() {form, text1, text})
        Else
            text1 = text
        End If
    End Sub

    Delegate Sub SetTextStringDelegate1(ByVal c As Control, ByVal text1 As String, ByVal c As ComboBox)

    Sub SetTextString1(ByVal ctl1 As Control, ByVal text1 As String, ByVal ctl As ComboBox)
        If ctl1.InvokeRequired Then
            Dim d As SetTextStringDelegate1 = New SetTextStringDelegate1(AddressOf SetTextString1)
            ctl1.Invoke(d, New Object() {ctl1, text1, ctl})
        Else
            text1 = ctl.Text
        End If
    End Sub

    Delegate Sub SetBoolDelegate(ByVal f As Form, ByVal bol1 As Boolean, ByVal bol2 As Boolean)

    Sub SetBool(ByVal form As Form, ByVal bol1 As Boolean, ByVal bol2 As Boolean)
        If form.InvokeRequired Then
            Dim d As SetBoolDelegate = New SetBoolDelegate(AddressOf SetBool)
            form.Invoke(d, New Object() {form, bol1, bol2})
        Else
            bol1 = bol2
        End If
    End Sub

    Delegate Sub SetBoolCtlDelegate(ByVal f As Form, ByVal ctl As Control, ByVal bol As Boolean)

    Sub SetCtlBool(ByVal form As Form, ByVal ctl As Control, ByVal bol As Boolean)
        If form.InvokeRequired Then
            Dim d As SetBoolCtlDelegate = New SetBoolCtlDelegate(AddressOf SetCtlBool)
            form.Invoke(d, New Object() {form, ctl, bol})
        Else
            ctl.Enabled = bol
        End If
    End Sub
End Module
