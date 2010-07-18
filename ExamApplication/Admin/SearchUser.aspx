<%@ Page MasterPageFile="~/ExamApplicationMasterPage.master" Language="C#" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="ExamApplication.Admin.SearchUser" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="Content">
    <asp:Panel ID="panelSearchUsers" runat="server">
        <asp:Label ID="labelSearchUser" runat="server" /> 
        <asp:TextBox ID="textBoxUserName" runat="server" />
        <asp:Button ID="buttonSearchUsers" runat="server" Text="Button" 
            onclick="buttonSearchUsers_Click" />
    </asp:Panel>
    <asp:Panel ID="panelUsers" runat="server">
        <asp:DataGrid ID="gridViewUsers" runat="server" OnEditCommand="gridViewUsers_OnEdit" OnSelectedIndexChanged="gridViewUsers_SelectedIndexChange">
            
            <Columns>
                <asp:EditCommandColumn CancelText="Cancel" EditText="Edit" UpdateText="Update"></asp:EditCommandColumn>
                <asp:ButtonColumn CommandName="Delete" Text="Delete"></asp:ButtonColumn>
                <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
            </Columns>
            
        </asp:DataGrid>
    </asp:Panel>
</asp:Content>