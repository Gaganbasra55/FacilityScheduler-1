<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Register" %>

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
						<asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password does not match" ControlToCompare="textboxPassword" ForeColor="Red" Display="Dynamic" ControlToValidate="textboxRepassword"></asp:CompareValidator>
						<asp:RequiredFieldValidator ID="RequiredFieldValidatorRepassword" runat="server" ErrorMessage="Re-enter the password" ControlToValidate="textboxRepassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
						<asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password" CssClass="w3-input w3-border w3-round "></asp:TextBox>
					</div>

					<div class="w3-padding w3-large w3-right-align">
						<asp:Button ID="buttonRegister" runat="server" OnClick="buttonRegister_Click" Text="Register" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
					</div>

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
