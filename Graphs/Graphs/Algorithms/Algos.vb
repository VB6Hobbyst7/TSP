'Imports Graphs

'Public Class Clustering
Public Enum Algorithms As Byte
    MaximalCliques
    FeasibleClusters
    MinimalInfeasibleClusters
    ConnectedComponents
    Cycles
End Enum

'    Private mTime As Long

'#Region "Constructors"
'    ''' <summary>
'    ''' Initializes a new instance of the <see cref="Clustering" /> class.
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Sub New(ByVal graph As Graph(Of Graphs.Node, IEdge),
'                   ByVal clusterMethod As Method,
'                   Optional ByVal minArea As Double = Double.NegativeInfinity,
'                   Optional ByVal maxArea As Double = Double.PositiveInfinity)

'        Debug.Assert(graph IsNot Nothing, "There is no graph.")
'        Debug.Assert(graph.Nodes.Count > 0, "The graph does not have nodes.")

'        Me.Graph = graph
'        ClusteringMethod = clusterMethod
'        MinimumArea = minArea
'        MaximumArea = maxArea

'        Nodes = New Container(Of Node)(graph.Nodes.Count)
'        Clusters = New Container(Of Cluster)

'        For i = 0 To graph.Nodes.Count - 1
'            Nodes.Add(New Node())
'        Next

'    End Sub
'#End Region

'#Region "Properties"
'    ''' <summary>
'    ''' Gets the graph used to compute clustering methods
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Graph As Graph(Of Graphs.Node, IEdge)

'    ''' <summary>
'    ''' Gets the clustering method
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property ClusteringMethod As Method

'    ''' <summary>
'    ''' Gets the minimum area to be considered in computations.
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property MinimumArea As Double

'    ''' <summary>
'    ''' Gets the maximum area to be considered in computations.
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property MaximumArea As Double

'    ''' <summary>
'    ''' Stores for each node the list of clusters where the node is present.
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Nodes As Container(Of Node)

'    ''' <summary>
'    ''' Stores the clusters found.
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Clusters As Container(Of Cluster)

'    ''' <summary>
'    ''' Gets the number of clusters
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property NumberOfClusters As Integer
'        Get
'            Return Clusters.Count
'        End Get
'    End Property

'    ''' <summary>
'    ''' Stores the time used for computation
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Time As Long
'        Get
'            Return mTime
'        End Get
'    End Property
'#End Region

'#Region "Methods"
'    ''' <summary>
'    ''' Computes the clusters accordingly to the method passed in the constructor
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Sub Compute()
'        Try
'            'OnMessaging(New MessagingEventArgs(String.Format("Computing {0} ...", ClusteringMethod.ToString), True))

'            Select Case ClusteringMethod

'                Case Method.MaximalCliques
'                    ComputeMaximalCliques()
'                Case Method.FeasibleClusters
'                    'ComputeFeasibleClusters()
'                Case Method.MinimalInfeasibleClusters
'                    'ComputeInfeasibleClusters()
'                Case Method.ConnectedComponents
'                    ComputeConnectedComponents()
'                Case Method.Cycles
'                    ComputeCycles()
'            End Select

'            'OnMessaging(New MessagingEventArgs(String.Format("{0} {1} were found in {2} msec.", NumberOfClusters, ClusteringMethod.ToString, Time), True))
'            'OnClustersFound(Me, New EventArgs)

'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'    End Sub

'    ''' <summary>
'    ''' Returns all clusters that contains nd.
'    ''' </summary>
'    ''' <param name="nd">The node.</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function GetClusters(nd As Graphs.Node) As Container(Of Cluster)
'        Dim resultClusters As New Container(Of Cluster)

'        'For Each cID In Nodes(nd.NodeID).Clusters
'        '    resultClusters.Add(mClusters(cID))
'        'Next

'        Return resultClusters
'    End Function

'    ''' <summary>
'    ''' Returns all the clusters intersecting the nds.
'    ''' </summary>
'    ''' <param name="nds">The nodes.</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function GetClusters(ByVal nds As IEnumerable(Of Graphs.Node)) As Container(Of Cluster)
'        Dim resultClusters As New Container(Of Cluster)
'        Dim allClustersID As New HashSet(Of Integer)

'        'For Each nd In nds
'        '    allClustersID.UnionWith(Nodes(nd.NodeID).Clusters)
'        'Next

'        For Each cID In allClustersID
'            resultClusters.Add(Clusters(cID))
'        Next

'        Return resultClusters
'    End Function

'    ''' <summary>
'    ''' Returns all clusters that intersect the given cluster
'    ''' </summary>
'    ''' <param name="refCluster">The reference cluster.</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Function GetAllIntersectingClusters(ByVal refCluster As Cluster) As Container(Of Cluster)
'        Dim resultClusters As New Container(Of Cluster)
'        Dim allClustersID As New HashSet(Of Integer)

'        For i = 0 To refCluster.Nodes.Count - 1
'            allClustersID.UnionWith(Nodes(i).Clusters)
'        Next

'        For Each cID In allClustersID
'            resultClusters.Add(Clusters(cID))
'        Next

'        Return resultClusters
'    End Function

'    ''' <summary>
'    ''' Return the common elements of both sets
'    ''' </summary>
'    ''' <param name="setA"></param>
'    ''' <param name="setB"></param>
'    ''' <returns></returns>
'    ''' <remarks>TODO: if sets to large, sort them and use binary search. Additional parallel also can improve </remarks>
'    Private Shared Function Intersect(ByVal setA As IEnumerable(Of Graphs.Node), ByVal setB As IEnumerable(Of Graphs.Node)) As HashSet(Of Graphs.Node)
'        Return New HashSet(Of Graphs.Node)(setA.Intersect(setB))
'    End Function

'    ''' <summary>
'    ''' Return the union of element with the set.
'    ''' </summary>
'    ''' <param name="setA">The set.</param>
'    ''' <param name="nd">The node.</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Shared Function Union(ByVal setA As IEnumerable(Of Graphs.Node), ByVal nd As Graphs.Node) As HashSet(Of Graphs.Node)
'        Dim result As New HashSet(Of Graphs.Node)(setA)

'        If Not result.Contains(nd) Then
'            result.Add(nd)
'        End If

'        Return result

'    End Function

'    ''' <summary>
'    ''' Return the union of the elements of both sets
'    ''' </summary>
'    ''' <param name="setA"></param>
'    ''' <param name="setB"></param>
'    ''' <returns></returns>
'    ''' <remarks>'TODO: if sets to large, sort them and use binary search. Additional parallel also can improve</remarks>
'    Private Shared Function Union(ByVal setA As IEnumerable(Of Graphs.Node), ByVal setB As IEnumerable(Of Graphs.Node)) As HashSet(Of Graphs.Node)
'        Return New HashSet(Of Graphs.Node)(setA.Union(setB))
'    End Function

'    ''' <summary>
'    ''' Return a cluster containing the neighbors of a given cluster
'    ''' </summary>
'    ''' <param name="nodes"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Private Function GetClusterBorder(ByVal nodes As HashSet(Of Graphs.Node)) As HashSet(Of Graphs.Node)
'        Dim border As New HashSet(Of Graphs.Node)

'        Try
'            'For Each nd In nodes
'            '    border.UnionWith(Graph.GetNodesAtDistance(nd))
'            'Next
'            border.ExceptWith(nodes)

'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'        Return border

'    End Function

'#Region "Maximal Cliques"
'    Private Sub ComputeMaximalCliques()
'        Try

'            Dim myTime As Stopwatch = Stopwatch.StartNew()

'            'Dim setP As New HashSet(Of Graphs.Node)(Graph.Nodes) 'Get the nodes from the graph

'            'ComputeMaximalCliques(New HashSet(Of Graphs.Node), setP, New HashSet(Of Graphs.Node))

'            myTime.Stop()
'            mTime = myTime.ElapsedMilliseconds

'        Catch ex As Exception

'            Throw New Exception(ex.Message)

'        Finally

'        End Try
'    End Sub

'    'Private Sub ComputeMaximalCliques(ByVal setR As HashSet(Of Graphs.Node), ByVal setP As HashSet(Of Graphs.Node), ByVal setX As HashSet(Of Graphs.Node))

'    '    If setP.Count = 0 And setX.Count = 0 And setR.Count >= 1 Then

'    '        Dim l As New List(Of Integer)
'    '        For Each nd In setR
'    '            l.Add(nd.NodeID)
'    '        Next
'    '        Dim c As New Cluster(Graph.GetSubGraph(mClusters.GetValidID, l, False))
'    '        l.Clear()
'    '        l = Nothing

'    '        If mClusters.Add(c) Then 'Report R as maximal clique
'    '            For Each nd In c.Nodes.Values
'    '                Nodes(nd.NodeID).AddCluster(c.GraphID)
'    '            Next
'    '        Else
'    '            c = Nothing
'    '        End If

'    '    Else
'    '        Dim neighbors As HashSet(Of Graphs.Node)
'    '        Dim nodesCopy As New HashSet(Of Graphs.Node)(setP)  'Copy P's nodes for traversal

'    '        For Each mu In nodesCopy 'For each node id in P:

'    '            ' Make graph with just v's neighbors
'    '            neighbors = New HashSet(Of Graphs.Node)(Graph.GetNodesAtDistance(mu))

'    '            ' Move v to X
'    '            setP.Remove(mu)

'    '            ' BronKerbosch(R U {v}, P INTERSECT N(v), X INTERSECT N(v)))
'    '            ComputeMaximalCliques(Union(setR, mu), Intersect(setP, neighbors), Intersect(setX, neighbors))

'    '            setX = Union(setX, mu)

'    '        Next
'    '        nodesCopy = Nothing
'    '        neighbors = Nothing
'    '    End If

'    'End Sub
'#End Region

'#Region "Connected Components"
'    Private Sub ComputeConnectedComponents()

'        Try

'            Dim myTime As Stopwatch = Stopwatch.StartNew()

'            'GetConnectedComponents()

'            myTime.Stop()
'            mTime = myTime.ElapsedMilliseconds

'        Catch ex As Exception

'            Throw New Exception(ex.Message)

'        Finally

'        End Try

'    End Sub

'    'Private Sub GetConnectedComponents()
'    '    Dim controlNodes As New Dictionary(Of Integer, Boolean)(Nodes.Count)
'    '    Dim clusterBorder As HashSet(Of Graphs.Node)

'    '    For Each nd In Graph.Nodes.Values
'    '        controlNodes.Add(nd.NodeID, False)
'    '    Next

'    '    For Each nd1 In Graph.Nodes.Values

'    '        If controlNodes(nd1.NodeID) = False Then

'    '            Dim conComponent As New HashSet(Of Graphs.Node)
'    '            conComponent.Add(nd1)

'    '            clusterBorder = GetClusterBorder(conComponent)
'    '            While clusterBorder.Count <> 0
'    '                For Each nd2 In clusterBorder
'    '                    If Not conComponent.Contains(nd2) Then
'    '                        conComponent.Add(nd2)
'    '                        controlNodes(nd2.NodeID) = True
'    '                    End If
'    '                Next
'    '                clusterBorder.Clear()
'    '                clusterBorder = GetClusterBorder(conComponent)
'    '            End While

'    '            Dim l As New List(Of Integer)
'    '            For Each nd In conComponent
'    '                l.Add(nd.NodeID)
'    '            Next
'    '            mClusters.Add(New Cluster(Graph.GetSubGraph(mClusters.GetValidID, l, False)))
'    '            l.Clear()
'    '            l = Nothing

'    '        End If

'    '    Next

'    '    'Clean
'    '    controlNodes.Clear()
'    '    controlNodes = Nothing

'    'End Sub
'#End Region

'#Region "Circuits"
'    Private Sub ComputeCycles()
'        Try

'            Dim myTime As Stopwatch = Stopwatch.StartNew()

'            'ComputeCycles(Graph.Nodes.Values)

'            'Oriented
'            'Dim setP As New HashSet(Of INode)(Graph.Nodes.Values) 'Get the nodes from the graph
'            'ComputeCycles(New HashSet(Of INode), setP, New HashSet(Of INode))

'            myTime.Stop()
'            mTime = myTime.ElapsedMilliseconds

'        Catch ex As Exception

'            Throw New Exception(ex.Message)

'        Finally

'        End Try
'    End Sub

'    'Private Sub ComputeCycles(ByVal nodes As ICollection(Of Graphs.Node))
'    '    Dim succ As New Dictionary(Of Integer, Dictionary(Of Integer, Boolean))
'    '    Dim ndProc As New Dictionary(Of Integer, Boolean)
'    '    Dim maxSucc As Integer = Integer.MinValue
'    '    Dim temp As Integer
'    '    Dim clyc As List(Of Integer)

'    '    For Each nd In nodes
'    '        temp = nd.Edges.Count
'    '        If temp > maxSucc Then
'    '            maxSucc = temp
'    '        End If
'    '        Dim nxt As New Dictionary(Of Integer, Boolean)
'    '        For Each e In nd.Edges
'    '            nxt.Add(Graph.GetEdge(e).GetOtherNode(nd.NodeID), False)
'    '        Next
'    '        succ.Add(nd.NodeID, nxt)
'    '        ndProc.Add(nd.NodeID, False)
'    '    Next

'    '    Dim i, j, s As Integer
'    '    Dim cycleFound As Boolean
'    '    For Each nd In nodes
'    '        If Not ndProc(nd.NodeID) Then
'    '            cycleFound = False
'    '            clyc = New List(Of Integer)
'    '            i = nodes(i).NodeID
'    '            clyc.Add(i)
'    '            ndProc(nd.NodeID) = True
'    '            s = i
'    '            While j <> i
'    '                For Each j In succ(s).Keys
'    '                    If Not succ(s)(j) And Not ndProc(j) Then
'    '                        clyc.Add(j)
'    '                        ndProc(j) = True
'    '                        succ(s)(j) = True
'    '                        s = j
'    '                        Exit For
'    '                    ElseIf succ(s).Keys.Contains(i) And succ(s)(j) Then
'    '                        cycleFound = True
'    '                        Exit While
'    '                    End If
'    '                Next

'    '            End While

'    '            If cycleFound Then
'    '                Dim c As New Cluster(Graph.GetSubGraph(mClusters.GetValidID, clyc, False))
'    '                Clusters.Add(c)

'    '            End If

'    '        End If
'    '    Next


'    '    Dim neighbors As HashSet(Of Graphs.Node)
'    '    Dim nodesCopy As New HashSet(Of Graphs.Node)(nodes)  'Copy P's nodes for traversal

'    '    For Each mu In nodesCopy 'For each node id in P:

'    '        ' Make graph with just v's neighbors
'    '        neighbors = New HashSet(Of Graphs.Node)(Graph.GetNodesAtDistance(mu))

'    '        ' Move v to X
'    '        nodes.Remove(mu)

'    '    Next
'    '    nodesCopy = Nothing
'    '    neighbors = Nothing

'    'End Sub

'    'Private Sub ComputeCycles(ByVal setR As HashSet(Of Graphs.Node), ByVal setP As HashSet(Of Graphs.Node), ByVal setX As HashSet(Of Graphs.Node))

'    '    If setP.Count = 0 And setX.Count = 0 And setR.Count >= 1 Then

'    '        Dim l As New List(Of Integer)
'    '        For Each nd In setR
'    '            l.Add(nd.NodeID)
'    '        Next
'    '        Dim c As New Cluster(Graph.GetSubGraph(mClusters.GetValidID, l, False))
'    '        l.Clear()
'    '        l = Nothing

'    '        If mClusters.Add(c) Then 'Report R as maximal clique
'    '            For Each nd In c.Nodes.Values
'    '                Nodes(nd.NodeID).AddCluster(c.GraphID)
'    '            Next
'    '        Else
'    '            c = Nothing
'    '        End If

'    '    Else
'    '        Dim neighbors As HashSet(Of Graphs.Node)
'    '        Dim nodesCopy As New HashSet(Of Graphs.Node)(setP)  'Copy P's nodes for traversal

'    '        For Each mu In nodesCopy 'For each node id in P:

'    '            ' Make graph with just v's neighbors
'    '            neighbors = New HashSet(Of Graphs.Node)(Graph.GetNodesAtDistance(mu))

'    '            ' Move v to X
'    '            setP.Remove(mu)

'    '            ' BronKerbosch(R U {v}, P INTERSECT N(v), X INTERSECT N(v)))
'    '            ComputeCycles(Union(setR, mu), Intersect(setP, neighbors), Intersect(setX, neighbors))

'    '            setX = Union(setX, mu)

'    '        Next
'    '        nodesCopy = Nothing
'    '        neighbors = Nothing
'    '    End If

'    'End Sub
'#End Region

'#End Region

'#Region "Inner Classes"
'    Public Class Node

'#Region "Constructors"
'        Public Sub New()
'            Clusters = New HashSet(Of Integer)
'        End Sub
'#End Region

'#Region "Properties"
'        Public ReadOnly Property Clusters As HashSet(Of Integer)
'#End Region

'#Region "Methods"
'        Public Sub AddCluster(id As Integer)
'            If Not Clusters.Contains(id) Then
'                Clusters.Add(id)
'            End If
'        End Sub

'        Public Sub RemoveCluster(id As Integer)
'            If Clusters.Contains(id) Then
'                Clusters.Remove(id)
'            End If
'        End Sub
'#End Region

'    End Class

'    Public Class Cluster
'        Inherits Graph(Of Graphs.Node, IEdge)
'        Implements IEquatable(Of Cluster)

'#Region "Constructors"
'        Public Sub New(g As Graph(Of Graphs.Node, IEdge))
'            MyBase.New()
'        End Sub
'#End Region

'#Region "Methods"
'        'Public Shadows Function Equals(y As NewCluster) As Boolean
'        '    If NumberNodes <> y.NumberNodes Then
'        '        Return False
'        '    ElseIf Math.Abs(TotalShapeArea - y.TotalShapeArea) > 0.000000001 Then
'        '        Return False
'        '    ElseIf Math.Abs(Perimeter - y.Perimeter) > 0.000000001 Then
'        '        Return False
'        '    Else
'        '        Return True
'        '    End If
'        'End Function

'        ''' <summary>
'        ''' 
'        ''' </summary>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Overrides Function ToString() As String
'            'Dim s As String = Nodes.Aggregate("", Function(current, nd) current & String.Format(" {0,5}", nd.NodeID))
'            'Return String.Format("{0,6} {1,6}", Nodes.Count, s)
'        End Function

'        Public Shadows Function Equals(other As Cluster) As Boolean Implements IEquatable(Of Cluster).Equals
'            ' Check for null
'            If other Is Nothing Then Return False

'            ' Compare run-time types.
'            If Not Me.GetType() Is other.GetType() Then Return False

'            ' Check for same reference
'            If ReferenceEquals(Me, other) Then Return True

'            Return Me.Equals(other)
'        End Function
'#End Region

'#End Region

'    End Class

'    '    Public Class NodeCollection
'    '        Inherits Dictionary(Of Integer, Clustering.Node)

'    '#Region "Variables"
'    '        Private mMaxId As Integer
'    '        Private ReadOnly mAvailableIDs As List(Of Integer) 'A list of available IDs
'    '#End Region

'    '#Region "Constructors"
'    '        ''' <summary>
'    '        ''' Initializes a new instance of the <see cref="NodeCollection" /> class.
'    '        ''' </summary>
'    '        Public Sub New()
'    '            MyBase.New()
'    '            mAvailableIDs = New List(Of Integer)
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Initializes a new instance of the <see cref="NodeCollection" /> class.
'    '        ''' </summary>
'    '        Public Sub New(ByVal capacity As Integer)
'    '            MyBase.New(capacity)
'    '            mAvailableIDs = New List(Of Integer)
'    '        End Sub
'    '#End Region

'    '#Region "Methods"
'    '        ''' <summary>
'    '        ''' Adds the specific node.
'    '        ''' </summary>
'    '        ''' <param name="nd">The node.</param>
'    '        Public Shadows Function Add(ByVal nd As Clustering.Node) As Boolean
'    '            Dim k As Integer = nd.ID

'    '            Try
'    '                If Not Keys.Contains(k) Then
'    '                    MyBase.Add(k, nd)
'    '                    If k > mMaxId Then mMaxId = k
'    '                    Return True
'    '                Else
'    '                    Return False
'    '                End If
'    '            Catch ex As Exception
'    '                Throw New Exception(ex.Message)
'    '            End Try

'    '        End Function

'    '        ''' <summary>
'    '        ''' Removes the specific node.
'    '        ''' </summary>
'    '        ''' <param name="nd">The node.</param>
'    '        ''' <remarks></remarks>
'    '        Public Shadows Sub Remove(ByVal nd As Clustering.Node)
'    '            mAvailableIDs.Add(nd.ID)
'    '            MyBase.Remove(nd.ID)
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Clear the container
'    '        ''' </summary>
'    '        ''' <remarks></remarks>
'    '        Public Shadows Sub Clear()
'    '            mMaxId = 0
'    '            mAvailableIDs.Clear()
'    '            MyBase.Clear()
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Returns an available ID
'    '        ''' </summary>
'    '        ''' <returns></returns>
'    '        ''' <remarks></remarks>
'    '        Public Function GetValidID() As Integer
'    '            If mAvailableIDs.Count = 0 Then
'    '                Return mMaxId + 1
'    '            Else
'    '                Dim id As Integer = mAvailableIDs(0)
'    '                mAvailableIDs.RemoveAt(0) 'Remove the id from the list
'    '                Return id
'    '            End If
'    '        End Function
'    '#End Region
'    '    End Class

'    '    Public Class ClusterCollection
'    '        Inherits Dictionary(Of Integer, Clustering.Cluster)

'    '#Region "Variables"
'    '        Private mMaxId As Integer
'    '        Private ReadOnly mAvailableIDs As List(Of Integer) 'A list of available IDs
'    '#End Region

'    '#Region "Constructors"
'    '        ''' <summary>
'    '        ''' Initializes a new instance of the <see cref="ClusterCollection" /> class.
'    '        ''' </summary>
'    '        Public Sub New()
'    '            MyBase.New()
'    '            mAvailableIDs = New List(Of Integer)
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Initializes a new instance of the <see cref="ClusterCollection" /> class.
'    '        ''' </summary>
'    '        Public Sub New(ByVal capacity As Integer)
'    '            MyBase.New(capacity)
'    '            mAvailableIDs = New List(Of Integer)
'    '        End Sub
'    '#End Region

'    '#Region "Methods"
'    '        ''' <summary>
'    '        ''' Adds the specific cluster.
'    '        ''' </summary>
'    '        ''' <param name="g">The cluster.</param>
'    '        Public Shadows Function Add(ByVal g As Clustering.Cluster) As Boolean
'    '            Dim k As Integer = g.GraphID

'    '            Try
'    '                If Not Values.Contains(g) Then
'    '                    MyBase.Add(k, g)
'    '                    If k > mMaxId Then mMaxId = k
'    '                    Return True
'    '                Else
'    '                    Return False
'    '                End If
'    '            Catch ex As Exception
'    '                Throw New Exception(ex.Message)
'    '            End Try

'    '        End Function

'    '        ''' <summary>
'    '        ''' Removes the specific cluster.
'    '        ''' </summary>
'    '        ''' <param name="g">The cluster.</param>
'    '        ''' <remarks></remarks>
'    '        Public Shadows Sub Remove(ByVal g As Clustering.Cluster)
'    '            mAvailableIDs.Add(g.GraphID)
'    '            MyBase.Remove(g.GraphID)
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Clear the container
'    '        ''' </summary>
'    '        ''' <remarks></remarks>
'    '        Public Shadows Sub Clear()
'    '            mMaxId = 0
'    '            mAvailableIDs.Clear()
'    '            MyBase.Clear()
'    '        End Sub

'    '        ''' <summary>
'    '        ''' Returns an available ID
'    '        ''' </summary>
'    '        ''' <returns></returns>
'    '        ''' <remarks></remarks>
'    '        Public Function GetValidID() As Integer
'    '            If mAvailableIDs.Count = 0 Then
'    '                Return mMaxId + 1
'    '            Else
'    '                Dim id As Integer = mAvailableIDs(0)
'    '                mAvailableIDs.RemoveAt(0) 'Remove the id from the list
'    '                Return id
'    '            End If
'    '        End Function
'    '#End Region
'    '    End Class


'#Region "Export"
'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="path"></param>
'    ''' <param name="append"></param>
'    ''' <param name="header"></param>
'    ''' <remarks></remarks>
'    Public Sub ExportClusters(ByVal path As String, ByVal append As Boolean, Optional ByVal header As Boolean = False)
'        Dim w As IO.StreamWriter = Nothing

'        Try
'            w = New IO.StreamWriter(path, append)
'            ExportClusters(w, header)
'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        Finally
'            w.Close()
'        End Try
'    End Sub

'    ''' <summary>
'    ''' 
'    ''' </summary>
'    ''' <param name="w"></param>
'    ''' <param name="header"></param>
'    ''' <remarks></remarks>
'    Public Sub ExportClusters(ByRef w As IO.StreamWriter, Optional ByVal header As Boolean = False)

'        Dim sBuilder As Text.StringBuilder = Nothing

'        Try

'            sBuilder = New Text.StringBuilder
'            'Header
'            If header Then
'                sBuilder.AppendLine(String.Format("Date: {0}", Now.ToShortDateString))
'                sBuilder.AppendLine(String.Format("Cluster Type: {0}", ClusteringMethod.ToString))
'                sBuilder.AppendLine(String.Format("File Version: {0}", My.Application.Info.Version.ToString))
'                sBuilder.AppendLine(String.Format("File Format: {0}", 0))
'                sBuilder.AppendLine()
'            End If
'            sBuilder.AppendLine(String.Format("No Clusters: {0}", Clusters.Count))
'            sBuilder.AppendLine(String.Format("{0,6} {1,6} {2,5}", "ID", "NoNode", "Nodes"))

'            'For Each ic In mClusters.Values

'            '    sBuilder.AppendLine(ic.ToString)

'            'Next
'            w.Write(sBuilder.ToString)

'        Catch ex As Exception

'            Throw New Exception(ex.Message)

'        Finally

'            sBuilder.Clear()

'        End Try
'    End Sub
'#End Region

'End Class
