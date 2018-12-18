<%@ Page Title="" Language="C#" MasterPageFile="~/2DepartmentHead/Head.Master" AutoEventWireup="true" CodeBehind="Authorise Requsition list.aspx.cs" Inherits="Team4_Ad.Authorise_Requsition_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Authorise Requistions</h4>
                    <p class="card-category">
                      <asp:Label ID="Label1" runat="server" Text="You have" Font-Size="Medium"></asp:Label>
                      <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                      <asp:label runat="server" text="Requisition forms from the following Staff yet to be authorised:" Font-Size="Medium"></asp:label>
                    </p>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table" >
                            <%--<thead class="text-primary">
                                <tr>            
                                  <td colspan="4" align ="Center"> Select Item Category
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="265px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="28px" >                    
                                    </asp:DropDownList> 
                                  </td>            
                                </tr>
                            </thead>--%>
                            <tbody>
                                <tr >                       
                                  <td  colspan="4">
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DatakeyNames="RequId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Align ="center"   BorderWidth="2" >
          
            <Columns>
                <asp:TemplateField HeaderText="No." >
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Requisition Form Id" SortExpression="Requid">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Requid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Submitted By" SortExpression="name">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date Submitted" SortExpression="SubmittedDate">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("SubmittedDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="status">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button"  ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
                
            </td></tr>
           <%-- <tr>
                <td colspan ="4"> 
                    <br />
                    <br />
                    <asp:Button ID="Button1"  runat="server" Text="View Discrepancies List" OnClick="Button1_Click" /> 

                </td>

            </tr>--%>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
