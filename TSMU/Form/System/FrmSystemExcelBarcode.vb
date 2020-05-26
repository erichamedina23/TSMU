Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class FrmSystemExcelBarcode
    Dim fc_class As New clsSales_Budget
    Dim GridData As DataTable = Nothing
    Dim Gridfilter As DataTable = Nothing
    Dim a As Integer = 0
    Dim b As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByRef dt As DataTable, ByVal x As Integer)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
        a = x
    End Sub
    Private Sub FrmSystemExcelBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.Text = ""
    End Sub

    'Private Sub FillComboCustomer()
    '    Dim dtTabel As New DataTable
    '    dtTabel = fc_class.getCusstID_Solomon
    '    Dim dr As DataRow = dtTabel.NewRow
    '    dr("CustId") = ""
    '    dtTabel.Rows.InsertAt(dr, 0)
    '    _cmbTahun.Items.Clear()
    '    For i As Integer = 0 To dtTabel.Rows.Count - 1
    '        _cmbTahun.Items.Add(dtTabel.Rows(i)("CustId"))
    '    Next
    'End Sub
    Dim path As String
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub _txtExcel_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles _txtExcel.ButtonClick
        Try
            OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            ' Test result.
            If result = System.Windows.Forms.DialogResult.OK Then
                path = OpenFileDialog1.FileName
                'path = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                'MsgBox(path)
                Dim text As String = System.IO.File.ReadAllText(path)
                _txtExcel.Text = path
                'Me.Text = text.Length.ToString
            End If
        Catch ex As Exception When Not TypeOf ex Is MissingMethodException
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub _BtnExport1_Click(sender As Object, e As EventArgs) Handles _BtnExport1.Click
        Try
            If lblStatus.Text <> "" Then
                Throw New Exception("Proses masih berjalan !")
            End If
            If _txtExcel.Text = "" Then
                _txtExcel.Focus()
                Throw New Exception("File Excel yang akan di upload tidak ada !")
            End If
            Dim connString As String = String.Empty
            Dim extension As String = System.IO.Path.GetExtension(path)
            Select Case extension
                Case ".xls"
                    'Excel 97-03

                    connString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 or higher
                    connString = ConfigurationManager.ConnectionStrings("Excel07+ConString").ConnectionString
                    Exit Select

            End Select
            connString = String.Format(connString, path)
            Using excel_con As New OleDbConnection(connString)
                excel_con.Open()
                Dim sheet1 As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & sheet1) + "]", excel_con)
                    oda.Fill(GridData)
                End Using
                excel_con.Close()
            End Using
            Me.Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class