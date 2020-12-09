Namespace Tree
    '    ''' <summary>
    '    ''' Generic Tree Node base class
    '    ''' </summary>
    '    ''' <typeparam name="T"></typeparam>
    '    Public MustInherit Class TreeNodeBase(Of T As {Class, ITreeNode(Of T)})
    '        Implements ITreeNode(Of T)

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <param name="nodeID"></param>
    '        Protected Sub New(nodeID As UInteger)
    '            Me.NodeID = nodeID
    '            Me.ChildNodes = New List(Of T)()
    '        End Sub

    '        ''' <summary>
    '        ''' Node ID
    '        ''' </summary>
    '        Public Property NodeID() As UInteger

    '        ''' <summary>
    '        ''' The data
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Property Data As T

    '        ''' <summary>
    '        ''' Parent
    '        ''' </summary>
    '        Public Property Parent() As T

    '        ''' <summary>
    '        ''' Child nodes
    '        ''' </summary>
    '        Public Property ChildNodes() As List(Of T)

    '        ''' <summary>
    '        ''' this
    '        ''' </summary>
    '        Protected MustOverride ReadOnly Property MySelf() As T

    '        ''' <summary>
    '        ''' True if a Leaf Node
    '        ''' </summary>
    '        Public ReadOnly Property IsLeaf() As Boolean
    '            Get
    '                Return ChildNodes.Count = 0
    '            End Get
    '        End Property

    '        ''' <summary>
    '        ''' True if the Root of the Tree
    '        ''' </summary>
    '        Public ReadOnly Property IsRoot() As Boolean
    '            Get
    '                Return Parent Is Nothing
    '            End Get
    '        End Property

    '        ''' <summary>
    '        ''' List of Leaf Nodes
    '        ''' </summary>
    '        Public Function GetLeafNodes() As List(Of T)
    '            Return ChildNodes.Where(Function(x) x.IsLeaf).ToList()
    '        End Function

    '        ''' <summary>
    '        ''' List of Non Leaf Nodes
    '        ''' </summary>
    '        Public Function GetNonLeafNodes() As List(Of T)
    '            Return ChildNodes.Where(Function(x) Not x.IsLeaf).ToList()
    '        End Function

    '        ''' <summary>
    '        ''' Get the Root Node of the Tree
    '        ''' </summary>
    '        Public Function GetRootNode() As ITreeNode(Of T)
    '            If Parent Is Nothing Then
    '                Return MySelf
    '            End If

    '            Return Parent.GetRootNode
    '        End Function

    '        ''' <summary>
    '        ''' Dot separated name from the Root to this Tree Node
    '        ''' </summary>
    '        Public Function GetFullyQualifiedName() As String
    '            If Parent Is Nothing Then
    '                Return NodeID.ToString
    '            End If

    '            Return String.Format("{0}.{1}", Parent.ToString(), NodeID)
    '        End Function

    '        ''' <summary>
    '        ''' Add a Child Tree Node
    '        ''' </summary>
    '        ''' <param name="child"></param>
    '        Public Sub AddChild(child As T)
    '            child.Parent = MySelf
    '            ChildNodes.Add(child)
    '        End Sub

    '        ''' <summary>
    '        ''' Add a collection of child Tree Nodes
    '        ''' </summary>
    '        ''' <param name="children"></param>
    '        Public Sub AddChildren(children As IEnumerable(Of T))
    '            For Each child As T In children
    '                AddChild(child)
    '            Next
    '        End Sub



    '#Region "IDisposable Support"
    '        Private disposedValue As Boolean ' To detect redundant calls

    '        ' IDisposable
    '        Protected Overridable Sub Dispose(disposing As Boolean)
    '            If Not Me.disposedValue Then
    '                If disposing Then
    '                    ' TODO: dispose managed state (managed objects).
    '                End If

    '                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
    '                ' TODO: set large fields to null.
    '            End If
    '            Me.disposedValue = True
    '        End Sub

    '        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    '        'Protected Overrides Sub Finalize()
    '        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '        '    Dispose(False)
    '        '    MyBase.Finalize()
    '        'End Sub

    '        ' This code added by Visual Basic to correctly implement the disposable pattern.
    '        Public Sub Dispose() Implements IDisposable.Dispose
    '            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '            Dispose(True)
    '            GC.SuppressFinalize(Me)
    '        End Sub
    '#End Region

    '    End Class
End Namespace