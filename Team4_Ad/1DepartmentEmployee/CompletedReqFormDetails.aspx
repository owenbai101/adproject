<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="CompletedReqFormDetails.aspx.cs" Inherits="Team4_Ad.DepartmentEmployee.CompletedReqFormDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <p>
  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/1DepartmentEmployee/CompletedReqForm.aspx">&lt;&lt; Back</asp:HyperLink>
</p>
<div class="row">
  <div class="col-md-12">
    <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title">Completed Requisition Form #<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
           </h4>
             </div>
               <div class="card-body">
                 <div class="table-responsive">
                   <table class="table">                      
                       <tbody>
                         <tr>                       
                           <td colspan="4">
                              <asp:GridView ID="GridView1" Align ="center" runat="server" AutoGenerateColumns="False" BorderWidth="2">
        <Columns>
            <%-- <asp:TemplateField HeaderText="RequId" SortExpression="RequId">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("RequId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="Item" SortExpression="Item">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="RequestedQuantity" SortExpression="RequestedQuantity">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("RequestedQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="OutstandingQuantity" SortExpression="OutstandingQuantity">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OutstandingQuantity") %>'></asp:Label>
                    </ItemTemplate>
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

