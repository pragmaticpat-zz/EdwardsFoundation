<%@ Page Language="C#" MasterPageFile="~/ExamApplicationMasterPage.master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="ExamApplication._Default" Title="Exam" %>
<asp:Content ContentPlaceHolderID="content" ID="form1" runat="server" >
        <asp:Label ID="labelError" runat="server" CssClass="message" />
        <h1><asp:Literal ID="literalHeader" runat="server" /></h1>
        <div id="instruction">
            <asp:Literal ID="literalInstructions" runat="server" />
        </div>
        <asp:Panel ID="panelQuestions" runat="server" />
        <asp:Panel ID="panelButtons" runat="server" />
        <asp:Panel ID="panelFooter" runat="server" />
</asp:Content>