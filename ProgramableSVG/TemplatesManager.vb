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
    Public Shared Sub Init(pathToTemplatesXML As String)

        Templates = New List(Of Template)

        Try

            Dim doc As XmlDocument
            Dim templates_nodes As XmlNode

            doc = New XmlDocument()

            doc.Load(pathToTemplatesXML)

            For Each templates_nodes In doc.SelectNodes("/templates/template")

                Dim template = New Template(templates_nodes.Attributes.GetNamedItem("name").Value,
                                            templates_nodes.Attributes.GetNamedItem("description").Value)

                For Each var_node As XmlNode In templates_nodes.SelectNodes("var")

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

    End Sub

End Class
