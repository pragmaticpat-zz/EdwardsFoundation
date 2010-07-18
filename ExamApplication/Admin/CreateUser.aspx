<%@ Page MasterPageFile="~/ExamApplicationMasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="ExamApplication.Admin.CreateUser" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="Content">
    <asp:Label ID="LabelErrorMessage" runat="server" Text="" CssClass="error" />
    
    <br />
    <asp:Label ID="LabelTextBoxEmail" runat="server" Text="Email Address" CssClass="input-label" />
    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-input" CausesValidation="true" />
    <asp:RequiredFieldValidator ID="ValidatorEmailAddress" runat="server" ControlToValidate="TextBoxEmail" />
    <br />
    <asp:Label ID="LabelTextBoxFirstName" runat="server" Text="First Name" CssClass="input-label" />
    <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="form-input" CausesValidation="true" />
    <asp:RequiredFieldValidator ID="ValidatorFirstName"  runat="server" ControlToValidate="TextBoxFirstName" />
    <br />
    <asp:Label ID="LabelTextBoxLastName" runat="server" Text="Last Name" CssClass="input-label" />
    <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="form-input" CausesValidation="true" />
    <asp:RequiredFieldValidator ID="ValidatorLastName" runat="server" ControlToValidate="TextBoxLastName" />
    <br />
    <asp:Label ID="LabelTextBoxGradeLevel" runat="server" Text="Grade Level" CssClass="input-label" />
    <asp:TextBox ID="TextBoxGradeLevel" runat="server" CssClass="form-input" CausesValidation="true" />
    <asp:RequiredFieldValidator ID="ValidatorGradeLevel" runat="server" ControlToValidate="TextBoxGradeLevel" />
    <br />
    <asp:Label ID="LabelTextBoxUserType" runat="server" Text="User Type" CssClass="input-label" />
    <asp:DropDownList ID="DropDownListUserType" runat="server" />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Password" CssClass="input-label" />
    <input id="TextBoxPassword" runat="server" type="password" class="form-input" />
    <asp:RequiredFieldValidator ID="ValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" />
    <asp:CompareValidator id="CompareValidatorPassword" runat="server"
                            ControlToValidate="TextBoxPassword" ControlToCompare="TextBoxConfirmPassword"
                            Operator="Equal" />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Confirm Password" CssClass="input-label" />
    <input id="TextBoxConfirmPassword" runat="server" type="password" class="form-input" />
    <asp:RequiredFieldValidator ID="ValidatorConfirmPassword" runat="server" ControlToValidate="TextBoxConfirmPassword" />
    <br />
    
    <asp:Button ID="Button1" runat="server" Text="Create User" 
        onclick="Button1_Click" />
</asp:Content>