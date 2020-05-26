Imports System.Collections.ObjectModel
Public Class clsCoA
    Dim _Query As String
    Private _accountid As String
    Public Property AccountID() As String
        Get
            Return _accountid
        End Get
        Set(ByVal value As String)
            _accountid = value
        End Set
    End Property

    Private _accountname As String
    Public Property AccountName() As String
        Get
            Return _accountname
        End Get
        Set(ByVal value As String)
            _accountname = value
        End Set
    End Property

    Private _accounttype As String
    Public Property AccountType() As String
        Get
            Return _accounttype
        End Get
        Set(ByVal value As String)
            _accounttype = value
        End Set
    End Property

    Public Sub New()
        Me._Query = "select acctid as [Account ID], acctname [Account Name], tipe [Type] from tipeacct order by AcctID"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"


            'Tes Git
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
            Dim query As String = "select * from tipeacct where AcctID = " & QVal(ID) & " order by AcctID"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._accountid = Trim(.Item("acctid") & "")
                    Me._accountname = Trim(.Item("acctname") & "")
                    Me._accounttype = Trim(.Item("tipe") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByInvt(ByVal ID As String)
        Try
            Dim query As String = "select * from tipeacct where AcctID = " & QVal(ID) & " order by AcctID"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._accountid = Trim(.Item("acctid") & "")
                    Me._accountname = Trim(.Item("acctname") & "")
                    Me._accounttype = Trim(.Item("tie") & "")
                End With
            Else
                _accountid = ""
                _accountname = ""
                _accounttype = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me._accountname = "" OrElse Me._accountid = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 acctid from tipeacct where acctid = " & QVal(Me._accountid) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) & _
                "[" & Me._accountname & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "Insert into tipeacct(acctid,acctname,tipe,created_by,created_date) " & _
                                "values(" & QVal(Me._accountid) & ", " & _
                                "" & QVal(Me._accountname) & ", " & _
                                "" & QVal(Me._accounttype) & ", " & _
                                "" & QVal(gh_Common.Username) & ", " & _
                                "getdate())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim ls_SP As String = "update tipeacct " & _
                                    "set acctname = " & QVal(Me._accountname) & ", " & _
                                    "tipe = " & QVal(Me._accounttype) & ", " & _
                                    "updated_by = " & QVal(gh_Common.Username) & ", " & _
                                    "updated_date = getdate() where acctID = " & QVal(Me._accountid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim ls_SP As String = "Delete from tipeacct where acctID =" & QVal(Me._accountid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class

