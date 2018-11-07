<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SDProject_1.Pages.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="loginPage">
        <p>Welcome to our Login Page</p>
        <p>
             User Name: <br />
        <asp:TextBox ID="textboxUserName" runat="server"></asp:TextBox> <br />

             Password: <br />
        <asp:TextBox ID="textboxPassword" runat="server"></asp:TextBox><br />
        <asp:Button ID="buttonLogin" runat="server" OnClick="buttonLogin_Click" Text="Log In" />
    
        </p>
        <p>
        <asp:LinkButton ID="linkButtonForgotAccount" runat="server" OnClick="linkButtonForgotAccount_Click">Forgot Account ?</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="linkButtonRegisterNow" runat="server" OnClick="linkButtonRegisterNow_Click">Register Now</asp:LinkButton>
         </p>

    </div>
</asp:Content>
