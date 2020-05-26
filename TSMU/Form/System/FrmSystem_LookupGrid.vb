Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base.ViewInfo

Public Class FrmSystem_LookupGrid
    Enum ReturnType As Byte
        Kode = 0
        Nama = 1
    End Enum

    Dim CustomQuery As String = ""    '# Query yang ditentukan sendiri...
    Dim SelectedValue As String = ""
    Dim SelectedDesc As String = ""
    Dim SelectedRow As DataRowView = Nothing
    Dim GridData As DataTable = Nothing
    Dim _HiddenCols() As Integer

    Property HiddenCols() As Integer
        Get
            Return _HiddenCols.Length
        End Get
        Set(ByVal value As Integer)
            If _HiddenCols Is Nothing Then
                ReDim Preserve _HiddenCols(0)
            Else
                ReDim Preserve _HiddenCols(_HiddenCols.Length)
            End If
            _HiddenCols(_HiddenCols.Length - 1) = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal Query As String)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        CustomQuery = Query
    End Sub

    Public Sub New(ByVal dt As DataTable)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
    End Sub

    ReadOnly Property Result(Optional ByVal Item As ReturnType = ReturnType.Kode) As String
        Get
            If Item = ReturnType.Kode Then
                Return SelectedValue
            Else
                Return SelectedDesc
            End If
        End Get
    End Property

    ReadOnly Property Values() As DataRowView
        Get
            Return SelectedRow
        End Get
    End Property
    Private Sub FrmSystem_LookupGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim query As String = ""

            If CustomQuery.Trim <> "" Then
                '# Query ditentukan sendiri :
                query = CustomQuery.Trim
            End If

            If GridData IsNot Nothing Then
                Grid.DataSource = GridData
                GridView1.BestFitColumns()
            Else
                Dim dt As DataTable = MainModul.GetDataTable(query)
                Grid.DataSource = dt
                GridData = Grid.DataSource
                GridView1.BestFitColumns()
            End If

            If _HiddenCols IsNot Nothing AndAlso _HiddenCols.Length > 0 Then
                For i As Integer = 0 To _HiddenCols.Length - 1
                    If _HiddenCols(i) > -1 AndAlso _HiddenCols(i) <= GridView1.Columns.Count - 1 Then
                        GridView1.Columns(_HiddenCols(i)).Visible = False
                    End If
                Next
            End If
            GridView1.ClearSelection()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SelectValue()
        Dim selRows As Integer() = DirectCast(Grid.MainView, GridView).GetSelectedRows()
        Dim selRow As DataRowView = DirectCast(DirectCast(Grid.MainView, GridView).GetRow(selRows(0)), DataRowView)
        With GridView1
            If selRows IsNot Nothing Then
                'If .CurrentRow.Index >= 0 Then
                Me.SelectedValue = selRow(0)
                Me.SelectedDesc = selRow(1)
                Me.SelectedRow = selRow
                'Me.Close()
            End If
            Me.Close()
        End With
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter AndAlso GridView1.GetSelectedRows IsNot Nothing Then
            BtnOk.PerformClick()
        ElseIf e.KeyCode = Keys.Up AndAlso GridView1.GetSelectedRows IsNot Nothing AndAlso GridView1.FocusedRowHandle = 0 Then
            Call SelectNextControl(Grid, False, True, False, False)
        End If
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Call SelectValue()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = Grid.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Call SelectValue()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class