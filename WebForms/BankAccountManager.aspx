<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterForms/BankAcntMngr.master" AutoEventWireup="true" CodeBehind="BankAccountManager.aspx.cs" Inherits="Masrofy4.WebForms.BankAccountManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../styling/Master/BankAccountManager.css" rel="stylesheet" />
    <div class="mt-5 mb-2">
        <h3>Link a new bank account</h3>
    </div>
    <div class="container mb-5 mt-1">
        <asp:Table CellPadding="10" CssClass="mt-3" runat="server">

            <asp:TableRow>
                <asp:TableCell CssClass="w-auto">
                    <asp:Label ID="accNameHolderLabel" CssClass="fw-bold fst-italic w-auto" Font-Size="Medium" Text="Account name holder:" runat="server" AssociatedControlID="accNumTextBox" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="accNameHolderTextBox" BorderStyle="Ridge" BorderColor="SpringGreen" CssClass="fieldInput rounded-2 ms-3" runat="server" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="w-auto">
                    <asp:Label ID="accNumLabel" CssClass="fw-bold fst-italic " Font-Size="Medium" Text="Account number:" runat="server" AssociatedControlID="accNumTextBox" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="accNumTextBox" BorderStyle="Ridge" BorderColor="SpringGreen" CssClass="fieldInput rounded-2 ms-3" runat="server" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="w-auto">
                    <asp:Label ID="accTypeLabel" CssClass="fw-bold fst-italic " Font-Size="Medium" Text="Account Type:" runat="server" AssociatedControlID="accNumTextBox" />
                </asp:TableCell>
                <asp:TableCell CssClass="">
                    <asp:DropDownList ID="accTypeDropList" BorderColor="Green" BorderStyle="Ridge" CssClass="dropdown rounded-2 ms-3 pe-5" runat="server">
                        <asp:ListItem Text="Credit" Value="0" Selected="True" />
                        <asp:ListItem Text="Debit" Value="1" Selected="False" />                       
                        <asp:ListItem Text="Savings" Value="2" Selected="False" />
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="pt-4 text-center" ColumnSpan="1">
                    <asp:Button Text="Add" ID="registerBankAccBtn" ForeColor="Black" BackColor="#7dca50" OnClick="registerBankAccBtn_Click" CssClass="px-5 btn btn-outline-success fw-bold" runat="server"/>
                </asp:TableCell>
                <asp:TableCell CssClass="pt-4 text-center" ColumnSpan="1">
                    <asp:Button Text="Cancel" ForeColor="Black" ID="goBackBtn" OnClick="goBackBtn_Click" CssClass="px-5 btn btn-danger fw-bold" runat="server"/>
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>
    </div>



</asp:Content>
