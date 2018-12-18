<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="ClerkHome.aspx.cs" Inherits="Team4_Ad.StoreClerk.ClerkHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 429px;
        }
        .auto-style2 {
            margin-left: 431px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
       <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Notification</h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table">           
                            <tbody>
                                <tr>                       
                                  <td colspan="4">
                              <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>       
                
            </td></tr>
            <tr>
                <td colspan ="4" > 
                    <br />
                    <br />
                     <asp:Button ID="Button1" runat="server" Text="Check detail" CssClass="auto-style2" OnClick="Button1_Click" Width="121px" />
                </td></tr>
  
    <tr>                       
          <td colspan="4"> 
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>                  
   </td></tr>

    <tr>
          <td colspan ="4" > 
                   <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" CssClass="auto-style1" OnClick="Button2_Click" Text="Check detail" Width="129px" />

                </td> </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
