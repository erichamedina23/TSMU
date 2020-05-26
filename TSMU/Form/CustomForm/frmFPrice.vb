Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraSplashScreen
Public Class frmFPrice
    Dim ObjCommon As CommonModel

    Dim ObjForecast As New forecast_price_models
    Dim ObjHeader As New forecast_price_models_header
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        TForecastPrice1TableAdapter.Connection.ConnectionString = GetConnString()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TForecastPrice1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TForecastPrice1BindingNavigatorSaveItem.Click

        Try
            Me.Validate()
            Me.TForecastPrice1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.DataSet1)
            Me.TForecastPrice1TableAdapter.Fill(DataSet1.tForecastPrice1)
            MsgBox("Data Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub frmFPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.tForecastPrice1' table. You can move, or remove it, as needed.
        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
        With GridView1
            .BestFitColumns()

            .Columns("Id").Visible = False

            .FixedLineWidth = 2
            .Columns("Tahun").Fixed = Columns.FixedStyle.Left
            .Columns(2).Fixed = Columns.FixedStyle.Left
            .Columns(3).Fixed = Columns.FixedStyle.Left
            .Columns(4).Fixed = Columns.FixedStyle.Left
            .Columns(5).Fixed = Columns.FixedStyle.Left
            .Columns(6).Fixed = Columns.FixedStyle.Left
            '.OptionsView.ShowFooter = True
            '.OptionsBehavior.Editable = False
        End With
        SetEditColumnGrid()
        FillComboBulan()
    End Sub
    Private Sub FillComboBulan()
        Dim Bulan() As String = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"}
        cmbBulan.Items.Clear()
        For Each var As String In Bulan
            cmbBulan.Items.Add(var)
        Next
    End Sub
    Private Sub SetEditColumnGrid()
        Try
            Dim cmbCustID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInvtID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbSite As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbOE As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbFlag As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInhouse As RepositoryItemComboBox = New RepositoryItemComboBox()

            AddHandler cmbCustID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInvtID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbSite.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbOE.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbFlag.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInhouse.EditValueChanged, AddressOf ComboBox_EditValueChanged

            ObjCommon = New CommonModel
            Dim dt As New DataTable
            dt = ObjCommon.GeCustID
            cmbCustID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbCustID.Items.Add(dt.Rows(i).Item("CustId").ToString())
            Next
            GridView1.Columns("CustID").ColumnEdit = cmbCustID
            TForecastPrice1GridControl.RepositoryItems.Add(cmbCustID)

            dt = New DataTable
            dt = ObjCommon.GetInvtID
            cmbInvtID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbInvtID.Items.Add(dt.Rows(i).Item("InvtID").ToString())
            Next
            cmbOE.Items.AddRange(New String() {"OE", "PE"})
            cmbSite.Items.AddRange(New String() {"TNG-U", "TSC3-U"})
            cmbFlag.Items.AddRange(New String() {"N/A", "KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"})
            cmbInhouse.Items.AddRange(New String() {"Inhouse", "Subcon"})

            With GridView1
                .Columns("CustID").ColumnEdit = cmbCustID
                .Columns("InvtID").ColumnEdit = cmbInvtID
                .Columns("Oe/Pe").ColumnEdit = cmbOE
                .Columns("IN/SUB").ColumnEdit = cmbInhouse
                .Columns("Site").ColumnEdit = cmbSite
                .Columns("Flag").ColumnEdit = cmbFlag
            End With
            With TForecastPrice1GridControl.RepositoryItems
                .Add(cmbCustID)
                .Add(cmbInvtID)
                .Add(cmbOE)
                .Add(cmbInhouse)
                .Add(cmbSite)
                .Add(cmbFlag)
            End With

            'AddHandler GridView1.CustomColumnDisplayText, AddressOf GridView1_CustomColumnDisplayText
            'AddHandler GridView1.ShowingEditor, AddressOf GridView1_ShowingEditor
            'AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'GridView1.PostEditor()
            'GridView1.UpdateCurrentRow()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub tsbImport_Click(sender As Object, e As EventArgs) Handles tsbImport.Click
        Try
            Dim table As New DataTable
            Dim ls_Judul As String = "Forecast/Price"
            Dim Bulan As String = ""
            Dim strTahun As String = ""
            Dim strCustomer As String = ""

            Dim frmExcel As FrmSystemExcel1
            frmExcel = New FrmSystemExcel1(table, 69)
            frmExcel.Text = "Import " & ls_Judul
            frmExcel.StartPosition = FormStartPosition.CenterScreen
            frmExcel.ShowDialog()
            Dim _err As String = String.Empty

            If frmExcel.tab = 0 Then
                strTahun = frmExcel.Tahun
                strCustomer = frmExcel.Customer
                Bulan = frmExcel.Bulan

                'Try
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                If strCustomer <> "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "' AND [Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer = "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer <> "" AndAlso strTahun = "" Then
                    dv.RowFilter = "[Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                Else
                    dtFilter = dv.ToTable
                End If

                If dtFilter.Rows.Count > 0 Then
                    'If strCustomer <> "" AndAlso strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun, strCustomer)
                    'End If
                    'If strCustomer = "" AndAlso strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun)
                    'End If

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    ObjHeader.ObjForecastCollection.Clear()

                    For Each row As DataRow In dtFilter.Rows
                        Try
                            ObjForecast = New forecast_price_models
                            'Dim ObjCollection As New forecast_price_models
                            With ObjForecast
                                .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                                .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID").ToString())
                                .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                                .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID").ToString())
                                .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                                .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                                .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                                .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe").ToString())
                                .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                                .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
                                .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                                .JanQty1 = If(row("Jan Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty1")))
                                .FebQty1 = If(row("Feb Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty1")))
                                .MarQty1 = If(row("Mar Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty1")))
                                .AprQty1 = If(row("Apr Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty1")))
                                .MeiQty1 = If(row("Mei Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty1")))
                                .JunQty1 = If(row("Jun Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty1")))
                                .JulQty1 = If(row("Jul Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty1")))
                                .AgtQty1 = If(row("Agt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty1")))
                                .SepQty1 = If(row("Sep Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty1")))
                                .OktQty1 = If(row("Okt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty1")))
                                .NovQty1 = If(row("Nov Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty1")))
                                .DesQty1 = If(row("Des Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty1")))

                                .JanQty2 = If(row("Jan Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty2")))
                                .FebQty2 = If(row("Feb Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty2")))
                                .MarQty2 = If(row("Mar Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty2")))
                                .AprQty2 = If(row("Apr Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty2")))
                                .MeiQty2 = If(row("Mei Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty2")))
                                .JunQty2 = If(row("Jun Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty2")))
                                .JulQty2 = If(row("Jul Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty2")))
                                .AgtQty2 = If(row("Agt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty2")))
                                .SepQty2 = If(row("Sep Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty2")))
                                .OktQty2 = If(row("Okt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty2")))
                                .NovQty2 = If(row("Nov Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty2")))
                                .DesQty2 = If(row("Des Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty2")))

                                .JanQty3 = If(row("Jan Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty3")))
                                .FebQty3 = If(row("Feb Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty3")))
                                .MarQty3 = If(row("Mar Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty3")))
                                .AprQty3 = If(row("Apr Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty3")))
                                .MeiQty3 = If(row("Mei Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty3")))
                                .JunQty3 = If(row("Jun Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty3")))
                                .JulQty3 = If(row("Jul Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty3")))
                                .AgtQty3 = If(row("Agt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty3")))
                                .SepQty3 = If(row("Sep Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty3")))
                                .OktQty3 = If(row("Okt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty3")))
                                .NovQty3 = If(row("Nov Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty3")))
                                .DesQty3 = If(row("Des Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty3")))

                                .JanHarga1 = If(row("Jan Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga1")))
                                .FebHarga1 = If(row("Feb Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga1")))
                                .MarHarga1 = If(row("Mar Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga1")))
                                .AprHarga1 = If(row("Apr Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga1")))
                                .MeiHarga1 = If(row("Mei Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga1")))
                                .JunHarga1 = If(row("Jun Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga1")))
                                .JulHarga1 = If(row("Jul Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga1")))
                                .AgtHarga1 = If(row("Agt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga1")))
                                .SepHarga1 = If(row("Sep Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga1")))
                                .OktHarga1 = If(row("Okt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga1")))
                                .NovHarga1 = If(row("Nov Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga1")))
                                .DesHarga1 = If(row("Des Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga1")))

                                .JanHarga2 = If(row("Jan Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga2")))
                                .FebHarga2 = If(row("Feb Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga2")))
                                .MarHarga2 = If(row("Mar Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga2")))
                                .AprHarga2 = If(row("Apr Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga2")))
                                .MeiHarga2 = If(row("Mei Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga2")))
                                .JunHarga2 = If(row("Jun Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga2")))
                                .JulHarga2 = If(row("Jul Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga2")))
                                .AgtHarga2 = If(row("Agt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga2")))
                                .SepHarga2 = If(row("Sep Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga2")))
                                .OktHarga2 = If(row("Okt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga2")))
                                .NovHarga2 = If(row("Nov Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga2")))
                                .DesHarga2 = If(row("Des Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga2")))

                                .JanHarga3 = If(row("Jan Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga3")))
                                .FebHarga3 = If(row("Feb Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga3")))
                                .MarHarga3 = If(row("Mar Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga3")))
                                .AprHarga3 = If(row("Apr Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga3")))
                                .MeiHarga3 = If(row("Mei Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga3")))
                                .JunHarga3 = If(row("Jun Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga3")))
                                .JulHarga3 = If(row("Jul Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga3")))
                                .AgtHarga3 = If(row("Agt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga3")))
                                .SepHarga3 = If(row("Sep Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga3")))
                                .OktHarga3 = If(row("Okt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga3")))
                                .NovHarga3 = If(row("Nov Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga3")))
                                .DesHarga3 = If(row("Des Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga3")))

                                .Jan_PO1 = If(row("Jan PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO1")))
                                .Feb_PO1 = If(row("Feb PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO1")))
                                .Mar_PO1 = If(row("Mar PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO1")))
                                .Apr_PO1 = If(row("Apr PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO1")))
                                .Mei_PO1 = If(row("Mei PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO1")))
                                .Jun_PO1 = If(row("Jun PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO1")))
                                .Jul_PO1 = If(row("Jul PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO1")))
                                .Agt_PO1 = If(row("Agt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO1")))
                                .Sep_PO1 = If(row("Sep PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO1")))
                                .Okt_PO1 = If(row("Okt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO1")))
                                .Nov_PO1 = If(row("Nov PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO1")))
                                .Des_PO1 = If(row("Des PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO1")))

                                .Jan_PO2 = If(row("Jan PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO2")))
                                .Feb_PO2 = If(row("Feb PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO2")))
                                .Mar_PO2 = If(row("Mar PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO2")))
                                .Apr_PO2 = If(row("Apr PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO2")))
                                .Mei_PO2 = If(row("Mei PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO2")))
                                .Jun_PO2 = If(row("Jun PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO2")))
                                .Jul_PO2 = If(row("Jul PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO2")))
                                .Agt_PO2 = If(row("Agt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO2")))
                                .Sep_PO2 = If(row("Sep PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO2")))
                                .Okt_PO2 = If(row("Okt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO2")))
                                .Nov_PO2 = If(row("Nov PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO2")))
                                .Des_PO2 = If(row("Des PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO2")))
                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username
                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            'Console.WriteLine(ex.Message)
                            _err = ex.Message
                            WriteToErrorLog(_err, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, 0, "Invt ID", gh_Common.Username)
                            'Continue For
                            Exit For
                        End Try
                    Next
                    If _err = "" Then
                        With ObjHeader
                            .Tahun = strTahun
                            .CustID = strCustomer
                            .Bulan = Bulan
                            .InsertData1()
                            SplashScreenManager.CloseForm()
                            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                            Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
                        End With
                    Else
                        SplashScreenManager.CloseForm()
                        Throw New Exception("Silahkan Hubungi MIS, Error Upload")
                    End If
                End If
                'Catch ex As Exception
                '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                '    SplashScreenManager.CloseForm()
                '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

                'End Try
            Else
                strTahun = frmExcel.Tahun1
                'Try
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                If strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "'"
                    dtFilter = dv.ToTable
                Else
                    dtFilter = dv.ToTable
                End If

                If dtFilter.Rows.Count > 0 Then
                    'If strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun)
                    'End If

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    ObjHeader.ObjForecastCollection.Clear()

                    For Each row As DataRow In dtFilter.Rows
                        Try
                            ObjForecast = New forecast_price_models
                            With ObjForecast
                                .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                                .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID").ToString())
                                .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                                .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID").ToString())
                                .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                                .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                                .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                                .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe").ToString())
                                .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                                .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
                                .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                                .JanQty1 = If(row("Jan Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty1")))
                                .FebQty1 = If(row("Feb Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty1")))
                                .MarQty1 = If(row("Mar Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty1")))
                                .AprQty1 = If(row("Apr Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty1")))
                                .MeiQty1 = If(row("Mei Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty1")))
                                .JunQty1 = If(row("Jun Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty1")))
                                .JulQty1 = If(row("Jul Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty1")))
                                .AgtQty1 = If(row("Agt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty1")))
                                .SepQty1 = If(row("Sep Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty1")))
                                .OktQty1 = If(row("Okt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty1")))
                                .NovQty1 = If(row("Nov Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty1")))
                                .DesQty1 = If(row("Des Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty1")))

                                .JanQty2 = If(row("Jan Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty2")))
                                .FebQty2 = If(row("Feb Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty2")))
                                .MarQty2 = If(row("Mar Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty2")))
                                .AprQty2 = If(row("Apr Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty2")))
                                .MeiQty2 = If(row("Mei Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty2")))
                                .JunQty2 = If(row("Jun Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty2")))
                                .JulQty2 = If(row("Jul Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty2")))
                                .AgtQty2 = If(row("Agt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty2")))
                                .SepQty2 = If(row("Sep Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty2")))
                                .OktQty2 = If(row("Okt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty2")))
                                .NovQty2 = If(row("Nov Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty2")))
                                .DesQty2 = If(row("Des Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty2")))

                                .JanQty3 = If(row("Jan Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty3")))
                                .FebQty3 = If(row("Feb Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty3")))
                                .MarQty3 = If(row("Mar Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty3")))
                                .AprQty3 = If(row("Apr Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty3")))
                                .MeiQty3 = If(row("Mei Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty3")))
                                .JunQty3 = If(row("Jun Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty3")))
                                .JulQty3 = If(row("Jul Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty3")))
                                .AgtQty3 = If(row("Agt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty3")))
                                .SepQty3 = If(row("Sep Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty3")))
                                .OktQty3 = If(row("Okt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty3")))
                                .NovQty3 = If(row("Nov Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty3")))
                                .DesQty3 = If(row("Des Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty3")))

                                .JanHarga1 = If(row("Jan Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga1")))
                                .FebHarga1 = If(row("Feb Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga1")))
                                .MarHarga1 = If(row("Mar Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga1")))
                                .AprHarga1 = If(row("Apr Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga1")))
                                .MeiHarga1 = If(row("Mei Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga1")))
                                .JunHarga1 = If(row("Jun Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga1")))
                                .JulHarga1 = If(row("Jul Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga1")))
                                .AgtHarga1 = If(row("Agt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga1")))
                                .SepHarga1 = If(row("Sep Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga1")))
                                .OktHarga1 = If(row("Okt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga1")))
                                .NovHarga1 = If(row("Nov Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga1")))
                                .DesHarga1 = If(row("Des Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga1")))

                                .JanHarga2 = If(row("Jan Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga2")))
                                .FebHarga2 = If(row("Feb Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga2")))
                                .MarHarga2 = If(row("Mar Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga2")))
                                .AprHarga2 = If(row("Apr Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga2")))
                                .MeiHarga2 = If(row("Mei Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga2")))
                                .JunHarga2 = If(row("Jun Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga2")))
                                .JulHarga2 = If(row("Jul Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga2")))
                                .AgtHarga2 = If(row("Agt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga2")))
                                .SepHarga2 = If(row("Sep Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga2")))
                                .OktHarga2 = If(row("Okt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga2")))
                                .NovHarga2 = If(row("Nov Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga2")))
                                .DesHarga2 = If(row("Des Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga2")))

                                .JanHarga3 = If(row("Jan Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga3")))
                                .FebHarga3 = If(row("Feb Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga3")))
                                .MarHarga3 = If(row("Mar Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga3")))
                                .AprHarga3 = If(row("Apr Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga3")))
                                .MeiHarga3 = If(row("Mei Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga3")))
                                .JunHarga3 = If(row("Jun Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga3")))
                                .JulHarga3 = If(row("Jul Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga3")))
                                .AgtHarga3 = If(row("Agt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga3")))
                                .SepHarga3 = If(row("Sep Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga3")))
                                .OktHarga3 = If(row("Okt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga3")))
                                .NovHarga3 = If(row("Nov Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga3")))
                                .DesHarga3 = If(row("Des Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga3")))

                                .Jan_PO1 = If(row("Jan PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO1")))
                                .Feb_PO1 = If(row("Feb PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO1")))
                                .Mar_PO1 = If(row("Mar PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO1")))
                                .Apr_PO1 = If(row("Apr PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO1")))
                                .Mei_PO1 = If(row("Mei PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO1")))
                                .Jun_PO1 = If(row("Jun PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO1")))
                                .Jul_PO1 = If(row("Jul PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO1")))
                                .Agt_PO1 = If(row("Agt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO1")))
                                .Sep_PO1 = If(row("Sep PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO1")))
                                .Okt_PO1 = If(row("Okt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO1")))
                                .Nov_PO1 = If(row("Nov PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO1")))
                                .Des_PO1 = If(row("Des PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO1")))

                                .Jan_PO2 = If(row("Jan PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO2")))
                                .Feb_PO2 = If(row("Feb PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO2")))
                                .Mar_PO2 = If(row("Mar PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO2")))
                                .Apr_PO2 = If(row("Apr PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO2")))
                                .Mei_PO2 = If(row("Mei PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO2")))
                                .Jun_PO2 = If(row("Jun PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO2")))
                                .Jul_PO2 = If(row("Jul PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO2")))
                                .Agt_PO2 = If(row("Agt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO2")))
                                .Sep_PO2 = If(row("Sep PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO2")))
                                .Okt_PO2 = If(row("Okt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO2")))
                                .Nov_PO2 = If(row("Nov PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO2")))
                                .Des_PO2 = If(row("Des PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO2")))
                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username

                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, 0, "Invt ID", gh_Common.Username)
                            _err = ex.Message
                            Exit For
                            'Continue For
                        End Try
                    Next
                    If _err = "" Then
                        ObjHeader.Tahun = strTahun
                        ObjHeader.InsertData()
                        SplashScreenManager.CloseForm()
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
                    Else
                        SplashScreenManager.CloseForm()
                        MsgBox("Silahkan Hubungi MIS !", "Error Upload")
                    End If

                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            SplashScreenManager.CloseForm()
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(TForecastPrice1GridControl)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub

    Private Sub CekHargaBedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekHargaBedaToolStripMenuItem.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetHargaSAPKAP_ADM

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST HARGA INVENTORY SAMA TAPI HARGA BEDA", 0)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CekInventory1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekInventory1ToolStripMenuItem.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetDoubleInvtID

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST INVENTORY ID YANG LEBIH DARI 1", 1)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        Try
            Dim gridView As GridView = TryCast(sender, GridView)
            Dim hitInfo As GridHitInfo = gridView.CalcHitInfo(e.Location)
            If hitInfo.Column Is Nothing OrElse hitInfo.Column.FieldName = "Tahun" _
                OrElse hitInfo.Column.FieldName = "CustID" _
                OrElse hitInfo.Column.FieldName = "InvtID" _
                OrElse hitInfo.Column.FieldName = "Model" Then
                Return
            End If

            Me.BeginInvoke(Sub()
                               gridView.ShowEditorByMouse()
                           End Sub)
            'Me.BeginInvoke(New MethodInvoker(Function()
            '                                     gridView.ShowEditorByMouse()
            '                                 End Function))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If GridView1.FocusedColumn.FieldName = "CustID" Then
                ObjHeader = New forecast_price_models_header
                Dim CustID = If(GridView1.GetFocusedRowCellValue("CustID") Is DBNull.Value, "", Convert.ToString(GridView1.GetFocusedRowCellValue("CustID")))
                If CustID = "" Then
                    Exit Sub
                End If
                Dim dt As New DataTable
                dt = ObjHeader.GetInventoryName(CustID)
                If dt.Rows.Count > 0 Then
                    GridView1.FocusedColumn = GridView1.VisibleColumns(2)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Customer", dt.Rows(0)(0))
                    'GridView1.PostEditor()
                    'GridView1.CloseEditor()
                    'GridView1.UpdateCurrentRow()
                    'GridView1.FocusedColumn = GridView1.VisibleColumns(3)
                Else
                    MsgBox("Data tidak ditemukan !")
                End If

            End If

            If GridView1.FocusedColumn.FieldName = "InvtID" Then
                Dim ObjInvt As New global_function_models

                Dim InvtID = If(GridView1.GetFocusedRowCellValue("InvtID") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("InvtID"))
                If InvtID = "" Then
                    Exit Sub
                End If
                Dim dt As New DataTable
                dt = ObjInvt.getPartNo_Solomon(InvtID)
                If dt.Rows.Count > 0 Then
                    GridView1.FocusedColumn = GridView1.VisibleColumns(6)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Description", dt.Rows(0)(2))
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "PartNo", dt.Rows(0)(1))
                    'GridView1.PostEditor()
                    'GridView1.CloseEditor()
                    'GridView1.UpdateCurrentRow()
                Else
                    MsgBox("Data tidak ditemukan !")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefresh.Click
        TampilGrid()
    End Sub
    Private Sub TampilGrid()
        'Me.DataSet1.tForecastPrice1.Clear()
        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
        'TForecastPrice1BindingSource.RaiseListChangedEvents = True
        'TForecastPrice1BindingSource.ResetBindings(False)
        'TForecastPrice1GridControl.DataSource = Nothing
        'TForecastPrice1GridControl.DataSource = TForecastPrice1BindingSource
    End Sub

    Private Sub TForecastPrice1GridControl_MouseDown(sender As Object, e As MouseEventArgs) Handles TForecastPrice1GridControl.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub


    Private Sub ShowGridColumByMonth(po As String, n1 As String, n2 As String, n3 As String,
                                     Optional h1 As String = "", Optional h2 As String = "", Optional h3 As String = "")
        Try
            For i As Integer = 12 To GridView1.Columns.Count - 1
                With GridView1
                    Dim _po As String = String.Empty
                    Dim _n1 As String = String.Empty
                    Dim _n2 As String = String.Empty
                    Dim _n3 As String = String.Empty
                    Dim _h1 As String = String.Empty
                    Dim _h2 As String = String.Empty
                    Dim _h3 As String = String.Empty
                    _po = .Columns(i).FieldName
                    _n1 = .Columns(i).FieldName
                    _n2 = .Columns(i).FieldName
                    _n3 = .Columns(i).FieldName
                    _h1 = .Columns(i).FieldName
                    _h2 = .Columns(i).FieldName
                    _h3 = .Columns(i).FieldName
                    If po = "" Then
                        .Columns(i).Visible = True
                    Else
                        If _po = po OrElse _n1 = n1 OrElse _n2 = n2 OrElse _n3 = n3 _
                            OrElse _h1 = h1 OrElse _h2 = h2 OrElse _h3 = h3 Then
                            .Columns(i).Visible = True
                        Else
                            .Columns(i).Visible = False
                        End If
                    End If
                End With
            Next
            If cmbBulan.SelectedIndex = 0 Then
                With GridView1
                    .Columns("JanQty1").VisibleIndex = 11
                    .Columns("JanQty2").VisibleIndex = 12
                    .Columns("JanQty3").VisibleIndex = 13
                    .Columns("FebQty1").VisibleIndex = 14
                    .Columns("FebQty2").VisibleIndex = 15
                    .Columns("FebQty3").VisibleIndex = 16
                    .Columns("MarQty1").VisibleIndex = 17
                    .Columns("MarQty2").VisibleIndex = 18
                    .Columns("MarQty3").VisibleIndex = 19
                    .Columns("AprQty1").VisibleIndex = 20
                    .Columns("AprQty2").VisibleIndex = 21
                    .Columns("AprQty3").VisibleIndex = 22
                    .Columns("MeiQty1").VisibleIndex = 23
                    .Columns("MeiQty2").VisibleIndex = 24
                    .Columns("MeiQty3").VisibleIndex = 25
                    .Columns("JunQty1").VisibleIndex = 26
                    .Columns("JunQty2").VisibleIndex = 27
                    .Columns("JunQty3").VisibleIndex = 28
                    .Columns("JulQty1").VisibleIndex = 29
                    .Columns("JulQty2").VisibleIndex = 30
                    .Columns("JulQty3").VisibleIndex = 31
                    .Columns("AgtQty1").VisibleIndex = 32
                    .Columns("AgtQty2").VisibleIndex = 33
                    .Columns("AgtQty3").VisibleIndex = 34
                    .Columns("SepQty1").VisibleIndex = 35
                    .Columns("SepQty2").VisibleIndex = 36
                    .Columns("SepQty3").VisibleIndex = 37
                    .Columns("OktQty1").VisibleIndex = 38
                    .Columns("OktQty2").VisibleIndex = 39
                    .Columns("OktQty3").VisibleIndex = 40
                    .Columns("NovQty1").VisibleIndex = 41
                    .Columns("NovQty2").VisibleIndex = 42
                    .Columns("NovQty3").VisibleIndex = 43
                    .Columns("DesQty1").VisibleIndex = 44
                    .Columns("DesQty2").VisibleIndex = 45
                    .Columns("DesQty3").VisibleIndex = 46

                    .Columns("Jan PO1").VisibleIndex = 47
                    .Columns("Jan PO2").VisibleIndex = 48
                    .Columns("Feb PO1").VisibleIndex = 49
                    .Columns("Feb PO2").VisibleIndex = 50
                    .Columns("Mar PO1").VisibleIndex = 51
                    .Columns("Mar PO2").VisibleIndex = 52
                    .Columns("Apr PO1").VisibleIndex = 53
                    .Columns("Apr PO2").VisibleIndex = 54
                    .Columns("Mei PO1").VisibleIndex = 55
                    .Columns("Mei PO2").VisibleIndex = 56
                    .Columns("Jun PO1").VisibleIndex = 57
                    .Columns("Jun PO2").VisibleIndex = 58
                    .Columns("Jul PO1").VisibleIndex = 59
                    .Columns("Jul PO2").VisibleIndex = 60
                    .Columns("Agt PO1").VisibleIndex = 61
                    .Columns("Agt PO2").VisibleIndex = 62
                    .Columns("Sep PO1").VisibleIndex = 63
                    .Columns("Sep PO2").VisibleIndex = 64
                    .Columns("Okt PO1").VisibleIndex = 65
                    .Columns("Okt PO2").VisibleIndex = 66
                    .Columns("Nov PO1").VisibleIndex = 67
                    .Columns("Nov PO2").VisibleIndex = 68
                    .Columns("Des PO1").VisibleIndex = 69
                    .Columns("Des PO2").VisibleIndex = 70

                    .Columns("JanHarga1").VisibleIndex = 71
                    .Columns("JanHarga2").VisibleIndex = 72
                    .Columns("JanHarga3").VisibleIndex = 73
                    .Columns("FebHarga1").VisibleIndex = 74
                    .Columns("FebHarga2").VisibleIndex = 75
                    .Columns("FebHarga3").VisibleIndex = 76
                    .Columns("MarHarga1").VisibleIndex = 77
                    .Columns("MarHarga2").VisibleIndex = 78
                    .Columns("MarHarga3").VisibleIndex = 79
                    .Columns("AprHarga1").VisibleIndex = 80
                    .Columns("AprHarga2").VisibleIndex = 81
                    .Columns("AprHarga3").VisibleIndex = 82
                    .Columns("MeiHarga1").VisibleIndex = 83
                    .Columns("MeiHarga2").VisibleIndex = 84
                    .Columns("MeiHarga3").VisibleIndex = 85
                    .Columns("JunHarga1").VisibleIndex = 86
                    .Columns("JunHarga2").VisibleIndex = 87
                    .Columns("JunHarga3").VisibleIndex = 88
                    .Columns("JulHarga1").VisibleIndex = 89
                    .Columns("JulHarga2").VisibleIndex = 90
                    .Columns("JulHarga3").VisibleIndex = 91
                    .Columns("AgtHarga1").VisibleIndex = 92
                    .Columns("AgtHarga2").VisibleIndex = 93
                    .Columns("AgtHarga3").VisibleIndex = 94
                    .Columns("SepHarga1").VisibleIndex = 95
                    .Columns("SepHarga2").VisibleIndex = 96
                    .Columns("SepHarga3").VisibleIndex = 97
                    .Columns("OktHarga1").VisibleIndex = 98
                    .Columns("OktHarga2").VisibleIndex = 100
                    .Columns("OktHarga3").VisibleIndex = 101
                    .Columns("NovHarga1").VisibleIndex = 102
                    .Columns("NovHarga2").VisibleIndex = 103
                    .Columns("NovHarga3").VisibleIndex = 104
                    .Columns("DesHarga1").VisibleIndex = 105
                    .Columns("DesHarga2").VisibleIndex = 106
                    .Columns("DesHarga3").VisibleIndex = 107
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbBulan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBulan.SelectedIndexChanged
        'If cmbBulan.SelectedIndex = 1 Then
        '    ShowGridColumByMonth("Jan")

        'End If

        Select Case cmbBulan.SelectedIndex
            Case 1
                ShowGridColumByMonth("Jan PO1", "FebQty3", "MarQty2", "AprQty1", "JanHarga1", "JanHarga2", "JanHarga3")
            Case 2
                ShowGridColumByMonth("Feb PO1", "MarQty3", "AprQty2", "MeiQty1", "FebHarga1", "FebHarga2", "FebHarga3")
            Case 3
                ShowGridColumByMonth("Mar PO1", "AprQty3", "MeiQty2", "JunQty1", "MarHarga1", "MarHarga2", "MarHarga3")
            Case 4
                ShowGridColumByMonth("Apr PO1", "MeiQty3", "JunQty2", "JulQty1", "AprHarga1", "AprHarga2", "AprHarga3")
            Case 5
                ShowGridColumByMonth("Mei PO1", "JunQty3", "JulQty2", "AgtQty1", "MeiHarga1", "MeiHarga2", "MeiHarga3")
            Case 6
                ShowGridColumByMonth("Jun PO1", "JulQty3", "AgtQty2", "SepQty1", "JunHarga1", "JunHarga2", "JunHarga3")
            Case 7
                ShowGridColumByMonth("Jul PO1", "AgtQty3", "SepQty2", "OktQty1", "JulHarga1", "JulHarga2", "JulHarga3")
            Case 8
                ShowGridColumByMonth("Agt PO1", "SepQty3", "OktQty2", "NovQty1", "AgtHarga1", "AgtHarga2", "AgtHarga3")
            Case 9
                ShowGridColumByMonth("Sep PO1", "OktQty3", "NovQty2", "DesQty1", "SepHarga1", "SepHarga2", "SepHarga3")
            Case 10
                ShowGridColumByMonth("Okt PO1", "NovQty3", "DesQty2", "JanQty1", "OktHarga1", "OktHarga2", "OktHarga3")
            Case 11
                ShowGridColumByMonth("Nov PO1", "DesQty3", "JanQty2", "FebQty1", "NovHarga1", "NovHarga2", "NovHarga3")
            Case 12
                ShowGridColumByMonth("Des PO1", "JanQty3", "FebQty2", "MarQty1", "DesHarga1", "DesHarga2", "DesHarga3")
            Case Else
                ShowGridColumByMonth("", "", "", "")
                'TampilGrid()
        End Select
    End Sub
End Class