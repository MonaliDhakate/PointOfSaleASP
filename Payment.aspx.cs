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
    public partial class Payment : System.Web.UI.Page
    {
        DAL d = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtid.Focus();
            ViewState.Add("FoundFlag", false);
        }

        protected void txtid_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader rdr = d.getreader("select * from tbl_payment where id=" + Common.Cint(txtid.Text));


            if (rdr != null && rdr.HasRows)
            {

                ViewState["FoundFlag"] = true;
                rdr.Read();
                txtcusname.Text = rdr["customername"].ToString();
                txtproductname.Text = rdr["productname"].ToString();
                txtprice.Text = rdr["price"].ToString();
                txtquantity.Text = rdr["quantity"].ToString();
                txtdiscount.Text = rdr["discount"].ToString();
                txttotalamount.Text = rdr["totalamount"].ToString();

            }
            else
            {
                ViewState["FoundFlag"] = false;
                txtproductname.Text = "";
                txtcusname.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
                txtdiscount.Text = "";
                txttotalamount.Text = "";

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtcusname.Text = "";
            txtproductname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            txtdiscount.Text = "";
            txttotalamount.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.isProCall = true;
            d.addParameters("action", "delete");
            int res = d.ExecuteQuery("sp_payment");
            if (res > 0)
            {
                Response.Write("record delete sucessfully");
                txtid.Text = "";
                txtcusname.Text = "";
                txtproductname.Text = "";
                txtprice.Text = "";
                txtquantity.Text = "";
                txtdiscount.Text = "";
                txttotalamount.Text = "";
            }
            else
            {
                Response.Write("record not delete");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.addParameters("customername", txtcusname.Text.ToString());
            d.addParameters("productname", txtproductname.Text.ToString());
            d.addParameters("discount", txtdiscount.Text);
            d.addParameters("price", txtprice.Text);
            d.addParameters("quantity", txtquantity.Text);
            d.addParameters("totalamount", txttotalamount.Text);

            d.isProCall = true;
            if ((bool)ViewState["FoundFlag"])
            {
                d.addParameters("action", "update");
            }
            else
            {
                d.addParameters("action", "insert");

            }
            int res = d.ExecuteQuery("sp_payment");
            if (res > 0)
            {
                Response.Write("record saved sucessfully");
            }
            else
            {
                Response.Write("record not saved ");
            }
        }
    }
}