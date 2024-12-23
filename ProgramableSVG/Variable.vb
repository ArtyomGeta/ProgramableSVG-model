''' <summary>
''' Класс переменной для отображения на странице генерации
''' </summary>
Public Class Variable
    ''' <summary>
    ''' Имя переменной, которое будет выведено пользователю
    ''' </summary>
    Public Property Name() As String
    ''' <summary>
    ''' Тип данных этой переменной. Например
    ''' <list type="bullet"><item>i - int</item><item>s - string</item><item>b - boolean</item></list>
    ''' </summary>
    Public Property Type() As String
    ''' <summary>
    ''' ИД переменной. Не будет выведено пользователю
    ''' </summary>
    Public Property Id() As String
    ''' <summary>
    ''' Значение переменной по умолчанию
    ''' </summary>
    ''' <returns></returns>
    Public Property DefaultValue() As String

    ''' <summary>
    ''' Класс переменной для отображения на странице генерации.
    ''' </summary>
    ''' <param name="name">Название переменной</param>
    ''' <param name="type">Тип данных переменной</param>
    ''' <param name="id">ИД переменной (не будет выведено пользователю)</param>
    ''' <param name="defaultValue">Значение переменной по умолчанию</param>
    Public Sub New(name As String, type As String, id As String, defaultValue As String)
        Me.Name = name
        Me.Type = type
        Me.Id = id
        Me.DefaultValue = defaultValue
    End Sub

End Class
