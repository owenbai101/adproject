<%@ Page Title="" Language="C#" MasterPageFile="~/2DepartmentHead/Head.Master" AutoEventWireup="true" CodeBehind="HeadHome.aspx.cs" Inherits="Team4_Ad.DepartmentHead.HeadHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

<div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    
                    <p class="card-category">
                      <asp:Label ID="Label1" runat="server" Text="You have" Font-Size="Medium"></asp:Label>
                      <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                      <asp:label runat="server" text="Requisition forms from the following Staff yet to be authorised:" Font-Size="Medium"></asp:label>
                    </p>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table" >
                            <tbody>
                                <tr >                       
                                  <td align="center">
                                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
onrowdatabound="GridView1_RowDataBound" DataKeyNames="UserId">
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
             
            </Columns>
        </asp:GridView>
                
            </td></tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

