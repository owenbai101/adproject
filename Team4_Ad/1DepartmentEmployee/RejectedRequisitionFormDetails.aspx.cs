using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad.DepartmentEmployee
{
    public partial class RejectedRequisitionFormDetails : System.Web.UI.Page
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
            if (Session["rejectedrequid"] != null)
            {
                int RequId = (int)Session["rejectedrequid"];
                var c = entities.RequDetails.Where(p => p.RequId == RequId)
                    .Join(entities.ItemLists, m=>m.ItemId, f=>f.ItemId, (m, f) => new { f.Description, m.RequestedQuantity })
                    .ToList();
                GridView1.DataSource = c;
                GridView1.DataBind();
                Label1.Text = RequId.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RejectedRequisitionForm.aspx");
        }
    }
}