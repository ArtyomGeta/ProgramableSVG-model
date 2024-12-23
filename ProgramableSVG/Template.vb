''' <summary>
''' Класс шаблона для вывода на странице выбора
''' </summary>
Public Class Template

    ''' <summary>
    ''' Имя шаблона
    ''' </summary>
    Public Property Name As String
    ''' <summary>
    ''' Описание шаблона
    ''' </summary>
    Public Property Description As String
    ''' <summary>
    ''' Список переменных для страницы генерации
    ''' </summary>
    Public Property Vars As List(Of Variable)

    ''' <summary>
    ''' Класс шаблона для вывода на странице выбора
    ''' </summary>
    ''' <param name="name">Название шаблона</param>
    ''' <param name="description">Описание шаблона</param>
    Public Sub New(name As String, description As String)
        Me.Name = name
        Me.Description = description
        Vars = New List(Of Variable)
    End Sub

End Class
