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
    public partial class Certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void View(object sender, EventArgs e)
        {
            if(txt_cid.Text.Equals(""))
            {
                Response.Write("Please enter a course id");
                return;
            }


            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("viewCertificate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cid", Int32.Parse(txt_cid.Text)));
            cmd.Parameters.Add(new SqlParameter("@sid",Int32.Parse(Session["user"].ToString())));

            conn.Open();
            bool isExist = false;
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                isExist = true;
                string s = "";
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    s += rdr.GetName(i) + ":" + rdr.GetValue(i).ToString() + " ";
                }
                Label l = new Label();
                l.Text = s;
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(l);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
            }
            conn.Close();
            if (!isExist)
                Response.Write("No certificate available");
        }
    }
}