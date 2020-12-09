Imports System.Runtime.CompilerServices

Public Class ConvexHull

    Protected mEdges As Integer()
    Protected mNodes As Integer()

#Region "Constructors"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nodePath"></param>
    ''' <param name="edgePath"></param>
    Public Sub New(nodePath As IEnumerable(Of Integer), edgePath As IEnumerable(Of Integer))
        mNodes = nodePath.ToArray

        If Not edgePath Is Nothing Then
            mEdges = edgePath.ToArray
        Else
            mEdges = New Integer() {}
        End If
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property NumberNodes As Integer
        Get
            Return mNodes.Count : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property NumberEdges As Integer
        Get
            Return mEdges.Count : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Nodes As IEnumerable(Of Integer)
        Get
            Return mNodes : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Edges As IEnumerable(Of Integer)
        Get
            Return mEdges : End Get
    End Property
#End Region

#Region "Methods"
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function ContainsNode(nIndx As Integer) As Boolean
        Return mNodes.Contains(nIndx)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function ContainsEdge(eIndx As Integer) As Boolean
        Return mEdges.Contains(eIndx)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="eIndx"></param>
    ''' <returns></returns>
    Public Function EdgeNeighbors(eIndx As Integer) As Tuple(Of Integer, Integer)
        Dim retValue As Tuple(Of Integer, Integer) = Nothing

        For i = 0 To NumberEdges - 1
            If mEdges(i) = eIndx Then

                If i > 0 AndAlso i < NumberEdges - 1 Then
                    retValue = Tuple.Create(mEdges(i - 1), mEdges(i + 1))
                ElseIf i = 0 Then
                    retValue = Tuple.Create(mEdges(i + 1), mEdges(NumberEdges - 1))
                Else 'If i = Size - 1 Then
                    retValue = Tuple.Create(mEdges(NumberEdges - 2), mEdges(0))
                End If

                Exit For
            End If
        Next

        Return retValue
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nIndx"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function NeighborNodes(nIndx As Integer) As Tuple(Of Integer, Integer)
        Dim retValue As Tuple(Of Integer, Integer) = Nothing

        If NumberEdges = 0 Then
            retValue = Tuple.Create(-1, -1)
        ElseIf NumberEdges = 1 Then
            If mNodes(0) = nIndx Then
                retValue = Tuple.Create(mNodes(1), -1)
            Else
                retValue = Tuple.Create(mNodes(0), -1)
            End If
        Else
            For i = 0 To NumberEdges - 1
                If mNodes(i) = nIndx Then

                    If i > 0 AndAlso i < NumberEdges - 1 Then
                        retValue = Tuple.Create(mNodes(i - 1), mNodes(i + 1))
                    ElseIf i = 0 Then
                        retValue = Tuple.Create(mNodes(i + 1), mNodes(NumberEdges - 1))
                    Else 'If i = Size - 1 Then
                        retValue = Tuple.Create(mNodes(NumberEdges - 2), mNodes(0))
                    End If

                    Exit For
                End If
            Next
        End If

        Return retValue
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nIndx"></param>
    ''' <param name="distance"></param>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function NodesAtDistance(nIndx As Integer, distance As Integer) As Integer
        Dim retIndx As Integer
        Dim retValue As Integer

        If distance < 1 OrElse distance > NumberEdges - 1 Then
            retValue = -1
        Else
            ' Find the index of the node index
            For i = 0 To NumberEdges - 1
                If mNodes(i) = nIndx Then
                    retIndx = i + distance
                    Exit For
                End If
            Next
            ' Find the nodes at distance
            If retIndx <= NumberEdges - 1 Then
                retValue = mNodes(retIndx)
            Else
                retValue = mNodes(retIndx - NumberEdges)
            End If
        End If
        Return retValue
    End Function
#End Region

End Class
