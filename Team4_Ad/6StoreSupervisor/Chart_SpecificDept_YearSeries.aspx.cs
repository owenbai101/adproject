using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Globalization;
using System.Collections;

namespace Team4_Ad.StoreSupervisor
{
    public partial class Chart_Dept_yearbreakdown : System.Web.UI.Page
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
                    //To generate the options for departments

                    var depts = from dept in b.Departments select dept.DepartmentName;
                    DeptList.DataSource = depts.ToArray();

                    DeptList.DataBind();
                    DeptList.Items.Remove(DeptList.Items.FindByText("Stationary Store Dept"));
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
                string selecteditemcat = DropDownList1.SelectedValue;
                string DeptSelected = "";
                string Deptname = "";
                List<int> MthSelected = new List<int>();
                string[] months = new string[13] { "", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
                //To get all the departments chosen by user

                for (int i = 0; i < DeptList.Items.Count; i++)
                {
                    if (DeptList.Items[i].Selected)
                    {
                        String temp = DeptList.Items[i].Value.ToString();
                        Department dd = b.Departments.Where(p => p.DepartmentName.Contains(temp)).First();
                        DeptSelected = dd.DepartmentCode;
                        Deptname = dd.DepartmentName;
                    }
                }
                //To get all the months chosen by user

                for (int j = 0; j < CheckBoxList2.Items.Count; j++)
                {
                    if (CheckBoxList2.Items[j].Selected)
                    {
                        MthSelected.Add(Int32.Parse(CheckBoxList2.Items[j].Value));

                    }
                }
                var sd = yearrange[0];
                var ed = yearrange[1];

                //Setting up chart properties
                Chart1.ChartAreas.Add("ChartArea2");
                Chart1.ChartAreas[0].AxisX.Title = Deptname;
                Chart1.ChartAreas[0].AxisY.Title = "Quantity Ordered";
                Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                Chart1.Legends.Add("QuantityOrdered");
                Title title = new Title();
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.Text = "Month Breakdown of Item Quantity Ordered from " + selecteditemcat + " Category by "+Deptname ;

                Chart1.Titles.Add(title);
                //Getting datapoints according to what user selected
                for (int i = sd; i <= ed; i++)
                {

                    var xy = b.Transactions.Where(p => (p.ItemList.ItemCategory.CategoryName.Contains(selecteditemcat))
                        && (p.EntryDate.Value.Year == i))

                        .Join(b.Requisitions, m => m.Requid, f => f.RequId,
                        (m, f) => new { Requid = m.Requid, EmployeeId = f.EmployeeId, m.EntryDate, m.Quantity })

                    .Join(b.Employees.Where(p => p.DepartmentCode.Equals(DeptSelected)), q => q.EmployeeId, p => p.UserId,
                    (q, p) => new { q.EntryDate, p.DepartmentCode, q.Quantity })

                    .GroupBy(n => n.EntryDate.Value.Month)

                    .Select(g => new { b = g.Key, a = g.Sum(a => a.Quantity) }).OrderBy(x => x.b).ToList();

                    List<string> xcoor = new List<string>();
                    List<int> ycoor = new List<int>();

                    //Converting datapoints into coordinates

                    if (MthSelected.Count == 0)
                    {
                        for (int p = 0; p < xy.Count; p++)
                        {
                            xcoor.Add(months[xy[p].b]);
                            ycoor.Add((int)(xy[p].a));
                        }
                    }
                    else
                    {
                        for (int p = 0; p < xy.Count; p++)
                        {
                            if (MthSelected.Contains(xy[p].b))
                            {
                                xcoor.Add(months[xy[p].b]);
                                ycoor.Add((int)(xy[p].a));
                            }
                        }
                    }
                    string yearseries = i.ToString();
                    Chart1.Series.Add(yearseries);

                    //More Chart properties
                    Chart1.Series[yearseries].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    Chart1.Series[yearseries].Points.DataBindXY(xcoor, ycoor);
                    Chart1.Series[yearseries].IsVisibleInLegend = true;
                    Chart1.Series[yearseries].IsValueShownAsLabel = true;
                    Chart1.Series[yearseries].BorderWidth = 1;
                    Chart1.Series[yearseries].ToolTip = "Quantity Ordered: #VALY";
                    Chart1.Series[yearseries].Font = new System.Drawing.Font("Arial", 12);
                    Chart1.Series[yearseries]["LabelStyle"] = "Top";
                    Chart1.Series[yearseries].LabelBackColor = Color.LightCyan;
                    Chart1.Series[yearseries]["PixelPointWidth"] = "50";
                    Chart1.AlignDataPointsByAxisLabel();
                    Chart1.DataBind();
                }

            }

        }
    }
}