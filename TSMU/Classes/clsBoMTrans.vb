Imports System.Collections.ObjectModel
Public Class clsBoMTrans
    Dim _fc_classdetail As New Collection(Of clsBoMdetails)
    Dim fc_clsHeader As New clsBoM
    'Dim fc_clsDetails As New BoMDetail
    Private _bomid As String
    Public Property BoMID() As String
        Get
            Return _bomid
        End Get
        Set(ByVal value As String)
            _bomid = value
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

    Private _siteid As String
    Public Property SiteID() As String
        Get
            Return _siteid
        End Get
        Set(ByVal value As String)
            _siteid = value
        End Set
    End Property

    Private _runner As String
    Public Property Runner() As String
        Get
            Return _runner
        End Get
        Set(ByVal value As String)
            _runner = value
        End Set
    End Property

    Private _ct As String
    Public Property CycleTime() As String
        Get
            Return _ct
        End Get
        Set(ByVal value As String)
            _ct = value
        End Set
    End Property
    Private _mc As String
    Public Property MC() As String
        Get
            Return _mc
        End Get
        Set(ByVal value As String)
            _mc = value
        End Set
    End Property
    Public Property cavity() As String
    Public Property WC() As String
    Private _allowance As Integer
    Public Property Allowance() As Integer
        Get
            Return _allowance
        End Get
        Set(ByVal value As Integer)
            _allowance = value
        End Set
    End Property
    Private _mp As String
    Public Property MP() As String
        Get
            Return _mp
        End Get
        Set(ByVal value As String)
            _mp = value
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
    Private _active As Integer
    Public Property Active() As Integer
        Get
            Return _active
        End Get
        Set(ByVal value As Integer)
            _active = value
        End Set
    End Property
    Public Property RefType() As String
    Public Property RefNo() As String
    Public Property Converted() As Boolean
    Public Property fc_classdetail() As Collection(Of clsBoMdetails)
        Get
            Return Me._fc_classdetail
        End Get
        Set(ByVal value As Collection(Of clsBoMdetails))
            Me._fc_classdetail = value
        End Set
    End Property
    Public Sub InsertBoM(status As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        With fc_clsHeader
                            .BoMID = Me._bomid
                            .Tgl = Me._tgl
                            .InvtID = Me._invtid
                            .Desc = Me._desc
                            .SiteID = Me._siteid
                            .CycleTime = Me._ct
                            .Runner = Me._runner
                            .MC = Me._mc
                            .cavity = Me.cavity
                            .WC = Me.WC
                            .Allowance = Me._allowance
                            .Status = Me._status
                            .Active = Me._active
                            .MP = Me._mp
                            .Converted = False
                        End With

                        fc_clsHeader.InsertHeader(status)

                        For i As Integer = 0 To Me._fc_classdetail.Count - 1
                            With Me._fc_classdetail(i)
                                .InsertDetail()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateBoM(ByVal Rev As Integer, IsConverted As Boolean, status As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        With fc_clsHeader
                            .Tgl = Me._tgl
                            .InvtID = Me._invtid
                            .Desc = Me._desc
                            .SiteID = Me._siteid
                            .CycleTime = Me._ct
                            .Runner = Me._runner
                            .MC = Me._mc
                            .cavity = Me.cavity
                            .WC = Me.WC
                            .Allowance = Me._allowance
                            .MP = Me._mp
                            .Status = status
                            .Active = Me._active
                            .RefType = Me.RefType
                            .RefNo = RefNo
                            .Converted = Converted
                            If IsConverted Then
                                .ValidateInsert1()
                                .BoMID = .RegularAutoNo
                                .InsertHeader(status)
                            Else
                                .BoMID = _bomid
                                .UpdateHeader(Rev)
                            End If
                        End With


                        Dim fc_classdetail As New clsBoMdetails
                        If IsConverted Then
                        Else
                            fc_classdetail.DeleteDetail(Me._bomid, Rev)
                        End If

                        For i As Integer = 0 To Me._fc_classdetail.Count - 1
                            With Me._fc_classdetail(i)
                                .InsertDetail()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1
                    Try
                        fc_clsHeader.DeleteHeader(Me._bomid)

                        Dim fc_classdetail As New clsBoMdetails
                        fc_classdetail.DeleteDetail(Me._bomid, 0)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
