Imports System.Runtime.CompilerServices

Public Class Segment
    Implements IEquatable(Of Segment)

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pt1"></param>
    ''' <param name="pt2"></param>
    Public Sub New(pt1 As Point, pt2 As Point)
        Point1 = pt1
        Point2 = pt2
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Point1 As Point

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Point2 As Point
#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Length() As Single
        Return Distance(Point1, Point2)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function Slope() As Single
        Return Functions.Slope(Me)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Shadows Function Equals(other As Segment) As Boolean Implements IEquatable(Of Segment).Equals
        If Point1.Equals(other.Point1) AndAlso Point2.Equals(other.Point2) Then
            Return True
        ElseIf Point1.Equals(other.Point2) AndAlso Point2.Equals(other.Point1) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Returns a <see cref="T:System.String" /> that represents the current
    ''' <see cref="T:System.Object" />.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return String.Format("X1: {0:f2} Y1: {1:f2} /_\ X2: {2:f2} Y2: {3:f2}", Point1.X, Point1.Y, Point2.X, Point2.Y)
    End Function
#End Region

End Class
