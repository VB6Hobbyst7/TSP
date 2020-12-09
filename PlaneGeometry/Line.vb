Public Class Line

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="slope"></param>
    ''' <param name="intersect"></param>
    Public Sub New(slope As Single, intersect As Single)
        Me.Slope = slope
        Me.Intersect = intersect
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pt1"></param>
    ''' <param name="pt2"></param>
    Public Sub New(pt1 As Point, pt2 As Point)
        Slope = Functions.Slope(pt1, pt2)
        Intersect = pt1.Y - Slope * pt1.X
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Slope As Single

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Intersect As Single
#End Region

End Class
