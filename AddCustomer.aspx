<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="PointOfSaleASP.AddCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 443px;
        }
        .auto-style2 {
            margin-left: 635px;
        }
        .auto-style3 {
            width: 335px;
        }
    </style>
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
        function clear()
        {
            
            document.getElementById("txtid").value = "";
            document.getElementById("txtfname").value = "";
            document.getElementById("txtlname").value = "";
            document.getElementById("txtmob").value = "";
            document.getElementById("txtstate").value = "";
            document.getElementById("txtcity").value = "";
            document.getElementById("txtaddress").value = "";
            document.getElementById("txtpincode").value = "";
            return false;
           
        }

    </script>
<body>
    <form id="form1" runat="server">
        <div>
            <tr style="text-align:center;">
            <asp:Image ID="Image1" runat="server" style="-moz-box-align" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7H6mnZ8qvAxlaq9dL2lXLQa3ysUW3rwAU1Gzi7lEzS--GhhVC8v8hvMDTEW4-lo1m43E&usqp=CAU" margin-left="auto" margin-right="auto" Height="143px" Width="16%" CssClass="auto-style2" />
           </tr>
            <h2 style="text-align:center;background-color:lightskyblue;padding:10px">ADD CUSTOMER </h2>
            <table border="1" style="width:100%" >
               <tr> <th class="auto-style3"> ID </th>
                 
                <td>
                    <asp:TextBox ID="txtid" runat="server" Width="362px" OnTextChanged="txtid_TextChanged" onkeypress="return validateFields(this,'int',event);" AutoPostBack="True"></asp:TextBox>
                </td>
              </tr>
                <tr>
                 <th class="auto-style3"> FisrtName </th>
                 <td>
                     <asp:TextBox ID="txtfname" runat="server"  Width="362px" onkeypress="return validateFields(this,'string',event);"></asp:TextBox>
                 </td>
                </tr>
                 <tr> <th class="auto-style3"> LastName </th>
                 <td>
                     <asp:TextBox ID="txtlname" runat="server"  Width="362px" onkeypress="return validateFields(this,'string',event);"></asp:TextBox>
                 </td>
                 </tr>
                <tr> <th class="auto-style3"> MobileNo </th>
                 <td>
                     <asp:TextBox ID="txtmob" runat="server"  Width="362px" onkeypress="return validateFields(this,'int',event);"></asp:TextBox>
                 </td>
                   </tr> 
                <tr> <th class="auto-style3"> State </th>
                 <td>
                   <asp:DropDownList ID="drpdnstate" runat="server">
                       <asp:ListItem>J & K</asp:ListItem>
                       <asp:ListItem>MadhyaPradesh</asp:ListItem>
                       <asp:ListItem Selected="True">Maharashtra </asp:ListItem>
                       <asp:ListItem>Chattisgarh</asp:ListItem>
                       <asp:ListItem>UttarPradesh</asp:ListItem>
                       <asp:ListItem>Kerala</asp:ListItem>
                       <asp:ListItem>Bihar</asp:ListItem>
                       <asp:ListItem>HimachalPradesh</asp:ListItem>
                       <asp:ListItem>Rajasthan</asp:ListItem>
                       <asp:ListItem>Gujrat</asp:ListItem>
                       <asp:ListItem>Assam</asp:ListItem>
                       <asp:ListItem></asp:ListItem>
                     </asp:DropDownList>

                 </td>
                  </tr>
                 <tr> <th class="auto-style3"> City </th>
                 <td>
                     <asp:TextBox ID="txtcity" runat="server"  Width="362px" onkeypress="return validateFields(this,'string',event);"></asp:TextBox>
                 </td>
                 </tr>
               <tr>  <th class="auto-style3"> Address </th>
                 <td>
                <asp:TextBox ID="txtaddress" runat="server"  Width="362px" onkeypress="return validateFields(this,'string',event);"></asp:TextBox>
                 </td>
                  </tr>
               <tr> <th class="auto-style3"> Pincode </th>
                  <td>
                     <asp:TextBox ID="txtpincode" runat="server"  Width="362px" onkeypress="return validateFields(this,'int',event);"></asp:TextBox>
                 </td>
                    </tr> 
                <tr>
                     <th class="auto-style3"> &nbsp;</th>
                    <td class="auto-style1">
                      <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="136px" OnClick="btnSave_Click" /> &nbsp
                      <asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="136px" OnClientClick="return clear();" OnClick="btnCancel_Click" /> &nbsp
                      <asp:Button ID="btnDel" runat="server" Text="DELETE" Width="136px" OnClick="btnDel_Click"/> &nbsp
                      <asp:Button ID="btnnext" runat="server" Text="NEXT" Width="136px" OnClick="btnnext_Click"/> &nbsp
                        
                        </td>
                </tr>
               </table> 
           
        </div>
    </form>
</body>
</html>
