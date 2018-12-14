using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class OweDAO
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
        public DataTable LoadOwe()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' order by (id) DESC", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchOwe(string customerName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name", con);
                command.Parameters.AddWithValue("@name", "%"+customerName+"%");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss") ;
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchOweDayMonthYear(string customerName,string day, string month,string year)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("if(@day != '' and @month ='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and day(o.date)=@day " +
                    "if(@day = '' and @month !='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and month(o.date)=@month " +
                    "if(@day = '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and year(o.date)=@year " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and year(o.date)=@year and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month !='' and @year ='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and year(o.date)=@year and day(o.date)=@day " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and year(o.date)=@year and month(o.date)=@month ", con);
                command.Parameters.AddWithValue("@name", "%"+customerName+"%");
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@year", year);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchOweDayMonthYearWithoutName( string day, string month, string year)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("if(@day != '' and @month ='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1'  and day(o.date)=@day " +
                    "if(@day = '' and @month !='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1'  and month(o.date)=@month " +
                    "if(@day = '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1'  and year(o.date)=@year " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1'  and year(o.date)=@year and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month !='' and @year ='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1'  and year(o.date)=@year and day(o.date)=@day " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and year(o.date)=@year and month(o.date)=@month ", con);
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@year", year);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public List<UserDTO> LoadCustomer()
        {
            List<UserDTO> list = new List<UserDTO>();
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name from Customer where stt=1", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    UserDTO dto = new UserDTO(id, name);
                    list.Add(dto);
                }

            }
            CloseConnection();
            return list;
        }
        public List<GasDTO> LoadGas()
        {
            List<GasDTO> list = new List<GasDTO>();
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select id,name,price from Gas", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                   
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    GasDTO dto = new GasDTO(id, name,(float)price);
                    list.Add(dto);
                }
            }
            CloseConnection();
            return list;
        }
        public bool AddOwe(string date,string customer,string gas,string price,string quantity,string total,string note)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("insert into Owe(date,customer,gas,price,quantity,total,stt,note) values (@date,@customer,@gas,@price,@quantity,@total,'1',@note)",con);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@customer", customer);
                command.Parameters.AddWithValue("@gas", gas);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@note", note);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
                return check;
        }
        public bool UpdateOwe(string date, string customer, string gas, string price, string quantity, string total, string note,string id)
        {
            bool check = false;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Owe set date=@date,customer=@customer,gas=@gas,price=@price,quantity=@quantity,total=@total,note=@note where id=@id ", con);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@customer", customer);
                command.Parameters.AddWithValue("@gas", gas);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@note", note);
                command.Parameters.AddWithValue("@id", id);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public OweDTO ShowDetail(string oweId)
        {
            OweDTO dto = null;
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  o.id,o.date,c.name,g.name,o.quantity,o.price,o.total,o.note from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and o.id=@id", con);
                command.Parameters.AddWithValue("@id",oweId);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                   
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString();
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double quantity = reader.GetDouble(4);
                    double price = reader.GetDouble(5);
                    double total = reader.GetDouble(6);
                    string note=(reader.IsDBNull(7)==true)? "" : reader.GetString(7);
                    dto = new OweDTO(id.ToString(), date, customer, gas,  (float)price,(float)quantity, (float)total, note);
                }
            }
            CloseConnection();
            return dto;
        }
        public bool DeleteOwe(string id)
        {
            bool check = false;
            using(con=new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Owe set stt='0' where id=@id",con);
                command.Parameters.AddWithValue("@id",id);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public DataTable LoadOweByCustomerId(string cusId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.id = @id", con);
                command.Parameters.AddWithValue("@id", cusId );
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchOweDayMonthYearWithCusName(string customerName, string day, string month, string year)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("if(@day != '' and @month ='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name like @name and day(o.date)=@day " +
                    "if(@day = '' and @month !='' and @year='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and month(o.date)=@month " +
                    "if(@day = '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and year(o.date)=@year " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and year(o.date)=@year and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month !='' and @year ='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and day(o.date)=@day and month(o.date)=@month " +
                    "if(@day != '' and @month ='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and year(o.date)=@year and day(o.date)=@day " +
                    "if(@day != '' and @month !='' and @year !='' )select  o.id,o.date,c.name,g.name,o.total from Owe o, Gas g,Customer c where o.customer=c.id and o.gas=g.id and o.stt='1' and c.name = @name and year(o.date)=@year and month(o.date)=@month ", con);
                command.Parameters.AddWithValue("@name", customerName );
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@year", year);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string date = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(2);
                    string gas = reader.GetString(3);
                    double total = reader.GetDouble(4);
                    row["Id"] = id;
                    row["Ngày"] = date;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
    }
}
