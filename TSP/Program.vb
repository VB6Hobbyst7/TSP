Imports Graphs
Imports PlaneGeometry

Module Program
    'https://www.gamedev.net/forums/topic/582520-number-of-edges-on-a-triangulated-set-of-points/

    Dim TSP As PlaneTSP


    Sub Main(args As String())

        TSP = New PlaneTSP(args(0), True)
        Console.WriteLine("Number of Nodes: {0}", TSP.Graph.NumberNodes)
        Console.WriteLine("Number of Edges: {0}", TSP.Graph.NumberEdges)
        Console.WriteLine()

        ''Dim oX = 0
        ''Dim oY = 0
        'Dim oX = 14.8
        'Dim oY = 18.18
        'Dim rotation As Double = 45
        'Dim pt As Point
        'pt = New Point(19, 16)
        'Console.WriteLine("Point: {0}", pt.ToString)
        'Console.WriteLine("System 1: Q {0} - System 2: Q {1}", GetQuadrant(pt, oX, oY), GetQuadrant(pt, oX, oY, rotation))
        'pt = New Point(14, 25)
        'Console.WriteLine("Point: {0}", pt.ToString)
        'Console.WriteLine("System 1: Q {0} - System 2: Q {1}", GetQuadrant(pt, oX, oY), GetQuadrant(pt, oX, oY, rotation))

        TSP.ClassifyEdges()
        TSP.RunEdgeElimination()

        'Dim totalRemoved As Integer = TSP.EliminatedEdges.Sum
        'Console.WriteLine("Edges Removed: {0}/{1} - {2:f2}%", totalRemoved, TSP.Graph.NumberEdges, 100 * totalRemoved / TSP.Graph.NumberEdges)

        'Console.WriteLine("Convex Hulls Nodes: {0}/{1} - {2:f2}% / {3:f2}%", TSP.NumberEdgesInsideConvexHulls, TSP.EliminatedEdges(0), 100 * TSP.EliminatedEdges(0) / TSP.Graph.NumberEdges, 100 * TSP.EliminatedEdges(0) / TSP.NumberEdgesInsideConvexHulls)
        'Console.WriteLine("Between Convex Hulls: {0}/{1} - {2:f2}% / {3:f2}%", TSP.NumberEdgesBetweenConvexHulls, TSP.EliminatedEdges(1), 100 * TSP.EliminatedEdges(1) / TSP.Graph.NumberEdges, 100 * TSP.EliminatedEdges(1) / TSP.NumberEdgesBetweenConvexHulls)
        'Console.WriteLine("Between Convex Hulls: {0}/{1} - {2:f2}% / {3:f2}%", TSP.NumberEdgesBetweenConvexHulls, TSP.EliminatedEdges(2), 100 * TSP.EliminatedEdges(2) / TSP.Graph.NumberEdges, 100 * TSP.EliminatedEdges(2) / TSP.NumberEdgesBetweenConvexHulls)
        Dim cntr As Integer
        For i = 0 To TSP.Graph.NumberEdges - 1
            Dim edg As Edge(Of EdgeTSP)
            edg = TSP.Graph.GetEdge(i)
            'If edg.Attributes.IsBetweenConvexHulls AndAlso Not edg.Active Then
            '    cntr += 1
            'End If
            If Not edg.Attributes.IsConvexHull AndAlso Not edg.Attributes.IsInsideConvexHull AndAlso Not edg.Attributes.IsBetweenConvexHulls AndAlso Not edg.Attributes.IsOverConvexHull Then
                cntr += 1
            End If
        Next
        Console.WriteLine("{0}", cntr)
        'Console.WriteLine("{0}", TSP.NumberEdgesBetweenConvexHulls - cntr)
        'Console.WriteLine("Intersecting Own Convex Hull: {0}/{1} - {2:f2}% / {3:f2}%", EdgesRemoved(1)(0), EdgesRemoved(1)(1), 100 * EdgesRemoved(1)(0) / TSP.Graph.NumberEdges, 100 * EdgesRemoved(1)(0) / EdgesRemoved(1)(1))
        'Console.WriteLine("Between Two Consecutive Convex Hulls: {0}/{1} - {2:f2}% / {3:f2}%", EdgesRemoved(2)(0), EdgesRemoved(2)(1), 100 * EdgesRemoved(2)(0) / TSP.Graph.NumberEdges, 100 * EdgesRemoved(2)(0) / EdgesRemoved(2)(1))
        'Console.WriteLine("Over Convex Hull: {0}/{1} - {2:f2}% / {3:f2}%", TSP.NumberEdgesOverConvexHull, TSP.EliminatedEdges(3), 100 * TSP.EliminatedEdges(3) / TSP.Graph.NumberEdges, 100 * TSP.EliminatedEdges(3) / TSP.NumberEdgesOverConvexHull)
        'Console.WriteLine("Over Convex Hull: {0}/{1} - {2:f2}% / {3:f2}%", TSP.NumberEdgesOverConvexHull, TSP.EliminatedEdges(4), 100 * TSP.EliminatedEdges(4) / TSP.Graph.NumberEdges, 100 * TSP.EliminatedEdges(4) / TSP.NumberEdgesOverConvexHull)
        'Console.WriteLine("Edges Convex Hull: {0}/{1} - {2:f2}% / {3:f2}%", EdgesRemoved(4)(0), EdgesRemoved(4)(1), 100 * EdgesRemoved(4)(0) / TSP.Graph.NumberEdges, 100 * EdgesRemoved(4)(0) / EdgesRemoved(4)(1))


        'Console.WriteLine("Double Edge Cross Convex Hulls: {0}", EdgesRemoved(4))
        'Console.WriteLine("Node Degree: {0}", EdgesRemoved(5))
        'Console.WriteLine("Angles: {0}", EdgesRemoved(6))
        'Console.WriteLine("New Number of Edges: {0}", TSP.Graph.NumberEdges - totalRemoved)

        Dim e As Edge
        Dim cnt As Integer
        For i = 0 To TSP.Graph.NumberNodes - 1
            Console.Write("{0} -", i + 1)
            For j = i + 1 To TSP.Graph.NumberNodes - 1
                e = TSP.Graph.GetEdge(TSP.Graph.GetEdgeIndex(i, j))
                If e.Active Then
                    Console.Write(" {0}", e.Node2 + 1)
                    cnt += 1
                End If
            Next
            Console.WriteLine()
        Next
        Console.WriteLine("Edge Count: {0}", cnt)
        Console.WriteLine("Edges Remoded: {0}", TSP.Graph.NumberEdges - cnt)
        'cnt = 0
        'For i = 0 To TSP.Graph.NumberEdges - 1
        '    e = TSP.Graph.GetEdge(i)
        '    If e.NumTests = 0 Then
        '        Console.WriteLine("{0} {1}", e.Point1 + 1, e.Point2 + 1)
        '        cnt += 1
        '    End If
        'Next
        'Console.WriteLine("Edge Count: {0}", cnt)

        Dim angls(2) As Double
        Dim p1, p2, p3 As Integer
        p1 = 12 : p2 = 14 : p3 = 15

        angls(0) = Angle(TSP.Graph.GetNode(p1).Attributes, TSP.Graph.GetNode(p2).Attributes, TSP.Graph.GetNode(p3).Attributes)
        angls(1) = Angle(TSP.Graph.GetNode(p2).Attributes, TSP.Graph.GetNode(p1).Attributes, TSP.Graph.GetNode(p3).Attributes)
        angls(2) = Angle(TSP.Graph.GetNode(p3).Attributes, TSP.Graph.GetNode(p1).Attributes, TSP.Graph.GetNode(p2).Attributes)

        Dim D29_31, D31_42 As Double
        D29_31 = Distance(TSP.Graph.GetNode(28).Attributes, TSP.Graph.GetNode(30).Attributes)
        D31_42 = Distance(TSP.Graph.GetNode(30).Attributes, TSP.Graph.GetNode(41).Attributes)
        Dim x = D29_31 + D31_42
        Dim D5_31, D31_32 As Double
        D5_31 = Distance(TSP.Graph.GetNode(4).Attributes, TSP.Graph.GetNode(30).Attributes)
        D31_32 = Distance(TSP.Graph.GetNode(30).Attributes, TSP.Graph.GetNode(31).Attributes)
        Dim y = D5_31 + D31_32

        'Do While ConnectedComponents Is Nothing OrElse ConnectedComponents.Count > 1
        'WriteLP5()
        'ReadSolution("C:\Users\pauborge\Desktop\TSP\Solution5.sol")
        'ComputeConnComp()
        'Loop

        Console.ReadKey()
    End Sub



    'Public Function TestAngles(minAngle As Double, maxAngle As Double) As Integer
    '    Dim pt1, pt2, pt3 As Point
    '    Dim eg1, eg2, eg3 As Edge
    '    Dim n1, n2, n3 As Integer
    '    Dim e1, e2, e3 As Integer
    '    Dim angl1, angl2, angl3 As Double
    '    Dim c1, c2, c3 As Integer
    '    Dim retValue As Integer
    '    Dim edgeToRemove As Edge = Nothing
    '    Dim othernode As Integer
    '    Dim cnt As Integer

    '    For n1 = 0 To TSP.Graph.NumberNodes - 3
    '        pt1 = TSP.Graph.GetNode(n1).Attributes
    '        c1 = TSP.Graph.GetNode(n1).Cluster
    '        For n2 = n1 + 1 To TSP.Graph.NumberNodes - 2
    '            pt2 = TSP.Graph.GetNode(n2).Attributes
    '            c2 = TSP.Graph.GetNode(n2).Cluster
    '            e1 = TSP.Graph.GetEdgeIndex(n1, n2)
    '            eg1 = TSP.Graph.GetEdge(e1)
    '            For n3 = n2 + 1 To TSP.Graph.NumberNodes - 1
    '                pt3 = TSP.Graph.GetNode(n3).Attributes
    '                c3 = TSP.Graph.GetNode(n3).Cluster
    '                e2 = TSP.Graph.GetEdgeIndex(n1, n3)
    '                eg2 = TSP.Graph.GetEdge(e2)
    '                e3 = TSP.Graph.GetEdgeIndex(n2, n3)
    '                eg3 = TSP.Graph.GetEdge(e3)
    '                angl1 = Angle(pt1, pt2, pt3)
    '                angl2 = Angle(pt2, pt1, pt3)
    '                angl3 = Angle(pt3, pt1, pt2)
    '                If angl1 > minAngle AndAlso angl1 < maxAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, False) : eg3.AddTest(0, True)
    '                    'retValue += 1
    '                    edgeToRemove = eg3
    '                    othernode = n1
    '                ElseIf angl2 > minAngle AndAlso angl2 < maxAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, True) : eg3.AddTest(0, False)
    '                    'retValue += 1
    '                    edgeToRemove = eg2
    '                    othernode = n2
    '                ElseIf angl3 > minAngle AndAlso angl3 < maxAngle Then
    '                    'eg1.AddTest(0, True) : eg2.AddTest(0, False) : eg3.AddTest(0, False)
    '                    'retValue += 1
    '                    edgeToRemove = eg1
    '                    othernode = n3
    '                    'ElseIf c1 <> c2 AndAlso c1 <> c3 AndAlso c2 <> c3 Then
    '                ElseIf angl1 = maxAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, False) : eg3.AddTest(0, True)
    '                ElseIf angl2 = maxAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, True) : eg3.AddTest(0, False)
    '                ElseIf angl3 = maxAngle Then
    '                    'eg1.AddTest(0, True) : eg2.AddTest(0, False) : eg3.AddTest(0, False)
    '                ElseIf angl1 = minAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, False) : eg3.AddTest(0, True)
    '                ElseIf angl2 = minAngle Then
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, True) : eg3.AddTest(0, False)
    '                ElseIf angl3 = minAngle Then
    '                    'eg1.AddTest(0, True) : eg2.AddTest(0, False) : eg3.AddTest(0, False)
    '                Else
    '                    'eg1.AddTest(0, False) : eg2.AddTest(0, False) : eg3.AddTest(0, False)
    '                End If
    '                If edgeToRemove IsNot Nothing AndAlso edgeToRemove.Node1 = 4 AndAlso edgeToRemove.Node2 = 5 Then
    '                    retValue += 1
    '                    If ConvexHulls(1).Nodes.Contains(othernode) Then
    '                        cnt += 1
    '                    End If
    '                End If
    '            Next
    '        Next
    '    Next

    '    Return retValue
    'End Function


    'Public Sub ComputeCircuits()
    '    'If Vertices IsNot Nothing Then
    '    ConnectedComponents = New List(Of List(Of Integer))
    '    Dim connectEdges As List(Of Integer)
    '    Dim exploredEdges As New List(Of Integer)
    '    Dim firstNode, currentNode, currentEdge As Integer
    '    Dim candidaNode As Integer

    '    For i = 0 To SolutionEdges.Length - 1
    '        currentEdge = SolutionEdges(i)

    '        If Not exploredEdges.Contains(currentEdge) Then

    '            connectEdges = New List(Of Integer)
    '            firstNode = TSP.Graph.GetEdge(currentEdge).Node1 + 1
    '            'currentNode = firstNode
    '            candidaNode = TSP.Graph.GetEdge(currentEdge).Node2 + 1
    '            exploredEdges.Add(currentEdge)

    '            'If Not Vertices.Contains(currentNode) AndAlso Not Vertices.Contains(candidaNode) Then
    '            connectEdges.Add(currentEdge)
    '            'End If

    '            While candidaNode <> firstNode

    '                currentNode = candidaNode
    '                For Each edg In TSP.Graph.GetNode(currentNode - 1).Edges
    '                    If edg <> currentEdge AndAlso SolutionEdges.Contains(edg) Then
    '                        currentEdge = edg
    '                        candidaNode = TSP.Graph.GetOtherNode(currentEdge, currentNode - 1) + 1
    '                        exploredEdges.Add(currentEdge)
    '                        'If Not Vertices.Contains(currentNode) AndAlso Not Vertices.Contains(candidaNode) Then
    '                        connectEdges.Add(currentEdge)
    '                        'End If
    '                        Exit For
    '                    End If
    '                Next
    '            End While

    '            ConnectedComponents.Add(connectEdges)
    '        End If
    '    Next
    '    'End If
    'End Sub



End Module
