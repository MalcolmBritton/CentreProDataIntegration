Public Class DBConnection

    Implements System.IDisposable
    Public conn As SqlConnection

#Region "Private Member Variables"
    Private m_ConnectionStatus As Boolean
    Private m_ConnectionExceptionMessage As String
    Private m_ConnectionExceptionDetail As String
#End Region

    Public Sub New()

    End Sub

    Public Sub New(sString As String)
        If ConnectDB(sString) = False Then
            m_ConnectionStatus = False
        Else
            m_ConnectionStatus = True
        End If
    End Sub

    Public Shared Function GetConnectionIntegrated() As SqlConnection

        Return New SqlConnection(My.Settings.conIntegrated)

    End Function

    Public Shared Function GetConnectionIntermediate() As SqlConnection

        Return New SqlConnection(My.Settings.conIntermediate)

    End Function

    Public Shared Function GetConnectionTrident() As SqlConnection

        Return New SqlConnection(My.Settings.conTridentCounrt)

    End Function

    Public Shared Function GetConnectionBuilding(sConn As String) As SqlConnection

        ' Connect to a specific building database in the enterprise
        Return New SqlConnection(sConn)

    End Function

    Private Function ConnectDB(sString) As Boolean
        Try
            conn = New SqlConnection(sString)
            conn.Open()
            ' close the connection otherwise it'll hang about for the enitre application life!
            conn.Close()
            Return True
        Catch ex As Exception
            m_ConnectionExceptionMessage = ex.Message.ToString
            m_ConnectionExceptionDetail = ex.ToString
            Return False
        End Try

    End Function

    Public ReadOnly Property ConnectionStatus As Boolean
        Get
            Return m_ConnectionStatus
        End Get
    End Property

    Public ReadOnly Property ConnectionExceptionMessage As String
        Get
            Return m_ConnectionExceptionMessage
        End Get
    End Property

    Public ReadOnly Property ConnectionExceptionDetail As String
        Get
            Return m_ConnectionExceptionDetail
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
