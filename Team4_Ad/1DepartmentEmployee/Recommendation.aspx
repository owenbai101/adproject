<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="Recommendation.aspx.cs" Inherits="Team4_Ad.Recommendation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:Button ID="Button2" runat="server" Text="View Cart" OnClick="Button2_Click" />
    <div class="row">
  <div class="col-md-12">
    <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title">Top 10 Popular Items
              <asp:Label ID="Label7" runat="server" Text="lab"></asp:Label>
           </h4>
           
             </div>
               <div class="card-body">
                 <div class="table-responsive">
                   <table class="table">                      
                       <tbody>
                         <tr>                       
                           <td colspan="4">
             <asp:GridView ID="GridView1" align="center" runat="server" AutoGenerateColumns="False" DatakeyNames="ItemId" AllowPaging="True" AllowSorting="True" 
                OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" Visible="false" />
               <%-- <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />--%>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
               <%-- <asp:BoundField DataField="ReOrderLevel" HeaderText="ReOrderLevel" SortExpression="ReOrderLevel" />
                <asp:BoundField DataField="ReOrderQty" HeaderText="ReOrderQty" SortExpression="ReOrderQty" />--%>
                <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />
               <%-- <asp:BoundField DataField="Bin" HeaderText="Bin" SortExpression="Bin" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />--%>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
    <%--<br/>
    <div class="jumbotron" style="width:90%; margin: 0 auto; background-color:white;">
        <h1></h1>

        
    </div>--%>
</asp:Content>
