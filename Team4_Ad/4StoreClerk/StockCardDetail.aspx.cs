using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                TextBox1.Text = Session["itid"].ToString();
                String id = TextBox1.Text;
                
                LastADEntities entities = new LastADEntities();
                //TextBox_date.Text = DateTime.Now.Date.ToString();
                ItemList ii = new ItemList();
                ii = entities.ItemLists.Find(id);
                //TextBox_desc.Text = ii.Description;
                //TextBox_uom.Text = ii.UOM;
                GridView1.DataSource = transactioncontrol.showTransactionBy(id);
                GridView1.DataBind();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}