<%@ Page Language="C#" MasterPageFile="~/3DepartmentRep/Rep.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="Team4_Ad.ChangeCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <header> 
    
    <style type="text/css">
        #form1 {
            height: 456px;
        }
    </style>
</header>

     <div class="row">
  <div class="col-md-12">
    <div class="card">
       <div class="card-header card-header-primary">
          <h4 class="card-title"> Current Collection Point:    
        <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           </h4>
           
             </div>
               <div class="card-body">
                 <div class="table-responsive">
                   <table class="table"> 
                             
                       
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CollectionPointName" DataValueField="CollectionPointId" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Stationery Store</asp:ListItem>  
            <asp:ListItem>Management School</asp:ListItem>  
            <asp:ListItem>Medical School</asp:ListItem>  
            <asp:ListItem>Engineering School</asp:ListItem>  
            <asp:ListItem>Science School</asp:ListItem>  
            <asp:ListItem>University Hospital</asp:ListItem>  
            </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LastADConnectionString %>" SelectCommand="SELECT [CollectionPointName], [CollectionPointId] FROM [CollectionPoint]"></asp:SqlDataSource>
         <asp:Button ID="UpdateButton" runat="server" Height="35px" OnClick="Button1_Click" Text="Update Collection Point" Width="223px" class="btn-success" align="center"/>
                
                            </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--    
    <div>
        </div>
        Current Collection Point:
        <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CollectionPointName" DataValueField="CollectionPointId" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Stationery Store</asp:ListItem>  
            <asp:ListItem>Management School</asp:ListItem>  
            <asp:ListItem>Medical School</asp:ListItem>  
            <asp:ListItem>Engineering School</asp:ListItem>  
            <asp:ListItem>Science School</asp:ListItem>  
            <asp:ListItem>University Hospital</asp:ListItem>  
            </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LastADConnectionString %>" SelectCommand="SELECT [CollectionPointName], [CollectionPointId] FROM [CollectionPoint]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="UpdateButton" runat="server" Height="35px" OnClick="Button1_Click" Text="Update Collection Point" Width="223px" />
   --%>

</asp:Content>
