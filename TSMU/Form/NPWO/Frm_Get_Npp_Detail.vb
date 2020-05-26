Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Public Class Frm_Get_Npp_Detail

    Dim fc_Class As New Cls_Npwo_Detail
    Dim fc_ClassNpp As New Cls_NPP_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Nama As String
    Dim Material As String
    Dim Weight As String
    Dim Inj As Boolean
    Dim Pnt As Boolean
    Dim Chrome As Boolean
    Dim Assy As Boolean
    Dim Ultrasonic As Boolean
    Dim StatusMold As String
    Dim OrderMonth As String
    Dim Grid1 As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean

    Dim GridBayangan As GridControl
    Dim dtDetail As DataTable

    Dim DtTabale As DataTable
    Dim dt As DataTable
    Dim dtNpwoDetail As DataTable

    Public Sub New(ByVal _ID As String,
                   ByVal _Nama As String,
                   ByVal _Material As String,
                   ByVal _Weight As String,
                   ByVal _Inj As Boolean,
                   ByVal _Paint As Boolean,
                   ByVal _Chrome As Boolean,
                   ByVal _Assy As Boolean,
                   ByVal _Ultrasonic As Boolean,
                   ByVal _StatusMold As String,
                   ByVal _OrderMonth As String,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As GridControl,
                   ByRef _dtDetail As DataTable,
                   ByRef _grid1 As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ID = _ID
        Nama = _Nama
        Material = _Material
        Weight = _Weight
        Inj = _Inj
        Pnt = _Paint
        Chrome = _Chrome
        Assy = _Assy
        Ultrasonic = _Ultrasonic
        StatusMold = _StatusMold
        OrderMonth = _OrderMonth
        IsNew = _IsNew
        Grid1 = _grid
        DtTabale = _dt

        GridBayangan = _grid1

        dtDetail = _dtDetail


    End Sub

    Private Sub Frm_Get_Npp_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'RBSingle.Checked = True

        CreateTableBarang()

        If ID <> "" Then
            Call LoadGrid(ID)
        End If

    End Sub

    Private Sub LoadGrid(NPP_ As String)

        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dt = fc_ClassNpp.Get_Detail_NPP(NPP_)

            Dim PartNoNPWO As String = ""
            Dim PartNoNPP As String = ""

            For i As Integer = 0 To dt.Rows.Count - 1

                PartNoNPP = dt.Rows(i).Item("Part No")

                For j As Integer = 0 To dtDetail.Rows.Count - 1
                    PartNoNPWO = dtDetail.Rows(j).Item("Part No")
                    If PartNoNPP = PartNoNPWO Then
                        dt.Rows(i).Item("Check") = "True"
                    End If

                Next
            Next

            Grid.DataSource = dt
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub CreateTableBarang()

        dt = New DataTable


        dt.Columns.AddRange(New DataColumn(18) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("Check", GetType(Boolean)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("Cav", GetType(String)),
                                                           New DataColumn("C/T", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Mold No", GetType(String)),
                                                           New DataColumn("Npp No", GetType(String)),
                                                           New DataColumn("Group ID", GetType(String)),
                                                           New DataColumn("Order Month", GetType(Int32))})
        Grid.DataSource = dt
        GridView1.OptionsView.ShowAutoFilterRow = True

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

        Dim MyNewRow As DataRow
        Dim MyNewRowDetail As DataRow

        If IsNew = True Then

            Dim ID As String = ""
            Dim Inj As Boolean = False
            Dim paint As Boolean = False
            Dim chrome As Boolean = False
            Dim assy As Boolean = False
            Dim ultra As Boolean = False
            Dim vibra As Boolean = False

            Dim CT As Integer = 0
            Dim Weight As Double = 0


            MyNewRow = DtTabale.NewRow
            MyNewRowDetail = dtDetail.NewRow

            Dim count As Integer = 0

            Dim CekPartNo As String = ""
            Dim Group As String = ""
            Dim chkSelect As Boolean
            Dim Group2 As String = ""
            Dim chkSelect2 As Boolean

            For i As Integer = 0 To GridView1.RowCount - 1
                chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Check")))
                Group = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns("Group ID")))
                CekPartNo = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns("Part No")))

                If chkSelect = True Then

                    If DtTabale.Rows.Count <= 0 Then
                        MyNewRow = DtTabale.NewRow

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    With MyNewRow
                                        .Item("Group ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                        .Item("Type") = "MOLD"
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                        Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                        paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                        chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                        assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))

                                        ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))

                                        .Item("Inj") = Inj
                                        .Item("Painting") = paint
                                        .Item("Chrome") = chrome
                                        .Item("Assy") = assy
                                        .Item("Qty Mold") = "0"
                                        .Item("Ultrasonic") = ultra
                                        .Item("Vibration") = vibra
                                        .Item("Type") = "MOLD"

                                        CT = CT + GridView1.GetRowCellValue(j, GridView1.Columns("C/T"))
                                        Weight = Weight + GridView1.GetRowCellValue(j, GridView1.Columns("Weight"))
                                        .Item("Machine") = GridView1.GetRowCellValue(j, GridView1.Columns("Machine"))
                                        .Item("Cav") = GridView1.GetRowCellValue(j, GridView1.Columns("Cav"))
                                        .Item("C/T") = CT
                                        .Item("Weight") = Weight

                                        .Item("Status Mold") = GridView1.GetRowCellValue(j, GridView1.Columns("Status Mold"))


                                    End With


                                End If
                            End If
                        Next
                        DtTabale.Rows.Add(MyNewRow)
                        DtTabale.AcceptChanges()
                        ID = MyNewRow.Item("Part No")

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then


                                    MyNewRowDetail = dtDetail.NewRow
                                    With MyNewRowDetail
                                        .Item("Group ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                        .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                        .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                        .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                        .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                        .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("C/T") = GridView1.GetRowCellValue(j, GridView1.Columns("C/T"))
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight"))
                                        .Item("Machine") = GridView1.GetRowCellValue(j, GridView1.Columns("Machine"))
                                        .Item("Cav") = GridView1.GetRowCellValue(j, GridView1.Columns("Cav"))
                                        .Item("Qty Mold") = "0"
                                        .Item("Type") = "PROCESS"
                                        .Item("Type1") = "MOLD"

                                        .Item("Status Mold") = GridView1.GetRowCellValue(j, GridView1.Columns("Status Mold"))

                                    End With
                                    dtDetail.Rows.Add(MyNewRowDetail)
                                    dtDetail.AcceptChanges()
                                End If
                            End If
                        Next




                    Else
                        Dim CekPartNo2 As String = ""
                        For k As Integer = 0 To dtDetail.Rows.Count - 1
                            CekPartNo2 = dtDetail.Rows(k).Item("Part No")
                            If CekPartNo = CekPartNo2 Then
                                GoTo Lanjut
                            End If
                        Next

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    MyNewRow = DtTabale.NewRow
                                    With MyNewRow
                                        .Item("Group ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                        Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                        paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                        chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                        assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))
                                        ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("Inj") = Inj
                                        .Item("Painting") = paint
                                        .Item("Chrome") = chrome
                                        .Item("Assy") = assy
                                        .Item("Qty Mold") = "0"
                                        .Item("Ultrasonic") = ultra
                                        .Item("Vibration") = vibra
                                        .Item("Type") = "MOLD"

                                        CT = CT + GridView1.GetRowCellValue(j, GridView1.Columns("C/T"))
                                        Weight = Weight + GridView1.GetRowCellValue(j, GridView1.Columns("Weight"))
                                        .Item("Machine") = GridView1.GetRowCellValue(j, GridView1.Columns("Machine"))
                                        .Item("Cav") = GridView1.GetRowCellValue(j, GridView1.Columns("Cav"))
                                        .Item("C/T") = CT
                                        .Item("Weight") = Weight

                                        .Item("Status Mold") = GridView1.GetRowCellValue(j, GridView1.Columns("Status Mold"))

                                    End With

                                End If
                            End If
                        Next
                        DtTabale.Rows.Add(MyNewRow)
                        DtTabale.AcceptChanges()
                        ID = MyNewRow.Item("Part No")

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then


                                    MyNewRowDetail = dtDetail.NewRow
                                    With MyNewRowDetail
                                        .Item("Group ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                        .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                        .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                        .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                        .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                        .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("C/T") = GridView1.GetRowCellValue(j, GridView1.Columns("C/T"))
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight"))
                                        .Item("Machine") = GridView1.GetRowCellValue(j, GridView1.Columns("Machine"))
                                        .Item("Cav") = GridView1.GetRowCellValue(j, GridView1.Columns("Cav"))
                                        .Item("Qty Mold") = "0"
                                        .Item("Type") = "PROCESS"
                                        .Item("Type1") = "MOLD"

                                        .Item("Status Mold") = GridView1.GetRowCellValue(j, GridView1.Columns("Status Mold"))

                                    End With
                                    dtDetail.Rows.Add(MyNewRowDetail)
                                    dtDetail.AcceptChanges()

                                End If
                            End If
                        Next

                    End If
                End If
Lanjut:
            Next
        Else
        End If

        Me.Close()

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged

        'Dim PartNo As String = ""
        'PartNo = GridView1.GetRowCellValue(0, GridView1.Columns("Part No")).ToString

        Try
            Dim Cek As Boolean
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim GroupSelect As String = ""
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    GroupSelect = GridView1.GetRowCellValue(rowHandle, "Group ID")
                    Cek = Convert.ToBoolean(GridView1.GetRowCellValue(rowHandle, "Check"))
                End If
            Next rowHandle

            Dim T As Boolean = True
            Dim F As Boolean = False

            If Cek = False Then
                For I As Integer = 0 To GridView1.RowCount - 1
                    Dim GroupCek As String = GridView1.GetRowCellValue(I, GridView1.Columns("Group ID")).ToString
                    If GroupCek = GroupSelect Then
                        GridView1.SetRowCellValue(I, "Check", T)
                    End If
                Next
            Else
                For I As Integer = 0 To GridView1.RowCount - 1
                    Dim GroupCek As String = GridView1.GetRowCellValue(I, GridView1.Columns("Group ID")).ToString
                    If GroupCek = GroupSelect Then
                        GridView1.SetRowCellValue(I, "Check", F)
                    End If
                Next
            End If


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
End Class