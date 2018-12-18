using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Team4_Ad
{
    public partial class AddAdjustmentVoucher : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        ArrayList list1 = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getting data for DropDownList1
                var catlist = Business.Listcategory();
                ItemCategory a = new ItemCategory();
                a.CategoryName = "---Select Item Category---";
                catlist.Insert(0, a);
                
                DropDownList1.DataSource = catlist;
                DropDownList1.DataTextField = "CategoryName";
                DropDownList1.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected item from DropDownList1
            string categoryname = DropDownList1.SelectedItem.ToString();

            //Input data into GridView2 based on the selected item from DropDownList1
            GridView2.DataSource = Business.GetitemListbyCatname(categoryname);
            GridView2.DataBind();
            
        }
        //This method is to obtain the itemid, quantityadjusted and reason for discrepancy as per input by user on web application.
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["quantitydiscrepancylist"] != null)
            {
                dt = (DataTable)Session["quantitydiscrepancylist"];
            }
            Page.Validate();
            if (Page.IsValid)
            {
                string itid = GridView2.SelectedDataKey.Value.ToString();
                TextBox tb = (TextBox)GridView2.SelectedRow.Cells[4].FindControl("TextBox1");
                DropDownList reasons = (DropDownList)(GridView2.SelectedRow.Cells[5].FindControl("DropDownList2"));
                string adjquantity = tb.Text;
                string reason = (string)reasons.SelectedItem.Text;
                string sysquantity = Business.GetitemListbyItemId(itid).Stock.ToString();

                int adquantity;
                if (adjquantity != "")
                {
                    adquantity = Int32.Parse(adjquantity);
                }
                else { adquantity = Int32.Parse(sysquantity); }
                int syquantity = Int32.Parse(sysquantity);
                int quantitydifference = adquantity - syquantity;

                //setting up datatable with all the information required for adjustment voucher 
                //and pass to the next webpage in a session to diplay in a gridview
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("ItemId", typeof(string));
                    dt.Columns.Add("AdjustedQuantity", typeof(string));
                    dt.Columns.Add("Reason", typeof(string));
                }
                //This if condition is add to prevent cases where store clerk submits a adjustment voucher 
                //for an item that does not require adjustment voucher. meaning 50 stock in both system and bin.
                if (quantitydifference != 0)
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow[0] = itid;
                    NewRow[1] = quantitydifference;
                    NewRow[2] = reason;
                    
                    dt.Rows.Add(NewRow);
                    Session["quantitydiscrepancylist"] = dt;
                    Label aa = (Label)GridView2.SelectedRow.Cells[4].FindControl("Label1");
                    aa.Text = "Item Added!";
                }
                else {
                    Label aa = (Label)GridView2.SelectedRow.Cells[4].FindControl("Label1");
                    aa.Text = "Please enter Quantity.";
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiscrepancyList.aspx");
        }

    }
}