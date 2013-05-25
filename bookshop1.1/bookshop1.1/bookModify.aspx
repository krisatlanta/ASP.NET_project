<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookModify.aspx.cs" Inherits="bookshop1._1.Seller.bookModify" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td width="10%" align="center">
                
                <asp:Label ID="booknameLable" runat="server" Text="书名"></asp:Label>
            </td>
            <td width="50%">
                
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="20" Width="343px"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="书名不能为空" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td width="10%" align="center">
                <asp:Label ID="authorLable" runat="server" Text="作者"></asp:Label>
               
            </td>
            <td>
                
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="20" Width="343px"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="作者不能为空" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                
            </td align="center">
        </tr>
        <tr>
            <td align="center" width="10%">
               
                <asp:Label ID="publisherLable" runat="server" Text="出版社"></asp:Label>
            </td>
            <td>
                
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="20" Width="343px"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="出版社不能为空" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                <asp:Label ID="isbnLabel" runat="server" Text="ISBN"></asp:Label>
                
            </td>
            <td>
                
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="20" Width="343px"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="ISBN不能为空" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                <asp:Label ID="Label2" runat="server" Text="书籍详细介绍"></asp:Label>
                
            </td>
            <td>
                
                <asp:TextBox ID="TextBox5" runat="server" Height="139px" MaxLength="255" 
                    Width="368px"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="书籍详细介绍不能为空" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                <asp:Label ID="Label3" runat="server" Text="书价"></asp:Label>
                
            </td>
            <td>
                
                <asp:TextBox ID="TextBox6" runat="server" MaxLength="3" Width="60px"></asp:TextBox>
                .<asp:TextBox ID="TextBox7" runat="server" MaxLength="2" Width="45px"></asp:TextBox>
                元（价格需小于999.99）</td>
            <td>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox6" ErrorMessage="请输入数字" 
                    ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="请输入数字" ControlToValidate="TextBox7" 
                    ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                <asp:Label ID="Label4" runat="server" Text="是否上架"></asp:Label>
                
            </td>
            <td>
                
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                    GroupName="shelfRadio" Text="是" />
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="shelfRadio" 
                    Text="否" />
                
            </td>
            <td>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                分类</td>
            <td>
                
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="bookshopsrc" 
                    DataTextField="type_name" DataValueField="type_name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="bookshopsrc" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [type_name] FROM [type_list]" 
                    onselecting="bookshopsrc_Selecting"></asp:SqlDataSource>
                
            </td>
            <td>
                
            </td>
        </tr>
          <tr>
            <td align="center">
                
                <asp:Label ID="Label5" runat="server" Text="书本数量"></asp:Label>
                
            </td>
            <td>
                
                <asp:TextBox ID="TextBox8" runat="server" MaxLength="10"></asp:TextBox>
                
            </td>
            <td>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ErrorMessage="请输入整数" ControlToValidate="TextBox8" 
                    ValidationExpression="^-?\d+$"></asp:RegularExpressionValidator>
                
            </td>
        </tr>

        <tr>
        <td>图片上传</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td>&nbsp;<asp:Image ID="Image1" runat="server" Height="193px" Width="392px" />
            </td>
        </tr>
        <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="修改" Height="28px" 
                onclick="Button1_Click" Width="106px" />
        </td>
        <td>
            &nbsp;</td>
        </tr>
        </table> 
</asp:Content>
