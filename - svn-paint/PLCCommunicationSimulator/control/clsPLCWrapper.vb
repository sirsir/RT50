Public Class clsPLCWrapper
    Inherits OMRON.Compolet.SYSMAC.SysmacCS

#Region "Attributes"
    Private m_Mutex As Threading.Mutex
    Private m_strMutexName As String
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Method"
    Public Sub InitializeAndConnect(ByVal net As Integer, ByVal node As Integer, ByVal unit As Integer, Optional ByVal mutexName As String = "")
        Me.NetworkAddress = CShort(net)
        Me.NodeAddress = CShort(node)
        Me.UnitAddress = CShort(unit)
        Me.Active() = True
        Me.Update()

        m_strMutexName = IIf(mutexName = String.Empty, "OMRON.Compolet.SYSMAC.SysmacCS", mutexName)
        m_Mutex = New Threading.Mutex(False, m_strMutexName)
    End Sub
#End Region

    Public Shadows Function ReadMemoryWordInteger(ByVal memoryType As OMRON.Compolet.SYSMAC.SysmacCS.MemoryTypes, ByVal offset As Long, ByVal count As Long, ByVal dataType As OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes) As Integer()
        Me.GetLock()
        ReadMemoryWordInteger = MyBase.ReadMemoryWordInteger(memoryType, offset, count, dataType)
        Me.ReleaseLock()
    End Function

    Private Sub GetLock()
        m_Mutex.WaitOne()
    End Sub

    Private Sub ReleaseLock()
        m_Mutex.ReleaseMutex()
    End Sub
End Class
