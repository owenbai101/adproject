<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="Team4_Ad.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container-fluid" style="text-align:center;">
    <%--<br/>Welcome to the Stationery Store. Feel free to choose your stationery.--%></div><hr />
    <asp:Button ID="Button2" runat="server" Text="View Cart" OnClick="Button2_Click" /><br/>
    <div class="jumbotron" style="width:90%; margin: 0 auto; background-color:white;">
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="Pick_Command" Width="100%" cssClass="row" RepeatLayout="Flow" RepeatDirection="Horizontal">
    <ItemStyle BorderColor="black" BorderWidth="1px" />
    <ItemTemplate> 
        <br> 
    </br><div class="col-xs-3 col-lg-3"><asp:Label ID="Label2" runat="server" Text='<%# Eval("CategoryId")%>' Visible ="false"></asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName")%>'></asp:Label></div>
    <div class="col-xs-3 col-lg-3"><image src="images/<%# Eval("CategoryId") %>.jpg" width="120" height="120"></image></div>
        <br></br>
    <div class="col-xs-3 col-lg-3"><asp:Button ID="Button1" runat="server" Text="Select"
                     CommandName="Pick" 
                     CommandArgument='<%# Eval("CategoryId") %>' />
   </div>
        <br></br>
    </ItemTemplate>
    </asp:DataList>
    </div>

    <br/><br/>
     <br/><br/> <br/>
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <br/> <br/>
</asp:Content>
