Public Class Ray

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="origin"></param>
    ''' <param name="slope"></param>
    Public Sub New(origin As Point, slope As Double)
        Me.Origin = origin
        Me.Slope = slope
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Origin As Point

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Slope As Double
#End Region

End Class
