Public Interface INode
    ReadOnly Property Edges As ICollection(Of Integer)
    ReadOnly Property Degree As Integer
End Interface

Public Interface IEdge
    ReadOnly Property Node1 As Integer
    ReadOnly Property Node2 As Integer
    Property Active As Boolean
End Interface

'Public Interface IArc(Of T)
'    ReadOnly Property SourceNode As Integer
'    ReadOnly Property SinkNode As Integer
'    ReadOnly Property Attributes As T
'    Function GetOtherNode(ByVal nodeID As Integer) As Integer
'End Interface
