using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class Authorise_Requsition_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Requid"] == null)
                {
                    Label2.Text = null;
                }
                else
                {
                    Label2.Text = Session["Requid"].ToString();
                }
                if (Session["Requid"] != null)
                {
                    int Requid = Int32.Parse(Session["Requid"].ToString());
                    //GridView1.DataSource = Business.GetRequDEtialbyID(Requid);
                    //GridView1.DataBind();
                    LastADEntities ctx = new LastADEntities();
                    var c = ctx.RequDetails.Where(x=>x.RequId == Requid).Join(ctx.ItemLists, m => m.ItemId, f => f.ItemId, (m, f) => new { itemid = m.ItemId, name = f.Description, Quantity = m.RequestedQuantity }).ToList();

                    GridView2.DataSource = c;
                    GridView2.DataBind();
                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Requid"] != null)
            {
                int Requid = Int32.Parse(Session["Requid"].ToString());
                if (Session["EmpName"] != null)
                {
                    string empname = Session["EmpName"].ToString();

                    string reason = TextBox2.Text;
                    Business.ConfirmRequsition(Requid, reason, empname);
                }


                Business.sendemail();
                MailMessage mm = new MailMessage("AdProjectTeam04@gmail.com",
                "owenbai101@gmail.com");
                mm.Subject = "Requisition Form " + Requid.ToString() + " Status";
                mm.Body = "Your Requisition Request has been approved!";
                Business.sendemail().Send(mm);
                Response.Redirect("Authorise Requsition list.aspx");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["Requid"] != null)
            {
                int Requid = Int32.Parse(Session["Requid"].ToString());
                if (Session["EmpName"] != null)
                {
                    string empname = Session["EmpName"].ToString();

                    string reason = TextBox2.Text;
                    Business.RejectRequisition(Requid, reason, empname);


                    Business.sendemail();
                    MailMessage mm = new MailMessage("AdProjectTeam04@gmail.com",
                    "owenbai101@gmail.com");
                    mm.Subject = "Requisition Form " + Requid.ToString() + " Status";
                    mm.Body = "Your Requisition Request has been rejected! Reason: " + reason;
                    Business.sendemail().Send(mm);
                    Response.Redirect("Authorise Requsition list.aspx");
                }
            }
        }
    }
}