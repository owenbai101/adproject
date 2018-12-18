using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data;

namespace Team4_Ad
{
    public partial class AdjVoucher1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LastADEntities entities = new LastADEntities();
            
            var c = entities.AdjVouchers.Where(p => p.Status == "Pending Authorisation")
                .Join(entities.ItemLists, m => m.ItemId, f => f.ItemId,
                (m, f) => new {
                    AdjVoucherId = m.AdjVoucherId,
                    Datechecked = m.SubmitDate,
                    ItemId = m.ItemId,
                    Item = f.Description,
                    QuantityAdjusted = m.QuantityAdj,
                    
                    Reason = m.Reason})                
                .ToList();

            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("AdjVoucherId", typeof(int));
                dt.Columns.Add("DateChecked", typeof(DateTime));
                dt.Columns.Add("Item", typeof(string));
                dt.Columns.Add("QuantityAdjusted", typeof(int));
                dt.Columns.Add("Cost", typeof(decimal));
                dt.Columns.Add("Reason", typeof(string));
                
            }
            for (int i = 0; i < c.Count(); i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = c[i].AdjVoucherId;
                NewRow[1] = c[i].Datechecked.Value.Date;
                NewRow[2] = c[i].Item;
                NewRow[3] = c[i].QuantityAdjusted;
                decimal Cost = Math.Round((decimal)(Business.Findavgitempricebyid(c[i].ItemId)*c[i].QuantityAdjusted),2);
                NewRow[4] = Cost;
                NewRow[5] = c[i].Reason;
                dt.Rows.Add(NewRow);
            }

            GridView2.DataSource = dt;
            
            
            GridView2.DataBind();
            
        }

        protected void Unnamed3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            int adjid = Int32.Parse(((Label)GridView2.Rows[rowindex].FindControl("Label1")).Text);

            using (LastADEntities entities = new LastADEntities())
            {
                AdjVoucher abc = entities.AdjVouchers.Where(p => p.AdjVoucherId == adjid).First();
                if (e.CommandName == "Issue Voucher")
                {
                    abc.ApprovedDate = DateTime.Now;
                    //abc.ApprovalEmpNum = ...
                    abc.Status = "Authorised";
                    entities.SaveChanges();

                    

                    Transaction trans = new Transaction();
                    string itemname = ((Label)GridView2.Rows[rowindex].FindControl("Label3")).Text;
                    string ItemId =Business.Finditemidbyname(itemname);
                    trans.ItemId = ItemId;
                    int Quantity = Int32.Parse(((Label)GridView2.Rows[rowindex].FindControl("Label4")).Text);
                    trans.Quantity = Quantity;
                    ItemList i = entities.ItemLists.Find(ItemId);
                    int stock = (int)i.Stock;
                    int Balance = stock + (Quantity);
                    trans.Balance = Balance;

                    trans.AdjVoucherId = adjid;
                    trans.EntryDate = DateTime.Now;
                    entities.Transactions.Add(trans);
                    entities.SaveChanges();

                    GridView2.DataBind();

                    ItemList xyz = entities.ItemLists.Where(p => p.ItemId == ItemId).First();
                    xyz.Stock = Balance;
                    entities.SaveChanges();

                    Response.Redirect("~/6StoreSupervisor/SupervisorAdjVoucher.aspx");
                }


                else if (e.CommandName == "Inform Manager")
                {
                    abc.Status = "PendingDHAuthorisation";

                    entities.SaveChanges();
                    Response.Redirect("~/6StoreSupervisor/SupervisorAdjVoucher.aspx");
                }
            }
        }
        } 
    }
