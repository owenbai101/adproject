using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Team4_Ad
{
    public partial class retrieveReqHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LastADEntities entities = new LastADEntities();
                var c = entities.Requisitions.Where(x => x.Status.Equals("Completed")|| x.Status.Equals("Rejected")).ToList();
                GridView1.DataSource = c;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime d = Calendar1.SelectedDate;
            LastADEntities entities = new LastADEntities();
            var c = entities.Requisitions.Where(x => x.Status.Equals("Completed") ).ToList();
            GridView1.DataSource = c;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DateTime d = Calendar1.SelectedDate;
            LastADEntities entities = new LastADEntities();
            var c = entities.Requisitions.Where(x => x.Status.Equals("Rejected")).ToList();
            GridView1.DataSource = c;
            GridView1.DataBind();
        }

        
        protected void Button5_Click(object sender, EventArgs e)
        {
            //LastADEntities3 entities = new LastADEntities3();
            ////int id = Convert.ToInt16(GridView1.SelectedDataKey.ToString());
            //GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            //c = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]);
            //
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            LastADEntities entities = new LastADEntities();
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            int c = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]);
            var s = entities.RequDetails.Where(x => x.RequId==c).ToList();
            GridView2.DataSource = s;
            GridView2.DataBind();
        }
    }
}