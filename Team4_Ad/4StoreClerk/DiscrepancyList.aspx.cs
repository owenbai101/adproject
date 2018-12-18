using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Net.Mail;

namespace Team4_Ad
{
    public partial class DiscrepanciesList : System.Web.UI.Page
    {
        DataTable list3 = new DataTable();
        List<ItemList> list = new List<ItemList>();
        ArrayList list4 = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is taking the datatable from AddAdjustmentVoucher.aspx to display in gridview
            list3 = (DataTable)Session["quantitydiscrepancylist"];
            if (!IsPostBack)
            {            
                GridView3.DataSource = list3;
                GridView3.DataBind();
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Clicking this button will generate a new Adjustment voucher. Those values displayed in the gridview
            //wil be added into the adjustment voucher accordingly. This adjustment voucher will be added into the database

            LastADEntities entities = new LastADEntities();
            for(int i = 0; i < list3.Rows.Count; i++)
            {

                AdjVoucher adj = new AdjVoucher();
                adj.ItemId = (list3.Rows[i][0].ToString());
                adj.QuantityAdj = Int32.Parse(list3.Rows[i][1].ToString());
                adj.Reason = list3.Rows[i][2].ToString();
                if (Session["EmpId"] != null) { 
                adj.RequestEmpNum = Int32.Parse( Session["EmpId"].ToString());
                }
                adj.SubmitDate = DateTime.Now;
                adj.Status = "Pending Authorisation";
                entities.AdjVouchers.Add(adj);
                entities.SaveChanges();
            }
            //An email will be sent to the supervisor for approval.

            string bossmail = "e0284003@u.nus.edu";
            Business.sendemail();
            MailMessage mm = new MailMessage("ADProjectTeam04@gmail.com",
            bossmail);
            mm.Subject = "The new Adjustment voucher has been send to you, please help us check and review";

            mm.Body = "There are"+ list3.Rows.Count.ToString() + " item need to be issued";
            Business.sendemail().Send(mm);

            Response.Redirect("DiscrepancyListSubmitted.aspx");
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            //Store clerk can delete the adjustment entries before submiting.
            list3.Rows[e.RowIndex].Delete();
            GridView3.DataSource = list3;
            GridView3.DataBind();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            //Store Clerk can edit the quantity needed to adjust before submitting
            GridView3.EditIndex = e.NewEditIndex;
            GridView3.DataSource = list3;
            GridView3.DataBind();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Store Clerk can update the quantity needed to adjust before submitting
            GridViewRow row = GridView3.Rows[e.RowIndex];

            int newadjquantity = Convert.ToInt32((row.FindControl("TextBox10") as TextBox).Text);
            list3.Rows[e.RowIndex].BeginEdit();
            list3.Rows[e.RowIndex][1] = newadjquantity;

            GridView3.EditIndex = -1;
            GridView3.DataSource = list3;
            GridView3.DataBind();

        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            
            GridView3.EditIndex = -1;
            GridView3.DataSource = list3;
            GridView3.DataBind();
        }
    }
}