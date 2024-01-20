<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInventory.aspx.cs" Inherits="PointOfSaleASP.AddInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
     <script type="text/javascript">

     function validateFields(ctrls, datatype, e) {
         debugger;
            var returnflag = true;
            if (datatype == 'int') {
             var nums = '0123456789\b';
            if (nums.indexOf(e.key.toString()) == -1)
            returnflag = false;
            }
            else if (datatype == 'string') {
             var nums = 'abcdefghijklmnopqrstuvwxyz';
            if (nums.indexOf(e.key.toString().toLowerCase()) == -1)
            returnflag = false;

            }
            else if (datatype == 'double') {
             var nums = '0123456789\b.';
            if (nums.indexOf(e.key.toString()) == -1)
            returnflag = false;
             if (ctrls.value.indexOf('.') >= 0 && e.key == '.')
            returnflag = false;
            }
            return returnflag;

     }


    </script>
<body>
    <form id="form1" runat="server">
        <div>
             <tr style="text-align:center;">
 <asp:Image ID="Image1" runat="server" style="-moz-box-align; margin-left: 636px;" src="https://tse2.mm.bing.net/th?id=OIP.Doz7YpBNeMoNvI8M94GH0wAAAA&pid=Api&P=0&h=180" margin-left="auto" margin-right="auto" Height="143px" Width="16%" CssClass="auto-style2" />
</tr>
             <h2 style="text-align:center;background-color:lightskyblue;padding:10px">ADD INVENTORY </h2>
 <table border="1" style="width:100%" >
    <tr> <th class="auto-style1"> ID </th>
     <td>
         <asp:TextBox ID="txtid" runat="server" Width="345px" onkeypress="return validateFields(this, 'int', event);" OnTextChanged="txtid_TextChanged" AutoPostBack="True" ></asp:TextBox>
     </td>
   </tr>
     <tr>
      <th class="auto-style1"> Productname </th>
      <td>
          <asp:TextBox ID="txtprod" runat="server" Width="345px" onkeypress="return validateFields(this, 'string', event);"></asp:TextBox>
      </td>
     </tr>
      <tr> <th class="auto-style1"> Price </th>
      <td>
          <asp:TextBox ID="txtprice" runat="server" Width="345px" onkeypress="return validateFields(this, 'double', event);"></asp:TextBox>
      </td>
      </tr>
     <tr> <th class="auto-style1"> Quantity </th>
      <td>
          <asp:TextBox ID="txtquantity" runat="server" Width="345px"></asp:TextBox>
         
        </td>
        
       </tr> 
     <tr>
          <th> &nbsp</th>
         <td class="auto-style1">
           <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="120px" OnClick="btnSave_Click" /> &nbsp
           <asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="120px" OnClick="btnCancel_Click" /> &nbsp
           <asp:Button ID="btnDel" runat="server" Text="DELETE" Width="120px" OnClick="btnDel_Click"/> &nbsp
              <asp:Button ID="btnnext" runat="server" Text="Next" Width="120px" OnClick="btnnext_Click"/> &nbsp
             </td>
     </tr>
    </table> 
           

        </div>
    </form>
</body>
</html>
