using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad._7OtherPages
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IIdentity id = User.Identity;
            LastADEntities entities = new LastADEntities();
            Employee employee = new Employee();
            employee = entities.Employees.Where(x => x.Name == id.Name).First();
            string dept = employee.DepartmentCode;
            string role = employee.Role.RoleDescription;
            string employeename = employee.Name;
            string collectionpoint="0";
            string Bossemail = "0";
            string employeeid = employee.UserId.ToString();

            if (employee.StartDate != null && employee.EndDate != null)
            {
                if (DateTime.Now.Date.CompareTo(employee.StartDate) >= 0 && DateTime.Now.Date.CompareTo(employee.EndDate) <= 0)
                {
                    employee.RoleId = 6;
                    entities.SaveChanges();
                }
                else if (DateTime.Now.Date.CompareTo(employee.EndDate) > 0)
                {
                    if (User.IsInRole("Employee"))
                    {
                        employee.RoleId = 4;
                        employee.StartDate = null;
                        employee.EndDate = null;
                        entities.SaveChanges();
                    }
                    else
                    {
                        employee.RoleId = 5;
                        employee.StartDate = null;
                        employee.EndDate = null;
                        entities.SaveChanges();
                    }
                }
            }



            if (!dept.Contains("STNR"))
            {
                collectionpoint = employee.Department.CollectionPoint.CollectionPointName;

                int? ii = 6;


                 Bossemail = entities.Employees.Where(x => x.DepartmentCode == dept && (x.RoleId == ii)).First().Email;
                
            }
            else
            {
                Bossemail = "owenbai101@gmail.com";
                collectionpoint = "0";
            }



            Session["EmpName"] = employeename;
            Session["DpCode"] = dept;
            Session["EmpRole"] = role;
            Session["CollectionPoint"] = collectionpoint;
            Session["EmpId"] = employeeid;
            Session["BossEmail"] = Bossemail;  
            


            if (id.IsAuthenticated)
            {
                if (User.IsInRole("Store Clerk"))
                {
                    Response.Redirect("~/4StoreClerk/ClerkHome.aspx");

                }
                else if (User.IsInRole("Supervisor"))
                {
                    Response.Redirect("~/6StoreSupervisor/SupervisorAdjVoucher.aspx");
                }
                else if (User.IsInRole("Manager"))
                {
                    Response.Redirect("~/5StoreManager/mt250AdjustmentVoucher.aspx");
                }
                else if (User.IsInRole("Employee"))
                {
                    Response.Redirect("~/1DepartmentEmployee/EmployeeHome.aspx");
                }
                else if (User.IsInRole("Department Representative"))
                {
                    Response.Redirect("~/3DepartmentRep/RepHome.aspx");
                }
                else if (User.IsInRole("Department Head"))
                {
                    Response.Redirect("~/2DepartmentHead/HeadHome.aspx");
                }


            }

        }
    }
}