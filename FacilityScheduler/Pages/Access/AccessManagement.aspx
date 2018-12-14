<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AccessManagement.aspx.cs" Inherits="FacilityScheduler.Pages.Bookings.AccessManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="w3-center">
        <h5>Facility Access</h5>                
        <div id="table" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="FacilityTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
</div>
</asp:Content>
