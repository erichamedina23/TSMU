Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmSales_ForecastPrice_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjForecastPrice As New forecast_price_models
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim id As System.Globalization.CultureInfo
    Dim EdtiPrice As Boolean

    Dim ObjGlobal As New global_function_models
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

    Private Sub frmSales_ForecastPrice_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjForecastPrice.Id = fs_Code
                ObjForecastPrice.GetAllDataGridById(False)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "SALES->FORECAST->" & fs_Code
            Else
                Me.Text = "SALES->FORECAST->NEW"
            End If

            Call LoadTxtBox()
            'End If
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSales_ForecastPrice"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjForecastPrice
                    TxtId.Text = .Id
                    TxtTahun.Text = .Tahun
                    TxtCustID.Text = .CustID
                    TxtCustName.Text = .Customer
                    TxtInvtID.Text = .InvtID
                    TxtInvtName.Text = .Description
                    TxtPartNo.Text = .PartNo
                    TxtModel.Text = .Model
                    TxtOePe.Text = .OePe
                    TxtInSub.Text = .INSub
                    TxtSite.Text = .Site
                    LoadDataNew()

                    With GridView1
                        .SetRowCellValue(0, "Qty1", ObjForecastPrice.JanQty1)
                        .SetRowCellValue(0, "Qty2", ObjForecastPrice.JanQty2)
                        .SetRowCellValue(0, "Qty3", ObjForecastPrice.JanQty3)
                        .SetRowCellValue(0, "PO1", ObjForecastPrice.Jan_PO1)
                        .SetRowCellValue(0, "PO2", ObjForecastPrice.Jan_PO2)
                        .SetRowCellValue(0, "Harga1", ObjForecastPrice.JanHarga1)
                        .SetRowCellValue(0, "Harga2", ObjForecastPrice.JanHarga2)
                        .SetRowCellValue(0, "Harga3", ObjForecastPrice.JanHarga3)

                        .SetRowCellValue(1, "Qty1", ObjForecastPrice.FebQty1)
                        .SetRowCellValue(1, "Qty2", ObjForecastPrice.FebQty2)
                        .SetRowCellValue(1, "Qty3", ObjForecastPrice.FebQty3)
                        .SetRowCellValue(1, "PO1", ObjForecastPrice.Feb_PO1)
                        .SetRowCellValue(1, "PO2", ObjForecastPrice.Feb_PO2)
                        .SetRowCellValue(1, "Harga1", ObjForecastPrice.FebHarga1)
                        .SetRowCellValue(1, "Harga2", ObjForecastPrice.FebHarga2)
                        .SetRowCellValue(1, "Harga3", ObjForecastPrice.FebHarga3)

                        .SetRowCellValue(2, "Qty1", ObjForecastPrice.MarQty1)
                        .SetRowCellValue(2, "Qty2", ObjForecastPrice.MarQty2)
                        .SetRowCellValue(2, "Qty3", ObjForecastPrice.MarQty3)
                        .SetRowCellValue(2, "PO1", ObjForecastPrice.Mar_PO1)
                        .SetRowCellValue(2, "PO2", ObjForecastPrice.Mar_PO2)
                        .SetRowCellValue(2, "Harga1", ObjForecastPrice.MarHarga1)
                        .SetRowCellValue(2, "Harga2", ObjForecastPrice.MarHarga2)
                        .SetRowCellValue(2, "Harga3", ObjForecastPrice.MarHarga3)

                        .SetRowCellValue(3, "Qty1", ObjForecastPrice.AprQty1)
                        .SetRowCellValue(3, "Qty2", ObjForecastPrice.AprQty2)
                        .SetRowCellValue(3, "Qty3", ObjForecastPrice.AprQty3)
                        .SetRowCellValue(3, "PO1", ObjForecastPrice.Apr_PO1)
                        .SetRowCellValue(3, "PO2", ObjForecastPrice.Apr_PO2)
                        .SetRowCellValue(3, "Harga1", ObjForecastPrice.AprHarga1)
                        .SetRowCellValue(3, "Harga2", ObjForecastPrice.AprHarga2)
                        .SetRowCellValue(3, "Harga3", ObjForecastPrice.AprHarga3)

                        .SetRowCellValue(4, "Qty1", ObjForecastPrice.MeiQty1)
                        .SetRowCellValue(4, "Qty2", ObjForecastPrice.MeiQty2)
                        .SetRowCellValue(4, "Qty3", ObjForecastPrice.MeiQty3)
                        .SetRowCellValue(4, "PO1", ObjForecastPrice.Mei_PO1)
                        .SetRowCellValue(4, "PO2", ObjForecastPrice.Mei_PO2)
                        .SetRowCellValue(4, "Harga1", ObjForecastPrice.MeiHarga1)
                        .SetRowCellValue(4, "Harga2", ObjForecastPrice.MeiHarga2)
                        .SetRowCellValue(4, "Harga3", ObjForecastPrice.MeiHarga3)

                        .SetRowCellValue(5, "Qty1", ObjForecastPrice.JunQty1)
                        .SetRowCellValue(5, "Qty2", ObjForecastPrice.JunQty2)
                        .SetRowCellValue(5, "Qty3", ObjForecastPrice.JunQty3)
                        .SetRowCellValue(5, "PO1", ObjForecastPrice.Jun_PO1)
                        .SetRowCellValue(5, "PO2", ObjForecastPrice.Jun_PO2)
                        .SetRowCellValue(5, "Harga1", ObjForecastPrice.JunHarga1)
                        .SetRowCellValue(5, "Harga2", ObjForecastPrice.JunHarga2)
                        .SetRowCellValue(5, "Harga3", ObjForecastPrice.JunHarga3)

                        .SetRowCellValue(6, "Qty1", ObjForecastPrice.JulQty1)
                        .SetRowCellValue(6, "Qty2", ObjForecastPrice.JulQty2)
                        .SetRowCellValue(6, "Qty3", ObjForecastPrice.JulQty3)
                        .SetRowCellValue(6, "PO1", ObjForecastPrice.Jul_PO1)
                        .SetRowCellValue(6, "PO2", ObjForecastPrice.Jul_PO2)
                        .SetRowCellValue(6, "Harga1", ObjForecastPrice.JulHarga1)
                        .SetRowCellValue(6, "Harga2", ObjForecastPrice.JulHarga2)
                        .SetRowCellValue(6, "Harga3", ObjForecastPrice.JulHarga3)

                        .SetRowCellValue(7, "Qty1", ObjForecastPrice.AgtQty1)
                        .SetRowCellValue(7, "Qty2", ObjForecastPrice.AgtQty2)
                        .SetRowCellValue(7, "Qty3", ObjForecastPrice.AgtQty3)
                        .SetRowCellValue(7, "PO1", ObjForecastPrice.Agt_PO1)
                        .SetRowCellValue(7, "PO2", ObjForecastPrice.Agt_PO2)
                        .SetRowCellValue(7, "Harga1", ObjForecastPrice.AgtHarga1)
                        .SetRowCellValue(7, "Harga2", ObjForecastPrice.AgtHarga2)
                        .SetRowCellValue(7, "Harga3", ObjForecastPrice.AgtHarga3)

                        .SetRowCellValue(8, "Qty1", ObjForecastPrice.SepQty1)
                        .SetRowCellValue(8, "Qty2", ObjForecastPrice.SepQty2)
                        .SetRowCellValue(8, "Qty3", ObjForecastPrice.SepQty3)
                        .SetRowCellValue(8, "PO1", ObjForecastPrice.Sep_PO1)
                        .SetRowCellValue(8, "PO2", ObjForecastPrice.Sep_PO2)
                        .SetRowCellValue(8, "Harga1", ObjForecastPrice.SepHarga1)
                        .SetRowCellValue(8, "Harga2", ObjForecastPrice.SepHarga2)
                        .SetRowCellValue(8, "Harga3", ObjForecastPrice.SepHarga3)

                        .SetRowCellValue(9, "Qty1", ObjForecastPrice.OktQty1)
                        .SetRowCellValue(9, "Qty2", ObjForecastPrice.OktQty2)
                        .SetRowCellValue(9, "Qty3", ObjForecastPrice.OktQty3)
                        .SetRowCellValue(9, "PO1", ObjForecastPrice.Okt_PO1)
                        .SetRowCellValue(9, "PO2", ObjForecastPrice.Okt_PO2)
                        .SetRowCellValue(9, "Harga1", ObjForecastPrice.OktHarga1)
                        .SetRowCellValue(9, "Harga2", ObjForecastPrice.OktHarga2)
                        .SetRowCellValue(9, "Harga3", ObjForecastPrice.OktHarga3)

                        .SetRowCellValue(10, "Qty1", ObjForecastPrice.NovQty1)
                        .SetRowCellValue(10, "Qty2", ObjForecastPrice.NovQty2)
                        .SetRowCellValue(10, "Qty3", ObjForecastPrice.NovQty3)
                        .SetRowCellValue(10, "PO1", ObjForecastPrice.Nov_PO1)
                        .SetRowCellValue(10, "PO2", ObjForecastPrice.Nov_PO2)
                        .SetRowCellValue(10, "Harga1", ObjForecastPrice.NovHarga1)
                        .SetRowCellValue(10, "Harga2", ObjForecastPrice.NovHarga2)
                        .SetRowCellValue(10, "Harga3", ObjForecastPrice.NovHarga3)

                        .SetRowCellValue(11, "Qty1", ObjForecastPrice.DesQty1)
                        .SetRowCellValue(11, "Qty2", ObjForecastPrice.DesQty2)
                        .SetRowCellValue(11, "Qty3", ObjForecastPrice.DesQty3)
                        .SetRowCellValue(11, "PO1", ObjForecastPrice.Des_PO1)
                        .SetRowCellValue(11, "PO2", ObjForecastPrice.Des_PO2)
                        .SetRowCellValue(11, "Harga1", ObjForecastPrice.DesHarga1)
                        .SetRowCellValue(11, "Harga2", ObjForecastPrice.DesHarga2)
                        .SetRowCellValue(11, "Harga3", ObjForecastPrice.DesHarga3)
                    End With
                End With
            Else
                TxtCustID.Text = ""
                TxtCustName.Text = ""
                TxtInvtID.Text = ""
                TxtInvtName.Text = ""
                TxtPartNo.Text = ""
                TxtModel.Text = ""
                TxtOePe.Text = ""
                TxtInSub.Text = ""
                TxtSite.Text = ""
                TxtTahun.Text = DateTime.Today.Year.ToString()
                TxtTahun.Focus()
                LoadDataNew()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadDataNew()
        Try
            Dim dt As New DataTable

            dt.Columns.Add("Bulan", GetType(String))
            dt.Columns.Add("Qty1", GetType(Integer))
            dt.Columns.Add("Qty2", GetType(Integer))
            dt.Columns.Add("Qty3", GetType(Integer))
            dt.Columns.Add("PO1", GetType(Integer))
            dt.Columns.Add("PO2", GetType(Integer))
            dt.Columns.Add("Harga1", GetType(Double))
            dt.Columns.Add("Harga2", GetType(Double))
            dt.Columns.Add("Harga3", GetType(Double))

            Dim Jan() As String = {"Januari", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Feb() As String = {"Februari", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Mar() As String = {"Maret", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Apr() As String = {"April", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Mei() As String = {"Mei", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Jun() As String = {"Juni", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Jul() As String = {"Juli", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Aug() As String = {"Agustus", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Sep() As String = {"September", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Okt() As String = {"Oktober", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Nov() As String = {"November", "0", "0", "0", "0", "0", "0", "0", "0"}
            Dim Des() As String = {"Desember", "0", "0", "0", "0", "0", "0", "0", "0"}

            Dim rows() As Object = {Jan, Feb, Mar, Apr, Mei, Jun, Jul, Aug, Sep, Okt, Nov, Des}

            Dim row As String()
            For Each row In rows
                dt.Rows.Add(row)
            Next row

            Grid.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                With ObjForecastPrice
                    .Tahun = TxtTahun.Text
                    .CustID = TxtCustID.Text
                    .Customer = TxtCustName.Text
                    .InvtID = TxtInvtID.Text
                    .Description = TxtInvtName.Text
                    .PartNo = TxtPartNo.Text
                    .Model = TxtModel.Text
                    .OePe = TxtOePe.Text
                    .INSub = TxtInSub.Text
                    .Site = TxtSite.Text
                    .JanQty1 = GridView1.GetRowCellValue(0, "Qty1")
                    .JanQty2 = GridView1.GetRowCellValue(0, "Qty2")
                    .JanQty3 = GridView1.GetRowCellValue(0, "Qty3")
                    .Jan_PO1 = GridView1.GetRowCellValue(0, "PO1")
                    .Jan_PO2 = GridView1.GetRowCellValue(0, "PO2")
                    .FebQty1 = GridView1.GetRowCellValue(1, "Qty1")
                    .FebQty2 = GridView1.GetRowCellValue(1, "Qty2")
                    .FebQty3 = GridView1.GetRowCellValue(1, "Qty3")
                    .Feb_PO1 = GridView1.GetRowCellValue(1, "PO1")
                    .Feb_PO2 = GridView1.GetRowCellValue(1, "PO2")
                    .MarQty1 = GridView1.GetRowCellValue(2, "Qty1")
                    .MarQty2 = GridView1.GetRowCellValue(2, "Qty2")
                    .MarQty3 = GridView1.GetRowCellValue(2, "Qty3")
                    .Mar_PO1 = GridView1.GetRowCellValue(2, "PO1")
                    .Mar_PO2 = GridView1.GetRowCellValue(2, "PO2")
                    .AprQty1 = GridView1.GetRowCellValue(3, "Qty1")
                    .AprQty2 = GridView1.GetRowCellValue(3, "Qty2")
                    .AprQty3 = GridView1.GetRowCellValue(3, "Qty3")
                    .Apr_PO1 = GridView1.GetRowCellValue(3, "PO1")
                    .Apr_PO2 = GridView1.GetRowCellValue(3, "PO2")
                    .MeiQty1 = GridView1.GetRowCellValue(4, "Qty1")
                    .MeiQty2 = GridView1.GetRowCellValue(4, "Qty2")
                    .MeiQty3 = GridView1.GetRowCellValue(4, "Qty3")
                    .Mei_PO1 = GridView1.GetRowCellValue(4, "PO1")
                    .Mei_PO2 = GridView1.GetRowCellValue(4, "PO2")
                    .JunQty1 = GridView1.GetRowCellValue(5, "Qty1")
                    .JunQty2 = GridView1.GetRowCellValue(5, "Qty2")
                    .JunQty3 = GridView1.GetRowCellValue(5, "Qty3")
                    .Jun_PO1 = GridView1.GetRowCellValue(5, "PO1")
                    .Jun_PO2 = GridView1.GetRowCellValue(5, "PO2")
                    .JulQty1 = GridView1.GetRowCellValue(6, "Qty1")
                    .JulQty2 = GridView1.GetRowCellValue(6, "Qty2")
                    .JulQty3 = GridView1.GetRowCellValue(6, "Qty3")
                    .Jul_PO1 = GridView1.GetRowCellValue(6, "PO1")
                    .Jul_PO2 = GridView1.GetRowCellValue(6, "PO2")
                    .AgtQty1 = GridView1.GetRowCellValue(7, "Qty1")
                    .AgtQty2 = GridView1.GetRowCellValue(7, "Qty2")
                    .AgtQty3 = GridView1.GetRowCellValue(7, "Qty3")
                    .Agt_PO1 = GridView1.GetRowCellValue(7, "PO1")
                    .Agt_PO2 = GridView1.GetRowCellValue(7, "PO2")
                    .SepQty1 = GridView1.GetRowCellValue(8, "Qty1")
                    .SepQty2 = GridView1.GetRowCellValue(8, "Qty2")
                    .SepQty3 = GridView1.GetRowCellValue(8, "Qty3")
                    .Sep_PO1 = GridView1.GetRowCellValue(8, "PO1")
                    .Sep_PO2 = GridView1.GetRowCellValue(8, "PO2")
                    .OktQty1 = GridView1.GetRowCellValue(9, "Qty1")
                    .OktQty2 = GridView1.GetRowCellValue(9, "Qty2")
                    .OktQty3 = GridView1.GetRowCellValue(9, "Qty3")
                    .Okt_PO1 = GridView1.GetRowCellValue(9, "PO1")
                    .Okt_PO2 = GridView1.GetRowCellValue(9, "PO2")
                    .NovQty1 = GridView1.GetRowCellValue(10, "Qty1")
                    .NovQty2 = GridView1.GetRowCellValue(10, "Qty2")
                    .NovQty3 = GridView1.GetRowCellValue(10, "Qty3")
                    .Nov_PO1 = GridView1.GetRowCellValue(10, "PO1")
                    .Nov_PO2 = GridView1.GetRowCellValue(10, "PO2")
                    .DesQty1 = GridView1.GetRowCellValue(11, "Qty1")
                    .DesQty2 = GridView1.GetRowCellValue(11, "Qty2")
                    .DesQty3 = GridView1.GetRowCellValue(11, "Qty3")
                    .Des_PO1 = GridView1.GetRowCellValue(11, "PO1")
                    .Des_PO2 = GridView1.GetRowCellValue(11, "PO2")
                    .JanHarga1 = GridView1.GetRowCellValue(0, "Harga1")
                    .JanHarga2 = GridView1.GetRowCellValue(0, "Harga2")
                    .JanHarga3 = GridView1.GetRowCellValue(0, "Harga3")
                    .FebHarga1 = GridView1.GetRowCellValue(1, "Harga1")
                    .FebHarga2 = GridView1.GetRowCellValue(1, "Harga2")
                    .FebHarga3 = GridView1.GetRowCellValue(1, "Harga3")
                    .MarHarga1 = GridView1.GetRowCellValue(2, "Harga1")
                    .MarHarga2 = GridView1.GetRowCellValue(2, "Harga2")
                    .MarHarga3 = GridView1.GetRowCellValue(2, "Harga3")
                    .AprHarga1 = GridView1.GetRowCellValue(3, "Harga1")
                    .AprHarga2 = GridView1.GetRowCellValue(3, "Harga2")
                    .AprHarga3 = GridView1.GetRowCellValue(3, "Harga3")
                    .MeiHarga1 = GridView1.GetRowCellValue(4, "Harga1")
                    .MeiHarga2 = GridView1.GetRowCellValue(4, "Harga2")
                    .MeiHarga3 = GridView1.GetRowCellValue(4, "Harga3")
                    .JunHarga1 = GridView1.GetRowCellValue(5, "Harga1")
                    .JunHarga2 = GridView1.GetRowCellValue(5, "Harga2")
                    .JunHarga3 = GridView1.GetRowCellValue(5, "Harga3")
                    .JulHarga1 = GridView1.GetRowCellValue(6, "Harga1")
                    .JulHarga2 = GridView1.GetRowCellValue(6, "Harga2")
                    .JulHarga3 = GridView1.GetRowCellValue(6, "Harga3")
                    .AgtHarga1 = GridView1.GetRowCellValue(7, "Harga1")
                    .AgtHarga2 = GridView1.GetRowCellValue(7, "Harga2")
                    .AgtHarga3 = GridView1.GetRowCellValue(7, "Harga3")
                    .SepHarga1 = GridView1.GetRowCellValue(8, "Harga1")
                    .SepHarga2 = GridView1.GetRowCellValue(8, "Harga2")
                    .SepHarga3 = GridView1.GetRowCellValue(8, "Harga3")
                    .OktHarga1 = GridView1.GetRowCellValue(9, "Harga1")
                    .OktHarga2 = GridView1.GetRowCellValue(9, "Harga2")
                    .OktHarga3 = GridView1.GetRowCellValue(9, "Harga3")
                    .NovHarga1 = GridView1.GetRowCellValue(10, "Harga1")
                    .NovHarga2 = GridView1.GetRowCellValue(10, "Harga2")
                    .NovHarga3 = GridView1.GetRowCellValue(10, "Harga3")
                    .DesHarga1 = GridView1.GetRowCellValue(11, "Harga1")
                    .DesHarga2 = GridView1.GetRowCellValue(11, "Harga2")
                    .DesHarga3 = GridView1.GetRowCellValue(11, "Harga3")
                    .created_by = gh_Common.Username
                    .created_date = DateTime.Today
                    .updated_by = gh_Common.Username
                    .update_date = DateTime.Today
                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
                        .ValidateUpdate1()
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
            If isUpdate = False Then
                ObjForecastPrice.InsertData()
                GridDtl.DataSource = ObjForecastPrice.GetAllDataGrid(bs_Filter)
                frmSales_ForecastPrice.GridView1.UpdateCurrentRow()
                frmSales_ForecastPrice.GridView1.OptionsNavigation.AutoFocusNewRow = True
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            Else
                ObjForecastPrice.Id = TxtId.Text
                ObjForecastPrice.UpdateData()

                'tsBtn_next.PerformClick()

                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtTahun.DoValidate()
        TxtCustID.DoValidate()
        TxtInvtID.DoValidate()
        TxtOePe.DoValidate()
        TxtInSub.DoValidate()
        TxtSite.DoValidate()
        TxtModel.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtTahun) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtCustID) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtInvtID) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtOePe) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtInSub) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtSite) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtModel) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
        GridDtl.DataSource = ObjForecastPrice.GetAllDataGrid(bs_Filter)
    End Sub

    Private Sub TxtCustID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtCustID.ButtonClick, TxtInvtID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            If sender.Name = TxtCustID.Name Then
                dtSearch = ObjGlobal.getCusst_Solomon
                ls_OldKode = TxtCustID.Text.Trim
                ls_Judul = "Customer"
            ElseIf sender.Name = TxtInvtID.Name Then
                If TxtCustID.Text = "" Then
                    TxtCustID.Focus()
                    Throw New Exception("Silahkan pilih customer !")
                End If
                dtSearch = ObjGlobal.getPartNo_Solomon(TxtCustID.Text)
                ls_OldKode = TxtInvtID.Text.Trim
                ls_Judul = "Inventory"
            End If
            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Data1 As String = ""
            Dim Data2 As String = ""
            Dim Data3 As String = ""
            Dim Data4 As String = ""

            If lF_SearchData.Values IsNot Nothing Then
                If sender.Name = TxtCustID.Name Then
                    Data1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Data2 = lF_SearchData.Values.Item(1).ToString.Trim
                    TxtCustID.Text = Data1
                    TxtCustName.Text = Data2
                    TxtInvtID.Focus()
                End If
                If sender.Name = TxtInvtID.Name Then
                    Data1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Data2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Data3 = lF_SearchData.Values.Item(2).ToString.Trim
                    TxtInvtID.Text = Data1
                    TxtPartNo.Text = Data2
                    TxtInvtName.Text = Data3
                    TxtModel.Focus()

                    With ObjForecastPrice
                        .Tahun = TxtTahun.Text
                        .CustID = TxtCustID.Text
                        .InvtID = TxtInvtID.Text
                        .PartNo = TxtPartNo.Text
                    End With
                    Dim IsInvtIDExist = ObjForecastPrice.ValidateUpdate
                    If IsInvtIDExist Then
                        XtraMessageBox.Show("Data sudah ada !")
                        ObjForecastPrice.GetAllDataGridById(True)
                        With ObjForecastPrice
                            TxtId.Text = .Id
                            TxtTahun.Text = .Tahun
                            TxtCustID.Text = .CustID
                            TxtCustName.Text = .Customer
                            TxtInvtID.Text = .InvtID
                            TxtInvtName.Text = .Description
                            TxtPartNo.Text = .PartNo
                            TxtModel.Text = .Model
                            TxtOePe.Text = .OePe
                            TxtInSub.Text = .INSub
                            TxtSite.Text = .Site
                            LoadDataNew()

                            With GridView1
                                .SetRowCellValue(0, "Qty1", ObjForecastPrice.JanQty1)
                                .SetRowCellValue(0, "Qty2", ObjForecastPrice.JanQty2)
                                .SetRowCellValue(0, "Qty3", ObjForecastPrice.JanQty3)
                                .SetRowCellValue(0, "PO1", ObjForecastPrice.Jan_PO1)
                                .SetRowCellValue(0, "PO2", ObjForecastPrice.Jan_PO2)
                                .SetRowCellValue(0, "Harga1", ObjForecastPrice.JanHarga1)
                                .SetRowCellValue(0, "Harga2", ObjForecastPrice.JanHarga2)
                                .SetRowCellValue(0, "Harga3", ObjForecastPrice.JanHarga3)

                                .SetRowCellValue(1, "Qty1", ObjForecastPrice.FebQty1)
                                .SetRowCellValue(1, "Qty2", ObjForecastPrice.FebQty2)
                                .SetRowCellValue(1, "Qty3", ObjForecastPrice.FebQty3)
                                .SetRowCellValue(1, "PO1", ObjForecastPrice.Feb_PO1)
                                .SetRowCellValue(1, "PO2", ObjForecastPrice.Feb_PO2)
                                .SetRowCellValue(1, "Harga1", ObjForecastPrice.FebHarga1)
                                .SetRowCellValue(1, "Harga2", ObjForecastPrice.FebHarga2)
                                .SetRowCellValue(1, "Harga3", ObjForecastPrice.FebHarga3)

                                .SetRowCellValue(2, "Qty1", ObjForecastPrice.MarQty1)
                                .SetRowCellValue(2, "Qty2", ObjForecastPrice.MarQty2)
                                .SetRowCellValue(2, "Qty3", ObjForecastPrice.MarQty3)
                                .SetRowCellValue(2, "PO1", ObjForecastPrice.Mar_PO1)
                                .SetRowCellValue(2, "PO2", ObjForecastPrice.Mar_PO2)
                                .SetRowCellValue(2, "Harga1", ObjForecastPrice.MarHarga1)
                                .SetRowCellValue(2, "Harga2", ObjForecastPrice.MarHarga2)
                                .SetRowCellValue(2, "Harga3", ObjForecastPrice.MarHarga3)

                                .SetRowCellValue(3, "Qty1", ObjForecastPrice.AprQty1)
                                .SetRowCellValue(3, "Qty2", ObjForecastPrice.AprQty2)
                                .SetRowCellValue(3, "Qty3", ObjForecastPrice.AprQty3)
                                .SetRowCellValue(3, "PO1", ObjForecastPrice.Apr_PO1)
                                .SetRowCellValue(3, "PO2", ObjForecastPrice.Apr_PO2)
                                .SetRowCellValue(3, "Harga1", ObjForecastPrice.AprHarga1)
                                .SetRowCellValue(3, "Harga2", ObjForecastPrice.AprHarga2)
                                .SetRowCellValue(3, "Harga3", ObjForecastPrice.AprHarga3)

                                .SetRowCellValue(4, "Qty1", ObjForecastPrice.MeiQty1)
                                .SetRowCellValue(4, "Qty2", ObjForecastPrice.MeiQty2)
                                .SetRowCellValue(4, "Qty3", ObjForecastPrice.MeiQty3)
                                .SetRowCellValue(4, "PO1", ObjForecastPrice.Mei_PO1)
                                .SetRowCellValue(4, "PO2", ObjForecastPrice.Mei_PO2)
                                .SetRowCellValue(4, "Harga1", ObjForecastPrice.MeiHarga1)
                                .SetRowCellValue(4, "Harga2", ObjForecastPrice.MeiHarga2)
                                .SetRowCellValue(4, "Harga3", ObjForecastPrice.MeiHarga3)

                                .SetRowCellValue(5, "Qty1", ObjForecastPrice.JunQty1)
                                .SetRowCellValue(5, "Qty2", ObjForecastPrice.JunQty2)
                                .SetRowCellValue(5, "Qty3", ObjForecastPrice.JunQty3)
                                .SetRowCellValue(5, "PO1", ObjForecastPrice.Jun_PO1)
                                .SetRowCellValue(5, "PO2", ObjForecastPrice.Jun_PO2)
                                .SetRowCellValue(5, "Harga1", ObjForecastPrice.JunHarga1)
                                .SetRowCellValue(5, "Harga2", ObjForecastPrice.JunHarga2)
                                .SetRowCellValue(5, "Harga3", ObjForecastPrice.JunHarga3)

                                .SetRowCellValue(6, "Qty1", ObjForecastPrice.JulQty1)
                                .SetRowCellValue(6, "Qty2", ObjForecastPrice.JulQty2)
                                .SetRowCellValue(6, "Qty3", ObjForecastPrice.JulQty3)
                                .SetRowCellValue(6, "PO1", ObjForecastPrice.Jul_PO1)
                                .SetRowCellValue(6, "PO2", ObjForecastPrice.Jul_PO2)
                                .SetRowCellValue(6, "Harga1", ObjForecastPrice.JulHarga1)
                                .SetRowCellValue(6, "Harga2", ObjForecastPrice.JulHarga2)
                                .SetRowCellValue(6, "Harga3", ObjForecastPrice.JulHarga3)

                                .SetRowCellValue(7, "Qty1", ObjForecastPrice.AgtQty1)
                                .SetRowCellValue(7, "Qty2", ObjForecastPrice.AgtQty2)
                                .SetRowCellValue(7, "Qty3", ObjForecastPrice.AgtQty3)
                                .SetRowCellValue(7, "PO1", ObjForecastPrice.Agt_PO1)
                                .SetRowCellValue(7, "PO2", ObjForecastPrice.Agt_PO2)
                                .SetRowCellValue(7, "Harga1", ObjForecastPrice.AgtHarga1)
                                .SetRowCellValue(7, "Harga2", ObjForecastPrice.AgtHarga2)
                                .SetRowCellValue(7, "Harga3", ObjForecastPrice.AgtHarga3)

                                .SetRowCellValue(8, "Qty1", ObjForecastPrice.SepQty1)
                                .SetRowCellValue(8, "Qty2", ObjForecastPrice.SepQty2)
                                .SetRowCellValue(8, "Qty3", ObjForecastPrice.SepQty3)
                                .SetRowCellValue(8, "PO1", ObjForecastPrice.Sep_PO1)
                                .SetRowCellValue(8, "PO2", ObjForecastPrice.Sep_PO2)
                                .SetRowCellValue(8, "Harga1", ObjForecastPrice.SepHarga1)
                                .SetRowCellValue(8, "Harga2", ObjForecastPrice.SepHarga2)
                                .SetRowCellValue(8, "Harga3", ObjForecastPrice.SepHarga3)

                                .SetRowCellValue(9, "Qty1", ObjForecastPrice.OktQty1)
                                .SetRowCellValue(9, "Qty2", ObjForecastPrice.OktQty2)
                                .SetRowCellValue(9, "Qty3", ObjForecastPrice.OktQty3)
                                .SetRowCellValue(9, "PO1", ObjForecastPrice.Okt_PO1)
                                .SetRowCellValue(9, "PO2", ObjForecastPrice.Okt_PO2)
                                .SetRowCellValue(9, "Harga1", ObjForecastPrice.OktHarga1)
                                .SetRowCellValue(9, "Harga2", ObjForecastPrice.OktHarga2)
                                .SetRowCellValue(9, "Harga3", ObjForecastPrice.OktHarga3)

                                .SetRowCellValue(10, "Qty1", ObjForecastPrice.NovQty1)
                                .SetRowCellValue(10, "Qty2", ObjForecastPrice.NovQty2)
                                .SetRowCellValue(10, "Qty3", ObjForecastPrice.NovQty3)
                                .SetRowCellValue(10, "PO1", ObjForecastPrice.Nov_PO1)
                                .SetRowCellValue(10, "PO2", ObjForecastPrice.Nov_PO2)
                                .SetRowCellValue(10, "Harga1", ObjForecastPrice.NovHarga1)
                                .SetRowCellValue(10, "Harga2", ObjForecastPrice.NovHarga2)
                                .SetRowCellValue(10, "Harga3", ObjForecastPrice.NovHarga3)

                                .SetRowCellValue(11, "Qty1", ObjForecastPrice.DesQty1)
                                .SetRowCellValue(11, "Qty2", ObjForecastPrice.DesQty2)
                                .SetRowCellValue(11, "Qty3", ObjForecastPrice.DesQty3)
                                .SetRowCellValue(11, "PO1", ObjForecastPrice.Des_PO1)
                                .SetRowCellValue(11, "PO2", ObjForecastPrice.Des_PO2)
                                .SetRowCellValue(11, "Harga1", ObjForecastPrice.DesHarga1)
                                .SetRowCellValue(11, "Harga2", ObjForecastPrice.DesHarga2)
                                .SetRowCellValue(11, "Harga3", ObjForecastPrice.DesHarga3)
                            End With
                        End With
                    End If
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtQty1_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty1.EditValueChanged, TxtQty2.EditValueChanged,
        TxtQty3.EditValueChanged, TxtHarga1.EditValueChanged, TxtHarga2.EditValueChanged, TxtHarga3.EditValueChanged
        Try
            Grid.FocusedView.PostEditor()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
    '    Try
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 0 Then
    '            GridView1.SetRowCellValue(1, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(2, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(0, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 0 Then
    '            GridView1.SetRowCellValue(1, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(2, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(0, "Harga3"))
    '        End If
    '        '=====Februari
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 1 Then
    '            GridView1.SetRowCellValue(2, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(1, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 1 Then
    '            GridView1.SetRowCellValue(2, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(1, "Harga3"))
    '        End If

    '        '=====Maret
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 2 Then
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(2, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 2 Then
    '            GridView1.SetRowCellValue(3, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(2, "Harga3"))
    '        End If

    '        '=====April
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 3 Then
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(3, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 3 Then
    '            GridView1.SetRowCellValue(4, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(3, "Harga3"))
    '        End If

    '        '=====Mei
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 4 Then
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(4, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 4 Then
    '            GridView1.SetRowCellValue(5, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(4, "Harga3"))
    '        End If

    '        '=====Juni
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 5 Then
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(5, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 5 Then
    '            GridView1.SetRowCellValue(6, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(5, "Harga3"))
    '        End If

    '        '=====Juli
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 6 Then
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(6, "Harga2"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(6, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(6, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(6, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(6, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 6 Then
    '            GridView1.SetRowCellValue(7, "Harga1", GridView1.GetRowCellValue(6, "Harga3"))
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(6, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(6, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(6, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(6, "Harga3"))
    '        End If

    '        '=====Agustus
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 7 Then
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(7, "Harga2"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(7, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(7, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(7, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 7 Then
    '            GridView1.SetRowCellValue(8, "Harga1", GridView1.GetRowCellValue(7, "Harga3"))
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(7, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(7, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(7, "Harga3"))
    '        End If

    '        '=====September
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 8 Then
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(8, "Harga2"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(8, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(8, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 8 Then
    '            GridView1.SetRowCellValue(9, "Harga1", GridView1.GetRowCellValue(8, "Harga3"))
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(8, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(8, "Harga3"))
    '        End If

    '        '=====Oktober
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 9 Then
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(9, "Harga2"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(9, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 9 Then
    '            GridView1.SetRowCellValue(10, "Harga1", GridView1.GetRowCellValue(9, "Harga3"))
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(9, "Harga3"))
    '        End If

    '        '=====November
    '        If e.Column.FieldName = "Harga2" And e.RowHandle = 10 Then
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(10, "Harga2"))
    '        End If
    '        If e.Column.FieldName = "Harga3" And e.RowHandle = 10 Then
    '            GridView1.SetRowCellValue(11, "Harga1", GridView1.GetRowCellValue(10, "Harga3"))
    '        End If

    '        ''=====Desember
    '        'If e.Column.FieldName = "Harga2" And e.RowHandle = 11 Then
    '        '    GridView1.SetRowCellValue(12, "Harga1", GridView1.GetRowCellValue(11, "Harga2"))
    '        'End If
    '        'If e.Column.FieldName = "Harga3" And e.RowHandle = 11 Then
    '        '    GridView1.SetRowCellValue(12, "Harga1", GridView1.GetRowCellValue(11, "Harga3"))
    '        'End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub GridView1_FocusedColumnChanged(sender As Object, e As FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
    '    Dim view As GridView = TryCast(sender, GridView)
    '    If view.GetColumnError(e.PrevFocusedColumn) <> String.Empty Then
    '        view.FocusedColumn = e.PrevFocusedColumn
    '    End If
    'End Sub
End Class
