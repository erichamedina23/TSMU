Imports DevExpress.XtraEditors

Public Class frmScanDN
    Dim dtTemp As DataTable = Nothing
    Private Sub frmScanDN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        Init()
    End Sub
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("no")
        dtTemp.Columns.Add("noPol")
        dtTemp.Columns.Add("sopir")
        dtTemp.Columns.Add("noDn")
        dtTemp.Columns(0).AutoIncrement = True
        dtTemp.Columns(0).AutoIncrementSeed = 1
        dtTemp.Columns(0).AutoIncrementStep = 1
    End Sub
    Sub Init()
        txtPolisi.Text = ""
        txtSopir.Text = ""
        txtNoDn.Text = ""
        txtPolisi.Focus()
        TempTable()
        GridControl1.DataSource = dtTemp
    End Sub

    Private Sub txtNoDn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoDn.KeyDown
        Dim pesan As New CustomMsgBox
        Try
            If e.KeyCode = Keys.Enter Then
                If txtPolisi.Text = "" Then
                    MsgBox("HARAP ISI NO POLISI SEBELUM SCAN NO DN !")
                    'SendKeys.Send("{ENTER}")
                    txtPolisi.SelectAll()
                    txtPolisi.Focus()
                ElseIf txtSopir.Text = "" Then
                    MsgBox("HARAP ISI NAMA SOPIR SEBELUM SCAN NO DN !")
                    txtSopir.SelectAll()
                    txtSopir.Focus()
                ElseIf txtNoDn.Text = "" Then
                    MsgBox("HARAP SCAN NO DN TERLEBIH DAHULU !")
                    txtNoDn.SelectAll()
                    txtNoDn.Focus()
                Else
                    Dim ObjKanban As New KanbanAdmModel

                    Dim IsExist As Boolean = ObjKanban.IsDnNoExistCkr(txtNoDn.Text)
                    If IsExist Then
                        MsgBox("DATA SUDAH PERNAH DI SCAN !")
                    Else
                        ObjKanban.SaveDN(txtPolisi.Text.TrimEnd, txtNoDn.Text.TrimEnd, txtSopir.Text.TrimEnd)
                        'XtraMessageBox.Show("")

                        'MsgBox("DATA SUDAH DISIMPAN !")
                        pesan.LabelPesan = "DATA SUDAH DISIMPAN !"
                        pesan.StartPosition = FormStartPosition.CenterScreen
                        pesan.ShowDialog()

                        Dim R As DataRow = dtTemp.NewRow
                        R(1) = txtPolisi.Text
                        R(2) = txtSopir.Text
                        R(3) = txtNoDn.Text
                        dtTemp.Rows.Add(R)
                        GridControl1.DataSource = dtTemp

                        txtNoDn.Text = ""
                        txtNoDn.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Init()
    End Sub

    Private Sub txtPolisi_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPolisi.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub
End Class