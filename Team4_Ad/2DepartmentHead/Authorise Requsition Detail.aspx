<%@ Page Title="" Language="C#" MasterPageFile="~/2DepartmentHead/Head.Master" AutoEventWireup="true" CodeBehind="Authorise Requsition Detail.aspx.cs" Inherits="Team4_Ad.Authorise_Requsition_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <p>
   <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Authorise Requsition list.aspx">&lt;&lt;Back</asp:HyperLink>
</p>
 <div class="row">
  <div class="col-md-12">
    <div class="card">
      <div class="card-header card-header-primary">
        <h4 class="card-title">Authorise Requsition Detail</h4>
          </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table">
                  <thead class="text-primary">
                    <tr>            
                      <td colspan="4"> 
                          <asp:Label ID="Label1" runat="server" Text="Requisiton Form ID:"></asp:Label>
                          <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                      </td>            
                     </tr>
                   </thead>
         <tbody>
         <tr>                       
          <td colspan="4">
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  style="margin-left: 286px" Align ="center" BorderWidth="2">           
            <Columns>
                <asp:TemplateField HeaderText="No." >
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Id#" SortExpression="itemid">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Name" SortExpression="name">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>               
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
      <div class="col-md-12">
    <div class="card">
      <div class="card-header card-header-primary">
       <asp:Label ID="Label8" runat="server" Text="Reason"></asp:Label>
      </div>
      <div class="card-body">
       <asp:TextBox ID="TextBox2" runat="server" Height="71px" Width="443px"></asp:TextBox>
      </div>
      </div>
      </div>
    </div>
                
    
   <div class="btn-group" role="group" align="center">
         <asp:Button ID="Button1" runat="server" Text="Approve" OnClick="Button1_Click" class="btn-success" />
    
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reject" Width="89px" class="btn-danger" />
  </div>
 
</asp:Content>
