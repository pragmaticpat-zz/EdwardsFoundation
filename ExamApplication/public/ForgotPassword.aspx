<%@ Page MasterPageFile="~/ExamApplicationMasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ExamApplication.ForgotPassword" Title="Forgot Password" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="labelError" runat="server" />
    <br />
    <asp:Label ID="labelForgotPasswordInstructions" runat="server" />
    <br />
    <asp:Label ID="labelUserName" runat="server" />
    <asp:TextBox ID="textBoxUserName" runat="server" />
    <br />
    <asp:Button ID="buttonSubmit" runat="server" Text="Submit" OnClick="buttonSubmit_Click" />
</asp:Content>