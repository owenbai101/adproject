using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class EmployeeAddCart : System.Web.UI.Page
    {
        LastADEntities entities = new LastADEntities();
        ArrayList temp = new ArrayList();
        
        private void bindGridView()
        {
            int catid = (int)Session["categoryid"];
            GridView1.DataSource = EmployeeHomeController.ListItemCategory(catid);
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["itemidlist"] != null)
            {
                temp = (ArrayList)Session["itemidlist"];
            }
            else
            {
                Session["itemidlist"] = temp;
            }
            if (!IsPostBack)
            {
                bindGridView();
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ItemId = GridView1.SelectedRow.Cells[0].Text.ToString();
            //ItemList itemx = entities.ItemLists.Where(x => x.ItemId == ItemId).First();
            temp = (ArrayList)Session["itemidlist"];
            temp.Add(ItemId);
            Session["itemidlist"] = temp;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Stationary Confirmation.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeHome.aspx");
        }

    }
}