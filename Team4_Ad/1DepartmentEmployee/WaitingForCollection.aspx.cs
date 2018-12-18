using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class ApprovedRequisitionForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DpCode"] != null)
                {
                    String DPcode = Session["DpCode"].ToString();

                    BindGrid(DPcode);
                }
            }
        }

        private void BindGrid(string Dpcode)
        {
            LastADEntities entities = new LastADEntities();
            var c = entities.Requisitions.Where(p => p.Status == "Waiting For Collection" && p.Employee.DepartmentCode.Equals(Dpcode))
                .Join(entities.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new { m.RequId, f.Name, m.RequestedDate, m.Status, m.SignBy, m.SignDate, m.Note})
                .ToList();
            GridView1.DataSource = c;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WaitingForCollection.aspx");
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateRequisitionForm.aspx");
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RejectedRequisitionForm.aspx");
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RequId = (int)GridView1.SelectedDataKey.Value;
            Session["approvedrequid"] = RequId;
            Response.Redirect("WaitingForCollectionDetails.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompletedReqForm.aspx");
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WaitingForDelivery.aspx");
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
           
        }
    }
}