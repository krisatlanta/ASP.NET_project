<%@ Page Title="登陆" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bookshop1._1.Login" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="login">
<fieldset class="login">
<legend>登录</legend>
<table border="0"  width="95%"  >

        <tr>
        <div>
        <td width=10% align="right"><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label></td>
                        <td><asp:TextBox ID="UserName" runat="server" CssClass="textEntry" 
                                ontextchanged="UserName_TextChanged" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                             CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                             ValidationGroup="LoginUserValidationGroup">必须填写“用户名”</asp:RequiredFieldValidator></td>
           </div>    
         </tr>
         <tr  height=15%>
         <div>
         <td width=7% align="right"> <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label></td>
                        <td><asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" 
                                TextMode="Password" ontextchanged="Password_TextChanged" 
                                MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                             CssClass="failureNotification" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。"
                             ValidationGroup="LoginUserValidationGroup">必须填写“密码”</asp:RequiredFieldValidator></td>
          </div> 
         </tr>
       
        <tr>
       <td></td>
           <td> <div align="left"> <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click"/>
               <asp:HyperLink ID="HyperLink1" runat="server" 
                   NavigateUrl="~/Register.aspx">注册新用户</asp:HyperLink>
                      </div>
            </td>
            
     
        </tr>
        <tr>
        <td></td>
           <td width="15%">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                 <ContentTemplate>
                    
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                      <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                 </ContentTemplate>
             </asp:UpdatePanel>
            </td>
            </tr>
    

	
</table>
</div>
</fieldset>
</asp:Content>


