<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="sellerOrder.aspx.cs" Inherits="bookShop.UI.sellerOrder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
    
        <asp:Button ID="Button1" runat="server" Text="显示所有订单" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="显示未发货订单" 
            onclick="Button2_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="order_form_id" HeaderText="订单号" ReadOnly="True" 
                    SortExpression="order_form_id" />
                <asp:BoundField DataField="customer_name" HeaderText="买家" ReadOnly="True" 
                    SortExpression="customer_name" />
                <asp:BoundField DataField="customer_address" HeaderText="买家地址" ReadOnly="True" 
                    SortExpression="customer_address" />
                <asp:BoundField DataField="order_form_time" HeaderText="订单时间" ReadOnly="True" 
                    SortExpression="order_form_time" />
                <asp:BoundField DataField="order_form_state" HeaderText="订单状态" ReadOnly="True" 
                    SortExpression="order_form_state" />
                <asp:ButtonField ButtonType="Button" CommandName="detail" HeaderText="详细内容" 
                    Text="详细内容" />
            </Columns>
        </asp:GridView>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView2_RowCommand">
            <Columns>
                <asp:BoundField DataField="order_form_id" HeaderText="订单号" ReadOnly="True" 
                    SortExpression="order_form_id" />
                <asp:BoundField DataField="customer_name" HeaderText="买家" ReadOnly="True" 
                    SortExpression="customer_name" />
                <asp:BoundField DataField="customer_address" HeaderText="买家地址" ReadOnly="True" 
                    SortExpression="customer_address" />
                <asp:BoundField DataField="order_form_time" HeaderText="订单时间" ReadOnly="True" 
                    SortExpression="order_form_time" />
                <asp:BoundField DataField="order_form_state" HeaderText="订单状态" ReadOnly="True" 
                    SortExpression="order_form_state" />
                <asp:ButtonField ButtonType="Button"  HeaderText="发货" 
                    Text="发货" CommandName="sentOrder" />
                <asp:ButtonField ButtonType="Button" CommandName="detail" HeaderText="详细内容" 
                    Text="详细内容" />
            </Columns>
        </asp:GridView>
    
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="book_id" HeaderText="图书编号" ReadOnly="True" 
                    SortExpression="book_id" />
                <asp:BoundField DataField="book_title" HeaderText="书名" ReadOnly="True" 
                    SortExpression="book_title" />
                <asp:BoundField DataField="order_amount" HeaderText="购买量" ReadOnly="True" 
                    SortExpression="order_amount" />
                <asp:BoundField DataField="order_single_price" HeaderText="购买价格" 
                    ReadOnly="True" SortExpression="order_single_price" />
            </Columns>
        </asp:GridView>
    
    </div>
</asp:Content>
