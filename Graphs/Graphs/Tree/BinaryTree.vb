Namespace Tree
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks> Refence here: http://www.dreamincode.net/forums/blog/217/entry-3354-generic-binary-tree/
    ''' ANOTHER binary tree: http://www.dreamincode.net/forums/topic/240466-a-basic-binary-trees/ </remarks>
    Public Class BinaryTreeNode(Of T As IComparable(Of T))

#Region "Instance Variables"

        Private mData As T

        Private mParentNode As BinaryTreeNode(Of T)

        Private mLeftNode As BinaryTreeNode(Of T)

        Private mRightNode As BinaryTreeNode(Of T)
#End Region
        Public Sub New(nodeData As T)
            Data = nodeData
            ParentNode = Nothing
            LeftNode = Nothing
            RightNode = Nothing
        End Sub

        Public Sub New(nodeData As T, parent As BinaryTreeNode(Of T))
            Data = nodeData
            ParentNode = parent
            LeftNode = Nothing
            RightNode = Nothing
        End Sub

#Region "Properties"
        Public Property Data As T
            Get
                Return mData
            End Get
            Private Set(value As T)
                mData = value
            End Set
        End Property

        Property ParentNode() As BinaryTreeNode(Of T)
            Get
                Return mParentNode
            End Get
            Protected Friend Set(value As BinaryTreeNode(Of T))
                mParentNode = value
            End Set
        End Property

        Public Property LeftNode As BinaryTreeNode(Of T)
            Get
                Return mLeftNode
            End Get
            Protected Friend Set(value As BinaryTreeNode(Of T))
                mLeftNode = value
            End Set
        End Property
        Public Property RightNode As BinaryTreeNode(Of T)
            Get
                Return mRightNode
            End Get
            Protected Friend Set(value As BinaryTreeNode(Of T))
                mRightNode = value
            End Set
        End Property
#End Region

#Region "Helpers"
        Public Function HasLeft() As Boolean
            Return LeftNode IsNot Nothing
        End Function
        Public Function HasRight() As Boolean
            Return RightNode IsNot Nothing
        End Function
        Public Function ParentAbsent() As Boolean
            Return ParentNode Is Nothing
        End Function
        Public Function LeftIsEmpty() As Boolean
            Return LeftNode Is Nothing
        End Function
        Public Function RightIsEmpty() As Boolean
            Return RightNode Is Nothing
        End Function
#End Region

#Region "Comparision Operators"

#Region "Node Based"
        Public Shared Operator =(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) = 0
        End Operator
        Public Shared Operator <>(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) <> 0
        End Operator
        Public Shared Operator <(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) < 0
        End Operator
        Public Shared Operator <=(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) <= 0
        End Operator
        Public Shared Operator >(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) > 0
        End Operator
        Public Shared Operator >=(a As BinaryTreeNode(Of T), b As BinaryTreeNode(Of T)) As Boolean
            Return a.Data.CompareTo(b.Data) >= 0
        End Operator
#End Region

#Region "Comparision Operators with Value"
        Public Shared Operator =(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) = 0
        End Operator
        Public Shared Operator <>(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) <> 0
        End Operator
        Public Shared Operator <(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) < 0
        End Operator
        Public Shared Operator >(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) > 0
        End Operator
        Public Shared Operator <=(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) <= 0
        End Operator
        Public Shared Operator >=(a As BinaryTreeNode(Of T), v As T) As Boolean
            Return a.Data.CompareTo(v) >= 0
        End Operator
#End Region

#End Region

        Public Overrides Function ToString() As String
            Return Data.ToString
        End Function

    End Class

    Public Class BinaryTree(Of T As IComparable(Of T))

#Region "Instance Variables"
        Private mRoot As BinaryTreeNode(Of T)
#End Region

        Public Sub New()
            mRoot = Nothing
        End Sub ' New

#Region "Insert Methods"

#Region "Insert based on value"
        Public Sub Insert(ByRef i As T)
            If mRoot Is Nothing Then
                mRoot = New BinaryTreeNode(Of T)(i, Nothing)
            Else
                Insert(mRoot, i)
            End If
        End Sub

        Private Shared Sub Insert(ByRef thisNode As BinaryTreeNode(Of T), value As T)
            If thisNode > value Then
                If thisNode.LeftIsEmpty Then
                    thisNode.LeftNode = New BinaryTreeNode(Of T)(value, thisNode)
                Else
                    Insert(thisNode.LeftNode, value)
                End If
            Else
                If thisNode.RightIsEmpty Then
                    thisNode.RightNode = New BinaryTreeNode(Of T)(value, thisNode)
                Else
                    Insert(thisNode.RightNode, value)
                End If
            End If
        End Sub
#End Region

#Region "Insert Based on nodes"
        Private Shared Sub Insert(ByRef thisNode As BinaryTreeNode(Of T), nodeBeingInserted As BinaryTreeNode(Of T))
            If nodeBeingInserted < thisNode Then
                If thisNode.LeftIsEmpty Then
                    thisNode.LeftNode = nodeBeingInserted
                    nodeBeingInserted.ParentNode = thisNode
                Else
                    Insert(thisNode.LeftNode, nodeBeingInserted)
                End If
            Else
                If thisNode.RightIsEmpty Then
                    thisNode.RightNode = nodeBeingInserted
                    nodeBeingInserted.ParentNode = thisNode
                Else
                    Insert(thisNode.RightNode, nodeBeingInserted)
                End If
            End If
        End Sub
#End Region

#End Region

#Region "Contains"
        Public Function Contains(ByVal key As T) As Boolean
            Return MyContains(key) IsNot Nothing
        End Function

        Private Function MyContains(ByVal key As T) As BinaryTreeNode(Of T)
            Dim current As BinaryTreeNode(Of T) = mRoot
            While (current IsNot Nothing) AndAlso (current <> key)
                current = If(current > key, current.LeftNode, current.RightNode)
            End While
            Return current
        End Function
#End Region

#Region "Deletion"
        Public Sub Clear()
            Dim nodeList As New List(Of BinaryTreeNode(Of T))
            Traverse_InOrder_Nodes(mRoot, nodeList)
            nodeList.ForEach(Sub(n)
                                 SetLinksToNull(n)
                                 n = Nothing
                             End Sub)
            mRoot = Nothing
        End Sub

        Public Function Delete(ByVal key As T) As Boolean
            Dim nodeLoci = MyContains(key)
            ' Not Found is idicated by a null value.
            If nodeLoci Is Nothing Then Return False
            Dim childrenOfNode = Traverse_InOrder_Nodes_ExceptMe(nodeLoci)
            If nodeLoci.ParentAbsent Then
                mRoot = Nothing
                childrenOfNode.ForEach(Sub(n)
                                           SetLinksToNull(n)
                                           If mRoot Is Nothing Then
                                               mRoot = n
                                           Else
                                               Insert(mRoot, n)
                                           End If
                                       End Sub)
                Return True
            Else
                Dim moveChildren = Function()
                                       childrenOfNode.ForEach(Sub(n) Insert(mRoot, SetLinksToNull(n))) ' Insert(NodeLoci.Parent, SetLinksToNull(n)))
                                       Return True
                                   End Function
                With nodeLoci.ParentNode
                    If .HasLeft AndAlso (.LeftNode = nodeLoci) Then
                        .LeftNode = Nothing : Return moveChildren()
                    ElseIf .HasRight AndAlso (.RightNode = nodeLoci) Then
                        .RightNode = Nothing : Return moveChildren()
                    End If
                End With
            End If
            Return False
        End Function
#End Region

#Region "Helper Methods"
        Private Shared Function SetLinksToNull(ByRef n As BinaryTreeNode(Of T)) As BinaryTreeNode(Of T)
            n.LeftNode = Nothing
            n.RightNode = Nothing
            n.ParentNode = Nothing
            Return n
        End Function
#End Region

#Region "In-Order Traversals"

        Private Function Travers_InOrder_Values() As List(Of T)
            Dim rl As New List(Of BinaryTreeNode(Of T))
            Traverse_InOrder_Nodes(mRoot, rl)
            Return rl.Select(Function(n) n.Data).ToList
        End Function

        Private Shared Function Traverse_InOrder_Nodes_ExceptMe(ByRef thisNode As BinaryTreeNode(Of T)) As List(Of BinaryTreeNode(Of T))
            Dim childrenLeft As New List(Of BinaryTreeNode(Of T))
            Dim childrenRight As New List(Of BinaryTreeNode(Of T))
            If thisNode IsNot Nothing Then
                If thisNode.HasLeft Then Traverse_InOrder_Nodes(thisNode.LeftNode, childrenLeft)
                If thisNode.HasRight Then Traverse_InOrder_Nodes(thisNode.RightNode, childrenRight)
            End If
            childrenLeft.Reverse()
            Return childrenLeft.Concat(childrenRight).ToList()
        End Function

        Private Shared Sub Traverse_InOrder_Nodes(ByVal thisNode As BinaryTreeNode(Of T), ByRef nodeList As List(Of BinaryTreeNode(Of T)))
            If thisNode IsNot Nothing Then
                If thisNode.HasLeft Then Traverse_InOrder_Nodes(thisNode.LeftNode, NodeList)
                NodeList.Add(thisNode)
                If thisNode.HasRight Then Traverse_InOrder_Nodes(thisNode.RightNode, NodeList)
            End If
        End Sub

#Region "Output Displays"

        Public Sub PrintOut(cout As IO.TextWriter)
            Travers_InOrder_Values.ForEach(Sub(n) cout.Write("{0} ", n))
            cout.WriteLine()
            cout.Flush()
        End Sub

        Public Sub PrintIndented(cout As IO.TextWriter)
            Traverse_InOrder_Indented(mRoot, cout, 0)
        End Sub

        Private Shared Sub Traverse_InOrder_Indented(ByVal thisNode As BinaryTreeNode(Of T), cout As IO.TextWriter, Optional indent As Integer = 0)
            If thisNode IsNot Nothing Then
                If thisNode.HasLeft Then
                    Traverse_InOrder_Indented(thisNode.LeftNode, cout, indent + 4)
                    cout.WriteLine("{0}{1}", New String(" "c, 2 + indent), "/")
                End If
                cout.WriteLine("{0}({1})", New String(" "c, indent), thisNode.Data.ToString)
                If thisNode.HasRight Then
                    cout.WriteLine("{0}{1}", New String(" "c, 2 + indent), "\")
                    Traverse_InOrder_Indented(thisNode.RightNode, cout, indent + 4)
                End If
            End If
            cout.Flush()
        End Sub
#End Region

#End Region

    End Class
End Namespace
