Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen

Public Class FrmSales_ForecastPriceSync
    Dim GridData As DataTable = Nothing
    Dim ObjHeader As New forecast_price_models_header
    Dim ObjForecast As New forecast_price_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByRef dt As DataTable)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
    End Sub

    Private Sub FrmSystemExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBulan()
    End Sub

    Private Sub FillComboBulan()

        Dim items = {New With {Key .Text = "Januari", Key .Value = "01"},
                    New With {Key .Text = "Februari", Key .Value = "02"},
                    New With {Key .Text = "Maret", Key .Value = "03"},
                    New With {Key .Text = "April", Key .Value = "04"},
                    New With {Key .Text = "Mei", Key .Value = "05"},
                    New With {Key .Text = "Juni", Key .Value = "06"},
                    New With {Key .Text = "Juli", Key .Value = "07"},
                    New With {Key .Text = "Agustus", Key .Value = "08"},
                    New With {Key .Text = "September", Key .Value = "09"},
                    New With {Key .Text = "Oktober", Key .Value = "10"},
                    New With {Key .Text = "November", Key .Value = "11"},
                    New With {Key .Text = "Desember", Key .Value = "12"}
        }
        _CmbBulan.Properties.DataSource = Nothing
        _CmbBulan.Properties.DataSource = items
        _cmbBulan.Properties.DisplayMember = "Text"
        _cmbBulan.Properties.ValueMember = "Value"
    End Sub
    Dim path As String
    Dim path2 As String

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

    Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            If _CmbBulan.Text = "" Then
                _CmbBulan.Focus()
                Throw New Exception("Pilih Bulan !")
            End If
            ObjHeader.ObjForecastCollection.Clear()
            For Each row As DataRow In GridData.Rows
                Dim Tahun As String = row("Tahun")
                Dim CustID As String = row("CustId")
                Dim InvtID As String = row("InvtID")
                Dim PartNo As String = row("PartNo")
                ObjForecast = New forecast_price_models
                With ObjForecast
                    .Tahun = Tahun
                    .CustID = CustID
                    .InvtID = InvtID
                    .PartNo = PartNo
                    .created_date = Date.Today
                    .created_by = gh_Common.Username
                End With
                ObjHeader.ObjForecastCollection.Add(ObjForecast)
            Next

            With ObjHeader
                .BulanAngka = _CmbBulan.EditValue
                .Bulan = Microsoft.VisualBasic.Left(_CmbBulan.Text.Trim, 3)
                .SinkronasiHarga()
            End With
            SplashScreenManager.CloseForm()
            Close()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class