using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad.StoreClerk
{
    public partial class SelectRequisitionForRetrieval : System.Web.UI.Page
    {
        ArrayList temp = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getting requisition froms with status "Waiting For Collection" and display in gridview
                GridView1.DataSource = Business.ListRequisitionWithPendingtoCollectionForClerk();
                GridView1.DataBind();               
            }
        }
        protected void SelectCheckBox_OnCheckedChanged(object sender, EventArgs e)
        {
            //We allow store clerk to choose the forms that he wants to generate stationary retrieval form with.

            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                GridViewRow row = (GridViewRow)chk.NamingContainer;
                String requid = row.Cells[0].Text;
                int id = Int32.Parse(requid);
                temp.Add(id);
                Session["a"] = temp;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StationeryRetrieval.aspx");
        }
    }
}