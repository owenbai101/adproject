using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

using Team4_Ad.WCF;
using System.Collections;

namespace Team4_Ad
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Json)]
        List<String> Getitemname();

        //[OperationContract]
        //[WebGet(UriTemplate = "/GetRequisitionNotApprove", ResponseFormat = WebMessageFormat.Json)]
        //String GetRequisitionNotApprove();

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionDetail/{requid}", ResponseFormat = WebMessageFormat.Json)]

        List<WCF_RequisitionDetail> GetRequisitionDetail(string requid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisition/{requid}", ResponseFormat = WebMessageFormat.Json)]

        WCF_RequsitionJoinEmployee GetRequisition(string requid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionidPendingApprove", ResponseFormat = WebMessageFormat.Json)]

        List<int> GetRequidPendingApprove();

        [OperationContract]
        [WebGet(UriTemplate = "/GetItemListId/{categoryname}", ResponseFormat = WebMessageFormat.Json)]

        List<String> GetItemListID(string categoryname);

        [OperationContract]
        [WebGet(UriTemplate = "/GetItemByID/{Itemid}", ResponseFormat = WebMessageFormat.Json)]

         WCF_ItemList GetItemListByID(string Itemid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionDetailid/{requid}", ResponseFormat = WebMessageFormat.Json)]

        List<String> GetRequisitionDetailid(string requid);


        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionDetailByRequdetailId/{requdetailid}", ResponseFormat = WebMessageFormat.Json)]

        WCF_RequisitionDetail GetRequisitionDetailByRequdetailId(string requdetailid);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionidWaitingForCollection", ResponseFormat = WebMessageFormat.Json)]

        List<int> GetRequisitionidWaitingForCollection();


        [OperationContract]
        [WebGet(UriTemplate = "/GetDisbursement/{CpId}", ResponseFormat = WebMessageFormat.Json)]

        List<WCF_Disbursement> GetDisbursement(String CpId);

        [OperationContract]
        [WebGet(UriTemplate = "/ApproveRequisition/{reqid}",ResponseFormat = WebMessageFormat.Json)]
       void ApproveRequisition(String reqid);

        [OperationContract]
        [WebGet(UriTemplate = "/RejectRequisition/{reqid}", ResponseFormat = WebMessageFormat.Json)]
        void RejectRequisition(String reqid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangeCollectionPoint", Method = "POST",
             RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]

        String ChangeCollectionPoint(WCF_Department dpmt);

        [OperationContract]
        [WebGet(UriTemplate = "/RetrievalListForm", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequisitionDetailJoinItemList> RetrievalListForm();

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitionidWaitingForDelivery", ResponseFormat = WebMessageFormat.Json)]

        List<int> GetRequisitionidWaitingForDelivery();

        [OperationContract]

        [WebInvoke(UriTemplate = "/ConfirmRequisition", Method = "POST",ResponseFormat = WebMessageFormat.Json,

         RequestFormat = WebMessageFormat.Json)]

        string ConfirmRequisition(List< WCF_RequisitionDetail> WRDS);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateAdjVoucher", Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        //ResponseFormat = WebMessageFormat.Json)]
        String UpdateAdjVoucher(WCF_AdjVoucher AdjVoucher);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AndroidLogin", Method = "POST",
     RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json)]
        String AndroidLogin(WCF_User users);

        

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequsitionWithPendingtoCollectionWithDepartmentID/{Dpcode}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequsitionJoinEmployee> GetRequsitionWithPendingtoCollectionWithDepartmentID(String DpCode);


        [OperationContract]
        [WebGet(UriTemplate = "/GetRequsitionRequsitionCompleteWithDepartmentID/{Dpcode}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequsitionJoinEmployee> GetRequsitionRequsitionCompleteWithDepartmentID(String DpCode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRequsitionRejectedWithDepartmentID/{Dpcode}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_RequsitionJoinEmployee> GetRequsitionRejectedWithDepartmentID(String DpCode);

        
        [OperationContract]
        [WebGet(UriTemplate = "/GetRequsitionPendingApprovalWithDepartmentID/{DpCode}", ResponseFormat = WebMessageFormat.Json)]

        List<WCF_RequsitionJoinEmployee> GetRequsitionPendingApprovalWithDepartmentID(String DpCode);

        
        [OperationContract]
        [WebGet(UriTemplate = "/RequsitionWaitingForDeliveryWithDepartmentID/{DpCode}", ResponseFormat = WebMessageFormat.Json)]

        List<WCF_RequsitionJoinEmployee> RequsitionWaitingForDeliveryWithDepartmentID(String DpCode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDisbursementFordp/{dpcode}", ResponseFormat = WebMessageFormat.Json)]

        List<WCF_Disbursement> GetDisbursementFordp(String dpcode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCollectionPointName/{dpcode}", ResponseFormat = WebMessageFormat.Json)]

        String GetCollectionPointName(String dpcode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartmentID/{EmpId}", ResponseFormat = WebMessageFormat.Json)]

        String GetDepartmentID(String EmpId);

        [OperationContract]
        [WebGet(UriTemplate = "/GetRoleID/{EmpId}", ResponseFormat = WebMessageFormat.Json)]

        String GetRoleID(String EmpId);


    }
}
