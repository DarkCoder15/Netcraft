Option Explicit Off
Imports NCore.netcraft.server.api
Public Class Plugin
    Inherits NCore.Plugin
    Friend Shared instance As Plugin
    Shared Function GetInstance() As Plugin
        Return instance
    End Function
    Const DEF_CONFIG As String = "enable-automod=1"
    Function Create() As NCore.Plugin
        SetOptions("AdminUtilsN", "������� ��� ��������������� �������� NetCraft.", "1.0", {"GladCypress3030"})
        Plugin.instance = Me
        Return Me
    End Function
    Friend conf As Config
    Friend passwords As Config
    Dim automodInstance As Automod
    Function GetAutomod()
        Return automodInstance
    End Function
    Public Overrides Function OnLoad() As String
        GetLogger.Info("������ ��������.")
        If IO.Directory.Exists("./data") Then
            If Not IO.Directory.Exists("./data/AdminUtilsN") Then
                IO.Directory.CreateDirectory("./data/AdminUtilsN")
                IO.File.WriteAllText("./data/AdminUtilsN/config.txt", DEF_CONFIG, Text.Encoding.UTF8)
            End If
            conf = Config.Read("./data/AdminUtilsN/config.txt")
        Else
            Return "������ ��� �������� �������: �� ������� ���������� ����� data."
        End If

        If conf.Parse("enable-automod") = "1" Then
            automodInstance = New Automod
            GetLogger.Info("Auto-mod enabled!")
        End If
        Return Nothing
    End Function
    Sub AdminMessage(a As String)
        For Each b In Netcraft.GetOnlinePlayers
            If b.IsAdmin Then
                b.Chat(a)
            End If
        Next
        GetLogger.Info(a)
    End Sub
    Public Overrides Sub OnUnload()
        GetLogger.Info("������ ��������.")
    End Sub
End Class
