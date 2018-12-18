<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="PlacePO.aspx.cs" Inherits="Team4_Ad.PlacePO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
    <div class="col-md-12">
      <div class="card">
        <div class="card-header card-header-primary">
          <h4 class="card-title">Place PO</h4>
           </div>
             <div class="card-body">
               <div class="table-responsive">
                 <table class="table">
                   <thead class="text-primary">
                     <tr>            
                       <td> Category
                          <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="CategoryName" DataValueField="CategoryName" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                          </asp:DropDownList>
                          <asp:DropDownList ID="ItemIdDropDownList" runat="server" Height="23px" Width="191px" OnSelectedIndexChanged="ItemIdDropDownList_SelectedIndexChanged" AutoPostBack="True" >
                          </asp:DropDownList> 
                          <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LastADConnectionString %>" SelectCommand="SELECT [CategoryName] FROM [ItemCategory]"></asp:SqlDataSource>
                        </td>            
                      </tr>

                       <tr>            
                       <td class="auto-style1"> Supplier
                          <asp:DropDownList ID="SupplierDropDownList" runat="server" Height="20px" Width="191px" >
                          </asp:DropDownList>
                           <br />
                        </td>            
                      </tr>

                  </thead>
                  <tbody>
                     <tr>                       
                       <td>
                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDeleting="GridView2_RowDeleting" 
                 DataKeyNames="ItemId" OnRowEditing="OnRowEditing" OnRowUpdating="GridView2_RowUpdating" OnRowCancelingEdit="GridView2_RowCancelingEdit" Align ="center" BorderWidth="2">
                
                <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" ReadOnly="true"/>
                      <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ReadOnly="true" />
                    
                     <asp:TemplateField HeaderText="ReOrderQty" SortExpression="ReOrderQty">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReOrderQty") %>'></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="TextBox1"
                        ErrorMessage="Enter a number"
                        ValidationExpression="^\d+$"
                        Type="Integer">
                    </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextBox1" ForeColor="Red"
                            ErrorMessage="RequiredFieldValidator">Enter a quantity
                        </asp:RequiredFieldValidator>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReOrderQty") %>'></asp:Label>
                         </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="SupplierId" HeaderText="SupplierId" SortExpression="SupplierId" ReadOnly="true" />
             
                     <asp:CommandField ShowEditButton="True" />
                     <asp:CommandField ShowDeleteButton="True" />
             
                     </Columns>
            </asp:GridView>                 
            </td></tr>
            <tr>
                <td align ="Center" > 
            <asp:Button ID="Button3" runat="server" Height="40px" Text="Add Item" Width="211px" OnClick="AddItemButton_Click" />
            <asp:Button ID="Button4" runat="server" Height="40px" Text="Reset" Width="211px" OnClick="ResetButton_Click" />
            <asp:Button ID="Button5" runat="server" Height="40px" Text="Place Order" Width="211px" OnClick="PlaceOrderButton_Click" />
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


           