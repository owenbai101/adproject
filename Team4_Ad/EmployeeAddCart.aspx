<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeAddCart.aspx.cs" Inherits="Team4_Ad.EmployeeAddCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="Button1" runat="server" Text="Select again" OnClick="Button1_Click" /><br/>
<asp:Button ID="Button2" runat="server" Text="View Cart" OnClick="Button2_Click" /><br/>
<div class="jumbotron" style="width:90%; margin: 0 auto; background-color:white;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" />
                <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="ReOrderLevel" HeaderText="ReOrderLevel" SortExpression="ReOrderLevel" />
                <asp:BoundField DataField="ReOrderQty" HeaderText="ReOrderQty" SortExpression="ReOrderQty" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
                <asp:BoundField DataField="Bin" HeaderText="Bin" SortExpression="Bin" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
