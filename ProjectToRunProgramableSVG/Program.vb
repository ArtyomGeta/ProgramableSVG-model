Imports System
Imports System.Xml
Imports ProgramableSVG

Module Program

    Sub Main(args As String())

        Const PathToTemplates = "C:\Users\silen\source\repos\ProgramableSVG\ProgramableSVG\templates.xml"

        TemplatesManager.Init(PathToTemplates)

        For Each template In TemplatesManager.Templates

            Console.WriteLine(template.Name)
            Console.WriteLine(template.Description)

            For Each var In template.Vars

                Console.WriteLine(vbTab & var.Name)

            Next

        Next

    End Sub

End Module
