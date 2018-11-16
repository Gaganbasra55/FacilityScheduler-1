<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="FacilityScheduler.Pages.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divForgotPasswordPage">
<p> Welcome to Forgot Password Page</p>
    <p>
        Please Enter Your User Name: <br />
        <asp:TextBox ID="textboxForgotPassword" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorForgotPassword" runat="server" ErrorMessage="User Name Required" ControlToValidate="textboxForgotPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> <br /><br />
        
        <asp:Button ID="buttonForgotPassword" runat="server" OnClick="buttonForgotPassword_Click" Text="Submit & Check your Email" />
    </p>
</div>

</asp:Content>
