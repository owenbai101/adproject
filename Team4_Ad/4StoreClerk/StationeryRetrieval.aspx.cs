using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        ArrayList list2 = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (LastADEntities ctx = new LastADEntities())
                {
                    //RetrievalListSimple is a method that consolidates the quantity of the items to collect from the warehouse
                    // and will display this data in a gridview
                    if (Session["a"] != null)
                    {
                        list2 = (ArrayList)Session["a"];
                        GridView1.DataSource = Business.RetrievalListSimple(list2);
                        GridView1.DataBind();
                    }
                    int quantityneed;

                    String id;
                    ItemList items;


                    for (int i = 0; i < this.GridView1.Rows.Count; i++)
                    {
                        TextBox txt = (TextBox)this.GridView1.Rows[i].Cells[5].FindControl("TextBox1");
                        if (txt != null)
                        {
                            Control ctrl = GridView1.Rows[i].Cells[2].FindControl("Label7");
                            Label lab = ctrl as Label;
                            id = lab.Text;
                            items = Business.FindItemByID(id).First();
                            quantityneed = Business.GetTotalQtyNeededForSelectedItem(id, list2);

                            //if we have more stock than requested quantity, we will retrieve the requested quantity
                            //else we will only retrieve the amount we have in the store
                            if (items.Stock > quantityneed)
                            {
                                txt.Text = quantityneed.ToString();
                            }
                            else
                            {
                                txt.Text = items.Stock.ToString();
                            }
                           
                        }

                    }
                }

            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            LastADEntities entities = new LastADEntities();
            if (Session["a"] != null)
            {
                list2 = (ArrayList)Session["a"];
            }
            Requisition rr = new Requisition();
            List<Requisition> c = new List<Requisition>();
            List<string> email = new List<string>();
            foreach (int i in list2)
            {
                rr = entities.Requisitions.Where(x => x.RequId == i).First();
                string emal = rr.Employee.Department.Employees.Where(x=>x.RoleId==5).First().Email.ToString();
                c.Add(rr);
                email.Add(emal);
            }
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                TextBox txt = (TextBox)this.GridView1.Rows[i].Cells[5].FindControl("TextBox1");
                int RetrievedAmt = Int32.Parse(txt.Text);
                Label lab = (Label)this.GridView1.Rows[i].Cells[2].FindControl("Label7");
                RequDetail requDetail = new RequDetail();
                c = c.Where(x => x.RequDetails.Select(y => y.ItemId).Contains(lab.Text)).OrderBy(x => x.SignDate).ToList();
                foreach (Requisition requ in c)
                {


                    DateTime entryday = DateTime.Now;
                    int? RetrievedAmtnt = requ.RequDetails.Where(x => x.ItemId.Equals(lab.Text)).Select(x => x.RequestedQuantity).First();
                    if (RetrievedAmt == 0)
                    {

                    }
                    else if (RetrievedAmt < RetrievedAmtnt)
                    {
                        RetrievedAmtnt = RetrievedAmt;
                    }

                    if (RetrievedAmtnt != 0)
                    {
                        RequDetail requde = new RequDetail();
                        requde = requ.RequDetails.Where(x => x.ItemId.Equals(lab.Text)).First();
                        int balance = Convert.ToInt32(requde.ItemList.Stock) - Convert.ToInt32(RetrievedAmtnt);
                        Transaction tt = new Transaction();
                        tt.Balance = balance;
                        tt.EntryDate = entryday;
                        tt.ItemId = requde.ItemId;
                        tt.Quantity = RetrievedAmtnt;
                        tt.Requid = requde.RequId;
                        ItemList ii = new ItemList();
                        ii = requde.ItemList;
                        ii.Stock = balance;


                        entities.Transactions.Add(tt);
                        entities.SaveChanges();
                        RetrievedAmt = RetrievedAmt - Convert.ToInt32(RetrievedAmtnt);
                    }

                }
                foreach (Requisition requ in c)
                {
                    requ.Status = "Waiting For Delivery";
                    entities.SaveChanges();
                }
            }
            foreach(string em in email)
            {
                
                string bossmail = em;
                Business.sendemail();
                MailMessage mm = new MailMessage("ADProjectTeam04@gmail.com",
                bossmail);
                mm.Subject = "Your Requisition order has been send to your collection point ";
                mm.Body = "Your Requisition order has been send to your collection point, please collect your item before tmr 12:00pm ";

                Business.sendemail().Send(mm);
            }
            Response.Redirect("DisbursementList.aspx");
        }
    }
}