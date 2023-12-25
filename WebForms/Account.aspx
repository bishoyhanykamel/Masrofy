<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/Home.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Masrofy4.WebForms.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 fst-italic">My Profile</h1>
    <div class="container mt-5" style="display: flex; flex-direction: row;">
        <div>
            <img class="img" src="../icons/parent.png" width="128px" height="128px" alt="User Image" />
        </div>
        <table class="ms-3 d-flex">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nameTxt" runat="server" CssClass="textBox" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Change" CssClass="button" OnClick="Button2_Click" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mobile Number: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="numTxt" runat="server" CssClass="textBox" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Change" CssClass="button" OnClick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="changePWD" runat="server" Text="Change Password" CssClass="button"
                        OnClientClick="return clickPWD();" CausesValidation="false" />
                </td>
            </tr>
            <tr class="pwd">
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Current Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="currPwdTxt" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="pwd">
                <td>
                    <asp:Label ID="Label8" runat="server" Text="New Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="newpwdTxt" runat="server" CssClass="textBox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="pwd">
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Change Password" CssClass="button" OnClick="Button5_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="container mt-5">
        <h3 class="fst-italic">Add child</h3>
        <div>
            <div class="p-2">
                <asp:Label ID="Label9" runat="server" Text="Child ID: "></asp:Label>
                <asp:TextBox ID="childID" runat="server" CssClass="textBox"></asp:TextBox>
            </div>
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
                <asp:Button ID="Button4" runat="server" Text="Save" CssClass="button-1" OnClick="Button4_Click1" />
            </div>
        </div>

    </div>
    <script type="text/javascript">
        function clickPWD() {
            console.log("clicked");
            document.getElementById('<%=changePWD.ClientID%>').style.display = "none";
            document.getElementsByClassName('pwd')[0].style.display = "block";
            document.getElementsByClassName('pwd')[1].style.display = "block";
            document.getElementsByClassName('pwd')[2].style.display = "block";
            return false;
        }
    </script>
</asp:Content>
