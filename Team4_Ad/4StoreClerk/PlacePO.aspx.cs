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
 
    public partial class PlacePO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
                cclist = POcontrol.ListItemNeedReorder();
                Session["cclist"] = cclist;
                
                DropDownList1.SelectedIndex = 0;
                GridView2.DataSource = cclist;
                GridView2.DataBind();
            }
        }




        protected void AddItemButton_Click(object sender, EventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            string itemdesc = ItemIdDropDownList.SelectedItem.ToString();
            LastADEntities entities = new LastADEntities();
            ItemList item = new ItemList();
            item = entities.ItemLists.Where(x => x.Description.Equals(itemdesc)).First();
            string itemId = item.ItemId;

            ArrayList aaaa = new ArrayList();
            ArrayList list = new ArrayList();
            aaaa.Add(itemId);
            for (int i = 0; i < aaaa.Count; i++)
            {
                if (!list.Contains(aaaa[i]))
                {
                    list.Add(aaaa[i]);
                }
            }
            string supplierName = SupplierDropDownList.SelectedValue;

            LastADEntities context = new LastADEntities();
            var c = context.ItemSuppliers.Where(d => d.ItemId.Equals(itemId) && d.Supplier.SupplierCode.Equals(supplierName)).
                Join(context.ItemLists, m => m.ItemId, f => f.ItemId, (m, f) => new itemsuppliers { ItemId = m.ItemId, Description = f.Description, ReOrderQty = f.ReOrderQty, SupplierId = m.SupplierCode }).ToList();
            foreach (itemsuppliers aa in c)
            {
                if (!cclist.Exists(x => x.ItemId.Equals(aa.ItemId)))
                    cclist.Add(aa);

            }


            GridView2.DataSource = cclist;
            GridView2.DataBind();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            GridView2.EditIndex = e.NewEditIndex;
            GridView2.DataSource = cclist;
            GridView2.DataBind();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            GridView2.EditIndex = -1;
            GridView2.DataSource = cclist;
            GridView2.DataBind();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            GridView2.Columns.Clear();
            cclist.Clear();
        }

        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            //Session["cclist"] = null;
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            POcontrol.PlacePurchaseOrder(cclist);
      

            string bossmail = "owenbai101@gmail.com";
            Business.sendemail();
            MailMessage mm = new MailMessage("ADProjectTeam04@gmail.com",
            bossmail);
            mm.Subject = "The PO has Sent to Suppliers please review";
            for (int j = 0; j < cclist.Count; j++)
            {
                mm.Body = cclist[j].Description.ToString()+","+mm.Body;
            }
            mm.Body = mm.Body+" Has been Placed. Please Review." ;
            Business.sendemail().Send(mm);


            Response.Redirect("~/4StoreClerk/ClerkHome.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ItemIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemdesc = ItemIdDropDownList.SelectedItem.ToString();
            LastADEntities entities = new LastADEntities();
            ItemList item = new ItemList();
            item = entities.ItemLists.Where(x => x.Description.Equals(itemdesc)).First();
            string itemId = item.ItemId;
            LastADEntities context = new LastADEntities();
            List<ItemSupplier> t = context.ItemSuppliers.Where(p => p.ItemId.Equals(itemId)).ToList<ItemSupplier>();
            SupplierDropDownList.Items.Clear();
            for (int i = 0; i < t.Count; i++)
            {
                SupplierDropDownList.Items.Add(t[i].SupplierCode);
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            string id = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
            itemsuppliers ll = new itemsuppliers();
            ll = cclist.Where(x => x.ItemId.Equals(id)).First();
            cclist.Remove(ll);
            GridView2.DataSource = cclist;
            GridView2.DataBind();
        }



        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<itemsuppliers> cclist = (List<itemsuppliers>)Session["cclist"];
            GridViewRow row = GridView2.Rows[e.RowIndex];
            string id = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
            itemsuppliers ll = new itemsuppliers();
            ll = cclist.Where(x => x.ItemId.Equals(id)).First();
            ll.ReOrderQty = Convert.ToInt16((row.FindControl("TextBox1") as TextBox).Text);
            GridView2.EditIndex = -1;
            GridView2.DataSource = cclist;
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryName = DropDownList1.SelectedItem.ToString();
            LastADEntities context = new LastADEntities();
            String[] list;
            list = context.ItemLists.Where(x => x.ItemCategory.CategoryName.Equals(categoryName)).Select(x => x.Description).ToArray();

            ItemIdDropDownList.DataSource = list;
            ItemIdDropDownList.DataBind();

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<itemsuppliers> list = (List<itemsuppliers>)Session["cclist"];
            GridView2.DataSource = list;
            GridView2.DataBind();
        }
    }
}