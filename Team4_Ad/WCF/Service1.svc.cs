using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team4_Ad.WCF;
using System.Web.Security;

using System.Collections;

namespace Team4_Ad
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public object JsonConvert { get; private set; }

        public List<string> Getitemname()
        {

            return EmployeeHomeController.GetItemname();
        }

        public String AndroidLogin(WCF_User users)
        {
            {


                //users.username = "qiyuan";
                //users.userpassword = "qiyuan,000";
                // string tokens = null;
                //string Token= JsonConvert.SerializeObject(users);
                //JObject jo = JObject.Parse(b);

                ////加密
                //string user = jo.ToString();
                //byte[] bytes = Encoding.UTF8.GetBytes(users.username);
                //string username = Convert.ToBase64String(bytes);
                //byte[] bytes1 = Encoding.UTF8.GetBytes(users.userpassword);
                //string userpassword = Convert.ToBase64String(bytes1);

                ////得到 jsonstring
                //WCF_User test = new WCF_User(username, userpassword);
                //string teststr = JsonConvert.SerializeObject(test);

                ////解密从teststr
                //JObject testjo = JObject.Parse(teststr);
                //string jieminame = testjo["username"].ToString();
                //byte[] bytes2 = Convert.FromBase64String(jieminame);
                //jieminame = Encoding.UTF8.GetString(bytes2);
                string jiemipwd = users.password;
                
                byte[] bytes3 = Convert.FromBase64String(jiemipwd);
                jiemipwd = Encoding.UTF8.GetString(bytes3);
                string ending = "saasasa";
                string jieminame = users.name;
                
                //  string gettoken = users.token;
                // string status = users.status;

                try
                {
                    if (Membership.ValidateUser(jieminame, jiemipwd))
                    {
                        LastADEntities entities = new LastADEntities();
                        Employee employee = entities.Employees.Where(x => x.Name == jieminame).First();
                        //  users.token = "11111";
                        users.department = employee.Department.DepartmentCode;
                        users.status = "1";
                        users.token = employee.UserId.ToString();
                        
                        // ending = "1" + users.name;
                        //tokens = JsonConvert.SerializeObject(users);
                        ending =users.token;

                    }
                    else { ending = "error"; }

                }
                catch (Exception e)
                {
                    ending = jieminame;
                }
                return ending;



            }
        }
        public List<WCF_RequisitionDetail> GetRequisitionDetail(string requid)
        {

            using (LastADEntities ctx = new LastADEntities())
            {
                int requsitionid =Int32.Parse(requid);
                return ctx.RequDetails.Where(x => x.RequId == requsitionid).Join(ctx.ItemLists, m => m.ItemId, f => f.ItemId, (m, f) => new WCF_RequisitionDetail{ itemid = m.ItemId, name = f.Description, quantity = m.RequestedQuantity.ToString() }).ToList();

            }
        }

        public WCF_RequsitionJoinEmployee GetRequisition(string requid)
        {
            int id = Int32.Parse(requid);
            return Business.GetRequisitionbyid(id);
        }

        public List<int> GetRequidPendingApprove()
        {
            return Business.GetRequidPendingApprove();
        }

        public List<String> GetItemListID(string categoryname)
        {
            return Business.GetitemIdbyCatname(categoryname);

        }

        public WCF_ItemList GetItemListByID(string Itemid)
        {
            ItemList I = Business.GetitemListbyItemId(Itemid);
            String a = Convert.ToString(I.Stock); 
            return new WCF_ItemList(I.ItemId, I.Description, I.Bin, a);
        }

        public List<String> GetRequisitionDetailid(string requid)
        {
            int id = Int32.Parse(requid);
            return Business.GetRequisitionDetailid(id);

        }

        public WCF_RequisitionDetail GetRequisitionDetailByRequdetailId(string requdetailid)
        {

            int id = Int32.Parse(requdetailid);
            return Business.GetRequisitionDetailByRequisitionId(id);
             
        }


        public List<int> GetRequisitionidWaitingForCollection()
        {
            return Business.GetRequidWaitingForCollection();

        }

        public List<WCF_Disbursement> GetDisbursement(String CpId)
        {
            List<WCF_Disbursement> list = new List<WCF_Disbursement>();
            int id = Int32.Parse(CpId);
            foreach (DisbursementListForSend a in transactioncontrol.showDisbursementSeBy(id))
            {
                
                list.Add(new WCF_Disbursement(a.Description, a.Quantity.ToString()));
            }
            return list;
        }

        public void ApproveRequisition(String reqid)
        {
            int id = Int32.Parse(reqid); 
            Business.ConfirmRequsition(id, null,"qiyuan");
        }

        public void RejectRequisition(String reqid)
        {
            int id = Int32.Parse(reqid);
            Business.RejectRequisition(id, null,"owen");
        }

        //public void ChangeCollectionPoint(String cid)
        //{
        //    int id = Int32.Parse(cid);
        //    Business.ChangeCollectionPoint(id);
        //}

        public List<WCF_RequisitionDetailJoinItemList> RetrievalListForm()
        {
            return Business.RetrievalList();
        }

        public List<int> GetRequisitionidWaitingForDelivery()
        {
            return Business.GetRequidWaitingForDelivery();
        }

        public string ConfirmRequisition(List< WCF_RequisitionDetail> WRDS)

        {
            LastADEntities entities = new LastADEntities();
            string end = "0";
            int tok =Convert.ToInt16( WRDS.First().Requid);
            try
            {
                //Employee employee = entities.Employees.Where(x => x.UserId == tok).First().Requisitions;
                end = Business.Confrimrequ(WRDS);
            }
            catch (Exception e)
            {
                end = "-1";
            }
            if (end == "-1")
            {
                return end;
            }
            return Business.Confrimrequ(WRDS);
            //StringBuilder stringBuilder = new StringBuilder();
            //foreach(WCF_RequisitionDetail req in WRDS)
            //{
            //    stringBuilder.Append(req.itemid);
            //}
            //return stringBuilder.ToString();
        }

        public String UpdateAdjVoucher(WCF_AdjVoucher AdjV)
        {
            LastADEntities entities = new LastADEntities();
            AdjVoucher adj = new AdjVoucher();
            adj.ItemId = AdjV.ItemId;
            adj.QuantityAdj = Int32.Parse(AdjV.QuantityAdj);
            adj.Reason = AdjV.Reason;
            adj.RequestEmpNum = Int32.Parse(AdjV.RequestEmpNum);
            adj.SubmitDate = DateTime.Now;
            adj.Status = "Pending Authorisation";
            entities.AdjVouchers.Add(adj);
            entities.SaveChanges();
            return "Successfully";


        }

        public List<WCF_RequsitionJoinEmployee> GetRequsitionWithPendingtoCollectionWithDepartmentID(String DpCode)
        {
            return Business.ListRequsitionWithPendingtoCollectionWithDepartmentID(DpCode);

        }

        public List<WCF_RequsitionJoinEmployee> GetRequsitionRequsitionCompleteWithDepartmentID(String DpCode)
        {
            return Business.ListRequsitionCompleteWithDepartmentID(DpCode);
        }

        public List<WCF_RequsitionJoinEmployee> GetRequsitionRejectedWithDepartmentID(String DpCode)
        {
            return Business.ListRequsitionRejectedWithDepartmentID(DpCode);

        }

        public List<WCF_RequsitionJoinEmployee> GetRequsitionPendingApprovalWithDepartmentID(String DpCode)
        {
            return Business.ListRequsitionPendingApprovalWithDepartmentID(DpCode);
            
        }

        public List<WCF_RequsitionJoinEmployee> GetRequsitionWaitingForDeliveryWithDepartmentID(String DpCode)
        {

            return Business.ListRequsitionWaitingForDeliveryWithDepartmentID(DpCode);
        }


        public List<WCF_RequsitionJoinEmployee> RequsitionWaitingForDeliveryWithDepartmentID(String DpCode)
        {
            return Business.ListRequsitionWaitingForDeliveryWithDepartmentID(DpCode);
        }

        public List<WCF_Disbursement> GetDisbursementFordp(String dpcode)
        {
            List<WCF_Disbursement> list = new List<WCF_Disbursement>();

            foreach (DisbursementListForDepa a in transactioncontrol.showDisbursementDpBy(dpcode))
            {

                list.Add(new WCF_Disbursement(a.Description, a.Quantity.ToString()));
            }
            return list;
        }

        public String GetCollectionPointName(String dpcode)
        {
            return Business.GetCollectionPointName(dpcode);

        }

        public String ChangeCollectionPoint(WCF_Department dpmt)
        {
            int id = Int32.Parse(dpmt.CollectionPointId);
            string dpid = dpmt.DepartmentCode;
            Business.ChangeCollectionPoint(id, dpid);
            return "successful";
        }

        public String GetDepartmentID(String EmpId)

        {
            int id = Int32.Parse(EmpId);
            using (LastADEntities ctx = new LastADEntities())
            {
               return ctx.Employees.Where(x => x.UserId == id).First().DepartmentCode;

            }
        }

        public String GetRoleID(String EmpId)
        {
            int id = Int32.Parse(EmpId);
            using (LastADEntities ctx = new LastADEntities())
            {
                return ctx.Employees.Where(x => x.UserId == id).First().RoleId.ToString();
            }
        }

    }
}
