
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Public Class Frm_NPP_Set_Grup

    Dim fc_Class As New Cls_NPP_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Part_No As String
    Dim Part_Name As String
    Dim Check As Boolean
    Dim Grid1 As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean


    Dim dt As DataTable
    Dim dtInduk As DataTable

    Private Sub Frm_NPP_Set_Grup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CreateTable()
        'If ID <> "" Then
        '    Call LoadGrid(ID)
        'End If

    End Sub

    Private Sub CreateTable()

        'dt = New DataTable


        'dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Part No", GetType(String)),
        '                                                   New DataColumn("Group ID", GetType(String)),
        '                                                   New DataColumn("Check", GetType(Boolean)),
        '                                                   New DataColumn("Part Name", GetType(String))})
        'Grid.DataSource = dt
        'GridView1.OptionsView.ShowAutoFilterRow = True


    End Sub
    Public Sub New(ByVal _ID As String,
                   ByVal _PartNo As String,
                   ByVal _PartName As String,
                   ByVal _Check As Boolean,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        Part_No = _PartNo
        ID = _ID
        Part_Name = _PartName
        Check = _Check
        IsNew = _IsNew
        Grid1 = _grid
        dtInduk = _dt


        For a As Integer = 0 To dtInduk.Rows.Count - 1
            dtInduk.Rows(a).Item("Check") = "False"
        Next
        Grid.DataSource = dtInduk

    End Sub
    Private Sub LoadGrid(NPP_ As String)

        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dt = fc_Class.Get_Detail_NPP(NPP_)
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BSetGroup_Click(sender As Object, e As EventArgs) Handles BSetGroup.Click

        If TGroupID.EditValue = "" Then
            MessageBox.Show("Please Fill Group ID",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else

            Dim Cek As Boolean
            Dim PN As String = ""
            For a As Integer = 0 To GridView1.RowCount - 1
                Cek = Convert.ToBoolean(GridView1.GetRowCellValue(a, "Check"))
                If Cek = True Then
                    PN = GridView1.GetRowCellValue(a, "Part No")

                    For i As Integer = 0 To dtInduk.Rows.Count - 1
                        If dtInduk.Rows(i).Item("Part No") = PN Then
                            With dtInduk.Rows(i)
                                .Item("Group ID") = "G" & TGroupID.EditValue.Trim
                            End With
                        End If
                    Next


                    For i As Integer = 0 To dtInduk.Rows.Count - 1
                        If dtInduk.Rows(i).Item("Part No") = PN Then
                            With dtInduk.Rows(i)
                                .Item("Group ID") = "G" & TGroupID.EditValue.Trim
                            End With
                        End If
                    Next

                End If
            Next

            Me.Close()
        End If
    End Sub

    Private Sub TGroupID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TGroupID.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 44)) Then
            e.Handled = True
        End If

    End Sub
End Class