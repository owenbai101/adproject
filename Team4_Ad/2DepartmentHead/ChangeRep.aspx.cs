﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team4_Ad
{
    public partial class ChangeRep : System.Web.UI.Page
    {
        private void BindGrid()
        {
            if (Session["DpCode"] != null)
            {
                string dpid = Session["DpCode"].ToString();
                LastADEntities entities = new LastADEntities();
                var c = entities.Employees.Where(x => x.DepartmentCode.Equals(dpid)).Join(entities.Roles.Where(p => p.RoleId > 3), m => m.RoleId, f => f.RoleId, (m, f)
                    => new Employeerole { Name = m.Name, RoleDescription = f.RoleDescription, Userid = m.UserId, RoleId = m.RoleId }).ToList();
                GridView1.DataSource = c;
                GridView1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                Employeerole employeerole = (Employeerole)e.Row.DataItem;
                DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
                if (dp != null)
                {
                    LastADEntities entities = new LastADEntities();
                    var c = entities.Roles.Where(q => q.RoleId > 3).ToList();
                    dp.DataSource = c;
                    dp.DataTextField = "RoleDescription";
                    dp.DataValueField = "RoleId";
                    dp.DataBind();
                    dp.SelectedValue = employeerole.RoleId.ToString();

                }
            }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int UserId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int RoleId = Int32.Parse((row.FindControl("DropDownList1") as DropDownList).SelectedValue);
            using (LastADEntities entities = new LastADEntities())
            {
                Employee employee = entities.Employees.Where(p => p.UserId == UserId).First<Employee>();
                employee.RoleId = RoleId;
                entities.SaveChanges();
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }
    }
}