<%@ Page Title="" Language="C#" MasterPageFile="~/6StoreSupervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Chart_SpecificYear_DeptSeries.aspx.cs" Inherits="Team4_Ad.Chart_Month" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     
    <table ID="Table1" runat="server" style="width: 900px">
        <tr>
            <td colspan="6">
                <h2>Specific Year by Department series</h2>
            </td>
        </tr>
        
        <tr>
            <td style="width: 192px" >
                Select Item Category:
            </td>
            <td >
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="offset-sm-0"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1" InitialValue="---Select---"
             ErrorMessage="* Please select an item category." ForeColor="Red"  >
        </asp:RequiredFieldValidator> 
            </td>
            <%--<td >
                Select Item:
            </td>
            <td colspan="3">
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            <td style="width: 192px">Select Dept(s):</td>
            <td colspan="5"> <asp:CheckBoxList ID="DeptList" CellPadding="3" RepeatDirection="Horizontal" runat="server"></asp:CheckBoxList></td>
        </tr>
        <tr>
            <td >
                Select Year:
            </td>
            <td>
                <asp:DropDownList ID="SelectedYear" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
                
                <asp:ListItem Value="2017">2017</asp:ListItem>
                <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator  ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="SelectedYear"
                ErrorMessage="* Value Required!" InitialValue="--Select--"></asp:RequiredFieldValidator>
                

            </td>
            
        </tr>
<tr>
            <td style="width: 192px">Choose Specific Month(s): </td>
            
        </tr>
        <tr >
            <td colspan="6">
            <asp:CheckBoxList ID="CheckBoxList2" repeatdirection="Horizontal" runat="server" CellPadding="5">
                <asp:ListItem Value="1">Jan</asp:ListItem>
                <asp:ListItem Value="2">Feb</asp:ListItem>
                <asp:ListItem Value="3">Mar</asp:ListItem>
                <asp:ListItem Value="4">Apr</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">Jun</asp:ListItem>
                <asp:ListItem Value="7">Jul</asp:ListItem>
                <asp:ListItem Value="8">Aug</asp:ListItem>
                <asp:ListItem Value="9">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>
            </asp:CheckBoxList>
                </td>
        </tr>
        
        <tr>
            <td style="width: 192px">
            <asp:Button ID="Button1" runat="server" Text="Create Table" OnClick="CreateTable" />
            </td>
        </tr>
                    
    </table>
    <asp:Chart ID="Chart1" runat="server" Height="415px" Width="714px">
        
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        
    </asp:Chart>
    </asp:Content>
