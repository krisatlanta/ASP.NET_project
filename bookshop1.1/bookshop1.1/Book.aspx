<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="bookshop1._1.Book" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div  >
    <table width=100% style="height: 469px">
    	<tr height=335px>
    		<td width=40%>
            <!-- 商品图片 -->
            <asp:Image ID="Image1" runat="server" Height="332px" Width="295px" />
            </td>
            <td width=60%>
            <!-- 商品简介信息 -->
            <table border="0" cellspacing="0" cellpadding="0" width="100%" height=335px>
            <div>
                <asp:Label ID="Label2" runat="server" Text="对不起，这本书已下架" Visible="False" 
                    Font-Size="Large" ForeColor="Red"></asp:Label></div>
            <tr><td width=15%>商品名称</td><td><div class="bookName">
                <asp:Label ID="bookNameLabel" runat="server"></asp:Label>
                </div></td></tr>   
            <tr><td width=15%>商品价格</td><td><div class="bookName"><!--在此输入商品价格 -->
                <asp:Label ID="priceLabel" runat="server"></asp:Label>
                </div></td></tr>  
            <tr><td width=15%>库存量</td><td><div class="bookName">
                <asp:Label ID="amountLabel" runat="server"></asp:Label>
                </div></td></tr>
                 <tr><td width=15%>作者</td><td><div class="bookName">
                <asp:Label ID="authorLabel" runat="server"></asp:Label>
                </div></td></tr>
                 <tr><td width=15%>出版社</td><td><div class="bookName">
                <asp:Label ID="pubLabel" runat="server"></asp:Label>
                </div></td></tr>
                <tr><td width=15%>ISBN</td><td><div class="bookName">
                <asp:Label ID="isbnLabel" runat="server"></asp:Label>
                </div></td></tr>
                <tr><td width=15%>类别</td><td><div class="bookName">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                </div></td></tr>
            <tr> <td width=15%>详细介绍</td><td>
                <asp:Literal ID="infoLiteral" runat="server"></asp:Literal></td></tr>
            </table>
                <asp:Button ID="Button1" runat="server" Text="加入购物车" Height="27px" 
                    Width="142px" onclick="Button1_Click" />
            </table>
            </div>
            
</asp:Content>
