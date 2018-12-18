using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad.DepartmentHead
{
    public partial class HeadHome : System.Web.UI.Page
    {
        private void BindGrid()
       {
            if (Session["DpCode"] != null)
            {
                string dpid = Session["DpCode"].ToString();

                LastADEntities entities = new LastADEntities();
                var c = entities.Employees.Where(x => x.DepartmentCode.Equals(dpid)).Join(entities.Roles.Where(p => p.RoleId > 3), m => m.RoleId, f => f.RoleId, (m, f)
                    => new Employeerole { Name = m.Name, RoleDescription = f.RoleDescription, Userid = m.UserId }).ToList();
                GridView1.DataSource = c;
                GridView1.DataBind();
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               BindGrid();
                LastADEntities ctx = new LastADEntities();
                var c = ctx.Requisitions.Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate, status = m.Status }).Where(x => x.status == "Pending Approval").ToList();

                Label8.Text = (String)Session["count"];
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                Employeerole employeerole = (Employeerole)e.Row.DataItem;
                DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
                if (dp != null)
                {
                    LastADEntities entities = new LastADEntities();
                    var c = entities.Roles.Where(q => q.RoleId > 3).ToList();
                    dp.DataSource = c;
                    dp.DataTextField = "RoleDescription";
                    
                    dp.DataBind();
                   

                }
            }
        }

    }
}