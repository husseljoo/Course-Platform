using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera_Web
{
    public partial class InstructorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddTelephone(object sender, EventArgs e)
        {
            Response.Redirect("AddTelephone.aspx");
        }
        protected void AddCourse(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }
        protected void DefineAssignment(object sender, EventArgs e)
        {
            Response.Redirect("DefineAssignment.aspx");
        }
        protected void ViewAssignment(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignment.aspx");
        }
        protected void GradeAssignment(object sender, EventArgs e)
        {
            Response.Redirect("GradeAssignment.aspx");
        }
        protected void ViewFeedback(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }
        protected void IssueCertificate(object sender, EventArgs e)
        {
            Response.Redirect("IssueCertificate.aspx");
        }
    }
}