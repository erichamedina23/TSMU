Imports System.Collections.ObjectModel
Public Class clsInventory
    Dim _Query As String
    Private _unit As String
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(ByVal value As String)
            _unit = value
        End Set
    End Property
    Private _tgl As Date
    Public Property Tgl() As Date
        Get
            Return _tgl
        End Get
        Set(ByVal value As Date)
            _tgl = value
        End Set
    End Property

    Private _invtid As String
    Public Property InvtID() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property

    Private _desc As String
    Public Property Desc() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _catalog As String
    Public Property Catalog() As String
        Get
            Return _catalog
        End Get
        Set(ByVal value As String)
            _catalog = value
        End Set
    End Property

    Private _packing As Integer
    Public Property Packing() As Integer
        Get
            Return _packing
        End Get
        Set(ByVal value As Integer)
            _packing = value
        End Set
    End Property

    Private _minstok As Integer
    Public Property MinStok() As Integer
        Get
            Return _minstok
        End Get
        Set(ByVal value As Integer)
            _minstok = value
        End Set
    End Property
    Private _kdgroup As String
    Public Property Group() As String
        Get
            Return _kdgroup
        End Get
        Set(ByVal value As String)
            _kdgroup = value
        End Set
    End Property

    Private _polt As Integer
    Public Property Polt() As Integer
        Get
            Return _polt
        End Get
        Set(ByVal value As Integer)
            _polt = value
        End Set
    End Property

    Private _mfglt As Integer
    Public Property Mfglt() As Integer
        Get
            Return _mfglt
        End Get
        Set(ByVal value As Integer)
            _mfglt = value
        End Set
    End Property

    Private _remark As String
    Public Property Remark() As String
        Get
            Return _remark
        End Get
        Set(ByVal value As String)
            _remark = value
        End Set
    End Property

    Private _carmodel As String
    Public Property CarModel() As String
        Get
            Return _carmodel
        End Get
        Set(ByVal value As String)
            _carmodel = value
        End Set
    End Property


    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _price As Single
    Public Property Price() As Single
        Get
            Return _price
        End Get
        Set(ByVal value As Single)
            _price = value
        End Set
    End Property


    Public Sub New()
        Me._Query = "SELECT invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok] " & vbCrLf & _
                    "	, case kdgrup " & vbCrLf & _
                    "	        when 'FG' then 'Finish Good' " & vbCrLf & _
                    "	        else 'PURCHASE' end as [Group] " & vbCrLf & _
                    "FROM " & vbCrLf & _
                    "   inventory_lc " & vbCrLf & _
                    "ORDER by Invtid"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select bomid as [BoM ID],invtid as [Inventory ID], descr as Description, siteid as Site " & _
                "from bomh order by bomid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select InvtID,Descr,StkUnit,TranStatusCode,catalog,packing,min_stok,kdgrup,polt,mfglt,remark, car_model, price from Inventory_lc where invtid = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._desc = Trim(.Item("descr") & "")
                    Me._unit = Trim(.Item("StkUnit") & "")
                    Me._status = Trim(.Item("TranStatusCode") & "")
                    Me._catalog = Trim(.Item("catalog") & "")
                    Me._packing = Trim(.Item("packing") & "")
                    Me._minstok = Trim(.Item("min_stok") & "")
                    Me._kdgroup = Trim(.Item("kdgrup") & "")
                    Me._polt = Trim(.Item("polt") & "")
                    Me._mfglt = Trim(.Item("mfglt") & "")
                    Me._remark = Trim(.Item("remark") & "")
                    Me._carmodel = Trim(.Item("car_model") & "")
                    Me._price = Trim(.Item("price") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByInvt(ByVal ID As String)
        Try
            Dim query As String = "select * from bomh where invtID = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._unit = Trim(.Item("bomid") & "")
                    Me._tgl = Trim(.Item("tgl") & "")
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._desc = Trim(.Item("descr") & "")
                    Me._catalog = Trim(.Item("siteid") & "")
                    Me._packing = Trim(.Item("runner") & "")
                    Me._minstok = Trim(.Item("ct") & "")
                    Me._kdgroup = Trim(.Item("mc") & "")
                End With
            Else
                _unit = ""
                _tgl = ""
                _invtid = ""
                _desc = ""
                _catalog = ""
                _packing = ""
                _minstok = ""
                _kdgroup = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me._invtid = "" OrElse Me._desc = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 invtId from Inventory_lc where invtId = " & QVal(Me._invtid) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) & _
                "[" & Me._invtid & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = "Insert into inventory_lc(InvtID,Descr,StkUnit,TranStatusCode,catalog,packing,min_stok,kdgrup,polt,mfglt,remark, car_model, price, createdby, created_date) " & _
                                "values(" & QVal(Me._invtid) & ", " & _
                                "" & QVal(Me._desc) & ", " & _
                                "" & QVal(Me._unit) & ", " & _
                                "" & QVal("AC") & ", " & _
                                "" & QVal(Me._catalog) & ", " & _
                                "" & QVal(Me._packing) & ", " & _
                                "" & QVal(Me._minstok) & ", " & _
                                "" & QVal(Me._kdgroup) & ", " & _
                                "" & QVal(Me._polt) & ", " & _
                                "" & QVal(Me._mfglt) & ", " & _
                                "" & QVal(Me._remark) & ", " & _
                                "" & QVal(Me._carmodel) & ", " & _
                                "" & QVal(Me._price) & ", " & _
                                "" & QVal(gh_Common.Username) & ", " & _
                                "getdate())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeader()
        Try
            Dim ls_SP As String = "update inventory_lc " &
                                    "set Descr = " & QVal(Me._desc) & ", " &
                                    "StkUnit = " & QVal(Me._unit) & ", " &
                                    "TranStatusCode = " & QVal("AC") & ", " &
                                    "catalog = " & QVal(Me._catalog) & ", " &
                                    "packing = " & QVal(Me._packing) & ", " &
                                    "min_stok = " & QVal(Me._minstok) & ", " &
                                    "kdgrup = " & QVal(Me._kdgroup) & ", " &
                                    "polt = " & QVal(Me._polt) & ", " &
                                    "mfglt = " & QVal(Me._mfglt) & ", " &
                                    "remark = " & QVal(Me._remark) & ", " &
                                    "car_model = " & QVal(Me._carmodel) & ", " &
                                    "price = " & QVal(Me._price) & ", " &
                                    "updatedby = " & QVal(gh_Common.Username) & ", " &
                                    "updated_date = getdate() where InvtID = " & QVal(Me._invtid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeader()
        Try
            Dim ls_SP As String = "Delete from inventory_lc where InvtID =" & QVal(Me._invtid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

