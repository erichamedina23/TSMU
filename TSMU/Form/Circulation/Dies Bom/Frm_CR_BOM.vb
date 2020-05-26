Public Class Frm_CR_BOM
    Dim DtGridBarang As DataTable
    Dim fc_Class As New ClsCR_CreateUser
    Dim BomT1 As New ClsCR_BomT1
    Dim Description_Of_Cost As New ClsCR_Description_of_Cost
    Public T_Event As String



    Private Sub Frm_CR_BOM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()

    End Sub
    Private Sub CreateTableBarang()

        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(3) {New DataColumn("No", GetType(String)),
                                                            New DataColumn("PartNo", GetType(String)),
                                                            New DataColumn("PartName", GetType(String)),
                                                            New DataColumn("Qty", GetType(Double))})

        Grid.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub

    Private Sub BAddRows_Click(sender As Object, e As EventArgs) Handles BAddRows.Click


        Dim No As Integer = 0
        For i As Integer = 1 To GridView1.RowCount
            No = i

        Next

        GridView1.AddNewRow()
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "No", (No + 1).ToString)


    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

        fc_Class.Collection_BomT1.Clear()
        For j As Integer = 0 To GridView1.RowCount - 1

            BomT1 = New ClsCR_BomT1
            With BomT1
                .D_T1 = T_Event
                .D_PartNo = Convert.ToString(GridView1.GetRowCellValue(j, "PartNo"))
                .D_ParName = Convert.ToString(GridView1.GetRowCellValue(j, "PartName"))
                .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(j, "Qty"))

            End With
            fc_Class.Collection_BomT1.Add(BomT1)

        Next

        fc_Class.InsertTemp()

        Me.Hide()

    End Sub
End Class