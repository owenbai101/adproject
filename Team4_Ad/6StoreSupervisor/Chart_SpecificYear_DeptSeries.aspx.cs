using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Globalization;
namespace Team4_Ad
{
    public partial class Chart_Month : System.Web.UI.Page
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
        // Get selected year value
        static int selectedyear;
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { selectedyear = Int32.Parse(SelectedYear.SelectedItem.Text);}
            catch { selectedyear = DateTime.Now.Year; }
            
        }
        
        protected void CreateTable(object sender, EventArgs e)
        {
            
            using (LastADEntities b = new LastADEntities())
            {
                string selecteditemcat = DropDownList1.SelectedValue;
                int NumOfDepts = 0;
                ArrayList DeptSelected = new ArrayList();
                List<int> MthSelected = new List<int>();
                string[] months = new string[13] {"", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
                // Get departments selected
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
                // Get Months selected
                for (int j = 0; j < CheckBoxList2.Items.Count; j++)
                {
                    if (CheckBoxList2.Items[j].Selected)
                    {
                        MthSelected.Add(Int32.Parse(CheckBoxList2.Items[j].Value));
                        
                    }
                }
                //Chart properties

                Chart1.ChartAreas.Add("ChartArea2");
                Chart1.ChartAreas[0].AxisX.Title = "Year "+selectedyear.ToString();
                Chart1.ChartAreas[0].AxisY.Title = "Quantity Ordered";
                Chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                Chart1.Legends.Add("QuantityOrdered");
                Title title = new Title();
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                title.Text = "Month Breakdown of Quantity Ordered from " + selecteditemcat + " Category in Year "+selectedyear;
                
                Chart1.Titles.Add(title);
                
                //Getting datapoints according to what users selected
                foreach (string ddept in DeptSelected)
                {

                    var xy = b.Transactions.Where(p => p.ItemList.ItemCategory.CategoryName.Contains(selecteditemcat)
                        && p.EntryDate.Value.Year == selectedyear)

                        .Join(b.Requisitions, m => m.Requid, f => f.RequId,
                        (m, f) => new { Requid = m.Requid, EmployeeId = f.EmployeeId, m.EntryDate, m.Quantity })

                    .Join(b.Employees.Where(p => p.DepartmentCode.Equals(ddept)), q => q.EmployeeId, p => p.UserId,
                    (q, p) => new { q.EntryDate, p.DepartmentCode, q.Quantity })

                    .GroupBy(n => n.EntryDate.Value.Month)
                    .Select(g => new { b = g.Key, a = g.Sum(a => a.Quantity) }).ToList();

                    List<string> xcoor = new List<string>();
                    List<int> ycoor = new List<int>();
                    //converting datapoints into coordinates
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
                    string deptstring = ddept.ToString();
                    Chart1.Series.Add(deptstring);

                    //More chart properties
                    Chart1.Series[deptstring].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    Chart1.Series[deptstring].Points.DataBindXY(xcoor, ycoor);
                    Chart1.Series[deptstring].IsVisibleInLegend = true;
                    Chart1.Series[deptstring].IsValueShownAsLabel = true;
                    Chart1.Series[deptstring].BorderWidth = 1;
                    Chart1.Series[deptstring].ToolTip = "Quantity Ordered: #VALY";
                    Chart1.Series[deptstring].Font = new System.Drawing.Font("Arial", 12);
                    Chart1.Series[deptstring]["LabelStyle"] = "Top";
                    Chart1.Series[deptstring].LabelBackColor = Color.LightCyan;
                    
                    
                    Chart1.Series[deptstring]["PixelPointWidth"] = "50";
                    Chart1.AlignDataPointsByAxisLabel();
                    Chart1.DataBind();
                }

            }
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Chart1_Customize(object sender, EventArgs e)
        {
        }
    }
}