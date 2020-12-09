Public Class Partition

    Dim cutValue As Single
    Dim set1 As List(Of Integer)
    Dim set2 As List(Of Integer)
    'Dim excludeSet As List(Of Tuple(Of Integer, Integer))

    Public Sub New(cutValue As Single,
                   set1 As List(Of Integer),
                   set2 As List(Of Integer))
        'excludeSet As List(Of Tuple(Of Integer, Integer)),

        'Me.excludeSet = excludeSet
        Me.cutValue = cutValue
        Me.set1 = set1
        Me.set2 = set2
    End Sub

    Public Function Run() As List(Of Tuple(Of Integer, Integer))
        Dim retValue As New List(Of Tuple(Of Integer, Integer))

        If set1.Count <= set2.Count Then
            For Each n1 In set1
                For Each n2 In set2
                    'If Distance(n1, n2) = cutValue Then
                    '    retValue.Add(Tuple.Create(n1, n2))
                    'End If
                Next
            Next
        Else

        End If

        Return retValue
    End Function
End Class
