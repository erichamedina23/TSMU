Public Class frmBoM_detail_input
    Public IsClosed As Boolean
    Dim fs_InvtId As String
    Dim fs_Desc As String
    Dim fs_Qty As String
    Dim fs_Unit As String
    Dim fs_judul As String
    Dim Grid As DataGridView
    Dim isNew As Boolean
    Dim isUpdate As Boolean = False
    Dim fs_split As String = "'"
    Dim fc_Class As New clsBoM
    Dim dtTable As DataTable

    Public Sub New(ByVal _InvtId As String, _
                   ByVal _Desc As String, _
                   ByVal _Qty As String, _
                   ByVal _Unit As String, _
                      ByVal _judul As String, _
                      ByRef _grid As DataGridView, _
                      ByRef _dt As DataTable, _
                      ByVal _isNew As Boolean)

        InitializeComponent()
        fs_InvtId = _InvtId
        fs_Desc = _Desc
        fs_Qty = _Qty
        fs_Unit = _Unit
        fs_judul = _judul
        Grid = _grid
        dtTable = _dt
        isNew = _isNew
    End Sub
    Public Enum ColIndex As Byte
        InvtId = 0
        Desc = 1
        Qty = 2
        Unit = 3
    End Enum
    Private Sub frmBoM_detail_input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            If _txtQty.Text = "0" OrElse _txtQty.Text = "" Then
                _txtQty.Focus()
                Throw New Exception("Qty tidak boleh kosong atau 0 !")
            End If
            If isNew = True Then
                Dim MyNewRow As DataRow
                MyNewRow = dtTable.NewRow
                With MyNewRow
                    .Item(0) = _txtInvID.Text.Trim
                    .Item(1) = _txtDesc.Text.Trim
                    .Item(2) = _txtQty.Text.Trim
                    .Item(3) = _txtUnit.Text.Trim
                End With
                dtTable.Rows.Add(MyNewRow)
                dtTable.AcceptChanges()
            Else
                With Grid.SelectedRows(0)
                    .Cells(ColIndex.InvtId).Value = _txtInvID.Text.Trim
                    .Cells(ColIndex.Desc).Value = _txtDesc.Text.Trim
                    .Cells(ColIndex.Qty).Value = _txtQty.Text.Trim
                    .Cells(ColIndex.Unit).Value = _txtUnit.Text.Trim
                End With
            End If
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_validate As Boolean = False
        Try
            Dim dtview As DataView
            dtview = New DataView(Grid.DataSource)
            dtview.RowFilter = "[Inventory ID]= " & QVal(_txtInvID.Text.Trim)
            Dim dtTable As DataTable = dtview.ToTable

            If _txtInvID.Text = "" Then
                btnCari.Focus()
                Call ShowMessage("Please fill Inventory ID !", MessageTypeEnum.ErrorMessage)
            ElseIf dtTable.Rows.Count > 0 AndAlso _txtInvID.Text.Trim <> fs_InvtId Then
                Call ShowMessage("Data Duplicate !", MessageTypeEnum.ErrorMessage)
            Else
                lb_validate = True
            End If
        Catch ex As Exception
            lb_validate = False
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return lb_validate
    End Function
    Private Sub LoadTxtBox(ByVal kode As String)
        If kode <> True Then
            _txtInvID.Text = fs_InvtId
            _txtDesc.Text = fs_Desc
            _txtQty.Text = fs_Qty
            _txtUnit.Text = fs_Unit
            btnCari.Focus()
        Else
            _txtInvID.Text = fs_InvtId
            _txtDesc.Text = fs_Desc
            _txtQty.Text = fs_Qty
            _txtUnit.Text = fs_Unit
            btnCari.Focus()
        End If
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            Me.Text = fs_judul & " - " & IIf((fs_InvtId) Is "", "New Inventory ID ", "Inventory ID " & fs_InvtId)
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox(isNew)
            Call InputBeginState(Me)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            IsClosed = True
            Me.Hide()
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox(isNew)
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            If sender.Name = btnCari.Name Then
                dtSearch = fc_Class.getInvtItem
                ls_OldKode = _txtInvID.Text.Trim
                ls_Judul = "Items"

            End If

            'dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            'dtSearch.Rows(0).Item(0) = "ALL"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""
            Dim ls_unit As String = ""
            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                ls_unit = lF_SearchData.Values.Item(2).ToString.Trim
                If sender.Name = btnCari.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _txtInvID.Text = ls_Kode
                    _txtDesc.Text = ls_Nama
                    _txtUnit.Text = ls_unit
                End If
            End If
            _txtQty.Focus()
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
