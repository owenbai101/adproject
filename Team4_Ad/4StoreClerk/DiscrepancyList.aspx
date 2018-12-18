<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DiscrepancyList.aspx.cs" Inherits="Team4_Ad.DiscrepanciesList" %>
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
                                  <td colspan="4"> Discrepancy List</td>                                                                                 
                                </tr>
                            </thead>
                            <tbody>            
                              <tr>                        
            <td colspan="4">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  align="Center" DataKeyNames="ItemId" OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" >
            <Columns>
                 <asp:TemplateField HeaderText="Item ID" SortExpression="ItemId">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Adjusted Quantity" SortExpression="AdjustedQuantity">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AdjustedQuantity") %>'></asp:Label>
                    </ItemTemplate>
                   <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("AdjustedQuantity") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason" SortExpression="Reason">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>            
             <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowDeleteButton="True" HeaderText="Action" />
                    
            </Columns>
        </asp:GridView>               
            </td></tr>
            <tr>
                <td colspan ="4"> 
                    <asp:Button ID="Button1"  runat="server" Text="Submit Request" OnClick="Button1_Click" /> 

                </td>

            </tr>
        </tbody>
                        </table>
                    </div>
                <div>
            </div>
            </div>
        </div>
       </div>
     </div>
</asp:Content>
