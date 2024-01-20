using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace PointOfSaleASP
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text=="admin" && txtpass.Text=="admin123")
            {
             
                Response.Redirect("AddCustomer.aspx");
              
            }
            else
            {
                Response.Write("invalid user");
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
        }
    }
}