<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/mainTemplate.Master" AutoEventWireup="true" CodeBehind="ForgotPasswordAuth.aspx.cs" Inherits="Masrofy4.WebForms.ForgotPasswordAuth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

        <div class="header mx-1">
            <p class="heading-paragraph">Forgot Password</p>
        </div>

        <div id="body pt-2">

            <!-- Full legal name -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label Text="Full legal name:" runat="server" />
                </div>
                <div class="fieldInput">
                    <asp:TextBox ID="legalNameTextBox" CssClass="usrTxt" runat="server" />
                </div>
            </div>

            <!-- username -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label Text="Username:" runat="server" />
                </div>
                <div class="fieldInput">
                    <asp:TextBox ID="usernameTextBox" CssClass="usrTxt" runat="server" />
                </div>
            </div>
            <!-- mobile number -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label Text="Mobile number:" runat="server" />
                </div>
                <div class="fieldInput">
                    <asp:TextBox ID="mobileNumTextBox" CssClass="usrTxt" runat="server" />
                </div>
            </div>

            <!-- national id -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label Text="National ID:" runat="server" />
                </div>
                <div class="fieldInput">
                    <asp:TextBox ID="nationalIDTextBox" CssClass="usrTxt" runat="server" />
                </div>
            </div>

            <!-- submit button -->
            <div class="btn-container">
                <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" OnClick="submitBtn_Click" />
            </div>
        </div>

        <div id="footer">
            <div class="text-center" id="gobackRef">
                <asp:HyperLink ID="HyperLink2" runat="server" cssStyle="link" NavigateUrl="LoginPage.aspx">Go back</asp:HyperLink>
            </div>
        </div>
    </div>



</asp:Content>
