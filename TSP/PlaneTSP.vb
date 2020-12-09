Imports graphs
Imports PlaneGeometry
Public Class PlaneTSP

    Dim mConvexHulls As List(Of ConvexHull)
    Dim mSpanningTree As EdgeContainer
    Dim mHullsSpanningTrees As Dictionary(Of String, EdgeContainer)
    Dim mConnectedComponents As List(Of List(Of Integer))
    Dim mSolution As EdgeContainer
    Dim mOptimalTour As EdgeContainer

    Dim mCentroid As NodeTSP
    Dim mPointsMagnitude As Integer

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="addEdges"></param>
    Public Sub New(path As String, addEdges As Boolean)
        Graph = Load(path, addEdges)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Graph As Graph(Of Node(Of NodeTSP), Edge(Of EdgeTSP))

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConvexHulls As List(Of ConvexHull)
        Get
            Return mConvexHulls : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property SpanningTree As EdgeContainer
        Get
            Return mSpanningTree : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property HullsSpanningTrees As Dictionary(Of String, EdgeContainer)
        Get
            Return mHullsSpanningTrees : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConnectedCompnents As List(Of List(Of Integer))
        Get
            Return mConnectedComponents : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Solution As EdgeContainer
        Get
            Return mSolution : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Centroid As NodeTSP
        Get
            Return mCentroid : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property EliminatedEdges As Integer()
#End Region

#Region "Methods"

#Region "IO"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="addAllEdges"></param>
    ''' <returns></returns>
    Private Function Load(path As String, Optional addAllEdges As Boolean = False) As Graph(Of Node(Of NodeTSP), Edge(Of EdgeTSP))

        Dim r As IO.StreamReader = Nothing
        Dim line As String
        Dim data() As String
        Dim numNodes As Integer
        Dim node As Node(Of NodeTSP)
        Dim b As Boolean
        Dim sumX, sumY As Single
        ReDim Limits(3)

        Dim minX, maxX, minY, maxY As Single

        Dim retValue As Graph(Of Node(Of NodeTSP), Edge(Of EdgeTSP)) = Nothing

        Try
            minX = Single.MaxValue
            maxX = Single.MinValue
            minY = Single.MaxValue
            maxY = Single.MinValue

            r = New IO.StreamReader(path)
            While r.Peek <> -1
                line = r.ReadLine
                data = line.Split({" "c, ":"c, ChrW(34), vbTab}, StringSplitOptions.RemoveEmptyEntries)
                If data(0) = "DIMENSION" Then
                    'data = line.Split({" "c, ":"c, ChrW(34)}, StringSplitOptions.RemoveEmptyEntries)
                    numNodes = CInt(data(1))
                    If addAllEdges Then
                        retValue = New Graph(Of Node(Of NodeTSP), Edge(Of EdgeTSP))(numNodes, (numNodes * (numNodes - 1) \ 2))
                    Else
                        retValue = New Graph(Of Node(Of NodeTSP), Edge(Of EdgeTSP))(numNodes, CInt(0.2 * (numNodes * (numNodes - 1) \ 2)))
                    End If
                ElseIf data(0) = "EOF" Then
                    Exit While
                ElseIf b Then
                    'data = line.Split({" "c, ChrW(34), vbTab}, StringSplitOptions.RemoveEmptyEntries)
                    node = New Node(Of NodeTSP)(New NodeTSP(CSng(data(1)), CSng(data(2))))
                    sumX += node.Attributes.X
                    sumY += node.Attributes.Y
                    retValue.AddNode(node)

                    If node.Attributes.X < minX Then
                        minX = node.Attributes.X
                    End If
                    If node.Attributes.X > maxX Then
                        maxX = node.Attributes.X
                    End If

                    If node.Attributes.Y < minY Then
                        minY = node.Attributes.Y
                    End If
                    If node.Attributes.Y > maxY Then
                        maxY = node.Attributes.Y
                    End If

                ElseIf line.StartsWith("NODE_COORD_SECTION") OrElse line.StartsWith("DISPLAY_DATA_SECTION") Then
                    b = True
                End If
            End While

            'Add edges
            If addAllEdges Then
                For i = 0 To retValue.NumberNodes - 2
                    For j = i + 1 To retValue.NumberNodes - 1
                        retValue.AddEdge(New Edge(Of EdgeTSP)(i, j, New EdgeTSP()))
                    Next
                Next
            End If

            'Compute centroid
            mCentroid = New NodeTSP(sumX / retValue.NumberNodes, sumY / retValue.NumberNodes)

            'Update range
            Limits(0) = minX
            Limits(1) = maxX
            Limits(2) = minY
            Limits(3) = maxY

            Dim digits As Integer = CInt(Math.Log10(Limits.Max(Function(i) Math.Abs(i))))
            mPointsMagnitude = CInt(Math.Max(10 ^ (digits - 1), 1))

            Return retValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            r.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Sub LoadTour(path As String)

        Dim r As IO.StreamReader = Nothing
        Dim line As String
        Dim data() As String
        Dim nIndx As Integer
        Dim eIndx As Integer
        Dim nodes As List(Of Integer)
        Dim edge As Edge(Of EdgeTSP)
        Dim d As Single
        Dim b As Boolean

        Try
            mOptimalTour = New EdgeContainer
            nodes = New List(Of Integer)(Graph.NumberNodes)

            r = New IO.StreamReader(path)
            While r.Peek <> -1
                line = r.ReadLine
                data = line.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

                If line.StartsWith("EOF") Then
                    Exit While
                ElseIf b Then
                    For i = 0 To data.Length - 1
                        nIndx = CInt(data(i))
                        If nIndx < 0 Then
                            nIndx = Math.Abs(nIndx)
                        End If
                        nodes.Add(nIndx - 1)
                    Next
                ElseIf line.StartsWith("TOUR_SECTION") Then
                    b = True
                End If

            End While

            For i = 0 To nodes.Count - 2
                eIndx = Graph.GetEdgeIndex(nodes(i), nodes(i + 1))
                edge = Graph.GetEdge(eIndx)
                edge.Attributes.IsTour = True
                d = Distance(Graph.GetNode(edge.Node1).Attributes, Graph.GetNode(edge.Node2).Attributes)
                mOptimalTour.AddEdge(eIndx, d)
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If r IsNot Nothing Then r.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    Public Sub SaveTour(path As String)
        Dim w As IO.StreamWriter = Nothing
        Dim nodes As List(Of Integer)

        Try
            w = New IO.StreamWriter(path)
            w.WriteLine("NAME: {0}", IO.Path.GetFileNameWithoutExtension(path))
            w.WriteLine("COMMENT: Length {0}", mSolution.Value)
            w.WriteLine("TYPE:   TOUR")
            w.WriteLine("DIMENSION: {0}", Graph.NumberNodes)
            w.WriteLine("TOUR_SECTION")

            nodes = mConnectedComponents(0)
            For i = 0 To nodes.Count - 1
                w.WriteLine("{0}", nodes(i) + 1)
            Next
            w.WriteLine("-{0}", nodes(0) + 1)
            w.WriteLine("EOF")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If w IsNot Nothing Then w.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    Public Sub WriteLP(path As String)
        Dim w As New IO.StreamWriter(path)
        Dim e As Edge
        Dim n1, n2 As Node(Of NodeTSP)
        Dim d As Double
        Dim eIndx As Integer

        w.WriteLine("Minimize")

        w.Write("COST: ")
        For i = 0 To Graph.NumberEdges - 1
            e = Graph.GetEdge(i)
            If e.Active Then
                n1 = Graph.GetNode(e.Node1)
                n2 = Graph.GetNode(e.Node2)
                d = New Segment(n1.Attributes, n2.Attributes).Length
                w.Write(" + {0} X.{1}.{2}", d, e.Node1 + 1, e.Node2 + 1)
            End If
        Next
        w.WriteLine()
        w.WriteLine("Subject To")
        For i = 0 To Graph.NumberNodes - 1
            n1 = Graph.GetNode(i)
            w.Write("N{0}:", i + 1)
            For j = 0 To n1.Degree - 1
                eIndx = n1.Edges(j)
                e = Graph.GetEdge(eIndx)
                If e.Active Then
                    w.Write(" + X.{0}.{1}", e.Node1 + 1, e.Node2 + 1)
                End If
            Next
            w.WriteLine(" = 2")
        Next
        w.WriteLine()

        If mConnectedComponents IsNot Nothing Then
            For Each cc In mConnectedComponents
                For i = 0 To cc.Count - 2
                    For j = i + 1 To cc.Count - 1
                        eIndx = Graph.GetEdgeIndex(cc(i), cc(j))
                        e = Graph.GetEdge(eIndx)
                        If e.Active Then
                            w.Write(" + X.{0}.{1}", e.Node1 + 1, e.Node2 + 1)
                        End If
                    Next
                Next
                w.WriteLine(" <= {0}", cc.Count - 1)
            Next
        End If

        w.WriteLine("BIN")
        For i = 0 To Graph.NumberEdges - 1
            e = Graph.GetEdge(i)
            If e.Active Then
                w.Write(" X.{0}.{1}", e.Node1 + 1, e.Node2 + 1)
            End If
        Next
        w.WriteLine()
        w.WriteLine("END")
        w.Dispose()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path"></param>
    Public Sub ReadSolution(path As String)

        Dim r As New IO.StreamReader(path)
        Dim s As String
        Dim tokens() As String
        Dim cnt As Integer
        Dim eIndx As Integer
        Dim n1, n2 As Integer
        mSolution = New EdgeContainer()

        While r.Peek <> -1
            s = r.ReadLine()
            If s.StartsWith("  <variable") Then
                tokens = s.Split({" "c, "/"c, "="c, "<"c, ">"c, ChrW(34)}, StringSplitOptions.RemoveEmptyEntries)

                If CDbl(tokens(6)) > 0.99 Then
                    tokens = tokens(2).Split({"."c})
                    n1 = CInt(tokens(1)) : n2 = CInt(tokens(2))
                    eIndx = Graph.GetEdgeIndex(n1 - 1, n2 - 1)
                    Graph.GetEdge(eIndx).Attributes.IsSolution = True
                    mSolution.AddEdge(eIndx, Distance(Graph.GetNode(n1 - 1).Attributes, Graph.GetNode(n2 - 1).Attributes))
                    cnt += 1
                End If
            End If

        End While
        ' add fixed edges
        'Dim fObjValue As Double
        'Dim fEdges As Integer(,) = {{0, 1}, {1, 2}, {2, 7}, {9, 11}, {11, 12}, {13, 14}, {15, 17}, {16, 17}, {34, 35}, {35, 37}, {36, 37}, {36, 38}, {38, 39}, {39, 40}}
        'Dim fEdges As Integer(,) = {{0, 1}, {1, 2}, {2, 7}, {7, 8}, {8, 9}, {9, 11}, {11, 12}, {13, 14}, {15, 17}, {16, 17}, {34, 35}, {35, 37}, {36, 37}, {36, 38}, {38, 39}, {39, 40}}
        'For i = 0 To fEdges.GetUpperBound(0)
        'eIndx = Graph.GetEdgeIndex(fEdges(i, 0), fEdges(i, 1))
        'fObjValue += Distance(Graph.GetNode(fEdges(i, 0)).Attributes, Graph.GetNode(fEdges(i, 1)).Attributes)
        'SolutionEdges(cnt) = eIndx
        'cnt += 1
        'Next

        'Console.WriteLine("Objective: {0}", ObjValue + fObjValue)
        r.Dispose()

    End Sub
#End Region

#Region "Algorithms"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="withBoundary"></param>
    Public Sub ComputeConvexHulls(withBoundary As Boolean)
        Dim points As List(Of Point)
        Dim hull As List(Of Point)
        Dim nd As Node(Of NodeTSP)
        Dim hullNodes As Integer()
        Dim hullEdges As Integer()
        Dim nIndx As Integer
        Dim eIndx As Integer
        Dim hIndx As Integer
        Dim size As Integer

        Try
            points = New List(Of Point)(Graph.NumberNodes)
            For i = 0 To Graph.NumberNodes - 1
                points.Add(Graph.GetNode(i).Attributes)
            Next

            mConvexHulls = New List(Of ConvexHull)

            While points.Count > 0
                hull = Functions.ConvexHull(points, withBoundary)
                ReDim hullNodes(hull.Count - 1)

                'Nodes
                For i = 0 To hull.Count - 1
                    nd = New Node(Of NodeTSP)(New NodeTSP(hull(i).X, hull(i).Y))
                    nIndx = Graph.GetNodeIndex(nd)
                    hullNodes(i) = nIndx
                    points.Remove(hull(i))
                    Graph.GetNode(nIndx).Attributes.ConvexHull = hIndx
                Next

                'Edges
                size = hullNodes.Count
                If size > 2 Then

                    ReDim hullEdges(size - 1)
                    For j = 0 To size - 2
                        eIndx = Graph.GetEdgeIndex(hullNodes(j), hullNodes(j + 1))
                        hullEdges(j) = eIndx
                        Graph.GetEdge(eIndx).Attributes.IsConvexHull = True
                    Next
                    'last edge - between first and last nodes
                    eIndx = Graph.GetEdgeIndex(hullNodes(size - 1), hullNodes(0))
                    hullEdges(size - 1) = eIndx
                    Graph.GetEdge(eIndx).Attributes.IsConvexHull = True

                ElseIf size = 2 Then 'only one edge

                    ReDim hullEdges(0)
                    eIndx = Graph.GetEdgeIndex(hullNodes(size - 1), hullNodes(0))
                    hullEdges(0) = eIndx
                    Graph.GetEdge(eIndx).Attributes.IsConvexHull = True

                Else
                    hullEdges = {} 'no edge. single point
                End If

                mConvexHulls.Add(New ConvexHull(hullNodes, hullEdges))
                hIndx += 1
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="withAlternativeEdges"></param>
    Public Sub ComputeSpanningTree(withAlternativeEdges As Boolean)
        Dim nodes As List(Of Point)
        Dim MST As Integer()
        Dim eIndx As Integer
        Dim MSTValue As Single

        nodes = New List(Of Point)(Graph.NumberNodes)
        For i = 0 To Graph.NumberNodes - 1
            nodes.Add(Graph.GetNode(i).Attributes)
        Next

        'Generate first MST
        mSpanningTree = New EdgeContainer
        MST = Prim(nodes)
        For i = 0 To MST.Count - 1
            If MST(i) >= 0 Then
                eIndx = Graph.GetEdgeIndex(i, MST(i))
                Graph.GetEdge(eIndx).Attributes.IsSpanningEdge = True
                mSpanningTree.AddEdge(eIndx, Distance(Graph.GetNode(i).Attributes, Graph.GetNode(MST(i)).Attributes))
            End If
        Next
        MSTValue = mSpanningTree.Value

        If withAlternativeEdges Then
            Dim edge, newEdge As Edge(Of EdgeTSP)
            Dim cutValue As Single
            Dim set1 As List(Of Integer)
            Dim set2 As List(Of Integer)
            Dim family As Dictionary(Of Integer, List(Of Integer))
            Dim parent, child As Integer
            Dim pt1, pt2 As Point
            Dim weight As Single

            'Generate family tree
            family = New Dictionary(Of Integer, List(Of Integer))
            For child = 0 To MST.Count - 1
                parent = MST(child)
                If parent <> -1 Then
                    If Not family.ContainsKey(parent) Then
                        family.Add(parent, New List(Of Integer))
                        family(parent).Add(child)
                    Else
                        family(parent).Add(child)
                    End If
                End If
            Next

            'Generate Partitions
            For i = 1 To MST.Count - 1
                set1 = New List(Of Integer)
                set2 = New List(Of Integer)

                edge = Graph.GetEdge(Graph.GetEdgeIndex(i, MST(i)))
                cutValue = Distance(nodes(edge.Node1), nodes(edge.Node2))

                'Generate set1
                set1.Add(i)
                If family.ContainsKey(i) Then
                    Dim explore As New List(Of Integer)
                    Dim ref As Integer
                    For Each sibling In family(i)
                        explore.Add(sibling)
                    Next
                    While explore.Count > 0
                        ref = explore(0)
                        If family.ContainsKey(ref) Then
                            For Each sibling In family(ref)
                                explore.Add(sibling)
                            Next
                        End If
                        set1.Add(ref)
                        explore.RemoveAt(0)
                    End While
                End If

                'Generate set2
                For j = 0 To nodes.Count - 1
                    If Not set1.Contains(j) Then
                        set2.Add(j)
                    End If
                Next

                'Search
                If set1.Count <= set2.Count Then
                    For Each n1 In set1
                        pt1 = Graph.GetNode(n1).Attributes
                        For Each n2 In set2
                            pt2 = Graph.GetNode(n2).Attributes

                            If Math.Min(n1, n2) <> edge.Node1 OrElse Math.Max(n1, n2) <> edge.Node2 Then
                                weight = Distance(pt1, pt2)
                                If weight = cutValue Then
                                    eIndx = Graph.GetEdgeIndex(n1, n2)
                                    newEdge = Graph.GetEdge(eIndx)
                                    newEdge.Attributes.IsSpanningEdge = True
                                    mSpanningTree.AddEdge(eIndx, weight)
                                    edge.Attributes.HasAlternative = True
                                    newEdge.Attributes.HasAlternative = True
                                End If
                            End If

                        Next
                    Next
                Else
                    For Each n2 In set2
                        pt2 = Graph.GetNode(n2).Attributes
                        For Each n1 In set1
                            pt1 = Graph.GetNode(n1).Attributes

                            If Math.Min(n1, n2) <> edge.Node1 OrElse Math.Max(n1, n2) <> edge.Node2 Then
                                weight = Distance(pt1, pt2)
                                If weight = cutValue Then
                                    eIndx = Graph.GetEdgeIndex(n1, n2)
                                    newEdge = Graph.GetEdge(eIndx)
                                    newEdge.Attributes.IsSpanningEdge = True
                                    mSpanningTree.AddEdge(eIndx, weight)
                                    edge.Attributes.HasAlternative = True
                                    newEdge.Attributes.HasAlternative = True
                                End If
                            End If

                        Next
                    Next
                End If
            Next
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="withAlternativeEdges"></param>
    Public Sub ComputeHullsSpanningTrees(withAlternativeEdges As Boolean)

        Dim points As List(Of Point)
        Dim iHull, oHull As ConvexHull
        Dim eIndx As Integer
        Dim spanTree As EdgeContainer
        Dim MST As Integer()
        Dim MSTValue As Single
        Dim translate As Dictionary(Of Integer, Integer)
        Dim cnt As Integer

        mHullsSpanningTrees = New Dictionary(Of String, EdgeContainer)

        For i = 0 To mConvexHulls.Count - 2
            oHull = ConvexHulls(i)
            For j = i + 1 To mConvexHulls.Count - 1
                iHull = ConvexHulls(j)

                cnt = 0
                points = New List(Of Point)(oHull.NumberNodes + iHull.NumberNodes)
                translate = New Dictionary(Of Integer, Integer)(oHull.NumberNodes + iHull.NumberNodes)

                For k = 0 To oHull.NumberNodes - 1
                    points.Add(Graph.GetNode(oHull.Nodes(k)).Attributes)
                    translate.Add(cnt, oHull.Nodes(k))
                    cnt += 1
                Next
                For k = 0 To iHull.NumberNodes - 1
                    points.Add(Graph.GetNode(iHull.Nodes(k)).Attributes)
                    translate.Add(cnt, iHull.Nodes(k))
                    cnt += 1
                Next

                'Generate first MST
                spanTree = New EdgeContainer()
                MST = Prim(points)
                For k = 0 To MST.Count - 1
                    If MST(k) >= 0 Then
                        eIndx = Graph.GetEdgeIndex(translate(k), translate(MST(k)))
                        Graph.GetEdge(eIndx).Attributes.IsHullSpanningEdge = True
                        spanTree.AddEdge(eIndx, Distance(Graph.GetNode(translate(k)).Attributes, Graph.GetNode(translate(MST(k))).Attributes))
                    End If
                Next
                MSTValue = spanTree.Value

                mHullsSpanningTrees.Add(String.Format("{0}-{1}", i, j), spanTree)
            Next
        Next


        Dim tEdge, iEdge As Edge(Of EdgeTSP)
        Dim tPt1, tPt2, iPt1, iPt2 As NodeTSP
        Dim tSegment, iSegment As Segment
        Dim tDistance, iDistance As Single
        Dim intersect As Integer
        For Each tSpanTree In mHullsSpanningTrees.Values
            For i = 0 To tSpanTree.Count - 1
                tEdge = Graph.GetEdge(tSpanTree.GetEdge(i))
                tPt1 = Graph.GetNode(tEdge.Node1).Attributes
                tPt2 = Graph.GetNode(tEdge.Node2).Attributes
                tSegment = New Segment(tPt1, tPt2)
                tDistance = tSegment.Length

                For Each iSpanTree In mHullsSpanningTrees.Values
                    For j = 0 To iSpanTree.Count - 1
                        iEdge = Graph.GetEdge(iSpanTree.GetEdge(j))
                        iPt1 = Graph.GetNode(iEdge.Node1).Attributes
                        iPt2 = Graph.GetNode(iEdge.Node2).Attributes
                        iSegment = New Segment(iPt1, iPt2)
                        iDistance = iSegment.Length

                        If (Not tPt1.Equals(iPt1) AndAlso Not tPt2.Equals(iPt2)) AndAlso
                            (Not tPt1.Equals(iPt2) AndAlso Not tPt2.Equals(iPt1)) Then

                            intersect = Intersect_2Segments(tSegment, iSegment, Nothing, Nothing)
                            If intersect <> 0 Then
                                If tSegment.Length > iSegment.Length Then
                                    tEdge.Attributes.IsCrossingHullSpanningEdge = True
                                    tEdge.Active = False
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    If Not tEdge.Active Then Exit For
                Next
            Next
        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub ComputeCycles()
        mConnectedComponents = New List(Of List(Of Integer))
        Dim connectedNodes As List(Of Integer)
        Dim exploredEdges As New List(Of Integer)
        Dim firstNode, currentNode, currentEdge As Integer
        Dim candidaNode As Integer
        Try
            If mSolution Is Nothing Then Exit Sub

            For i = 0 To mSolution.Count - 1
                currentEdge = mSolution.GetEdge(i)

                If Not exploredEdges.Contains(currentEdge) Then

                    connectedNodes = New List(Of Integer)
                    firstNode = Graph.GetEdge(currentEdge).Node1
                    candidaNode = Graph.GetEdge(currentEdge).Node2
                    exploredEdges.Add(currentEdge)
                    connectedNodes.Add(firstNode)

                    While candidaNode <> firstNode

                        currentNode = candidaNode
                        For Each edg In Graph.GetNode(currentNode).Edges
                            If edg <> currentEdge AndAlso Solution.ContainsEdge(edg) Then
                                currentEdge = edg
                                candidaNode = Graph.GetOtherNode(currentEdge, currentNode)
                                exploredEdges.Add(currentEdge)
                                connectedNodes.Add(currentNode)
                                Exit For
                            End If
                        Next
                    End While
                    mConnectedComponents.Add(connectedNodes)
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
#End Region

#Region "Edge Elimination"
    Public Sub RunEdgeElimination()
        ReDim EliminatedEdges(8)

        'Parallel.For(0, Graph.NumberEdges, Sub(i)
        '                                       Dim edge As Edge(Of EdgeTSP)
        '                                       edge = Graph.GetEdge(i)
        '                                       If Not edge.Attributes.IsConvexHull Then
        '                                           IntersectOwnHull(edge)
        '                                       ElseIf edge.Attributes.IsInsideConvexHull Then
        '                                           InsideHullElimination(edge)
        '                                       ElseIf edge.Attributes.IsHullSpanningEdge Then
        '                                           IntersectHullSpanningEdge(edge)
        '                                       ElseIf edge.Attributes.IsConvexHull Then
        '                                           'ConvexHullElimination(edge)
        '                                       Else
        '                                           IntersectHullSpanningEdge(edge)
        '                                       End If
        '                                   End Sub)

        Dim edge As Edge(Of EdgeTSP)
        For i = 0 To Graph.NumberEdges - 1
            edge = Graph.GetEdge(i)

            If edge.Attributes.IsOverConvexHull Then
                IntersectOwnHull(edge)
                IntersectHullSpanningEdge(edge)
            ElseIf edge.Attributes.IsInsideConvexHull Then
                InsideHullElimination(edge)
                IntersectHullSpanningEdge(edge)
            ElseIf edge.Attributes.IsHullSpanningEdge Then
                'IntersectHullSpanningEdge(edge)
            ElseIf edge.Attributes.IsConvexHull Then
                'ConvexHullElimination(edge)
                IntersectHullSpanningEdge(edge)
            Else
                IntersectHullSpanningEdge(edge)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub ClassifyEdges()
        Dim edg As Edge(Of EdgeTSP)
        Dim nd1, nd2 As NodeTSP
        Dim temp As Integer

        If mConvexHulls Is Nothing Then Exit Sub

        For i = 0 To Graph.NumberEdges - 1
            edg = Graph.GetEdge(i)
            nd1 = Graph.GetNode(edg.Node1).Attributes
            nd2 = Graph.GetNode(edg.Node2).Attributes
            If Not edg.Attributes.IsConvexHull Then
                temp = Math.Abs(nd1.ConvexHull - nd2.ConvexHull)
                If temp = 0 Then
                    edg.Attributes.IsInsideConvexHull = True
                ElseIf temp = 1 Then
                    edg.Attributes.IsBetweenConvexHulls = True
                Else
                    edg.Attributes.IsOverConvexHull = True
                End If
                'Else 'edg is convex hull
            End If
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edge"></param>
    Private Sub InsideHullElimination(edge As Edge(Of EdgeTSP))
        edge.Active = False
        EliminatedEdges(0) += 1
    End Sub

    ''' <summary>
    ''' Test for intersecting own convex hull
    ''' </summary>
    ''' <param name="edge"></param>
    Private Sub IntersectOwnHull(edge As Edge(Of EdgeTSP))
        Dim innerHull, outerHull As ConvexHull
        Dim iEdge As Edge(Of EdgeTSP)
        Dim tPt1, tPt2, iPt1, iPt2, iPt As NodeTSP
        Dim tSegment, iSegment As Segment
        Dim tDistance, iDistance As Single
        Dim intersect As Integer
        Dim intersectPoint1 As Point

        tPt1 = Graph.GetNode(edge.Node1).Attributes
        tPt2 = Graph.GetNode(edge.Node2).Attributes
        tSegment = New Segment(tPt1, tPt2)
        tDistance = tSegment.Length

        If tPt1.ConvexHull < tPt2.ConvexHull Then
            innerHull = ConvexHulls(tPt2.ConvexHull)
            outerHull = ConvexHulls(tPt1.ConvexHull)
            iPt = tPt2
        Else
            innerHull = ConvexHulls(tPt1.ConvexHull)
            outerHull = ConvexHulls(tPt2.ConvexHull)
            iPt = tPt1
        End If

        If innerHull.Edges IsNot Nothing Then
            For Each iEdgeIndx In innerHull.Edges
                iEdge = Graph.GetEdge(iEdgeIndx)
                iPt1 = Graph.GetNode(iEdge.Node1).Attributes
                iPt2 = Graph.GetNode(iEdge.Node2).Attributes
                iSegment = New Segment(iPt1, iPt2)
                iDistance = iSegment.Length

                intersectPoint1 = Nothing
                'inner hull edge do not contain the inner node
                If Not iPt.Equals(iPt1) AndAlso Not iPt.Equals(iPt2) Then
                    intersect = Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing)
                    If intersect <> 0 Then
                        If Not intersectPoint1.Equals(iPt1) AndAlso
                            Not intersectPoint1.Equals(iPt2) AndAlso
                            tDistance > iDistance Then

                            edge.Attributes.IsIntersectOwnConvexHull = True
                            edge.Active = False
                            EliminatedEdges(1) += 1
                            Exit Sub
                        End If
                    End If
                End If

            Next
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edge"></param>
    Private Sub ConvexHullElimination(edge As Edge(Of EdgeTSP))
        Dim iEdge As Edge(Of EdgeTSP)
        Dim iSegment As Segment
        Dim pt1, pt2 As NodeTSP
        Dim tSegment As Segment
        Dim intersectPoint1 As Point

        pt1 = Graph.GetNode(edge.Node1).Attributes
        pt2 = Graph.GetNode(edge.Node2).Attributes
        tSegment = New Segment(pt1, pt2)

        ' test for intersecting spanning tree
        For stIndx = 0 To SpanningTree.Count - 1
            iEdge = Graph.GetEdge(SpanningTree.GetEdge(stIndx))

            If Not edge.Node1.Equals(iEdge.Node1) AndAlso
            Not edge.Node1.Equals(iEdge.Node2) AndAlso
            Not edge.Node2.Equals(iEdge.Node1) AndAlso
            Not edge.Node2.Equals(iEdge.Node2) Then

                iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                intersectPoint1 = Nothing
                If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                    If intersectPoint1 IsNot Nothing Then
                        edge.Attributes.IsCrossingSpanningEdge = True
                        edge.Active = False
                        EliminatedEdges(2) += 1
                        Exit Sub
                    End If
                End If

            End If
        Next

        ' test for intersecting expand spanning tree
        Dim eST As EdgeContainer
        For Each eST In mHullsSpanningTrees.Values
            'eST = mExpandSpanningTrees(i)
            For stIndx = 0 To eST.Count - 1
                iEdge = Graph.GetEdge(eST.GetEdge(stIndx))

                If Not edge.Node1.Equals(iEdge.Node1) AndAlso
                Not edge.Node1.Equals(iEdge.Node2) AndAlso
                Not edge.Node2.Equals(iEdge.Node1) AndAlso
                Not edge.Node2.Equals(iEdge.Node2) Then

                    iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                    intersectPoint1 = Nothing
                    If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                        If intersectPoint1 IsNot Nothing Then
                            edge.Attributes.IsCrossingSpanningEdge = True
                            edge.Active = False
                            EliminatedEdges(2) += 1
                            Exit Sub
                        End If
                    End If

                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="edge"></param>
    Private Sub IntersectHullSpanningEdge(edge As Edge(Of EdgeTSP))
        Dim iEdge As Edge(Of EdgeTSP)
        Dim tPt1, tPt2, iPt1, iPt2 As NodeTSP
        Dim tSegment, iSegment As Segment
        Dim tDistance, iDistance As Single
        Dim intersect As Integer

        tPt1 = Graph.GetNode(edge.Node1).Attributes
        tPt2 = Graph.GetNode(edge.Node2).Attributes
        tSegment = New Segment(tPt1, tPt2)
        tDistance = tSegment.Length

        For Each iSpanTree In mHullsSpanningTrees.Values
            For j = 0 To iSpanTree.Count - 1
                iEdge = Graph.GetEdge(iSpanTree.GetEdge(j))
                iPt1 = Graph.GetNode(iEdge.Node1).Attributes
                iPt2 = Graph.GetNode(iEdge.Node2).Attributes
                iSegment = New Segment(iPt1, iPt2)
                iDistance = iSegment.Length

                If (Not tPt1.Equals(iPt1) AndAlso Not tPt2.Equals(iPt2)) AndAlso
                            (Not tPt1.Equals(iPt2) AndAlso Not tPt2.Equals(iPt1)) Then

                    intersect = Intersect_2Segments(tSegment, iSegment, Nothing, Nothing)
                    If intersect <> 0 Then
                        If tSegment.Length > iSegment.Length Then
                            edge.Attributes.IsCrossingHullSpanningEdge = True
                            edge.Active = False
                            Exit Sub
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub TestElimination()
        Dim e As Edge(Of EdgeTSP)

        If mOptimalTour Is Nothing Then Exit Sub

        For i = 0 To Graph.NumberEdges - 1
            e = Graph.GetEdge(i)
            If Not e.Active AndAlso e.Attributes.IsTour Then
                e.Attributes.IsWrongElimination = True
            End If
        Next
    End Sub
#End Region

#End Region

#Region "Drawing"
    Private Property Limits As Single()

    Public Function WidthRange() As Single
        Return (Limits(1) - Limits(0)) / mPointsMagnitude
    End Function

    Public Function HeightRange() As Single
        Return (Limits(3) - Limits(2)) / mPointsMagnitude
    End Function

    Public Function RefCorner() As NodeTSP
        Return New NodeTSP(Limits(0), Limits(2))
    End Function

    Public ReadOnly Property PointMagnitude As Integer
        Get
            Return mPointsMagnitude : End Get
    End Property
#End Region


    Private Sub BetweenHullElimination(edge As Edge(Of EdgeTSP))
        Dim iEdge As Edge(Of EdgeTSP)
        Dim pt1, pt2 As NodeTSP
        Dim iSegment, tSegment As Segment
        Dim intersectPoint1 As Point
        Dim tDistance As Double

        pt1 = Graph.GetNode(edge.Node1).Attributes
        pt2 = Graph.GetNode(edge.Node2).Attributes
        tSegment = New Segment(pt1, pt2)
        tDistance = tSegment.Length

        ' test for intersecting spanning tree
        For stIndx = 0 To SpanningTree.Count - 1
            iEdge = Graph.GetEdge(SpanningTree.GetEdge(stIndx))

            If Not edge.Node1.Equals(iEdge.Node1) AndAlso
            Not edge.Node1.Equals(iEdge.Node2) AndAlso
            Not edge.Node2.Equals(iEdge.Node1) AndAlso
            Not edge.Node2.Equals(iEdge.Node2) Then

                iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                intersectPoint1 = Nothing
                If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                    If intersectPoint1 IsNot Nothing Then
                        edge.Attributes.IsCrossingSpanningEdge = True
                        edge.Active = False
                        EliminatedEdges(2) += 1
                        Exit Sub
                    End If
                End If

            End If
        Next

        ' test for intersecting expand spanning tree
        Dim eST As EdgeContainer
        For Each eST In mHullsSpanningTrees.Values
            'eST = mExpandSpanningTrees(i)
            For stIndx = 0 To eST.Count - 1
                iEdge = Graph.GetEdge(eST.GetEdge(stIndx))

                If Not edge.Node1.Equals(iEdge.Node1) AndAlso
                Not edge.Node1.Equals(iEdge.Node2) AndAlso
                Not edge.Node2.Equals(iEdge.Node1) AndAlso
                Not edge.Node2.Equals(iEdge.Node2) Then

                    iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                    intersectPoint1 = Nothing
                    If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                        If intersectPoint1 IsNot Nothing Then
                            edge.Attributes.IsCrossingSpanningEdge = True
                            edge.Active = False
                            EliminatedEdges(2) += 1
                            Exit Sub
                        End If
                    End If

                End If
            Next
        Next

        ''Angles larger than 120 degrees
        'If iPtIndx = iEdge.Node1 Then
        '    cPt = Graph.GetNode(iEdge.Node2).Attributes
        '    angl = Angle(cPt, Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(oPtIndx).Attributes)
        '    If angl >= 120 AndAlso angl <180 Then
        '        edge.Active = False
        '        EliminatedEdges(3) += 1
        '        Exit Sub
        '        'ElseIf angl = 180 Then
        '        '    Dim x = 0
        '    End If
        'ElseIf iPtIndx = iEdge.Node2 Then
        '    cPt = Graph.GetNode(iEdge.Node1).Attributes
        '    angl = Angle(cPt, Graph.GetNode(iEdge.Node2).Attributes, Graph.GetNode(oPtIndx).Attributes)
        '    If angl >= 120 AndAlso angl < 180 Then
        '        edge.Active = False
        '        EliminatedEdges(3) += 1
        '        Exit Sub
        '        'ElseIf angl = 180 Then
        '        '    Dim x = 0
        '    End If
        'End If


        ''test intersect between hull edge
        'For i = 0 To innerHull.Nodes.Count - 1
        '    For j = 0 To outerHull.Nodes.Count - 1
        '        iEdge = Graph.GetEdge(Graph.GetEdgeIndex(innerHull.Nodes(i), outerHull.Nodes(j)))
        '        If Not iEdge.Attributes.IsIntersectOwnConvexHull AndAlso Not iEdge.Equals(edge) Then
        '            iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
        '            intersectPoint1 = Nothing
        '            If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
        '                If intersectPoint1 IsNot Nothing AndAlso
        '                Not intersectPoint1.Equals(Graph.GetNode(iEdge.Node1).Attributes) AndAlso
        '                Not intersectPoint1.Equals(Graph.GetNode(iEdge.Node2).Attributes) Then

        '                    If tDistance > iSegment.Length Then
        '                        edge.Active = False
        '                        EliminatedEdges(7) += 1
        '                        Exit Sub
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        'Next

    End Sub
    Private Sub OverHullElimination(edge As Edge(Of EdgeTSP))
        Dim middleHull As ConvexHull
        Dim iEdge As Edge(Of EdgeTSP)
        Dim pt1, pt2 As NodeTSP
        Dim tSegment, iSegment As Segment
        Dim intersectPoint1 As Point
        Dim iHullIndx, oHullIndx As Integer

        ' test for intersecting own convex hull
        pt1 = Graph.GetNode(edge.Node1).Attributes
        pt2 = Graph.GetNode(edge.Node2).Attributes
        tSegment = New Segment(pt1, pt2)
        'tDistance = tSegment.Length

        ' test for intersecting spanning tree
        For stIndx = 0 To SpanningTree.Count - 1
            iEdge = Graph.GetEdge(SpanningTree.GetEdge(stIndx))

            If Not edge.Node1.Equals(iEdge.Node1) AndAlso
            Not edge.Node1.Equals(iEdge.Node2) AndAlso
            Not edge.Node2.Equals(iEdge.Node1) AndAlso
            Not edge.Node2.Equals(iEdge.Node2) Then

                iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                intersectPoint1 = Nothing
                If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                    If intersectPoint1 IsNot Nothing Then
                        edge.Attributes.IsCrossingSpanningEdge = True
                        edge.Active = False
                        EliminatedEdges(2) += 1
                        Exit Sub
                    End If
                End If

            End If
        Next

        ' test for intersecting expand spanning tree
        Dim eST As EdgeContainer
        For Each eST In mHullsSpanningTrees.Values
            'eST = mExpandSpanningTrees(i)
            For stIndx = 0 To eST.Count - 1
                iEdge = Graph.GetEdge(eST.GetEdge(stIndx))

                If Not edge.Node1.Equals(iEdge.Node1) AndAlso
                Not edge.Node1.Equals(iEdge.Node2) AndAlso
                Not edge.Node2.Equals(iEdge.Node1) AndAlso
                Not edge.Node2.Equals(iEdge.Node2) Then

                    iSegment = New Segment(Graph.GetNode(iEdge.Node1).Attributes, Graph.GetNode(iEdge.Node2).Attributes)
                    intersectPoint1 = Nothing
                    If Intersect_2Segments(tSegment, iSegment, intersectPoint1, Nothing) <> 0 Then
                        If intersectPoint1 IsNot Nothing Then
                            edge.Attributes.IsCrossingSpanningEdge = True
                            edge.Active = False
                            EliminatedEdges(2) += 1
                            Exit Sub
                        End If
                    End If

                End If
            Next
        Next

        'test colinear
        Dim mPt As NodeTSP
        For k = oHullIndx + 1 To iHullIndx - 1
            middleHull = ConvexHulls(k)
            For Each mNodeIndex In middleHull.Nodes
                mPt = Graph.GetNode(mNodeIndex).Attributes
                If Ccw(pt1, pt2, mPt) = 0 AndAlso InSegment(mPt, tSegment) Then
                    edge.Attributes.IsColinear = True
                    edge.Active = False
                    EliminatedEdges(3) += 1
                    Exit Sub
                End If
            Next
        Next

    End Sub


    Public Sub NewComputeSpanningTree(withAlternativeEdges As Boolean)
        Dim nodes As List(Of Point)
        Dim pt1, pt2 As NodeTSP
        Dim eIndx As Integer
        Dim iHull, oHull As ConvexHull
        Dim eST As EdgeContainer
        Dim translate As Dictionary(Of Integer, Integer)
        Dim cnt As Integer
        Dim MST As Integer()
        Dim MSTValue As Single
        Dim rIndx As Integer
        Dim excludeEdges As List(Of Tuple(Of Integer, Integer))
        'Dim edge As Edge(Of EdgeTSP)

        mHullsSpanningTrees = New Dictionary(Of String, EdgeContainer)

        For i = 0 To mConvexHulls.Count - 2
            oHull = ConvexHulls(i)
            For j = i + 1 To mConvexHulls.Count - 1
                iHull = ConvexHulls(j)

                cnt = 0
                nodes = New List(Of Point)(oHull.NumberNodes + iHull.NumberNodes)
                translate = New Dictionary(Of Integer, Integer)(oHull.NumberNodes + iHull.NumberNodes)

                For k = 0 To oHull.NumberNodes - 1
                    nodes.Add(Graph.GetNode(oHull.Nodes(k)).Attributes)
                    translate.Add(cnt, oHull.Nodes(k))
                    cnt += 1
                Next
                For k = 0 To iHull.NumberNodes - 1
                    nodes.Add(Graph.GetNode(iHull.Nodes(k)).Attributes)
                    translate.Add(cnt, iHull.Nodes(k))
                    cnt += 1
                Next

                eST = New EdgeContainer()
                mHullsSpanningTrees.Add(String.Format("{0}-{1}", i, j), eST)
            Next
        Next

        'excludeEdges = New List(Of Tuple(Of Integer, Integer))
        '        MST = Prim(nodes, 0, excludeEdges)

        '        For k = 0 To MST.Count - 1
        '            If MST(k) >= 0 Then
        '                eIndx = Graph.GetEdgeIndex(translate(k), translate(MST(k)))
        '                pt1 = Graph.GetNode(translate(k)).Attributes
        '                pt2 = Graph.GetNode(translate(MST(k))).Attributes
        '                Graph.GetEdge(eIndx).Attributes.IsExpandedSpanningTree = True
        '                eST.AddEdge(eIndx, Distance(pt1, pt2))
        '            End If
        '        Next
        '        MSTValue = eST.Value

        '        While eST.Value = MSTValue
        '            mExpandSpanningTrees.Add(String.Format("{0}-{1}", i, j), eST)

        '            rIndx += 1
        '            'edge = Graph.GetEdge(eST.GetEdge(rIndx))
        '            excludeEdges.Add(Tuple.Create(rIndx, MST(rIndx)))
        '            eST = New EdgeContainer()
        '            MST = Prim(nodes, 0, excludeEdges)

        '            For k = 0 To MST.Count - 1
        '                If MST(k) >= 0 Then
        '                    eIndx = Graph.GetEdgeIndex(translate(k), translate(MST(k)))
        '                    pt1 = Graph.GetNode(translate(k)).Attributes
        '                    pt2 = Graph.GetNode(translate(MST(k))).Attributes
        '                    Graph.GetEdge(eIndx).Attributes.IsExpandedSpanningTree = True
        '                    eST.AddEdge(eIndx, Distance(pt1, pt2))
        '                End If
        '            Next

        '        End While

        '    Next
        'Next


    End Sub
End Class
