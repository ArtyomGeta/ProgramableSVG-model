''' <summary>
''' ����� ������� ��� ������ �� �������� ������
''' </summary>
Public Class Project

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
    Public Property GlobalVars As List(Of Variable)
    Public Property Id As Integer

    ''' <summary>
    ''' ����� ������� ��� ������ �� �������� ������
    ''' </summary>
    ''' <param name="name">�������� �������</param>
    ''' <param name="description">�������� �������</param>
    Public Sub New(id As Integer, name As String, description As String)
        Me.Id = id
        Me.Name = name
        Me.Description = description
        GlobalVars = New List(Of Variable)
    End Sub

End Class
