using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsertingFormDataUsingWebAPI
{
    public class EmpRepository
    {
        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);


        }

        public string AddEmployees(Employee Emp)
        {
            connection();
            com = new SqlCommand("InsertData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FName", Emp.FirstName);
            com.Parameters.AddWithValue("@Lname", Emp.LastName);
            com.Parameters.AddWithValue("@Compnay", Emp.Company);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "New Employee Added Successfully";

            }
            else
            {
                return "Employee Not Added";

            }
        }
    }
}  

   