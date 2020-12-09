Public Class NodeTSP
    Inherits PlaneGeometry.Point
    Implements IEquatable(Of NodeTSP)
    Implements IComparable(Of NodeTSP)

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    Public Sub New(x As Single, y As Single)
        MyBase.New(x, y)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property ConvexHull As Integer
#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Shadows Function Equals(other As NodeTSP) As Boolean Implements IEquatable(Of NodeTSP).Equals
        Return MyBase.Equals(other)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Overloads Function CompareTo(other As NodeTSP) As Integer Implements IComparable(Of NodeTSP).CompareTo
        Return MyBase.CompareTo(other)
    End Function
#End Region

End Class
