<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bookshop1._1.Default" %>



<%@ Register src="customerManager.ascx" tagname="customerManager" tagprefix="uc1" %>
<%@ Register src="SellerManager.ascx" tagname="SellerManager" tagprefix="uc2" %>
<%@ Register src="AdminManager.ascx" tagname="AdminManager" tagprefix="uc3" %>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" 
        frame="border">
        
 <tr>
 <td class="style1">
 <div class="list" align="center" >
 <h3>书籍分类</h3>
 <div align="left">
 <ul>
    
  	<li value="1"><a href="BookList.aspx?typeid=1">文学</a></li>
    <li value="2"><a href="BookList.aspx?typeid=2">少儿</a></li>
    <li value="3"><a href="BookList.aspx?typeid=3">管理</a></li>
    <li value="4"><a href="BookList.aspx?typeid=4">励志与成功</a></li>
    <li value="5"><a href="BookList.aspx?typeid=5">人文社科</a></li>
    <li value="6"><a href="BookList.aspx?typeid=6">生活</a></li>
    <li value="7"><a href="BookList.aspx?typeid=7">艺术学</a></li>
    <li value="8"><a href="BookList.aspx?typeid=8">科技</a></li>
    <li value="9"><a href="BookList.aspx?typeid=9">计算机与互联网</a></li>
    <li value="10"><a href="BookList.aspx?typeid=10">教育</a></li>
    <li value="11"><a href="BookList.aspx?typeid=11">期刊</a></li>
 </ul>
 </div>
 </div>
 </td>
 <td>
 <div align="left" style="margin: 10px; position: inherit;">
     <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="最新添加的书"></asp:Label>
 </div>
 <div  align="left">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         EditRowStyle-BorderStyle="Dashed" EmptyDataRowStyle-BorderStyle="Dashed" 
         EnableTheming="False" 
         onselectedindexchanged="GridView1_SelectedIndexChanged" 
         style="margin-left: 2px; margin-top: 13px" Height="91px" Width="609px" 
         ShowHeaderWhenEmpty="True">
         <Columns>
             <asp:BoundField DataField="book_title" HeaderText="书名" ReadOnly="True" 
                 SortExpression="book_title" />
             <asp:BoundField DataField="book_author" HeaderText="作者" ReadOnly="True" 
                 SortExpression="book_author" />
             <asp:BoundField DataField="book_publisher" HeaderText="出版社" ReadOnly="True" 
                 SortExpression="book_publisher" />
             <asp:BoundField DataField="book_price" HeaderText="价格" ReadOnly="True" 
                 SortExpression="book_price" />
             <asp:ImageField HeaderText="封面" ReadOnly="True" DataImageUrlField="book_image">
             </asp:ImageField>
             <asp:HyperLinkField DataNavigateUrlFormatString="Book.aspx?id={0}" 
                 HeaderText="查看详细" DataNavigateUrlFields="book_id" 
                 DataTextFormatString="查看这本书" Text="查看这本书" />
         </Columns>

<EditRowStyle BorderStyle="Dashed"></EditRowStyle>

<EmptyDataRowStyle BorderStyle="Dashed"></EmptyDataRowStyle>
         <HeaderStyle BackColor="#003366" ForeColor="White" />
     </asp:GridView>
 </div>
 
</td>
<td>
    <uc1:customerManager ID="customerManager1" runat="server" Visible="False" />
    <uc2:SellerManager ID="SellerManager1" runat="server" Visible="False" />
    <br />
    <uc3:AdminManager ID="AdminManager1" runat="server" Visible="False" />
</td>
 </tr>
 </table>
 

</asp:Content>