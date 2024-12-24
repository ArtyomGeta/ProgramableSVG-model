''' <summary>
''' Класс шаблона для вывода на странице выбора
''' </summary>
Public Class Project

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
    Public Property GlobalVars As List(Of Variable)
    Public Property Id As Integer

    ''' <summary>
    ''' Класс шаблона для вывода на странице выбора
    ''' </summary>
    ''' <param name="name">Название шаблона</param>
    ''' <param name="description">Описание шаблона</param>
    Public Sub New(id As Integer, name As String, description As String)
        Me.Id = id
        Me.Name = name
        Me.Description = description
        GlobalVars = New List(Of Variable)
    End Sub

End Class
