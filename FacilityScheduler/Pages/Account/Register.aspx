<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="w3-small">
	<h3>Registration</h3>
	<div class="w3-bar w3-center w3-row-padding w3-small">

		<div class="w3-padding w3-left-align">
			<h5>Email:</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email Required" ControlToValidate="textboxEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="textboxEmail" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator> 
			<asp:TextBox ID="textboxEmail" runat="server" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>

		<div class="w3-half w3-padding w3-left-align">
			<h5>First Name:</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="First Name Required" ControlToValidate="textboxFirstName" ForeColor="Red"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxFirstName" runat="server" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>
		<div class="w3-half w3-left-align  w3-padding">
			<h5>Last Name: &nbsp;</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name Required" ControlToValidate="textboxLastName" ForeColor="Red"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxLastName" runat="server" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>
		 

		<div class="w3-half w3-left-align w3-padding">
			<h5>Password: &nbsp;</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password Required" ControlToValidate="textboxPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxPassword" runat="server" TextMode="Password" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>
		<div class="w3-half w3-left-align  w3-padding">
			<h5>Re-Password: &nbsp;</h5>
			<asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password does not match" ControlToCompare="textboxPassword" ForeColor="Red"  Display="Dynamic" ControlToValidate="textboxRepassword"></asp:CompareValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorRepassword" runat="server" ErrorMessage="Re-enter the password" ControlToValidate="textboxRepassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password" CssClass="w3-input w3-border w3-round "></asp:TextBox>
		</div>
		 
		<div class="w3-padding w3-large w3-right-align">
			<asp:Button ID="buttonRegister" runat="server" OnClick="buttonRegister_Click" Text="Register" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
		</div>
		 
	</div>
		</div>

</asp:Content>
