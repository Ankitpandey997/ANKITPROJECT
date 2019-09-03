using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace InsertingFormDataUsingWebAPI
{
   
    public partial class Default : System.Web.UI.Page
    {
        string Con = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            
                BindGridviewData();
            

        }
        protected void BindGridviewData()
        {

            using (SqlConnection Con = new SqlConnection(Con).ToString()) ;
            
                using (SqlCommand cmd = new SqlCommand("select * from sampleinfo", Con)) ;
                {
                    Con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    Con.Close();
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                }
            }
        }
        [WebMethod]
        public static string InsertData(string username, string subj, string desc)
        {
            string msg = string.Empty;

            using (SqlConnection Con = new SqlConnection(con)) ;
            {
                using (SqlCommand cmd = new SqlCommand("insert into sampleinfo(name,subject,description) VALUES(@name,@subject,@desc)", Con))
                {
                    Con.Open();
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Parameters.AddWithValue("@subject", subj);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    int i = cmd.ExecuteNonQuery();
                    Con.Close();
                    if (i == 1)
                    {
                        msg = "true";
                    }
                    else
                    {
                        msg = "false";
                    }
                }
            }
            return msg;
        }
    }
}