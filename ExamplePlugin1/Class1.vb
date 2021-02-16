Imports NCore
Imports NCore.netcraft.server.api
Public Class Plugin
    Inherits NCore.Plugin

    Public Overrides Sub OnUnload()
        GetLogger.Warning("Example plugin �����������")
    End Sub

    Public Overrides Function Create() As NCore.Plugin
        SetOptions("ExamplePlugin1", "Example plugin", "0.1", {"DarkCoder15"})
        Return Me
    End Function

    Public Overrides Function OnLoad() As String
        GetLogger.Info("���������")
        GetLogger.Warning("�������� � ��������")
        GetLogger.Severe("=)")

        '������� ���������� �������, ��������, ����� ���������� ����� ��� � ��� ����� '������, {��� ������}'
        AddHandler NCSApi.PlayerJoinEvent, AddressOf JoinEvent

        '������� ���������� �������, ��������, ����� ����� ����� � ��� "1" ��� ���������� �� "0"
        AddHandler NCSApi.PlayerChatEvent, AddressOf ChatEvent
        Return Nothing
    End Function

    Protected Async Function JoinEvent(e As events.PlayerJoinEventArgs) As Task
        Dim p = e.GetPlayer
        Await p.Chat($"������, {p.Username}")
    End Function

    Protected Async Function ChatEvent(e As events.PlayerChatEventArgs) As Task
        Dim p = e.GetPlayer
        If e.GetMessage = "1" Then
            e.SetMessage("0")
        End If
    End Function
End Class
