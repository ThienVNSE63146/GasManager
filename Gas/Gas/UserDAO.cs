using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
  
    class UserDAO
    {
        SqlConnection con;
        SqlCommand command;
        SqlDataReader reader;
        string connectionString = "Data Source=ThienVNSE63146\\SQLExpress;Initial Catalog=Gas;User ID=sa;Password=12";
        public void CloseConnection()
        {
            if (reader != null) reader.Close();
            if (con != null) con.Close();
        }
        public DataTable LoadUser()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Tên");
            table.Columns.Add("Địa Chỉ");
            table.Columns.Add("SĐT");
            using(con=new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name,address,phone from Customer where stt=1", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string address = reader.GetString(2);
                    string phone = reader.GetString(3);
                    row["Id"] = id;
                    row["Tên"] = name;
                    row["Địa Chỉ"] = address;
                    row["SĐT"] = phone;
                    table.Rows.Add(row);
                }
               
            }
            CloseConnection();
            return table;
        }
        public bool InsertUser(UserDTO dto)
        {
            bool check = false;
            using(con=new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("insert into Customer(name,address,phone,stt) values (@name,@address,@phone,@stt)", con);
                command.Parameters.AddWithValue("@name",dto.Name);
                command.Parameters.AddWithValue("@address",dto.Address);
                command.Parameters.AddWithValue("@phone",dto.Phone);
                command.Parameters.AddWithValue("@stt",1);
                check=command.ExecuteNonQuery()>0;
            }
            CloseConnection();
            return check;
        }
        public bool DeleteUser(string id)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Customer set stt=0 where id=@id", con);
                command.Parameters.AddWithValue("@id", id);
                check=command.ExecuteNonQuery()>0;
            }
            CloseConnection();
            return check;
        }
        public bool UpdateUser(UserDTO dto)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Customer set name=@name,address=@address,phone=@phone where id=@id", con);
                command.Parameters.AddWithValue("@name", dto.Name);
                command.Parameters.AddWithValue("@address", dto.Address);
                command.Parameters.AddWithValue("@phone", dto.Phone);
                command.Parameters.AddWithValue("@id", dto.Id);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public DataTable SearchUser(string userName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Tên");
            table.Columns.Add("Địa Chỉ");
            table.Columns.Add("SĐT");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name,address,phone from Customer where stt=1 and name like @name", con);
                command.Parameters.AddWithValue("@name", "%"+userName+"%");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string address = reader.GetString(2);
                    string phone = reader.GetString(3);
                    row["Id"] = id;
                    row["Tên"] = name;
                    row["Địa Chỉ"] = address;
                    row["SĐT"] = phone;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
    }
}
