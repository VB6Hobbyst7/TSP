Namespace Tree
    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <typeparam name="T"></typeparam>
    '    ''' <remarks>Refence here: http://www.dreamincode.net/forums/blog/217/entry-3354-generic-binary-tree/ </remarks>
    '    Public Class TreeNode(Of T As IEquatable(Of T))
    '        Implements ITreeNode(Of T)

    '#Region "Instance Variables"
    '        Protected Root As ITreeNode(Of T)
    '#End Region

    '#Region "Constructors"
    '        Public Sub New()
    '            Root = Nothing
    '        End Sub ' New

    '        Public Sub New(ByVal nodeID As UInteger)
    '            Me.NodeID = nodeID
    '            Me.Data = Nothing
    '            Me.Parent = Nothing
    '            Me.Childs = Nothing
    '            Me.Depth = 0
    '        End Sub

    '        Public Sub New(ByVal nodeID As UInteger, ByVal nodeData As T)
    '            Me.Data = nodeData
    '            Me.Parent = Nothing
    '            Me.Childs = Nothing
    '            Me.Depth = 0
    '        End Sub

    '        Public Sub New(ByVal nodeID As UInteger, ByVal nodeData As T, ByRef parent As ITreeNode(Of T))
    '            Me.Data = nodeData
    '            Me.Parent = parent
    '            Me.Childs = Nothing
    '            Me.Depth = 0
    '        End Sub

    '        Public Sub New(ByVal nodeID As UInteger, ByVal nodeData As T, ByRef parent As ITreeNode(Of T), ByVal childs As List(Of ITreeNode(Of T)))
    '            Me.Data = nodeData
    '            Me.Parent = parent
    '            Me.Childs = childs
    '            Me.Depth = 0
    '        End Sub

    '        Public Sub New(ByVal nodeID As UInteger, ByVal nodeData As T, ByRef parent As ITreeNode(Of T), ByVal childs As List(Of ITreeNode(Of T)), ByVal depth As Byte)
    '            Me.Data = nodeData
    '            Me.Parent = parent
    '            Me.Childs = childs
    '            Me.Depth = depth
    '        End Sub
    '#End Region

    '#Region "Properties"
    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Property NodeID As UInteger Implements INode.NodeID

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Property Data As T Implements INode(Of T).Attributes

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Property Parent() As ITreeNode(Of T) Implements ITreeNode(Of T).Parent

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Property Childs As List(Of ITreeNode(Of T)) Implements ITreeNode(Of T).ChildNodes

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Property Depth As Byte Implements ITreeNode(Of T).Depth

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public ReadOnly Property IsLeaf As Boolean Implements ITreeNode(Of T).IsLeaf
    '            Get
    '                Return Childs.Count = 0
    '            End Get
    '        End Property

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <value></value>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public ReadOnly Property IsRoot As Boolean Implements ITreeNode(Of T).IsRoot
    '            Get
    '                Return Parent Is Nothing
    '            End Get
    '        End Property
    '#End Region

    '#Region "Methods"
    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Function GetRootNode() As ITreeNode(Of T) Implements ITreeNode(Of T).GetRootNode
    '            If Parent Is Nothing Then
    '                Return Me
    '            End If

    '            Return Parent.GetRootNode()
    '        End Function

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <param name="node"></param>
    '        ''' <remarks></remarks>
    '        Public Sub AddChild(ByVal node As ITreeNode(Of T))
    '            If Not Me.Childs.Contains(node) Then Me.Childs.Add(node)
    '        End Sub

    '        ''' <summary>
    '        ''' 
    '        ''' </summary>
    '        ''' <returns></returns>
    '        ''' <remarks></remarks>
    '        Public Overrides Function ToString() As String
    '            Return Data.ToString
    '        End Function
    '#End Region

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

    '    Public Class Tree(Of T As {IEquatable(Of T), TreeNode(Of T)})
    '        Inherits Utils.StringContainer(Of T)

    '#Region "Instance Variables"
    '        Protected Root As TreeNode(Of T)
    '#End Region

    '        Public Sub New()
    '            Root = Nothing
    '        End Sub ' New

    '#Region "In-Order Traversals"

    '        Public Function Travers_InOrder_Values() As List(Of T)
    '            Dim rl As New List(Of TreeNode(Of T))
    '            Traverse_InOrder_Nodes(Root, rl)
    '            Return rl.Select(Function(n) n.Data).ToList
    '        End Function

    '        Private Function Traverse_InOrder_Nodes_ExceptMe(ByRef thisNode As TreeNode(Of T)) As List(Of TreeNode(Of T))
    '            Dim Children_Left As New List(Of TreeNode(Of T))
    '            Dim Children_Right As New List(Of TreeNode(Of T))
    '            If thisNode IsNot Nothing Then
    '                'If thisNode.HasLeft Then Traverse_InOrder_Nodes(thisNode.LeftNode, Children_Left)
    '                'If thisNode.HasRight Then Traverse_InOrder_Nodes(thisNode.RightNode, Children_Right)
    '            End If
    '            Children_Left.Reverse()
    '            Return Children_Left.Concat(Children_Right).ToList()
    '        End Function

    '        Private Sub Traverse_InOrder_Nodes(ByVal thisNode As TreeNode(Of T), ByRef NodeList As List(Of TreeNode(Of T)))
    '            If thisNode IsNot Nothing Then
    '                'If thisNode.HasLeft Then Traverse_InOrder_Nodes(thisNode.LeftNode, NodeList)
    '                'NodeList.Add(thisNode)
    '                'If thisNode.HasRight Then Traverse_InOrder_Nodes(thisNode.RightNode, NodeList)
    '            End If
    '        End Sub

    '#Region "Output Displays"

    '        Public Sub PrintOut(cout As System.IO.TextWriter)
    '            Travers_InOrder_Values.ForEach(Sub(n) cout.Write("{0} ", n))
    '            cout.WriteLine()
    '            cout.Flush()
    '        End Sub

    '        Public Sub PrintIndented(cout As System.IO.TextWriter)
    '            Traverse_InOrder_Indented(Root, cout, 0)
    '        End Sub

    '        Private Shared Sub Traverse_InOrder_Indented(ByVal thisNode As TreeNode(Of T), cout As System.IO.TextWriter, Optional Indent As Integer = 0)
    '            If thisNode IsNot Nothing Then
    '                'If thisNode.HasLeft Then
    '                '    Traverse_InOrder_Indented(thisNode.LeftNode, cout, Indent + 4)
    '                '    cout.WriteLine("{0}{1}", New String(" "c, 2 + Indent), "/")
    '                'End If
    '                'cout.WriteLine("{0}({1})", New String(" "c, Indent), thisNode.Data.ToString)
    '                'If thisNode.HasRight Then
    '                '    cout.WriteLine("{0}{1}", New String(" "c, 2 + Indent), "\")
    '                '    Traverse_InOrder_Indented(thisNode.RightNode, cout, Indent + 4)
    '                'End If
    '            End If
    '            cout.Flush()
    '        End Sub
    '#End Region

    '#End Region

    '    End Class
End Namespace
