<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facilities.aspx.cs" Inherits="FacilityScheduler.Pages.Facilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
        <h5>Search a facility
        <asp:TextBox ID="TextBoxSearchFacility" runat="server" ValidationGroup="searchGroup" CssClass="w3-round w3-margin-left"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="searchGroup" OnClick="SearchButton_Click" CssClass="w3-button w3-black w3-padding w3-round w3-medium" />
        </h5>
        <div id="tableFacilities" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="FacilitiesTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                </asp:table>
            </p>
        </div>
        <div id="NoFacilityElements" runat="server">
            <h5>There are no Facilities!</h5>
        </div>

    <p>
	    <asp:Button ID="AddFacility" runat="server" OnClick="addFacility_Click"  ValidationGroup="addGroup" Text="Add Facility" CssClass="w3-button w3-black w3-padding w3-round"/>
    </p>
  <%--
        A gridview if need   
          --%>
  <%-- 
    <asp:GridView ID="gridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

     <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="TypeId_Fk" HeaderText="TypeId_Fk" SortExpression="TypeId_Fk" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        <asp:BoundField DataField="Descripton" HeaderText="Descripton" SortExpression="Descripton" />
        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
    </Columns>

    </asp:GridView>

      --%>

</div>
</asp:Content>
