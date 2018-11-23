<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageFacilities.aspx.cs" Inherits="FacilityScheduler.Pages.ManageFacilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divFacilitiesSecondPage" runat="server"  CssClass="w3-bar w3-center w3-row-padding w3-small">
   
        <div class="w3-padding w3-bar w3-medium">
            <h3 runat="server" id="add">Add Facility</h3>
            <h3 runat="server" id="edit">Edit Facility</h3>
            <div class="w3-center w3-bar"><hr /></div>

                <asp:CustomValidator ID="CustomValidatorTimes" ValidationGroup="manageFacility" runat="server" ErrorMessage="End Time must be after Start time!" OnServerValidate="CustomValidator_ValidateTimes" ControlToValidate="DropDownListEndTime" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityName" ValidationGroup="manageFacility" runat="server" ErrorMessage="Facility name required" ControlToValidate="textboxFacityName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:TextBox ID="textboxFacityName" ValidationGroup="manageFacility" runat="server" CssClass="w3-input w3-border w3-round w3-centered" placeholder="Name" MaxLength="50"></asp:TextBox> 
        
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilitySlot" runat="server" ErrorMessage="Time Slot required" ControlToValidate="DropDownListTimeSlot" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <h5>Time Slot Length</h5>
                <asp:DropDownList ID="DropDownListTimeSlot" runat="server" ValidationGroup="manageFacility">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                </asp:DropDownList>
        

                <h5>Start time</h5>
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
    
                <h5>End time</h5>
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
        <asp:Button ID="buttonCreateFacility" runat="server" OnClick="buttonCreateFacility_Click" Text="Create Facility" ValidationGroup="manageFacility" CssClass="w3-button w3-black w3-padding w3-round"/>  
        <asp:Button ID="buttonUpdateFacility" runat="server" OnClick="buttonUpdateFacility_Click" Text="Update Facility" ValidationGroup="manageFacility" CssClass="w3-button w3-black w3-padding w3-round"/>  

        <asp:Button ID="buttonCancel" runat="server" OnClick="buttonCancel_Click" Text="Cancel" CausesValidation="false" CssClass="w3-button w3-black w3-padding w3-round"/>  
        <asp:HiddenField ID="HiddenFieldFacilityId" runat="server" />
        </p>
    </div>
</asp:Content>