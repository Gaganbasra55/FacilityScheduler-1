<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="FacilityScheduler.Pages.UserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
        <h5>Search a User Account</h5>
        <asp:TextBox ID="TextBoxSearchUserAccount" runat="server" ValidationGroup="searchGroup" CssClass="w3-round w3-margin-left"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="searchGroup" OnClick="SearchButton_Click" CssClass="w3-button w3-black w3-padding w3-round w3-medium" />
        <div class="w3-padding w3-large w3-left-align w3-center">
            <asp:DropDownList ID="DropDownListCategory" runat="server" ValidationGroup="searchGroup"></asp:DropDownList>&nbsp;&nbsp;
            Verified <asp:CheckBox ID="CheckBoxSearchUserAccount" runat="server" ValidationGroup="searchGroup" CssClass="w3-round w3-margin-left"></asp:CheckBox>&nbsp;&nbsp;
        </div>
        <div id="tableUserAccount" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="UserAccountTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
        <div id="NoUserAccountElements" runat="server">
            <h5>There are no User Accounts!</h5>
        </div>

</div>
</asp:Content>
