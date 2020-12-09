Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices

Public Module Functions

    ''' <summary>
    '''  Calculate the cross product of the two points.
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Function CrossProduct(p1 As Point, p2 As Point) As Single
        Return p1.X * p2.Y - p1.Y * p2.X
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Function DotProduct(p1 As Point, p2 As Point) As Single
        Return p1.X * p2.X + p1.Y * p2.Y
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="p"></param>
    ''' <returns></returns>
    Function ScalarProduct(s As Single, p As Point) As Point
        Return New Point(s * p.X, s * p.Y)
    End Function

    ''' <summary>
    ''' Adds the second point from the first.
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    Function AddPoints(p1 As Point, p2 As Point) As Point
        Return New Point(p1.X + p2.X, p1.Y + p2.Y)
    End Function

    ''' <summary>
    ''' Subtract the second point to the first.
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Function SubtractPoints(p1 As Point, p2 As Point) As Point
        Return New Point(p1.X - p2.X, p1.Y - p2.Y)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Distance(p1 As Point, p2 As Point) As Single
        Return Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
    End Function

    Public Function Slope(s As Segment) As Single
        Return Slope(s.Point1, s.Point2)
    End Function

    Public Function Slope(p1 As Point, p2 As Point) As Single
        Return p2.Y - p1.Y / p2.X - p1.X
    End Function

    Public Function Perimeter(vertices As IEnumerable(Of Point)) As Single
        Dim retValue As Single
        Dim size As Integer
        size = vertices.Count
        For i = 0 To size - 2
            retValue += Distance(vertices(i), vertices(i + 1))
        Next
        Return retValue + Distance(vertices(size - 1), vertices(0))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="refPt"></param>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <param name="inRadians"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Angle(refPt As Point, p1 As Point, p2 As Point, Optional inRadians As Boolean = False) As Single
        Dim a As Point = SubtractPoints(p1, refPt)
        Dim b As Point = SubtractPoints(p2, refPt)
        Dim dp As Single = DotProduct(a, b)
        Dim temp As Single = dp / (Distance(refPt, p1) * Distance(refPt, p2))
        If 1 - Math.Abs(temp) < 0.00000001 Then
            If inRadians Then
                Return Math.PI
            Else
                Return 180
            End If
        Else
            If inRadians Then
                Return Math.Acos(temp)
            Else
                Return (180 / Math.PI) * Math.Acos(temp)
            End If
        End If

    End Function

    Public Function AreaTriangle(p1 As Point, p2 As Point, p3 As Point) As Single
        Return Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2
    End Function

    ''' <summary>
    ''' Computes the area of a quadrilateral. Assumes the points are in sequence and its convex.
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <param name="p3"></param>
    ''' <param name="p4"></param>
    ''' <returns>Returns the area of a quadrilateral.</returns>
    Public Function AreaConvexQuadrilateral(p1 As Point, p2 As Point, p3 As Point, p4 As Point) As Single
        'https://en.wikipedia.org/wiki/Quadrilateral
        Dim isSquared As Boolean = True
        Dim angles(3) As Single

        angles(0) = Angle(p1, p2, p4)
        angles(1) = Angle(p2, p1, p3)
        angles(2) = Angle(p3, p2, p4)
        angles(3) = Angle(p4, p1, p3)

        'test if is squared (squares & rectangles)
        For Each a In angles
            If a <> 90 Then
                isSquared = False
                Exit For
            End If
        Next

        If isSquared Then
            Return Distance(p1, p2) * Distance(p2, p3)
        Else
            Throw New NotImplementedException()
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="p"></param>
    ''' <param name="originX"></param>
    ''' <param name="originY"></param>
    ''' <param name="rotationDegrees"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function GetQuadrant(p As Point,
                                Optional originX As Single = 0,
                                Optional originY As Single = 0,
                                Optional rotationDegrees As Double = 0) As Integer

        Dim refPt As Point
        If originX = 0 AndAlso originY = 0 Then
            refPt = p
        Else
            refPt = SubtractPoints(p, New Point(originX, originY))
        End If

        If rotationDegrees <> 0 AndAlso Math.Abs(rotationDegrees) < 360 Then ' rotate point
            Dim rad As Double = rotationDegrees * (Math.PI / 180)
            Dim c As Double = Math.Cos(rad)
            Dim s As Double = Math.Sin(rad)
            refPt = New Point(refPt.X * c + refPt.Y * s, refPt.Y * c - refPt.X * s)
        End If

        If refPt.X > 0 AndAlso refPt.Y > 0 Then
            Return 1
        ElseIf refPt.X > 0 AndAlso refPt.Y < 0 Then
            Return 4
        ElseIf refPt.X > 0 AndAlso refPt.Y = 0 Then
            Return 14
        ElseIf refPt.X < 0 AndAlso refPt.Y > 0 Then
            Return 2
        ElseIf refPt.X < 0 AndAlso refPt.Y < 0 Then
            Return 3
        ElseIf refPt.X < 0 AndAlso refPt.Y = 0 Then
            Return 23
        ElseIf refPt.X = 0 AndAlso refPt.Y > 0 Then
            Return 12
        ElseIf refPt.X = 0 AndAlso refPt.Y < 0 Then
            Return 34
        Else 'refPt.X = 0 AndAlso refPt.Y = 0
            Return 0
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="elmts"></param>
    ''' <returns></returns>
    Public Function Centroid(elmts As IEnumerable(Of Point)) As Point

        Dim tX As Double
        Dim tY As Double
        Dim n As Integer = elmts.Count

        For Each e In elmts
            tX += e.X
            tY += e.Y
        Next

        Return New Point(tX / n, tY / n)
    End Function

    ''' <summary>
    ''' Find the 2D intersection Of 2 finite segments.
    ''' </summary>
    ''' <param name="s1">A segment.</param>
    ''' <param name="s2">A segment.</param>
    ''' <param name="I0">I0 is intersect point (when it exists)</param>
    ''' <param name="I1">I1 is  endpoint of intersect segment [I0,I1] (when it exists)</param>
    ''' <returns>0 if disjoint (no intersect). 1 if intersect in unique point I0. 2 is overlap in segment from I0 to I1</returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Function Intersect_2Segments(s1 As Segment, s2 As Segment, ByRef I0 As Point, ByRef I1 As Point) As Integer
        'http://geomalgorithms.com/a05-_intersect-1.html#intersect2D_2Segments()

        Dim u As Point = SubtractPoints(s1.Point2, s1.Point1)
        Dim v As Point = SubtractPoints(s2.Point2, s2.Point1)
        Dim w As Point = SubtractPoints(s1.Point1, s2.Point1)
        Dim D As Single = CrossProduct(u, v)
        Dim SMALL_NUM As Single = 0.00000001 ' anything that avoids division overflow

        ' test if  they are parallel (includes either being a point)
        If (Math.Abs(D) < SMALL_NUM) Then           ' S1 And S2 are parallel
            If (CrossProduct(u, w) <> 0 OrElse CrossProduct(v, w) <> 0) Then
                Return 0                    ' they are Not collinear
            End If

            ' they are collinear Or degenerate check if they are degenerate points
            Dim du As Single = DotProduct(u, u)
            Dim dv As Single = DotProduct(v, v)
            If (du = 0 AndAlso dv = 0) Then ' both segments are points
                If Not s1.Point1.Equals(s2.Point2) Then ' they are distinct  points
                    Return 0
                Else
                    I0 = s1.Point1 ' they are the same point
                    Return 1
                End If
            End If

            If (du = 0) Then ' S1 Is a single point
                If InSegment(s1.Point1, s2) Then ' but Is Not in S2
                    I0 = s1.Point1
                    Return 1
                Else
                    Return 0
                End If
            End If
            If (dv = 0) Then ' S2 is a single point
                If InSegment(s2.Point1, s1) Then ' but Is Not in S1
                    I0 = s2.Point1
                    Return 1
                Else
                    Return 0
                End If
            End If
            ' they are collinear segments - get  overlap (Or Not)
            Dim t0, t1 As Single                   ' endpoints Of S1 In eqn For S2
            Dim w2 = SubtractPoints(s1.Point2, s2.Point1)
            If (v.X <> 0) Then
                t0 = w.X / v.X
                t1 = w2.X / v.X
            Else
                t0 = w.Y / v.Y
                t1 = w2.Y / v.Y
            End If

            If (t0 > t1) Then                    ' must have t0 smaller than t1
                Dim t = t0 : t0 = t1 : t1 = t    ' swap If Not
            End If
            If (t0 > 1 OrElse t1 < 0) Then
                Return 0      ' NO overlap
            End If

            If t0 < 0 Then ' clip To min 0
                t0 = 0
            End If
            If t1 > 1 Then ' clip To max 1
                t1 = 1
            End If

            If (t0 = t1) Then                  ' intersect Is a point
                I0 = AddPoints(s2.Point1, ScalarProduct(t0, v))
                Return 1
            End If

            ' they overlap in a valid subsegment
            I0 = AddPoints(s2.Point1, ScalarProduct(t0, v))
            I1 = AddPoints(s2.Point1, ScalarProduct(t1, v))
            Return 2
        End If

        ' the segments are skew And may intersect in a point get the intersect parameter for S1
        Dim sI As Single = CrossProduct(v, w) / D
        If (sI < 0 OrElse sI > 1) Then               ' no intersect with S1
            Return 0
        End If
        ' get the intersect parameter for S2
        Dim tI As Single = CrossProduct(u, w) / D
        If (tI < 0 OrElse tI > 1) Then                ' no intersect with S2
            Return 0
        End If

        I0 = AddPoints(s1.Point1, ScalarProduct(sI, u)) ' compute S1 intersect point
        I0.Precision(6)
        Return 1
    End Function

    ''' <summary>
    '''  Determine if a point is inside a segment.
    '''  Assumes colinearity was tested before.
    ''' </summary>
    ''' <param name="p">A point.</param>
    ''' <param name="s">A segment.</param>
    ''' <returns>1 if p is inside S. 0 if p is not inside S.</returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Function InSegment(p As Point, s As Segment) As Boolean

        If s.Point1.X <> s.Point2.X AndAlso s.Point1.Y = s.Point2.Y Then ' S Is horizontal

            If s.Point1.X <= p.X AndAlso p.X <= s.Point2.X Then Return True
            If s.Point1.X >= p.X AndAlso p.X >= s.Point2.X Then Return True

        ElseIf s.Point1.Y <> s.Point2.Y AndAlso s.Point1.X = s.Point2.X Then ' S Is vertical

            If s.Point1.Y <= p.Y AndAlso p.Y <= s.Point2.Y Then Return True
            If s.Point1.Y >= p.Y AndAlso p.Y >= s.Point2.Y Then Return True

        Else

            'S has positive slope
            If s.Point1.X <= p.X AndAlso p.X <= s.Point2.X AndAlso s.Point1.Y <= p.Y AndAlso p.Y <= s.Point2.Y Then Return True
            If s.Point2.X <= p.X AndAlso p.X <= s.Point1.X AndAlso s.Point2.Y <= p.Y AndAlso p.Y <= s.Point1.Y Then Return True

            'S has negative slope
            If s.Point1.X <= p.X AndAlso p.X <= s.Point2.X AndAlso s.Point2.Y <= p.Y AndAlso p.Y <= s.Point1.Y Then Return True
            If s.Point2.X <= p.X AndAlso p.X <= s.Point1.X AndAlso s.Point1.Y <= p.Y AndAlso p.Y <= s.Point2.Y Then Return True

        End If

        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="originalWidth"></param>
    ''' <param name="originalHeight"></param>
    ''' <param name="newWidth"></param>
    ''' <param name="newHeight"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function ScalePlane(originalWidth As Single, originalHeight As Single, newWidth As Single, newHeight As Single) As Tuple(Of Integer, Integer)
        Dim scaleWidth As Integer = Math.Max(Math.Floor(newWidth / originalWidth), 1)
        Dim scaleHeight As Integer = Math.Max(Math.Floor(newHeight / originalHeight), 1)

        Return Tuple.Create(scaleWidth, scaleHeight)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function ScalePoint(p As Point,
                               scaling As Tuple(Of Integer, Integer),
                               refCorner As Point,
                               planeHeight As Integer,
                               magnitute As Integer,
                               shiftWidth As Integer,
                               shiftHeigth As Integer) As Point
        Dim x As Integer
        Dim y As Integer

        x = CInt(shiftWidth + ((p.X - refCorner.X) / magnitute * scaling.Item1))
        y = CInt(planeHeight + shiftHeigth - (p.Y - refCorner.Y) / magnitute * scaling.Item2)

        Return New Point(x, y)
    End Function

#Region "Convex hull"
    Function ConvexHull(p As List(Of Point), Optional addBoundary As Boolean = False, Optional sortInPlace As Boolean = False) As List(Of Point)
        Dim hull As List(Of Point)
        Dim potentialBoundary As List(Of Point)
        Dim ccwValue As Integer
        Dim t As Integer
        Dim pt As Point

        If p.Count = 0 Then
            Return Nothing
        ElseIf p.Count = 1 Then
            Return p
        End If

        If Not sortInPlace Then p.Sort()

        hull = New List(Of Point)
        potentialBoundary = New List(Of Point)

        ' Lower hull
        For Each pt In p
            'While hull.Count >= 2 AndAlso Not Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt)
            '    hull.RemoveAt(hull.Count - 1)
            'End While

            While hull.Count >= 2 AndAlso Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt) <= 0

                ccwValue = Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt)
                If ccwValue = 0 Then
                    potentialBoundary.Add(hull(hull.Count - 1))
                End If
                hull.RemoveAt(hull.Count - 1)

            End While
            hull.Add(pt)
        Next

        ' Upper hull
        t = hull.Count + 1
        For i = p.Count - 1 To 0 Step -1
            pt = p(i)
            'While hull.Count >= t AndAlso Not Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt)
            '    hull.RemoveAt(hull.Count - 1)
            'End While

            While hull.Count >= t AndAlso Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt) <= 0

                ccwValue = Ccw(hull(hull.Count - 2), hull(hull.Count - 1), pt)
                If ccwValue = 0 Then
                    potentialBoundary.Add(hull(hull.Count - 1))
                End If
                hull.RemoveAt(hull.Count - 1)

            End While
            hull.Add(pt)
        Next

        hull.RemoveAt(hull.Count - 1)

        'Add boundary points
        If addBoundary Then
            Dim hullSize As Integer
            For j = 0 To potentialBoundary.Count - 1

                hullSize = hull.Count

                ' check on the edge formed between first and last nodes
                If Not potentialBoundary(j).Equals(hull(0)) AndAlso Not potentialBoundary(j).Equals(hull(hullSize - 1)) Then
                    ccwValue = Ccw(hull(0), hull(hullSize - 1), potentialBoundary(j))
                    If ccwValue = 0 AndAlso InSegment(potentialBoundary(j), New Segment(hull(0), hull(hullSize - 1))) Then 'Add the boundary point
                        hull.Add(potentialBoundary(j))
                        hullSize += 1
                    End If
                End If

                ' check on the edge formed between the nodes
                For i = 0 To hullSize - 2
                    If Not potentialBoundary(j).Equals(hull(i)) AndAlso Not potentialBoundary(j).Equals(hull(i + 1)) Then
                        ccwValue = Ccw(hull(i), hull(i + 1), potentialBoundary(j))
                        If ccwValue = 0 AndAlso InSegment(potentialBoundary(j), New Segment(hull(i), hull(i + 1))) Then 'Add the boundary point
                            Dim rng = hull.GetRange(i + 1, hullSize - i - 1)
                            hull.RemoveRange(i + 1, hullSize - i - 1)
                            hull.Add(potentialBoundary(j))
                            hull.InsertRange(i + 2, rng)
                        End If
                    End If
                Next

            Next
        End If

        Return hull
    End Function

    'Private Function Ccw(a As Point, b As Point, c As Point) As Boolean
    '    'Return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X))
    '    Dim area As Double
    '    area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)
    '    If area < 0 Then
    '        Return False 'Clockwise
    '    ElseIf area > 0 Then
    '        Return True 'Counter-clockwise
    '    Else
    '        Return True 'collinear
    '    End If
    'End Function

    Public Function Ccw(a As Point, b As Point, c As Point) As Integer
        Dim area As Double

        area = Math.Round((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X), 7)
        If area < 0 Then
            Return -1 'Clockwise
        ElseIf area > 0 Then
            Return 1 'Counter-clockwise
        Else
            Return 0 'collinear
        End If
    End Function
#End Region

#Region "Spanning Tree"
    ''' <summary>
    ''' Function to construct a MST for a graph
    ''' </summary>
    ''' <param name="points"></param>
    ''' <returns></returns>
    Public Function Prim(points As List(Of Point)) As Integer()
        ' Number of vertices in the graph
        Dim NumberNodes As Integer = points.Count
        ' Array to store constructed MST
        Dim parent As Integer() = New Integer(NumberNodes - 1) {}
        ' Key values used to pick minimum weight edge in cut
        Dim keys As Single() = New Single(NumberNodes - 1) {}
        ' To represent set of vertices included in MST
        Dim mstSet As Boolean() = New Boolean(NumberNodes - 1) {}

        Dim weigth As Single

        ' Initialize all keys as INFINITE
        For i As Integer = 0 To NumberNodes - 1
            keys(i) = Single.MaxValue
            mstSet(i) = False
        Next

        ' Always include first the 1st vertex in MST.
        ' Make keys 0 so that this vertex Is picked as first vertex
        ' First node Is always root of MST
        keys(0) = 0
        parent(0) = -1

        ' The MST will have V vertices
        Dim u As Integer
        For count As Integer = 0 To NumberNodes - 1 ' - 1
            ' Pick the minimum keys vertex from the set of vertices Not yet included in MST
            u = MinKey(keys, mstSet)
            ' Add the picked vertex to the MST Set
            mstSet(u) = True
            ' Update keys value and parent index of the adjacent vertices of the picked vertex.
            ' Consider only those vertices which are Not yet included in MST
            For v As Integer = 0 To NumberNodes - 1
                'Consider only vertices not yet included in the MST
                If Not mstSet(v) Then
                    weigth = Distance(points(u), points(v))

                    If weigth < keys(v) Then ' AndAlso weigth > 0
                        parent(v) = u
                        keys(v) = weigth
                    End If
                End If

            Next
        Next

        Return parent
    End Function

    ''' <summary>
    ''' A utility function to find the vertex with minimum keys value, from the set of vertices Not yet included in MST
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="mstSet"></param>
    ''' <returns></returns>
    Private Function MinKey(key As Single(), mstSet As Boolean()) As Integer
        Dim numberNodes As Integer = key.Count
        ' Initialize min value
        Dim min As Single = Single.MaxValue
        Dim min_index As Integer = -1

        For v As Integer = 0 To numberNodes - 1

            If mstSet(v) = False AndAlso key(v) < min Then
                min = key(v)
                min_index = v
            End If
        Next

        Return min_index
    End Function
#End Region

End Module
