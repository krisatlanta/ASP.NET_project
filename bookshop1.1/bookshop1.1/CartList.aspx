<%@ Page Language="C#"MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="CartList.aspx.cs" Inherits="bookShop.UI.CartList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div align="center">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" EmptyDataText="没有记录" >
            <Columns>
                <asp:BoundField DataField="book_id" HeaderText="图书编号" ReadOnly="True" 
                    SortExpression="book_id" />
                <asp:BoundField DataField="book_title" HeaderText="书名" ReadOnly="True" 
                    SortExpression="book_title" />
                <asp:BoundField DataField="cart_amount" HeaderText="购买数量" 
                    SortExpression="cart_amount" />
                <asp:BoundField DataField="book_price" HeaderText="单价" ReadOnly="True" 
                    SortExpression="book_price" />
                
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    CausesValidation="False"/>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" 
                    CausesValidation="False" EditText="更改数量"/>
                
            </Columns>
            <EmptyDataRowStyle BorderStyle="None" />
            <HeaderStyle BackColor="#003366" BorderColor="Blue" BorderStyle="Dashed" 
                ForeColor="White" />
        </asp:GridView>
    
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="提交购物车" />
    <asp:Label ID="Label1" runat="server" Text="总价："></asp:Label>
    <%=computeTotalCost()%>元
    
</asp:Content>
