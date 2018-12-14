<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FacilityScheduler.Pages.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
        <h5>Dashboard</h5>                
        <div id="table" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="DashboardTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
        <div id="NoElements" runat="server">
            <h5>There are no User without validation!</h5>
        </div>    

</div>
</asp:Content>
