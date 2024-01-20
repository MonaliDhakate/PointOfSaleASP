<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PointOfSaleASP.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> lOGIN </title>
    <style type="text/css">
        .auto-style2 {
            width: 700px;
            height: 194px;
        }
    </style>
</head>

    <script type="text/javascript">

        function validateform() {
            var user = document.getElementById("txtuser").value;
            var pass = document.getElementById("txtpass").value;

            if (user == '' && pass == '') {
                alert("Please enter ID and Password");
                document.getElementById("txtuser").focus();
                return false;
            }
            else if (user=='') {
                alert("Please enter ID ");
                document.getElementById("txtuser").focus();
                return false;
            }
            else if (pass == '') {
                alert("Please enter pass ");
                document.getElementById("txtpass").focus();
                return false;
            }
            else if (user.length<5 ) {
                alert("Username should wrong ");
                document.getElementById("txtuser").focus();
                return false;
            }
            else if (pass.length < 7 ||  pass.length>10) {
                alert("Password should be wrong");
                document.getElementById("txtpass").focus();
                return false;
            }

         
        }

      
        
    </script>
<body>
    <form id="form1" runat="server">
       
         <div style="margin-left:350px;margin-top:50px" class="auto-style2"> 
             <h1 style="text-align:center;background-color:lightskyblue;padding:10px"> LOGIN FORM</h1> 
           
             <th style="text-align:left">Username</th> 
                <tr> <td><asp:TextBox ID="txtuser" runat="server" Width="686px "></asp:TextBox></td> </tr>

             <th style="text-align:left">Password</th>
                <tr> <td><asp:TextBox ID="txtpass" runat="server" Width="688px" TextMode="Password" Height="23px"></asp:TextBox></td></tr>  &nbsp
         
              <div> <asp:Button ID="btnlogin" runat="server" Text="LOGIN" OnClientClick="return validateform();" OnClick="btnlogin_Click" Width="698px" /> </div>
            <tr><asp:Button ID="btnclear" runat="server" Text="CLEAR" Width="700px" OnClick="btnclear_Click" /> </tr>
             
        
          </div>
        
      
    </form>
</body>
</html>
