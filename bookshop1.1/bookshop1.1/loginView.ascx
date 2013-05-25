<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="loginView.ascx.cs" Inherits="bookshop1._1.loginView" %>
<div align="center" style="width: 231px; height: 32px; float: right;">
    欢迎,<asp:HyperLink ID="HyperLink1" runat="server" 
        ClientIDMode="AutoID" ></asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Register.aspx">新用户注册</asp:HyperLink>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="点击登出" />
</div>