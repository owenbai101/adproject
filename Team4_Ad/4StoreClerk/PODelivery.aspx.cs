using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class PODelivery : System.Web.UI.Page
    {
        static int poid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            if (!IsPostBack)
            {
                List<PurchaseOrder> po = POcontrol.GetPurchaseOrder();

                GridView1.DataSource = po;
                GridView1.DataBind();
                
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            poid = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]);
            List<PurchaseOrderDetail> pd = POcontrol.GetOrderDetailByOrderId(poid);
            GridView2.DataSource = pd;
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            LastADEntities entities = new LastADEntities();
            List<PurchaseOrderDetail> pd = entities.PurchaseOrderDetails.Where(x=>x.PurchaseOrderId==poid).ToList();
            PurchaseOrder ppo = entities.PurchaseOrders.Where(x => x.PurchaseOrderId == poid).First();
            foreach (PurchaseOrderDetail p in pd)
            {
                String id = p.ItemId;
                int qty = Convert.ToInt16(p.Amount);
                int qtyy= Convert.ToInt16(p.Quantity);
                int balance = Convert.ToInt16(p.ItemList.Stock) + qtyy;
                //DateTime entryday = Convert.ToDateTime(p.PurchaseOrder.DeliveryDate);
                ppo.DeliveryDate = DateTime.Now;
                Transaction t = new Transaction();
                t.Balance = balance;
                

                t.EntryDate = DateTime.Now;
                t.ItemId = id;
                t.Quantity = qtyy;
                t.PurchaseOrderId = poid;
                ItemList ii = new ItemList();
                ii = entities.ItemLists.Find(id);
                ii.Stock = balance;
                entities.Transactions.Add(t);
                entities.SaveChanges();


            }
            List<PurchaseOrder> po = POcontrol.GetPurchaseOrder();

            GridView1.DataSource = po;
            GridView1.DataBind();
            GridView2.DataSource = "";
            GridView2.DataBind();
        }
    }
    }
