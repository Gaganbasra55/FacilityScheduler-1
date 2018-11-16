<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FacilitiesSecond.aspx.cs" Inherits="FacilityScheduler.Pages.FacilitiesSecond" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divFacilitiesSecondPage">
    <p>
        Welcome in Facilities Second Page
    </p>
    <p>
        Facility Name: <br />
        <asp:TextBox ID="textboxFacityName" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityName" runat="server" ErrorMessage="Facility name required" ControlToValidate="textboxFacityName" ForeColor="Red"></asp:RequiredFieldValidator><br />
        
        Facility Code:<br />
        <asp:TextBox ID="textboxFacilityCode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacilityCode" runat="server" ErrorMessage="Facility code required" ControlToValidate="textboxFacilityCode" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Facility Description: <br />
        <asp:TextBox ID="textboxFacilityDescription" runat="server"></asp:TextBox><br />
        <%--Email: <br />
        <asp:TextBox ID="textboxEmail" runat="server"></asp:TextBox><br />
        Password: <br />
        <asp:TextBox ID="textboxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        Re-Password: <br />
        <asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password"></asp:TextBox><br />--%>

        <asp:Button ID="buttonCreateFacility" runat="server" OnClick="buttonCreateFacility_Click" Text="Create Facility" /> <br />
        </p>
    </div>
</asp:Content>