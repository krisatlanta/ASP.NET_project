<%@ Page Title="修改密码" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="bookshop1._1.ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
<table table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="旧密码"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" MaxLength="20" 
            ontextchanged="TextBox1_TextChanged" Width="200px" TextMode="Password"></asp:TextBox>
        
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="新密码"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" MaxLength="20" Width="200px" 
            ontextchanged="TextBox2_TextChanged" TextMode="Password"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="确认新密码"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" MaxLength="20" Width="200px" 
            ontextchanged="TextBox3_TextChanged" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="TextBox3" ErrorMessage="确认密码必须与密码一致" 
            ValidationGroup="ChangePswValidation" ToolTip="确认密码必须与密码一致" 
            ControlToCompare="TextBox2"></asp:CompareValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="修改密码" 
        ValidationGroup="ChangePswValidation" />
</td>
<td>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            
          
                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
            </ContentTemplate>
              </asp:UpdatePanel>  
        
</td>
</tr>
</table>
</div>
</asp:Content>
