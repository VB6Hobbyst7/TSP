Imports System.Runtime.CompilerServices

Public Class Graph(Of N As {INode, IEquatable(Of N), IComparable(Of N)}, E As {IEdge, IEquatable(Of E), IComparable(Of E)})

    Protected mNodes As Container(Of N)
    Protected mEdges As Container(Of E)

#Region "Constructors"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Graph(Of N, E)" /> class.
    ''' </summary>
    ''' <param name="numberOfNodes">The number of nodes.</param>
    ''' <param name="numberOfEdges">The number of edges.</param>
    Public Sub New(Optional numberOfNodes As Integer = 100, Optional numberOfEdges As Integer = 500)
        mNodes = New Container(Of N)(numberOfNodes)
        mEdges = New Container(Of E)(numberOfEdges)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Graph(Of N, E)" /> class.
    ''' </summary>
    ''' <param name="nodeList">The list of nodes.</param>
    ''' <param name="edgeList">The list of edges.</param>
    Public Sub New(nodeList As IEnumerable(Of N), edgeList As IEnumerable(Of E))
        mNodes = New Container(Of N)(nodeList)
        mEdges = New Container(Of E)(edgeList)
    End Sub

    '''' <summary>
    '''' Initializes a new instance of the <see cref="Graph(Of N, E)" /> class.
    '''' </summary>
    '''' <param name="edgeList">The list of edges.</param>
    'Public Sub New(edgeList As IEnumerable(Of E))
    '    mNodes = New Container(Of N)(100)
    '    mEdges = New Container(Of E)(edgeList)
    '    'TODO: Add nodes from the edges
    'End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets the number of the nodes of the graph
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Public ReadOnly Property NumberNodes As Integer
        Get
            Return mNodes.Count
        End Get
    End Property

    ''' <summary>
    ''' Gets the number of edges of the graph
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Public ReadOnly Property NumberEdges As Integer
        Get
            Return mEdges.Count
        End Get
    End Property

    Public ReadOnly Property Nodes As IEnumerable(Of N)
        Get
            Return mNodes.Data
        End Get
    End Property
#End Region

#Region "On Nodes"
    ''' <summary>
    ''' Get the node with the specific ID
    ''' </summary>
    ''' <param name="indx">The node index</param>
    ''' <returns></returns>
    Public Function GetNode(indx As Integer) As N
        Return mNodes(indx)
    End Function

    ''' <summary>
    ''' Add a node to the graph.
    ''' </summary>
    ''' <param name="node">The node.</param>
    ''' <returns></returns>
    Public Function AddNode(node As N) As Integer
        Return mNodes.Add(node)
    End Function

    ''' <summary>
    ''' Remove a node from the graph
    ''' </summary>
    ''' <param name="indx">The node index.</param>
    ''' <param name="removeZeroDegree"></param>
    ''' <returns></returns>
    Public Function RemoveNode(indx As Integer, Optional removeZeroDegree As Boolean = False) As Boolean
        Dim refNode As N 'The node
        Dim othNode As N
        Dim othIndex As Integer
        Dim refNodeEdges As ICollection(Of Integer) 'The list of edges of this node
        Dim edge As E

        refNode = GetNode(indx) 'Get the node
        refNodeEdges = refNode.Edges 'Get the list of its edges

        'Get the nodes connected to this node and remove the edge from its list
        For Each eIndx In refNodeEdges
            edge = GetEdge(eIndx)
            othIndex = GetOtherNode(eIndx, indx)
            othNode = GetNode(othIndex) ' Get the other node of the edge

            'Remove the edge from the list of both nodes
            refNode.Edges.Remove(eIndx)
            othNode.Edges.Remove(eIndx)

            RemoveEdge(edge) 'Remove the edge from the list of edges

            If removeZeroDegree AndAlso othNode.Degree = 0 Then
                mNodes.RemoveAt(othIndex)
            End If
        Next

        'Remove the node form the node list
        mNodes.RemoveAt(indx)

        'Clean
        refNodeEdges.Clear()

        Return True
    End Function

    ''' <summary>
    ''' Gets the other node.
    ''' </summary>
    ''' <param name="eIndx">The edge index.</param>
    ''' <param name="nIndx">The index of reference node of the edge.</param>
    ''' <returns></returns>
    Public Function GetOtherNode(eIndx As Integer, nIndx As Integer) As Integer
        Dim e As E
        e = GetEdge(eIndx)
        If e.Node1 = nIndx Then
            Return e.Node2
        ElseIf e.Node2 = nIndx Then
            Return e.Node1
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="node"></param>
    ''' <returns></returns>
    Public Function ContainsNode(node As N) As Boolean
        Return mNodes.Contains(node)
    End Function

    Public Function GetNodeIndex(node As N) As Integer
        Return mNodes.GetIndex(node)
    End Function

#End Region

#Region "On Edges"
    ''' <summary>
    ''' Get the edge with the specific ID
    ''' </summary>
    ''' <param name="indx">The edge index</param>
    ''' <returns></returns>
    Public Function GetEdge(indx As Integer) As E
        Return mEdges(indx)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="n1Indx"></param>
    ''' <param name="n2Indx"></param>
    ''' <returns>The edge index that contains the two nodes.</returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function GetEdgeIndex(n1Indx As Integer, n2Indx As Integer) As Integer
        For Each eIndx In GetNode(n1Indx).Edges
            If GetOtherNode(eIndx, n1Indx) = n2Indx Then
                Return eIndx
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Add a edge to the graph.
    ''' </summary>
    ''' <param name="edge">The edge.</param>
    ''' <returns></returns>
    Public Function AddEdge(edge As E) As Integer
        Dim node1 As N
        Dim node2 As N
        Dim indx As Integer
        Try
            node1 = GetNode(edge.Node1)
            node2 = GetNode(edge.Node2)
            'Check if nodes on the edge are in the graph
            If node1 IsNot Nothing AndAlso node2 IsNot Nothing Then
                indx = mEdges.Add(edge) 'Add the edge to the list
                If indx <> -1 Then
                    'Add to the list of each node the edge id
                    node1.Edges.Add(indx)
                    node2.Edges.Add(indx)
                    'Else
                    '    indx = -1
                End If
                Return indx
            Else
                Throw New ArgumentException("Adding edge failed.")
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Removes the edge from the graph
    ''' </summary>
    ''' <param name="edge"></param>
    ''' <param name="removeZeroDegree"></param>
    Public Sub RemoveEdge(edge As E, Optional removeZeroDegree As Boolean = False)
        Dim node1, node2 As N
        Dim edgeIndx As Integer

        Try
            'Get the nodes
            node1 = GetNode(edge.Node1)
            node2 = GetNode(edge.Node2)
            edgeIndx = Connected(edge.Node1, edge.Node2)

            'Remove the edge from the nodes
            node1.Edges.Remove(edgeIndx)
            node2.Edges.Remove(edgeIndx)

            If removeZeroDegree Then
                If node1.Degree = 0 Then
                    RemoveNode(edge.Node1)
                End If
                If node2.Degree = 0 Then
                    RemoveNode(edge.Node2)
                End If
            End If

            'Remove the edge from the list of edges
            mEdges.RemoveAt(edgeIndx)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Removes the edge connecting node1 and node2 from the graph
    ''' </summary>
    ''' <param name="eIndx"></param>
    ''' <param name="removeZeroDegree"></param>
    Public Sub RemoveEdge(eIndx As Integer, Optional removeZeroDegree As Boolean = False)

        Dim node1, node2 As N
        Dim n1Indx, n2Indx As Integer
        Try
            'Get the nodes
            n1Indx = GetEdge(eIndx).Node1
            n2Indx = GetEdge(eIndx).Node2
            node1 = GetNode(n1Indx)
            node2 = GetNode(n2Indx)

            'Remove the edge from the nodes
            node1.Edges.Remove(eIndx)
            node2.Edges.Remove(eIndx)

            If removeZeroDegree Then
                If node1.Degree = 0 Then
                    RemoveNode(n1Indx)
                End If
                If node2.Degree = 0 Then
                    RemoveNode(n2Indx)
                End If
            End If

            'Remove the edge
            mEdges.RemoveAt(eIndx)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edge"></param>
    ''' <returns></returns>
    Public Function ContainsEdge(edge As E) As Boolean
        Return mEdges.Contains(edge)
    End Function

#End Region

#Region "General"
    '''' <summary>
    '''' Check if an edge exists between node1 and node2. If true return the edge, else return nothing
    '''' </summary>
    '''' <param name="node1Indx">The node 1 index.</param>
    '''' <param name="node2Indx">The node 2 index.</param>
    '''' <returns></returns>
    'Public Function Connected(node1Indx As Integer, node2Indx As Integer) As E
    '    Dim node1 As N
    '    Dim node2 As N
    '    Dim resultEdgeList As IEnumerable(Of Integer)

    '    Try
    '        'Get Nodes
    '        node1 = GetNode(node1Indx)
    '        node2 = GetNode(node2Indx)

    '        If node1 IsNot Nothing And node2 IsNot Nothing Then

    '            resultEdgeList = node1.Edges.Intersect(node2.Edges)

    '            If resultEdgeList.Count > 1 Then
    '                Throw New Exception("There are more than one edge connecting these nodes.")
    '            ElseIf resultEdgeList.Count = 0 Then
    '                Return Nothing
    '            Else
    '                Return GetEdge(resultEdgeList(0))
    '            End If

    '        Else
    '            Throw New ArgumentException("At least one of the nodes is not in the graph")
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try

    'End Function

    ''' <summary>
    ''' Check if an edge exists between node1 and node2. If true return the edge, else return nothing
    ''' </summary>
    ''' <param name="node1Indx">The node 1 index.</param>
    ''' <param name="node2Indx">The node 2 index.</param>
    ''' <returns></returns>
    Public Function Connected(node1Indx As Integer, node2Indx As Integer) As Integer
        Dim node1 As N
        Dim node2 As N
        Dim resultEdgeList As IEnumerable(Of Integer)

        Try
            'Get Nodes
            node1 = GetNode(node1Indx)
            node2 = GetNode(node2Indx)

            If node1 IsNot Nothing And node2 IsNot Nothing Then

                resultEdgeList = node1.Edges.Intersect(node2.Edges)

                If resultEdgeList.Count > 1 Then
                    Throw New Exception("There are more than one edge connecting these nodes.")
                ElseIf resultEdgeList.Count = 0 Then
                    Return Nothing
                Else
                    Return resultEdgeList(0)
                End If

            Else
                Throw New ArgumentException("At least one of the nodes is not in the graph")
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' Returns a list of node ids which are at a certain distance
    ''' </summary>
    ''' <param name="nodeIndx">The node index.</param>
    ''' <param name="distance">The distance.</param>
    ''' <returns></returns>
    Public Function GetNodesAtDistance(nodeIndx As Integer, Optional distance As Integer = 1) As List(Of N)

        If distance > 1 Then Throw New NotImplementedException("The function only works with distance equals to one.")

        Dim node As N
        Dim edgeList As IEnumerable(Of Integer)
        Dim resultList As List(Of N)

        Try
            node = GetNode(nodeIndx)
            edgeList = node.Edges
            resultList = New List(Of N)(edgeList.Count)

            For Each eIndx In edgeList
                resultList.Add(GetNode(GetOtherNode(eIndx, nodeIndx)))
            Next

            Return resultList

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Public Function GetSubGraph(nodes As IEnumerable(Of Integer), edges As IEnumerable(Of Integer)) As Graph(Of N, E)
    '    Dim refNode As N
    '    Dim othNode As N
    '    Dim edge As E
    '    Dim othNodeIndx As Integer
    '    Dim retValue As Graph(Of N, E)

    '    Try
    '        'Create the graph to return
    '        retValue = New Graph(Of N, E)()

    '        For Each refNodeIndx In nodes

    '            refNode = GetNode(refNodeIndx)

    '            For Each e In GetNode(refNodeIndx).Edges

    '                edge = GetEdge(e)
    '                othNodeIndx = GetOtherNode(e, refNodeIndx)

    '                If nodes.Contains(othNodeIndx) Then

    '                    othNode = GetNode(othNodeIndx)

    '                    If Not retValue.ContainsNode(refNode) Then
    '                        retValue.AddNode(refNode)
    '                        '                    If Not newNode1.Edges.Contains(e) Then
    '                        '                        newNode1.Edges.Add(e)
    '                        '                    End If
    '                        '                    newNodes.Add(newNode1)
    '                    End If

    '                    If Not retValue.ContainsNode(othNode) Then
    '                        '                    newNode2 = CType(GetNode(n2).DeepClone, N)
    '                        '                    If Not newNode2.Edges.Contains(e) Then
    '                        '                        newNode2.Edges.Add(e)
    '                        '                    End If
    '                        '                    newNodes.Add(newNode2)
    '                    End If

    '                    '                If Not EDs.ContainsKey(edge.EdgeID) Then
    '                    '                    EDs.Add(CType(edge.DeepClone, E))
    '                    '                End If

    '                    '            ElseIf connectedNodes = False Then

    '                    '                newNodes.Add(CType(GetNode(mu1ID).DeepClone, N))

    '                End If

    '            Next

    '            '        If GetNode(mu1ID).Edges.Count = 0 And connectedNodes = False Then
    '            '            NDs.Add(CType(GetNode(mu1ID).DeepClone, N))
    '            '        End If

    '        Next

    '        Return retValue

    '    Catch ex As Exception

    '        Throw New Exception(ex.Message)

    '    End Try
    'End Function

    'Public Function SortNodes(ByVal mus As IEnumerable(Of N)) As IEnumerable(Of N)
    '    Throw New NotImplementedException
    'End Function
#End Region

End Class
