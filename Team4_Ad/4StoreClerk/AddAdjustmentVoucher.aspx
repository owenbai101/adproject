<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="AddAdjustmentVoucher.aspx.cs" Inherits="Team4_Ad.AddAdjustmentVoucher"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Inventory Status Report</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">
                            <thead class="text-primary">
                                <tr>            
                                  <td colspan="4"> Select Item Category
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="265px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="28px" >                    
                                    </asp:DropDownList> 
                                  </td>            
                                </tr>
                            </thead>
                            <tbody>
                                <tr>                       
                                  <td colspan="4">
                                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  align="Center" DatakeyNames="ItemId" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"> 
                                       <Columns>
                                         <asp:TemplateField HeaderText="Item ID" SortExpression="ItemId">
                                            <ItemTemplate>
                                         <asp:Label ID="Label6" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                                            </ItemTemplate>
                                         </asp:TemplateField>
               <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit of Measure" SortExpression="UOM">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity in System" SortExpression="stock">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Quantity on hand">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="100px" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">
                            
                        </asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason">
                    
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
                <asp:ListItem Value="Wrong Allocation">Wrong Allocation</asp:ListItem>
                <asp:ListItem Value="Missing">Missing</asp:ListItem>
                <asp:ListItem Value="Damaged">Damaged</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                        
                </asp:TemplateField>
                
                 <asp:CommandField HeaderText="Add discrepancies" ButtonType="Button"  ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" SelectText =" Add "/>
                  <asp:TemplateField  SortExpression="stock">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                
            </td></tr>
            <tr>
                <td colspan ="4" > 
                    <br />
                    <br />
                    <asp:Button ID="Button1"  runat="server" Text="View Discrepancies List" OnClick="Button1_Click" /> 

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