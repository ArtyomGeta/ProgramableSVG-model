#If DEBUG Then

Imports System
Imports System.IO
Imports System.Xml
Imports ProgramableSVG

Module Program

    Sub Main(args As String())

        ProjectsManager.LinkOrPathToProjectsXML = "C:\Users\silen\OneDrive\Документы\HomeWork\Projects.xml"
        ProjectsManager.LoadNamesAndDescriptions()

        Dim Projects = New List(Of Project)

        For Each project In ProjectsManager.Projects

            Console.WriteLine(project.Name)
            Console.WriteLine(project.Description)

            Projects.Add(ProjectsManager.LoadNameDescriptionAndVariables(project.Id))

            For Each var As Variable In Projects.Last.GlobalVars
                Console.WriteLine(var.Id)
            Next


        Next

    End Sub

End Module

#End If