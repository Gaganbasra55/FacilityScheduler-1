<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FacilitiesSecond.aspx.cs" Inherits="FacilityScheduler.Pages.FacilitiesSecond" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divFacilitiesSecondPage">
    <p>
        Welcome in Facilities Second Page
    </p>
    <p>
        Facility ID:  
        <asp:TextBox ID="textboxFacilityId" runat="server" TextMode="Number"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityId" runat="server" ErrorMessage="Facility ID required" ControlToValidate="textboxFacityId" ForeColor="Red"></asp:RequiredFieldValidator> 
        
        Facility Name:  
        <asp:TextBox ID="textboxFacityName" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityName" runat="server" ErrorMessage="Facility name required" ControlToValidate="textboxFacityName" ForeColor="Red"></asp:RequiredFieldValidator> 
        
        Time Slot Length: 
        <asp:TextBox ID="textboxTimeSlotLength" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimeSlotLength" runat="server" ErrorMessage="Time Slot required" ControlToValidate="textboxTimeSlotLength" ForeColor="Red"></asp:RequiredFieldValidator>
         
        Start Time: 
        <asp:TextBox ID="textboxDayStartTime" runat="server" TextMode="Time"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDayStartTime" runat="server" ErrorMessage="Start Time required" ControlToValidate="textboxFacilityCode" ForeColor="Red"></asp:RequiredFieldValidator>
        
        End Time: 
        <asp:TextBox ID="textboxDayEndTime" runat="server" TextMode="Time"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDayEndTime" runat="server" ErrorMessage="End Time required" ControlToValidate="textboxFacilityCode" ForeColor="Red"></asp:RequiredFieldValidator>
         
        <%--Facility Description:  
        <asp:TextBox ID="textboxFacilityDescription" runat="server"></asp:TextBox> 
        Email:  
        <asp:TextBox ID="textboxEmail" runat="server"></asp:TextBox> 
        Password:  
        <asp:TextBox ID="textboxPassword" runat="server" TextMode="Password"></asp:TextBox> 
        Re-Password:  
        <asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password"></asp:TextBox> --%>

        <asp:Button ID="buttonCreateFacility" runat="server" OnClick="buttonCreateFacility_Click" Text="Create Facility" />  
        </p>
    </div>
</asp:Content>