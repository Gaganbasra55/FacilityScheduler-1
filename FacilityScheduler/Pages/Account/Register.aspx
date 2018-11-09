<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FacilityScheduler.Pages.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="registerPage">
        <p>Welcome to our Registration Page</p>
        <p>   
        User Name: &nbsp;
        <asp:TextBox ID="textboxUserName" runat="server" CssClass="textBox"></asp:TextBox> <br />
        First Name: &nbsp;
        <asp:TextBox ID="textboxFirstName" runat="server" CssClass="textBox"></asp:TextBox><br />
        Last Name: &nbsp;
        <asp:TextBox ID="textboxLastName" runat="server" CssClass="textBox"></asp:TextBox><br />
        Email: &nbsp;
        <asp:TextBox ID="textboxEmail" runat="server" CssClass="textBox"></asp:TextBox><br />
        Password: &nbsp;
        <asp:TextBox ID="textboxPassword" runat="server" TextMode="Password" CssClass="textBox"></asp:TextBox><br />
        Re-Password: &nbsp;
        <asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password" CssClass="textBox"></asp:TextBox><br />

        <asp:Button ID="buttonRegister" runat="server" OnClick="buttonRegister_Click" Text="Register" /> <br />
        </p>
    </div>
</asp:Content>
