Public Class Edge
    Implements IEdge
    Implements IEquatable(Of Edge)
    Implements IComparable(Of Edge)

#Region "Constructor"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Edge" /> class.
    ''' </summary>
    ''' <param name="node1">The node1 index.</param>
    ''' <param name="node2">The node2 index.</param>
    ''' <param name="active"></param>
    Public Sub New(node1 As Integer, node2 As Integer, Optional active As Boolean = True)
        Debug.Assert(node1 >= 0, "New: node1 argument not valid")
        Debug.Assert(node2 >= 0, "New: node2 argument not valid")
        Debug.Assert(node1 <> node2, "New: node1 and node2 must be different")

        If node1 < node2 Then
            Me.Node1 = node1
            Me.Node2 = node2
        Else
            Me.Node1 = node2
            Me.Node2 = node1
        End If
        Me.Active = active
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Node1 As Integer Implements IEdge.Node1

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Node2 As Integer Implements IEdge.Node2

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Active As Boolean Implements IEdge.Active
#End Region

#Region "Methods"
    ''' <summary>
    ''' Gets the other node.
    ''' </summary>
    ''' <param name="refNodeID">The reference node ID of the edge.</param>
    ''' <returns></returns>
    Public Function GetOtherNode(refNodeID As Integer) As Integer 'Implements IEdge.GetOtherNode
        If Node1 = refNodeID Then
            Return Node2
        ElseIf Node2 = refNodeID Then
            Return Node1
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Overridable Shadows Function Equals(other As Edge) As Boolean Implements IEquatable(Of Edge).Equals
        ' Check for null
        If other Is Nothing Then Return False

        ' Compare run-time types.
        If Not Me.GetType() Is other.GetType() Then Return False

        ' Check for same reference
        If ReferenceEquals(Me, other) Then Return True

        If Node1 <> other.Node1 OrElse Node2 <> other.Node2 Then Return False

        Return True
    End Function

    ''' <summary>
    '''  Make a shallow clone of this edge.
    ''' </summary>
    ''' <returns></returns>
    Public Function ShallowClone() As Edge
        Return CType(MemberwiseClone(), Edge)
    End Function

    ''' <summary>
    ''' Make a deep clone of this node.
    ''' </summary>
    ''' <returns></returns>
    Public Function DeepClone() As Edge
        Return New Edge(Node1, Node2, Active)
    End Function

    ''' <summary>
    ''' Returns a <see cref="T:System.String" /> that represents the current
    ''' <see cref="T:System.Object" />.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return String.Format("{0} {1} - {2}", Node1, Node2, Active.ToString)
    End Function

    Public Function CompareTo(other As Edge) As Integer Implements IComparable(Of Edge).CompareTo
        If Node1 = other.Node1 AndAlso Node2 = other.Node2 Then
            Return 0
        ElseIf Node1 > other.Node1 AndAlso Node2 > other.Node2 Then
            Return 1
        ElseIf Node1 < other.Node1 AndAlso Node2 < other.Node2 Then
            Return -1
        Else
            Return 0
        End If
        'Throw New NotImplementedException()
    End Function
#End Region

End Class

Public Class Edge(Of T As {IEquatable(Of T), IComparable(Of T)})
    Inherits Edge
    Implements IEquatable(Of Edge(Of T))
    Implements IComparable(Of Edge(Of T))

#Region "Constructor"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Edge" /> class.
    ''' </summary>
    ''' <param name="node1">The node1 index.</param>
    ''' <param name="node2">The node2 index.</param>
    ''' <param name="active"></param>
    ''' <param name="attr">The additional attributes of the edge.</param>
    Public Sub New(node1 As Integer, node2 As Integer, attr As T, Optional active As Boolean = True)
        MyBase.New(node1, node2, active)
        Attributes = attr
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets the attributes.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Attributes As T
#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Overloads Function Equals(other As Edge(Of T)) As Boolean Implements IEquatable(Of Edge(Of T)).Equals
        ' Check for null
        If other Is Nothing Then Return False

        ' Compare run-time types.
        'If Not Me.GetType() Is other.GetType() Then Return False

        ' Check for same reference
        'If ReferenceEquals(Me, other) Then Return True

        If Not MyBase.Equals(other) Then Return False
        'if Node1 <> other.Node1 OrElse Node2 <> other.Node2 = False Then Return False

        If Not Attributes.Equals(other.Attributes) Then Return False

        Return True
    End Function

    ''' <summary>
    '''  Make a shallow clone of this edge.
    ''' </summary>
    ''' <returns></returns>
    Public Shadows Function ShallowClone() As Edge(Of T)
        Return CType(MemberwiseClone(), Edge(Of T))
    End Function

    ''' <summary>
    ''' Make a deep clone of this node.
    ''' </summary>
    ''' <returns></returns>
    Public Shadows Function DeepClone() As Edge(Of T)
        Throw New NotImplementedException
        'Return New Edge(Of T)(Node1, Node2, Attributes.DeepClone(), Active)
    End Function

    Public Overloads Function CompareTo(other As Edge(Of T)) As Integer Implements IComparable(Of Edge(Of T)).CompareTo
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
        Return String.Format("{0} {1}", MyBase.ToString, Attributes.ToString)
    End Function

#End Region

End Class
