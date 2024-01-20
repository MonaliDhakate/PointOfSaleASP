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
    public partial class AddToCart : System.Web.UI.Page
    {
        DAL  d=new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            txtid.Focus();
            ViewState.Add("FoundFlag", false);
        }

        protected void txtquantity_TextChanged(object sender, EventArgs e)
        {
            txtamount.Text=(Common.Cint(txtquantity.Text)* Common.Cdouble(txtquantity.Text)).ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.addParameters("customername", txtcusname.Text.ToString());
            d.addParameters("productname", txtprodname.Text.ToString());
            d.addParameters("price", txtprice.Text);
            d.addParameters("quantity", txtquantity.Text);
            d.addParameters("amount", txtamount.Text);
           
            d.isProCall = true;
            if ((bool)ViewState["FoundFlag"])
            {
                d.addParameters("action", "update");
            }
            else
            {
                d.addParameters("action", "insert");

            }
            int res = d.ExecuteQuery("sp_addtocart");
            if (res > 0)
            {
                Response.Write("record saved sucessfully");
            }
            else
            {
                Response.Write("record not saved ");
            }
            Response.Redirect("Payment.aspx");
        }

        protected void txtid_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader rdr = d.getreader("select * from tbl_addtocart where id=" + Common.Cint(txtid.Text));


            if (rdr != null && rdr.HasRows)
            {

                ViewState["FoundFlag"] = true;
                rdr.Read();
                txtcusname.Text = rdr["customername"].ToString();
                txtprodname.Text = rdr["productname"].ToString();
                txtprice.Text = rdr["price"].ToString();
                txtquantity.Text = rdr["quantity"].ToString();
                txtamount.Text = rdr["amount"].ToString();

            }
            else
            {
                ViewState["FoundFlag"] = false;
                txtprodname.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
                txtamount.Text = "";

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtcusname.Text = "";
            txtprodname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            txtamount.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.isProCall = true;
            d.addParameters("action", "delete");
            int res = d.ExecuteQuery("sp_addtocart");
            if (res > 0)
            {
                Response.Write("record delete sucessfully");
                txtid.Text = "";
                txtcusname.Text = "";
                txtprodname.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
                txtamount.Text = "";
            }
            else
            {
                Response.Write("record not delete");
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Payment.aspx");
        }
    }
}