using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad.StoreClerk
{
    public partial class ClerkHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is to show reminders to the store clerk on the number of requisition forms submitted by the departments
            // and the items needed to reorder.
            LastADEntities entities = new LastADEntities();
            int i = entities.Requisitions.Where(x => x.Status.Equals("Waiting for Collection")).Count();
            int j = entities.ItemLists.Where(x => x.Stock < x.ReOrderLevel&&x.PurchaseOrderDetails.Contains(null)).Count();
            Label7.Text = "There are " + i + " requsitionForm waiting for collection.";
            Label1.Text = "There are " + j + " item need to reorder.";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/4StoreClerk/SelectRequisitionForRetrieval.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/4StoreClerk/PlacePO.aspx");
        }
    }
}