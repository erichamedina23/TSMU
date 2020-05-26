Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_Npwo_Detail1

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New Cls_Npwo_Detail
    Dim fc_Class_Head As New Cls_Npwo_Header
    Dim Fc_Clas_Col_Detail As Col_Cls_Npwo_Detail_NPWO
    Dim Fc_Clas_Col_Detail_1 As Col_Cls_Npwo_Detail_1_NPWO

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim dtGrid As New DataTable
    Dim dt As New DataTable
    Dim dtDetail As New DataTable

    Dim dtHeader As New DataTable
    Dim dtBayangan As New DataTable

    Dim frmInput As Frm_Get_Npp_Detail
    Dim frmInput1 As Frm_Input_NpwoDetail
    Dim frmInput2 As Frm_Input_NPPDetail
    Dim frmPrepare As Frm_Npwo_Prepare

    Dim FormDetail As Integer = 0
    Dim dataSet As New DataSet
    Dim dtApprove As New DataTable

    Dim FrmReport As New Frm_Rpt_NPWO


    'Dim DtGridNPWO As DataTable

    Private Sub Frm_Npw_Detail1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        Call FillComboNPP()
        Call FillComboCategory()

        Call InitialSetForm()

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

    Private Sub FillComboNPP()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetNoNpp
            TNoNpp.Properties.DataSource = Nothing
            TNoNpp.Properties.DataSource = dt
            TNoNpp.Properties.ValueMember = "Value"
            TNoNpp.Properties.DisplayMember = "Value"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CreateTableBarang()

        dt = New DataTable
        dt.Columns.AddRange(New DataColumn(19) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Group ID", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("C/T", GetType(Double)),
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
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("LOI", GetType(String)),
                                                           New DataColumn("Order Month", GetType(Int32)),
                                                           New DataColumn("Type", GetType(String))})

        dtDetail = New DataTable
        dtDetail.Columns.AddRange(New DataColumn(19) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("C/T", GetType(Double)),
                                                           New DataColumn("Cav", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Qty Mold", GetType(Int32)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("LOI", GetType(String)),
                                                           New DataColumn("Order Month", GetType(Int32)),
                                                           New DataColumn("Group ID", GetType(String)),
                                                           New DataColumn("Type", GetType(String)),
                                                           New DataColumn("Type1", GetType(String))})


        dt.TableName = "Master"
        dtDetail.TableName = "Detail"
        dataSet.Tables.Add(dt)
        dataSet.Tables.Add(dtDetail)
        dataSet.Relations.Add("NPWO", dt.Columns("Group ID"), dtDetail.Columns("Group ID"))

        'Grid.DataSource = dt
        Grid.DataSource = dataSet
        Grid.DataMember = "Master"
        'Grid.DataMember = "Detail"
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
                Me.Text = "NPWO FORM -> " & fs_Code
            Else
                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)

                Me.Text = "NPWO FORM "
            End If

            Call LoadTxtBox()
            Call LoadGrid(fc_Class.H_No_Npwo)

            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TNpwo_No.EditValue = .H_No_Npwo
                    TNoNpp.EditValue = .H_No_NPP
                    TModelDesc.EditValue = .H_Model_Desc
                    TCustomer.EditValue = .H_Customer_Name
                    TModel.EditValue = .H_Model_Name
                    TOrderMonth.EditValue = .H_Order_Month
                    TOrderMaxMonth.EditValue = .H_Order_Max_Month
                    CBCad.Checked = .H_CAD_Data
                    CBDrawing.Checked = .H_Drawing
                    CBSample.Checked = .H_Sample
                    CBStr.Checked = .H_Special_Technical_Requires
                    CBTng.Checked = .H_Factory_Tsc_TNG
                    CBCkr.Checked = .H_Factory_Tsc_CKR
                    TCategory.EditValue = .H_Category_Class
                    TNoNpp.Enabled = False

                    Dim Mp As Date = "1900-01-01"
                    Dim HMP As Date = .H_MP
                    Dim HT0 As Date = .H_T0
                    Dim HT1 As Date = .H_T1
                    Dim HT2 As Date = .H_T2

                    If HMP <> Mp Then
                        TMp.EditValue = .H_MP
                    End If


                    If HT0 <> Mp Then
                        TT0.EditValue = .H_T0
                    End If

                    If HT1 <> Mp Then
                        TT1.EditValue = .H_T1
                    End If

                    If HT2 <> Mp Then
                        TT2.EditValue = .H_T2
                    End If

                End With

                If fc_Class.H_Approve = True Then
                    TRevisi.EditValue = fc_Class.H_Rev + 1
                Else
                    TRevisi.EditValue = fc_Class.H_Rev
                End If
                ' TRevisiInformasi.EditValue = ""
            Else
                TRevisi.EditValue = "0"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub LoadGrid(NPwo_ As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                dt = fc_Class.Get_Detail_Npwo(NPwo_)
                dtDetail = fc_Class.Get_Detail1_Npwo(NPwo_)


                dt.TableName = "Master1"
                dtDetail.TableName = "Detail1"
                dataSet.Tables.Add(dt)
                dataSet.Tables.Add(dtDetail)
                dataSet.Relations.Add("NPWO1", dt.Columns("Group ID"), dtDetail.Columns("Group ID"))
                Grid.DataSource = dataSet
                Grid.DataMember = "Master1"

            Else
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub TNoNpp_EditValueChanged(sender As Object, e As EventArgs) Handles TNoNpp.EditValueChanged
        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dtHeader = fc_Class.GetNppByID(TNoNpp.EditValue)
            If dtHeader.Rows.Count > 0 Then
                TCustomer.EditValue = dtHeader.Rows(0).Item("Customer_Name")
                TModel.EditValue = dtHeader.Rows(0).Item("Model_Name")
                TModelDesc.EditValue = dtHeader.Rows(0).Item("Model_Desc")
                TOrderMonth.EditValue = dtHeader.Rows(0).Item("Order_Month")
                TOrderMaxMonth.EditValue = dtHeader.Rows(0).Item("Order_Max_Month")
                TCategory.EditValue = dtHeader.Rows(0).Item("Category_Class")
                CBDrawing.Checked = dtHeader.Rows(0).Item("Drawing")
                CBCad.Checked = dtHeader.Rows(0).Item("CAD_Data")
                CBSample.Checked = dtHeader.Rows(0).Item("Sample")
                CBStr.Checked = dtHeader.Rows(0).Item("Special_Technical_Requires")
                CBCkr.Checked = dtHeader.Rows(0).Item("Factory_Tsc_CKR")
                CBTng.Checked = dtHeader.Rows(0).Item("Factory_Tsc_TNG")
                'TMp.EditValue = dtHeader.Rows(0).Item("MP")
                'TTargetDr.EditValue = dtHeader.Rows(0).Item("TargetDRR")
                'TTargetQuot.EditValue = dtHeader.Rows(0).Item("TargetQuot")

                If isUpdate = False Then
                    Call fc_Class.GetNpwoNoAuto(Trim(dtHeader.Rows(0).Item("Customer_Name")), Trim(dtHeader.Rows(0).Item("Model_Name")))
                    TNpwo_No.EditValue = fc_Class.H_No_Npwo
                End If

                dataSet.Clear()
                Grid.DataSource = dataSet
                Grid.Refresh()

            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BDetail_Click(sender As Object, e As EventArgs) Handles BDetail.Click


        FormDetail = 1
        CallForm(TNoNpp.EditValue, "")


    End Sub
    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal Nama As String = "",
                        Optional ByVal Machine As String = "",
                        Optional ByVal cycleTime As String = "",
                        Optional ByVal Cav As String = "",
                        Optional ByVal Weight As String = "",
                        Optional ByVal QtyMold As String = "",
                        Optional ByVal Material As String = "",
                        Optional ByVal Inj As Boolean = False,
                        Optional ByVal Paint As Boolean = False,
                        Optional ByVal Chrome As Boolean = False,
                        Optional ByVal Assy As Boolean = False,
                        Optional ByVal Ultrasonic As Boolean = False,
                        Optional ByVal Vibration As Boolean = False,
                        Optional ByVal StatusMold As String = "",
                        Optional ByVal OrderMonth As String = "",
                        Optional ByVal LOI As String = "",
                        Optional ByVal Type As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If FormDetail = 1 Then
            frmInput = New Frm_Get_Npp_Detail(ID, Nama, Material, Weight, Inj, Paint, Chrome, Assy, Ultrasonic, StatusMold, OrderMonth, IsNew, dt, Grid, dtDetail, Grid)
            frmInput.StartPosition = FormStartPosition.CenterScreen
            frmInput.MaximizeBox = False
            frmInput.ShowDialog()

        ElseIf FormDetail = 2 Then

            frmInput1 = New Frm_Input_NpwoDetail(ID, Nama, Machine, cycleTime, Cav, Weight, QtyMold, Material, Inj, Paint, Chrome, Assy, Ultrasonic, Vibration, StatusMold, OrderMonth, Type, LOI, IsNew, dt, dtDetail, Grid)
            frmInput1.StartPosition = FormStartPosition.CenterScreen
            frmInput1.MaximizeBox = False
            frmInput1.ShowDialog()
        ElseIf FormDetail = 3 Then
            frmPrepare = New Frm_Npwo_Prepare(ID)
            frmPrepare.StartPosition = FormStartPosition.CenterScreen
            frmPrepare.MaximizeBox = False
            frmPrepare.ShowDialog()

        End If

    End Sub

    Private Sub TPartNo_EditValueChanged(sender As Object, e As EventArgs) Handles TPartNo.EditValueChanged, Grid.DoubleClick
        Try
            'Part No
            Dim Kode As String = (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDB")).ToString
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            'For i As Integer = 0 To GridView2.RowCount - 1
            '    Dim kodeDetail As String = GridView2.GetRowCellValue(i, GridView2.Columns("IDB1")).ToString
            '    If Kode = kodeDetail Then
            '        GridView2.SetRowCellValue(i, GridView2.Columns("ID"), (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Part No")).ToString)
            '    End If
            'Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

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

                MessageBox.Show("Please Fill Grid 1 ", "Warning",
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

#Region "Insert"

                dtApprove = New DataTable

                dtApprove = fc_Class.GetApprove()

                With fc_Class

                    .H_No_Npwo = TNpwo_No.EditValue
                    .H_No_NPP = TNoNpp.EditValue
                    .H_Model_Name = TModel.EditValue
                    .H_Model_Desc = TModelDesc.EditValue
                    .H_Customer_Name = TCustomer.EditValue
                    .H_Order_Month = TOrderMonth.EditValue
                    .H_Order_Max_Month = TOrderMaxMonth.EditValue

                    Dim iDate As String = "1900-01-01"
                    Dim oDate As Date = DateTime.ParseExact(iDate, "yyyy-MM-dd", Nothing)

                    If TMp.Text = "" Then
                        .H_MP = oDate
                    Else
                        .H_MP = TMp.EditValue
                    End If

                    If TT0.Text = "" Then
                        .H_T0 = oDate
                    Else
                        .H_T0 = TT0.EditValue
                    End If

                    If TT1.Text = "" Then
                        .H_T1 = oDate
                    Else
                        .H_T1 = TT1.EditValue
                    End If

                    If TT2.Text = "" Then
                        .H_T2 = oDate
                    Else
                        .H_T2 = TT2.EditValue
                    End If

                    .H_Drawing = CBDrawing.CheckState
                    .H_CAD_Data = CBCad.CheckState
                    .H_Sample = CBSample.CheckState
                    .H_Special_Technical_Requires = CBStr.CheckState
                    .H_Category_Class = TCategory.EditValue
                    .H_Factory_Tsc_TNG = CBTng.CheckState
                    .H_Factory_Tsc_CKR = CBCkr.CheckState
                    .H_Rev = 0
                    .H_Rev_Info = TRevInfo.EditValue

                    .H_Checked = dtApprove.Rows(0).Item("Checked")
                    .H_A1 = dtApprove.Rows(0).Item("A1")
                    .H_A2 = dtApprove.Rows(0).Item("A2")
                    .H_A3 = dtApprove.Rows(0).Item("A3")
                    .H_A4 = dtApprove.Rows(0).Item("A4")

                End With
                'Colletion Detail
                fc_Class.Collection_Detail.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Fc_Clas_Col_Detail = New Col_Cls_Npwo_Detail_NPWO
                    With Fc_Clas_Col_Detail
                        .Join = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .GroupID = Convert.ToString(GridView1.GetRowCellValue(i, "Group ID"))
                        .No_Npwo = TNpwo_No.EditValue
                        .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                        .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                        .Cycle_Time = Convert.ToDouble(GridView1.GetRowCellValue(i, "C/T"))
                        .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                        .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                        .Qty_Mold = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty Mold"))
                        .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                        .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                        .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                        .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                        .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                        .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                        .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                        .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                        .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                        .LOI_Number = Convert.ToString(GridView1.GetRowCellValue(i, "LOI"))
                        .Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail.Add(Fc_Clas_Col_Detail)

                Next

                'Colletion Detail_1

                fc_Class.Collection_Detail_1.Clear()
                For i As Integer = 0 To dtDetail.Rows.Count - 1

                    Fc_Clas_Col_Detail_1 = New Col_Cls_Npwo_Detail_1_NPWO
                    With Fc_Clas_Col_Detail_1
                        .No_Npwo = TNpwo_No.EditValue
                        .Part_No = Convert.ToString(dtDetail.Rows(i).Item("Part No"))
                        .Part_Name = Convert.ToString(dtDetail.Rows(i).Item("Part Name"))
                        .Machine = Convert.ToString(dtDetail.Rows(i).Item("Machine"))
                        .Cycle_Time = Convert.ToDouble(dtDetail.Rows(i).Item("C/T"))
                        .Cavity = Convert.ToString(dtDetail.Rows(i).Item("Cav"))
                        .Weight = Convert.ToDouble(dtDetail.Rows(i).Item("Weight"))
                        .Qty_Mold = Convert.ToDouble(dtDetail.Rows(i).Item("Qty Mold"))
                        .Material_Resin = Convert.ToString(dtDetail.Rows(i).Item("Material"))
                        .Injection = Convert.ToBoolean(dtDetail.Rows(i).Item("Inj"))
                        .Painting = Convert.ToBoolean(dtDetail.Rows(i).Item("Painting"))
                        .Chrome = Convert.ToBoolean(dtDetail.Rows(i).Item("Chrome"))
                        .Vibration = Convert.ToBoolean(dtDetail.Rows(i).Item("Vibration"))
                        .Assy = Convert.ToBoolean(dtDetail.Rows(i).Item("Assy"))
                        .Ultrasonic = Convert.ToBoolean(dtDetail.Rows(i).Item("Ultrasonic"))
                        .StatusMold = Convert.ToString(dtDetail.Rows(i).Item("Status Mold"))
                        .OrderMonth = Convert.ToInt32(dtDetail.Rows(i).Item("Order Month"))
                        .LOI_Number = Convert.ToString(dtDetail.Rows(i).Item("LOI"))
                        .GroupID = Convert.ToString(dtDetail.Rows(i).Item("Group ID"))
                        .Type = Convert.ToString(dtDetail.Rows(i).Item("Type"))
                        .Type1 = Convert.ToString(dtDetail.Rows(i).Item("Type1"))

                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail_1.Add(Fc_Clas_Col_Detail_1)

                Next


                fc_Class.Insert(TNpwo_No.EditValue)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class_Head.Get_NPWO()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
#End Region



#Region "Update"

            Else
                With fc_Class

                    .H_No_Npwo = TNpwo_No.EditValue
                    .H_No_NPP = TNoNpp.EditValue
                    .H_Model_Name = TModel.EditValue
                    .H_Model_Desc = TModelDesc.EditValue
                    .H_Customer_Name = TCustomer.EditValue
                    .H_Order_Month = TOrderMonth.EditValue
                    .H_Order_Max_Month = TOrderMaxMonth.EditValue

                    Dim iDate As String = "1900-01-01"
                    Dim oDate As Date = DateTime.ParseExact(iDate, "yyyy-MM-dd", Nothing)

                    If TMp.Text = "" Then
                        .H_MP = oDate
                    Else
                        .H_MP = TMp.EditValue
                    End If

                    If TT0.Text = "" Then
                        .H_T0 = oDate
                    Else
                        .H_T0 = TT0.EditValue
                    End If

                    If TT1.Text = "" Then
                        .H_T1 = oDate
                    Else
                        .H_T1 = TT0.EditValue
                    End If

                    If TT2.Text = "" Then
                        .H_T2 = oDate
                    Else
                        .H_T2 = TT0.EditValue
                    End If

                    .H_Drawing = CBDrawing.CheckState
                    .H_CAD_Data = CBCad.CheckState
                    .H_Sample = CBSample.CheckState
                    .H_Special_Technical_Requires = CBStr.CheckState
                    .H_Category_Class = TCategory.EditValue
                    .H_Factory_Tsc_TNG = CBTng.CheckState
                    .H_Factory_Tsc_CKR = CBCkr.CheckState
                    .H_Rev = 0
                    .H_Rev_Info = TRevInfo.EditValue

                End With
                'Colletion Detail
                fc_Class.Collection_Detail.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Fc_Clas_Col_Detail = New Col_Cls_Npwo_Detail_NPWO
                    With Fc_Clas_Col_Detail

                        .No_Npwo = TNpwo_No.EditValue
                        .GroupID = Convert.ToString(GridView1.GetRowCellValue(i, "Group ID"))
                        .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                        .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                        .Cycle_Time = Convert.ToDouble(GridView1.GetRowCellValue(i, "C/T"))
                        .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                        .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                        .Qty_Mold = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty Mold"))
                        .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                        .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                        .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                        .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                        .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                        .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                        .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                        .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                        .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                        .LOI_Number = Convert.ToString(GridView1.GetRowCellValue(i, "LOI"))
                        .Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                        .Rev = 0


                    End With
                    fc_Class.Collection_Detail.Add(Fc_Clas_Col_Detail)

                Next

                'Colletion Detail_1

                fc_Class.Collection_Detail_1.Clear()
                For i As Integer = 0 To dtDetail.Rows.Count - 1

                    Fc_Clas_Col_Detail_1 = New Col_Cls_Npwo_Detail_1_NPWO
                    With Fc_Clas_Col_Detail_1
                        .No_Npwo = TNpwo_No.EditValue
                        .Part_No = Convert.ToString(dtDetail.Rows(i).Item("Part No"))
                        .Part_Name = Convert.ToString(dtDetail.Rows(i).Item("Part Name"))
                        .Machine = Convert.ToString(dtDetail.Rows(i).Item("Machine"))
                        .Cycle_Time = Convert.ToDouble(dtDetail.Rows(i).Item("C/T"))
                        .Cavity = Convert.ToString(dtDetail.Rows(i).Item("Cav"))
                        .Weight = Convert.ToDouble(dtDetail.Rows(i).Item("Weight"))
                        .Qty_Mold = Convert.ToDouble(dtDetail.Rows(i).Item("Qty Mold"))
                        .Material_Resin = Convert.ToString(dtDetail.Rows(i).Item("Material"))
                        .Injection = Convert.ToBoolean(dtDetail.Rows(i).Item("Inj"))
                        .Painting = Convert.ToBoolean(dtDetail.Rows(i).Item("Painting"))
                        .Chrome = Convert.ToBoolean(dtDetail.Rows(i).Item("Chrome"))
                        .Vibration = Convert.ToBoolean(dtDetail.Rows(i).Item("Vibration"))
                        .Assy = Convert.ToBoolean(dtDetail.Rows(i).Item("Assy"))
                        .Ultrasonic = Convert.ToBoolean(dtDetail.Rows(i).Item("Ultrasonic"))
                        .StatusMold = Convert.ToString(dtDetail.Rows(i).Item("Status Mold"))
                        .OrderMonth = Convert.ToInt32(dtDetail.Rows(i).Item("Order Month"))
                        .LOI_Number = Convert.ToString(dtDetail.Rows(i).Item("LOI"))
                        .GroupID = Convert.ToString(dtDetail.Rows(i).Item("Group ID"))
                        .Type = Convert.ToString(dtDetail.Rows(i).Item("Type"))
                        .Type1 = Convert.ToString(dtDetail.Rows(i).Item("Type1"))
                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail_1.Add(Fc_Clas_Col_Detail_1)

                Next

                fc_Class.Update(TNpwo_No.EditValue)
                bs_Filter = gh_Common.GroupID
                'GridDtl.DataSource = fc_Class_Head.Get_NPWO()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
#End Region


            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyData = Keys.Delete Then

            Try
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim ID As String = ""
                'fc_ClassCRUD = New ClsCR_CreateUser
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "Part No")
                    End If
                Next rowHandle



                For b As Integer = 0 To dtDetail.Rows.Count - 1
                    If dtDetail.Rows(b).Item("Part No") = ID Then
                        Dim rows() As DataRow = dtDetail.Select()
                        rows(b).Delete()
                    End If

                Next

                For a As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(a).Item("Part No") = ID Then
                        Dim rows() As DataRow = dt.Select()
                        rows(a).Delete()

                    End If
                Next
                dt.AcceptChanges()
                dtDetail.AcceptChanges()
                dt.TableName = "Master1"
                dtDetail.TableName = "Detail1"
                dataSet.Tables.Add(dt)
                dataSet.Tables.Add(dtDetail)
                dataSet.Relations.Add("NPWO1", dt.Columns("Group ID"), dtDetail.Columns("Group ID"))
                Grid.DataSource = dataSet
                Grid.DataMember = "Master1"

            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub GridBayangan_KeyDown(sender As Object, e As KeyEventArgs)

        'If e.KeyData = Keys.Delete Then
        '    GridView2.DeleteRow(GridView2.FocusedRowHandle)
        '    GridView2.RefreshData()

        'End If

    End Sub

    Private Sub B_AddRows_Click(sender As Object, e As EventArgs) Handles B_AddRows.Click


        FormDetail = 2
        CallForm()

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs)

        Try


            FormDetail = 2

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim PartNo As String = ""
            Dim PartName As String = ""
            Dim Machine As String = ""
            Dim CycleTime As String = ""
            Dim Cav As String = ""
            Dim Weight As String = ""
            Dim QtyMold As String = ""
            Dim Material As String = ""
            Dim StatusMold As String = ""
            Dim Order As String = ""
            Dim LOI As String = ""
            Dim Inj As Boolean = True
            Dim Painting As Boolean = True
            Dim Chrome As Boolean = True
            Dim Assy As Boolean = True
            Dim Ultrasonic As Boolean = True
            Dim Vibration As Boolean = True



            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PartNo = GridView1.GetRowCellValue(rowHandle, "Part No")
                    PartName = GridView1.GetRowCellValue(rowHandle, "Part Name")
                    Machine = GridView1.GetRowCellValue(rowHandle, "Machine")
                    CycleTime = GridView1.GetRowCellValue(rowHandle, "C/T")
                    Cav = GridView1.GetRowCellValue(rowHandle, "Cav")
                    Weight = GridView1.GetRowCellValue(rowHandle, "Weight")
                    QtyMold = GridView1.GetRowCellValue(rowHandle, "Qty Mold")
                    Material = GridView1.GetRowCellValue(rowHandle, "Material")
                    Order = GridView1.GetRowCellValue(rowHandle, "Order Month")
                    LOI = GridView1.GetRowCellValue(rowHandle, "LOI")
                    Inj = GridView1.GetRowCellValue(rowHandle, "Inj")
                    Painting = GridView1.GetRowCellValue(rowHandle, "Painting")
                    Chrome = GridView1.GetRowCellValue(rowHandle, "Chrome")
                    Assy = GridView1.GetRowCellValue(rowHandle, "Assy")
                    Ultrasonic = GridView1.GetRowCellValue(rowHandle, "Ultrasonic")
                    Vibration = GridView1.GetRowCellValue(rowHandle, "Vibration")

                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then

                Call CallForm(PartNo, PartName, Machine, CycleTime, Cav, Weight, QtyMold, Material, Inj, Painting, Chrome, Assy, Ultrasonic, Vibration, StatusMold, Order, "", LOI, False)

            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Public Overrides Sub Proc_Print()

        fc_Class.GetDataByID(fs_Code)
        If fc_Class.H_Approve = True Then


            FormDetail = 3
            CallForm(fs_Code)

            FrmReport = New Frm_Rpt_NPWO
            FrmReport.NPWO_No = TNpwo_No.EditValue
            FrmReport.REV = TRevisi.EditValue

            FrmReport.StartPosition = FormStartPosition.CenterScreen
            FrmReport.WindowState = FormWindowState.Maximized
            FrmReport.MaximizeBox = False
            FrmReport.ShowDialog()

        Else

            MessageBox.Show("NPWO No " & TNpwo_No.EditValue & " Must be Approved First",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub TNoNpp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNoNpp.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Public Overrides Sub Proc_Approve()


        fc_Class.GetDataByID(fs_Code)
        If fc_Class.H_Approve = False Then
            Dim result As DialogResult = XtraMessageBox.Show("Are You Sure To Approve " & fs_Code & "  ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                Try
                    With fc_Class
                        .H_Approve = 1
                    End With
                    fc_Class.UpdateApprove(fs_Code)
                    bs_Filter = gh_Common.Username()
                    GridDtl.DataSource = fc_Class_Head.Get_NPWO()

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
End Class
