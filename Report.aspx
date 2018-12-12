<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
   
    
    <script src="js/CalanderJScript.js"></script>
    <script src="js/jquery-ui.js"></script>
   

    <script src="scripts/jquery-1.4.1.min.js"></script>
   
    <script src="scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="css/CalendarStyles.css" rel="stylesheet" />
    <link href="css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
   
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" />
   
    <link href="css/StyleSheet.css" rel="stylesheet" />
 
   
     
<script type="text/javascript">
    $(function () {
       
        $('[id*=lstFruits]').multiselect({
    includeSelectAllOption: true,
    nonSelectedText: 'Select ticket type' // Here change with your desired text.
  
        });
});


</script>


         
<script type="text/javascript">
    $(function () {
    $('[id*=ListBox1]').multiselect({
    includeSelectAllOption: true,
    nonSelectedText: 'Select Category' // Here change with your desired text.
  
        });
});


</script>

 <script type="text/javascript">

        var $j = $.noConflict(true);

        
    

 </script>
    <script >
          $(document).ready(function () {


          

    });


      
             </script>


    <style>
        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td{
            padding:3px;
        }
        .table{
            font-size:10px!important;
        }
       /*.table-hover > tbody > tr:hover > td, .table-hover > tbody > tr:hover > th{
           background-color:lightgray;
       }*/
      .table-striped > tbody > tr:nth-child(2n+1) > td, .table-striped > tbody > tr:nth-child(2n+1) > th{
           background-color:none!important;
       }

     

       #GridView1 tr.rowHover:hover

   {

      background-color:lightgreen!important;

       font-family:sans-serif!important;
       /*font-size:11px!important;*/
       color:black!important;

   }

       .textaligne{
           text-align:center!important;

       }

        .textaligne1{
           text-align:center!important;
           border-left-width:5px!important;
           border-left-color:white!important;

       }

         .textaligne2{
           text-align:center!important;
           border-right-width:5px!important;
           border-right-color:white!important;

       }

.btn-group > :first-child.btn{
    margin-left:10px!important;
} 
button, input, select, textarea{
    font-family:Verdana!important;
}      

    </style>


</head>
<body style="background-color:#eaf8e3">
    <form id="form1" runat="server">

         <div class="wrapper" >
         <div id="uhTopLine">
        <span></span>
            <span></span>
            <span></span>
        </div>
           <div class="header">
            
           <%--<div class="left1">--%>
                 <img class="left1" alt="SAP Logo" src="http://cstooldev.jnb.global.corp.sap:1080/images/SAP_grad_R_min.PNG"/>
              
           <%--</div>--%>
             <div class="right">
                 <p class="namep">ITdirect category search view</p>
             </div>
            <div class="circlebase type1">
                 <img  alt="SAP Logo" class="circlebase type1" style="width:100%" src=""  id="user" runat="server" />
            </div>
            <div class="right1">
               <p><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
            </div>

        </div>
       <div class="topnav">
    
    <ul style=" list-style: none;">
     <%-- <li  class="item"><a href="sla.aspx" class="aclass" style="color:white!important">&nbsp &nbsp Home &nbsp &nbsp</a></li>--%>
        
    <%--  <li class="dropdown"><a href="#" class="aclass" style="color:black">&nbsp &nbsp Category Search  &nbsp &nbsp</a>--%>
          

     <%-- </li>--%>
    
      
    </ul>
  
</div>

<div class="container">
      <div>
    <asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple" style="margin-left:20px!important; font-family:Verdana!important; font-size:12px!important" OnSelectedIndexChanged="lstFruits_SelectedIndexChanged" AutoPostBack="true">
   
    <asp:ListItem Text="Service Request" Value="ZITSM_SR_CS" />
    
    <asp:ListItem Text="Incident Management" Value="ZITSM_IM_CS" />
    <%--<asp:ListItem Text="Orange" Value="5" />--%>
</asp:ListBox>

           <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" style="margin-left:20px!important; font-family:Verdana!important; font-size:12px!important" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true">
   
 
    <%--<asp:ListItem Text="Orange" Value="5" />--%>
</asp:ListBox>
          <asp:TextBox ID="txtcategory" runat="server" CssClass="sapUiTf sapUiTfBack sapUiTfBrd sapUiTfRo" AutoPostBack="true" OnTextChanged="txtcategory_TextChanged" placeholder="Category search" style="margin-top:2px; font-family:Verdana!important; margin-left:10px; width:200px"></asp:TextBox>
            <asp:TextBox ID="txtdescription" runat="server" CssClass="sapUiTf sapUiTfBack sapUiTfBrd sapUiTfRo" AutoPostBack="true" placeholder="Category description" style="margin-top:2px; margin-left:10px; width:400px; font-family:Verdana!important" OnTextChanged="txtdescription_TextChanged"  ></asp:TextBox>
<asp:Button Text="Submit" runat="server" OnClick="Submit" CssClass="btn btn-success" style="margin-left:5px" Visible="false"  />
         <%--  <asp:ImageButton ID="ImageButton1" runat="server" Style=" width: 20px;margin-left:1em; margin-top:5px"  ImageUrl="pics/if_Refresh_85212.png" OnClick="ImageButton1_Click1" ToolTip="Refresh"   />--%>
          <asp:Button ID="ImageButton1" runat="server" Text="Clear" CssClass="btn btn-sm" style="background-color:lightblue; font:bold!important; margin-top:3px!important" OnClick="ImageButton1_Click1" ToolTip="Refresh" />
           <asp:Label ID="lblHits" runat="server" style="font-size:small; color:lightgray" Text=""></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" cssclass="hidden"></asp:TextBox>
   
 
</div>
<asp:ScriptManager ID="ScriptManager" runat="server" />
                   
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
             <div style="margin-top:15px; Overflow:auto; margin-left:5px;margin-right:5px">
                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive"  RowStyle-CssClass="rowHover"   AllowPaging="True" PageSize="10" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found to Display!"  style="font-size:12px!important; text-align: left; font-family:Verdana!important "  HeaderStyle-Font-Size="12.5px" FooterStyle-Height="5px" ItemStyle-font-size="14px" CellPadding="4" HeaderStyle-BackColor="#0f204b" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="OnSelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                  <Columns>

                     <%-- <asp:ButtonField Text="Click to check SLA" CommandName="Select"  ControlStyle-Font-Bold="true" ButtonType="Button" ItemStyle-Width="100px"  />--%>
                    


                   <%--   <asp:BoundField DataField="RID" HeaderText="RID" InsertVisible="False" ReadOnly="True" SortExpression="RID" FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" >
<FooterStyle CssClass="hidden"></FooterStyle>

<HeaderStyle CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
                      </asp:BoundField>--%>
                      <asp:BoundField DataField="Schema_Identifier1" HeaderText="Ticket type" SortExpression="Schema_Identifier1" HeaderStyle-BackColor="#0f204b"  FooterStyle-BackColor="#0f204b" HeaderStyle-Width="150px" ItemStyle-Width="150px"> 
<FooterStyle BackColor="#0F204B"></FooterStyle>

<HeaderStyle BackColor="#0F204B"></HeaderStyle>
                      </asp:BoundField>
                      <asp:TemplateField HeaderText="Category" SortExpression="Category" HeaderStyle-BackColor="#0f204b" HeaderStyle-Width="300px" ItemStyle-Width="300px">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                          </ItemTemplate>

<HeaderStyle BackColor="#0F204B"></HeaderStyle>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Category Description" SortExpression="Category_Description" HeaderStyle-BackColor="#0f204b"  FooterStyle-BackColor="#0f204b" HeaderStyle-Width="400px" ItemStyle-Width="400px">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox2" runat="server" Text='<%#  Bind("Category_Description") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Label2" runat="server" Text='<%#  Bind("Category_Description") %>'></asp:Label>
                          </ItemTemplate>

<FooterStyle BackColor="#0F204B"></FooterStyle>

<HeaderStyle BackColor="#0F204B"></HeaderStyle>

<%--<ItemStyle CssClass="hidden"></ItemStyle>--%>
                      </asp:TemplateField>

                          <asp:BoundField DataField="Ticket_category" HeaderText="Ticket category" SortExpression="Ticket_category" HeaderStyle-BackColor="#0f204b"  FooterStyle-BackColor="#0f204b" HeaderStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"> 
<FooterStyle BackColor="#0F204B"></FooterStyle> </asp:BoundField> 
                              
                     
                   
                  </Columns>

<FooterStyle Height="5px" BackColor="#0f204b" ForeColor="#fff"></FooterStyle>

                  <HeaderStyle BackColor="#0f204b" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#0f204b" ForeColor="#FFFFCC" HorizontalAlign="Center" Height="1px" />
                     <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" Height="10px" />
                  <PagerSettings NextPageText="Next" PreviousPageText="Prev &nbsp &nbsp" FirstPageText="Next" LastPageText="Prev" Mode="NextPrevious"  />
                </asp:GridView>
                 <asp:LinkButton ID="test" runat="server"></asp:LinkButton>
             </div>

             <div style="margin-top:15px; Overflow:auto; margin-left:30px;margin-right:5px">
                 <div style="width:400px; float:left; ">
                 <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive" style="font-family:Verdana!important; font-size:13px!important"   AutoGenerateColumns="False"  OnRowCreated="GridView2_RowCreated" OnRowDataBound="GridView2_RowDataBound" >
                     <Columns>
                            <asp:BoundField DataField="Service_Team" HeaderText="Service Team" SortExpression="Service_Team" HeaderStyle-Width="100px" ItemStyle-Width="90px" />
                         <asp:BoundField DataField="Receiver" HeaderText="Receiver" SortExpression="Receiver" HeaderStyle-Width="90px" ItemStyle-Width="90px"/>
                      

                     </Columns>
                     <EditRowStyle BackColor="#7C6F57" />
                     <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                     <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#E3EAEB" />
                     <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F8FAFA" />
                     <SortedAscendingHeaderStyle BackColor="#246B61" />
                     <SortedDescendingCellStyle BackColor="#D4DFE1" />
                     <SortedDescendingHeaderStyle BackColor="#15524A" />
                 </asp:GridView>
                     </div>
                 <div style="width:70%; float:left;margin-left:15px">
                 <asp:GridView ID="GridView3" runat="server" CellPadding="4" CssClass="table table-striped table-bordered table-hover table-responsive" ItemStyle-CssClass="textaligne" EmptyDataText="No records Found to Display!"  AutoGenerateColumns="False" HeaderStyle-Font-Size="12px" Width="100%" ForeColor="#333333" GridLines="None" OnDataBound="GridView3_DataBound" OnRowCreated="GridView3_RowCreated"  HeaderStyle-CssClass="textaligne" style="font-family:Verdana!important; font-size:13px!important; " >
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>

                           <asp:BoundField DataField="t" HeaderText="" SortExpression="t" HeaderStyle-Width="50px" ItemStyle-Width="50px" ReadOnly="True" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne" >
                         </asp:BoundField>

                         <asp:BoundField DataField="SLA" HeaderText="SLA" SortExpression="SLA" HeaderStyle-Width="40px" ItemStyle-Width="40px" ReadOnly="True" HeaderStyle-CssClass="textaligne" ItemStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_IRT_Very_High" HeaderText="Very High" SortExpression="SP_IRT_Very_High"  HeaderStyle-Width="75px" ItemStyle-Width="75px" ItemStyle-CssClass="textaligne1" HeaderStyle-CssClass="textaligne1"    >
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_IRT_High" HeaderText="High" SortExpression="SP_IRT_High"  HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_IRT_Medium" HeaderText="Medium" SortExpression="SP_IRT_Medium"  HeaderStyle-Width="75px" ItemStyle-Width="75px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_IRT_Low" HeaderText="Low" SortExpression="SP_IRT_Low" HeaderStyle-Width="75px" ItemStyle-Width="75px" ItemStyle-CssClass="textaligne2" HeaderStyle-CssClass="textaligne2">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_MPT_Very_High" HeaderText="Very High" SortExpression="SP_MPT_Very_High"  HeaderStyle-Width="75px" ItemStyle-Width="75px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_MPT_High" HeaderText="High" SortExpression="SP_MPT_High"  HeaderStyle-Width="75px" ItemStyle-Width="75px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_MPT_Medium" HeaderText="Medium" SortExpression="SP_MPT_Medium"  HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                         <asp:BoundField DataField="SP_MPT_Low" HeaderText="Low" SortExpression="SP_MPT_Low"  HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="textaligne" HeaderStyle-CssClass="textaligne">
                         </asp:BoundField>
                     </Columns>
                     <EditRowStyle BackColor="#7C6F57" />
                     <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                     <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#E3EAEB" />
                     <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F8FAFA" />
                     <SortedAscendingHeaderStyle BackColor="#246B61" />
                     <SortedDescendingCellStyle BackColor="#D4DFE1" />
                     <SortedDescendingHeaderStyle BackColor="#15524A" />
                 </asp:GridView>
                 
                 

                    

                 </ContentTemplate>
         <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtcategory" EventName="TextChanged" />
             <asp:AsyncPostBackTrigger ControlID="txtdescription" EventName="TextChanged" />
             
            </Triggers>
    </asp:UpdatePanel>
    </div>
             <div>
               
              
             </div>
             </div>



 
    </form>
</body>
</html>
