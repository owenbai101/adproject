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
    public partial class Chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (LastADEntities b = new LastADEntities())
                {
                    //To generate data for DropDownList1
                    var itemcat = (from ic in b.ItemCategories select ic.CategoryName).ToList();
                    itemcat.Insert(0, "---Select---");
                    //DropDownList1.SelectedIndex = 0;

                    DropDownList1.DataSource = itemcat;
                    DropDownList1.DataBind();
                    //To generate the options for departments
                    var depts = from dept in b.Departments select dept.DepartmentName;
                    DeptList.DataSource = depts.ToArray();

                    DeptList.DataBind();
                    DeptList.Items.Remove(DeptList.Items.FindByText("Stationary Store Dept"));

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
                    var dropdown2ds = b.ItemLists.Join(b.ItemCategories.Where(p => p.CategoryName == DropDownList1.SelectedValue), m => m.CategoryId, f => f.CategoryId,
                       (m, f) => new
                       {
                           ItemId = m.ItemId,
                           Description = m.Description,

                       }).ToList();
                    DropDownList2.DataTextField = "Description";
                    DropDownList2.DataValueField = "ItemId";
                    //DropDownList2.DataSource = dropdown2ds.Where(p => p.CategoryName == DropDownList1.SelectedValue).ToList();

                    DropDownList2.DataSource = dropdown2ds;
                    DropDownList2.DataBind();
                }
                else if (DropDownList1.SelectedValue == "---Select---")
                {
                    DropDownList2.DataSource = null;
                    DropDownList2.Items.Clear();

                }
            }
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
                string selecteditem = DropDownList2.SelectedItem.Text.ToString();
                ItemList idd = new ItemList();

                //To get item id
                idd = b.ItemLists.Where(p => p.Description.Equals(selecteditem)).First();
                String idddd = idd.ItemId;
                int NumOfDepts = 0;
                ArrayList DeptSelected = new ArrayList();

                //To get all the departments chosen by user
                for (int i = 0; i < DeptList.Items.Count; i++)
                {
                    if (DeptList.Items[i].Selected)
                    {
                        String temp = DeptList.Items[i].Value.ToString();
                        Department dd = b.Departments.Where(p => p.DepartmentName.Contains(temp)).First();
                        String temp2 = dd.DepartmentCode;
                        DeptSelected.Add(temp2);
                        NumOfDepts++;
                    }
                }

                Chart1.ChartAreas.Add("ChartArea2");
                var sd = yearrange[0];
                var ed = yearrange[1];

                //Setting up the Chart properties
                Chart1.ChartAreas[0].AxisX.Title = "Year";
                Chart1.ChartAreas[0].AxisY.Title = "Quantity Ordered";
                Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                Chart1.Legends.Add("QuantityOrdered");
                Title title = new Title();
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.Text = "Trend Analysis of Quantity of " + idd.Description + " Ordered";
                Chart1.ChartAreas[0].AxisX.Minimum = sd;
                Chart1.ChartAreas[0].AxisX.Maximum = ed;


                Chart1.Titles.Add(title);
                int z = 0;
                //To get all the datapoints that match the conditions chosen by user
                foreach (string ddept in DeptSelected)
                {

                    var xy = b.Transactions.Where(p => p.ItemId.Contains(idddd)
                        && p.EntryDate.Value.Year >= sd && p.EntryDate.Value.Year <= ed)

                        .Join(b.Requisitions, m => m.Requid, f => f.RequId,
                        (m, f) => new { Requid = m.Requid, EmployeeId = f.EmployeeId, m.EntryDate, m.Quantity })

                    .Join(b.Employees.Where(p => p.DepartmentCode.Equals(ddept)), q => q.EmployeeId, p => p.UserId,
                    (q, p) => new { q.EntryDate, p.DepartmentCode, q.Quantity })

                     .GroupBy(n => n.EntryDate.Value.Year)
                    .Select(g => new { b = g.Key, a = g.Sum(a => a.Quantity) }).ToList();

                    List<int> xcoor = new List<int>();
                    List<int> ycoor = new List<int>();
                    
                    //Converting datapoints into coordinates for the chart
                    for (int q = sd; q <= ed; q++)
                    {
                        for (int p = 0; p < xy.Count; p++)
                        {
                            if (q == xy[p].b)
                            {
                                xcoor.Add(q);
                                ycoor.Add((int)(xy[p].a));
                            }
                            //else
                            //{
                            //    xcoor.Add(q);
                            //    ycoor.Add(0);
                            //}
                        }

                    }

                    Chart1.Series.Add(ddept.ToString());

                    Chart1.Series[z].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    Chart1.Series[z].Points.DataBindXY(xcoor, ycoor);
                    Chart1.Series[z].IsVisibleInLegend = true;
                    Chart1.Series[z].IsValueShownAsLabel = true;
                    Chart1.Series[z].BorderWidth = 3;
                    Chart1.Series[z].ToolTip = "Quantity Ordered: #VALY";
                    Chart1.Series[z].Font = new System.Drawing.Font("Arial", 12);
                    Chart1.Series[z]["LabelStyle"] = "Top";
                    Chart1.Series[z].LabelBackColor = Color.LightCyan;

                    z++;
                    Chart1.DataBind();
                }
            }
        }
    }

}
