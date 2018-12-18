<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DiscrepancyListSubmitted.aspx.cs" Inherits="Team4_Ad.DiscrepancyListSubmitted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">
                            <tbody>            
                              <tr>                        
                                <td colspan="4">
                                    <asp:Label ID="Label1" align="center" runat="server" Text="Label"> Discrepancy List Submitted!!</asp:Label>
                                </td></tr>
                                <tr>
                               <td >
                               <asp:Button ID="Button1" align="center" runat="server" Text="Return to homepage" OnClick="Button1_Click" />
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


    <%--<table ID="Table1" width="90%" align="center" runat="server">
        <tr>
            <th align="center">
                <asp:Label ID="Label1" align="center" runat="server" Text="Label"> Discrepancy List Submitted!!</asp:Label>
            </th>
        </tr>
        <br />
        <br />
        <tr>
            <td align="center">
                <asp:Button ID="Button1" align="center" runat="server" Text="Return to homepage" OnClick="Button1_Click" />
            </td>
        </tr>


    
        </table>--%>

