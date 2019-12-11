using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PracticeADO_crud.Models;

namespace PracticeADO_crud.Data_Access_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["crud"].ConnectionString);


        public void AddEmp(Employee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("Sp_AddNewEmployee", con);
                com.CommandType = CommandType.StoredProcedure;

                // Now we are adding the parameters 
                com.Parameters.AddWithValue("@emp_name",employee.emp_name);
                com.Parameters.AddWithValue("@emp_city",employee.emp_city);
                com.Parameters.AddWithValue("@emp_department",employee.emp_department);
                com.Parameters.AddWithValue("@emp_pincode",employee.emp_pincode);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                // check the Connection state is open or not
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        public void UpdateEmp(Employee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("Sp_UpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;

                // Now we are adding the parameters 

                com.Parameters.AddWithValue("@emp_id", employee.emp_id);
                com.Parameters.AddWithValue("@emp_name", employee.emp_name);
                com.Parameters.AddWithValue("@emp_city", employee.emp_city);
                com.Parameters.AddWithValue("@emp_department", employee.emp_department);
                com.Parameters.AddWithValue("@emp_pincode", employee.emp_pincode);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                // check the Connection state is open or not
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataSet ShowEmp_ByID(int id)
        {
            SqlCommand cmd = new SqlCommand("Sp_EmployeeById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", id);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }
    
        public DataSet showAllEmployees()
        {
            SqlCommand cmd = new SqlCommand("Sp_ShowAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public List<Employee> showAllEmployees1()
        {
            SqlCommand cmd = new SqlCommand("Sp_ShowAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            List <Employee> dd = dataSet.Tables[0].AsEnumerable().Select(e =>new Employee
            {
                 emp_city=e.Field<string>("emp_city"),
                  emp_id=e.Field<int>("emp_id"), 
                emp_department=e.Field<string>("emp_department"), 
                emp_name=e.Field<string>("emp_name"),
                   emp_pincode=e.Field<Int64>("emp_pincode").ToString()
            }).ToList();
            return dd;
        }

        public void 
            Delete_emp(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Deletemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

               if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }

}