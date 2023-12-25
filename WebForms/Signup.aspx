<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/mainTemplate.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Masrofy4.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<div class="content">
    <div class="header">
        <p class="heading-paragraph">Sign Up</p>
</div>

<div id="body">

<!-- national id field -->
    <div class="field">
        <div class="fieldlabel">
                <asp:Label ID="nidLbl" runat="server" Text="National ID:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="nidTxt" runat="server"></asp:TextBox>
            </div>
        </div>

    <!-- mobile number field -->
    <div class="field">
        <div class="fieldlabel">
                <asp:Label ID="mobNoLbl" runat="server" Text="Mobile Number:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="mobNoTxt" runat="server"></asp:TextBox>
            </div>
        </div>

    <!-- full name field -->
    <div class="field">
        <div class="fieldlabel">
                <asp:Label ID="nameLbl" runat="server" Text="Full name:"></asp:Label>
            </div>
            <div id="nameInput">
                <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
            </div>
        </div>

    <!-- username field -->
    <div class="field">
        <div class="fieldlabel">
                <asp:Label ID="usrNameLbl" runat="server" Text="Username:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="usrNameInput" runat="server"></asp:TextBox>
            </div>
        </div>

    <!-- password field -->
    <div class="field">
        <div class="fieldlabel">
                <asp:Label ID="pwdLbl" runat="server" Text="Password:"></asp:Label>
            </div>
            <div class="fieldtxt">
                <asp:TextBox ID="pwdInput" runat="server" TextMode="Password"></asp:TextBox>
                
            </div>
        </div>

    <div class="btn-container">
        <!-- add onclick -->
        <asp:Button ID="signupBtn" runat="server" Text="Sign Up" CssClass="btn" OnClick="signupBtn_Click" />
    </div>
</div>
    <div id="loginRef">
        <asp:HyperLink ID="HyperLink2" runat="server" cssStyle="link" NavigateUrl="LoginPage.aspx">Log in</asp:HyperLink>
    </div>
</div>
    
</asp:Content>
