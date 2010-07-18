<%@ Page MasterPageFile="~/ExamApplicationMasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ExamApplication.login" Title="Login" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="content" runat="server">
        <asp:Label ID="labelError" runat="server" />
        <asp:Login ID="loginControl" runat="server" OnAuthenticate="loginControl_Authenticate" 
             PasswordRecoveryUrl="~/public/forgotpassword.aspx" />
</asp:Content>
