Imports DevExpress.XtraGrid
Public Class Frm_Input_NpwoDetail

    Dim fc_Class As New Cls_Npwo_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Nama As String
    Dim Machine As String
    Dim CycleTime As String
    Dim Cav As String
    Dim Weight As String
    Dim QtyMold As String
    Dim Material As String
    Dim LOI As String
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
    Dim DtDetail As DataTable
    Dim H_Order As String

    Private Sub Frm_Input_NpwoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        If IsNew Then
            TPartNo.EditValue = ""
            TPartName.EditValue = ""
            TMachine.EditValue = ""
            TCT.EditValue = "0"
            TCav.EditValue = ""
            TWeight.EditValue = "0"
            TQtyMold.EditValue = "0"
            TMaterial.EditValue = ""
            CInjection.Checked = False
            CPainting.Checked = False
            CChrome.Checked = False
            CAssy.Checked = False
            CUltrasonic.Checked = False
            CbVibration.Checked = False
            TStatusMold.EditValue = ""
            TOrder.EditValue = "0"
        Else
            TPartNo.Enabled = False
            TPartNo.EditValue = ID
            TPartName.EditValue = Nama
            TMachine.EditValue = Machine
            TCT.EditValue = CycleTime
            TCav.EditValue = Cav
            TWeight.EditValue = Weight
            TQtyMold.EditValue = QtyMold
            TMaterial.EditValue = Material
            TStatusMold.EditValue = StatusMold
            TOrder.EditValue = OrderMonth

            CInjection.Checked = Inj
            CPainting.Checked = Pnt
            CChrome.Checked = Chrome
            CAssy.Checked = Assy
            CUltrasonic.Checked = Ultrasonic
            CbVibration.Checked = Vibration
        End If

    End Sub

    Public Sub New(ByVal _ID As String,
                   ByVal _Nama As String,
                   ByVal _Machine As String,
                   ByVal _CycleTime As String,
                   ByVal _Cav As String,
                   ByVal _Weight As String,
                   ByVal _QtyMold As String,
                   ByVal _Material As String,
                   ByVal _Inj As Boolean,
                   ByVal _Paint As Boolean,
                   ByVal _Chrome As Boolean,
                   ByVal _Assy As Boolean,
                   ByVal _Ultrasonic As Boolean,
                   ByVal _Vibration As Boolean,
                   ByVal _StatusMold As String,
                   ByVal _OrderMonth As String,
                   ByVal _Type As String,
                   ByVal _LOI As String,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _dtDetail As DataTable,
                   ByRef _grid As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        ID = _ID
        Nama = _Nama
        Machine = _Machine
        CycleTime = _CycleTime
        Cav = _Cav
        Weight = _Weight
        QtyMold = _QtyMold
        Material = _Material
        StatusMold = _StatusMold
        LOI =
        Inj = _Inj
        Pnt = _Paint
        Chrome = _Chrome
        Assy = _Assy
        Ultrasonic = _Ultrasonic
        Vibration = _Vibration
        StatusMold = _StatusMold
        OrderMonth = _OrderMonth
        IsNew = _IsNew
        Grid = _grid
        DtTabale = _dt
        DtDetail = _dtDetail

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If IsNew = True Then

            Dim GroupID As String = fc_Class.GetGroupIDAuto(DtTabale.Rows.Count)

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
            ElseIf TType.Text = "" Then
                MessageBox.Show("Please Select Type",
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
                dt = fc_Class.Cek_PartNo_Detail_Npwo(TPartNo.EditValue)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("" & TPartNo.Text & " Already exists",
                                       "Warning",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation,
                                       MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If

                Dim MyNewRow As DataRow
                MyNewRow = DtTabale.NewRow
                With MyNewRow
                    .Item("Part No") = TPartNo.Text.Trim
                    .Item("Part Name") = TPartName.Text.Trim
                    .Item("Machine") = TMachine.Text.Trim
                    .Item("C/T") = TCT.Text.Trim
                    .Item("Cav") = TCav.Text.Trim
                    .Item("Weight") = TWeight.Text.Trim
                    .Item("Qty Mold") = TQtyMold.Text.Trim
                    .Item("Material") = TMaterial.Text.Trim
                    .Item("Inj") = CInjection.CheckState
                    .Item("Painting") = CPainting.CheckState
                    .Item("Chrome") = CChrome.CheckState
                    .Item("Assy") = CAssy.CheckState
                    .Item("Ultrasonic") = CAssy.CheckState
                    .Item("Vibration") = CbVibration.CheckState
                    .Item("Status Mold") = TStatusMold.Text.Trim
                    .Item("Order Month") = TOrder.Text.Trim
                    .Item("LOI") = TLOI.Text.Trim
                    .Item("Group ID") = GroupID
                    .Item("Type") = TType.Text.Trim

                End With


                DtTabale.Rows.Add(MyNewRow)
                DtTabale.AcceptChanges()

                Dim MyNewRowDetail As DataRow
                MyNewRowDetail = DtDetail.NewRow
                With MyNewRowDetail
                    .Item("Part No") = TPartNo.Text.Trim
                    .Item("Part Name") = TPartName.Text.Trim
                    .Item("Machine") = TMachine.Text.Trim
                    .Item("C/T") = TCT.Text.Trim
                    .Item("Cav") = TCav.Text.Trim
                    .Item("Weight") = TWeight.Text.Trim
                    .Item("Qty Mold") = TQtyMold.Text.Trim
                    .Item("Material") = TMaterial.Text.Trim
                    .Item("Inj") = CInjection.CheckState
                    .Item("Painting") = CPainting.CheckState
                    .Item("Chrome") = CChrome.CheckState
                    .Item("Assy") = CAssy.CheckState
                    .Item("Ultrasonic") = CAssy.CheckState
                    .Item("Vibration") = CbVibration.CheckState
                    .Item("Status Mold") = TStatusMold.Text.Trim
                    .Item("Order Month") = TOrder.Text.Trim
                    .Item("LOI") = TLOI.Text.Trim
                    .Item("Group ID") = GroupID
                    If TType.EditValue = "MOLD" Then
                        .Item("Type") = "PROCESS"
                        .Item("Type1") = "MOLD"
                    ElseIf TType.EditValue = "PROCESS" Then
                        .Item("Type") = "PROCESS"
                        .Item("Type1") = "PROCESS"
                    End If


                End With


                DtDetail.Rows.Add(MyNewRowDetail)
                DtDetail.AcceptChanges()

                TPartNo.EditValue = ""
                TPartName.EditValue = ""
                TMachine.EditValue = ""
                TCT.EditValue = "0"
                TCav.EditValue = ""
                TWeight.EditValue = "0"
                TQtyMold.EditValue = "0"
                TMaterial.EditValue = ""
                CInjection.Checked = False
                CPainting.Checked = False
                CChrome.Checked = False
                CAssy.Checked = False
                CUltrasonic.Checked = False
                CbVibration.Checked = False
                TStatusMold.EditValue = ""
                TOrder.EditValue = "0"
                TType.EditValue = ""

            End If


        Else

            For i As Integer = 0 To DtTabale.Rows.Count - 1
                If TPartNo.EditValue.Trim = DtTabale.Rows(i).Item("Part No") Then
                    With DtTabale.Rows(i)
                        .Item("Part Name") = TPartName.Text.Trim
                        .Item("Machine") = TMachine.Text.Trim
                        .Item("C/T") = TCT.Text.Trim
                        .Item("Cav") = TCav.Text.Trim
                        .Item("Weight") = TWeight.Text.Trim
                        .Item("Qty Mold") = TQtyMold.Text.Trim
                        .Item("Material") = TMaterial.Text.Trim
                        .Item("Inj") = CInjection.CheckState
                        .Item("Painting") = CPainting.CheckState
                        .Item("Chrome") = CChrome.CheckState
                        .Item("Assy") = CAssy.CheckState
                        .Item("Ultrasonic") = CAssy.CheckState
                        .Item("Vibration") = CbVibration.CheckState
                        .Item("Status Mold") = TStatusMold.Text.Trim
                        .Item("Order Month") = TOrder.Text.Trim
                        .Item("LOI") = TLOI.Text.Trim
                        '.Item("Group ID") =GroupID
                    End With

                End If
            Next


        End If

    End Sub

    Private Sub TCT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCT.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TWeight.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TQtyMold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TQtyMold.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOrder.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TPartNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPartNo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TPartName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPartName.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TMachine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMachine.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TCav_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCav.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TMaterial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMaterial.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub TLOI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TLOI.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub BFinish_Click(sender As Object, e As EventArgs) Handles BFinish.Click
        Me.Close()
    End Sub
End Class