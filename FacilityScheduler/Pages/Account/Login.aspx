<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="w3-bar w3-white w3-center w3-medium">
		<p>
			<asp:TextBox ID="textboxUserName" runat="server" OnTextChanged="textboxUserName_TextChanged" CssClass="w3-input w3-border w3-round" placeholder="Username"></asp:TextBox>
			<br />
			<asp:TextBox ID="textboxPassword" runat="server" CssClass="w3-input w3-border w3-round" placeholder="Password">
			</asp:TextBox>
			<br />
			<asp:Button ID="buttonLogin" runat="server" OnClick="buttonLogin_Click" Text="Log In" CssClass="w3-button w3-black w3-padding w3-round" />

		</p>
		<p>
			<asp:LinkButton ID="linkButtonForgotAccount" runat="server" OnClick="linkButtonForgotAccount_Click">Forgot Account ?</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="linkButtonRegisterNow" runat="server" OnClick="linkButtonRegisterNow_Click">Register Now</asp:LinkButton>
		</p>

	</div>
</asp:Content>
