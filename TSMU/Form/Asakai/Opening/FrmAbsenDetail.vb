Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmAbsenDetail

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable


    Dim DeptID As String




    '---------------------------
    Dim DtScan As DataTable
    Dim ObjAbsen As New AbsenModel
    Dim ObjAbsenHeader As New AbsenModel
    Dim ObjAbsenDetail As New AbsenModelDetail
    Dim Total As Double




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


    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(2) {New DataColumn("ID", GetType(String)),
                                                            New DataColumn("Absen", GetType(String)),
                                                            New DataColumn("Jumlah", GetType(Integer))})
        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub


    Private Sub FrmAbsenDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub
    Private Sub jmlabsen_EditValueChanged(sender As Object, e As EventArgs) Handles jmlabsen.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        'Grid.FocusedView.PostEditor()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjAbsen.DeptID = fs_Code
                ObjAbsen.GetDataByDate(fs_Code2)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Master Absen " & fs_Code
            Else
                Me.Text = "Master New Absen"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmAbsen"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code = "" Then
                Dim dtGrid As New DataTable
                dtGrid = ObjAbsen.GetAllDataTableKategoriAbsen()
                Grid.DataSource = dtGrid

                DeptID = String.Empty
                DeptID = gh_Common.GroupID
                TxtDepartemen.Text = DeptID

                'Dim dtGrid As New DataTable
                dtGrid = Grid.DataSource
                Call GetJumlahKaryawan()

            Else
                Dim dtGrid As New DataTable
                ObjAbsen.DeptID = fs_Code
                dtGrid = ObjAbsen.GetDataDetailByDate(fs_Code2)
                Grid.DataSource = dtGrid
                'If dtGrid.Rows.Count > 0 Then
                '    GridCellFormat(GridView1)
                'End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjAbsen
                    TxtDepartemen.Text = .DeptID
                    TxtTanggalAbsen.Text = Format(.TanggalAbsen, gs_FormatSQLDateIn)
                    TxtPersen.Text = .Percentage.ToString
                    TxtJumlahKaryawan.Text = .Jumlah.ToString
                End With
            Else
                TxtPersen.Text = "100"
                TxtTanggalAbsen.EditValue = DateTime.Now
                'TextEdit1.EditValue = Format(DateTime.Now)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Dim IdKategoriAbsen, KategoriAbsen As String
    Dim Jumlah As Integer

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If String.IsNullOrEmpty(TxtDepartemen.Text) Then
                ErrorProvider.SetError(TxtDepartemen, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtDepartemen, "")
            End If

            If String.IsNullOrEmpty(TxtTanggalAbsen.Text) Then
                ErrorProvider.SetError(TxtTanggalAbsen, "Value cannot be empty.")
            Else
                ErrorProvider.SetError(TxtTanggalAbsen, "")
            End If

            Dim success As Boolean = True
            For Each c As Control In LayoutControl1.Controls
                If ErrorProvider.GetError(c).Length > 0 Then
                    success = False
                End If
            Next

            If success Then
                lb_Validated = True
            End If

            If lb_Validated Then
                With ObjAbsen
                    .DeptID = TxtDepartemen.Text
                    .Percentage = TxtPersen.Text
                    .JumlahKaryawan = TxtJumlahKaryawan.Text
                    Dim oDate As DateTime = DateTime.ParseExact(TxtTanggalAbsen.Text, "dd-MM-yyyy", provider)
                    .TanggalAbsen = oDate



                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
                        '.ValidateUpdate()
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
                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                If GridView1.GetRowCellValue(i, GridView1.Columns("No")).ToString = "" OrElse
                       GridView1.GetRowCellValue(i, GridView1.Columns("Description")).ToString = "" OrElse
                       GridView1.GetRowCellValue(i, GridView1.Columns("Jumlah")).ToString = "" Then
                    IsEmpty = True
                    GridView1.DeleteRow(i)
                End If
            Next


            If isUpdate = False Then
                With ObjAbsen
                    '.DeptID = TxtDepartemen.Text
                    '.Percentage = TxtPersen.Text
                    '.JumlahKaryawan = TxtJumlahKaryawan.Text
                    ''Dim oDate As DateTime = DateTime.ParseExact(TxtTanggalAbsen.Text, "dd-MM-yyyy", provider)
                    '.TanggalAbsen = oDate
                End With

                ObjAbsen.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Jumlah").ToString <> "" Then
                        ObjAbsenDetail = New AbsenModelDetail
                        With ObjAbsenDetail
                            '.TanggalAbsen = CDate(TxtTanggalAbsen.EditValue)
                            .DeptID = TxtDepartemen.Text
                            .ID = Convert.ToInt32(GridView1.GetRowCellValue(i, "No"))
                            .Jumlah = Convert.ToInt32(GridView1.GetRowCellValue(i, "Jumlah"))
                        End With
                        ObjAbsen.ObjDetails.Add(ObjAbsenDetail)
                    End If
                Next
                ObjAbsen.InsertDataAbsen()
                GridDtl.DataSource = ObjAbsen.GetDataLoad()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else

                ObjAbsen.ObjDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "Jumlah").ToString <> "" Then
                            ObjAbsenDetail = New AbsenModelDetail
                        With ObjAbsenDetail
                            '.TanggalAbsen = CDate(TxtTanggalAbsen.EditValue)
                            .DeptID = TxtDepartemen.Text
                            .Percentage = TxtPersen.Text
                            .ID = Convert.ToInt32(GridView1.GetRowCellValue(i, "No"))
                            .Jumlah = Convert.ToInt32(GridView1.GetRowCellValue(i, "Jumlah"))

                        End With
                        ObjAbsen.ObjDetails.Add(ObjAbsenDetail)
                        End If
                    Next
                ObjAbsen.UpdateData()
                GridDtl.DataSource = ObjAbsen.GetDataLoad()
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




    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        'Dim ignoreCancel As Boolean = False
        'TxtIDAbsen.DoValidate()
        'TxtDescription.DoValidate()
        'TxtJumlah.DoValidate()

        'If DxValidationProvider1.GetInvalidControls().Contains(TxtIDAbsen) _
        '    OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDescription) Then
        '    ignoreCancel = True
        'Else
        '    ignoreCancel = True
        'End If

        'MyBase.OnFormClosing(e)
        'e.Cancel = Not ignoreCancel
    End Sub


    Private Sub GridView1_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim tombol As Integer
        'tombol = Asc(e.KeyChar)


        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            'e.Handled = True

        End If
    End Sub

    Public Sub GetJumlahKaryawan()

        Try

            Dim Departemen As DepartemenModel = New DepartemenModel
            Dim dt As New DataTable
            dt = Departemen.getDataDepartemenByID(DeptID)
            TxtJumlahKaryawan.Text = Departemen.Jumlah.ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Call HitungPersentase()
    End Sub



    Private Sub GridView1_ColumnChanged(sender As Object, e As EventArgs) Handles GridView1.ColumnChanged
        'Call HitungPersentase()
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Sub HitungPersentase()

        Dim karyawan As Integer
        karyawan = Convert.ToInt32(TxtJumlahKaryawan.Text)

        Total = 0

        For i As Integer = 0 To GridView1.RowCount - 1

            GridView1.MoveFirst()
            If GridView1.GetRowCellValue(i, GridView1.Columns("Status")) = "TRUE" Then
                Total = (Total + Val(GridView1.GetRowCellValue(i, GridView1.Columns("Jumlah"))))
            End If


        Next
        TxtPersen.Text = Math.Round(Val(((karyawan - Total) / karyawan) * 100), 2).ToString
    End Sub



End Class
