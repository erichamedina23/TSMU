

Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Public Class Frm_CR_Get_Mold

    Dim fc_Class As New ClsCR_CreateUser

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Grid1 As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim dtRef As DataTable

    Private Sub Frm_CR_Get_Mold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadGrid()
    End Sub

    Public Sub New(ByVal _ID As String,
                  ByRef _dt As DataTable,
                  ByRef _grid As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ID = _ID
        Grid1 = _grid
        dtRef = _dt


    End Sub

    'Public Sub CreateTable()
    '    dt1 = New DataTable
    '    dt1.Columns.AddRange(New DataColumn(2) {New DataColumn("Part No", GetType(String)),
    '                                                        New DataColumn("Part Name", GetType(String)),
    '                                                        New DataColumn("Check", GetType(Boolean))})

    '    Grid.DataSource = dt1
    '    GridView1.OptionsView.ShowAutoFilterRow = False
    'End Sub


    Private Sub LoadGrid()

        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dt = fc_Class.GetMold()

            dt.Columns.Add("Qty")
            dt.Columns.Add("Price")
            dt.Columns.Add("Amount")
            dt.Columns.Add("PR No")
            dt.Columns.Add("Curr")
            dt.Columns.Add("Rate")
            dt.Columns.Add("Balance")
            dt.Columns.Add("Remaining Budget")


            For a As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(a).Item("Qty") = "0"
                dt.Rows(a).Item("Price") = "0"
                dt.Rows(a).Item("Amount") = "0"
                dt.Rows(a).Item("PR No") = ""
                dt.Rows(a).Item("Curr") = ""
                dt.Rows(a).Item("Rate") = "1"
                dt.Rows(a).Item("Balance") = "0"
                dt.Rows(a).Item("Remaining Budget") = 0
            Next

            Grid.DataSource = dt
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Badd_Click(sender As Object, e As EventArgs) Handles Badd.Click

        Dim MyNewRow As DataRow
        Dim chkSelect As Boolean

        For j As Integer = 0 To GridView1.RowCount - 1

            chkSelect = If(GridView1.GetRowCellValue(j, GridView1.Columns("Check")) Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check"))))
            MyNewRow = dtRef.NewRow
            If chkSelect = True Then

                With MyNewRow
                    .Item("Name Of Goods") = GridView1.GetRowCellValue(j, GridView1.Columns("Name Of Goods")).ToString
                    .Item("Spesification") = GridView1.GetRowCellValue(j, GridView1.Columns("Spesification")).ToString
                    .Item("Qty") = GridView1.GetRowCellValue(j, GridView1.Columns("Qty")).ToString
                    .Item("Price") = GridView1.GetRowCellValue(j, GridView1.Columns("Price")).ToString
                    .Item("Amount") = GridView1.GetRowCellValue(j, GridView1.Columns("Amount")).ToString
                    .Item("Curr") = "IDR"
                    .Item("Rate") = GridView1.GetRowCellValue(j, GridView1.Columns("Rate")).ToString
                    .Item("Balance") = GridView1.GetRowCellValue(j, GridView1.Columns("Balance")).ToString
                    .Item("Remaining Budget") = 0
                End With
                dtRef.Rows.Add(MyNewRow)
                dtRef.AcceptChanges()

            End If

        Next

        Me.Close()


    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub
End Class