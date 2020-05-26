Imports DevExpress.XtraSplashScreen

Public Class frmSales_Price
    Dim ff_Detail As frmSales_Price_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSales_Price
    Private Sub frmSales_Price_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
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
        Dim ls_Judul As String = "Price"
        Dim Bulan As String = ""
        Dim strTtahun As String = ""
        Dim strCustomer As String = ""

        table.Columns.Add("tahun")
        table.Columns.Add("custid")
        table.Columns.Add("customer")
        table.Columns.Add("invtid")
        table.Columns.Add("descr")
        table.Columns.Add("partno")
        table.Columns.Add("model")
        table.Columns.Add("oe_re")
        table.Columns.Add("in_sub")
        table.Columns.Add("site")

        table.Columns.Add("jan_harga01")
        table.Columns.Add("jan_harga02")
        table.Columns.Add("jan_harga03")
        table.Columns.Add("jan_harga04")
        table.Columns.Add("jan_harga05")
        'table.Columns.Add("jan_harga03")

        table.Columns.Add("feb_harga01")
        table.Columns.Add("feb_harga02")
        table.Columns.Add("feb_harga03")
        table.Columns.Add("feb_harga04")
        table.Columns.Add("feb_harga05")
        'table.Columns.Add("feb_harga03")

        table.Columns.Add("mar_harga01")
        table.Columns.Add("mar_harga02")
        table.Columns.Add("mar_harga03")
        table.Columns.Add("mar_harga04")
        table.Columns.Add("mar_harga05")
        'table.Columns.Add("mar_harga03")

        table.Columns.Add("apr_harga01")
        table.Columns.Add("apr_harga02")
        table.Columns.Add("apr_harga03")
        table.Columns.Add("apr_harga04")
        table.Columns.Add("apr_harga05")
        'table.Columns.Add("apr_harga03")

        table.Columns.Add("mei_harga01")
        table.Columns.Add("mei_harga02")
        table.Columns.Add("mei_harga03")
        table.Columns.Add("mei_harga04")
        table.Columns.Add("mei_harga05")
        'table.Columns.Add("mei_harga03")

        table.Columns.Add("jun_harga01")
        table.Columns.Add("jun_harga02")
        table.Columns.Add("jun_harga03")
        table.Columns.Add("jun_harga04")
        table.Columns.Add("jun_harga05")

        'table.Columns.Add("jun_harga03")
        table.Columns.Add("jul_harga01")
        table.Columns.Add("jul_harga02")
        table.Columns.Add("jul_harga03")
        table.Columns.Add("jul_harga04")
        table.Columns.Add("jul_harga05")
        'table.Columns.Add("jul_harga03")
        table.Columns.Add("agt_harga01")
        table.Columns.Add("agt_harga02")
        table.Columns.Add("agt_harga03")
        table.Columns.Add("agt_harga04")
        table.Columns.Add("agt_harga05")
        'table.Columns.Add("agt_harga03")
        table.Columns.Add("sep_harga01")
        table.Columns.Add("sep_harga02")
        table.Columns.Add("sep_harga03")
        table.Columns.Add("sep_harga04")
        table.Columns.Add("sep_harga05")
        'table.Columns.Add("sep_harga03")
        table.Columns.Add("okt_harga01")
        table.Columns.Add("okt_harga02")
        table.Columns.Add("okt_harga03")
        table.Columns.Add("okt_harga04")
        table.Columns.Add("okt_harga05")
        'table.Columns.Add("okt_harga03")
        table.Columns.Add("nov_harga01")
        table.Columns.Add("nov_harga02")
        table.Columns.Add("nov_harga03")
        table.Columns.Add("nov_harga04")
        table.Columns.Add("nov_harga05")
        'table.Columns.Add("nov_harga03")
        table.Columns.Add("des_harga01")
        table.Columns.Add("des_harga02")
        table.Columns.Add("des_harga03")
        table.Columns.Add("des_harga04")
        table.Columns.Add("des_harga05")

        'table.Columns.Add("des_po03")

        Dim frmExcel As FrmSystemExcel1
        frmExcel = New FrmSystemExcel1(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        strTtahun = frmExcel.Tahun
        strCustomer = frmExcel.Customer
        Bulan = frmExcel.Bulan

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            If strCustomer <> "" AndAlso strTtahun <> "" AndAlso Bulan <> "" Then
                dv.RowFilter = "tahun = '" & strTtahun & "' AND custid = '" & strCustomer & "'"
                dtFilter = dv.ToTable
            ElseIf strCustomer = "" AndAlso strTtahun <> "" Then
                dv.RowFilter = "tahun = '" & strTtahun & "'"
                dtFilter = dv.ToTable
            ElseIf strCustomer <> "" AndAlso strTtahun = "" Then
                dv.RowFilter = "custid = '" & strCustomer & "'"
                dtFilter = dv.ToTable
            Else
                dtFilter = dv.ToTable
            End If

            If dtFilter.Rows.Count > 0 Then
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
                            If dtFilter.Rows(i)("customer") Is DBNull.Value OrElse dtFilter.Rows(i)("customer").ToString = "" Then
                                .Customer = ""
                            Else
                                .Customer = dtFilter.Rows(i)("customer").ToString
                            End If
                            If dtFilter.Rows(i)("partno") Is DBNull.Value OrElse dtFilter.Rows(i)("partno").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("partno").ToString
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
                            If dtFilter.Rows(i)("site") Is DBNull.Value OrElse dtFilter.Rows(i)("site").ToString = "" Then
                                .Site = ""
                            Else
                                .Site = dtFilter.Rows(i)("site").ToString
                            End If

                            If dtFilter.Rows(i)("in_sub") Is DBNull.Value OrElse dtFilter.Rows(i)("in_sub").ToString = "" Then
                                .In_Sub = ""
                            Else
                                .In_Sub = dtFilter.Rows(i)("in_sub").ToString
                            End If

                            'Januari
                            If dtFilter.Rows(i)("Jan_harga01").ToString = "" OrElse dtFilter.Rows(i)("Jan_harga01") Is DBNull.Value Then
                                .jan_harga01 = 0
                            Else
                                .jan_harga01 = Single.Parse(dtFilter.Rows(i)("Jan_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_harga02").ToString = "" OrElse dtFilter.Rows(i)("Jan_harga02") Is DBNull.Value Then
                                .jan_harga02 = 0
                            Else
                                .jan_harga02 = Single.Parse(dtFilter.Rows(i)("Jan_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_harga03").ToString = "" OrElse dtFilter.Rows(i)("Jan_harga03") Is DBNull.Value Then
                                .jan_harga03 = 0
                            Else
                                .jan_harga03 = Single.Parse(dtFilter.Rows(i)("Jan_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_harga04").ToString = "" OrElse dtFilter.Rows(i)("Jan_harga04") Is DBNull.Value Then
                                .jan_harga04 = 0
                            Else
                                .jan_harga04 = Single.Parse(dtFilter.Rows(i)("Jan_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("Jan_harga05").ToString = "" OrElse dtFilter.Rows(i)("Jan_harga05") Is DBNull.Value Then
                                .jan_harga05 = 0
                            Else
                                .jan_harga05 = Single.Parse(dtFilter.Rows(i)("Jan_harga05").ToString)
                            End If

                            'Februari
                            If dtFilter.Rows(i)("Feb_harga01").ToString = "" OrElse dtFilter.Rows(i)("Feb_harga01") Is DBNull.Value Then
                                .feb_harga01 = 0
                            Else
                                .feb_harga01 = Single.Parse(dtFilter.Rows(i)("feb_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("feb_harga02").ToString = "" OrElse dtFilter.Rows(i)("feb_harga02") Is DBNull.Value Then
                                .feb_harga02 = 0
                            Else
                                .feb_harga02 = Single.Parse(dtFilter.Rows(i)("feb_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("feb_harga03").ToString = "" OrElse dtFilter.Rows(i)("feb_harga03") Is DBNull.Value Then
                                .feb_harga03 = 0
                            Else
                                .feb_harga03 = Single.Parse(dtFilter.Rows(i)("feb_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("feb_harga04").ToString = "" OrElse dtFilter.Rows(i)("feb_harga04") Is DBNull.Value Then
                                .feb_harga04 = 0
                            Else
                                .feb_harga04 = Single.Parse(dtFilter.Rows(i)("feb_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("feb_harga05").ToString = "" OrElse dtFilter.Rows(i)("feb_harga05") Is DBNull.Value Then
                                .feb_harga05 = 0
                            Else
                                .feb_harga05 = Single.Parse(dtFilter.Rows(i)("feb_harga05").ToString)
                            End If

                            'Maret

                            If dtFilter.Rows(i)("Mar_harga01").ToString = "" OrElse dtFilter.Rows(i)("Mar_harga01") Is DBNull.Value Then
                                .mar_harga01 = 0
                            Else
                                .mar_harga01 = Single.Parse(dtFilter.Rows(i)("Mar_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("mar_harga02").ToString = "" OrElse dtFilter.Rows(i)("mar_harga02") Is DBNull.Value Then
                                .mar_harga02 = 0
                            Else
                                .mar_harga02 = Single.Parse(dtFilter.Rows(i)("mar_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("mar_harga03").ToString = "" OrElse dtFilter.Rows(i)("mar_harga03") Is DBNull.Value Then
                                .mar_harga03 = 0
                            Else
                                .mar_harga03 = Single.Parse(dtFilter.Rows(i)("mar_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("mar_harga04").ToString = "" OrElse dtFilter.Rows(i)("mar_harga04") Is DBNull.Value Then
                                .mar_harga04 = 0
                            Else
                                .mar_harga04 = Single.Parse(dtFilter.Rows(i)("mar_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("mar_harga05").ToString = "" OrElse dtFilter.Rows(i)("mar_harga05") Is DBNull.Value Then
                                .mar_harga05 = 0
                            Else
                                .mar_harga05 = Single.Parse(dtFilter.Rows(i)("mar_harga05").ToString)
                            End If

                            'April

                            If dtFilter.Rows(i)("Apr_harga01").ToString = "" OrElse dtFilter.Rows(i)("Apr_harga01") Is DBNull.Value Then
                                .apr_harga01 = 0
                            Else
                                .apr_harga01 = Single.Parse(dtFilter.Rows(i)("Apr_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("apr_harga02").ToString = "" OrElse dtFilter.Rows(i)("apr_harga02") Is DBNull.Value Then
                                .apr_harga02 = 0
                            Else
                                .apr_harga02 = Single.Parse(dtFilter.Rows(i)("apr_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("apr_harga03").ToString = "" OrElse dtFilter.Rows(i)("apr_harga03") Is DBNull.Value Then
                                .apr_harga03 = 0
                            Else
                                .apr_harga03 = Single.Parse(dtFilter.Rows(i)("apr_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("apr_harga04").ToString = "" OrElse dtFilter.Rows(i)("apr_harga04") Is DBNull.Value Then
                                .apr_harga04 = 0
                            Else
                                .apr_harga04 = Single.Parse(dtFilter.Rows(i)("apr_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("apr_harga05").ToString = "" OrElse dtFilter.Rows(i)("apr_harga05") Is DBNull.Value Then
                                .apr_harga05 = 0
                            Else
                                .apr_harga05 = Single.Parse(dtFilter.Rows(i)("apr_harga05").ToString)
                            End If

                            'Mei
                            If dtFilter.Rows(i)("Mei_harga01").ToString = "" OrElse dtFilter.Rows(i)("Mei_harga01") Is DBNull.Value Then
                                .mei_harga01 = 0
                            Else
                                .mei_harga01 = Single.Parse(dtFilter.Rows(i)("Mei_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("mei_harga02").ToString = "" OrElse dtFilter.Rows(i)("mei_harga02") Is DBNull.Value Then
                                .mei_harga02 = 0
                            Else
                                .mei_harga02 = Single.Parse(dtFilter.Rows(i)("mei_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("mei_harga03").ToString = "" OrElse dtFilter.Rows(i)("mei_harga03") Is DBNull.Value Then
                                .mei_harga03 = 0
                            Else
                                .mei_harga03 = Single.Parse(dtFilter.Rows(i)("mei_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("mei_harga04").ToString = "" OrElse dtFilter.Rows(i)("mei_harga04") Is DBNull.Value Then
                                .mei_harga04 = 0
                            Else
                                .mei_harga04 = Single.Parse(dtFilter.Rows(i)("mei_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("mei_harga05").ToString = "" OrElse dtFilter.Rows(i)("mei_harga05") Is DBNull.Value Then
                                .mei_harga05 = 0
                            Else
                                .mei_harga05 = Single.Parse(dtFilter.Rows(i)("mei_harga05").ToString)
                            End If

                            'Juni

                            If dtFilter.Rows(i)("jun_harga01").ToString = "" OrElse dtFilter.Rows(i)("jun_harga01") Is DBNull.Value Then
                                .jun_harga01 = 0
                            Else
                                .jun_harga01 = Single.Parse(dtFilter.Rows(i)("jun_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("jun_harga02").ToString = "" OrElse dtFilter.Rows(i)("jun_harga02") Is DBNull.Value Then
                                .jun_harga02 = 0
                            Else
                                .jun_harga02 = Single.Parse(dtFilter.Rows(i)("jun_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("jun_harga03").ToString = "" OrElse dtFilter.Rows(i)("jun_harga03") Is DBNull.Value Then
                                .jun_harga03 = 0
                            Else
                                .jun_harga03 = Single.Parse(dtFilter.Rows(i)("jun_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("jun_harga04").ToString = "" OrElse dtFilter.Rows(i)("jun_harga04") Is DBNull.Value Then
                                .jun_harga04 = 0
                            Else
                                .jun_harga04 = Single.Parse(dtFilter.Rows(i)("jun_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("jun_harga05").ToString = "" OrElse dtFilter.Rows(i)("jun_harga05") Is DBNull.Value Then
                                .jun_harga05 = 0
                            Else
                                .jun_harga05 = Single.Parse(dtFilter.Rows(i)("jun_harga05").ToString)
                            End If

                            'Juli

                            If dtFilter.Rows(i)("Jul_harga01").ToString = "" OrElse dtFilter.Rows(i)("Jul_harga01") Is DBNull.Value Then
                                .jul_harga01 = 0
                            Else
                                .jul_harga01 = Single.Parse(dtFilter.Rows(i)("Jul_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("jul_harga02").ToString = "" OrElse dtFilter.Rows(i)("jul_harga02") Is DBNull.Value Then
                                .jul_harga02 = 0
                            Else
                                .jul_harga02 = Single.Parse(dtFilter.Rows(i)("jul_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("jul_harga03").ToString = "" OrElse dtFilter.Rows(i)("jul_harga03") Is DBNull.Value Then
                                .jul_harga03 = 0
                            Else
                                .jul_harga03 = Single.Parse(dtFilter.Rows(i)("jul_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("jul_harga04").ToString = "" OrElse dtFilter.Rows(i)("jul_harga04") Is DBNull.Value Then
                                .jul_harga04 = 0
                            Else
                                .jul_harga04 = Single.Parse(dtFilter.Rows(i)("jul_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("jul_harga05").ToString = "" OrElse dtFilter.Rows(i)("jul_harga05") Is DBNull.Value Then
                                .jul_harga05 = 0
                            Else
                                .jul_harga05 = Single.Parse(dtFilter.Rows(i)("jul_harga05").ToString)
                            End If

                            'Agustus
                            If dtFilter.Rows(i)("Agt_harga01").ToString = "" OrElse dtFilter.Rows(i)("Agt_harga01") Is DBNull.Value Then
                                .agt_harga01 = 0
                            Else
                                .agt_harga01 = Single.Parse(dtFilter.Rows(i)("Agt_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("agt_harga02").ToString = "" OrElse dtFilter.Rows(i)("agt_harga02") Is DBNull.Value Then
                                .agt_harga02 = 0
                            Else
                                .agt_harga02 = Single.Parse(dtFilter.Rows(i)("agt_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("agt_harga03").ToString = "" OrElse dtFilter.Rows(i)("agt_harga03") Is DBNull.Value Then
                                .agt_harga03 = 0
                            Else
                                .agt_harga03 = Single.Parse(dtFilter.Rows(i)("agt_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("agt_harga04").ToString = "" OrElse dtFilter.Rows(i)("agt_harga04") Is DBNull.Value Then
                                .agt_harga04 = 0
                            Else
                                .agt_harga04 = Single.Parse(dtFilter.Rows(i)("agt_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("agt_harga05").ToString = "" OrElse dtFilter.Rows(i)("agt_harga05") Is DBNull.Value Then
                                .agt_harga05 = 0
                            Else
                                .agt_harga05 = Single.Parse(dtFilter.Rows(i)("agt_harga05").ToString)
                            End If

                            'September
                            If dtFilter.Rows(i)("Sep_harga01").ToString = "" OrElse dtFilter.Rows(i)("Sep_harga01") Is DBNull.Value Then
                                .sep_harga01 = 0
                            Else
                                .sep_harga01 = Single.Parse(dtFilter.Rows(i)("Sep_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("sep_harga02").ToString = "" OrElse dtFilter.Rows(i)("sep_harga02") Is DBNull.Value Then
                                .sep_harga02 = 0
                            Else
                                .sep_harga02 = Single.Parse(dtFilter.Rows(i)("sep_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("sep_harga03").ToString = "" OrElse dtFilter.Rows(i)("sep_harga03") Is DBNull.Value Then
                                .sep_harga03 = 0
                            Else
                                .sep_harga03 = Single.Parse(dtFilter.Rows(i)("sep_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("sep_harga04").ToString = "" OrElse dtFilter.Rows(i)("sep_harga04") Is DBNull.Value Then
                                .sep_harga04 = 0
                            Else
                                .sep_harga04 = Single.Parse(dtFilter.Rows(i)("sep_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("sep_harga05").ToString = "" OrElse dtFilter.Rows(i)("sep_harga05") Is DBNull.Value Then
                                .sep_harga05 = 0
                            Else
                                .sep_harga05 = Single.Parse(dtFilter.Rows(i)("sep_harga05").ToString)
                            End If

                            'Okoteber
                            If dtFilter.Rows(i)("Okt_harga01").ToString = "" OrElse dtFilter.Rows(i)("Okt_harga01") Is DBNull.Value Then
                                .okt_harga01 = 0
                            Else
                                .okt_harga01 = Single.Parse(dtFilter.Rows(i)("Okt_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("okt_harga02").ToString = "" OrElse dtFilter.Rows(i)("okt_harga02") Is DBNull.Value Then
                                .okt_harga02 = 0
                            Else
                                .okt_harga02 = Single.Parse(dtFilter.Rows(i)("okt_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("okt_harga03").ToString = "" OrElse dtFilter.Rows(i)("okt_harga03") Is DBNull.Value Then
                                .okt_harga03 = 0
                            Else
                                .okt_harga03 = Single.Parse(dtFilter.Rows(i)("okt_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("okt_harga04").ToString = "" OrElse dtFilter.Rows(i)("okt_harga04") Is DBNull.Value Then
                                .okt_harga04 = 0
                            Else
                                .okt_harga04 = Single.Parse(dtFilter.Rows(i)("okt_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("okt_harga05").ToString = "" OrElse dtFilter.Rows(i)("okt_harga05") Is DBNull.Value Then
                                .okt_harga05 = 0
                            Else
                                .okt_harga05 = Single.Parse(dtFilter.Rows(i)("okt_harga05").ToString)
                            End If

                            'November 
                            If dtFilter.Rows(i)("Nov_harga01").ToString = "" OrElse dtFilter.Rows(i)("Nov_harga01") Is DBNull.Value Then
                                .nov_harga01 = 0
                            Else
                                .nov_harga01 = Single.Parse(dtFilter.Rows(i)("Nov_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("nov_harga02").ToString = "" OrElse dtFilter.Rows(i)("nov_harga02") Is DBNull.Value Then
                                .nov_harga02 = 0
                            Else
                                .nov_harga02 = Single.Parse(dtFilter.Rows(i)("nov_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("nov_harga03").ToString = "" OrElse dtFilter.Rows(i)("nov_harga03") Is DBNull.Value Then
                                .nov_harga03 = 0
                            Else
                                .nov_harga03 = Single.Parse(dtFilter.Rows(i)("nov_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("nov_harga04").ToString = "" OrElse dtFilter.Rows(i)("nov_harga04") Is DBNull.Value Then
                                .nov_harga04 = 0
                            Else
                                .nov_harga04 = Single.Parse(dtFilter.Rows(i)("nov_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("nov_harga05").ToString = "" OrElse dtFilter.Rows(i)("nov_harga05") Is DBNull.Value Then
                                .nov_harga05 = 0
                            Else
                                .nov_harga05 = Single.Parse(dtFilter.Rows(i)("nov_harga05").ToString)
                            End If

                            'Desember
                            If dtFilter.Rows(i)("Des_harga01").ToString = "" OrElse dtFilter.Rows(i)("Des_harga01") Is DBNull.Value Then
                                .des_harga01 = 0
                            Else
                                .des_harga01 = Single.Parse(dtFilter.Rows(i)("Des_harga01").ToString)
                            End If
                            If dtFilter.Rows(i)("des_harga02").ToString = "" OrElse dtFilter.Rows(i)("des_harga02") Is DBNull.Value Then
                                .des_harga02 = 0
                            Else
                                .des_harga02 = Single.Parse(dtFilter.Rows(i)("des_harga02").ToString)
                            End If
                            If dtFilter.Rows(i)("des_harga03").ToString = "" OrElse dtFilter.Rows(i)("des_harga03") Is DBNull.Value Then
                                .des_harga03 = 0
                            Else
                                .des_harga03 = Single.Parse(dtFilter.Rows(i)("des_harga03").ToString)
                            End If
                            If dtFilter.Rows(i)("des_harga04").ToString = "" OrElse dtFilter.Rows(i)("des_harga04") Is DBNull.Value Then
                                .des_harga04 = 0
                            Else
                                .des_harga04 = Single.Parse(dtFilter.Rows(i)("des_harga04").ToString)
                            End If
                            If dtFilter.Rows(i)("des_harga05").ToString = "" OrElse dtFilter.Rows(i)("des_harga05") Is DBNull.Value Then
                                .des_harga05 = 0
                            Else
                                .des_harga05 = Single.Parse(dtFilter.Rows(i)("des_harga05").ToString)
                            End If

                            Dim IsExist = .ValidateUpdate
                            If IsExist Then
                                .Update_New(Bulan)
                            Else
                                .Insert_New(Bulan)
                            End If
                            '.Delete_byTahun()
                            '.Insert()

                        End With

                    Catch ex As Exception
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        WriteSalesToErrorLog("SalesPrice", "Log", dtFilter, i, "invtid", gh_Common.Username)
                        Continue For
                    End Try
                Next
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
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
        ff_Detail = New frmSales_Price_detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = frmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As Integer = 0
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
    Private Sub frmSales_Price_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim invtID = String.Empty
        Dim ID As Integer = 0
        Try
            If e.KeyCode = Keys.F1 Then


                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                        ID = GridView1.GetRowCellValue(rowHandle, "id")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             invtID,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Dim invtID = String.Empty
        Dim ID As Integer = 0
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(ID,
                         invtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
