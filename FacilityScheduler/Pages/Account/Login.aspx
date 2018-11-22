<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Login" %>

<html>
<head runat="server">
	<title></title>
	<!--<link href="Style/StyleSheet.css" rel ="stylesheet" type="text/css"/>-->
	<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
	<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<style>
		body, h1, h2, h3, h4, h5, h6 {
			font-family: "Raleway", Arial, Helvetica, sans-serif
		}

		.mySlides {
			display: none
		}
	</style>

</head>
<body>
	<form id="form1" runat="server">
		<div class="w3-center">
			<asp:Image class="w3-image" runat="server" ImageUrl="~/images/logo_fs.png" Width="384" Height="192" />
			<div class="w3-margin-left w3-margin-right">
				<hr>
			</div>
			<div class="w3-bar w3-white w3-center w3-medium">
				<div class="w3-center w3-row-padding">
					<asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="User Name Required" ControlToValidate="textboxUserName" ForeColor="Red"></asp:RequiredFieldValidator>
					<asp:TextBox ID="textboxUserName" runat="server" ValidationGroup="login" OnTextChanged="textboxUserName_TextChanged" CssClass="w3-input w3-border w3-round" placeholder="Username"></asp:TextBox>

					<asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password Required" ControlToValidate="textboxPassword" ForeColor="Red"></asp:RequiredFieldValidator>
					<asp:TextBox TextMode="Password" ID="textboxPassword" runat="server" ValidationGroup="login" CssClass="w3-input w3-border w3-round" placeholder="Password">
					</asp:TextBox>
					<br />
					<asp:Button ID="buttonLogin" runat="server" ValidationGroup="login" OnClick="buttonLogin_Click" Text="Log In" CssClass="w3-button w3-black w3-padding w3-round" />
					<h5>
						<asp:LinkButton ID="linkButtonRegisterNow" runat="server" OnClick="linkButtonRegisterNow_Click" CssClass="w3-medium">Register Now</asp:LinkButton>
					</h5>
				</div>

			</div>
		</div>
	</form>
	<!-- Footer -->
	<footer class="w3-padding w3-center w3-margin-top">
		<div class="w3-margin-left w3-margin-right">
			<hr>
		</div>
		<p>COMP 231 – 007 Software Development Project 1</p>
		<p>Developed By: Frederico, Shyam, Gagandeep, Tanureet, Mashud, Gaurav </p>
	</footer>
</body>
</html>
