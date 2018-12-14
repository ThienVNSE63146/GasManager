using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class PayDAO
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
        public bool Pay(string oweId)
        {
            bool check = false;
            using (con=new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("update Owe set stt='2' where id=@id",con);
                command.Parameters.AddWithValue("@id",oweId);
                check = command.ExecuteNonQuery() > 0;
            }
            CloseConnection();
            return check;
        }
        public void AddPay(string date, string oweId,string note)
        {
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("insert into Pay (date,owe,note) values (@date,@owe,@note)", con);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@owe", oweId);
                command.Parameters.AddWithValue("@note", note);
                command.ExecuteNonQuery();
            }
            CloseConnection();
            
        }
        public DataTable LoadPay()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày Nợ");
            table.Columns.Add("Ngày Trả");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  p.id,o.date,p.date,c.name,g.name,o.total from Owe o, Gas g,Customer c,Pay p where o.id=p.owe and o.customer=c.id and o.gas=g.id and o.stt='2' order by (id) DESC", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string dateOwe = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string datePay = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(3);
                    string gas = reader.GetString(4);
                    double total = reader.GetDouble(5);
                    row["Id"] = id;
                    row["Ngày Nợ"] = dateOwe;
                    row["Ngày Trả"] = datePay;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchPay(string customerName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày Nợ");
            table.Columns.Add("Ngày Trả");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where o.id=p.owe and o.customer=c.id and o.gas=g.id  and c.name like @name", con);
                command.Parameters.AddWithValue("@name", "%" + customerName + "%");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string dateOwe = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string datePay = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(3);
                    string gas = reader.GetString(4);
                    double total = reader.GetDouble(5);
                    row["Id"] = id;
                    row["Ngày Nợ"] = dateOwe;
                    row["Ngày Trả"] = datePay;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchPayDayMonthYear(string customerName, string day, string month, string year)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày Nợ");
            table.Columns.Add("Ngày Trả");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("if(@day != '' and @month ='' and @year='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and day(p.date)=@day " +
                    "if(@day = '' and @month !='' and @year='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and month(p.date)=@month " +
                    "if(@day = '' and @month ='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and year(p.date)=@year " +
                    "if(@day != '' and @month !='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and year(p.date)=@year and day(p.date)=@day and month(p.date)=@month " +
                    "if(@day != '' and @month !='' and @year ='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and day(p.date)=@day and month(p.date)=@month " +
                    "if(@day != '' and @month ='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and year(p.date)=@year and day(p.date)=@day " +
                    "if(@day != '' and @month !='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and c.name like @name and year(p.date)=@year and month(p.date)=@month ", con);
                command.Parameters.AddWithValue("@name", "%" + customerName + "%");
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@year", year);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string dateOwe = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string datePay = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(3);
                    string gas = reader.GetString(4);
                    double total = reader.GetDouble(5);
                    row["Id"] = id;
                    row["Ngày Nợ"] = dateOwe;
                    row["Ngày Trả"] = datePay;
                    row["Tên Khách Hàng"] = customer;
                    row["Tên Hàng"] = gas;
                    row["Giá"] = total;
                    table.Rows.Add(row);
                }

            }
            CloseConnection();
            return table;
        }
        public DataTable SearchPayDayMonthYearWithoutName(string day, string month, string year)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Ngày Nợ");
            table.Columns.Add("Ngày Trả");
            table.Columns.Add("Tên Khách Hàng");
            table.Columns.Add("Tên Hàng");
            table.Columns.Add("Giá");
            using (con = new SqlConnection(connectionString))
            {
                con.Open();
                command = new SqlCommand("if(@day != '' and @month ='' and @year='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id  and day(p.date)=@day " +
                    "if(@day = '' and @month !='' and @year='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where  p.owe=o.id and o.customer=c.id and o.gas=g.id and month(p.date)=@month " +
                    "if(@day = '' and @month ='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id  and year(p.date)=@year " +
                    "if(@day != '' and @month !='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id   and year(p.date)=@year and day(p.date)=@day and month(p.date)=@month " +
                    "if(@day != '' and @month !='' and @year ='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id  and day(p.date)=@day and month(p.date)=@month " +
                    "if(@day != '' and @month ='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id   and year(p.date)=@year and day(p.date)=@day " +
                    "if(@day != '' and @month !='' and @year !='' )select  p.id,o.date,p.date,c.name,g.name,o.total from Pay p, Owe o, Gas g,Customer c where p.owe=o.id and o.customer=c.id and o.gas=g.id  and year(p.date)=@year and month(p.date)=@month ", con);
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@year", year);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    int id = reader.GetInt32(0);
                    string dateOwe = reader.GetDateTime(1).ToString("dd/MM/yyyy HH:mm:ss");
                    string datePay = reader.GetDateTime(2).ToString("dd/MM/yyyy HH:mm:ss");
                    string customer = reader.GetString(3);
                    string gas = reader.GetString(4);
                    double total = reader.GetDouble(5);
                    row["Id"] = id;
                    row["Ngày Nợ"] = dateOwe;
                    row["Ngày Trả"] = datePay;
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
