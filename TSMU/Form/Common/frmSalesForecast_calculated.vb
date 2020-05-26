Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting

Public Class frmSalesForecast_calculated
    'Dim ff_Detail As frmBoM_Budget_Calculate_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSalesForecastCalculate

    Private Sub frmSalesForecast_calculated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            Dim ds As New DataSet()
            Dim Header As String = fc_Class.getHeader()
            Dim Detail As String = fc_Class.getDetails()
            Dim daHeader As SqlDataAdapter
            Dim daDetail As New SqlDataAdapter

            Using conn As New SqlConnection
                conn.ConnectionString = GetConnString()
                conn.Open()
                daHeader = New SqlDataAdapter(Header, conn)
                daDetail = New SqlDataAdapter(Detail, conn)
                daHeader.Fill(ds, "Header")
                daDetail.Fill(ds, "Details")
            End Using


            Dim keyColumn As DataColumn = ds.Tables("Header").Columns("ID")
            Dim foreignKeyColumn As DataColumn = ds.Tables("Details").Columns("ID")
            ds.Relations.Add("HeaderDetails", keyColumn, foreignKeyColumn)

            Grid.DataSource = ds.Tables("Header")
            Grid.ForceInitialize()


            Dim View1 As GridView = New GridView(Grid)

            Grid.LevelTree.Nodes.Add("HeaderDetails", View1)
            View1.ViewCaption = "Details"
            GridView1.Columns("ID").VisibleIndex = -1

            View1.PopulateColumns(ds.Tables("Details"))
            View1.Columns("ID").VisibleIndex = -1

            View1.OptionsView.ShowAutoFilterRow = True
            View1.OptionsView.ShowGroupPanel = False
            View1.OptionsView.ColumnAutoWidth = False
            'View1.BestFitColumns()

            'View1.Columns("UnitPrice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'View1.Columns("UnitPrice").DisplayFormat.FormatString = "c2"

            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()

                FormatGridView(GridView1)
                'FormatGridView(View1)
                For Each column As GridColumn In View1.Columns
                    column.OptionsColumn.AllowSort = DefaultBoolean.[False]
                    column.BestFit()
                Next
                'BestFit(View1)

            End If
        Catch ex As Exception
            'Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                Dim save As New SaveFileDialog
                save.Filter = "Excel File|*.xls"
                save.Title = "Save an Excel File"
                If save.ShowDialog = DialogResult.OK Then
                    'GridView1.ZoomView()
                    'GridView1.ExportToXlsx(save.FileName)
                    'GridView1.NormalView()
                    GridView1.OptionsPrint.PrintDetails = True
                    GridView1.OptionsPrint.ExpandAllDetails = True
                    GridView1.OptionsPrint.ExpandAllGroups = True
                    Grid.ExportToXls(save.FileName, New XlsExportOptionsEx() With {
                        .ExportType = DevExpress.Export.ExportType.WYSIWYG
                    })
                    Process.Start(save.FileName)
                End If
                'getPath()
                '    Dim Filename As String = path & "\Forecast_.xls"
                '    'Dim FileName As String = "D:\Grid.xls"
                '    Grid.ExportToXls(Filename)

            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub BestFitAllViews()
        For Each view As BaseView In Grid.ViewCollection
            BestFit(TryCast(view, GridView))
        Next
    End Sub

    Private Sub BestFit(ByVal dview As GridView)
        If dview Is Nothing Then Return
        dview.OptionsView.ColumnAutoWidth = False

        For Each gc As GridColumn In dview.Columns
            gc.BestFit()
        Next
    End Sub
    'Private Sub GridView1_ColumnWidthChanged(sender As Object, e As ColumnEventArgs) Handles GridView1.ColumnWidthChanged
    'Dim gridView As GridView = CType(sender, GridView)
    'Dim gridControl As GridControl = gridView.GridControl
    'For Each view As GridView In gridControl.ViewCollection
    '    If (view Is gridView) Then
    '        Dim column As GridColumn = view.Columns(e.Column.FieldName)
    '        If (Not (column) Is Nothing) Then
    '            column.Width = ((e.Column.Width - GetColumnXCoordinate(view, column)) _
    '                        + GetColumnXCoordinate(gridView, column))
    '        End If

    '    End If

    'Next
    'End Sub
    'Private Function GetColumnXCoordinate(ByVal view As GridView, ByVal column As GridColumn) As Integer
    '    Return (TryCast(view.GetViewInfo(), GridViewInfo)).ColumnsInfo.Find(Function(y) y.Column IsNot Nothing AndAlso y.Column.FieldName = column.FieldName).Bounds.X
    'End Function
End Class
