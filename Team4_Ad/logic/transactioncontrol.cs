using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team4_Ad
{
    public class transactioncontrol
    {




        public static List<Transaction> showTransactionBy(string itemid)
        {
            LastADEntities entities = new LastADEntities();
            List<Transaction> list = entities.Transactions.
                Where(x => x.ItemId.Equals(itemid)).ToList();
            return list;
        }

        public static List<DisbursementListForDepa> showDisbursementDpBy(String dpcode)
        {
            LastADEntities entities = new LastADEntities();
            List<int> list = Business.GetRequidWaitingForDelivery();
            List<Transaction> tr = new List<Transaction>();
            foreach (int id in list)
            {
                List<Transaction> trans = entities.Requisitions.Where(x => x.RequId.Equals(id)).First().Transactions.ToList();
                foreach (Transaction tran in trans)
                {
                    tr.Add(tran);
                }
            }
            var tt = tr.Where(p => p.Requisition.Employee.Department.DepartmentCode.Equals(dpcode)).
              Join(entities.Departments, m => m.Requisition.Employee.DepartmentCode, f => f.DepartmentCode,
            (m, f) => new DisbursementListForDepa { CollectionPoint = f.CollectionPoint.CollectionPointName, Description = m.ItemList.Description, Quantity = m.Quantity }).ToList();
            var dd = tt.GroupBy(x => x.Description).Select(y => new DisbursementListForDepa { Description = y.Key, Quantity = y.Sum(x => x.Quantity) }).ToList();

            return dd;
        }

        public static List<DisbursementListForSend> showDisbursementSeBy(int CpId)
        {
            LastADEntities entities = new LastADEntities();
            List<int> list = Business.GetRequidWaitingForDelivery();
            List<Transaction> tr = new List<Transaction>();
            foreach (int id in list)
            {
                List<Transaction> trans = entities.Requisitions.Where(x => x.RequId == id).First().Transactions.ToList();
                foreach (Transaction tran in trans)
                {
                    tr.Add(tran);
                }
            }
            var tt = tr.Where(p => p.Requisition.Employee.Department.CollectionPoint.CollectionPointId.Equals(CpId)).
              Join(entities.Departments, m => m.Requisition.Employee.DepartmentCode, f => f.DepartmentCode,
            (m, f) => new DisbursementListForDepa { CollectionPoint = f.CollectionPoint.CollectionPointName, Description = m.ItemList.Description, Quantity = m.Quantity }).ToList();

            var dd = tt.GroupBy(x => x.Description).Select(y => new DisbursementListForSend { Description = y.Key, Quantity = y.Sum(x => x.Quantity) }).ToList();
            return dd;
        }

        internal static void generatedishburement(List<string> idlist, List<int> amtlist)
        {
            LastADEntities entities = new LastADEntities();
            RequDetail requDetail = new RequDetail();
            for (int i = 0; i < idlist.Count(); i++)
            {
                string id= idlist[i];
                var c = entities.Requisitions.Where(x => x.Status.Equals("Waiting For Collection") &&
              x.RequDetails.Select(y => y.ItemId).Contains(id)).OrderBy(x => x.SignDate).ToList();

                foreach (Requisition requ in c)
                {


                    DateTime entryday = DateTime.Now;
                    int? RetrievedAmtnt = requ.RequDetails.Where(x => x.ItemId.Equals(idlist[i])).Select(x => x.RequestedQuantity).First();
                    if (amtlist[i] == 0)
                    {

                    }
                    else if (amtlist[i] < RetrievedAmtnt)
                    {
                        RetrievedAmtnt = amtlist[i];
                    }

                    if (RetrievedAmtnt != 0)
                    {
                        RequDetail requde = new RequDetail();
                        requde = requ.RequDetails.Where(x => x.ItemId.Equals(id)).First();
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
                        amtlist[i] = amtlist[i] - Convert.ToInt32(RetrievedAmtnt);
                    }

                }
                foreach (Requisition requ in c)
                {
                    requ.Status = "Waiting For Delivery";
                    entities.SaveChanges();
                }
            }
        }
    }
    }

    public class DisbursementListForDepa
    {
        public string CollectionPoint { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }




    }

    public class DisbursementListForSend
    {

        public string Description { get; set; }
        public int? Quantity { get; set; }

    }
