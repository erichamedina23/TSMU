Public Class frmBoMLookUpLevel
    Dim fc_Class As New clsBoM
    Dim InvtId As String = String.Empty
    Dim dtGrid As DataTable
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strInvtId As String)
        Me.New()
        InvtId = strInvtId
    End Sub

    Private Sub frmBoMLookUpLevel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If Grid.SelectedRows.Count > 0 Then
                If e.KeyCode = Keys.F3 Then
                    'Dim objGrid As DataGridView = sender
                    CallFrmLookUp(Grid.SelectedRows(0).Cells(0).Value.ToString)
                    'Dim f As frmBoMLookUpLevel = New frmBoMLookUpLevel()
                    'f.StartPosition = FormStartPosition.CenterScreen
                    'f.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub frmBoMLookUpLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AturGrid(Grid, Me)
        LoadDataGrid()
    End Sub
    Public Sub LoadDataGrid()
        Try
            Dim dt As New DataTable
            'dt = fc_Class.getDetailBoM_Part_n(InvtId)
            dt = fc_Class.getRoutingBoM(InvtId)
            Dim str As String = String.Empty
            Dim dtGrid1 As New DataTable
            dtGrid1.Columns.AddRange(New DataColumn(3) {New DataColumn("Inventory ID", GetType(String)), _
                                                            New DataColumn("Description", GetType(String)), _
                                                            New DataColumn("Unit", GetType(String)), _
                                                            New DataColumn("Qty", GetType(String))})
            For rw = 0 To dt.Rows.Count - 1
                Dim parent As String = dt.Rows(rw)("parentid").ToString
                If parent <> "" Then
                    If parent = InvtId Then
                        str = "level 1 - " & dt.Rows(rw)("invtid").ToString
                        dtGrid1.Rows.Add()
                        dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(0) = dt.Rows(rw)("invtid")
                        dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(1) = dt.Rows(rw)("descr")
                        dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(2) = dt.Rows(rw)("unit")
                        dtGrid1.Rows(dtGrid1.Rows.Count - 1).Item(3) = dt.Rows(rw)("qty")
                    End If
                End If
            Next
            Grid.DataSource = dtGrid1
        Catch ex As Exception
            Throw
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        Try

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub CallFrmLookUp(Optional ByVal InvtId As String = "")
        Dim f As frmBoMLookUpLevel = New frmBoMLookUpLevel()
        f = New frmBoMLookUpLevel(InvtId)
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
End Class