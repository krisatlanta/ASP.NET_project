<%@ Page Title="所有顾客列表" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AllCustomer.aspx.cs" Inherits="bookshop1._1.Admin.AllCustomer" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="customer_id" HeaderText="ID">
            <HeaderStyle BackColor="#003366" />
            </asp:BoundField>
            <asp:BoundField HeaderText="姓名" />
            <asp:BoundField DataField="customer_phone" HeaderText="电话" />
            <asp:BoundField DataField="customer_eamil" HeaderText="邮箱" />
            <asp:BoundField DataField="customer_address" HeaderText="地址" />
        </Columns>
        <HeaderStyle BackColor="#003366" />
    </asp:GridView>
    </div>
</asp:Content>
