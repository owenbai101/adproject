using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Team4_Ad.WCF;
using System.Web.Security;
using System.Collections;

namespace Team4_Ad
{

    public class Business
    {
        public static string Finditemidbyname(string name)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.ItemLists.Where(x => x.Description.Contains(name)).Select(y => y.ItemId).First();

            }
        }
        public static decimal Findavgitempricebyid(string itemId)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                var t = ctx.ItemSuppliers.Where(x => x.ItemId == itemId).Select(y => y.Price).ToList();
                decimal avgprice = 0;
                for (int i = 0; i < t.Count; i++)
                {
                    avgprice += (Decimal)(t[i]);
                }
                return avgprice / t.Count;
            }


        }

        public static List<RequDetail> RetriveReqOutstanding(int reqID)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                // retrive the requisition with outstanding amount
                return ctx.RequDetails.Where(x => x.RequDetailId == reqID).Where(y => y.OutstandingQuantity != 0).ToList<RequDetail>();
            }

        }

        public static List<Requisition> ListRequsitionWithPendingtoCollection()
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Requisitions.Where(x => x.Status.Equals("Waiting for Collection")).ToList<Requisition>();
            }
        }

        public static List<RequDetail> GetOutStandingRequsitionDetail()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.RequDetails.Where(x => x.OutstandingQuantity != 0 && x.Requisition.Status.Equals("Waiting for Collection")).ToList<RequDetail>();
            }

        }

        public static List<RequDetail> GetOutStandingRequsitionDetailForSelectedItem(ArrayList list)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<RequDetail> Relist = new List<RequDetail>(); 
                foreach (int i in list)
                {

                    List<RequDetail> detaillist = ctx.RequDetails.Where(x => x.Requisition.RequId == i).ToList();
                    foreach (RequDetail dd in detaillist)
                    {
                        Relist.Add(dd);
                    }
                }
                return Relist.ToList<RequDetail>();
            }

        }

        public static List<Requisition> ListRequsitionFrombystatus(string status)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Requisitions.Where(x => x.Status.Equals(status)).ToList<Requisition>();
            }

        }

        public static List<ItemList> FindItemByID(string itemID)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                //List<ItemList> ll = new List<ItemList>();
                //ItemList i= ctx.ItemLists.Where(x => x.ItemId == itemID).First();
                //ll.Add(i);
                //return ll;
                return ctx.ItemLists.Where(x => x.ItemId == itemID).ToList<ItemList>();
            }

        }

        public static ItemList FinditemobjByID(string itemId)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.ItemLists.Where(x => x.ItemId == itemId).First();
            }
               
                    
        }

        public static int GetTotalQtyNeeded(String itemid)
        {
            List<RequDetail> templistDetails = GetOutStandingRequsitionDetail();
            int tqNeeded = 0;

            foreach (var item in templistDetails)
            {
                if (item.ItemId == itemid )
                {
                    tqNeeded += Convert.ToInt32(item.OutstandingQuantity);

                }

            }
            return tqNeeded;
        }
        public static int GetTotalQtyNeededForSelectedItem(String itemid, ArrayList list)
        {
            List<RequDetail> templistDetails = GetOutStandingRequsitionDetailForSelectedItem(list);
            int tqNeeded = 0;

            foreach (var item in templistDetails)
            {
                if (item.ItemId == itemid)
                {
                    tqNeeded += Convert.ToInt32(item.OutstandingQuantity);

                }

            }
            return tqNeeded;
        }

        public static List<ItemCategory> Listcategory()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.ItemCategories.ToList<ItemCategory>();
            }

        }

        public static List<ItemList> GetitemListbyCatname(string Categoryname)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.ItemLists.Where(p => p.ItemCategory.CategoryName == Categoryname).ToList<ItemList>();

            }

        }

        public static List<RequDetail> GetRequDEtialbyID(int requisitionid)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.RequDetails.Where(p => p.RequId == requisitionid).ToList<RequDetail>();
            }


        }


        public static void ConfirmRequsition(int requsitionid, string reason,string signby)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                Requisition requsition = ctx.Requisitions.Where(x => x.RequId == requsitionid).First<Requisition>();
                requsition.Status = "Waiting for Collection";
                requsition.SignDate = DateTime.Now;
                requsition.SignBy = signby;
                requsition.Note = reason;
                ctx.SaveChanges();
            }


        }
        public static void RejectRequisition(int requisitionid, string reason, string signby)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                Requisition requsition = ctx.Requisitions.Where(x => x.RequId == requisitionid).First<Requisition>();
                requsition.Status = "Rejected";
                requsition.SignDate = DateTime.Now;
                requsition.SignBy = signby;
                requsition.Note = reason;

                List<RequDetail> reqdetail = ctx.RequDetails.Where(y => y.RequId == requisitionid).ToList();
                foreach (RequDetail a in reqdetail)
                {
                    a.OutstandingQuantity = 0;
                }

                ctx.SaveChanges();
            }


        }

        public static ItemList GetitemListbyItemId(string ItemId)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.ItemLists.Where(p => p.ItemId == ItemId).First();

            }
        }

        public static SmtpClient sendemail()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential
             ("ADProjectTeam04@gmail.com",
            "ADProjectTeam04!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            return client;
        }
        public static List<WCF_RequsitionJoinEmployee> ListRequisitionNotAprrove()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Requisitions.Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).Where(x => x.status == "Pending Approval").ToList<WCF_RequsitionJoinEmployee>();
            }
        }

        public static WCF_RequsitionJoinEmployee GetRequisitionbyid(int reqid)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Requisitions.Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).Where(x => x.Requid == reqid).First();
            }

        }

        public static List<int> GetRequidPendingApprove()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<int> list = new List<int>();
                foreach (WCF_RequsitionJoinEmployee r in ListRequisitionNotAprrove())
                {
                    list.Add(r.Requid);
                }
                return list;

            }

        }

        public static List<string> GetitemIdbyCatname(string Categoryname)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<string> list = new List<string>();
                foreach (ItemList i in GetitemListbyCatname(Categoryname))
                {
                    list.Add(i.ItemId);
                }
                return list;
            }

        }

        public static List<string> GetRequisitionDetailid(int requid)
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<string> list = new List<string>();
                foreach (RequDetail i in GetRequDEtialbyID(requid))
                {
                    list.Add(i.RequDetailId.ToString());
                }
                return list;
            }

        }

        public static WCF_RequisitionDetail GetRequisitionDetailByRequisitionId(int RequisitionDetailId)
        {
            using (LastADEntities ctx = new LastADEntities())
            {


                return ctx.RequDetails.Where(x => x.RequDetailId == RequisitionDetailId).Join(ctx.ItemLists, m => m.ItemId, f => f.ItemId, (m, f) =>
                new WCF_RequisitionDetail { Requid = m.RequId.ToString(), itemid = m.ItemId, name = f.Description, quantity = m.RequestedQuantity.ToString(), OutstandingQuantity = m.OutstandingQuantity.ToString() }).First();
            }

        }


        public static List<int> GetRequidWaitingForCollection()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<int> list = new List<int>();
                foreach (Requisition r in ListRequsitionWithPendingtoCollection())
                {
                    list.Add(r.RequId);
                }
                return list;

            }

        }

        //public static void ChangeCollectionPoint(int id)
        //{
        //    LastADEntities ctx = new LastADEntities();
        //    Department c = ctx.Departments.Where(x => x.CollectionPointId == id).First();
        //    c.CollectionPointId = id;
        //    ctx.SaveChanges();

        //}
        public static void ChangeCollectionPoint(int id, string dpcd)
        {
            LastADEntities ctx = new LastADEntities();
            Department c = ctx.Departments.Where(x => x.DepartmentCode == dpcd).First();
            c.CollectionPointId = id;
            ctx.SaveChanges();

        }

        public static List<WCF_RequisitionDetailJoinItemList> RetrievalList()
        {

            LastADEntities ctx = new LastADEntities();
            List<WCF_RequisitionDetailJoinItemList> list = ctx.RequDetails.Where(x => x.Requisition.Status.Equals("Waiting for Collection")).GroupBy(x => x.ItemId).
                Select(y => (new { id = y.Key, quantity = y.Sum(x => x.OutstandingQuantity) }))
                .Join(ctx.ItemLists, m => m.id, f => f.ItemId, (m, f) => new WCF_RequisitionDetailJoinItemList
                { itemid = m.id, itemname = f.Description, Quantity = m.quantity, uom = f.UOM, bin = f.Bin })
                 .OrderBy(x => x.bin).ToList();

            foreach (WCF_RequisitionDetailJoinItemList w in list)
            {
                int quantityneed = Business.GetTotalQtyNeeded(w.itemid);
                w.RetrievalQuantity = Business.GetTotalQtyNeeded(w.itemid).ToString();
                int? Stock = ctx.ItemLists.Where(x => x.ItemId.Equals(w.itemid)).Select(x => x.Stock).First();

                if (Stock > quantityneed)
                {
                    w.RetrievalQuantity = quantityneed.ToString();
                }
                else
                {
                    w.RetrievalQuantity = Stock.ToString();
                }

            }
            return list;
        }

        

       
        public static List<WCF_RequisitionDetailJoinItemList> RetrievalListSimple(ArrayList requlist)
        {

            LastADEntities ctx = new LastADEntities();
            List<WCF_RequisitionDetailJoinItemList> WCF_RequisitionDetailJoinItemList = new List<WCF_RequisitionDetailJoinItemList>();
            List<RequDetail> itlist = new List<RequDetail>();

            foreach (int id in requlist)
            {
                List<RequDetail> detaillist = ctx.RequDetails.Where(x => x.Requisition.RequId == id).ToList();
                foreach(RequDetail dd in detaillist)
                {
                    itlist.Add(dd);
                }
            }
                List<WCF_RequisitionDetailJoinItemList> list =itlist. GroupBy(x => x.ItemId).
                   Select(y => (new { id = y.Key, quantity = y.Sum(x => x.OutstandingQuantity) }))
                   .Join(ctx.ItemLists, m => m.id, f => f.ItemId, (m, f) => new WCF_RequisitionDetailJoinItemList
                   { itemid = m.id, itemname = f.Description, Quantity = m.quantity, uom = f.UOM, bin = f.Bin })
                    .OrderBy(x => x.bin).ToList();
            
            return list;
        }

        public static List<Requisition> ListRequsitionWithWaitingForDelivery()
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Requisitions.Where(x => x.Status.Equals("Waiting for Delivery")).ToList<Requisition>();
            }
        }

        public static List<int> GetRequidWaitingForDelivery()
        {
            using (LastADEntities ctx = new LastADEntities())
            {
                List<int> list = new List<int>();
                foreach (Requisition r in ListRequsitionWithWaitingForDelivery())
                {
                    list.Add(r.RequId);
                }
                return list;

            }

        }

        public static String Confrimrequ(List<WCF_RequisitionDetail> WRDS)

        {
            //String  WRDD= WRD.ToString();
            //JArray array = (JArray)JsonConvert.DeserializeObject(WRDD);
            //List<WCF_RequisitionDetail> WRDS = new List<WCF_RequisitionDetail>();
            //foreach (JObject j in array)
            //{
            //   WCF_RequisitionDetail w=  j.ToObject<WCF_RequisitionDetail>();
            //    WRDS.Add(w);
            //}



            int requid = Convert.ToInt32(WRDS.First().Requid);
            // int id = 13;
            LastADEntities entities = new LastADEntities();
            Requisition requ = entities.Requisitions.Where(x => x.RequId == requid).First();
            List<RequDetail> details = requ.RequDetails.ToList();
            int percentage = 0;
            string ending = WRDS.ToString();
            //String WCFitemid = "1";
            try
            {
                // foreach (RequDetail detail in details)
                for (int i = 0; i < WRDS.Count(); i++)
                {
                    // entities.Entry(detail).State = System.Data.Entity.EntityState.Modified;
                    //WCFitemid = WRDS[i].itemid.ToString();
                    String WCFitemdesc = WRDS[i].name.ToString();
                    // ending = WCFitemid;
                    RequDetail wdetail = details.Where(x => x.ItemList.Description == WCFitemdesc).First();
                    wdetail.OutstandingQuantity = Convert.ToInt32(WRDS[i].OutstandingQuantity);
                    if (wdetail.OutstandingQuantity != 0)
                        percentage++;
                    else { }

                    if (percentage == 0)
                    {
                        requ.Status = "Completed";
                        requ.CollectionDate = DateTime.Now;
                    }
                    else
                    {
                        requ.Status = "Waiting for Collection";
                    }
                    entities.Entry(requ).State = System.Data.Entity.EntityState.Modified;
                }
                entities.SaveChanges();
                ending = "execute successfully";



            }
            catch (Exception e)
            {
                ending = e.ToString();
            }
            return ending;
        }

        public static List<WCF_RequsitionJoinEmployee> ListRequsitionWithPendingtoCollectionWithDepartmentID(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Waiting for Collection") && x.Employee.Department.DepartmentCode.Equals(DpCode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).ToList<WCF_RequsitionJoinEmployee>();
                return list;
            }
        }


        public static List<WCF_RequsitionJoinEmployee> ListRequsitionCompleteWithDepartmentID(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Completed") && x.Employee.Department.DepartmentCode.Equals(DpCode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).ToList<WCF_RequsitionJoinEmployee>();
                return list;

            }
        }


        public static List<WCF_RequsitionJoinEmployee> ListRequsitionRejectedWithDepartmentID(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Rejected") && x.Employee.Department.DepartmentCode.Equals(DpCode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).ToList<WCF_RequsitionJoinEmployee>();
                return list;

            }
        }

        public static List<WCF_RequsitionJoinEmployee> ListRequsitionPendingApprovalWithDepartmentID(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Pending Approval") && x.Employee.Department.DepartmentCode.Equals(DpCode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                { Requid = m.RequId, name = f.Name, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).ToList<WCF_RequsitionJoinEmployee>();

                return list;
            }

        }

        public static List<WCF_RequsitionJoinEmployee> ListRequsitionWaitingForDeliveryWithDepartmentID(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Waiting For Delivery") && x.Employee.Department.DepartmentCode.Equals(DpCode)).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                {
                    Requid = m.RequId,
                    name = f.Name,
                    SubmittedDate = m.RequestedDate.ToString(),
                    status = m.Status
                }).ToList<WCF_RequsitionJoinEmployee>();
                return list;
            }

        }

        public static List<WCF_RequsitionJoinEmployee> ListRequisitionWithPendingtoCollectionForClerk()
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                List<WCF_RequsitionJoinEmployee> list = ctx.Requisitions.Where(x => x.Status.Equals("Waiting for Collection")).Join(ctx.Employees, m => m.EmployeeId, f => f.UserId, (m, f) => new WCF_RequsitionJoinEmployee
                { Requid = m.RequId, DepartmentCode = f.DepartmentCode, SubmittedDate = m.RequestedDate.ToString(), status = m.Status }).ToList<WCF_RequsitionJoinEmployee>();
                return list;
            }
        }

        public static String GetCollectionPointName(String DpCode)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Departments.Where(x => x.DepartmentCode.Equals(DpCode)).First().CollectionPoint.CollectionPointName.ToString();


            }
        }





    }


}
