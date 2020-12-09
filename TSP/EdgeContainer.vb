Public Class EdgeContainer

    Protected mEdges As List(Of Integer)
    Protected mValue As Single

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub New()
        mEdges = New List(Of Integer)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edges"></param>
    Public Sub New(edges As IEnumerable(Of Integer))
        mEdges = New List(Of Integer)(edges)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Value As Single
        Get
            Return mValue
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Count As Integer
        Get
            Return mEdges.Count
        End Get
    End Property
#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edgeIndx"></param>
    ''' <param name="value"></param>
    Public Sub AddEdge(edgeIndx As Integer, value As Single)
        mEdges.Add(edgeIndx)
        mValue += value
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="indx"></param>
    ''' <returns></returns>
    Public Function GetEdge(indx As Integer) As Integer
        Return mEdges(indx)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="eIndx"></param>
    ''' <returns></returns>
    Public Function ContainsEdge(eIndx As Integer) As Boolean
        Return mEdges.Contains(eIndx)
    End Function
#End Region

End Class
