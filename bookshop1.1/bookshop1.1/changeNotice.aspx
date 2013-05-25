<%@ Page Title="修改通知" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changeNotice.aspx.cs" Inherits="bookshop1._1.Admin.changeNotice" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center"><asp:Label ID="Label3" runat="server" Text="通知内容"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="137px" 
            ontextchanged="TextBox1_TextChanged" Width="418px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="提交" />
    </div>
</asp:Content>
