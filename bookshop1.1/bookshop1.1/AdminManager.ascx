<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminManager.ascx.cs" Inherits="bookshop1._1.AdminManager" %>
<div style="height: 190px; width: 186px">
<div align="center" style="margin: 30px">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/AllCustomer.aspx">查看顾客列表</asp:HyperLink>
</div>
<div align="center" style="margin: 30px">
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/AllSeller.aspx">查看商家列表</asp:HyperLink>
</div>
<div align="center" style="margin: 30px">
    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/changeNotice.aspx">通知设置</asp:HyperLink>
</div>
</div>