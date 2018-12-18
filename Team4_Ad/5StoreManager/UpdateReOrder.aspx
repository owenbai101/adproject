<%@ Page Title="" Language="C#" MasterPageFile="~/5StoreManager/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateReOrder.aspx.cs" Inherits="Team4_Ad.UpdateReOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Update ReOrder Level</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">
                            <%--<thead class="text-primary">
                                <tr>            
                                  <td colspan="4" align ="Center"> Authorise Adjustment Form </td>                                                                                
                                </tr>
                            </thead>--%>
                            <tbody>
                                <tr>  
                                    <td>
                                    <asp:Label ID="Label10" runat="server" Text="Item: "></asp:Label><asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                <tr>  
                                    <td>
                                    <asp:Label ID="Label6" runat="server" Text="Current Stock count: "></asp:Label><asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                <tr><td>
                                    <asp:Label ID="Label7" runat="server" Text="Number of Re-Orders for the past 6 months: "></asp:Label><asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                  <td colspan="4">
                                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="OnRowEditing" AllowPaging="True"
OnRowUpdating="OnRowUpdating" OnRowCancelingEdit="OnRowCancelingEdit" DataKeyNames="ItemId" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="ItemId" SortExpression="ItemId" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UOM" SortExpression="UOM" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="ReOrderLevel" SortExpression="ReOrderLevel">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReOrderLevel") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ReOrderLevel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReOrderQty" SortExpression="ReOrderQty">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReOrderQty") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ReOrderQty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True"/>
            </Columns>
        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                         </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>