<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUserAccount.aspx.cs" Inherits="FacilityScheduler.Pages.ManageUserAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-small">
	<h3 runat="server" id ="Account">User Account</h3>
	<div class="w3-bar w3-center w3-row-padding w3-small">

		<div class="w3-padding w3-left-align">
			<h5>Email:</h5>            
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ValidationGroup="Register" ErrorMessage="Email Required" ControlToValidate="textboxEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" ValidationGroup="Register" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="textboxEmail" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator> 
			<asp:TextBox ID="textboxEmail" runat="server" ValidationGroup="Register" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>

		<div class="w3-half w3-padding w3-left-align">
			<h5>First Name:</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ValidationGroup="Register" runat="server" ErrorMessage="First Name Required" ControlToValidate="textboxFirstName" ForeColor="Red"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxFirstName" runat="server" ValidationGroup="Register" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>
		<div class="w3-half w3-left-align w3-padding">
			<h5>Last Name: &nbsp;</h5>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ValidationGroup="Register" runat="server" ErrorMessage="Last Name Required" ControlToValidate="textboxLastName" ForeColor="Red"></asp:RequiredFieldValidator> 
			<asp:TextBox ID="textboxLastName" runat="server" ValidationGroup="Register" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		</div>
		 

		<div class="w3-left-align w3-padding">            
			<h5>Role: &nbsp;</h5>
            <div class="w3-padding w3-large w3-left-align">
			    <asp:DropDownList ID="DropDownListCategory" runat="server"></asp:DropDownList>
		    </div>		
		</div>		
		 
		<div class="w3-padding w3-left-align w3-large">
			<asp:Button ID="buttonSave" runat="server" ValidationGroup="Register" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
			<asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
		</div>
        <asp:HiddenField ID="HiddenFieldId" runat="server" />
        <asp:HiddenField ID="HiddenFieldPW" runat="server" />
        <asp:HiddenField ID="HiddenFieldVerified" runat="server" />
	</div>
		</div>

</asp:Content>
