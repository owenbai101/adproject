using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class SelectedRequisitionForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            LastADEntities entities = new LastADEntities();
            if (Session["requid"] != null)
            {
                int RequId = (int)Session["requid"];
                var c = entities.RequDetails.Where(p => p.RequId == RequId)
                    .Join(entities.ItemLists, m => m.ItemId, f => f.ItemId, (m, f) => new { m.RequestedQuantity, m.OutstandingQuantity, f.Description, m.RequDetailId })
                    .ToList();
                GridView1.DataSource = c;
                GridView1.DataBind();
                Label5.Text = RequId.ToString();
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int requdetailid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int requestedquantity = Int32.Parse((row.FindControl("TextBox1") as TextBox).Text);
            using (LastADEntities entities = new LastADEntities())
            {
                RequDetail requdetail = entities.RequDetails.Where(p => p.RequDetailId == requdetailid ).First<RequDetail>();
                requdetail.RequestedQuantity = requestedquantity;
                requdetail.OutstandingQuantity = requdetail.RequestedQuantity;
                entities.SaveChanges();
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int requDetailId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using (LastADEntities entities = new LastADEntities())
            {
                RequDetail requdetails = entities.RequDetails.Where(p => p.RequDetailId == requDetailId).First<RequDetail>();
                entities.RequDetails.Remove(requdetails);
                entities.SaveChanges();
            }
            BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateRequisitionForm.aspx");
            BindGrid();
        }
    }
}