using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad.DepartmentRep
{
    public partial class RepHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LastADEntities ctx = new LastADEntities();
            //var c = ctx.Departments.Where(x => x.CollectionPointId == RadioButtonList1.SelectedIndex); //MAY need to changed RadioButtonList1.SelectedIndex

            if (!IsPostBack)
            {
                if (Session["CollectionPoint"] != null)
                {
                    Label1.Text = Session["CollectionPoint"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String DpCode = Session["DpCode"].ToString();
            LastADEntities ctx = new LastADEntities();

            Department c = ctx.Departments.Where(x => x.DepartmentCode == DpCode).First();
            c.CollectionPointId = RadioButtonList1.SelectedIndex + 1;
            ctx.SaveChanges();


        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = RadioButtonList1.SelectedItem.Text;
        }
    }
}