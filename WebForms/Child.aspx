<%@ Page Async="true" Title ="" Language="C#" MasterPageFile="~/MasterForms/Home.Master" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="Masrofy4.WebForms.Child" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Header Info -->

<div class="container" >
        <div>
    <h1 class="mt-3 fst-italic">My Child</h1>
        </div>
        <div class="navbar" id="navbarSupportedContent"  style="float: right">

            <ul class="navbar-nav mx-5">
                <li >
                    <asp:Button id="blkbtn"  runat="server" Text="Block Child" CssClass="btn btn-danger"  onclick="BlockBtn_click" />
                </li>

            </ul>
        </div>

    </div>
    
    
    <!-- Child Info -->
    <div class="container mt-5" style="display: flex; flex-direction: row;">

        <div>
            <img src="../icons/defaultChild.png" class="img" width="128px" height="128px"/>
        </div>

        <table class="ms-3 d-flex">
            <tr>
                <td>
                    <asp:Label runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox id="nameBox" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" Text="Change" Class="button" onClick="ChangeBtn_click" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Limit Period:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server">
                    <asp:listitem text="" value="val1"></asp:listitem>
                    <asp:listitem text="No Limit" value="val2"></asp:listitem>
                    <asp:listitem text="Daily" value="val3"></asp:listitem>
                    <asp:listitem text="Weekly" value="val4"></asp:listitem>
                    <asp:listitem text="Monthly" value="val5"></asp:listitem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Limit Amount:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox id="limbox" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" Text="Set Limit" Class="button" onClick="SetLimBtn_click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Current Balance:"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" id="balanceBox" Text="500"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>



    <!-- Recharge -->

    <div class="container mt-5">
        <h3 class="fst-italic">Recharge</h3>

        <div class="border">
            

                <div class="p-2">
                    <asp:Label runat="server" Text="From:"></asp:Label>
                    <asp:DropDownList ID="accountNum" runat="server">
                    <asp:listitem text="222" value="222"></asp:listitem>
                        <asp:listitem text="333" value="333"></asp:listitem>
                        <asp:listitem text="224" value="224"></asp:listitem>
                    </asp:DropDownList>
                </div>

                <div class="p-2">
                    <asp:Label runat="server" Text="Amount:"></asp:Label>
                    <asp:TextBox runat="server" id="amount" CssClass="textBox"></asp:TextBox>
                </div>

                <div class="p-2">
                    <asp:Label runat="server" Text="Purpose:"></asp:Label>
                    <asp:TextBox runat="server" ID="purpo" CssClass="textBox"></asp:TextBox>
                </div>
                <div class="p-2">
                    <asp:Label runat="server" Text="Automatic Recharge:"></asp:Label>
                    <asp:CheckBox runat="server" id="autoRech"></asp:CheckBox>
                </div>
                <div class="p-2">
                <asp:Label runat="server" Text="Recharge Period:"></asp:Label>
                <asp:DropDownList ID="period" runat="server">
                    <asp:listitem text="Daily" value="Daily"></asp:listitem>
                    <asp:listitem text="Weekly" value="Weekly"></asp:listitem>
                    <asp:listitem text="Monthly" value="Monthly"></asp:listitem>
                </asp:DropDownList>

                </div>

                <div class="p-2">
                    <asp:Button runat="server" Text="Recharge" Class="button" onClick="RechargeBtn_click" />
                </div>


        </div>
 
    </div>

     <!-- Transaction History -->


    <!-- <div class="container mt-5">
        <h3 class="fst-italic">Transactions</h3>

      <asp:GridView ID="transactions" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField Datafield="Date" HeaderText="" />
                <asp:BoundField Datafield="Place" HeaderText="" />
                <asp:BoundField Datafield="Amount" HeaderText="" />
            </Columns>
        </asp:GridView> 

        <div class="border" >
            <table class="border">
            <tr class="border">
                <td class="border">Date</td>
                <td class="border">Place</td>
                <td class="border">Amount</td>
            </tr>
            <tr>
                <td>test</td>
                <td>test</td>
                <td>test</td>
            </tr>
            <tr>
                <td>test1</td>
                <td>test1</td>
                <td>test1</td>
            </tr>

            </table>
        </div>
    </div> -->

    <!-- testing-->

    <div class="container mt-5">
        <h3 class="text-capitalize fst-italic">Transactions</h3>
         <div>
             <asp:GridView CssClass="table" ID="transaction_GridView" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="false">
                 
                 <Columns>
                     <asp:BoundField HeaderText="Date" DataField="transactionDate"/>
                     <asp:BoundField HeaderText="Place" DataField="transactionPlace" />
                     <asp:BoundField HeaderText="Amount" DataField="transactionAmount" />
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
    <!--  script -->
    <script>

</script>

    




</asp:Content>
