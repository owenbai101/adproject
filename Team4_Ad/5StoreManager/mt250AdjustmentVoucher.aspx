<%@ Page Title="" Language="C#" MasterPageFile="~/5StoreManager/Manager.Master" AutoEventWireup="true" CodeBehind="mt250AdjustmentVoucher.aspx.cs" Inherits="Team4_Ad.mt250AdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Authorise Adjustment Form</h4>
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
                                  <td colspan="4">
                                      <asp:GridView ID="GridView2" AutoGenerateColumns="False" runat="server" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Adjustment Voucher Id"   SortExpression="AdjVoucherId">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"  Text='<%# Bind("AdjVoucherId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Checked"   SortExpression="Datechecked">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"  Text='<%# Bind("Datechecked") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item" SortExpression="Item">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity Adjusted" SortExpression="QuantityAdj" >
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("QuantityAdjusted") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Adjusted Cost" SortExpression="Cost" >
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason" SortExpression="Reason">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        

                         <asp:ButtonField CommandName="Issue Voucher" HeaderText="Issue Adjustment voucher" Text="Issue" />
                         
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
