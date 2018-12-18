using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team4_Ad
{
    public class itemsuppliers
    {

        public string ItemId { get; set; }
        public string Description { get; set; }
        public int? ReOrderQty { get; set; }

        public String SupplierId { get; set; }
    
    }
    public class POcontrol
    {
       
        public static List<itemsuppliers> ListItemNeedReorder()
        {
            LastADEntities entities = new LastADEntities();
            var c = entities.ItemLists.Where(x => x.ReOrderLevel >= x.Stock && !x.PurchaseOrderDetails.Contains(null)).
                Join(entities.ItemSuppliers.Where(x => x.SupplierLevel == 1)
                , m => m.ItemId, f => f.ItemId, (m, f) => new itemsuppliers
                { ItemId = m.ItemId, Description = m.Description, ReOrderQty = m.ReOrderQty, SupplierId = f.SupplierCode }).ToList();
            return c;
        }

        public static List<ItemList> SearchItemById(string itemId)
        {
            using (LastADEntities entities = new LastADEntities())
            {

                return entities.ItemLists.Where(p => p.ItemId == itemId).ToList<ItemList>();
            }
        }

        public static List<PurchaseOrder> GetPurchaseOrder()
        {
            LastADEntities entities = new LastADEntities();
            List<PurchaseOrder> po = entities.PurchaseOrders.Where(x=>x.Transactions.Count()==0).
                OrderByDescending(p => p.PurchaseOrderId).ToList<PurchaseOrder>();
            return po;
        }
        // get all PurchaseOrder order by id

        public static List<PurchaseOrderDetail> GetOrderDetailByOrderId(int i)
        {
            LastADEntities entities = new LastADEntities();
            PurchaseOrder po1 = new PurchaseOrder();
            po1 = entities.PurchaseOrders.Find(i);
            List<PurchaseOrderDetail> pd = po1.PurchaseOrderDetails.ToList<PurchaseOrderDetail>();
            return pd;
        }
        // get PurchaseOrder i's OrderDetail
        public static void PlacePurchaseOrder(List<itemsuppliers> cclist)
        {
            LastADEntities entities = new LastADEntities();

            String[] ss = cclist.GroupBy(c => c.SupplierId).Select(c => c.Key).ToArray();
            String[] sss = cclist.Select(c => c.SupplierId).ToArray();

            int m = ss.Count();
            for (int i = 0; i < m; i++)
            {
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierCode = ss[i];
                po.PurchaseDate = DateTime.Now;
                
               
                entities.PurchaseOrders.Add(po);
                entities.SaveChanges();
                for (int j = 0; j < cclist.Count(); j++)
                {
                    if (sss[j] == ss[i])
                    {
                        PurchaseOrderDetail pod = new PurchaseOrderDetail();

                        pod.ItemId = cclist[j].ItemId;
                        ItemList item = new ItemList();
                        item = entities.ItemLists.Find(pod.ItemId);
                        decimal? price = item.ItemSuppliers.Where(x => x.SupplierCode.Equals(ss[i])).Select(x => x.Price).First();
                        pod.PurchaseOrderId = po.PurchaseOrderId;
                        pod.Quantity = cclist[j].ReOrderQty;
                        pod.Amount = pod.Quantity * price;
                        entities.PurchaseOrderDetails.Add(pod);
                        entities.SaveChanges();
                    }
                }
            }
        }
    }
}