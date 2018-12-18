using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class UpdateReOrder : System.Web.UI.Page
    {
        private void BindGrid()
        {
            LastADEntities entities = new LastADEntities();
            GridView1.DataSource = entities.ItemLists.ToList();
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //String ItemDesc = GridView1.SelectedRow.Cells[1].Text.ToString();
            String itemid = GridView1.DataKeys[e.NewEditIndex].Values[0].ToString();
            String name = Business.FindItemByID(itemid).First().Description.ToString();
            Label11.Text = name;
            String stock = Business.FindItemByID(itemid).First().Stock.ToString();
            Label8.Text = stock;
            var startdate = DateTime.Now.AddMonths(-6);
            var today = DateTime.Now;
            using (LastADEntities entities = new LastADEntities())
            {
                int itemlist = entities.PurchaseOrders
                    .Where(p => p.DeliveryDate > startdate && p.DeliveryDate < today)
                    .Join(entities.PurchaseOrderDetails.Where(x => x.ItemId == itemid), m => m.PurchaseOrderId, f => f.PurchaseOrderId,
                    (m, f) => new { f.ItemId }).Count();
                Label9.Text = itemlist.ToString();


            }




            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            String ItemId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            int ReOrderLevel = Int32.Parse((row.FindControl("TextBox1") as TextBox).Text);
            int ReOrderQty = Int32.Parse((row.FindControl("TextBox2") as TextBox).Text);
            using (LastADEntities entities = new LastADEntities())
            {
                ItemList itemlist = entities.ItemLists.Where(p => p.ItemId.Equals(ItemId)).First<ItemList>();
                itemlist.ReOrderLevel = ReOrderLevel;
                itemlist.ReOrderQty = ReOrderQty;
                entities.SaveChanges();
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            Label8.Text = "";
            Label9.Text = "";
            Label11.Text = "";
            BindGrid();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}