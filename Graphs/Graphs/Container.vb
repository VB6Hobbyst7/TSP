Public Class Container(Of T As {IEquatable(Of T), IComparable(Of T)})

#Region "Variables"
    ReadOnly mData As List(Of T)
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Container(Of T)" /> class.
    ''' </summary>
    ''' <param name="capacity">The capacity.</param>
    Public Sub New(Optional capacity As Integer = 100)
        mData = New List(Of T)(capacity)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Container(Of T)" /> class.
    ''' </summary>
    ''' <param name="data">The data.</param>
    Public Sub New(data As IEnumerable(Of T))
        mData = data.ToList
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="indx"></param>
    ''' <returns></returns>
    Default Public ReadOnly Property ElementAt(indx As Integer) As T
        Get
            Return mData(indx) : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Data As IEnumerable(Of T)
        Get
            Return mData : End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Count As Integer
        Get
            Return mData.Count : End Get
    End Property
#End Region

#Region "Methods"
    ''' <summary>
    ''' Adds the specific node.
    ''' </summary>
    ''' <param name="elmt">The element to add.</param>
    ''' <returns></returns>
    Public Function Add(elmt As T) As Integer
        Dim retValue As Integer

        mData.Add(elmt) : retValue = Count - 1

        Return retValue
    End Function

    ''' <summary>
    ''' Removes the element at index.
    ''' </summary>
    ''' <param name="index">The element index.</param>
    Public Sub RemoveAt(index As Integer)
        mData.RemoveAt(index)
    End Sub

    ''' <summary>
    ''' Removes the element.
    ''' </summary>
    ''' <param name="elmnt">The element.</param>
    Public Function Remove(elmnt As T) As Boolean
        Return mData.Remove(elmnt)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="elmt">The element.</param>
    ''' <returns></returns>
    Public Function Contains(elmt As T) As Boolean
        Return mData.Contains(elmt)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="elmt"></param>
    ''' <returns></returns>
    Public Function GetIndex(elmt As T) As Integer
        Return mData.FindIndex(New Predicate(Of T)(Function(e) e.Equals(elmt)))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="elmt"></param>
    ''' <returns></returns>
    Public Function Find(elmt As T) As T
        Return mData.Find(New Predicate(Of T)(Function(e) e.Equals(elmt)))
    End Function
#End Region

End Class
