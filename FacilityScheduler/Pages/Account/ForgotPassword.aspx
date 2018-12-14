<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="FacilityScheduler.Pages.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-bar w3-white w3-center w3-medium">

        <div id="RequestEmail" runat="server">
            <p>
                Please Enter Your Email!
            </p>
            <p>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Invalid Email!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="textboxForgotPassword" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator> 
                <asp:CustomValidator ID="CustomValidatorExistEmail" runat="server" ErrorMessage="Valid Email Required!" ControlToValidate="textboxForgotPassword" ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidatorExistEmail_ServerValidate"></asp:CustomValidator>                
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorForgotPassword" runat="server" ErrorMessage="Email Required" ControlToValidate="textboxForgotPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>   
                <asp:TextBox ID="textboxForgotPassword" runat="server"></asp:TextBox> 
            </p>
            <p>
                <asp:Button ID="buttonForgotPassword" runat="server" OnClick="buttonForgotPassword_Click" Text="Submit" CssClass="w3-button w3-black w3-padding w3-round" />
                <asp:Button ID="buttonCancel" runat="server" OnClick="buttonCancel_Click" Text="Cancel" CausesValidation="false" CssClass="w3-button w3-black w3-padding w3-round" />
            </p>
        </div><div id="CheckCode" runat="server">
            <p>
                Please Enter the code Received in your email!
            </p>
            <p>
                <asp:CustomValidator ID="CustomValidatorCodeMatch" runat="server" ErrorMessage="Invalid Code!" ControlToValidate="textCode" ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidatorMatchCode_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCode" runat="server" ErrorMessage="Code Required" ControlToValidate="textCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>   
                <asp:TextBox ID="textCode" runat="server"></asp:TextBox> 
            </p>
            <p>
                <asp:Button ID="buttonValidateCode" runat="server" OnClick="buttonCheckCode_Click" Text="Submit" CssClass="w3-button w3-black w3-padding w3-round"/>
                <asp:Button ID="buttonResend" runat="server" OnClick="buttonResendCode_Click" Text="Re-send code" CausesValidation="false" CssClass="w3-button w3-black w3-padding w3-round"/>                
            </p>
        </div>
    </div>

</asp:Content>
