Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_NPP_Detail

    Dim CForm As Integer = 0

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New Cls_NPP_Detail
    Dim fc_Class_Head As New Cls_NPP_Header
    Dim NPP_Detail As New Col_Cls_NPP_Detail_NPP
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Dept As String
    Dim DeptSub As String = ""

    Dim DtGridNPWO As DataTable
    Dim DtGridPayment As DataTable

    Dim frmInput As Frm_Input_NPPDetail
    Dim frmSetGroup As Frm_NPP_Set_Grup
    Dim frmPrepare As Frm_NPP_Prepare


    Dim dt As New DataTable
    Dim DtDelete As New DataTable
    Dim dtApprove As New DataTable

    Dim FrmReport As ReportNPWO

    Dim NoSirkulasi As String = ""

    Public Property Test As String = "t"

    Private Sub Frm_Npwo_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call CreateTableBarang()
        Call FillComboCustomer()
        Call FillComboCategory()

        'Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

        Me.TOrderMonth.Properties.Mask.EditMask = "n0"
        Me.TOrderMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

        Me.TOrderMaxMonth.Properties.Mask.EditMask = "n0"
        Me.TOrderMaxMonth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

    End Sub

    Private Sub FillComboCustomer()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetCustomer
            TCustomer.Properties.DataSource = Nothing
            TCustomer.Properties.DataSource = dt
            TCustomer.Properties.ValueMember = "Value"
            TCustomer.Properties.DisplayMember = "Value"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub FillComboCategory()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetCategory
            TCategory.Properties.DataSource = Nothing
            TCategory.Properties.DataSource = dt
            TCategory.Properties.ValueMember = "Value"
            TCategory.Properties.DisplayMember = "Value"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CreateTableBarang()

        DtGridNPWO = New DataTable
        DtGridNPWO.Columns.AddRange(New DataColumn(19) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("C/T", GetType(String)),
                                                           New DataColumn("Cav", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Qty Mold", GetType(Int32)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("Forecast", GetType(String)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Single", GetType(Boolean)),
                                                           New DataColumn("Group ID", GetType(String)),
                                                           New DataColumn("ID", GetType(Integer)),
                                                           New DataColumn("Order Month", GetType(Int32))})
        Grid.DataSource = DtGridNPWO
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.GetDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If

                Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, True)
                TNPP_No.Enabled = False
                TCustomer.Enabled = False
                TModel.Enabled = False
                Me.Text = "NPP FORM -> " & fs_Code
            Else
                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)

                Me.Text = "NPP FORM "
            End If

            Call LoadTxtBox()
            Call LoadGrid(fc_Class.H_No_NPP)

            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGrid(NPP_ As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                'Dim DtGridNPWO As New DataTable
                DtGridNPWO = fc_Class.Get_Detail_NPP(NPP_)
                Grid.DataSource = DtGridNPWO
                Cursor.Current = Cursors.Default
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub B_AddRows_Click(sender As Object, e As EventArgs) Handles B_AddRows.Click

        If TOrderMonth.Text = "" Then
            MessageBox.Show("Please Fill Order Month",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            CallForm()
        End If


    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TNPP_No.EditValue = .H_No_NPP
                    TCustomer.EditValue = .H_Customer_Name
                    TModel.EditValue = .H_Model_Name
                    TModelDesc.EditValue = .H_Model_Description
                    TOrderMonth.EditValue = .H_Order_Month
                    TOrderMaxMonth.EditValue = .H_Order_Max_Month
                    TMp.EditValue = .H_MP
                    CBCad.Checked = .H_CAD_Data
                    CBDrawing.Checked = .H_Drawing
                    CBSample.Checked = .H_Sample
                    CBStr.Checked = .H_Special_Technical_Requires
                    CBTng.Checked = .H_Factory_Tsc_TNG
                    CBCkr.Checked = .H_Factory_Tsc_CKR
                    TCategory.EditValue = .H_Category_Class
                    TTargetDr.EditValue = .H_TargetDRR
                    TTargetQuot.EditValue = .H_TargetQuot
                End With

                If fc_Class.H_Approve = True Then
                    TRevisi.EditValue = fc_Class.H_Rev + 1
                Else
                    TRevisi.EditValue = fc_Class.H_Rev
                End If
                TRevisiInformasi.EditValue = ""
            Else
                TRevisi.EditValue = "0"
                TRevisiInformasi.EditValue = "New Model"
                BSetGroup.Enabled = False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            Dim DR As Date = CDate(TTargetDr.EditValue)
            Dim QUOT As Date = CDate(TTargetQuot.EditValue)

            If TNPP_No.EditValue = "" Then
                MessageBox.Show("Please Choose Customer and Model", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf TCustomer.EditValue = "" Then
                MessageBox.Show("Please Choose Customer Name", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf TModel.EditValue = "" Then
                MessageBox.Show("Please fill Model Name", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf TOrderMonth.Text = "" Then
                MessageBox.Show("Order Month Must Be Number", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf TOrderMaxMonth.Text = "" Then
                MessageBox.Show("Order Max Month Must Be Number", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf TCategory.EditValue = "" Then
                MessageBox.Show("Please fill Category", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf TMp.EditValue = "" Then
                MessageBox.Show("Please fill MP", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf TTargetDr.Text = "" Then
                MessageBox.Show("Please fill Target DR", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf TTargetQuot.Text = "" Then
                MessageBox.Show("Please fill Quotation Target", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf DR > QUOT Then
                MessageBox.Show("Please Check DR Target and Quotatio Target", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            Else

                lb_Validated = True
            End If

            If lb_Validated Then
                With fc_Class
                    If isUpdate = False Then
                        '.ValidateInsert()
                    End If
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Please Fill Part Information ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub

            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty Of Description of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


            End If

            If isUpdate = False Then

                dtApprove = New DataTable
                dtApprove = fc_Class.GetApprove


                With fc_Class

                    .H_No_NPP = TNPP_No.EditValue
                    .H_Model_Name = TModel.EditValue
                    .H_Model_Description = TModelDesc.EditValue
                    .H_Customer_Name = TCustomer.EditValue
                    .H_Order_Month = TOrderMonth.EditValue
                    .H_Order_Max_Month = TOrderMaxMonth.EditValue
                    .H_MP = TMp.EditValue
                    .H_Drawing = CBDrawing.CheckState
                    .H_CAD_Data = CBCad.CheckState
                    .H_Sample = CBSample.CheckState
                    .H_Special_Technical_Requires = CBStr.CheckState
                    .H_Category_Class = TCategory.EditValue
                    .H_Factory_Tsc_TNG = CBTng.CheckState
                    .H_Factory_Tsc_CKR = CBCkr.CheckState
                    .H_Rev = 0
                    .H_RevInformasi = TRevisiInformasi.EditValue
                    .H_TargetDRR = TTargetDr.EditValue
                    .H_TargetQuot = TTargetQuot.EditValue
                    .H_Checked = dtApprove.Rows(0).Item("Checked")
                    .H_A1 = dtApprove.Rows(0).Item("A1")
                    .H_A2 = dtApprove.Rows(0).Item("A2")
                    .H_A3 = dtApprove.Rows(0).Item("A3")
                    .H_A4 = dtApprove.Rows(0).Item("A4")

                End With
                'Insert To ObjDetailMaterial
                fc_Class.Collection_Detail.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    NPP_Detail = New Col_Cls_NPP_Detail_NPP
                    With NPP_Detail

                        .No_Npwo = TNPP_No.EditValue
                        .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                        .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                        .Cycle_Time = Convert.ToString(GridView1.GetRowCellValue(i, "C/T"))
                        .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                        .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                        .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                        .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                        .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                        .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                        .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                        .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                        .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                        .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                        .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                        .MoldNumber = Convert.ToString(GridView1.GetRowCellValue(i, "Group ID"))

                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail.Add(NPP_Detail)

                Next

                fc_Class.Insert(fc_Class.H_No_NPP)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class_Head.Get_NPP()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            Else

                If fc_Class.H_Approve = False Then

                    With fc_Class

                        .H_No_NPP = TNPP_No.EditValue
                        .H_Model_Name = TModel.EditValue
                        .H_Model_Description = TModelDesc.EditValue
                        .H_Customer_Name = TCustomer.EditValue
                        .H_Order_Month = TOrderMonth.EditValue
                        .H_Order_Max_Month = TOrderMaxMonth.EditValue
                        .H_MP = TMp.EditValue
                        .H_Drawing = CBDrawing.CheckState
                        .H_CAD_Data = CBCad.CheckState
                        .H_Sample = CBSample.CheckState
                        .H_Special_Technical_Requires = CBStr.CheckState
                        .H_Category_Class = TCategory.EditValue
                        .H_Factory_Tsc_TNG = CBTng.CheckState
                        .H_Factory_Tsc_CKR = CBCkr.CheckState
                        .H_Rev = TRevisi.EditValue
                        .H_RevInformasi = TRevisiInformasi.EditValue
                        .H_TargetDRR = TTargetDr.EditValue
                        .H_TargetQuot = TTargetQuot.EditValue

                        .H_RevInformasi = TRevisiInformasi.EditValue

                    End With

                    'Insert To ObjDetailMaterial
                    fc_Class.Collection_Detail.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1

                        NPP_Detail = New Col_Cls_NPP_Detail_NPP
                        With NPP_Detail

                            .No_Npwo = TNPP_No.EditValue
                            .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                            .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                            .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                            .Cycle_Time = Convert.ToString(GridView1.GetRowCellValue(i, "C/T"))
                            .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                            .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                            .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                            .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                            .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                            .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                            .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                            .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                            .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                            .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                            .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                            .MoldNumber = Convert.ToString(GridView1.GetRowCellValue(i, "Group ID"))

                        End With
                        fc_Class.Collection_Detail.Add(NPP_Detail)

                    Next


                    'fc_Class.UpdateData(fs_Code)
                    fc_Class.Update(fc_Class.H_No_NPP)
                    bs_Filter = gh_Common.GroupID
                    GridDtl.DataSource = fc_Class_Head.Get_NPP()
                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    Me.Hide()

                Else
                    If TRevisiInformasi.EditValue = "" Then
                        MessageBox.Show("Please fill Revice Information", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    With fc_Class

                        .H_No_NPP = TNPP_No.EditValue
                        .H_Model_Name = TModel.EditValue
                        .H_Model_Description = TModelDesc.EditValue
                        .H_Customer_Name = TCustomer.EditValue
                        .H_Order_Month = TOrderMonth.EditValue
                        .H_Order_Max_Month = TOrderMaxMonth.EditValue
                        .H_MP = TMp.EditValue
                        .H_Drawing = CBDrawing.CheckState
                        .H_CAD_Data = CBCad.CheckState
                        .H_Sample = CBSample.CheckState
                        .H_Special_Technical_Requires = CBStr.CheckState
                        .H_Category_Class = TCategory.EditValue
                        .H_Factory_Tsc_TNG = CBTng.CheckState
                        .H_Factory_Tsc_CKR = CBCkr.CheckState
                        .H_RevInformasi = TRevisiInformasi.EditValue
                        .H_TargetDRR = TTargetDr.EditValue
                        .H_TargetQuot = TTargetQuot.EditValue


                        .H_Rev = .H_Rev + 1

                    End With

                    'Insert To ObjDetailMaterial
                    fc_Class.Collection_Detail.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1

                        NPP_Detail = New Col_Cls_NPP_Detail_NPP
                        With NPP_Detail

                            .No_Npwo = TNPP_No.EditValue
                            .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                            .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                            .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                            .Cycle_Time = Convert.ToString(GridView1.GetRowCellValue(i, "C/T"))
                            .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                            .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                            .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                            .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                            .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                            .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                            .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                            .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                            .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                            .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                            .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                            .MoldNumber = Convert.ToString(GridView1.GetRowCellValue(i, "Group ID"))
                            .Rev = fc_Class.H_Rev
                        End With
                        fc_Class.Collection_Detail.Add(NPP_Detail)

                    Next


                    'fc_Class.UpdateData(fs_Code)
                    fc_Class.UpdateaAndHistory(fc_Class.H_No_NPP)
                    bs_Filter = gh_Common.GroupID
                    GridDtl.DataSource = fc_Class_Head.Get_NPP()
                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    Me.Hide()



                End If

            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub



    Private Sub TModel_Leave(sender As Object, e As EventArgs) Handles TModel.Leave

        If TCustomer.EditValue = "" Then
            MessageBox.Show("Please Select Customer",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            TModel.EditValue = ""
            Exit Sub
        ElseIf TModel.EditValue = "" Then
            TNPP_No.EditValue = ""
        Else

            fc_Class.GetNpwoNoAuto(Trim(TCustomer.EditValue), Trim(TModel.EditValue))
            TNPP_No.EditValue = fc_Class.H_No_NPP
        End If


    End Sub

    Private Sub TCustomer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCustomer.KeyPress
        'Dim tombol As Integer
        'tombol = Asc(e.KeyChar)

        'If Not ((tombol = 0)) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles TCustomer.EditValueChanged

        If TModel.EditValue <> "" Then
            fc_Class.GetNpwoNoAuto(Trim(TCustomer.EditValue), TModel.EditValue)
            TNPP_No.EditValue = fc_Class.H_No_NPP
        End If

    End Sub

    Private Sub TNpwo_No_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNPP_No.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Frm_Npwo_Detail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub Frm_Npwo_Detail_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        TNPP_No.EditValue = Test
    End Sub




    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal Nama As String = "",
                        Optional ByVal Machine As String = "",
                        Optional ByVal CycleTime As String = "",
                        Optional ByVal Cav As String = "",
                        Optional ByVal Weight As String = "",
                        Optional ByVal Material As String = "",
                        Optional ByVal Inj As Boolean = False,
                        Optional ByVal Paint As Boolean = False,
                        Optional ByVal Chrome As Boolean = False,
                        Optional ByVal Assy As Boolean = False,
                        Optional ByVal Ultrasonic As Boolean = False,
                        Optional ByVal Vibration As Boolean = False,
                        Optional ByVal StatusMold As String = "",
                        Optional ByVal OrderMonth As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If CForm = 1 Then
            frmSetGroup = New Frm_NPP_Set_Grup(TNPP_No.EditValue, ID, Nama, False, False, DtGridNPWO, Grid)
            frmSetGroup.StartPosition = FormStartPosition.CenterScreen
            frmSetGroup.MaximizeBox = False
            frmSetGroup.ShowDialog()
        ElseIf CForm = 3 Then
            frmPrepare = New Frm_NPP_Prepare(ID)
            frmPrepare.StartPosition = FormStartPosition.CenterScreen
            frmPrepare.MaximizeBox = False
            frmPrepare.ShowDialog()
        Else
            frmInput = New Frm_Input_NPPDetail(ID, Nama, Machine, CycleTime, Cav, Weight, Material, Inj, Paint, Chrome, Assy, Ultrasonic, Vibration, StatusMold, OrderMonth, IsNew, DtGridNPWO, Grid, TOrderMonth.EditValue, TNPP_No.EditValue)
            frmInput.StartPosition = FormStartPosition.CenterScreen
            frmInput.MaximizeBox = False
            frmInput.ShowDialog()
        End If



    End Sub

    Private Sub TOrderMonth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOrderMonth.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TOrderMaxMonth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOrderMaxMonth.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown

        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
            Grid.Refresh()

            DtGridNPWO.AcceptChanges()

            'Dim baseEdit = TryCast(sender, BaseEdit)
            'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            'gridView.PostEditor()
            'gridView.UpdateCurrentRow()

        End If
        'If e.KeyData = Keys.Insert Then
        '    GridView1.AddNewRow()
        'End If

    End Sub

    Public Overrides Sub Proc_Approve()


        fc_Class.GetDataByID(fs_Code)
        If fc_Class.H_Approve = False Then
            Dim result As DialogResult = XtraMessageBox.Show("Are You Sure To Approve " & fs_Code & "  ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                Try
                    fc_Class = New Cls_NPP_Detail
                    With fc_Class
                        .H_Approve = 1
                    End With
                    fc_Class.UpdateApprove(fs_Code)
                    bs_Filter = gh_Common.Username()
                    GridDtl.DataSource = fc_Class_Head.Get_NPP()

                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    Me.Hide()
                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try

            End If
        Else
            XtraMessageBox.Show("NPP '" & fs_Code & "' has been Submitted  ?", "Confirmation", MessageBoxButtons.OK)
        End If


    End Sub

    Private Sub TCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCategory.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Public Overrides Sub Proc_Print()

        fc_Class.GetDataByID(fs_Code)
        If fc_Class.H_Approve = True Then

            CForm = 3
            CallForm(fs_Code)


            FrmReport = New ReportNPWO
            FrmReport.NPP_No = TNPP_No.EditValue
            FrmReport.REV = TRevisi.EditValue

            FrmReport.StartPosition = FormStartPosition.CenterScreen
            FrmReport.WindowState = FormWindowState.Maximized
            FrmReport.MaximizeBox = False
            FrmReport.ShowDialog()

        Else

            MessageBox.Show("NPP No " & TNPP_No.EditValue & " Must be Approved First",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub TModel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TModel.KeyPress
        'e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        'frmInput = New Frm_Input_NPPDetail
        fc_Class.H_No_NPP = TNPP_No.EditValue

        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim PartNo As String = ""
            Dim PartName As String = ""
            Dim Machine As String = ""
            Dim CT As String = ""
            Dim Cav As String = ""
            Dim Weight As String = ""
            Dim Material As String = ""
            Dim StatusMold As String = ""
            Dim Order As String = ""
            Dim Inj As Boolean = True
            Dim Painting As Boolean = True
            Dim Chrome As Boolean = True
            Dim Assy As Boolean = True
            Dim Ultrasonic As Boolean = True
            Dim Vibration As Boolean = True
            'fc_ClassCRUD = New ClsCR_CreateUser

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PartNo = GridView1.GetRowCellValue(rowHandle, "Part No")
                    PartName = GridView1.GetRowCellValue(rowHandle, "Part Name")
                    Machine = IIf(GridView1.GetRowCellValue(rowHandle, "Machine") Is DBNull.Value, "", GridView1.GetRowCellValue(rowHandle, "Machine"))
                    CT = IIf(GridView1.GetRowCellValue(rowHandle, "C/T") Is DBNull.Value, "", GridView1.GetRowCellValue(rowHandle, "C/T"))
                    Cav = IIf(GridView1.GetRowCellValue(rowHandle, "Cav") Is DBNull.Value, "", GridView1.GetRowCellValue(rowHandle, "Cav"))
                    Weight = GridView1.GetRowCellValue(rowHandle, "Weight")
                    Material = GridView1.GetRowCellValue(rowHandle, "Material")
                    StatusMold = GridView1.GetRowCellValue(rowHandle, "Status Mold")
                    Order = GridView1.GetRowCellValue(rowHandle, "Order Month")
                    Inj = GridView1.GetRowCellValue(rowHandle, "Inj")
                    Painting = GridView1.GetRowCellValue(rowHandle, "Painting")
                    Chrome = GridView1.GetRowCellValue(rowHandle, "Chrome")
                    Assy = GridView1.GetRowCellValue(rowHandle, "Assy")
                    Ultrasonic = GridView1.GetRowCellValue(rowHandle, "Ultrasonic")
                    Vibration = GridView1.GetRowCellValue(rowHandle, "Vibration")

                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallForm(PartNo, PartName, Machine, CT, Cav, Weight, Material, Inj, Painting, Chrome, Assy, Ultrasonic, Vibration, StatusMold, Order, False)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub TModel_EditValueChanged(sender As Object, e As EventArgs) Handles TModel.EditValueChanged

    End Sub

    Private Sub TModelDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TModelDesc.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub SingleCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SingleCheck.CheckedChanged

        'Try
        '    'Part No
        '    Dim Kode As Boolean = (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Single"))
        '    Dim baseEdit = TryCast(sender, BaseEdit)
        '    Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        '    gridView.PostEditor()
        '    gridView.UpdateCurrentRow()

        '    If Kode = False Then
        '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Mold Number", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Part No"))
        '    Else Kode = True
        '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Mold Number", "")
        '    End If

        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try

        Dim Kode As Boolean = (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Single"))
        If Kode = False Then
            Dim Check As Boolean = True
            Dim Cek As String = ""
            Cek = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Mold Number")

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Mold Number") = Cek Then
                    GridView1.SetRowCellValue(i, "Single", Check)
                End If
            Next
        Else
            Dim Check As Boolean = False
            Dim Cek As String = ""
            Cek = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Mold Number")

            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Mold Number") = Cek Then
                    GridView1.SetRowCellValue(i, "Single", Check)
                End If
            Next
        End If



    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub BSetGroup_Click(sender As Object, e As EventArgs) Handles BSetGroup.Click

        CForm = 1

        CallForm()

    End Sub

    Private Sub TOrderMonth_Leave(sender As Object, e As EventArgs) Handles TOrderMonth.Leave

    End Sub
End Class
