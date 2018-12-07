<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Booking Page.aspx.cs" Inherits="FacilityScheduler.Pages.Bookings.Booking_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divBooking Page">
    <p>
        Welcome in Bookings Page
    </p>
    <p>
       
         Booking ID:  
        <asp:TextBox ID="textboxBookingId" runat="server" TextMode="Number"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldBookingId" runat="server" ErrorMessage="Booking ID required" ControlToValidate="textboxBookingId" ForeColor="Red"></asp:RequiredFieldValidator> 
        
        Facility ID:  
        <asp:TextBox ID="textboxFacilityId" runat="server" TextMode="Number"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityId" runat="server" ErrorMessage="Facility ID required" ControlToValidate="textboxFacilityId" ForeColor="Red"></asp:RequiredFieldValidator> 
        
        User ID:  
        <asp:TextBox ID="textboxUserId" runat="server" TextMode="Number"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldUserId" runat="server" ErrorMessage="User ID required" ControlToValidate="textboxUserId" ForeColor="Red"></asp:RequiredFieldValidator> 
        
        Date: 
        <asp:TextBox ID="textboxDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="Date required" ControlToValidate="textboxDate" ForeColor="Red"></asp:RequiredFieldValidator>
         
        Start Time: 
        <asp:TextBox ID="textboxDayTimeStart" runat="server" TextMode="Time"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimeStart" runat="server" ErrorMessage="Start Time required" ControlToValidate="textboxDayTimeStart" ForeColor="Red"></asp:RequiredFieldValidator>
        
        Time Slot: 
        <asp:TextBox ID="textboxTimeSlot" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimeSlot" runat="server" ErrorMessage="Time Slot required" ControlToValidate="textboxTimeSlot" ForeColor="Red"></asp:RequiredFieldValidator>
         
        
        <asp:Button ID="buttonCreateBooking" runat="server" OnClick="buttonCreateBooking_Click" Text="Create Booking" />  
        </p>
    </div>
</asp:Content>

