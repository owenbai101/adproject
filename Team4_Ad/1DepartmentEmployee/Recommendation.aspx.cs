using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class Recommendation : System.Web.UI.Page
    {
        LastADEntities entities = new LastADEntities();
        ArrayList temp = new ArrayList();
        List<ItemList> il = new List<ItemList>();

        private void bindGridView()
        {
            LastADEntities entities = new LastADEntities();
            var q = entities.RequDetails.GroupBy(x=>x.ItemId).Select(x => new{ ItemId = x.Key, TotalRQ = x.Sum(p=>p.RequestedQuantity)})
                .OrderByDescending(p=>p.TotalRQ).Take(10).ToList();
            for (int i = 0; i<q.Count;i++)
            {
                il.Add(Business.FinditemobjByID(q[i].ItemId.ToString()));
            };
            GridView1.DataSource = il;
            GridView1.DataBind();
        }
        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Stationary Confirmation.aspx");
            //if (Session["b"] != null)
            //{
            //    Label7.Text = Session["b"].ToString();
            //}
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ItemId = GridView1.SelectedDataKey.Value.ToString();
            //string ItemId = GridView1.SelectedRow.Cells[0].Text.ToString();
            //Session["b"] = ItemId;
            //ItemList itemx = entities.ItemLists.Where(x => x.ItemId == ItemId).First();
            if (Session["itemidlist"] != null)
            {
                temp = (ArrayList)Session["itemidlist"];
            }
            temp.Add(ItemId);
            Session["itemidlist"] = temp;
        }
        
    }
}