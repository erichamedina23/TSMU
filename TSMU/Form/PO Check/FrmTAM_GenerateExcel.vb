Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class FrmTAM_GenerateExcel
    Private Initializing As Boolean = False
    Dim tam As Tam_Trans

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
        SaveToExcel(Grid, "TAM", "", False)
        Try
            For i = 0 To GridView1.RowCount - 1
                Dim tam = New Tam_Trans
                Dim DelDate As String = GridView1.GetRowCellValue(i, "DELIVERY DATE")
                Try
                    tam.UpdateFlag(DelDate)
                Catch ex As Exception
                    Continue For
                End Try
            Next
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        If RadioGroup1.SelectedIndex = 0 Then
            LoadToGrid(0)
        Else
            LoadToGrid(1)
        End If
    End Sub
    Private Sub LoadToGrid(flag As Integer)

        tam = New Tam_Trans
        Dim dt As New DataTable
        dt = tam.GetDataExcel(Format(TxtEtd.EditValue, "yyyyMMdd"), flag)
        Grid.DataSource = dt
        If dt.Rows.Count > 1 Then

            GridView1.BestFitColumns()
            GridCellFormat(GridView1)
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

    Private Sub FrmTAM_GenerateExcel_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False

    End Sub
End Class
