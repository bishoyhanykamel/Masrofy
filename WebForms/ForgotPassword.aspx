<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/mainTemplate.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Masrofy4.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href="styling/WebForms/ForgotPassword.css" rel="stylesheet" />

<div class="content">

    <div class="header">
        <p class="heading-paragraph">Forgot Password</p>
    </div>

    <div class="body">
        <!-- OTP field --> 
        <div class="field">
            <div class="fieldlabel">
                <asp:Label ID="otpLabel" runat="server" Text="OTP:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="otpTxt" runat="server" CssClass="usrTxt"></asp:TextBox>
            </div>
        </div>
        <!-- new password field -->
        <div class="field">
            <div class="fieldlabel">
                <asp:Label ID="pwdLabel" runat="server" Text="New Password:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="pwdTxt" runat="server" TextMode="Password" CssClass="pwdTxt"></asp:TextBox>
            </div>
        </div>

        <!-- confirm password field -->
        <div class="field">
            <div class="fieldlabel">
                <asp:Label ID="pwdCnfrmLabel" runat="server" Text="Re-enter new Password:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="pwdCnfrmTxt" runat="server" TextMode="Password" CssClass="pwdTxt"></asp:TextBox>
            </div>
        </div>
        <div class="btn-container">
                <!-- add onclick -->
                <asp:Button ID="confirmBtn" runat="server" Text="Submit" CssClass="btn" onclick="confirmBtn_Click" />
        </div>
    </div>

</div>


</asp:Content>
