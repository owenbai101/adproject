<%@ Page Title="" Language="C#" MasterPageFile="~/2DepartmentHead/Head.Master" AutoEventWireup="true" CodeBehind="DelegateRep.aspx.cs" Inherits="Team4_Ad.DelegateRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<br/><h1>Delegate Authority</h1>
<div class="jumbotron" style="width:90%; margin: 0 auto; background-color:white;">
<%--<div class="container-fluid" style="background-color:lightblue; text-align:center;">
  RoleId Legend: 1 = Store Clerk; 2 = Supervisor; 3 = Manager; 4 = Employee; 5 = Department Representative; 6 = Department Head
</div></br>--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="OnRowEditing" 
onrowdatabound="GridView1_RowDataBound" OnRowUpdating="OnRowUpdating" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="UserId">
            <Columns>
                <asp:TemplateField HeaderText="UserId" SortExpression="UserId" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Picture" SortExpression="Picture" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate >
                        <image src="images/<%# Eval("UserId") %>user.jpg" width="120" height="120"></image>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RoleDescription" SortExpression="RoleDescription" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("RoleDescription") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" ItemStyle-HorizontalAlign="center">
                    <EditItemTemplate>
                    <%--<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StartDate") %>'> </asp:TextBox>--%>
                        <asp:Calendar ID="Calendar1" runat="server" ></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" ItemStyle-HorizontalAlign="center">
                    <EditItemTemplate>
                        <%--<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("EndDate") %>'></asp:TextBox>--%>
                        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True"/>
            </Columns>
        </asp:GridView>
    <br/>
</div>
</asp:Content>
