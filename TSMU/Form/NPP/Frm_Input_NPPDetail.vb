Imports DevExpress.XtraGrid

Public Class Frm_Input_NPPDetail



    Dim fc_Class As New Cls_NPP_Detail
    Dim fc_ClassNPWO As New Cls_Npwo_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Nama As String
    Dim Machine As String
    Dim CT As String
    Dim Cav As String
    Dim Weight As String
    Dim Material As String
    Dim Inj As Boolean
    Dim Pnt As Boolean
    Dim Chrome As Boolean
    Dim Assy As Boolean
    Dim Ultrasonic As Boolean
    Dim Vibration As Boolean
    Dim StatusMold As String
    Dim OrderMonth As String
    Dim Grid As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean
    Dim DtTabale As DataTable
    Dim order As Double
    Dim NoNPP As String


    Dim dtB As DataTable
    Dim BS As New BindingSource

    Dim RowsAwal As Integer


    Public Sub New(ByVal _ID As String,
                   ByVal _Nama As String,
                   ByVal _Machine As String,
                   ByVal _CycleTime As String,
                   ByVal _Cav As String,
                   ByVal _Weight As String,
                   ByVal _Material As String,
                   ByVal _Inj As Boolean,
                   ByVal _Paint As Boolean,
                   ByVal _Chrome As Boolean,
                   ByVal _Assy As Boolean,
                   ByVal _Ultrasonic As Boolean,
                   ByVal _Vibration As Boolean,
                   ByVal _StatusMold As String,
                   ByVal _OrderMonth As String,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As GridControl,
                   ByVal _Order As Double,
                   ByVal _NoNpp As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        ID = _ID
        Nama = _Nama
        Machine = _Machine
        CT = _CycleTime
        Cav = _Cav
        Weight = _Weight
        Material = _Material
        Inj = _Inj
        Pnt = _Paint
        Chrome = _Chrome
        Assy = _Assy
        Ultrasonic = _Ultrasonic
        Vibration = _Vibration
        StatusMold = _StatusMold
        OrderMonth = _OrderMonth
        Grid = _grid
        IsNew = _IsNew
        DtTabale = _dt
        order = _Order
        NoNPP = _NoNpp

    End Sub



    Private Sub Frm_Input_NpwoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Me.TOrder.Properties.Mask.EditMask = "n0"
        Me.TOrder.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

        If IsNew Then
            TPartNo.EditValue = ""
            TPartName.EditValue = ""
            TWeight.EditValue = "0"
            TMaterial.EditValue = ""
            TStatusMold.EditValue = ""
            TOrder.EditValue = order
            TCt.EditValue = "0"

            BNext.Enabled = False
            BPrev.Enabled = False
            BindingNavigator1.Enabled = False

        Else
            BAdd.Text = "Update"
            ' Dim dtB As DataTable
            dtB = fc_Class.Get_Detail_NPP(NoNPP)
            ' Dim BS As New BindingSource
            BS.DataSource = dtB

            TPartNo.DataBindings.Add(New Binding("text", BS, "Part No"))
            TPartName.DataBindings.Add(New Binding("text", BS, "Part Name"))
            TWeight.DataBindings.Add(New Binding("text", BS, "Weight"))
            TMaterial.DataBindings.Add(New Binding("text", BS, "Material"))
            'tqt.DataBindings.Add(New Binding("text", BS, "Qty Mold"))
            TOrder.DataBindings.Add(New Binding("text", BS, "Order Month"))
            TMachine.DataBindings.Add(New Binding("text", BS, "Machine"))
            TCt.DataBindings.Add(New Binding("text", BS, "C/T"))
            TCav.DataBindings.Add(New Binding("text", BS, "Cav"))
            TStatusMold.DataBindings.Add(New Binding("text", BS, "Status Mold"))

            CInjection.DataBindings.Add(New Binding("Checked", BS, "Inj"))
            CPainting.DataBindings.Add(New Binding("Checked", BS, "Painting"))
            CChrome.DataBindings.Add(New Binding("Checked", BS, "Chrome"))
            CAssy.DataBindings.Add(New Binding("Checked", BS, "Assy"))
            CUltrasonic.DataBindings.Add(New Binding("Checked", BS, "Ultrasonic"))
            CbVibration.DataBindings.Add(New Binding("Checked", BS, "Vibration"))
            TID.DataBindings.Add(New Binding("text", BS, "ID"))


            'TCt.DataBindings.Add(New Binding("text", BS, "Part Name"))
            'TCt.DataBindings.Add(New Binding("text", BS, "Part Name"))
            'TCt.DataBindings.Add(New Binding("text", BS, "Part Name"))
            'TCt.DataBindings.Add(New Binding("text", BS, "Part Name"))



            BindingNavigator1.BindingSource = BS


            'BindingNavigator1.BindingSource.DataSource = dt

            'TPartNo.Enabled = False
            'TPartNo.EditValue = ID
            'TPartName.EditValue = Nama
            'TWeight.EditValue = Weight
            'TMaterial.EditValue = Material
            'TStatusMold.EditValue = StatusMold
            'TOrder.EditValue = OrderMonth
            'TMachine.EditValue = Machine
            'TCt.EditValue = CT
            'TCav.EditValue = Cav


            'CInjection.Checked = Inj
            'CPainting.Checked = Pnt
            'CChrome.Checked = Chrome
            'CAssy.Checked = Assy
            'CUltrasonic.Checked = Ultrasonic
            'CbVibration.Checked = Vibration
            'TOrder.EditValue = order





        End If


        RowsAwal = DtTabale.Rows.Count



    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click


        If IsNew = True Then

            If TPartNo.Text = "" Then
                MessageBox.Show("Please Fill Part No",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1)
            ElseIf TWeight.Text = "" Then
                MessageBox.Show("Weight Must be Number",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1)
            ElseIf TOrder.Text = "" Then
                MessageBox.Show("Order Must be Number",
                                     "Warning",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation,
                                     MessageBoxDefaultButton.Button1)
            ElseIf TCt.Text = "" Then
                MessageBox.Show("Cycle Time  Must be Number",
                                     "Warning",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation,
                                     MessageBoxDefaultButton.Button1)
            Else

                For i As Integer = 0 To DtTabale.Rows.Count - 1
                    If TPartNo.EditValue.Trim = DtTabale.Rows(i).Item("Part No") Then
                        MessageBox.Show("" & TPartNo.Text & " Already exists",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next

                Dim dt As New DataTable
                dt = fc_ClassNPWO.Cek_PartNo_Detail_NPP(TPartNo.EditValue)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("" & TPartNo.Text & " Already exists",
                                       "Warning",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation,
                                       MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If
                Dim GroupID As String = fc_Class.GetGroupIDAuto(DtTabale.Rows.Count, RowsAwal)
                Dim MyNewRow As DataRow
                MyNewRow = DtTabale.NewRow
                With MyNewRow
                    .Item("Part No") = TPartNo.Text.Trim
                    .Item("Part Name") = TPartName.Text.Trim
                    .Item("Machine") = TMachine.Text.Trim
                    .Item("C/T") = TCt.Text.Trim
                    .Item("Cav") = TCav.Text.Trim
                    .Item("Weight") = TWeight.Text.Trim
                    .Item("Material") = TMaterial.Text.Trim
                    .Item("Inj") = CInjection.CheckState
                    .Item("Painting") = CPainting.CheckState
                    .Item("Chrome") = CChrome.CheckState
                    .Item("Assy") = CAssy.CheckState
                    .Item("Ultrasonic") = CUltrasonic.CheckState
                    .Item("Vibration") = CbVibration.CheckState
                    .Item("Status Mold") = TStatusMold.Text.Trim
                    .Item("Order Month") = TOrder.EditValue
                    .Item("Group ID") = GroupID

                End With


                DtTabale.Rows.Add(MyNewRow)
                DtTabale.AcceptChanges()
                TPartNo.EditValue = ""
                TPartName.EditValue = ""
                TWeight.EditValue = "0"
                TMaterial.EditValue = ""
                TStatusMold.EditValue = ""
                TMachine.EditValue = ""
                TCav.EditValue = ""
                CAssy.Checked = False
                CbVibration.Checked = False
                CPainting.Checked = False
                CAssy.Checked = False
                CChrome.Checked = False
                CInjection.Checked = False

            End If


        Else

            For i As Integer = 0 To DtTabale.Rows.Count - 1
                If TID.EditValue.Trim = DtTabale.Rows(i).Item("ID") Then
                    With DtTabale.Rows(i)
                        .Item("Part No") = TPartNo.EditValue.Trim
                        .Item("Part Name") = TPartName.EditValue.Trim
                        .Item("Weight") = TWeight.EditValue.Trim
                        .Item("Material") = TMaterial.EditValue.Trim
                        .Item("Status Mold") = TStatusMold.EditValue.Trim
                        .Item("Order Month") = TOrder.EditValue.Trim
                        .Item("Inj") = CInjection.CheckState
                        .Item("Painting") = CPainting.CheckState
                        .Item("Chrome") = CChrome.CheckState
                        .Item("Assy") = CAssy.CheckState
                        .Item("Ultrasonic") = CUltrasonic.CheckState
                        .Item("Vibration") = CbVibration.CheckState
                        .Item("C/T") = TCt.EditValue
                        .Item("Cav") = TCav.EditValue
                        .Item("Machine") = TMachine.EditValue
                    End With

                End If
            Next


        End If


    End Sub


    Private Sub TWeight_KeyPress(sender As Object, e As KeyPressEventArgs)

        'Dim tombol As Integer
        'tombol = Asc(e.KeyChar)

        'If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub TQtyMold_KeyPress(sender As Object, e As KeyPressEventArgs)

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If

    End Sub



    Private Sub TForecast_KeyPress(sender As Object, e As KeyPressEventArgs)

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOrder.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 46)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TMachine_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TStatusMold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TStatusMold.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BFinish_Click(sender As Object, e As EventArgs) Handles BFinish.Click
        Me.Close()
    End Sub

    Private Sub TPartNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPartNo.KeyPress

        'e.KeyChar = e.KeyChar.ToUpper(e.KeyChar)
        e.KeyChar = Char.ToUpper(e.KeyChar)

    End Sub

    Private Sub TPartNo_EditValueChanged(sender As Object, e As EventArgs) Handles TPartNo.EditValueChanged



    End Sub

    Private Sub TPartName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPartName.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMaterial.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TCav_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCav.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub



    Private Sub BNext_Click(sender As Object, e As EventArgs) Handles BNext.Click

        BindingNavigator1.BindingSource.MoveNext()

    End Sub

    Private Sub BPrev_Click(sender As Object, e As EventArgs) Handles BPrev.Click

        BindingNavigator1.BindingSource.MovePrevious()

    End Sub

    Private Sub TCt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCt.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TWeight_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TWeight.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub
End Class