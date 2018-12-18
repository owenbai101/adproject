<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="UpdateRequisitionForm.aspx.cs" Inherits="Team4_Ad.UpdateRequisitionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<div class="row">
  <div class="col-md-12">
    <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title">Update Requisition Form</h4>
             </div>
               <div class="card-body">
                 <div class="table-responsive">
                   <table class="table">
                      <thead class="text-primary">
                        <tr>            
                          <td Align ="center" colspan="5"> 
                             <div class="btn-group"  role="group">
                                       <asp:Button type="button" id="Button1" runat="server" class="btn btn-primary" onclick="Button1_Click" text="Pending Approval"/>
                                       <asp:Button type="button" id="Button3" runat="server" class="btn btn-primary" onclick="Button3_Click" text="Waiting for Collection"/>
                                       <asp:Button type="button" id="Button4" runat="server" class="btn btn-primary" onclick="Button4_Click" text="Waiting for Delivery" />
                                       <asp:Button type="button" id="Button5" runat="server" class="btn btn-primary" onclick="Button5_Click" text="Completed"/>
                                       <asp:Button type="button" id="Button2" runat="server" class="btn btn-primary" onclick="Button2_Click" Text="Rejected"/>
                                      </div>
                           </td>   
                         </tr>
                       </thead>
                       <tbody>
                         <tr>                       
                           <td colspan="4">
                            <asp:GridView ID="GridView1" Align="center" runat="server" AutoGenerateColumns="False"
            DataKeyNames="RequId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderWidth="2" >
        <Columns>
            <asp:BoundField DataField="RequId" HeaderText="RequId" readonly="true" SortExpression="RequId" />
            <asp:BoundField DataField="Name" HeaderText="Submitted By" readonly="true" SortExpression="Name" />
            <asp:BoundField DataField="RequestedDate" HeaderText="RequestedDate" DataFormatString="{0:dd/MM/yyyy}" readonly="true" SortExpression="RequestedDate" />
             <asp:BoundField DataField="Status" HeaderText="Status" readonly="true" SortExpression="Status" />
            
        <asp:CommandField ButtonType="Button" ShowSelectButton="True"/>
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
