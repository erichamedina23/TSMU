Public Class clsBoMdetails
#Region "variables"
    Private _bomid As String
    Public Property BoMID() As String
        Get
            Return _bomid
        End Get
        Set(ByVal value As String)
            _bomid = value
        End Set
    End Property
    Private _parentid As String
    Public Property Parentid() As String
        Get
            Return _parentid
        End Get
        Set(ByVal value As String)
            _parentid = value
        End Set
    End Property

    Private _invtid_detail As String
    Public Property inventId() As String
        Get
            Return _invtid_detail
        End Get
        Set(ByVal value As String)
            _invtid_detail = value
        End Set
    End Property

    Private _descr_detail As String
    Public Property Descr_detail() As String
        Get
            Return _descr_detail
        End Get
        Set(ByVal value As String)
            _descr_detail = value
        End Set
    End Property

    Private _qty As Single
    Public Property Qty() As Single
        Get
            Return _qty
        End Get
        Set(ByVal value As Single)
            _qty = value
        End Set
    End Property

    Private _unit As String
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(ByVal value As String)
            _unit = value
        End Set
    End Property
#End Region
    Public Sub InsertDetail()
        Try
            Dim ls_SP As String = "" & vbCrLf & _
                                "INSERT INTO bom(bomid,parentid,invtid,descr,qty,unit) " & vbCrLf & _
                                "OUTPUT Inserted.bomid, " & vbCrLf & _
                                "       Inserted.parentid, " & vbCrLf & _
                                "       Inserted.invtid, " & vbCrLf & _
                                "       Inserted.descr, " & vbCrLf & _
                                "       Inserted.qty, " & vbCrLf & _
                                "       Inserted.unit, " & vbCrLf & _
                                "       0 " & vbCrLf & _
                                "       INTO bom_detail_history " & vbCrLf & _
                                "VALUES(" & QVal(Me._bomid) & ", " & vbCrLf & _
                                "   " & QVal(Me._parentid) & ", " & vbCrLf & _
                                "   " & QVal(Me._invtid_detail) & ", " & vbCrLf & _
                                "   " & QVal(Me._descr_detail) & ", " & vbCrLf & _
                                "   " & QVal(Me._qty) & ", " & vbCrLf & _
                                "   " & QVal(Me._unit) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal bomid As String, ByVal rev As Integer)
        Try
            Dim ls_SP As String = "" & vbCrLf &
                            "Delete from bom " & vbCrLf &
                            "   OUTPUT DELETED.*, " & rev & " + 1 Into bom_detail_history " & vbCrLf &
                            "where bomid = " & QVal(bomid) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetailByParentAndInvt(ByVal ParentId As String, ByVal InvtID As Integer)
        Try
            Dim ls_SP As String = "" & vbCrLf &
                            "Delete from bom " & vbCrLf &
                            "where ParentId = " & QVal(ParentId) & " AND InvtId = " & QVal(InvtID) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateQtyDetailsManual(ParentId As String, InvtID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update bom " & vbCrLf &
                                    "SET    Qty = " & QVal(Me.Qty) & " " & vbCrLf &
                                    "       where RTRIM(parentid) = " & QVal(ParentId.Trim) & " AND RTRIM(InvtId) = " & QVal(InvtID.Trim) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
