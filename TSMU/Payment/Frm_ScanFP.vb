Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_ScanFP
    ''Public da As MySqlDataAdapter
    Dim fpb As Cls_barcode = New Cls_barcode()
    Public dt As DataTable
    Dim ling As String
    Dim NoFaktur As String
    Dim IsNew As Boolean
    Dim ObjBarcode As New barcode_models
    'Private Property cmd As MySqlCommand
    Public Sub New(ByVal _NoFaktur As String, _IsNew As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        NoFaktur = _NoFaktur
        IsNew = _IsNew
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
    End Sub
    Private Sub bersih()
        txtbarcode.Text = ""
        _alamatPenjual.Text = ""
        _kdJenisTransaksi.Text = ""
        _fgPengganti.Text = ""
        _nomorFaktur.Text = ""
        _masapajak.Text = ""
        _tahunpajak.Text = ""
        _tanggalFaktur.Text = ""
        _npwpPenjual.Text = ""
        _namaPenjual.Text = ""
        _jumlahDpp.Text = ""
        _jumlahPpn.Text = ""
        _jumlahPpnBm.Text = ""
        Me.txtfm.Focus()
    End Sub
    Private Sub Frm_ScanFP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNew Then
            bersih()
            Button2.Enabled = True
        Else
            Dim dt As New DataTable
            dt = ObjBarcode.GetBarcodeByNoFaktur(NoFaktur)
            If dt.Rows.Count > 0 Then
                _kdJenisTransaksi.Text = Trim(dt.Rows(0).Item("kdJenisTransaksi"))
                _fgPengganti.Text = Trim(dt.Rows(0).Item("fgPengganti"))
                _nomorFaktur.Text = Trim(dt.Rows(0).Item("nomorFaktur"))
                _tanggalFaktur.Text = Trim(dt.Rows(0).Item("tanggalFaktur"))
                _npwpPenjual.Text = Trim(dt.Rows(0).Item("npwpPenjual"))
                _namaPenjual.Text = Trim(dt.Rows(0).Item("namaPenjual"))
                _alamatPenjual.Text = Trim(dt.Rows(0).Item("alamatPenjual"))
                _jumlahDpp.Text = Trim(dt.Rows(0).Item("jumlahDpp"))
                _jumlahPpn.Text = Trim(dt.Rows(0).Item("jumlahPpn"))
                _jumlahPpnBm.Text = Trim(dt.Rows(0).Item("jumlahPpnBm"))
                _txtbarcode.Text = Trim(dt.Rows(0).Item("ling"))
                _masapajak.Text = Trim(dt.Rows(0).Item("masapajak"))
                _tahunpajak.Text = Trim(dt.Rows(0).Item("tahunpajak"))

            End If
            Button2.Enabled = False
        End If

    End Sub

    Private Sub txtbarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarcode.KeyPress
        'If (e.KeyChar = Chr(13)) Then
        '    Call tampilbarcode()
        'End If
    End Sub

    Private Sub txtbarcode_LostFocus(sender As Object, e As EventArgs) Handles txtbarcode.LostFocus

        'If Not IsNew Then
        '    Exit Sub
        'End If
        'ling = txtbarcode.Text
        'If ling = "" Then
        'Else
        '    Dim xr As XmlReader = XmlReader.Create(ling)
        '    Do While xr.Read()
        '        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "kdJenisTransaksi" Then
        '            _kdJenisTransaksi.Text = xr.ReadElementString
        '            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "fgPengganti" Then
        '                _fgPengganti.Text = xr.ReadElementString
        '                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "nomorFaktur" Then
        '                    _nomorFaktur.Text = xr.ReadElementString
        '                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "tanggalFaktur" Then
        '                        _tanggalFaktur.Text = xr.ReadElementString
        '                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpPenjual" Then
        '                            _npwpPenjual.Text = xr.ReadElementString
        '                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaPenjual" Then
        '                                _namaPenjual.Text = xr.ReadElementString
        '                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatPenjual" Then
        '                                    _alamatPenjual.Text = xr.ReadElementString
        '                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpLawanTransaksi" Then
        '                                        _jumlahDpp.Text = xr.ReadElementString
        '                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaLawanTransaksi" Then
        '                                            _jumlahDpp.Text = xr.ReadElementString
        '                                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatLawanTransaksi" Then
        '                                                _jumlahDpp.Text = xr.ReadElementString
        '                                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahDpp" Then
        '                                                    _jumlahDpp.Text = xr.ReadElementString
        '                                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpn" Then
        '                                                        _jumlahPpn.Text = xr.ReadElementString
        '                                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpnBm" Then
        '                                                            _jumlahPpnBm.Text = xr.ReadElementString
        '                                                        Else
        '                                                            xr.Read()
        '                                                        End If
        '                                                    End If
        '                                                End If
        '                                            End If
        '                                        End If
        '                                    End If
        '                                End If
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Loop
        '    ''TextBox5.Text = Month(TextBox7.Text)
        '    _masapajak.Text = Mid(_tanggalFaktur.Text, 4, 2)
        '    _tahunpajak.Text = Mid(_tanggalFaktur.Text, 7, 4)
        'End If
        'Label33.Visible = True
        'Label32.Visible = True
        'Label34.Visible = True
        'Label35.Visible = True
        'Label36.Visible = True
        'Label37.Visible = True
        'Label40.Visible = True
        'If _npwpPenjual.Text = "" Then 'Frm_fp._npwp.Text Then
        '    Label33.Text = "√"
        '    Label33.ForeColor = Color.Green
        'Else
        '    Label33.Text = "X"
        '    Label33.ForeColor = Color.Red
        'End If
        'If _namaPenjual.Text = "" Then ' Frm_fp._nama_vendor.Text Then
        '    Label35.Text = "√"
        '    Label35.ForeColor = Color.Green
        'Else
        '    Label35.Text = "X"
        '    Label35.ForeColor = Color.Red
        'End If
        'If _jumlahDpp.Text = "" Then 'Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value() Then
        '    Label36.Text = "√"
        '    Label36.ForeColor = Color.Green
        'Else
        '    Label36.Text = "X"
        '    Label36.ForeColor = Color.Red
        'End If

        'If _nomorFaktur.Text = "" Then ' Mid(Replace(Replace(Frm_fp.DataGridView1.SelectedRows(0).Cells(7).Value(), ".", ""), "-", ""), 4, 13) Then
        '    Label34.Text = "√"
        '    Label34.ForeColor = Color.Green
        'Else
        '    Label34.Text = "X"
        '    Label34.ForeColor = Color.Red
        'End If

        'If _jumlahPpn.Text = "" Then ' Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value() Then
        '    Label37.Text = "√"
        '    Label37.ForeColor = Color.Green
        'Else
        '    Label37.Text = "X"
        '    Label37.ForeColor = Color.Red
        'End If

        '_dpp_ppn.Text = Val(_jumlahDpp.Text) + Val(_jumlahPpn.Text)
        'Label1.Text = "" ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value())
        'If _dpp_ppn.Text = "" Then ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value()) Then
        '    Label40.Text = "√"
        '    Label40.ForeColor = Color.Green
        'Else
        '    Label40.Text = "X"
        '    Label40.ForeColor = Color.Red
        'End If
        'If Label33.Text = "√" And Label34.Text = "√" And Label35.Text = "√" And Label36.Text = "√" And Label37.Text = "√" And Label40.Text = "√" Then
        '    Label32.Text = "Valid"
        '    Label32.ForeColor = Color.Green
        'Else
        '    Label32.Text = "Not Valid"
        '    Label32.ForeColor = Color.Red
        'End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        usergetobject()
        fpb.insertdata_barcodefp()
        MsgBox("Data tersimpan")
        Me.Close()
    End Sub

    Sub usergetobject()
        fpb.kdJenisTransaksi = _kdJenisTransaksi.Text
        fpb.fgPengganti = _fgPengganti.Text
        fpb.nomorFaktur = _nomorFaktur.Text
        fpb.tanggalFaktur = _tanggalFaktur.Text
        fpb.npwpPenjual = _npwpPenjual.Text
        fpb.namaPenjual = _namaPenjual.Text
        fpb.alamatPenjual = _alamatPenjual.Text
        fpb.jumlahDpp = _jumlahDpp.Text
        fpb.jumlahPpn = _jumlahPpn.Text
        fpb.jumlahPpnBm = _jumlahPpnBm.Text
        fpb.ling = _txtbarcode.Text
        fpb.masapajak = _masapajak.Text
        fpb.tahunpajak = _tahunpajak.Text
    End Sub

    Private Sub _jumlahDpp_TextChanged(sender As Object, e As EventArgs) Handles _jumlahDpp.TextChanged

    End Sub

    Private Sub txtbarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Not IsNew Then
                    Exit Sub
                End If
                ling = txtbarcode.Text
                If ling = "" Then
                Else
                    Dim xr As XmlReader = XmlReader.Create(ling)
                    Do While xr.Read()
                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "kdJenisTransaksi" Then
                            _kdJenisTransaksi.Text = xr.ReadElementString
                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "fgPengganti" Then
                                _fgPengganti.Text = xr.ReadElementString
                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "nomorFaktur" Then
                                    _nomorFaktur.Text = xr.ReadElementString
                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "tanggalFaktur" Then
                                        _tanggalFaktur.Text = xr.ReadElementString
                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpPenjual" Then
                                            _npwpPenjual.Text = xr.ReadElementString
                                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaPenjual" Then
                                                _namaPenjual.Text = xr.ReadElementString
                                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatPenjual" Then
                                                    _alamatPenjual.Text = xr.ReadElementString
                                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpLawanTransaksi" Then
                                                        _jumlahDpp.Text = xr.ReadElementString
                                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaLawanTransaksi" Then
                                                            _jumlahDpp.Text = xr.ReadElementString
                                                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatLawanTransaksi" Then
                                                                _jumlahDpp.Text = xr.ReadElementString
                                                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahDpp" Then
                                                                    _jumlahDpp.Text = xr.ReadElementString
                                                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpn" Then
                                                                        _jumlahPpn.Text = xr.ReadElementString
                                                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpnBm" Then
                                                                            _jumlahPpnBm.Text = xr.ReadElementString
                                                                        Else
                                                                            xr.Read()
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Loop
                    ''TextBox5.Text = Month(TextBox7.Text)
                    _masapajak.Text = Mid(_tanggalFaktur.Text, 4, 2)
                    _tahunpajak.Text = Mid(_tanggalFaktur.Text, 7, 4)
                End If
                Label33.Visible = True
                Label32.Visible = True
                Label34.Visible = True
                Label35.Visible = True
                Label36.Visible = True
                Label37.Visible = True
                Label40.Visible = True
                If _npwpPenjual.Text = "" Then 'Frm_fp._npwp.Text Then
                    Label33.Text = "√"
                    Label33.ForeColor = Color.Green
                Else
                    Label33.Text = "√"
                    Label33.ForeColor = Color.Green
                End If
                If _namaPenjual.Text = "" Then ' Frm_fp._nama_vendor.Text Then
                    Label35.Text = "√"
                    Label35.ForeColor = Color.Green
                Else
                    Label35.Text = "√"
                    Label35.ForeColor = Color.Green
                End If
                If _jumlahDpp.Text = "" Then 'Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value() Then
                    Label36.Text = "√"
                    Label36.ForeColor = Color.Green
                Else
                    Label36.Text = "√"
                    Label36.ForeColor = Color.Green
                End If

                If _nomorFaktur.Text = "" Then ' Mid(Replace(Replace(Frm_fp.DataGridView1.SelectedRows(0).Cells(7).Value(), ".", ""), "-", ""), 4, 13) Then
                    Label34.Text = "√"
                    Label34.ForeColor = Color.Green
                Else
                    Label34.Text = "√"
                    Label34.ForeColor = Color.Green
                End If

                If _jumlahPpn.Text = "" Then ' Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value() Then
                    Label37.Text = "√"
                    Label37.ForeColor = Color.Green
                Else
                    Label37.Text = "√"
                    Label37.ForeColor = Color.Green
                End If

                _dpp_ppn.Text = Val(_jumlahDpp.Text) + Val(_jumlahPpn.Text)
                Label1.Text = "" ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value())
                If _dpp_ppn.Text = "" Then ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value()) Then
                    Label40.Text = "√"
                    Label40.ForeColor = Color.Green
                Else
                    Label40.Text = "√"
                    Label40.ForeColor = Color.Green
                End If
                If Label33.Text = "√" And Label34.Text = "√" And Label35.Text = "√" And Label36.Text = "√" And Label37.Text = "√" And Label40.Text = "√" Then
                    Label32.Text = "Valid"
                    Label32.ForeColor = Color.Green
                Else
                    Label32.Text = "Valid"
                    Label32.ForeColor = Color.Green
                End If
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class