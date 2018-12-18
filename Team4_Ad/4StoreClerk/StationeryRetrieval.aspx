<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="StationeryRetrieval.aspx.cs" Inherits="Team4_Ad.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <p>
        &nbsp;</p>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Stationery Retrival Form</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">                            
                            <tbody>
                                <tr>                       
                                  <td colspan="4">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Align ="center" BorderWidth="2">
                <Columns>
                <asp:TemplateField HeaderText="No." >
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bin#" SortExpression="bin">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("bin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Number" SortExpression="itemid">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stationery Description" SortExpression="itemname">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("itemname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity Request" SortExpression="quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="need Retrive">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="100px" ReadOnly="true"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>     
                                      <br />
            </td></tr>
            <tr>

        
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generate Disbursement List" />
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </div>          
</asp:Content>


