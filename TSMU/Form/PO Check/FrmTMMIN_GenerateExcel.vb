Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class FrmTMMIN_GenerateExcel
    Dim tmmin As TMMINmodel
    Private Initializing As Boolean = False
    Sub New()
        Initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmTMMIN_GenerateExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
        TxtEtd.EditValue = DateTime.Today

    End Sub

    Public Overrides Sub Proc_Excel()
        SaveToExcel(Grid, "TMMIN")
        Try
            For i = 0 To GridView1.RowCount - 1
                Dim tmmin = New TMMINmodel
                Dim KanbanID As String = GridView1.GetRowCellValue(i, "Kanban ID")
                Try
                    tmmin.UpdateFlag(KanbanID)
                Catch ex As Exception
                    Continue For
                End Try
            Next
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadToGrid(flag As Integer)
        tmmin = New TMMINmodel
        Dim dt As New DataTable

        dt = tmmin.GetKanban(Format(TxtEtd.EditValue, "yyyy-MM-dd"), flag)
        Grid.DataSource = dt
        If dt.Rows.Count > 1 Then

            GridView1.BestFitColumns()
            GridCellFormat(GridView1)
        End If

    End Sub

    Public Overrides Sub Proc_Refresh()

        If RadioGroup1.SelectedIndex = 0 Then
            LoadToGrid(0)
        Else
            LoadToGrid(1)
        End If
    End Sub
    Private Sub TxtEtd_EditValueChanged(sender As Object, e As EventArgs) Handles TxtEtd.EditValueChanged
        Try
            If Initializing Then
                Exit Sub
            End If
            If RadioGroup1.SelectedIndex = 0 Then
                LoadToGrid(0)
            Else
                LoadToGrid(1)
            End If
        Catch ex As Exception

            XtraMessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Try
            If Initializing Then
                Exit Sub
            End If
            If RadioGroup1.SelectedIndex = 0 Then
                LoadToGrid(0)
            Else
                LoadToGrid(1)

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmTMMIN_GenerateExcel_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = True
    End Sub
End Class
