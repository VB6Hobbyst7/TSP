'Public Class Arc(Of T)
'    Implements IArc(Of T)
'    Implements IEquatable(Of Arc(Of T))

'    Protected mSourceNode As Integer
'    Protected mSinkNode As Integer
'    Private ReadOnly mAttributes As T
'#Region "Constructor"
'    ''' <summary>
'    ''' Initializes a new instance of the <see cref="Arc" /> class.
'    ''' </summary>
'    ''' <param name="sourceID">The source node ID.</param>
'    ''' <param name="sinkID">The sink node ID.</param>
'    ''' <param name="attr">The additional attributes of the edge.</param>
'    Public Sub New(ByVal sourceID As Integer, ByVal sinkID As Integer, ByVal attr As T)
'        Debug.Assert(sourceID > 0, Me.GetType.ToString, "New: node1 argument not valid")
'        Debug.Assert(sinkID > 0, Me.GetType.ToString, "New: node2 argument not valid")
'        mSourceNode = sourceID
'        mSinkNode = sinkID
'        mAttributes = attr
'    End Sub
'#End Region

'#Region "Properties"
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <returns></returns>
'    Public ReadOnly Property SourceNode As Integer Implements IArc(Of T).SourceNode
'        Get
'            Return mSourceNode
'        End Get
'    End Property

'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <returns></returns>
'    Public ReadOnly Property SinkNode As Integer Implements IArc(Of T).SinkNode
'        Get
'            Return mSinkNode
'        End Get
'    End Property

'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <returns></returns>
'    Public ReadOnly Property Attributes As T Implements IArc(Of T).Attributes
'        Get
'            Return mAttributes
'        End Get
'    End Property
'#End Region

'#Region "Methods"
'    ''' <summary>
'    ''' Gets the id of the node in the other extreme of the arc.
'    ''' </summary>
'    ''' <param name="refNodeID">The reference node ID of the arc.</param>
'    ''' <returns></returns>
'    Public Overridable Function GetOtherNode(ByVal refNodeID As Integer) As Integer Implements IArc(Of T).GetOtherNode
'        If mSourceNode = refNodeID Then
'            Return mSinkNode
'        ElseIf mSinkNode = refNodeID Then
'            Return mSourceNode
'        Else
'            Return Nothing
'        End If
'    End Function

'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="other"></param>
'    ''' <returns></returns>
'    Public Shadows Function Equals(other As Arc(Of T)) As Boolean Implements IEquatable(Of Arc(Of T)).Equals
'        ' Check for null values and compare run-time types.
'        If other Is Nothing Or Not Me.GetType() Is other.GetType() Then
'            Return False
'        End If

'        ' Check for null
'        If ReferenceEquals(other, Nothing) Then Return False

'        ' Check for same reference
'        If ReferenceEquals(Me, other) Then Return True

'        If mSourceNode <> other.SourceNode Then Return False
'        If mSinkNode <> other.SinkNode Then Return False
'        If Not Attributes.Equals(other.Attributes) Then Return False

'        Return True
'    End Function

'    ''' <summary>
'    ''' Make a shallow clone of this node.
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function ShallowClone() As Arc(Of T)
'        Return CType(MemberwiseClone(), Arc(Of T))
'    End Function

'    ''' <summary>
'    ''' Make a deep clone of this node.
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function DeepClone() As Arc(Of T)
'        Throw New NotImplementedException
'        'Return New Arc(Of T)(mSourceNode, mSinkNode, mAttributes.deepClone())
'    End Function

'    ''' <summary>
'    ''' Returns a <see cref="T:System.String" /> that represents the current
'    ''' <see cref="T:System.Object" />.
'    ''' </summary>
'    ''' <returns>
'    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
'    ''' </returns>
'    Public Overrides Function ToString() As String
'        Return String.Format("{0} {1} {2}", mSourceNode, mSinkNode, mAttributes.ToString)
'    End Function
'#End Region

'End Class
