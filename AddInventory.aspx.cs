using PointOfSaleASP.App_Start;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PointOfSaleASP
{
    public partial class AddInventory : System.Web.UI.Page
    {
        DAL d = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               txtid.Focus();
               ViewState.Add("FoundFlag", false);//FoundFlag=false
            }

        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.addParameters("productname", txtprod.Text.ToString());
            d.addParameters("price", txtprice.Text.ToString());
            d.addParameters("quantity", txtquantity.Text);
           
            d.isProCall = true;
            if ((bool)ViewState["FoundFlag"])
            {
                d.addParameters("action", "update");
            }
            else
            {
                d.addParameters("action", "insert");

            }
            int res = d.ExecuteQuery("sp_inventory");
            if (res > 0)
            {
                Response.Write("record saved sucessfully");
            }
            else
            {
                Response.Write("record not saved ");
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("AddToCart.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtprod.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.isProCall = true;
            d.addParameters("action", "delete");
            int res = d.ExecuteQuery("sp_inventory");
            if (res > 0)
            {
                Response.Write("record delete sucessfully");
                txtid.Text = "";
                txtprod.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
            }
            else
            {
                Response.Write("record not delete");
            }
        }

        protected void txtid_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader rdr = d.getreader("select * from tbl_inventory where id=" + Common.Cint(txtid.Text));


            if (rdr != null && rdr.HasRows)
            {

                ViewState["FoundFlag"] = true;
                rdr.Read();
                txtprod.Text = rdr["productname"].ToString();
                txtprice.Text = rdr["price"].ToString();
                txtquantity.Text = rdr["quantity"].ToString();

            }
            else
            {
                ViewState["FoundFlag"] = false;
                txtprod.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";

            }
        }
    }
}