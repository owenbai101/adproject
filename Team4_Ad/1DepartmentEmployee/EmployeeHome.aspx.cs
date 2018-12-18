using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        private void BindGrid()
        {
            DataList1.DataSource = EmployeeHomeController.ListCategory();
            DataList1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if (Session["BossEmail"] != null)
                {
                    Label7.Text = Session["BossEmail"].ToString();
                }
            }
        }

        protected void Pick_Command(Object sender, DataListCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            Label lab = (Label)DataList1.Items[index].FindControl("Label2");
            int catid = Int32.Parse(lab.Text);
            Session["categoryid"] = (int)catid; 
            Response.Redirect("EmployeeAddCart.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Stationary Confirmation.aspx");
        }
    }
}