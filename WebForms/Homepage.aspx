<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterForms/Home.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Masrofy4.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery-3.6.0.min.js"></script>
    <%--    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44338/api/HomePage/?nationalID=' + '434556',
                dataType: 'jsonp',
                Accept: 'application/json',
                success: function (data) {
                    console.log(data);
                }
            });
        });
    </script>--%>

    <link href="../styling/Master/Homepage.css" rel="stylesheet" />

    <div class="container mt-5" style="display: flex; flex-direction: row;">
        <div>
            <asp:ImageButton ID="userImage" CssClass="img" ImageUrl="../icons/parent.png" Width="128px" Height="128px" runat="server" OnClick="userImage_Click" />
        </div>
        <div class="ms-3">
            <h5 class="fw-bold">Welcome,</h5>
            <h3 class="text-capitalize fst-italic mt-3"><% =name%></h3>
        </div>
    </div>

    <div class="container mt-5">
        <div class="mt-3 mb-2">
            <h3 class="text-capitalize fst-italic">My Accounts</h3>
        </div>
        <%--<h3 class="text-capitalize fst-italic mt-2 mb-5">My Accounts</h3>--%>
        <div style="margin-bottom: 0px;">
            <asp:GridView CssClass="table" ID="parentBankAcc_GridView" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">

                <Columns>
                    <asp:BoundField HeaderText="Account Number" DataField="accNum" />
                    <asp:BoundField HeaderText="Balance (EGP)" DataField="balance" />
                    <asp:BoundField HeaderText="Account Type" DataField="accType" />
                </Columns>
                <PagerSettings Mode="NextPreviousFirstLast" Position="Bottom" />

                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

                <HeaderStyle BackColor="#63cc71" Font-Bold="True" ForeColor="#FFFFFF"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

                <RowStyle BackColor="White" ForeColor="black"></RowStyle>

                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
    </div>

<%--    gridview format template - can use auto format instead     --%>
        <%--   <table class="table">
                <thead>
                    <tr>
                        <th scope="col">Account Number</th>
                        <th scope="col">Balance</th>
                    </tr>
                    </thead>
                    <tbody>
                        <!-- append rows by data obtained from NBE API on page load -->
                        <% =bankAccountTableHTML %>
                    </tbody>
            </table>
            
             <input id="Button1" type="button" value="button" AutoPostBack="te" runat="server"/>

             <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                 <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

                 <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

                 <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>

                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

                 <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

                 <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

                 <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

                 <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
             </asp:GridView>
        --%>
    

    <%--karim's html/css generation - inside aspx instead of c#--%>

<%--    <%if (childAccountsList.Count > 0)
        {  %>
    <div class="row">

        <% foreach (var account in childAccountsList)
            { %>
        <div class="col-4">
            <img class="img" src="../icons/child.png" alt="{Child Name}" width="72px" height="72px" />
            <p class="mt-1 text-dark"><b><em><%=account.name %></em></b></p>
            <p style="font-size: 12px"><b>Current Balance: <span class="text-success"><%=account.balance %> EGP</span></b></p>
        </div>
        <%} %>
    </div>

    <%} %>--%>

    <%--my html/css generation - inside c#--%>       
        <!-- HTML template for a child
            <div class="row mb-3">

            <div class="col">
                <div class="text-center fw-bold">
                    <img class="img"src="../icons/Untitled.png" alt="{Child Name}" width="72px" height="72px" />
                    <p class="mt-1 text-dark"><b><em>Child Name</em></b></p>
                    <p style="font-size: 12px"><b>Current Balance: <span class="text-success">10000 EGP</span></b></p>
                </div>
            </div>
            -->
    <%--  <% =childAccountGridHTML %>  --%>


    <%--  list view implementation of child view  --%>

    <div class="container mt-5 me-5 fw-bold">
        <h3 class="text-capitalize fst-italic">My Children</h3>
        <div class="row text-center mb-3">
            <asp:ListView ID="childsAccountListView" runat="server">
                <ItemTemplate>
                    <div class="col-4 p-4">
                        <asp:ImageButton ID="childImage" CssClass="img" Width="72px" Height="72px" ImageUrl="../icons/defaultChild.png" runat="server" />
                        <%--<asp:Label ID="childName" CssClass="mt-1 text-dark" Text="<%# Eval("name")%>" runat="server" style="display: block" />--%>
                        <p><%# Eval("name")%></p>
                        <p class="fw-bold" style="font-size: 12px;">Current Balance: <span class="text-success" style="font-size: 12px;"><%# Eval("balance")%> EGP</span>   </p>

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>


</asp:Content>
