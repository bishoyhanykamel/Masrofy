<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/Home.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Masrofy4.WebForms.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3">My Account</h1>
    <div class="container mt-5" style="display: flex; flex-direction: row;">
        <div>
            <img class="img" src="../icons/parent.png" width="128px" height="128px" alt="User Image" />
        </div>
        <table class="ms-3 d-flex p-3">
            <tr class="mt-3">
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="fw-bold" Text="Name: "></asp:Label>
                </td>
                <td>
                    <p>
                        <asp:TextBox ID="nameTxt" runat="server" CssClass="textBox"></asp:TextBox>
                    </p>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Change" CssClass="button ms-3" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr class="mt-3">
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="fw-bold" Text="Mobile Number: "></asp:Label>
                </td>
                <td>
                    <p>
                        <asp:TextBox ID="numTxt" runat="server" CssClass="textBox" TextMode="Number"></asp:TextBox>
                    </p>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Change" CssClass="button ms-3" OnClick="Button3_Click" />
                </td>
            </tr>
            <tr class="mt-1">
                <td colspan="2">
                    <button id="changePWD" type="button" class="button ms-3 mt-2">Change Password</button>
                    <%--<asp:Button ID="changePWDs" runat="server" Text="Change Password" CssClass="button ms-3 mt-2"
                         AutoPostBack="false" CausesValidation="false"/>--%>
                </td>
            </tr>
            <tr class="pwd mt-3">
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="fw-bold" Text="Current Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="currPwdTxt" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="pwd mt-3">
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="fw-bold fst-italic" Text="New Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="newpwdTxt" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="pwd mt-3">
                <td>
                    <asp:Button ID="submitNewPwBtn" runat="server" Text="Change Password" CssClass="button mt-2" OnClick="submitNewPwBtn_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="container mt-5">
        <h3>Add child</h3>
        <div>
            <div class="p-2">
                <asp:Label ID="Label3" runat="server" Text="Child Name: "></asp:Label>
                <asp:TextBox ID="cName" runat="server" CssClass="textBox"></asp:TextBox>
            </div>
            <div class="p-2">
                <asp:Label ID="Label4" runat="server" Text="Child Picture: "></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div class="p-2">
                <asp:Label ID="Label5" runat="server" Text="Child Limit: "></asp:Label>
                <asp:TextBox ID="limitTxt" runat="server" CssClass="textBox" TextMode="Number"></asp:TextBox>
            </div>
            <div class="p-2">
                <asp:Label ID="Label6" runat="server" Text="Limit Period: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Text="No Limit"></asp:ListItem>
                    <asp:ListItem Text="Daily"></asp:ListItem>
                    <asp:ListItem Text="Weekly"></asp:ListItem>
                    <asp:ListItem Text="Monthly"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="p-2">
                <asp:Button ID="Button4" runat="server" Text="Save" CssClass="button-1" OnClick="Button4_Click" />
            </div>
        </div>

    </div>
    <script src="../js/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#changePWD').on('click', function (evnt) {
                document.getElementsByClassName('pwd')[0].style.display = "block";
                document.getElementsByClassName('pwd')[1].style.display = "block";
                document.getElementsByClassName('pwd')[2].style.display = "block";
                document.getElementById('changePWD').style.display = "none";
                $('#changePWD').style.display = "none";
                return false;
            });
        });
<%--        function clickPWD() {
            console.log("clicked");
            document.getElementById('<%=changePWDs.ClientID%>').style.display = "none";
            document.getElementsByClassName('pwd')[0].style.display = "block";
            document.getElementsByClassName('pwd')[1].style.display = "block";
            document.getElementsByClassName('pwd')[2].style.display = "block";
            return false;
        }--%>
    </script>
</asp:Content>
