Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmSuratJalanFin
    Dim ObjSj As ClsSJ
    Dim Username As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ObjSj = New ClsSJ

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmSuratJalanFin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadGrid(True)
        Call Proc_EnableButtons(True, True, False, True, True, False, False, False, False, False)
    End Sub

    Private Sub LoadGrid(IsLoad As Boolean)
        Try
            Dim dt As New DataTable
            ObjSj.NoTran = _TxtNo.Text
            dt = ObjSj.GetSJbyNoTran(IsLoad)
            _Grid1.DataSource = dt

            'Dim unbColumn As GridColumn = GridView2.Columns.AddField("ID")
            'unbColumn.VisibleIndex = GridView2.Columns.Count
            'unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            'unbColumn.Visible = True

            '' Disable editing.
            'unbColumn.OptionsColumn.AllowEdit = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        _Grid1.DataSource = Nothing
        _TxtNo.Text = ""
        _TxtNo.Focus()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If GridView2.RowCount = 0 Then
                Throw New Exception("Tidak ada data yang akan di simpan.")
            End If

            For i As Integer = 0 To GridView2.RowCount - 1
                Dim Checked As Boolean = False
                Dim ShipperID As String
                'Dim TglTerimaFin As DateTime

                ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                'TglTerimaFin = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tgl Check Fin")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tgl Check Fin"))))
                Checked = GridView2.GetRowCellValue(i, "Check")
                If Checked Then
                    Try
                        With ObjSj
                            .ShipperID = ShipperID
                            .TglCheckFin = DateTime.Today
                            .CheckFIn = Checked
                            .CreatedBy = gh_Common.Username
                            .UpdateFin()
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Continue For
                    End Try
                Else
                    Try
                        With ObjSj
                            .ShipperID = ShipperID
                            .TglCheckFin = Nothing
                            .CheckFIn = Nothing
                            .CreatedBy = gh_Common.Username
                            .UpdateFin()
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Continue For
                    End Try
                End If

            Next
            'btnFilter.Enabled = False
            LoadGrid(False)
            MsgBox("Data Saved !", MsgBoxResult.No)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub _TxtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles _TxtNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                LoadGrid(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSuratJalanFin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _TxtNo.Focus()
    End Sub
    Dim sj() As String
    Dim TempSJ As New List(Of String)
    Dim TempYIM As New List(Of String)
    Dim TempADM As New List(Of String)
    Private Sub _TxtNoSJ_KeyDown(sender As Object, e As KeyEventArgs) Handles _TxtNoSJ.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim dt As DataTable
                Dim Result As DataTable = New DataTable
                dt = New DataTable

                dt = _Grid1.DataSource
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("No Surat Jalan").ToString = _TxtNoSJ.Text Then
                        XtraMessageBox.Show("Data ketemu")
                        GridView2.FocusedRowHandle = i
                        TempSJ.Add(_TxtNoSJ.Text)
                    End If
                Next
                'Dim dv As DataView = New DataView(dt)
                'dv.RowFilter = "ShipperID = '" & _TxtNoSJ.Text & "'"
                'Result = dv.ToTable
                'If Result.Rows.Count > 0 Then

                'End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridView2_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView2.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("No Surat Jalan"))
                Dim array2() As String = TempSJ.ToArray
                For Each sj As String In array2
                    If category = sj Then
                        e.Appearance.BackColor = Color.LightBlue
                        e.Appearance.BackColor2 = Color.SeaShell
                        e.HighPriority = True
                    End If
                Next

                Dim YIM As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("SR YIM"))
                Dim arrayYIM() As String = TempYIM.ToArray
                For Each ym As String In arrayYIM
                    If YIM = ym Then
                        e.Appearance.BackColor = Color.LightBlue
                        e.Appearance.BackColor2 = Color.SeaShell
                        e.HighPriority = True
                    End If
                Next

                Dim ADM As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PO Customer"))
                Dim arrayADM() As String = TempADM.ToArray
                For Each dm As String In arrayADM
                    If ADM = dm Then
                        e.Appearance.BackColor = Color.LightBlue
                        e.Appearance.BackColor2 = Color.SeaShell
                        e.HighPriority = True
                    End If
                Next
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub GridView2_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView2.CustomUnboundColumnData
    '    Dim View As GridView = sender
    '    If e.Column.FieldName = "ID" Then
    '        Dim category As String = View.GetRowCellDisplayText(e.ListSourceRowIndex, View.Columns("No Surat Jalan"))
    '        Dim array2() As String = TempSJ.ToArray
    '        For Each sj As String In array2
    '            If category = sj Then
    '                e.Value = 1
    '            Else
    '                e.Value = 2
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub _TxtYiM_KeyDown(sender As Object, e As KeyEventArgs) Handles _TxtYiM.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim dt As DataTable
                Dim Result As DataTable = New DataTable
                dt = New DataTable

                dt = _Grid1.DataSource
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("SR YIM").ToString = _TxtYiM.Text Then
                        'XtraMessageBox.Show("Data ketemu")
                        GridView2.FocusedRowHandle = i
                        TempYIM.Add(_TxtYiM.Text)
                    End If
                Next
                'Dim dv As DataView = New DataView(dt)
                'dv.RowFilter = "ShipperID = '" & _TxtNoSJ.Text & "'"
                'Result = dv.ToTable
                'If Result.Rows.Count > 0 Then
                SendKeys.Send("{TAB}")
                'End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _TxtAdm_KeyDown(sender As Object, e As KeyEventArgs) Handles _TxtAdm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim dt As DataTable
                Dim Result As DataTable = New DataTable
                dt = New DataTable

                dt = _Grid1.DataSource
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("PO Customer").ToString = _TxtAdm.Text Then
                        'XtraMessageBox.Show("Data ketemu")
                        GridView2.FocusedRowHandle = i
                        TempADM.Add(_TxtAdm.Text)
                    End If
                Next
                'Dim dv As DataView = New DataView(dt)
                'dv.RowFilter = "ShipperID = '" & _TxtNoSJ.Text & "'"
                'Result = dv.ToTable
                'If Result.Rows.Count > 0 Then

                'End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
