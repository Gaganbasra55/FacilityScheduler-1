<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageFacilities.aspx.cs" Inherits="FacilityScheduler.Pages.ManageFacilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divFacilitiesSecondPage" runat="server"  CssClass="w3-bar w3-center w3-row-padding w3-small">
   
        <div class="w3-padding">
                <asp:CustomValidator ID="CustomValidatorTimes" ValidationGroup="manageFacility" runat="server" ErrorMessage="End Time must be after Start time!" OnServerValidate="CustomValidator_ValidateTimes" ControlToValidate="DropDownListEndTime" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityName" ValidationGroup="manageFacility" runat="server" ErrorMessage="Facility name required" ControlToValidate="textboxFacityName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:TextBox ID="textboxFacityName" ValidationGroup="manageFacility" runat="server" CssClass="w3-input w3-border w3-round w3-centered" placeholder="Name" MaxLength="50"></asp:TextBox> 
        
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilitySlot" runat="server" ErrorMessage="Time Slot required" ControlToValidate="DropDownListTimeSlot" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label runat="server" CssClass="w3-input w3-border w3-round">Time Slot Length</asp:Label>
                <asp:DropDownList ID="DropDownListTimeSlot" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                </asp:DropDownList>
        

                <asp:Label runat="server" CssClass="w3-input w3-border w3-round">Start time</asp:Label>
                <asp:DropDownList ID="DropDownListStartTime" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownListStartMinutes" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>        
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListStartPeriod" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
    
                <asp:Label runat="server" CssClass="w3-input w3-border w3-round">End time</asp:Label>
                <asp:DropDownList ID="DropDownListEndTime" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownListEndMinutes" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>        
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListEndDayPeriod" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem Value="AM">AM</asp:ListItem>
                    <asp:ListItem Value="PM">PM</asp:ListItem>
                </asp:DropDownList>
            </div>
    

    <p>
        <asp:Button ID="buttonCreateFacility" runat="server" OnClick="buttonCreateFacility_Click" Text="Create Facility" ValidationGroup="manageFacility"/>  
        <asp:Button ID="buttonUpdateFacility" runat="server" OnClick="buttonUpdateFacility_Click" Text="Update Facility" ValidationGroup="manageFacility"/>  

        <asp:Button ID="buttonCancel" runat="server" OnClick="buttonCancel_Click" Text="Cancel" ValidationGroup="none" />  
        <asp:HiddenField ID="HiddenFieldFacilityId" runat="server" />
        </p>
    </div>
</asp:Content>