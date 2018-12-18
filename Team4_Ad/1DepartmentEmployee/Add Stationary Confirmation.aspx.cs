using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net.Mail;

namespace Team4_Ad
{
    public partial class Add_Stationary_Comfirmation : System.Web.UI.Page
    {

        ArrayList list2 = new ArrayList();
        List<ItemList> list = new List<ItemList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["itemidlist"] != null) { 
            list2 = (ArrayList)Session["itemidlist"];
            }
            if (!IsPostBack)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    list.Add(Business.FinditemobjByID(list2[i].ToString()));

                }

                GridView1.DataSource = list;
                GridView1.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LastADEntities ctx = new LastADEntities();
            GridViewRow row = GridView1.Rows[e.RowIndex];
            String c = (GridView1.DataKeys[e.RowIndex].Values[0]).ToString();

            list2.Remove(c);
            Response.Redirect("Add Stationary Confirmation.aspx");

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeHome.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LastADEntities entities = new LastADEntities();
            Requisition req = new Requisition();
            //employee id need to ad later

            req.RequestedDate = DateTime.Now;
            req.Status = "Pending Approval";
            if (Session["EmpId"] != null)
            {
                req.EmployeeId = Int32.Parse(Session["EmpId"].ToString());
            }
            entities.Requisitions.Add(req);
            entities.SaveChanges();


            for (int i = 0; i < list2.Count; i++)
            {
                RequDetail reqdetail = new RequDetail();
                reqdetail.RequId = req.RequId;
                reqdetail.ItemId = list2[i].ToString();
                TextBox tb = (TextBox)this.GridView1.Rows[i].Cells[2].FindControl("TextBox1");

                int aa = Int32.Parse(tb.Text);
                reqdetail.RequestedQuantity = aa;
                reqdetail.OutstandingQuantity = aa;
                entities.RequDetails.Add(reqdetail);
                entities.SaveChanges();
                


            }
            Session["reqid"] = req.RequId;
            string bossmail = "owenbai101@gamil.com";
            if (Session["BossEmail"] != null)
            { bossmail = Session["BossEmail"].ToString();}
            Business.sendemail();
            MailMessage mm = new MailMessage("ADProjectTeam04@gmail.com",
            bossmail);
            mm.Subject ="Requisition ID"+ Session["reqid"].ToString() + " Has been submitted. Please Approve";
            mm.Body = "Requisition ID" + Session["reqid"].ToString() + " Has been submitted. Please Approve"; 
           
            Business.sendemail().Send(mm);
            
            Response.Redirect("EmployeeHome.aspx");
        }
    }
}
