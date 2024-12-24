#If DEBUG Then

Imports NUnit.Framework
Imports NUnit.Framework.Legacy
Imports ProgramableSVG
Imports System.IO.Abstractions.TestingHelpers

Namespace ProgramableSVGTests

    Public Class TemplatesManagerTest

        Dim Projects As List(Of Project)
        Dim mockFileSystem = New MockFileSystem()

        <SetUp>
        Public Sub Setup()

            mockFileSystem.AddFile("C:\Projects.xml", New MockFileData("<projects><project id=" & Chr(34) & "0" & Chr(34) & ">
                                                    <name>Приточная вентиляция</name>
                                                    <description>Описание приточной вентиляции</description>
                                                    <page link=" & Chr(34) & "Ссылка на шаблон" & Chr(34) & "/>
                                                    <var id=" & Chr(34) & "vent_amount" & Chr(34) & "
                                                    name=" & Chr(34) & "Количество вентиляторов" & Chr(34) & "
                                                    type=" & Chr(34) & "i" & Chr(34) & "
                                                    default=" & Chr(34) & "1" & Chr(34) & " />
                                                    </project></projects>"))

            ProjectsManager.LinkOrPathToProjectsXML = "С:\Projects.xml"
            ProjectsManager.LoadNamesAndDescriptions()

            Projects = New List(Of Project)

            For Each project As Project In ProjectsManager.Projects

                Projects.Add(ProjectsManager.LoadNameDescriptionAndVariables(project.Id))

            Next

        End Sub

        <Test>
        Public Sub ListOfTemplates_Templates_EqualTest()
            ClassicAssert.AreEqual(Projects.First.Name, "Приточная вентиляция")
        End Sub

        <Test>
        Public Sub ListOfTemplates_Vars_EqualTest()
            ClassicAssert.AreEqual(Projects.First.GlobalVars.First.Id, "vent_amount")
        End Sub

        <Test>
        Public Sub ListOfTemplates_VarsAmount_EqualTest()
            ClassicAssert.AreEqual(Projects.First.GlobalVars.Count, 1)
        End Sub

    End Class

End Namespace

#End If