Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml

Public MustInherit Class TemplatesManager

    ''' <summary>
    ''' Лист шаблонов. Изначально пустой. Заполняется <see cref="Init(String)"/>
    ''' </summary>
    Public Shared Templates As List(Of Template)

    ''' <summary>
    ''' Заполняет лист Templates
    ''' </summary>
    ''' <param name="pathToTemplatesXML">Путь к файлу, в котором записаны шаблоны</param>
    ''' <seealso cref="Templates"/>
    Public Shared Sub Init(pathToTemplatesFolder As String)

        Dim folders As String()

        If Directory.Exists(pathToTemplatesFolder) Then
            folders = Directory.GetDirectories(pathToTemplatesFolder)

        ElseIf Uri.TryCreate(pathToTemplatesFolder, UriKind.Absolute, Nothing) Then
            ' URL репозитория GitHub (замените на ваш)
            Dim repoUrl As String = pathToTemplatesFolder
            ' Путь для сохранения ZIP-файла
            Dim zipFilePath As String = "C:\Users\silen\source\repos\ProgramableSVG\ProgramableSVG\Templates.zip"
            ' Путь для распаковки
            Dim extractPath As String = "C:\Users\silen\source\repos\ProgramableSVG\ProgramableSVG\"

            ' Скачиваем ZIP-файл
            Using client As New WebClient()
                Try
                    Console.WriteLine("Скачивание репозитория...")
                    client.DownloadFile(repoUrl, zipFilePath)
                    Console.WriteLine("Скачивание завершено.")
                Catch ex As Exception
                    Console.WriteLine("Ошибка при скачивании: " & ex.Message)
                    Return
                End Try
            End Using

            ' Распаковываем ZIP-файл
            Try
                Console.WriteLine("Распаковка ZIP-файла...")
                ZipFile.ExtractToDirectory(zipFilePath, extractPath)
                Console.WriteLine("Распаковка завершена.")
            Catch ex As Exception
                Console.WriteLine("Ошибка при распаковке: " & ex.Message)
                Return
            End Try

            ' Удаляем ZIP-файл после распаковки
            Try
                File.Delete(zipFilePath)
                Console.WriteLine("ZIP-файл удален.")
            Catch ex As Exception
                Console.WriteLine("Ошибка при удалении ZIP-файла: " & ex.Message)
            End Try

            folders = Directory.GetDirectories(extractPath)

        Else
            Throw New Exception("Не удалось установить, является ли " & pathToTemplatesFolder & " локальной папкой, или ссылкой на zip-файл")
        End If

        Templates = New List(Of Template)

        'Перебираем папки внутри Templates
        For Each folder As String In folders

            Dim folderName As String = Path.GetFileName(folder)

            Dim xmlFilePath As String = Path.Combine(folder, "info.xml")

            'Если info.xml не найден
            If Not File.Exists(xmlFilePath) Then
                Throw New FileNotFoundException("info.xml is not found in " & folder)
            End If

            Dim doc As XmlDocument
            Dim templates_nodes As XmlNode

            doc = New XmlDocument()

            Try
                'Читаем info.xml
                doc.Load(xmlFilePath)

                For Each templates_nodes In doc.SelectNodes("/template")

                    Dim template = New Template(folderName,
                                                templates_nodes.Attributes.GetNamedItem("description").Value)

                    For Each var_node As XmlNode In templates_nodes.SelectNodes("var")
                        'Читаем переменные
                        Dim var = New Variable(var_node.Attributes.GetNamedItem("name").InnerText,
                                               var_node.Attributes.GetNamedItem("type").InnerText,
                                               var_node.Attributes.GetNamedItem("id").InnerText,
                                               var_node.Attributes.GetNamedItem("default").InnerText)

                        template.Vars.Add(var)

                    Next

                    Templates.Add(template)

                Next

            Catch errorVariable As Exception

                Console.Write(errorVariable.ToString())

            End Try

        Next


    End Sub

End Class
