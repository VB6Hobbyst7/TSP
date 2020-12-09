Imports System.Runtime.CompilerServices

Public Class Point
    Implements IEquatable(Of Point)
    Implements IComparable(Of Point)

    Protected mX As Single
    Protected mY As Single

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    Public Sub New(x As Single, y As Single)
        mX = x
        mY = y
        Quadrant = -1
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property X As Single
        Get
            Return mX : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Y As Single
        Get
            Return mY : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Quadrant As Integer
#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="p"></param>
    Public Sub Precision(p As Integer)
        mX = Math.Round(mX, p)
        mY = Math.Round(mY, p)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Shadows Function Equals(other As Point) As Boolean Implements IEquatable(Of Point).Equals
        If Math.Abs(X - other.X) < 0.00000001 AndAlso Math.Abs(Y - other.Y) < 0.00000001 Then
            Return True
        End If
        'If X = other.X AndAlso Y = other.Y Then Return True
        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Function CompareTo(other As Point) As Integer Implements IComparable(Of Point).CompareTo
        Dim retValue As Integer

        retValue = X.CompareTo(other.X)
        If retValue = 0 Then
            retValue = Y.CompareTo(other.Y)
        End If

        Return retValue
    End Function

    ''' <summary>
    ''' Returns a <see cref="T:System.String" /> that represents the current
    ''' <see cref="T:System.Object" />.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return String.Format("X: {0:f2} Y: {1:f2}", X, Y)
    End Function
#End Region

End Class
