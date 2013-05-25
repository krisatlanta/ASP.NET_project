<%@ Page Title="注册" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="bookshop1._1.Register" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="Register">
<fieldset class="Register">
<legend>用户注册</legend>
<table border="0"  width="95%"  >

        <tr>
        <div>
        <td width=10%><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label></td>
                        <td><asp:TextBox ID="UserName" runat="server" CssClass="textEntry" MaxLength="20" 
                                Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                             CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“用户名”</asp:RequiredFieldValidator></td>
           </div>    
         </tr>
         <tr  height=15%>
         <div>
         <td width=7%> <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label></td>
                        <td><asp:TextBox ID="Password" runat="server" CssClass="textEntry" 
                                TextMode="Password" MaxLength="20" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                             CssClass="failureNotification" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“密码”</asp:RequiredFieldValidator></td>
          </div> 
         </tr>
         <tr  height=15%>
         <div>
         <td width=13%> <asp:Label ID="ConfirmPswLabel" runat="server" AssociatedControlID="ConfirmPsw">确认密码:</asp:Label></td>
                        <td><asp:TextBox ID="ConfirmPsw" runat="server" CssClass="textEntry" 
                                TextMode="Password" MaxLength="20" Width="250px"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ErrorMessage="确认密码必须和密码一致" ControlToCompare="Password" 
                                ControlToValidate="ConfirmPsw" ToolTip="确认密码必须和密码一致" 
                                ValidationGroup="RegisterUserValidationGroup">确认密码必须和密码一致</asp:CompareValidator>
                        </td>
          </div> 
         </tr>
          <tr>
        <div>
        <td width=10%><asp:Label ID="NameLabel" runat="server" AssociatedControlID="Name">姓名:</asp:Label></td>
                        <td><asp:TextBox ID="Name" runat="server" CssClass="textEntry" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                             CssClass="failureNotification" ErrorMessage="必须填写“姓名”。" ToolTip="必须填写“姓名”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“姓名”</asp:RequiredFieldValidator></td>
           </div>    
         </tr>
          <tr>
        <div>
        <td width=10%><asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone">电话:</asp:Label></td>
                        <td><asp:TextBox ID="Phone" runat="server" CssClass="textEntry" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="Phone"
                             CssClass="failureNotification" ErrorMessage="必须填写“电话”。" ToolTip="必须填写“电话”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“电话”</asp:RequiredFieldValidator></td>
           </div>    
         </tr>
          <tr>
        <div>
        <td width=10%><asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Phone">Email:</asp:Label></td>
                        <td><asp:TextBox ID="Email" runat="server" CssClass="textEntry" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                             CssClass="failureNotification" ErrorMessage="必须填写“Email”。" ToolTip="必须填写“Email”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“Email”</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="邮箱格式错误" ControlToValidate="Email" 
                                CssClass="failureNotification" ToolTip="正确格式&quot;aaa@bc.com&quot;" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="RegisterUserValidationGroup">邮箱格式错误</asp:RegularExpressionValidator>
              </td>
           </div>    
         </tr>
             <tr>
        <div>
        <td width=10%><asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">地址:</asp:Label></td>
                        <td><asp:TextBox ID="Address" runat="server" CssClass="textEntry" Height="150px" 
                                Width="250px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address"
                             CssClass="failureNotification" ErrorMessage="必须填写“地址”。" ToolTip="必须填写“地址”。"
                             ValidationGroup="RegisterUserValidationGroup">必须填写“地址”</asp:RequiredFieldValidator></td>
           </div>    
         </tr>
         <tr>
         <td>
         
             <asp:Label ID="RoleLabel" runat="server" Text="注册为："></asp:Label>
         
         </td>
         <td>
             <asp:RadioButton ID="customerRadio" runat="server" Checked="True" 
                 GroupName="roleGroup" TabIndex="1" Text="顾客" ToolTip="希望买书" />
             <asp:RadioButton ID="sellerRadio" runat="server" GroupName="roleGroup" 
                 TabIndex="2" Text="商家" ToolTip="希望卖书" />
             </td>
         </tr>
          <tr>
         <td></td>
         <td>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                 <ContentTemplate>
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                     <asp:Label ID="Label1" runat="server" Font-Size="Large" 
    ForeColor="Red"></asp:Label>
                 </ContentTemplate>
             </asp:UpdatePanel>
              </td>
         </tr>
         <tr>
         <div>
         <td><div></div></td><td><asp:Button ID="CreateUserButton" runat="server" 
                 CommandName="MoveNext" Text="创建用户"
                                 ValidationGroup="RegisterUserValidationGroup" 
                 onclick="CreateUserButton_Click"/></td>
         </div>
         </tr>
        
       
</table>
</div>
</fieldset>
</asp:Content>
