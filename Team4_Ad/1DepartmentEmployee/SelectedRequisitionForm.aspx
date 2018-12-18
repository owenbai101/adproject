<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="SelectedRequisitionForm.aspx.cs" Inherits="Team4_Ad.SelectedRequisitionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <p>
  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/1DepartmentEmployee/UpdateRequisitionForm.aspx">&lt;&lt; Back</asp:HyperLink>
</p>
<div class="row">
  <div class="col-md-12">
    <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title">Requisition Form #
              <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
           </h4>
             </div>
               <div class="card-body">
                 <div class="table-responsive">
                   <table class="table">                      
                       <tbody>
                         <tr>                       
                           <td colspan="4">
                            <asp:GridView ID="GridView1" Align ="center" runat="server" AutoGenerateColumns="False" BorderWidth="2" DataKeyNames="RequDetailId"
            OnRowDeleting="OnRowDeleting" 
            OnRowEditing="OnRowEditing" 
            OnRowCancelingEdit="OnRowCancelingEdit"
            OnRowUpdating="OnRowUpdating">
        <Columns>
             <asp:TemplateField HeaderText="RequDetailId" SortExpression="RequDetailId" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RequDetailId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="Item" SortExpression="Item">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="RequestedQuantity" SortExpression="RequestedQuantity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RequestedQuantity") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("RequestedQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="OutstandingQuantity" SortExpression="OutstandingQuantity">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("OutstandingQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
       <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
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
