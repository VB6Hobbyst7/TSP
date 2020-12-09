Public Class Node(Of T As {IEquatable(Of T), IComparable(Of T)})
    Implements INode
    Implements IEquatable(Of Node(Of T))
    Implements IComparable(Of Node(Of T))

    Protected mEdges As List(Of Integer)

#Region "Constructor"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Node" /> class.
    '''<param name="attr">The attributes.</param>
    ''' </summary>
    Public Sub New(Optional attr As T = Nothing)
        Attributes = attr
        mEdges = New List(Of Integer)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Node" /> class.
    ''' </summary>
    ''' <param name="edges">The edges connected to the node.</param>
    ''' <param name="attr">The attributes.</param>
    Public Sub New(edges As ICollection(Of Integer), Optional attr As T = Nothing)
        Attributes = attr
        mEdges.AddRange(edges)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets the attributes.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Attributes As T

    ''' <summary>
    ''' Gets the edges.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Edges As ICollection(Of Integer) Implements INode.Edges
        Get
            Return mEdges
        End Get
    End Property

    '''' <summary>
    '''' 
    '''' </summary>
    '''' <param name="indxNode"></param>
    'Public Function IsNeighbor(indxNode As Integer) As Boolean
    '    Return Neigborgs.Contains(indxNode)
    'End Function

    ''' <summary>
    ''' Gets the degree of the node
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Degree As Integer Implements INode.Degree
        Get
            Return Edges.Count
        End Get
    End Property
#End Region

#Region "Methods"
    Public Shadows Function Equals(other As Node(Of T)) As Boolean Implements IEquatable(Of Node(Of T)).Equals
        ' Check for null
        If other Is Nothing Then Return False

        'Compare run-time types.
        If Not [GetType]() Is other.GetType() Then Return False

        ' Check for same reference
        'If ReferenceEquals(Me, other) Then Return True

        'If Edges.Count <> other.Edges.Count Then Return False
        'If Edges.Union(other.Edges).Count <> Edges.Count Then Return False
        If Not Attributes.Equals(other.Attributes) Then Return False

        Return True
    End Function

    Public Function CompareTo(other As Node(Of T)) As Integer Implements IComparable(Of Node(Of T)).CompareTo
        Return Attributes.CompareTo(other.Attributes)
        'Throw New NotImplementedException()
    End Function

    ''' <summary>
    ''' Returns a <see cref="T:System.String" /> that represents the current
    ''' <see cref="T:System.Object" />.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Dim s As String = Edges.Aggregate("", Function(current, n) current & (" " & n.ToString))
        Return String.Format("{0} {1}", s, Attributes.ToString)
    End Function


#End Region

End Class
