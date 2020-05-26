Imports DevExpress.XtraEditors

Public Class FrmTam_Scan
    Dim tam As TamScan
    Dim tran As Tam_Trans
    Private Sub FrmTam_Scan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False)
        ClearText()
    End Sub

    Private Sub ClearText()
        TxtBarcode.Text = ""
        TxtOriDelDate.Text = ""
        TxtDelDate.Text = ""
        TxtShipDate.Text = ""
        TxtCaseNo.Text = ""
        TxtCasePallMark.Text = ""
        TxtPoNo.Text = ""
        TxtPoDate.Text = ""
        TxtItemNo.Text = ""
        TxtFranchise.Text = ""
        TxtPartNo.Text = ""
        TxtActDelQty.Text = ""
        TxtPoDelQty.Text = ""
        TxtVendor.Text = ""
        TxtDelInstDate.Text = ""
        _TxtBarcode.Focus()
    End Sub

    Private Sub TxtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If TxtBarcode.Text <> "" Then
                    tam = New TamScan
                    Dim dt As New DataTable
                    dt = tam.GetKanban(TxtBarcode.Text.Trim)
                    If dt.Rows.Count > 0 Then
                        TxtOriDelDate.Text = dt.Rows(0)("DeliveryDate").ToString()
                        TxtDelDate.Text = DateTime.Today.ToString("yyyyMMdd")
                        TxtShipDate.Text = DateTime.Today.ToString("yyyyMMdd")
                        TxtCaseNo.Text = ""
                        TxtCasePallMark.Text = dt.Rows(0)("PalletizeMark").ToString()
                        TxtPoNo.Text = dt.Rows(0)("PONo").ToString()
                        TxtPoDate.Text = dt.Rows(0)("PODate").ToString()
                        TxtItemNo.Text = dt.Rows(0)("ItemNo").ToString()
                        TxtFranchise.Text = "A"
                        TxtPartNo.Text = dt.Rows(0)("PartNo").ToString()
                        TxtPoDelQty.Text = dt.Rows(0)("QtyOrder").ToString()
                        TxtActDelQty.Text = ""
                        TxtVendor.Text = dt.Rows(0)("VEndor").ToString()
                        TxtDelInstDate.Text = dt.Rows(0)("DeliveryDate").ToString()
                        SendKeys.Send("{TAB}")
                    End If
                Else
                    Throw New Exception("Scan Barcode terlebih dahulu !")
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtCaseNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCaseNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If TxtBarcode.Text <> "" Then
                If TxtCaseNo.Text <> "" AndAlso TxtPoDelQty.Text <> "" Then
                    tran = New Tam_Trans
                    tam = New TamScan

                    With tam
                        .PONo = TxtPoNo.Text
                        .PartNo = TxtPartNo.Text
                        .DelQty = TxtActDelQty.Text
                    End With

                    With tran
                        .ORIG_DELIVERY_DATE = TxtOriDelDate.Text
                        .DELIVERY_DATE = TxtDelDate.Text
                        .SHIPMENT_DATE = TxtShipDate.Text
                        .CASE_NO = TxtCaseNo.Text.ToUpper
                        .CASE_PALLETIZE_MARK = TxtCasePallMark.Text
                        .PO_NO = TxtPoNo.Text
                        .PO_DATE = TxtPoDate.Text
                        .ITEM_NO = TxtItemNo.Text
                        .FRANCHISE = TxtFranchise.Text
                        .PART_NO = TxtPartNo.Text
                        .DELIVERY_QUANTITY = TxtActDelQty.Text
                        .VENDOR_CODE = TxtVendor.Text
                        .DELIV_INSTRUCT_DATE = TxtOriDelDate.Text
                    End With

                    If TxtActDelQty.Text <> "0" Then
                        If Val(TxtActDelQty.Text) < Val(TxtPoDelQty) Then
                            TxtActDelQty.SelectAll()
                            TxtActDelQty.Focus()
                            Throw New Exception("Delivery Qty must be less or equal then Qty Order ! ")
                        Else
                            tam.SimpanData()
                            XtraMessageBox.Show("Data berhasil di simpan !")
                            ClearText()
                        End If
                    Else
                        TxtActDelQty.SelectAll()
                        TxtActDelQty.Focus()
                        Throw New Exception("Delivery Qty tidak boleh '0' atau kosong! ")
                    End If
                Else
                    _TxtCaseNo.SelectAll()
                    _TxtCaseNo.Focus()
                    Throw New Exception("Case No dan Delivery Qty harus diisi !")
                End If
            Else

                TxtBarcode.Focus()
                Throw New Exception("Scan PO terlebih dahulu !")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
