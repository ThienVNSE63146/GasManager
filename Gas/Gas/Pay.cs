using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas
{
    public partial class Pay : Form
    {
        PayDAO dao = new PayDAO();
        public Pay()
        {
            InitializeComponent();
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dao.LoadPay();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            DataTable table;
            string name = txtName.Text;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (name.Equals("") && day.Equals("") && month.Equals("") && year.Equals(""))
            {
                Pay_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchPay(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchPayDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchPayDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }
    }
}
