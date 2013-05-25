<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="bookshop1._1.About" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>网站使用规则：<br />
        1.非注册用户不能进行书的购买功能

     
        <br />
        2.注册分为顾客注册和商家注册，注册要填写一些个人信息<br />
        3.顾客可以购买商家上架的书籍<br />
        4.商家可以添加书本，修改书本信息和上下架一本书<br />
        5.顾客和商家可以修改自己的信息<br />
        6.商家注册后需要管理员审核才能使用管理功能（添加书目，上下架书，修改书信息）<br />

    </div>
</asp:Content>
