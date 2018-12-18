<%@ Page Title="" Language="C#" MasterPageFile="~/1DepartmentEmployee/Employee.Master" AutoEventWireup="true" CodeBehind="Add Stationary Confirmation.aspx.cs" Inherits="Team4_Ad.Add_Stationary_Comfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">


    <br />
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Font-Size="X-Large" Text="List of stationery that you have chosen to order:"></asp:Label>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DatakeyNames="ItemId" OnRowDeleting="GridView1_RowDeleting">
         
         <Columns>

              <asp:BoundField DataField="ItemId" HeaderText="Item Number" SortExpression="ItemId" Visible ="false" />
               <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
             <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="100px" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="TextBox1"
                        ErrorMessage="Enter a number"
                        ValidationExpression="^\d+$"
                        Type="Integer">
                    </asp:RegularExpressionValidator>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextBox1" ForeColor="Red"
                            ErrorMessage="RequiredFieldValidator">Enter a quantity
                        </asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Action" />
              
             
              
              </Columns>
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add New Item" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
    <br />

</asp:Content>
