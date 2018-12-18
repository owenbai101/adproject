<%@ Page Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="retrieveReqHistory.aspx.cs" Inherits="Team4_Ad.retrieveReqHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">



    
        <div>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Completed" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Rejected" OnClick="Button2_Click" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="2" DataKeyNames="RequId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        
            <Columns>
            
                <asp:BoundField DataField="RequestedDate" HeaderText="RequestedDate" SortExpression="RequestedDate" />
                <asp:BoundField DataField="SignDate" HeaderText="SignDate" SortExpression="SignDate" />
                <asp:BoundField DataField="SignBy" HeaderText="SignBy" SortExpression="SignBy" />
                <asp:BoundField DataField="CollectionDate" HeaderText="CollectionDate" SortExpression="CollectionDate" />
                <asp:BoundField DataField="ReceivedBy" HeaderText="ReceivedBy" SortExpression="ReceivedBy" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            
                <asp:BoundField DataField="RequId" HeaderText="RequId" ReadOnly="True" SortExpression="RequId" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    

</asp:Content>

