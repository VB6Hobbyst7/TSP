Namespace Tree

    Public Interface ITreeNode(Of T)

        Property NodeID As Integer

        Property Data As T

        Property Parent() As ITreeNode(Of T)

        Property ChildNodes() As List(Of ITreeNode(Of T))

        ReadOnly Property IsLeaf() As Boolean

        ReadOnly Property IsRoot() As Boolean

        Function GetRootNode() As ITreeNode(Of T)

        Property Depth As Byte

    End Interface
End Namespace
