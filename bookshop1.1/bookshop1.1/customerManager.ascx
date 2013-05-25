<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="customerManager.ascx.cs" Inherits="bookshop1._1.customerManager" %>
<div style="height: 221px; width: 217px">
<div align="center" style="margin: 30px;">
    <asp:HyperLink ID="HyperLink1" 
        runat="server" NavigateUrl="~/CartList.aspx">购物车</asp:HyperLink></div>

<div align="center" style="margin: 30px"><asp:HyperLink ID="HyperLink2" 
        runat="server" NavigateUrl="~/changeUserInfo.aspx">个人查看信息修改</asp:HyperLink></div>
<div align="center" style="margin: 30px">
    <asp:HyperLink ID="HyperLink3" 
        runat="server" NavigateUrl="~/customerOrder.aspx">查看订单</asp:HyperLink></div>
<div align="center" style="margin: 30px"><asp:HyperLink ID="HyperLink4" 
        runat="server" NavigateUrl="~/ChangePassword.aspx">修改密码</asp:HyperLink></div>
    
</div>
