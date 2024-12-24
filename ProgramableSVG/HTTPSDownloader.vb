Imports System.IO
Imports System.IO.Abstractions
Imports System.Net.Http
Imports System.Text

Public MustInherit Class HTTPSDownloader

    ''' <summary>
    ''' Загружает файл по ссылке
    ''' </summary>
    ''' <param name="link">ссылка на файл</param>
    ''' <returns>содержимое загруженного файла</returns>
    ''' <example>
    ''' Task.WaitAll(DownloadToString("https://example.com/file.txt"))
    ''' </example>
    Public Shared Async Function DownloadToString(link As String) As Task(Of String)
        Dim content As String

        Using client As New HttpClient()
            content = Await client.GetStringAsync(link)
        End Using

        Return content
    End Function

    Public Shared Function LoadXMLListOfProjects(path As String) As String
        Return File.ReadAllText(path)
    End Function

    Public Shared Function DownloadXMLListOfProjects() As String
        If ProjectsManager.LinkOrPathToProjectsXML Is Nothing Then
            Throw New Exception("Ссылка на Projects.xml не указана. Заполните LinkOrPathToProjectsXML.")
        End If
        Return Task.WaitAny(DownloadToString(ProjectsManager.LinkOrPathToProjectsXML))
    End Function

#If DEBUG Then
    Public Shared Function DownloadXMLListOfProjectsTest() As String
        Return "<projects><project id=" & Chr(34) & "0" & Chr(34) & ">
<name>Приточная вентиляция</name>
<description>Описание приточной вентиляции</description>
<page link=" & Chr(34) & "Ссылка на шаблон схемы автоматизации" & Chr(34) & "/>
<var id=" & Chr(34) & "vent_amount" & Chr(34) & "
name=" & Chr(34) & "Количество вентиляторов" & Chr(34) & "
type=" & Chr(34) & "i" & Chr(34) & "
default=" & Chr(34) & "1" & Chr(34) & " />
</project></projects>"
    End Function
#End If


End Class