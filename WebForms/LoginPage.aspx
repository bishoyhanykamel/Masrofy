<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/mainTemplate.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Masrofy4.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="content mt-2">

        <div class="header">
            <p class="heading-paragraph">Login</p>
        </div>

        <div id="body">
            <!-- username field -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label ID="usrLabel" runat="server" Text="Username:"></asp:Label>
                </div>
                <div class="fieldtxt">
                    <asp:TextBox ID="usrTxt" runat="server" CssClass="usrTxt"></asp:TextBox>
                </div>
            </div>

            <!-- password field -->
            <div class="field">
                <div class="fieldlabel">
                    <asp:Label ID="pwdLabel" runat="server" Text="Password:"></asp:Label>
                </div>
                <div id="fieldtxt">
                    <asp:TextBox ID="pwdTxt" runat="server" TextMode="Password" CssClass="pwdTxt"></asp:TextBox>
                </div>
            </div>

            <div class="btn-container">
                <!-- add onclick -->
                <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass="btn" OnClick="loginBtn_Click" />
                <%--<button id="loginBtn"  class="btn" type="button" onclick="Login()">Login</button> --%>
            </div>

        </div>

        <div id="footer">

            <div id="pwdRef">
                <asp:HyperLink ID="HyperLink1" runat="server" cssStyle="link" NavigateUrl="ForgotPasswordAuth.aspx">Forgot Password?</asp:HyperLink>
            </div>

            <div id="signupRef">
                <asp:HyperLink ID="HyperLink2" runat="server" cssStyle="link" NavigateUrl="Signup.aspx">Sign Up</asp:HyperLink>
            </div>
        </div>
    </div>
    <script src="../js/jquery-3.6.0.min.js"></script>
    <script>
        function Login() {
            $.ajax({
                type: 'POST',
                url: 'LoginPage.aspx/api1',
                dataType: 'json',
                contentType: 'application/json',
                data: null,
                success: function (response) {
                    console.log(response.d);
                    localStorage.setItem("nationalID", "")
                }
            }
            )
        }
    </script>
</asp:Content>

