<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 232px;
        }
        .auto-style3 {
            width: 140px;
        }
        .auto-style4 {
            width: 448px;
        }
        .auto-style5 {
            width: 140px;
            height: 43px;
        }
        .auto-style6 {
            width: 232px;
            height: 43px;
        }
        .auto-style7 {
            width: 448px;
            height: 43px;
        }
        .auto-style8 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="w3-bar w3-white w3-center w3-medium">
		<p>
            <asp:CustomValidator ID="CustomValidatorValid" ValidationGroup="login" runat="server" ErrorMessage="Invalid Email or Password!" ControlToValidate="textboxUserName" ForeColor="Red" OnServerValidate="AuthenticateUser" Display="Dynamic" ></asp:CustomValidator>
            <asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="User Name Required" ControlToValidate="textboxUserName" ForeColor="Red" Display="Dynamic" ></asp:RequiredFieldValidator>
			<asp:TextBox ID="textboxUserName" runat="server" ValidationGroup="login" CssClass="w3-input w3-border w3-round" placeholder="Username"></asp:TextBox>
			 
            <asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password Required" ControlToValidate="textboxPassword" ForeColor="Red" Display="Dynamic" ></asp:RequiredFieldValidator>
			<asp:TextBox ID="textboxPassword" TextMode="Password" runat="server" ValidationGroup="login" CssClass="w3-input w3-border w3-round" placeholder="Password">
			</asp:TextBox>
            </p>
			 <hr/>
		<p>
			<asp:Button ID="buttonLogin" runat="server" ValidationGroup="login" OnClick="buttonLogin_Click" Text="Log In" CssClass="w3-button w3-black w3-padding w3-round" />

		</p>
		<p>
            <asp:LinkButton ID="linkButtonRegisterNow" runat="server" OnClick="linkButtonRegisterNow_Click">Register Now</asp:LinkButton>
            <asp:LinkButton ID="linkButtonForgotPassword" runat="server" OnClick="linkButtonForgotPassword_Click">Forgot Password</asp:LinkButton>
		</p>

	</div>
</asp:Content>
