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
    public partial class Owe : Form
    {
        OweDAO dao = new OweDAO();
        bool addOwe = false;
      
        public Owe()
        {
            InitializeComponent();
        }

        private void Owe_Load(object sender, EventArgs e)
        {
            DataTable table = dao.LoadOwe();
            dataGridView1.DataSource = table;
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
                Owe_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchOwe(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchOweDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addOwe == false)
            {
                addOwe owe = new addOwe();
                addOwe = true;
                owe.Show();
                owe.FormClosed += AddOwe_Close;
            }
            
            
        }
        public void AddOwe_Close(object sender,EventArgs e)
        {
            addOwe = false;
            Owe_Load(sender,e);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (addOwe == false)
            {
                addOwe detail = new addOwe();
                detail.Show();
                addOwe = true;
                detail.FormClosed += AddOwe_Close;
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                OweDTO dto = dao.ShowDetail(id);
                detail.Dto = dto;
                detail.ShowDetail();
            }
          
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = txtName.Text;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (name.Equals("") && day.Equals("") && month.Equals("") && year.Equals(""))
            {
                Owe_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchOwe(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchOweDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }

        private void txtDay_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = txtName.Text;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (name.Equals("") && day.Equals("") && month.Equals("") && year.Equals(""))
            {
                Owe_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchOwe(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchOweDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }

        private void txtMonth_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = txtName.Text;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (name.Equals("") && day.Equals("") && month.Equals("") && year.Equals(""))
            {
                Owe_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchOwe(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchOweDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }

        private void txtYear_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable table;
            string name = txtName.Text;
            string day = txtDay.Text;
            string month = txtMonth.Text;
            string year = txtYear.Text;
            if (name.Equals("") && day.Equals("") && month.Equals("") && year.Equals(""))
            {
                Owe_Load(sender, e);
                return;
            }
            if (!name.Equals(""))
            {
                if (day.Equals("") && month.Equals("") && year.Equals(""))
                {
                    table = dao.SearchOwe(name);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    table = dao.SearchOweDayMonthYear(name, day, month, year);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                table = dao.SearchOweDayMonthYearWithoutName(day, month, year);
                dataGridView1.DataSource = table;
            }

        }
    }
}
