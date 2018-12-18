<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="PODelivery.aspx.cs" Inherits="Team4_Ad.PODelivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">View PO </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">                            
                            <tbody>
                                <tr>                       
                                  <td colspan="4">
                                    <asp:GridView ID="GridView1" runat="server" DatakeyNames="PurchaseOrderId" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AutoGenerateSelectButton="true" EnablePersistedSelection="True" AutoGenerateColumns="false" Align ="center" BorderWidth="2">
                                         
                                         <Columns>

                                         <asp:BoundField DataField="PurchaseOrderId" HeaderText="PurchaseOrderId" SortExpression="PurchaseOrderId"  />
                                         <asp:BoundField DataField="SupplierCode" HeaderText="SupplierCode" SortExpression="SupplierCode" />
                                         <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" SortExpression="PurchaseDate" />
                                        
                                        
                                        </Columns>
       
            </asp:GridView>                
            </td></tr>
            <tr>
                <td colspan ="4" > 
                    <br />
                    <br />

                </td>

            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Inventory Status Report</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">                            
                            <tbody>
                                <tr>                       
                                  <td colspan="4">
                                     <asp:GridView ID="GridView2" runat="server" Align ="center" BorderWidth="2" >
        </asp:GridView>     
            </td></tr>
            <tr>
                <td colspan ="4"> 
                    <br />
                    <br />
                    &nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Comfirm Received"  />
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
