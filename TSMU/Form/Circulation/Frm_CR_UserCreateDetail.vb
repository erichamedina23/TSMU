Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_CR_UserCreateDetail

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsCR_CreateUser
    Dim Description_Of_Cost As New ClsCR_Description_of_Cost
    Dim Installment As New ClsCR_Installment
    Dim Other_Dept As New ClsCR_Other_Dept
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Dept As String
    Dim DeptSub As String = ""

    Dim DtGridBarang As DataTable
    Dim DtGridPayment As DataTable

    Dim TotalBudget As Double = 0
    Dim TotalCR As Double = 0
    Dim SisaBudget As Double = 0

    Dim CR As Double = 0
    Dim Balance As Double = 0


    Dim NoSirkulasi As String = ""


    Dim CForm As Integer = 0
    Dim FGetMold As Frm_CR_Get_Mold





    Dim id As System.Globalization.CultureInfo '= New System.Globalization.CultureInfo("id-ID")





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

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If

                If fc_Class.H_Status = "Create" Then

                    Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)

                Else

                    Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False)


                End If

                Me.Text = "CIRCULATION FORM -> " & fs_Code
            Else
                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)

                Me.Text = "CIRCULATION FORM "
            End If

            Call LoadTxtBox()
            Call LoadGridBarang(fc_Class.H_CirculationNo)
            Call LoadGridInstallment(fc_Class.H_CirculationNo)
            'Call LoadGridDetil1()

            Call FillComboOtherDept()
            Call FillComboCurrency()
            Call Sub_Dept(gh_Common.GroupID)
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    T_CRNo.EditValue = .H_CirculationNo
                    T_RequirementDate.EditValue = .H_RequirementDate
                    T_CRType.EditValue = .H_CR_Type
                    T_Reason.Text = .H_Reason
                    T_Parent.EditValue = .H_Parent_Circulation
                    T_ParentAmount.EditValue = .H_Parent_Circulation_Amount.ToString("#,##0.00")


                End With
            Else
                T_RequirementDate.EditValue = DateTime.Now
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub LoadGridBarang(CirculationNo As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                Dim dt As New DataTable
                dt = fc_Class.Get_Detail_DescriptionOfCost(CirculationNo)
                Grid.DataSource = dt
                Cursor.Current = Cursors.Default
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub LoadGridInstallment(CirculationNo As String)
        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                Dim dt As New DataTable
                dt = fc_Class.Get_Detail_Installment(CirculationNo)
                Grid1.DataSource = dt
                Cursor.Current = Cursors.Default
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub FillComboOtherDept()
        Try
            If fs_Code <> "" Then

                Dim A As ArrayList = New ArrayList
                Dim dt1 As New DataTable
                dt1 = fc_Class.Get_Other_DeptID_Filter(fs_Code)

                For i As Integer = 0 To dt1.Rows.Count - 1
                    A.Add(dt1.Rows(i).Item("DeptID"))
                Next

                Dim s As String = ""
                Dim dt As New DataTable
                dt = fc_Class.Get_Other_DeptID
                T_Dept.Properties.DataSource = Nothing
                T_Dept.Properties.DataSource = dt
                T_Dept.Properties.ValueMember = "Value"
                T_Dept.Properties.DisplayMember = "Value"
                For b As Integer = 0 To A.Count - 1
                    s = s & A.Item(b) & ","
                Next
                T_Dept.SetEditValue(s)
            Else

                Dim dt As New DataTable
                dt = fc_Class.Get_Other_DeptID
                T_Dept.Properties.DataSource = Nothing
                T_Dept.Properties.DataSource = dt
                T_Dept.Properties.ValueMember = "Value"
                T_Dept.Properties.DisplayMember = "Value"
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
            Dim dt As New DataTable
            dt = fc_Class.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Rate Tidak ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                DeptSub = (dt.Rows(0).Item("Sub"))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub FillRate(Tahun As String, Bulan As String, Cur As String)
        Try

            ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
            Dim dt As New DataTable
            dt = fc_Class.Rate(Tahun, Bulan, Cur)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Rate Tidak ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                ' T_Rate.EditValue = "1"
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Curr", "IDR")
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", "1")
                Exit Sub
            Else
                Dim rate As Double = (dt.Rows(0).Item("Rate"))

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", rate)

                'T_Rate.EditValue = rate.ToString("#,##0.00")
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Qty", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Price", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", 0)

        For r As Integer = 1 To GridView2.RowCount
            GridView2.SelectRow(r)
            GridView2.DeleteSelectedRows()
        Next

    End Sub

    Private Sub T_Account_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_CRType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_CRType.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub



    Private Sub C_Currency_EditValueChanged(sender As Object, e As EventArgs)
        'Try
        '    If T_RequirementDate.EditValue = Nothing Then

        '        MessageBox.Show("Please Select Requirement Date ",
        '                       "Warning",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Exclamation,
        '                       MessageBoxDefaultButton.Button1)

        '    Else

        '        Dim Cur As String = C_Currency.EditValue
        '        Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
        '        Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
        '        Dim Bulan As String = Convert.ToString(Param.ToString("MM"))



        '        Call FillRate(Tahun, Bulan, Cur)
        '    End If

        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        'End Try
    End Sub

    Private Sub C_Currency_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_RequirementDate_EditValueChanged(sender As Object, e As EventArgs) Handles T_RequirementDate.EditValueChanged

    End Sub

    Private Sub T_RequirementDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_RequirementDate.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CreateTableBarang()
        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(10) {New DataColumn("Name Of Goods", GetType(String)),
                                                            New DataColumn("Spesification", GetType(String)),
                                                            New DataColumn("Qty", GetType(Double)),
                                                            New DataColumn("Price", GetType(Double)),
                                                            New DataColumn("Amount", GetType(Double)),
                                                            New DataColumn("Curr", GetType(String)),
                                                            New DataColumn("Category", GetType(String)),
                                                            New DataColumn("Balance", GetType(Double)),
                                                            New DataColumn("Rate", GetType(Double)),
                                                            New DataColumn("Remaining Budget", GetType(Double)),
                                                            New DataColumn("Account", GetType(String))})

        Grid.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False


        DtGridPayment = New DataTable
        DtGridPayment.Columns.AddRange(New DataColumn(3) {New DataColumn("Term", GetType(String)),
                                                            New DataColumn("Date", GetType(Date)),
                                                            New DataColumn("%", GetType(Double)),
                                                            New DataColumn("Total", GetType(Double))})

        Grid1.DataSource = DtGridPayment
        GridView2.OptionsView.ShowAutoFilterRow = False

    End Sub


    Private Sub Frm_CR_UserCreateDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        'Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub

    Private Sub FillComboCurrency()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getWC

            For a As Integer = 0 To dt.Rows.Count - 1
                CurrRepository.Items.Add(dt.Rows(a).Item(0))
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub C_Qty_EditValueChanged(sender As Object, e As EventArgs) Handles C_Qty.EditValueChanged
        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty"))
            Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            Dim Rate As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", Qty * Price * Rate)

            CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount"))
            SisaBudget = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget"))

            Balance = SisaBudget - CR
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)



            Dim Total1 As Double = Convert.ToDouble((GridView1.Columns("Amount").SummaryItem.SummaryValue))

            For r As Integer = 1 To GridView2.RowCount
                GridView2.SelectRow(r)
                GridView2.DeleteSelectedRows()
            Next

            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Category") <> "N" Then
                If Balance <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "O")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If
            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub C_Price_EditValueChanged(sender As Object, e As EventArgs) Handles C_Price.EditValueChanged

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty"))
            Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            Dim Rate As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", Qty * Price * Rate)

            CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount"))
            SisaBudget = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget"))

            Balance = SisaBudget - CR
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)

            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Category") <> "N" Then
                If Balance <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "O")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If
            End If

            Dim Total As Double = Convert.ToDouble((GridView1.Columns("Amount").SummaryItem.SummaryValue))

            For r As Integer = 1 To GridView2.RowCount
                GridView2.SelectRow(r)
                GridView2.DeleteSelectedRows()
            Next

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try






    End Sub

    Private Sub C_Percent_Term__EditValueChanged(sender As Object, e As EventArgs) Handles C_Percent_Term.EditValueChanged

        Dim CurrentCR As Double = "0"

        'Dim Total1 As Double = Convert.ToDouble((GridView1.Columns("Amount").SummaryItem.SummaryValue))

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim Percent As Double = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "%") Is DBNull.Value, 0, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "%"))
            Dim CR As Double = CurrentCR
            'Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Total", (Percent / 100) * CR)

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub


    Private Sub C_Total__EditValueChanged(sender As Object, e As EventArgs) Handles C_Total.EditValueChanged

        Dim CurrentCR As Double = "0"

        Dim Total1 As Double = Convert.ToDouble((GridView1.Columns("Amount").SummaryItem.SummaryValue))

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim Total As Double = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Total") Is DBNull.Value, 0, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Total"))
            Dim CR As Double = CurrentCR
            'Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "%", (Total / CR) * 100)

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub C_Term_KeyPress(sender As Object, e As KeyPressEventArgs) Handles C_Term.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub



    Private Sub C_Term_SelectedIndexChanged(sender As Object, e As EventArgs) Handles C_Term.SelectedIndexChanged



        Dim Rows As Integer = Convert.ToInt32(C_Term.EditValue)

        For r As Integer = 1 To GridView2.RowCount
            GridView2.SelectRow(r)
            GridView2.DeleteSelectedRows()
        Next

        For i As Integer = 1 To Rows

            GridView2.AddNewRow()
            GridView2.OptionsNavigation.AutoFocusNewRow = True
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Term", i.ToString)

        Next



    End Sub

    Private Sub T_RemainingBudget_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_CurrentCirculation_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_Balance_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub



    Private Sub T_Rate_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Get_Total_Sisa_Budget_Dept(Dept_Sub As String, NoAccount As String, Tahun As String, Bulan As String)

        Try
            Dim dt As New DataTable
            dt = fc_Class.Get_Total_Sisa_Budget_Dept(Dept_Sub, NoAccount, Tahun, Bulan)
            If dt.Rows.Count <= 0 Then
                'MessageBox.Show("Data Tidak ditemukan",
                '               "Warning",
                '               MessageBoxButtons.OK,
                '               MessageBoxIcon.Exclamation,
                '               MessageBoxDefaultButton.Button1)
                TotalBudget = 0
            Else
                SisaBudget = Convert.ToDouble(dt.Rows(0).Item("SisaBudget"))
                'Dim Buget As Double = Convert.ToDouble(dt.Rows(0).Item("Total"))
                'TextEdit_Buget_TSC.EditValue = Buget.ToString("#,##0.00")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Get_Total_CR_Dept(Dept As String, Site As String, NoAccount As String, Tahun As String)

        Try
            Dim dt As New DataTable
            dt = fc_Class.Get_Total_CR_Dept(Dept, Site, NoAccount, Tahun)
            If dt.Rows.Count <= 0 Then
                'MessageBox.Show("Data Tidak ditemukan",
                '               "Warning",
                '               MessageBoxButtons.OK,
                '               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                TotalCR = 0
                'TextEdit_CR_dept.EditValue = TotalCR.ToString("#,##0.00")
            Else
                TotalCR = Convert.ToDouble(dt.Rows(0).Item("Total"))
                Dim Buget As Double = Convert.ToDouble(dt.Rows(0).Item("Total"))
                'TextEdit_CR_dept.EditValue = Buget.ToString("#,##0.00")
            End If
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

                MessageBox.Show("Please Fill Description Of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf GridView2.RowCount = 0 Then
                MessageBox.Show("Please Fill Term of Paymen / Installment", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty Of Description of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


                For j As Integer = 0 To GridView2.RowCount - 1
                    GridView2.MoveFirst()
                    If GridView2.GetRowCellValue(j, GridView2.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty of Term Of Payment", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


            End If

            If isUpdate = False Then
                fc_Class.GetCirculationNoAuto()
                Dim BudgetType As Integer
                If RB_Budget.Checked = True Then
                    BudgetType = 1
                ElseIf RB_NonBudget.Checked = True Then
                    BudgetType = 0
                End If

                NoSirkulasi = fc_Class.H_CirculationNo
                With fc_Class

                    .H_Budget = BudgetType
                    .H_CR_Type = T_CRType.EditValue
                    .H_Reason = T_Reason.Text
                    .H_RequirementDate = Format(T_RequirementDate.EditValue, "yyyy-MM-dd")
                    .H_Status = "Create"
                    .H_Parent_Circulation = T_Parent.EditValue
                    .H_Parent_Circulation_Amount = CDec(T_ParentAmount.EditValue)
                    .H_Dies_Sales_Type = T_DS.EditValue
                    .H_Dies_Customer_Name = T_CustomerName.EditValue
                    .H_Dies_Model = T_ModelName.EditValue
                    '.H_ChargedOf = T_Charged.EditValue
                    If T_Charged.EditValue = "YES" Then
                        .H_ChargedOf = 1
                    Else
                        .H_ChargedOf = 0
                    End If
                    .H_Dies_Remark = T_Remark.EditValue
                    .H_InvoiceNo = ""
                    .H_InvoiceStatus = 0
                    .H_Dies = 1



                End With


                'Insert To ObjDetailMaterial
                fc_Class.Collection_Description_Of_Cost.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Description_Of_Cost = New ClsCR_Description_of_Cost
                    With Description_Of_Cost

                        .D_CirculationNo = NoSirkulasi
                        .D_Name_Of_Goods = Convert.ToString(GridView1.GetRowCellValue(i, "Name Of Goods"))
                        .D_Spesification = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))
                        .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Price = Convert.ToDouble(GridView1.GetRowCellValue(i, "Price"))
                        .D_Amount = Convert.ToInt32(GridView1.GetRowCellValue(i, "Amount"))
                        .D_PR_No = Convert.ToString(GridView1.GetRowCellValue(i, "PR No"))

                    End With
                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                Next

                fc_Class.Collection_Other_Dept.Clear()

                Dim checked As New List(Of String)
                Dim checkedString As String = CType(T_Dept.Properties.GetCheckedItems(), String)
                If (checkedString.Length > 0) Then
                    checked.AddRange(checkedString.Split(New Char() {","c}))
                    For Each item In checked

                        Other_Dept = New ClsCR_Other_Dept
                        With Other_Dept

                            .D_CirculationNo = NoSirkulasi
                            .D_Dept = Trim(item).ToString
                            .D_UserName = "UserName"
                            .D_Name = "test"
                            '.D_UserName = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))
                            '.D_Name = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))

                        End With
                        fc_Class.Collection_Other_Dept.Add(Other_Dept)

                        'MessageBox.Show(item.ToString, "Warning",
                        '   MessageBoxButtons.OK,
                        '   MessageBoxIcon.Exclamation,
                        '   MessageBoxDefaultButton.Button1)
                    Next
                End If

                fc_Class.Collection_Installment.Clear()
                For j As Integer = 0 To GridView2.RowCount - 1

                    Installment = New ClsCR_Installment
                    With Installment

                        .D_CirculationNo = NoSirkulasi
                        .D_Term = Convert.ToInt32(GridView2.GetRowCellValue(j, "Term"))
                        .D_Date = Convert.ToDateTime(GridView2.GetRowCellValue(j, "Date"))
                        .D_Percent = Convert.ToDouble(GridView2.GetRowCellValue(j, "%"))
                        .D_Amount = Convert.ToDouble(GridView2.GetRowCellValue(j, "Total"))

                    End With
                    fc_Class.Collection_Installment.Add(Installment)

                Next




                fc_Class.Insert(NoSirkulasi)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class.Get_CRRequest(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                'KodeTrans = fc_Class.IDTrans
                'fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                ''Insert To ObjDetailMaterial
                'fc_Class.ObjDetailQualityProblem.Clear()
                'For i As Integer = 0 To GridView1.RowCount - 1

                '    ObjQualityProblemDetail = New QualityProblemDetailModel
                '    With ObjQualityProblemDetail
                '        .D_IDTransaksi = KodeTrans
                '        .D_Shift = Convert.ToString(GridView1.GetRowCellValue(i, "Shift"))
                '        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                '        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                '        .D_InvtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                '        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "InvtName"))
                '        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                '        .D_Qty = Convert.ToString(GridView1.GetRowCellValue(i, "Qty"))
                '        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                '        .D_Analisis = Convert.ToString(GridView1.GetRowCellValue(i, "Analisis"))
                '        .D_CORRECTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action"))
                '        .D_PREVENTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action"))
                '        .D_Lot = Convert.ToString(GridView1.GetRowCellValue(i, "Lot No"))
                '        .D_Pic = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                '        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                '        .D_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                '        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))

                '    End With
                '    fc_Class.ObjDetailQualityProblem.Add(ObjQualityProblemDetail)

                'Next


                'fc_Class.UpdateData(fs_Code)
                'GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                'IsClosed = True
                'Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If RB_Budget.Checked = False And RB_NonBudget.Checked = False Then
                MessageBox.Show("Please Choose a Budget Type", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf T_Dept.EditValue = "" Then
                MessageBox.Show("Please Choose Other Dept", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf T_CRType.EditValue = "" Then
                MessageBox.Show("Please fill type of Circulation", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf T_Reason.Text = "" Then
                MessageBox.Show("Please fill Reason Of Description", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_DS.EditValue = "" Then
                MessageBox.Show("Please Choose Sales Type", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_CustomerName.EditValue = "" Then
                MessageBox.Show("Please fill Customer Name", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_ModelName.EditValue = "" Then
                MessageBox.Show("Please fill Model Name", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_Charged.EditValue = "" Then
                MessageBox.Show("Please Choose Charge Of Customer", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_RequirementDate.EditValue = "" Then
                MessageBox.Show("Please Choose RequirementDate", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)

            Else

                lb_Validated = True
            End If

            If lb_Validated Then
                With fc_Class
                    If isUpdate = False Then
                        .ValidateInsert()
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


    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView2.DeleteRow(GridView2.FocusedRowHandle)
            GridView2.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView2.AddNewRow()
        End If
    End Sub



    Private Sub T_Parent_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_Parent.ButtonClick
        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))




            dtSearch = fc_Class.GetParent_Circulation(Dept, Tahun, Bulan)
            ls_OldKode = T_Parent.EditValue
            ls_Judul = "Parent Cisrculation"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As Double = 0

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = Convert.ToDouble(lF_SearchData.Values.Item(1).ToString.Trim)
                T_Parent.EditValue = Value1
                T_ParentAmount.EditValue = Value2.ToString("#,##0.00")
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_Parent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_Parent.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_ParentAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ParentAmount.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_T1_ButtonClick(sender As Object, e As ButtonPressedEventArgs)





    End Sub

    Private Sub T_T1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub T_T2_ButtonClick(sender As Object, e As ButtonPressedEventArgs)



    End Sub

    Private Sub T_PRNumber_ButtonClick(sender As Object, e As ButtonPressedEventArgs)

        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As Double = Convert.ToDouble(Param.ToString("MM"))

            dtSearch = fc_Class.GetPR(DeptSub, Tahun, Bulan)
            'ls_OldKode = T_Account.Text
            ls_Judul = "Budget No"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub T_PRNumber_BindingContextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub C_Currency_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub C_Currency_CursorChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub C_Currency_MouseLeave(sender As Object, e As EventArgs)

    End Sub

    Private Sub C_Currency_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub C_Currency_Leave(sender As Object, e As EventArgs)
    '    Try
    '        If T_RequirementDate.EditValue = Nothing Then

    '            MessageBox.Show("Please Select Requirement Date ",
    '                           "Warning",
    '                           MessageBoxButtons.OK,
    '                           MessageBoxIcon.Exclamation,
    '                           MessageBoxDefaultButton.Button1)

    '        Else

    '            ' Dim Cur As String = C_Currency.EditValue
    '            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
    '            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
    '            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))



    '            Call FillRate(Tahun, Bulan, Cur)
    '        End If

    '    Catch ex As Exception
    '        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

    '    End Try
    'End Sub

    Private Sub T_Account_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid1_Click(sender As Object, e As EventArgs) Handles Grid1.Click

    End Sub

    Private Sub BMold_Click(sender As Object, e As EventArgs) Handles BMold.Click


        CForm = 1

        CallForm()



    End Sub

    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal Nama As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If CForm = 1 Then
            FGetMold = New Frm_CR_Get_Mold(ID, DtGridBarang, Grid1)
            FGetMold.StartPosition = FormStartPosition.CenterScreen
            FGetMold.MaximizeBox = False
            FGetMold.ShowDialog()
        End If



    End Sub

    Private Sub BAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BAccount.ButtonClick

        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))




            dtSearch = fc_Class.GetBudget(DeptSub, Tahun, Bulan)
            'ls_OldKode = T_Account.Text
            ls_Judul = "Budget No"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                'Dim Value21 As Double = Convert.ToDouble(Value2)
                'T_Account.Text = Value1
                If Val(Value2) <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "N")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
                'T_RemainingBudget.EditValue = Value21.ToString("#,##0.00")
                Try
                    Dim ACC_Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
                    Dim Acc_Departemen As String = gh_Common.GroupID
                    Dim Acc_Site As String = gh_Common.Site
                    Dim Acc_NoAccount As String = Value1
                    Dim Acc_Tahun As String = Convert.ToString(ACC_Param.ToString("yyyy"))
                    Dim Acc_Bulan As String = Convert.ToString(ACC_Param.ToString("MM"))

                    Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)

                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)

                    'Call Get_Total_CR_Dept(Acc_Departemen, Acc_Site, Acc_NoAccount, Acc_Tahun)


                    'T_RemainingBudget.EditValue = SisaBudget.ToString("#,##0.00")
                    CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount"))
                    Balance = SisaBudget - CR
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)

                    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Category") <> "N" Then
                        If Balance <= 0 Then
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "O")
                        Else
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                        End If
                    End If





                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub CurrRepository_EditValueChanged(sender As Object, e As EventArgs) Handles CurrRepository.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Try
            If T_RequirementDate.EditValue = Nothing Then

                MessageBox.Show("Please Select Requirement Date ",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

            Else

                Dim Cur As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Curr")
                Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
                Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
                Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

                Call FillRate(Tahun, Bulan, Cur)

                Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty"))
                Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
                Dim Rate As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate"))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", Qty * Price * Rate)

                CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount"))
                SisaBudget = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget"))

                Balance = SisaBudget - CR
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)

            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        End Try

    End Sub

    Private Sub CurrRepository_Leave(sender As Object, e As EventArgs) Handles CurrRepository.Leave

    End Sub

    Private Sub CurrRepository_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles CurrRepository.EditValueChanging

    End Sub
End Class
