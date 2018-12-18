using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class StockCards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Business.Listcategory();
                DropDownList1.DataTextField = "CategoryName";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string categoryname = DropDownList1.SelectedItem.ToString();
            GridView1.DataSource = Business.GetitemListbyCatname(categoryname);
            GridView1.DataBind();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String itemID1 = TextBox1.Text;
            GridView1.DataSource = Business.FindItemByID(itemID1);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridView1.SelectedDataKey.Value.ToString();
            Session["itid"] = id;
            Response.Redirect("StockCardDetail.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryname = DropDownList1.SelectedItem.ToString();
            GridView1.DataSource = Business.GetitemListbyCatname(categoryname);
            GridView1.DataBind();
        }
    }
}