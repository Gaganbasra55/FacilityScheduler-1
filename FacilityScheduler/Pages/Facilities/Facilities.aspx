<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facilities.aspx.cs" Inherits="FacilityScheduler.Pages.Facilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="w3-center">
    <p>

        <asp:Label ID="Label1" runat="server" Text="Search a facility"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="TextBoxSearchFacility" runat="server" ValidationGroup="searchGroup"></asp:TextBox>&nbsp;&nbsp;
        <!--
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSearchFacility" runat="server" ErrorMessage="Fred Help us!!!" ControlToValidate="textboxSearchFacility" ForeColor="Red"></asp:RequiredFieldValidator> 
         -->
        <asp:Button ID="SearchButton" runat="server" Text="Search" ValidationGroup="searchGroup" OnClick="SearchButton_Click" />
    </p>

        <div id="tableFacilities" runat="server" CssClass="w3-center">
            <p>
                <asp:table id="FacilitiesTable" runat="server" BackColor="#99FF66" BorderColor="#000066" BorderStyle="Ridge" ForeColor="#333300" GridLines="Horizontal" HorizontalAlign="Center" Width="75%">
                    <asp:TableRow >
                        <asp:TableCell>Facility</asp:TableCell>
                        <asp:TableCell>Time Slot</asp:TableCell>
                        <Asp:TableCell>Start Time</Asp:TableCell>
                        <Asp:TableCell>End Time</Asp:TableCell>
                        <Asp:TableCell> </Asp:TableCell>
                        <Asp:TableCell> </Asp:TableCell>
                    </asp:TableRow>
                </asp:table>
            </p>
        </div>
        <div id="NoFacilityElements" runat="server">
            There is no element!
        </div>

    <p>
	    <asp:Button ID="AddFacility" runat="server" OnClick="addFacility_Click"  ValidationGroup="addGroup" Text="Add Facility" CssClass="textBox"/>
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
