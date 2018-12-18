<%@ Page Title="" Language="C#" MasterPageFile="~/4StoreClerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DisbursementList.aspx.cs" Inherits="Team4_Ad.DisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
    <style type="text/css">
        .auto-style2 {
            position: relative;
            display: inline-flex;
            vertical-align: middle;
            margin-left: 1px;
            margin-right: 1px;
            margin-top: 18px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
  <div class="row">
    <div class="col-md-12">
      <div class="card">
        <div class="card-header card-header-primary">
          <h4 class="card-title">Disbursement List</h4>
            </div>
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table">                     
                    <tbody>
                        <tr>                       
                        <td colspan="4" align="center">
                            <div class="btn-group" role="group">
                                <asp:Button type="button" id="Button3" runat="server" class="btn btn-primary" onclick="Button3_Click1" text="Stationery Store"/>
                                <asp:Button type="button" id="Button4" runat="server" class="btn btn-primary" onclick="Button4_Click" text="Management School"/>
                                <asp:Button type="button" id="Button5" runat="server" class="btn btn-primary" onclick="Button5_Click" text="Medical School" />
                                <asp:Button type="button" id="Button6" runat="server" class="btn btn-primary" onclick="Button6_Click" text="Engineering School"/>
                                <asp:Button type="button" id="Button7" runat="server" class="btn btn-primary" onclick="Button7_Click" Text="Science School"/>
                                <asp:Button type="button" id="Button8" runat="server" class="btn btn-primary" onclick="Button8_Click" Text="University Hospital"/>
                         </div>
                        
                        </td></tr>
                      <tr>                       
                        <td colspan="4">
                           <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Align="center" margin-bottom="0px"  BorderWidth="2">
                             <%--<EmptyDataTemplate>
                           <asp:Button ID="Button2" runat="server" Text="Button" />
                             </EmptyDataTemplate>--%>
                           </asp:GridView>                
                       </td></tr>
                        
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>    
   
       


            <%--<asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" style="margin-left: 102px" Text="CP1" />

            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="CP2" />

            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="CP3" />

            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click"  Text="CP4" />

            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="CP5" />
        
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="CP6" />--%>
         
  </div>    
</asp:Content>
