Imports System.IO
Imports System.IO.Abstractions
Imports System.IO.Compression
Imports System.Net
Imports System.Xml

Public MustInherit Class ProjectsManager

    Public Shared Projects As List(Of Project)
    Public Shared LinkOrPathToProjectsXML As String

    ''' <summary>
    ''' Заполняет лист Projects объектами, содержащими только названия и описания
    ''' </summary>
    ''' <param name="pathToTemplatesXML">Путь к файлу, в котором записаны шаблоны</param>
    ''' <seealso cref="Projects"/>
    Public Shared Sub LoadNamesAndDescriptions()

        If Projects Is Nothing Then
            Projects = New List(Of Project)
        End If

        For Each projectNode As XmlNode In GetProjectNodes()

            Projects.Add(New Project(Convert.ToInt32(projectNode.Attributes("id").InnerText),
                                     projectNode.SelectSingleNode("name").InnerText,
                                     projectNode.SelectSingleNode("description").InnerText))
        Next


    End Sub

    ''' <summary>
    ''' Обрабатывает строку из Projects.xml, и возвращает в формате XMLNodeList
    ''' </summary>
    ''' <returns>Содержимое Projects.xml в удобном формате</returns>
    Private Shared Function GetProjectNodes() As XmlNodeList

        If LinkOrPathToProjectsXML Is Nothing Then
            Throw New Exception("Ссылка на Projects.xml не указана. Заполните LinkOrPathToProjectsXML.")
        End If

        Dim XMLListOfProjects As String
        If LinkOrPathToProjectsXML.StartsWith("https") Then
            XMLListOfProjects = HTTPSDownloader.DownloadXMLListOfProjects(LinkOrPathToProjectsXML)
        Else
            XMLListOfProjects = HTTPSDownloader.LoadXMLListOfProjects(LinkOrPathToProjectsXML)
        End If

        Dim doc As XmlDocument

        doc = New XmlDocument()

        Try

            doc.LoadXml(XMLListOfProjects)
            Return doc.SelectNodes("/projects/project")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Читает содержимое Projects.xml и возвращает объект Project только с именем и описанием
    ''' </summary>
    ''' <param name="id">ИД нужного проекта</param>
    ''' <returns>Найденный проект</returns>
    Public Shared Function LoadNameAndDescription(id As Int32) As Project

        Dim projectNode As XmlNode

        Try

            For Each projectNode In GetProjectNodes()

                If Convert.ToInt32(projectNode.Attributes("id").InnerText) <> id Then
                    Continue For
                End If

                Return New Project(Convert.ToInt32(projectNode.Attributes("id").InnerText),
                                         projectNode.SelectSingleNode("name").InnerText,
                                         projectNode.SelectSingleNode("description").InnerText)

            Next

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Throw New Exception("Проект с ИД " & id & " не найден")
    End Function

    ''' <summary>
    ''' Читает Projects.xml и возвращает проект с заполненными именем, описанием и списком переменных
    ''' </summary>
    ''' <param name="id">ИД нужного проекта</param>
    ''' <returns>Нужный проект с заполнеными именем, описанием и списком переменных</returns>
    Public Shared Function LoadNameDescriptionAndVariables(id As Int32) As Project

        Dim projectNode As XmlNode

        Try

            For Each projectNode In GetProjectNodes()

                If Convert.ToInt32(projectNode.Attributes("id").InnerText) <> id Then
                    Continue For
                End If

                Dim project = New Project(Convert.ToInt32(projectNode.Attributes("id").InnerText),
                                         projectNode.SelectSingleNode("name").InnerText,
                                         projectNode.SelectSingleNode("description").InnerText)

                For Each variableNode As XmlNode In projectNode.SelectNodes("var")

                    project.GlobalVars.Add(New Variable(variableNode.Attributes("name").InnerText,
                                                        variableNode.Attributes("type").InnerText,
                                                        variableNode.Attributes("id").InnerText,
                                                        variableNode.Attributes("default").InnerText))
                Next

                Return project

            Next

        Catch ex As XmlException
            Console.WriteLine(ex.Message)
        End Try
        Throw New Exception("Проект с ИД " & id & " не найден")

    End Function


End Class
