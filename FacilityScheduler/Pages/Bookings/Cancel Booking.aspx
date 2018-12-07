<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cancel Booking.aspx.cs" Inherits="FacilityScheduler.Pages.Bookings.Cancel_Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="ButtonCancelBooking" runat="server" OnClick="cancelBooking_Click"  ValidationGroup="addGroup" Text="Cancel Bookings" CssClass="w3-button w3-black w3-padding w3-round"/>
</asp:Content>
