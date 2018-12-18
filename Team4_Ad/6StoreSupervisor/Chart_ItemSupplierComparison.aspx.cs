using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Globalization;

namespace Team4_Ad
{
    public partial class Charts2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //To generate data for DropDownList1

                using (LastADEntities b = new LastADEntities())
                {
                    var itemcat = (from ic in b.ItemCategories select ic.CategoryName).ToList();

                    itemcat.Insert(0, "---Select---");
                    DropDownList1.SelectedIndex = 0;
                    DropDownList1.DataSource = itemcat;
                    DropDownList1.DataBind();


                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (LastADEntities b = new LastADEntities())
            {
                //DropDownList2 options are dependent on the selected item in DropDownList1

                if (DropDownList1.SelectedValue != "---Select---")
                {
                    var dropdown2ds = b.ItemLists.Join(b.ItemCategories, m => m.CategoryId, f => f.CategoryId,
                       (m, f) => new {
                           ItemId = m.ItemId,
                           Description = m.Description,
                           CategoryName = f.CategoryName
                       }).ToList();
                    DropDownList2.DataTextField = "Description";
                    DropDownList2.DataValueField = "ItemId";
                    DropDownList2.DataSource = dropdown2ds.Where(p => p.CategoryName == DropDownList1.SelectedValue).ToList();

                    DropDownList2.DataBind();
                }
                else if (DropDownList1.SelectedValue == "---Select---")
                {
                    DropDownList2.DataSource = null;
                    DropDownList2.Items.Clear();

                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //To save the Start Year and End Year that user chose.

        static int[] yearrange = new int[2];
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearrange[0] = Int32.Parse(StartYear.SelectedItem.Text);
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearrange[1] = Int32.Parse(EndYear.SelectedItem.Value);
        }

        protected void CreateTable(object sender, EventArgs e)
        {
            using (LastADEntities b = new LastADEntities())
            {
                //To obtain the itemid of the item selected
                string selecteditem = DropDownList2.SelectedItem.Text.ToString();
                ItemList idd = new ItemList();

                idd = b.ItemLists.Where(p => p.Description.Equals(selecteditem)).First();
                String idddd = idd.ItemId;

                Chart1.ChartAreas.Add("ChartArea2");
                var sd = yearrange[0];
                var ed = yearrange[1];

                //Setting up the Chart properties
                Title title = new Title();
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.Text = "Proportion of " + idd.Description + " Ordered from its Suppliers";
                Chart1.Titles.Add(title);
                Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                Chart1.Legends.Add("Supplier");

                int z = 0;

                //getting datapoints according to what user selected
                var xy = b.PurchaseOrderDetails.Where(p => p.ItemId.Contains(idddd))

                        .Join(b.PurchaseOrders.Where(q => q.DeliveryDate.Value.Year >= sd &&
                        q.DeliveryDate.Value.Year <= ed), m => m.PurchaseOrderId, f => f.PurchaseOrderId,
                        (m, f) => new { Quantity = m.Quantity, SupplierName = f.Supplier })

                        .GroupBy(n => n.SupplierName)
                        .Select(g => new { b = g.Key.SupplierName, a = g.Sum(a => a.Quantity) }).ToList();

                //converting datapoints into coordinates
                List<string> xcoor = new List<string>();
                List<int> ycoor = new List<int>();
                for (int p = 0; p < xy.Count; p++)
                {
                    //    try
                    //    {
                    //        {
                    xcoor.Add(xy[p].b);
                    ycoor.Add((int)(xy[p].a));
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        xcoor.Add(0);
                    //        ycoor.Add(0);
                    //    }
                }

                Chart1.Series.Add("1");

                Chart1.Series[z].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                Chart1.Series[z].Points.DataBindXY(xcoor, ycoor);


                Chart1.Series[z].IsValueShownAsLabel = true;
                Chart1.Series[z].ToolTip = "2";

                z++;

                Chart1.DataBind();
            }
        }



        protected void Chart1_Load(object sender, EventArgs e)
        {

        }


    }
}