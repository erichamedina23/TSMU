Partial Class dsLaporan
    Partial Public Class NPPDataTable
    End Class

    Partial Public Class NpwoRevDataTable


    End Class

    Partial Public Class ARDataTable
    End Class

    Partial Public Class suspendDataTable
    End Class

    Partial Public Class QRCodeDataTable
        Private Sub QRCodeDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.InvtIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class



End Class
