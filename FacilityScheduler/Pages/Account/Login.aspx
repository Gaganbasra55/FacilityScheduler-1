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
      <asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="User Name Required" ControlToValidate="textboxUserName" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:TextBox ID="textboxUserName" runat="server" ValidationGroup="login" OnTextChanged="textboxUserName_TextChanged" CssClass="w3-input w3-border w3-round" placeholder="Username"></asp:TextBox>
			<br />
      <asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password Required" ControlToValidate="textboxPassword" ForeColor="Red"></asp:RequiredFieldValidator>
			<asp:TextBox ID="textboxPassword" runat="server" ValidationGroup="login" CssClass="w3-input w3-border w3-round" placeholder="Password">
			</asp:TextBox>
			<br />
			<asp:Button ID="buttonLogin" runat="server" ValidationGroup="login" OnClick="buttonLogin_Click" Text="Log In" CssClass="w3-button w3-black w3-padding w3-round" />

		</p>
		<p>
            <asp:LinkButton ID="linkButtonRegisterNow" runat="server" OnClick="linkButtonRegisterNow_Click">Register Now</asp:LinkButton>
		</p>

	</div>
</asp:Content>
