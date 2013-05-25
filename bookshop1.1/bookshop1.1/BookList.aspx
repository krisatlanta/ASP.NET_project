<%@ Page Title="按类查看" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="bookshop1._1.BookList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="bookType" runat="server" Font-Size="X-Large" ForeColor="#FF9900"></asp:Label>
    </div>
    <div align="center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         EditRowStyle-BorderStyle="Dashed" EmptyDataRowStyle-BorderStyle="Dashed" 
         EnableTheming="False" 
         onselectedindexchanged="GridView1_SelectedIndexChanged" 
         style="margin-left: 2px; margin-top: 13px" Height="91px" Width="749px" 
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
</asp:Content>
