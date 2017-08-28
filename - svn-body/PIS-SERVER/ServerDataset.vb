Partial Class ServerDataset
    Partial Class T_Line_MSTDataTable

        Private Sub T_Line_MSTDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NodeAddressColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

'Namespace ServerDatasetTableAdapters

'    Partial Public Class TEMP_Production_DATTableAdapter
'    End Class
'End Namespace

Namespace ServerDatasetTableAdapters
    
    Partial Public Class T_LOG_DATTableAdapter
    End Class
End Namespace

Namespace ServerDatasetTableAdapters
    
    Partial Public Class T_Instruction_DATTableAdapter
    End Class
End Namespace
