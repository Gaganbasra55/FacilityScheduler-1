<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SDProject_1.Pages.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="divRegisterPage">
        <p>Welcome to our Registration Page</p>
        <p>   
        User Name: <br />
        <asp:TextBox ID="textboxUserName" runat="server"></asp:TextBox> <br />
        First Name: <br />
        <asp:TextBox ID="textboxFirstName" runat="server"></asp:TextBox><br />
        Last Name: <br />
        <asp:TextBox ID="textboxLastName" runat="server"></asp:TextBox><br />
        Email: <br />
        <asp:TextBox ID="textboxEmail" runat="server"></asp:TextBox><br />
        Password: <br />
        <asp:TextBox ID="textboxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        Re-Password: <br />
        <asp:TextBox ID="textboxRepassword" runat="server" TextMode="Password"></asp:TextBox><br />

        <asp:Button ID="buttonRegister" runat="server" OnClick="buttonRegister_Click" Text="Register" /> <br />
        </p>
    </div>
</asp:Content>
