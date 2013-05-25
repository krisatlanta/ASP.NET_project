<%@ Page Title="搜索" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="bookshop1._1.search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
   <div>
       <asp:Label ID="Label1" runat="server" Text="选择搜索方式"></asp:Label></div>
   <div>
    <asp:RadioButton ID="RadioButton1" runat="server" Text="按书名" Checked="True" 
           GroupName="searchway" />
    <asp:RadioButton ID="RadioButton2" runat="server" Text="按作者" 
           GroupName="searchway"/>
    <asp:RadioButton ID="RadioButton3" runat="server" Text="按出版社" 
           GroupName="searchway"/>
    <asp:RadioButton ID="RadioButton4" runat="server" Text="按ISBN" 
           GroupName="searchway"/>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="输入搜索关键字"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="464px" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="请输入搜索关键字" ValidationGroup="key" 
            ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="Button1" runat="server" Text="搜索" ValidationGroup="key" 
            onclick="Button1_Click" />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="book_title" HeaderText="书名" ReadOnly="True" 
                    SortExpression="book_title" />
                <asp:BoundField DataField="book_author" HeaderText="作者" ReadOnly="True" 
                    SortExpression="book_author" />
                <asp:BoundField DataField="book_publisher" HeaderText="出版社" ReadOnly="True" 
                    SortExpression="book_publisher" />
                <asp:BoundField DataField="book_isbn" HeaderText="ISBN" ReadOnly="True" 
                    SortExpression="book_isbn" />
                <asp:BoundField DataField="book_price" HeaderText="价格" ReadOnly="True" 
                    SortExpression="book_price" />
                <asp:ImageField HeaderText="封面" ReadOnly="True">
                </asp:ImageField>
                <asp:HyperLinkField HeaderText="查看详细" />
            </Columns>
            <HeaderStyle BackColor="#003366" ForeColor="White" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>
