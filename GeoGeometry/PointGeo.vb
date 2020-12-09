Public Structure PointGeo
    Implements IEquatable(Of PointGeo)

    Private ReadOnly mUsingKm As Boolean

    Public Sub New(lat As Double, lon As Double, Optional useKm As Boolean = True)
        Latitude = lat
        Longitude = lon
        mUsingKm = useKm
    End Sub

    Public ReadOnly Property Latitude As Double
    Public ReadOnly Property Longitude As Double

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="elmts"></param>
    ''' <returns></returns>
    Public Function Centroid(elmts As IEnumerable(Of PointGeo)) As PointGeo

        Dim tX As Double
        Dim tY As Double
        Dim n As Integer

        tX = Latitude
        tY = Longitude
        n = 1
        For Each e In elmts
            'If e IsNot Nothing Then
            tX += e.Latitude
            tY += e.Longitude
            n += 1
            'End If
        Next

        Return New PointGeo(tX / n, tY / n)
    End Function
    Public Function Distance(pt As PointGeo) As Double 'Implements Graphs.INodeTSP(Of PointGeo).Distance
        Dim lat1 As Double
        Dim lon1 As Double
        Dim lat2 As Double
        Dim lon2 As Double
        Dim dlon As Double
        Dim dlat As Double
        Dim a As Double
        Dim c As Double
        Dim r As Double

        ' The math module contains a function named toRadians which converts from degrees to radians. 
        lat1 = ToRadians(Latitude)
        lon1 = ToRadians(Longitude)
        lat2 = ToRadians(pt.Latitude)
        lon2 = ToRadians(pt.Longitude)

        ' Haversine formula
        dlon = lon2 - lon1
        dlat = lat2 - lat1
        a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2)
        c = 2 * Math.Asin(Math.Sqrt(a))

        ' Radius of earth in kilometers.
        If mUsingKm Then
            r = 6371
        Else 'Use 3956 for miles 
            r = 3956
        End If

        ' calculate the result 
        Return (c * r)
    End Function

    Public Function Area(pt2 As PointGeo, pt3 As PointGeo) As Double 'Implements Graphs(Of PointGeo).Area
        ' Reference: http://mathforum.org/library/drmath/view/65316.html

        ' My CRC Standard Mathematical Tables contain the basic formula for the Area of a spherical triangle

        ' Area = pi * R ^ 2 * E / 180

        ' where, 

        ' R = radius Of sphere
        ' E = spherical excess Of triangle, E = A + B + C - 180
        ' A, B, C = angles of spherical triangle in degrees

        ' This Is the formula you say isn't helpful because you don't know the 
        ' angles, Right? Well, the tables also have the following formula for 
        ' the spherical excess E

        'tan(E / 4) = sqrt(tan(s / 2) * tan((s - a) / 2) * tan((s - b) / 2) * tan((s - c) / 2))

        ' where,

        ' a, b, c = sides of spherical triangle
        ' s = (a + b + c) / 2

        Throw New NotImplementedException()
    End Function

    Public Function Perimeter(pt2 As PointGeo, pt3 As PointGeo) As Double
        Return Distance(pt2) + Distance(pt3) + pt2.Distance(pt3)
    End Function

    Private Function ToRadians(angleIn10thofaDegree As Double) As Double
        ' Angle in 10th of a degree 
        Return (angleIn10thofaDegree * Math.PI / 180)
    End Function

    Public Shadows Function Equals(other As PointGeo) As Boolean Implements IEquatable(Of PointGeo).Equals
        If Latitude = other.Latitude AndAlso Longitude = other.Longitude Then Return True
        Return False
    End Function

    ''' <summary>
    ''' Returns a <see cref="T:System.String" /> that represents the current
    ''' <see cref="T:System.Object" />.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return String.Format("Latitude: {0:f2} Longitude: {1:f2}", Latitude, Longitude)
    End Function

End Structure
