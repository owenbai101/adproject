using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad._2DepartmentHead
{
    public partial class Head2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpRole"] != null)
            {
                Label6.Text = Session["EmpRole"].ToString();
            }
            if (Session["EmpName"] != null)
            {
                Label4.Text = Session["EmpName"].ToString();
            }
        }
    }
}