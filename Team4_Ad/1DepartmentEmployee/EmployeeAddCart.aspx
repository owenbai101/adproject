<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeAddCart.aspx.cs" Inherits="Team4_Ad.EmployeeAddCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <!--Breadcrumbs-->
            <ol class="breadcrumb">
              <li class="breadcrumb-item">
                <a href="EmployeeHome.aspx">Add Cart</a>
              </li>
              <li class="breadcrumb-item active">Add item</li>
            </ol>  
<asp:Button ID="Button1" runat="server" Text="Add More" OnClick="Button1_Click" />&nbsp&nbsp
<asp:Button ID="Button2" runat="server" Text="View Cart" OnClick="Button2_Click" /><br/>
<div class="jumbotron" style="width:90%; margin: 0 auto; background-color:white;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BorderWidth="2"
                OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" />
                <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="ReOrderLevel" HeaderText="ReOrderLevel" SortExpression="ReOrderLevel" Visible="false" />
                <asp:BoundField DataField="ReOrderQty" HeaderText="ReOrderQty" SortExpression="ReOrderQty" Visible="false" />
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM"  />
                <asp:BoundField DataField="Bin" HeaderText="Bin" SortExpression="Bin" Visible="false" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" Visible="false"/>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                 <asp:TemplateField  >
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
