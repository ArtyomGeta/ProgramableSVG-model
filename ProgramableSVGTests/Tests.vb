Imports NUnit.Framework
Imports NUnit.Framework.Legacy
Imports ProgramableSVG

Namespace ProgramableSVGTests

    Public Class TemplatesManagerTest

        Dim Templates As List(Of Template)

        <SetUp>
        Public Sub Setup()

            TemplatesManager.Init("C:\Users\silen\source\repos\ProgramableSVG\ProjectToRunProgramableSVG\templates_test.xml")
            Templates = TemplatesManager.Templates

        End Sub

        <Test>
        Public Sub ListOfTemplates_Templates_EqualTest()
            ClassicAssert.AreEqual(Templates.First.Name, "Приточная вентиляция")
        End Sub

        <Test>
        Public Sub ListOfTemplates_Vars_EqualTest()
            ClassicAssert.AreEqual(Templates.First.Vars.First.Id, "vents_amount")
        End Sub

        <Test>
        Public Sub ListOfTemplates_VarsAmount_EqualTest()
            ClassicAssert.AreEqual(Templates.First.Vars.Count, 2)
        End Sub

    End Class

End Namespace
