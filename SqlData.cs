using MVC_Coding_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Coding_CRUD.SQL_Database
{
    public class SqlData
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F1LI6MI;initial catalog=ASP_DOTNET_CRUD;integrated security=true;");
        SqlCommand cmd;
        public string Query { get; set; }

        public bool EmpInsert(EmployeeClass em)
        {
            Query = "Emp_Insert";
            using (cmd = new SqlCommand(Query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Convert.ToString(em.Name));
                cmd.Parameters.AddWithValue("@Email", Convert.ToString(em.Email));
                cmd.Parameters.AddWithValue("@Designation", Convert.ToString(em.Designation));
                cmd.Parameters.AddWithValue("@Salary", Convert.ToString(em.Salary));
                cmd.Parameters.AddWithValue("@MobileNo", Convert.ToInt64(em.MobileNo));
                cmd.Parameters.AddWithValue("@Address", Convert.ToString(em.Address));
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int res = (int)cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool EmpUpdate(EmployeeClass Ec)
        {
            Query = "Emp_Update";
            using (cmd = new SqlCommand(Query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Ec.Id);
                cmd.Parameters.AddWithValue("@Name",Ec.Name);
                cmd.Parameters.AddWithValue("@Email", Ec.Email);
                cmd.Parameters.AddWithValue("@Designation", Ec.Designation);
                cmd.Parameters.AddWithValue("@Salary", Ec.Salary);
                cmd.Parameters.AddWithValue("@MobileNo", Ec.MobileNo);
                cmd.Parameters.AddWithValue("@Address", Ec.Address);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int res = (int)cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public bool EmpDelete(int Id)
        {
            Query = "Emp_Delete";
            using (cmd = new SqlCommand(Query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int res = (int)cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<EmployeeClass> GetAll()
        {
            List<EmployeeClass> list = new List<EmployeeClass>();
            Query = "Emp_Selectt";
            using (cmd = new SqlCommand(Query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EmployeeClass
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Designation = dr["Designation"].ToString(),
                        Salary = Convert.ToInt32(dr["Salary"]),
                        MobileNo = Convert.ToInt64(dr["MobileNo"]),
                        Address = dr["Address"].ToString()
                    });
                }
                return list;
            }
            
        }
    }
}