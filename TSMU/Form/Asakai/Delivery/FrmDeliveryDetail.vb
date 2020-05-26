Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports ExcelDataReader
'Imports GemBox.Spreadsheet
Imports System.Data.OleDb

Public Class FrmDeliveryDetail

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New DeliveryModel

    Dim GridDtl As GridControl
    Dim dt As New DataTable

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

    Dim ObjDeliveryDetail As New DeliveryDetailModel
    Dim Tanggal As Date
    Dim Keterangan As String = ""
    Dim IdTransaksi As String = ""

    Dim FileLokasi As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmDeliveryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
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
                Tanggal = fc_Class.Tanggal
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Delivery " & fs_Code
            Else
                Me.Text = "Delivery"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmDeliveryHeader"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    LblTanggal.Text = Format(fc_Class.Tanggal, gs_FormatSQLDateIn)

                End With
            Else
                LblTanggal.Text = Format(Date.Now, gs_FormatSQLDateIn)

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridDelivery As New DataTable
                dtGridDelivery = fc_Class.GetDataDetailDelivery(fs_Code)
                Grid.DataSource = dtGridDelivery
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click

        Try
            Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}


                If ofd.ShowDialog() = DialogResult.OK Then
                    FileLokasi = ofd.FileName

                    If IO.File.Exists(FileLokasi) Then
                        Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                        cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                        Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                        cn.Open()
                        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT F2 as InvtId
                        '                                                 ,F3 as [Item Number]
                        '                                               ,F1 as Customer
                        '                                                ,F4 as [Delivery Due Date]
                        '                                                ,F5 as [Qty Order]
                        '                                                ,F6 as Delivery
                        '                                                ,F7 as Jumlah
                        '                                                ,F8 as [Stock TNG 08 DEL]
                        '                                                ,F9 as [Stock TNG 05 WHJ]
                        '                                                ,F10 as [StockTNG06SFG]
                        '                                                ,F11 as [Stock 2nd]
                        '                                                ,F12 as [Stock Paint]
                        '                                                ,F13 as [Stock Inject Presisi]
                        '                                                ,F14 as WHP
                        '                                                ,F15 as [Stock TNG 04-02 PNT]
                        '                                                ,F16 as [Total Stock]
                        '                                                ,F17 as Balance
                        '                                                ,F18 as Keterangan
                        '                                                 FROM [ASAKAI$A4:R200] where F2 <>''", cn)

                        'Dim cmd As OleDbCommand = New OleDbCommand("SELECT F2 as InvtId
                        '                                                 ,F3 as [Item Number]
                        '                                               ,F1 as Customer
                        '                                                ,F4 as [Delivery Due Date]
                        '                                                ,F5 as [Qty Order]
                        '                                                ,F6 as Delivery
                        '                                                ,F7 as Jumlah
                        '                                                ,F8 as [TNG 08]
                        '                                                ,F9 as [TNG 05 06]
                        '                                                ,F10 as [Painting]
                        '                                                ,F11 as [Whp]
                        '                                                ,F12 as [Total Stock]
                        '                                                ,F13 as [Balance]
                        '                                                ,F14 as Keterangan
                        '                                                 FROM [ASAKAI$A4:R200] where F2 <>''", cn)

                        Dim cmd As OleDbCommand = New OleDbCommand("SELECT F2 as InvtId
                                                                         ,F3 as [Item Number]
                                                                       ,F1 as Customer
                                                                        ,F4 as [Delivery Due Date]
                                                                        ,F5 as [Qty Order]
                                                                        ,F6 as Delivery
                                                                        ,F7 as Jumlah
                                                                        ,F8 as [TNG 08]
                                                                        ,F9 as [TNG 05 06]
                                                                        ,F10 as [Painting]
                                                                        ,F11 as [Whp]
                                                                        ,F14 as Keterangan
                                                                         FROM [ASAKAI$A4:R200] where F2 <>''", cn)

                        'Dim dt As New DataTable
                        dt.Load(cmd.ExecuteReader)


                        Dim cbHeader As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                        cbHeader.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                        Dim cnHeader As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbHeader.ConnectionString}

                        cnHeader.Open()
                        Dim cmdHeader As OleDbCommand = New OleDbCommand("SELECT F1 as A FROM [ASAKAI$A1:R1]", cnHeader)
                        Dim dtHeader As New DataTable
                        dtHeader.Load(cmdHeader.ExecuteReader)




                        cnHeader.Close()

                        Tanggal = dtHeader.Rows(0).Item("A")
                        LblTanggal.Text = Format(Tanggal, "dd-MM-yyyy").ToString
                        Grid.DataSource = dt


                    End If
                End If
            End Using
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub



    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
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
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()

                If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(1)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(2)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(3)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(4)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(5)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(6)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(7)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(8)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(9)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(10)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(11)).ToString = "" OrElse
                  GridView1.GetRowCellValue(i, GridView1.Columns(12)).ToString = "" Then
                    IsEmpty = True
                    MessageBox.Show("Pastikan Data tidak ada yang kosong")
                    Exit Sub
                End If
            Next


            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                IdTransaksi = fc_Class.IDTrans
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailDelivery.Clear()


                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDeliveryDetail = New DeliveryDetailModel
                    With ObjDeliveryDetail

                        .IDTrans = IdTransaksi
                        .invtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .invtName = Convert.ToString(GridView1.GetRowCellValue(i, "Item Number"))
                        .Customer = GridView1.GetRowCellValue(i, "Customer")
                        .Delivery_Due_Date = GridView1.GetRowCellValue(i, "Delivery Due Date")
                        .Qty_Order = GridView1.GetRowCellValue(i, "Qty Order")
                        .Delivery = GridView1.GetRowCellValue(i, "Delivery")
                        .Jumlah = GridView1.GetRowCellValue(i, "Jumlah")
                        .Stock_TNG_08_DEL = GridView1.GetRowCellValue(i, "TNG 08")
                        .Stock_TNG_05_WHJ = GridView1.GetRowCellValue(i, "TNG 05 06")
                        .Stock_Paint = GridView1.GetRowCellValue(i, "Painting")
                        .WHP = GridView1.GetRowCellValue(i, "Whp")
                        .Total_Stock = GridView1.GetRowCellValue(i, "Total Stock")
                        .Balance = GridView1.GetRowCellValue(i, "Balance")
                        .Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))


                    End With
                    fc_Class.ObjDetailDelivery.Add(ObjDeliveryDetail)

                Next

                fc_Class.InsertDelivery()
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                IdTransaksi = fc_Class.IDTrans
                'Tanggal = fc_Class.ta
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailDelivery.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjDeliveryDetail = New DeliveryDetailModel
                    With ObjDeliveryDetail
                        .IDTrans = IdTransaksi
                        .invtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .invtName = Convert.ToString(GridView1.GetRowCellValue(i, "Item Number"))
                        .Customer = GridView1.GetRowCellValue(i, "Customer")
                        .Delivery_Due_Date = GridView1.GetRowCellValue(i, "Delivery Due Date")
                        .Qty_Order = GridView1.GetRowCellValue(i, "Qty Order")
                        .Delivery = GridView1.GetRowCellValue(i, "Delivery")
                        .Jumlah = GridView1.GetRowCellValue(i, "Jumlah")
                        .Stock_TNG_08_DEL = GridView1.GetRowCellValue(i, "TNG 08")
                        .Stock_TNG_05_WHJ = GridView1.GetRowCellValue(i, "TNG 05 06")
                        .Stock_Paint = GridView1.GetRowCellValue(i, "Painting")
                        .WHP = GridView1.GetRowCellValue(i, "Whp")
                        .Total_Stock = GridView1.GetRowCellValue(i, "Total Stock")
                        .Balance = GridView1.GetRowCellValue(i, "Balance")
                        .Keterangan = Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan"))

                    End With
                    fc_Class.ObjDetailDelivery.Add(ObjDeliveryDetail)





                Next

                fc_Class.Tanggal = Tanggal
                fc_Class.UpdateData()
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
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
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(LblTanggal.Text) Then
                ErrorProvider1.SetError(LblTanggal, "Value cannot be empty")
            ElseIf GridView1.RowCount = 0 Then
                ErrorProvider1.SetError(Grid, "Please Input Data In Grid")
            ElseIf CmbLaporan.Text = "" Or CmbLaporan.Text = "-" Then
                MessageBox.Show("Pilih Type Laporan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            Else

                ErrorProvider1.Clear()
                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class

                    .Tanggal = Format(CDate(Tanggal))
                    .Laporan = Trim(CmbLaporan.Text)

                    If isUpdate = False Then      'Belum Di Edit
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

    Private Sub CmbLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLaporan.SelectedIndexChanged

    End Sub

    Private Sub CmbLaporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbLaporan.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (0) Then
            e.Handled = True
        End If


    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub
End Class
