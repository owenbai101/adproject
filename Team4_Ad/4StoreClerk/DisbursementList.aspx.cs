using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class DisbursementList : System.Web.UI.Page
    {
        //This page is to filter disbursement list by the 6 collection points with the default showing the first
        //collection point. The filter method (showDisbursementSeBy) is defined in the transactioncontrol class

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {             
                GridView1.DataSource = transactioncontrol.showDisbursementSeBy(1);
                GridView1.DataBind();
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(4);
            GridView1.DataBind();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(1);
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(2);
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(3);
            GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(5);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            
            GridView1.DataSource = transactioncontrol.showDisbursementSeBy(6);
            GridView1.DataBind();
        }
    }
}