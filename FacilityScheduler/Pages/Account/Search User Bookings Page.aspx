<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Search User Bookings Page.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Search_User_Bookings_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
        <h5>Search User Booking
        <asp:TextBox ID="TextBoxSearchUserBooking" runat="server" ValidationGroup="searchGroup" CssClass="w3-round w3-margin-left"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="searchGroup" OnClick="SearchButton_Click" CssClass="w3-button w3-black w3-padding w3-round w3-medium" />
        </h5>
        <div id="tableUserBookings" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="UserBookingsTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
        <div id="NoUserBookingElements" runat="server">
            <h5>There are no Bookings for this user!</h5>
        </div>

    <%--<p>
	    <asp:Button ID="AddBooking" runat="server" OnClick="addBooking_Click"  ValidationGroup="addGroup" Text="Create Bookings" CssClass="w3-button w3-black w3-padding w3-round"/>
    </p>--%>
  
</div>
</asp:Content>
