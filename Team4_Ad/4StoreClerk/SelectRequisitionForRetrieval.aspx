<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="SelectRequisitionForRetrieval.aspx.cs" Inherits="Team4_Ad.StoreClerk.SelectRequisitionForRetrieval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Please Select Requisition Form For Collection "></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RequId"  Align="center" BorderWidth="2" >
        <Columns>
            <asp:BoundField DataField="RequId" HeaderText="RequId" readonly="true" SortExpression="Requid" />
            <asp:BoundField DataField="DepartmentCode" HeaderText="DepartmentCode" readonly="true" SortExpression="DepartmentCode" />
            <asp:BoundField DataField="SubmittedDate" HeaderText="SubmittedDate" DataFormatString="{0:dd/MM/yyyy}"  readonly="true" SortExpression="SubmittedDate" />
             <asp:BoundField DataField="Status" HeaderText="Status" readonly="true" SortExpression="Status" />
            <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:CheckBox ID="SelectCheckBox" runat="server" HeaderText="Select" OnCheckedChanged="SelectCheckBox_OnCheckedChanged"/>
            </ItemTemplate>
        </asp:TemplateField>
     
        </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>

    <p>
        <asp:Button ID="Button1" runat="server" Text="Generate Stationery Retrieval Form" align="center" OnClick="Button1_Click"/>
    </p>
</asp:Content>
