using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GUCera_Web
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void AddTelephone(object sender, EventArgs e)
        {
            Response.Redirect("AddTelephone.aspx");
        }
        protected void ViewAssignments(object sender, EventArgs e)
        {
            Response.Redirect("Assignments.aspx");
        }

        protected void FeedbackCourse(object sender, EventArgs e)
        {
            Response.Redirect("FeedbackCourse.aspx");
        }

        protected void ViewAllCert(object sender, EventArgs e)
        {
            Response.Redirect("Certificates.aspx");
        }
        protected void dispAvailableCourses(object sender, EventArgs e)
        {
            Response.Redirect("AvailableCourses.aspx");

        }
        protected void viewProfileInfo(object sender, EventArgs e)
        {
            Response.Redirect("ProfileInfo.aspx");

        }
        protected void AddCreditCard(object sender, EventArgs e)
        {
            Response.Redirect("AddCreditCard.aspx");

        }
        protected void ViewPromocodes(object sender, EventArgs e)
        {
            Response.Redirect("ViewPromocode.aspx");

        }
    }
}