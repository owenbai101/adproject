<%@ Page Title="" Language="C#" MasterPageFile="~/6StoreSupervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Chart_ItemReqTrendAnalysis.aspx.cs" Inherits="Team4_Ad.Chart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<table ID="Table1" runat="server">
        <tr>
            <td colspan="6">
                <h2>Item Requisition Trend Analysis By Year</h2>
            </td>
        </tr>
        <tr>
            <td >
                Select Item Category:
            </td>
            <td >
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
               <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1" InitialValue="---Select---"
             ErrorMessage="* Please select an item category." ForeColor="Red"  >
        </asp:RequiredFieldValidator> 
            </td>
            <td >
                Select Item:
            </td>
            <td colspan="3">
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td>Select Dept(s):</td>
            <td colspan="5"> <asp:CheckBoxList ID="DeptList" RepeatDirection="Horizontal" runat="server"></asp:CheckBoxList></td>
        </tr>
        <tr>
            <td colspan="2">
                Choose Year Range:
            </td>
            <td>
                Start Year:
            </td>
            <td>
                <asp:DropDownList ID="StartYear" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
                
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator  ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="StartYear"
                ErrorMessage="* Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
            <td>
                End Year:
            </td>
            <td>
                <asp:DropDownList ID="EndYear" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
               
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator  ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="EndYear"
                ErrorMessage="* Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            
        </tr>
        
        <tr>
            <td>
            <asp:Button ID="Button1" runat="server" Text="Create Table" OnClick="CreateTable" />
            </td>
        </tr>
         <tr>
            <td colspan="5">
                <asp:Chart ID="Chart1" runat="server" Height="415px" Width="714px">
        
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
                 </td>
        </tr>
                       
                     </table>
   
</asp:Content>

     
    <%--
        
    </table>
    <asp:Chart ID="Chart1" runat="server" Height="415px" Width="714px">
        
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>--%>


