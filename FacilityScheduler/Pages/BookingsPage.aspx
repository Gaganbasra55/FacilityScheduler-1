<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingsPage.aspx.cs" Inherits="FacilityScheduler.Pages.BookingsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<asp:DropDownList ID="DropDownList" runat="server" DataSourceID="SqlDataSourceFacilityList" DataTextField="name" DataValueField="facility_id" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

	<asp:SqlDataSource ID="SqlDataSourceFacilityList" runat="server" ConnectionString="<%$ ConnectionStrings:FSConnectionString %>" SelectCommand="SELECT [facility_id], [name] FROM [Facility]"></asp:SqlDataSource>

	<br />
	<br />
	<br />

<%--	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceBookings">
		<Columns>
			<asp:BoundField DataField="booking_id" HeaderText="booking_id" InsertVisible="False" ReadOnly="True" SortExpression="booking_id" />
			<asp:BoundField DataField="facility_id" HeaderText="facility_id" SortExpression="facility_id" />
			<asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" />
			<asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
			<asp:BoundField DataField="time_start" HeaderText="time_start" SortExpression="time_start" />
			<asp:BoundField DataField="time_slots" HeaderText="time_slots" SortExpression="time_slots" />
		</Columns>
	</asp:GridView>--%>

	<asp:SqlDataSource ID="SqlDataSourceBookings" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSQL %>" SelectCommand="SELECT * FROM [Booking] WHERE ([facility_id] = @facility_id)">
		<SelectParameters>
			<asp:ControlParameter ControlID="DropDownList" DefaultValue="0" Name="facility_id" PropertyName="SelectedValue" Type="Int32" />
		</SelectParameters>
	</asp:SqlDataSource>

	<asp:Label runat="server" ID="lbl_error" />

	<br />
	<br />

	<table id="tableContent" border="1" runat="server" class="w3-table w3-centered w3-small"></table>
</asp:Content>
