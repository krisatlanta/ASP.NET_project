<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellerManager.ascx.cs" Inherits="bookshop1._1.SellerManager" %>
<div style = "height:255px; width:217px">
<div style="margin: 30px;" align="center">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/changeUserInfo.aspx">个人信息查看修改</asp:HyperLink>
</div>
<div align="center" style="margin: 30px">

    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/BookList.aspx">管理书籍</asp:HyperLink>

</div>
<div align="center" style="margin: 30px">

    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/sellerOrder.aspx">查看订单</asp:HyperLink>

</div>
<div align="center" style="margin: 30px"><asp:HyperLink ID="HyperLink4" 
        runat="server" NavigateUrl="~/ChangePassword.aspx">修改密码</asp:HyperLink></div>
        <div align="center" style="margin: 30px">
            <asp:HyperLink ID="HyperLink5" 
        runat="server" NavigateUrl="~/AddBook.aspx">添加新书</asp:HyperLink></div>
</div>
</div>