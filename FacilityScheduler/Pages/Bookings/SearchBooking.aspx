<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchBooking.aspx.cs" Inherits="FacilityScheduler.Pages.Bookings.SearchBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
        <h5>Search Bookings
            <asp:CustomValidator ID="CustomValidatorValidDate" runat="server" ValidationGroup="SearcGroup" ErrorMessage="Invalid Date!" ControlToValidate="TextBoxSearchBooking" ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidatorDate_ServerValidate"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="Date required" ControlToValidate="TextBoxSearchBooking" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBoxSearchBooking" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="searchGroup" OnClick="SearchButton_Click" CssClass="w3-button w3-black w3-padding w3-round w3-medium" />
        </h5>
        <div id="tableBookings" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="BookingsTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
        <div id="NoBookingElements" runat="server">
            <h5>There are no Bookings!</h5>
        </div>
  
</div>
</asp:Content>