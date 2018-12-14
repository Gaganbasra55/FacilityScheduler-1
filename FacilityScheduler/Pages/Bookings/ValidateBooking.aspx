<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ValidateBooking.aspx.cs" Inherits="FacilityScheduler.Pages.Bookings.ValidateBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="SendCode" runat="server">
            <p>
                Click to send a Code!
            </p>            
            <p>
                <asp:Button ID="button2" runat="server" OnClick="buttonResendCode_Click" Text="Re-send code" CausesValidation="false" CssClass="w3-button w3-black w3-padding w3-round"/>                
            </p>
        </div>
    <div id="CheckCode" runat="server">
            <p>
                Please Enter the Access Code!
            </p>
            <p>
                <asp:CustomValidator ID="CustomValidatorCodeMatch" runat="server" ErrorMessage="Invalid Code!" ControlToValidate="textCode" ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidatorMatchCode_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCode" runat="server" ErrorMessage="Code Required" ControlToValidate="textCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>   
                <asp:TextBox ID="textCode" runat="server"></asp:TextBox> 
            </p>
            <p>
                <asp:Button ID="buttonValidateCoce" runat="server" OnClick="buttonCheckCode_Click" Text="Submit" CssClass="w3-button w3-black w3-padding w3-round"/>
                <asp:Button ID="buttonResend" runat="server" OnClick="buttonResendCode_Click" Text="Re-send code" CausesValidation="false" CssClass="w3-button w3-black w3-padding w3-round"/>                

            </p>
        </div>
                    <asp:HiddenField ID="HiddenFieldId"  runat="server"/>
                <asp:HiddenField ID="HiddenFieldEmail"  runat="server"/>
                <asp:HiddenField ID="HiddenFieldUserId"  runat="server"/>
</asp:Content>
