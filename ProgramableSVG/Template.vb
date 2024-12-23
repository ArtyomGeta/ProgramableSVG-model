''' <summary>
''' ����� ������� ��� ������ �� �������� ������
''' </summary>
Public Class Template

    ''' <summary>
    ''' ��� �������
    ''' </summary>
    Public Property Name As String
    ''' <summary>
    ''' �������� �������
    ''' </summary>
    Public Property Description As String
    ''' <summary>
    ''' ������ ���������� ��� �������� ���������
    ''' </summary>
    Public Property Vars As List(Of Variable)

    ''' <summary>
    ''' ����� ������� ��� ������ �� �������� ������
    ''' </summary>
    ''' <param name="name">�������� �������</param>
    ''' <param name="description">�������� �������</param>
    Public Sub New(name As String, description As String)
        Me.Name = name
        Me.Description = description
        Vars = New List(Of Variable)
    End Sub

End Class
