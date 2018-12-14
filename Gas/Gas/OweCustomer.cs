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
    public partial class OweCustomer : Form
    {
        private string cusId, cusName;
        OweDAO dao = new OweDAO();
        bool addOwe = false;
        public OweCustomer()
        {
            InitializeComponent();
        }

        public string CusId { get => cusId; set => cusId = value; }

        private void OweCustomer_Load(object sender, EventArgs e)
        {
            lblName.Text = cusName;
            dataGridView1.DataSource = dao.LoadOweByCustomerId(cusId);
        }

        private void btnSearch_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable table;
            string name = cusName;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (day.Equals("") && month.Equals("") && year.Equals(""))
            {
                OweCustomer_Load(sender,e);
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithCusName(name, day, month, year);
                dataGridView1.DataSource = table;
            }
        }

        private void txtDay_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = cusName;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (day.Equals("") && month.Equals("") && year.Equals(""))
            {
                OweCustomer_Load(sender, e);
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithCusName(name, day, month, year);
                dataGridView1.DataSource = table;
            }
        }

        private void txtMonth_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = cusName;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (day.Equals("") && month.Equals("") && year.Equals(""))
            {
                OweCustomer_Load(sender, e);
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithCusName(name, day, month, year);
                dataGridView1.DataSource = table;
            }
        }

        private void txtYear_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = cusName;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (day.Equals("") && month.Equals("") && year.Equals(""))
            {
                OweCustomer_Load(sender, e);
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithCusName(name, day, month, year);
                dataGridView1.DataSource = table;
            }
        }

        private void btnAddOwe_Click(object sender, EventArgs e)
        {
            if (!addOwe)
            {
                addOwe owe = new addOwe();
                owe.CustomerId = cusId;
                owe.Show();
                addOwe = true;
                owe.FormClosed += AddOwe_Closed;
            }
        }
        public void AddOwe_Closed(object sender, EventArgs e)
        {
            addOwe = false;
            OweCustomer_Load(sender,e);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (addOwe == false)
            {
                addOwe detail = new addOwe();
                detail.Show();
                addOwe = true;
                detail.FormClosed += AddOwe_Closed;
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                OweDTO dto = dao.ShowDetail(id);
                detail.Dto = dto;
                detail.ShowDetail();
            }
        }

        public string CusName { get => cusName; set => cusName = value; }
    }
}
