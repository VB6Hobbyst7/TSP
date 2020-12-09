Public Class EdgeTSP
    Implements IEquatable(Of EdgeTSP)
    Implements IComparable(Of EdgeTSP)

    Protected mClassificationBitProps As BitArray
    Protected mEliminationBitProps As BitArray
    Protected mValue As Single

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub New()
        mValue = Single.NaN
        mClassificationBitProps = New BitArray(9)
        mEliminationBitProps = New BitArray(5)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="value"></param>
    Public Sub New(value As Single)
        mValue = value
        mClassificationBitProps = New BitArray(9)
        mEliminationBitProps = New BitArray(5)
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Value As Single
        Get
            Return mValue : End Get
    End Property

#Region "Classification"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsConvexHull As Boolean
        Get
            Return mClassificationBitProps(0) : End Get
        Set(value As Boolean)
            mClassificationBitProps(0) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsSpanningEdge As Boolean
        Get
            Return mClassificationBitProps(1) : End Get
        Set(value As Boolean)
            mClassificationBitProps(1) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsHullSpanningEdge As Boolean
        Get
            Return mClassificationBitProps(2) : End Get
        Set(value As Boolean)
            mClassificationBitProps(2) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property HasAlternative As Boolean
        Get
            Return mClassificationBitProps(3) : End Get
        Set(value As Boolean)
            mClassificationBitProps(3) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsTour As Boolean
        Get
            Return mClassificationBitProps(4) : End Get
        Set(value As Boolean)
            mClassificationBitProps(4) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsInsideConvexHull As Boolean
        Get
            Return mClassificationBitProps(5) : End Get
        Set(value As Boolean)
            mClassificationBitProps(5) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsBetweenConvexHulls As Boolean
        Get
            Return mClassificationBitProps(6) : End Get
        Set(value As Boolean)
            mClassificationBitProps(6) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsOverConvexHull As Boolean
        Get
            Return mClassificationBitProps(7) : End Get
        Set(value As Boolean)
            mClassificationBitProps(7) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsSolution As Boolean
        Get
            Return mClassificationBitProps(8) : End Get
        Set(value As Boolean)
            mClassificationBitProps(8) = value : End Set
    End Property
#End Region

#Region "Elimination"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsIntersectOwnConvexHull As Boolean
        Get
            Return mEliminationBitProps(0) : End Get
        Set(value As Boolean)
            mEliminationBitProps(0) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsColinear As Boolean
        Get
            Return mEliminationBitProps(1) : End Get
        Set(value As Boolean)
            mEliminationBitProps(1) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsCrossingSpanningEdge As Boolean
        Get
            Return mEliminationBitProps(2) : End Get
        Set(value As Boolean)
            mEliminationBitProps(2) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsCrossingHullSpanningEdge As Boolean
        Get
            Return mEliminationBitProps(3) : End Get
        Set(value As Boolean)
            mEliminationBitProps(3) = value : End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsWrongElimination As Boolean
        Get
            Return mEliminationBitProps(4) : End Get
        Set(value As Boolean)
            mEliminationBitProps(4) = value : End Set
    End Property
#End Region

#End Region

#Region "Methods"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Shadows Function Equals(other As EdgeTSP) As Boolean Implements IEquatable(Of EdgeTSP).Equals
        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Function CompareTo(other As EdgeTSP) As Integer Implements IComparable(Of EdgeTSP).CompareTo
        Throw New NotImplementedException()
    End Function
#End Region

End Class
