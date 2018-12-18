using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class Authorise_Requsition_list : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DpCode"] != null)
                {
                    String DPcode = Session["DpCode"].ToString();



                    LastADEntities ctx = new LastADEntities();
                    var c = ctx.Requisitions.Where(x => x.Status == "Pending Approval" && x.Employee.DepartmentCode.Equals(DPcode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate, status = m.Status }).ToList();

                    GridView1.DataSource = c;
                    GridView1.DataBind();
                }
    

                Label8.Text = GridView1.Rows.Count.ToString();
                Session["count"] = Label8.Text;

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridView1.SelectedDataKey.Value.ToString();
            Session["Requid"] = id;
            Response.Redirect("Authorise Requsition Detail.aspx");
        }


    }
}