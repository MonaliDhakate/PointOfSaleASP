using PointOfSaleASP.App_Start;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Azure.Core.HttpHeader;

namespace PointOfSaleASP
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        DAL d = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["userid"] != null)
            {
                txtid.Text = Session["userid"].ToString();
                txtfname.Text = Session["name"].ToString();
                txtlname.Text = Session["surname"].ToString();
                txtmob.Text = Session["mob"].ToString();
                drpdnstate.Text = Session["state"].ToString();
                txtcity.Text = Session["city"].ToString();
                txtaddress.Text = Session["address"].ToString();
                txtpincode.Text = Session["pincode"].ToString();
                txtid.Focus();
                ViewState.Add("FoundFlag", false);//FoundFlag=false
            }

        }

        protected void txtid_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader rdr = d.getreader("select * from tbl_addcustomer where id=" + Common.Cint(txtid.Text));

            if (rdr != null && rdr.HasRows)
            {
                // hdnfnd.Value = "true";
               ViewState["FoundFlag"] = true;
                rdr.Read();
                txtfname.Text = rdr["firstname"].ToString();
                txtlname.Text = rdr["lastname"].ToString();
                txtmob.Text = rdr["mobileno"].ToString();
                drpdnstate.Text = rdr["state"].ToString();
                txtcity.Text = rdr["city"].ToString();
                txtaddress.Text = rdr["address"].ToString();
                txtpincode.Text = rdr["pincode"].ToString();

            }
            else
            {
                ViewState["FoundFlag"] = false;
                // hdnfnd.Value = "false";
                txtfname.Text = "";
                txtlname.Text = "";
                txtmob.Text = "";
                txtcity.Text = "";
                drpdnstate.Text = "";
                txtaddress.Text = "";
                txtpincode.Text = "";

            }
            txtid.Focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtmob.Text = "";
            txtcity.Text = "";
            drpdnstate.Text = "";
            txtaddress.Text = "";
            txtpincode.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.addParameters("firstname", txtfname.Text.ToString());
            d.addParameters("lastname", txtlname.Text.ToString());
            d.addParameters("mobileno", txtmob.Text);
            d.addParameters("city", txtcity.Text);
            d.addParameters("state", drpdnstate.Text);
            d.addParameters("address", txtaddress.Text);
            d.addParameters("pincode", txtpincode.Text);
            d.isProCall = true;
            if ((bool)ViewState["FoundFlag"])
            {
                d.addParameters("action", "update");
            }
            else
            {
                d.addParameters("action", "insert");

            }
            int res = d.ExecuteQuery("sp_addcustomer");
            if (res > 0)
            {
                Response.Write("record saved sucessfully");
            }
            else
            {
                Response.Write("record not saved ");
            }
           

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("id", Common.Cint(txtid.Text).ToString());
            d.isProCall = true;
            d.addParameters("action", "delete");
            int res = d.ExecuteQuery("sp_addcustomer");
            if (res > 0)
            {
                Response.Write("record delete sucessfully");
                txtid.Text = "";
                txtfname.Text = "";
                txtlname.Text = "";
                txtmob.Text = "";
                txtcity.Text = "";
                drpdnstate.Text = "";
                txtaddress.Text = "";
                txtpincode.Text = "";
            }
            else
            {
                Response.Write("record not delete");
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (Session["userid.Text"] == null)
                Session.Add("userid", txtid.Text);
            else
                Session["userid"] = txtid.Text;
                Session["name"] = txtfname.Text;
                Session["surname"] = txtlname.Text;
                Session["mob"] = txtmob.Text;
                Session["state"] = txtcity.Text;
                Session["city"] = drpdnstate.Text;
                Session["address"] = txtaddress.Text;
                Session["pincode"] = txtpincode.Text;
          


            Response.Redirect("AddInventory.aspx");
        }
    }
}       