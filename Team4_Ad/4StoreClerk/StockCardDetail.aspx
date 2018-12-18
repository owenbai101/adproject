<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="StockCardDetail.aspx.cs" Inherits="Team4_Ad.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 48px;
        }
    </style>
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
                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>      
                                  </td>
                                </tr>

            <tr>
                <td colspan ="4" align ="Center" > 
                   <asp:GridView ID="GridView1" runat="server" BorderWidth="2">
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
