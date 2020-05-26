Imports DevExpress.XtraSplashScreen

Public Class frmSales_Forecast
    Dim ff_Detail As frmSales_Forecast_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSales_Forecast
    Private Sub frmSales_Forecast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        'AturGrid(Grid, Me)
        'ProgressBar1.Location = New Point(500, 500)
        'CenterControl()
        'ProgressBar1.Visible = False
    End Sub
    Private Sub CenterControl()
        'ProgressBar1.Top = (Me.ClientSize.Height / 2) - (ProgressBar1.Height / 2)
        'ProgressBar1.Left = (Me.ClientSize.Width / 2) - (ProgressBar1.Width / 2)
    End Sub
    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            dtGrid = fc_Class.GetAllDataGrid(bs_Filter)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Forecast"
        Dim strTtahun As String = ""
        Dim strCustomer As String = ""

        'table.Columns.Add("tahun", GetType(String))
        'table.Columns.Add("custid", GetType(String))
        'table.Columns.Add("customer", GetType(String))
        'table.Columns.Add("invtid", GetType(String))
        'table.Columns.Add("descr", GetType(String))
        'table.Columns.Add("partno", GetType(String))
        'table.Columns.Add("model", GetType(String))
        'table.Columns.Add("oe_re", GetType(String))
        'table.Columns.Add("in_sub", GetType(String))
        'table.Columns.Add("site", GetType(String))

        'table.Columns.Add("jan_qty01", GetType(Single))
        'table.Columns.Add("jan_qty02", GetType(Single))
        'table.Columns.Add("jan_qty03", GetType(Single))
        'table.Columns.Add("jan_po01", GetType(Single))
        'table.Columns.Add("jan_po02", GetType(Single))
        'table.Columns.Add("jan_po03", GetType(Single))

        'table.Columns.Add("feb_qty01", GetType(Single))
        'table.Columns.Add("feb_qty02", GetType(Single))
        'table.Columns.Add("feb_qty03", GetType(Single))
        'table.Columns.Add("feb_po01", GetType(Single))
        'table.Columns.Add("feb_po02", GetType(Single))
        'table.Columns.Add("feb_po03", GetType(Single))

        'table.Columns.Add("mar_qty01", GetType(Single))
        'table.Columns.Add("mar_qty02", GetType(Single))
        'table.Columns.Add("mar_qty03", GetType(Single))
        'table.Columns.Add("mar_po01", GetType(Single))
        'table.Columns.Add("mar_po02", GetType(Single))
        'table.Columns.Add("mar_po03", GetType(Single))

        'table.Columns.Add("apr_qty01", GetType(Single))
        'table.Columns.Add("apr_qty02", GetType(Single))
        'table.Columns.Add("apr_qty03", GetType(Single))
        'table.Columns.Add("apr_po01", GetType(Single))
        'table.Columns.Add("apr_po02", GetType(Single))
        'table.Columns.Add("apr_po03", GetType(Single))

        'table.Columns.Add("mei_qty01", GetType(Single))
        'table.Columns.Add("mei_qty02", GetType(Single))
        'table.Columns.Add("mei_qty03", GetType(Single))
        'table.Columns.Add("mei_po01", GetType(Single))
        'table.Columns.Add("mei_po02", GetType(Single))
        'table.Columns.Add("mei_po03", GetType(Single))

        'table.Columns.Add("jun_qty01", GetType(Single))
        'table.Columns.Add("jun_qty02", GetType(Single))
        'table.Columns.Add("jun_qty03", GetType(Single))
        'table.Columns.Add("jun_po01", GetType(Single))
        'table.Columns.Add("jun_po02", GetType(Single))
        'table.Columns.Add("jun_po03", GetType(Single))

        'table.Columns.Add("jul_qty01", GetType(Single))
        'table.Columns.Add("jul_qty02", GetType(Single))
        'table.Columns.Add("jul_qty03", GetType(Single))
        'table.Columns.Add("jul_po01", GetType(Single))
        'table.Columns.Add("jul_po02", GetType(Single))
        'table.Columns.Add("jul_po03", GetType(Single))

        'table.Columns.Add("agt_qty01", GetType(Single))
        'table.Columns.Add("agt_qty02", GetType(Single))
        'table.Columns.Add("agt_qty03", GetType(Single))
        'table.Columns.Add("agt_po01", GetType(Single))
        'table.Columns.Add("agt_po02", GetType(Single))
        'table.Columns.Add("agt_po03", GetType(Single))

        'table.Columns.Add("sep_qty01", GetType(Single))
        'table.Columns.Add("sep_qty02", GetType(Single))
        'table.Columns.Add("sep_qty03", GetType(Single))
        'table.Columns.Add("sep_po01", GetType(Single))
        'table.Columns.Add("sep_po02", GetType(Single))
        'table.Columns.Add("sep_po03", GetType(Single))

        'table.Columns.Add("okt_qty01", GetType(Single))
        'table.Columns.Add("okt_qty02", GetType(Single))
        'table.Columns.Add("okt_qty03", GetType(Single))
        'table.Columns.Add("okt_po01", GetType(Single))
        'table.Columns.Add("okt_po02", GetType(Single))
        'table.Columns.Add("okt_po03", GetType(Single))

        'table.Columns.Add("nov_qty01", GetType(Single))
        'table.Columns.Add("nov_qty02", GetType(Single))
        'table.Columns.Add("nov_qty03", GetType(Single))
        'table.Columns.Add("nov_po01", GetType(Single))
        'table.Columns.Add("nov_po02", GetType(Single))
        'table.Columns.Add("nov_po03", GetType(Single))

        'table.Columns.Add("des_qty01", GetType(Single))
        'table.Columns.Add("des_qty02", GetType(Single))
        'table.Columns.Add("des_qty03", GetType(Single))
        'table.Columns.Add("des_po01", GetType(Single))
        'table.Columns.Add("des_po02", GetType(Single))

        'table.Columns.Add("des_po03")

        Dim frmExcel As FrmSystemExcel
        frmExcel = New FrmSystemExcel(table, 69)
        frmExcel.Text = "Upload " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        strTtahun = frmExcel.Tahun

        Try
            'Cursor = Cursors.WaitCursor
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            If strTtahun <> "" Then
                dv.RowFilter = "tahun = '" & strTtahun & "'"
                dtFilter = dv.ToTable
            Else
                dtFilter = dv.ToTable
            End If

            If dtFilter.Rows.Count > 0 Then
                fc_Class.DeleteByTahun()
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    Try
                        With fc_Class
                            If dtFilter.Rows(i)("tahun") Is DBNull.Value OrElse dtFilter.Rows(i)("tahun").ToString = "" Then
                                .Tahun = ""
                            Else
                                .Tahun = dtFilter.Rows(i)("tahun").ToString
                            End If
                            If dtFilter.Rows(i)("custid") Is DBNull.Value OrElse dtFilter.Rows(i)("custid").ToString = "" Then
                                .CustomerId = ""
                            Else
                                .CustomerId = dtFilter.Rows(i)("custid").ToString
                            End If
                            If dtFilter.Rows(i)("customer") Is DBNull.Value OrElse dtFilter.Rows(i)("customer").ToString = "" Then
                                .Customer = ""
                            Else
                                .Customer = dtFilter.Rows(i)("customer").ToString
                            End If
                            If dtFilter.Rows(i)("invtid") Is DBNull.Value OrElse dtFilter.Rows(i)("invtid").ToString = "" Then
                                .InvtId = ""
                            Else
                                .InvtId = dtFilter.Rows(i)("invtid").ToString
                            End If

                            If dtFilter.Rows(i)("descr") Is DBNull.Value OrElse dtFilter.Rows(i)("descr").ToString = "" Then
                                .Descr = ""
                            Else
                                .Descr = dtFilter.Rows(i)("descr").ToString
                            End If
                            If dtFilter.Rows(i)("partno") Is DBNull.Value OrElse dtFilter.Rows(i)("partno").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("partno").ToString
                            End If
                            If dtFilter.Rows(i)("model") Is DBNull.Value OrElse dtFilter.Rows(i)("model").ToString = "" Then
                                .Model = ""
                            Else
                                .Model = dtFilter.Rows(i)("model").ToString
                            End If
                            If dtFilter.Rows(i)("oe_re") Is DBNull.Value OrElse dtFilter.Rows(i)("oe_re").ToString = "" Then
                                .Oe_Re = ""
                            Else
                                .Oe_Re = dtFilter.Rows(i)("oe_re").ToString
                            End If

                            If dtFilter.Rows(i)("in_sub") Is DBNull.Value OrElse dtFilter.Rows(i)("in_sub").ToString = "" Then
                                .In_Sub = ""
                            Else
                                .In_Sub = dtFilter.Rows(i)("in_sub").ToString
                            End If
                            If dtFilter.Rows(i)("site") Is DBNull.Value OrElse dtFilter.Rows(i)("site").ToString = "" Then
                                .Site = ""
                            Else
                                .Site = dtFilter.Rows(i)("site").ToString
                            End If

                            '===================== Januari ==================
                            If dtFilter.Rows(i)("Jan_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Jan_Qty01") Is DBNull.Value Then
                                .Jan_Qty01 = 0
                            Else
                                .Jan_Qty01 = Int32.Parse(dtFilter.Rows(i)("Jan_Qty01").ToString)
                            End If

                            If dtFilter.Rows(i)("Jan_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Jan_Qty02") Is DBNull.Value Then
                                .Jan_Qty02 = 0
                            Else
                                .Jan_Qty02 = Int32.Parse(dtFilter.Rows(i)("Jan_Qty02").ToString)
                            End If

                            If dtFilter.Rows(i)("Jan_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Jan_Qty03") Is DBNull.Value Then
                                .Jan_Qty03 = 0
                            Else
                                .Jan_Qty03 = Int32.Parse(dtFilter.Rows(i)("Jan_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_po01").ToString = "" OrElse dtFilter.Rows(i)("Jan_po01") Is DBNull.Value Then
                                .Jan_PO01 = 0
                            Else
                                .Jan_PO01 = Int32.Parse(dtFilter.Rows(i)("Jan_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_po02").ToString = "" OrElse dtFilter.Rows(i)("Jan_po02") Is DBNull.Value Then
                                .Jan_PO02 = 0
                            Else
                                .Jan_PO02 = Int32.Parse(dtFilter.Rows(i)("Jan_po02").ToString)
                            End If

                            '===================== Februari ==================
                            If dtFilter.Rows(i)("Feb_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Feb_Qty01") Is DBNull.Value Then
                                .Feb_Qty01 = 0
                            Else
                                .Feb_Qty01 = Int32.Parse(dtFilter.Rows(i)("Feb_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Feb_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Feb_Qty02") Is DBNull.Value Then
                                .Feb_Qty02 = 0
                            Else
                                .Feb_Qty02 = Int32.Parse(dtFilter.Rows(i)("Feb_Qty02").ToString)
                            End If

                            If dtFilter.Rows(i)("Feb_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Feb_Qty03") Is DBNull.Value Then
                                .Feb_Qty03 = 0
                            Else
                                .Feb_Qty03 = Int32.Parse(dtFilter.Rows(i)("Feb_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Feb_po01").ToString = "" OrElse dtFilter.Rows(i)("Feb_po01") Is DBNull.Value Then
                                .Feb_PO01 = 0
                            Else
                                .Feb_PO01 = Int32.Parse(dtFilter.Rows(i)("Feb_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Feb_po02").ToString = "" OrElse dtFilter.Rows(i)("Feb_po02") Is DBNull.Value Then
                                .Feb_PO02 = 0
                            Else
                                .Feb_PO02 = Int32.Parse(dtFilter.Rows(i)("Feb_po02").ToString)
                            End If

                            '===================== Maret ==================
                            If dtFilter.Rows(i)("Mar_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Mar_Qty01") Is DBNull.Value Then
                                .Mar_Qty01 = 0
                            Else
                                .Mar_Qty01 = Int32.Parse(dtFilter.Rows(i)("Mar_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Mar_Qty02") Is DBNull.Value Then
                                .Mar_Qty02 = 0
                            Else
                                .Mar_Qty02 = Int32.Parse(dtFilter.Rows(i)("Mar_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Mar_Qty03") Is DBNull.Value Then
                                .Mar_Qty03 = 0
                            Else
                                .Mar_Qty03 = Int32.Parse(dtFilter.Rows(i)("Mar_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar_po01").ToString = "" OrElse dtFilter.Rows(i)("Mar_po01") Is DBNull.Value Then
                                .Mar_PO01 = 0
                            Else
                                .Mar_PO01 = Int32.Parse(dtFilter.Rows(i)("Mar_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar_po02").ToString = "" OrElse dtFilter.Rows(i)("Mar_po02") Is DBNull.Value Then
                                .Mar_PO02 = 0
                            Else
                                .Mar_PO02 = Int32.Parse(dtFilter.Rows(i)("Mar_po02").ToString)
                            End If

                            '===================== April ==================
                            If dtFilter.Rows(i)("Apr_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Apr_Qty01") Is DBNull.Value Then
                                .Apr_Qty01 = 0
                            Else
                                .Apr_Qty01 = Int32.Parse(dtFilter.Rows(i)("Apr_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Apr_Qty03") Is DBNull.Value Then
                                .Apr_Qty03 = 0
                            Else
                                .Apr_Qty03 = Int32.Parse(dtFilter.Rows(i)("Apr_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Apr_Qty02") Is DBNull.Value Then
                                .Apr_Qty02 = 0
                            Else
                                .Apr_Qty02 = Int32.Parse(dtFilter.Rows(i)("Apr_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr_po01").ToString = "" OrElse dtFilter.Rows(i)("Apr_po01") Is DBNull.Value Then
                                .Apr_PO01 = 0
                            Else
                                .Apr_PO01 = Int32.Parse(dtFilter.Rows(i)("Apr_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr_po02").ToString = "" OrElse dtFilter.Rows(i)("Apr_po02") Is DBNull.Value Then
                                .Apr_PO02 = 0
                            Else
                                .Apr_PO02 = Int32.Parse(dtFilter.Rows(i)("Apr_po02").ToString)
                            End If

                            '===================== Mei ==================
                            If dtFilter.Rows(i)("Mei_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Mei_Qty01") Is DBNull.Value Then
                                .Mei_Qty01 = 0
                            Else
                                .Mei_Qty01 = Int32.Parse(dtFilter.Rows(i)("Mei_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Mei_Qty02") Is DBNull.Value Then
                                .Mei_Qty02 = 0
                            Else
                                .Mei_Qty02 = Int32.Parse(dtFilter.Rows(i)("Mei_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Mei_Qty03") Is DBNull.Value Then
                                .Mei_Qty03 = 0
                            Else
                                .Mei_Qty03 = Int32.Parse(dtFilter.Rows(i)("Mei_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei_po01").ToString = "" OrElse dtFilter.Rows(i)("Mei_po01") Is DBNull.Value Then
                                .Mei_PO01 = 0
                            Else
                                .Mei_PO01 = Int32.Parse(dtFilter.Rows(i)("Mei_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei_po02").ToString = "" OrElse dtFilter.Rows(i)("Mei_po02") Is DBNull.Value Then
                                .Mei_PO02 = 0
                            Else
                                .Mei_PO02 = Int32.Parse(dtFilter.Rows(i)("Mei_po02").ToString)
                            End If

                            '===================== Juni ==================
                            If dtFilter.Rows(i)("Jun_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Jun_Qty01") Is DBNull.Value Then
                                .Jun_Qty01 = 0
                            Else
                                .Jun_Qty01 = Int32.Parse(dtFilter.Rows(i)("Jun_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jun_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Jun_Qty02") Is DBNull.Value Then
                                .Jun_Qty02 = 0
                            Else
                                .Jun_Qty02 = Int32.Parse(dtFilter.Rows(i)("Jun_Qty02").ToString)
                            End If

                            If dtFilter.Rows(i)("Jun_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Jun_Qty03") Is DBNull.Value Then
                                .Jun_Qty03 = 0
                            Else
                                .Jun_Qty03 = Int32.Parse(dtFilter.Rows(i)("Jun_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Jun_po01").ToString = "" OrElse dtFilter.Rows(i)("Jun_po01") Is DBNull.Value Then
                                .Jun_PO01 = 0
                            Else
                                .Jun_PO01 = Int32.Parse(dtFilter.Rows(i)("Jun_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jun_po02").ToString = "" OrElse dtFilter.Rows(i)("Jun_po02") Is DBNull.Value Then
                                .Jun_PO02 = 0
                            Else
                                .Jun_PO02 = Int32.Parse(dtFilter.Rows(i)("Jun_po02").ToString)
                            End If

                            '===================== Juli ==================
                            If dtFilter.Rows(i)("Jul_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Jul_Qty01") Is DBNull.Value Then
                                .Jul_Qty01 = 0
                            Else
                                .Jul_Qty01 = Int32.Parse(dtFilter.Rows(i)("Jul_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Jul_Qty02") Is DBNull.Value Then
                                .Jul_Qty02 = 0
                            Else
                                .Jul_Qty02 = Int32.Parse(dtFilter.Rows(i)("Jul_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Jul_Qty03") Is DBNull.Value Then
                                .Jul_Qty03 = 0
                            Else
                                .Jul_Qty03 = Int32.Parse(dtFilter.Rows(i)("Jul_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul_po01").ToString = "" OrElse dtFilter.Rows(i)("Jul_po01") Is DBNull.Value Then
                                .Jul_PO01 = 0
                            Else
                                .Jul_PO01 = Int32.Parse(dtFilter.Rows(i)("Jul_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul_po02").ToString = "" OrElse dtFilter.Rows(i)("Jul_po02") Is DBNull.Value Then
                                .Jul_PO02 = 0
                            Else
                                .Jul_PO02 = Int32.Parse(dtFilter.Rows(i)("Jul_po02").ToString)
                            End If

                            '===================== Agustus ==================
                            If dtFilter.Rows(i)("Agt_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Agt_Qty01") Is DBNull.Value Then
                                .Agt_Qty01 = 0
                            Else
                                .Agt_Qty01 = Int32.Parse(dtFilter.Rows(i)("Agt_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Agt_Qty02") Is DBNull.Value Then
                                .Agt_Qty02 = 0
                            Else
                                .Agt_Qty02 = Int32.Parse(dtFilter.Rows(i)("Agt_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Agt_Qty03") Is DBNull.Value Then
                                .Agt_Qty03 = 0
                            Else
                                .Agt_Qty03 = Int32.Parse(dtFilter.Rows(i)("Agt_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt_po01").ToString = "" OrElse dtFilter.Rows(i)("Agt_po01") Is DBNull.Value Then
                                .Agt_PO01 = 0
                            Else
                                .Agt_PO01 = Int32.Parse(dtFilter.Rows(i)("Agt_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt_po02").ToString = "" OrElse dtFilter.Rows(i)("Agt_po02") Is DBNull.Value Then
                                .Agt_PO02 = 0
                            Else
                                .Agt_PO02 = Int32.Parse(dtFilter.Rows(i)("Agt_po02").ToString)
                            End If

                            '===================== September ==================
                            If dtFilter.Rows(i)("Sep_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Sep_Qty01") Is DBNull.Value Then
                                .Sep_Qty01 = 0
                            Else
                                .Sep_Qty01 = Int32.Parse(dtFilter.Rows(i)("Sep_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Sep_Qty02") Is DBNull.Value Then
                                .Sep_Qty02 = 0
                            Else
                                .Sep_Qty02 = Int32.Parse(dtFilter.Rows(i)("Sep_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Sep_Qty03") Is DBNull.Value Then
                                .Sep_Qty03 = 0
                            Else
                                .Sep_Qty03 = Int32.Parse(dtFilter.Rows(i)("Sep_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep_po01").ToString = "" OrElse dtFilter.Rows(i)("Sep_po01") Is DBNull.Value Then
                                .Sep_PO01 = 0
                            Else
                                .Sep_PO01 = Int32.Parse(dtFilter.Rows(i)("Sep_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep_po02").ToString = "" OrElse dtFilter.Rows(i)("Sep_po02") Is DBNull.Value Then
                                .Sep_PO02 = 0
                            Else
                                .Sep_PO02 = Int32.Parse(dtFilter.Rows(i)("Sep_po02").ToString)
                            End If

                            '===================== Oktober ==================
                            If dtFilter.Rows(i)("Okt_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Okt_Qty01") Is DBNull.Value Then
                                .Okt_Qty01 = 0
                            Else
                                .Okt_Qty01 = Int32.Parse(dtFilter.Rows(i)("Okt_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Okt_Qty02") Is DBNull.Value Then
                                .Okt_Qty02 = 0
                            Else
                                .Okt_Qty02 = Int32.Parse(dtFilter.Rows(i)("Okt_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Okt_Qty03") Is DBNull.Value Then
                                .Okt_Qty03 = 0
                            Else
                                .Okt_Qty03 = Int32.Parse(dtFilter.Rows(i)("Okt_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt_po01").ToString = "" OrElse dtFilter.Rows(i)("Okt_po01") Is DBNull.Value Then
                                .Okt_PO01 = 0
                            Else
                                .Okt_PO01 = Int32.Parse(dtFilter.Rows(i)("Okt_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt_po02").ToString = "" OrElse dtFilter.Rows(i)("Okt_po02") Is DBNull.Value Then
                                .Okt_PO02 = 0
                            Else
                                .Okt_PO02 = Int32.Parse(dtFilter.Rows(i)("Okt_po02").ToString)
                            End If
                            '===================== November ==================
                            If dtFilter.Rows(i)("Nov_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Nov_Qty01") Is DBNull.Value Then
                                .Nov_Qty01 = 0
                            Else
                                .Nov_Qty01 = Int32.Parse(dtFilter.Rows(i)("Nov_Qty01").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Nov_Qty02") Is DBNull.Value Then
                                .Nov_Qty02 = 0
                            Else
                                .Nov_Qty02 = Int32.Parse(dtFilter.Rows(i)("Nov_Qty02").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Nov_Qty03") Is DBNull.Value Then
                                .Nov_Qty03 = 0
                            Else
                                .Nov_Qty03 = Int32.Parse(dtFilter.Rows(i)("Nov_Qty03").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov_po01").ToString = "" OrElse dtFilter.Rows(i)("Nov_po01") Is DBNull.Value Then
                                .Nov_PO01 = 0
                            Else
                                .Nov_PO01 = Int32.Parse(dtFilter.Rows(i)("Nov_po01").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov_po02").ToString = "" OrElse dtFilter.Rows(i)("Nov_po02") Is DBNull.Value Then
                                .Nov_PO02 = 0
                            Else
                                .Nov_PO02 = Int32.Parse(dtFilter.Rows(i)("Nov_po02").ToString)
                            End If

                            '===================== Desember ==================
                            If dtFilter.Rows(i)("Des_Qty01").ToString = "" OrElse dtFilter.Rows(i)("Des_Qty01") Is DBNull.Value Then
                                .Des_Qty01 = 0
                            Else
                                .Des_Qty01 = Int32.Parse(dtFilter.Rows(i)("Des_Qty01").ToString)
                            End If

                            If dtFilter.Rows(i)("Des_Qty02").ToString = "" OrElse dtFilter.Rows(i)("Des_Qty02") Is DBNull.Value Then
                                .Des_Qty02 = 0
                            Else
                                .Des_Qty02 = Int32.Parse(dtFilter.Rows(i)("Des_Qty02").ToString)
                            End If

                            If dtFilter.Rows(i)("Des_Qty03").ToString = "" OrElse dtFilter.Rows(i)("Des_Qty03") Is DBNull.Value Then
                                .Des_Qty03 = 0
                            Else
                                .Des_Qty03 = Int32.Parse(dtFilter.Rows(i)("Des_Qty03").ToString)
                            End If

                            If dtFilter.Rows(i)("Des_po01").ToString = "" OrElse dtFilter.Rows(i)("Des_po01") Is DBNull.Value Then
                                .Des_PO01 = 0
                            Else
                                .Des_PO01 = Int32.Parse(dtFilter.Rows(i)("Des_po01").ToString)
                            End If

                            If dtFilter.Rows(i)("Des_po02").ToString = "" OrElse dtFilter.Rows(i)("Des_po02") Is DBNull.Value Then
                                .Des_PO02 = 0
                            Else
                                .Des_PO02 = Int32.Parse(dtFilter.Rows(i)("Des_po02").ToString)
                            End If


                            .Insert()

                        End With

                    Catch ex As Exception
                        'MsgBox(ex.Message)
                        Console.WriteLine(ex.Message)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        WriteSalesToErrorLog("Forecast", "Log", dtFilter, i, "invtid", gh_Common.Username)
                        Continue For
                    End Try
                Next
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                'ProgressBar1.Visible = False
                'Cursor = Cursors.Default
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'Cursor = Cursors.Default
            'ProgressBar1.Visible = False
        End Try
    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Forecast"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            'Grid.all = False
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmSales_Forecast_detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = frmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle
            fc_Class.ID = ID
            fc_Class.Delete()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
            'Grid.RemoveItem(Grid.Row)
            'If Grid.Rows.Count > Grid.Rows.Fixed Then
            '    Call Proc_EnableButtons(True, False, True, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(True, False, False, True, True, True, False, False)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim InvtID As String
    Dim ID As Integer
    Private Sub frmSales_Forecast_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                InvtID = String.Empty
                ID = 0
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        InvtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                        ID = GridView1.GetRowCellValue(rowHandle, "id")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             InvtID,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSales_Forecast_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterControl()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            InvtID = String.Empty
            ID = 0
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    InvtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(ID,
                         InvtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
