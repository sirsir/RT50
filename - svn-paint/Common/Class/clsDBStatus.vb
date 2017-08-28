Public Class clsDBStatus
    Inherits System.ComponentModel.BackgroundWorker

#Region "Attribute"
    Private m_blnLastConnectionStatus As Boolean = False
    Private m_clrSuccess As Color = Color.DarkGray
    Private m_clrFail As Color = Color.DarkGray
#End Region

#Region "Constructor"
    Public Sub New()
        Me.WorkerSupportsCancellation = True
        Me.WorkerReportsProgress = True
    End Sub
#End Region

#Region "Property"

    Public ReadOnly Property SuccessColor() As Color
        Get
            Return m_clrSuccess
        End Get
    End Property

    Public ReadOnly Property FailColor() As Color
        Get
            Return m_clrFail
        End Get
    End Property

    Public ReadOnly Property LastConnectionStatus() As Boolean
        Get
            Return m_blnLastConnectionStatus
        End Get
    End Property

#End Region

#Region "Event"

    Private Sub clsDBStatus_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        Dim blnResult As Boolean
        Dim conn As New SqlClient.SqlConnection(My.Settings.ConnectionString)
        Dim cmd As SqlClient.SqlCommand = conn.CreateCommand

        cmd.CommandText = "SELECT 1"

        While Not Me.CancellationPending
            Try
                If conn.State <> ConnectionState.Open Then
                    SqlClient.SqlConnection.ClearPool(conn) 
                    conn.Open()
                End If

                cmd.ExecuteScalar()
                blnResult = True
            Catch ex As Exception
                blnResult = False
            End Try 

            m_clrSuccess = IIf(blnResult, Color.Green, Color.DarkGray)
            m_clrFail = IIf(blnResult, Color.DarkGray, Color.Red)

            If m_blnLastConnectionStatus <> blnResult Then
                m_blnLastConnectionStatus = blnResult
                ReportProgress(0, 1)
            End If

            Threading.Thread.Sleep(My.Settings.DB_PoolInterval)
        End While
    End Sub

#End Region

End Class
