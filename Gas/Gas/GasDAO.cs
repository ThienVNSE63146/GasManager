using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class GasDAO
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
        public DataTable LoadGas()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Tên");
            table.Columns.Add("Số Lượng");
            table.Columns.Add("Đơn Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name,quantity,price from Gas", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double quantity = reader.GetDouble(2);
                    double price = reader.GetDouble(3);
                    row["Id"] = id;
                    row["Tên"] = name;
                    row["Số Lượng"] = quantity;
                    row["Đơn Giá"] = price;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public bool InsertGas(GasDTO dto)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("insert into Gas(name,quantity,price) values (@name,@quantity,@price)", con);
                command.Parameters.AddWithValue("@name", dto.Name);
                command.Parameters.AddWithValue("@quantity", dto.Quantity);
                command.Parameters.AddWithValue("@price", dto.Price);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public bool DeleteGas(string id)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Gas set stt=0 where id=@id", con);
                command.Parameters.AddWithValue("@id", id);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public bool UpdateGas(GasDTO dto)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Gas set name=@name,quantity=@quantity,price=@price where id=@id", con);
                command.Parameters.AddWithValue("@name", dto.Name);
                command.Parameters.AddWithValue("@quantity", dto.Quantity);
                command.Parameters.AddWithValue("@price", dto.Price);
                command.Parameters.AddWithValue("@id", dto.Id);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public DataTable SearchGas(string gasName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Tên");
            table.Columns.Add("Số Lượng");
            table.Columns.Add("Đơn Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name,quantity,price from Gas where name like @name", con);
                command.Parameters.AddWithValue("@name", "%"+gasName+"%");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double quantity = reader.GetDouble(2);
                    double price = reader.GetDouble(3);
                    row["Id"] = id;
                    row["Tên"] = name;
                    row["Số Lượng"] = quantity;
                    row["Đơn Giá"] = price;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }

    }
}
