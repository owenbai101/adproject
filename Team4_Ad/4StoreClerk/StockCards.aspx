<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="StockCards.aspx.cs" Inherits="Team4_Ad.StockCards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<p>
  <asp:HyperLink ID="HyperLink1" runat="server" style="z-index: 1; position: absolute; top: 190px; left: 0px">&lt;&lt; Back</asp:HyperLink>
</p>
<div class="row">
  <div class="col-md-12">
     <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title">Stock Cards</h4>
            </div>
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table">
                    <thead class="text-primary">
                       <tr>            
                         <td colspan="4" > Select Item Category
                            <asp:Label ID="Label2" runat="server" Text="Search By: "></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="Search" Width="69px" />        
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList> 
                          </td>            
                        </tr>
                     </thead>
                     <tbody>
                       <tr>                       
                         <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DatakeyNames="ItemId"   OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderWidth="2">           
                            <Columns>
                            <asp:TemplateField HeaderText="ItemId" SortExpression="ItemId">
                            <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                            <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Level" SortExpression="ReOrderLevel">
                            <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReOrderLevel") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Qty" SortExpression="ReOrderQty">
                            <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ReOrderQty") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit of measure" SortExpression="UOM">
                            <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance" SortExpression="Stock">
                            <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Button"  ShowSelectButton="True" />
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
