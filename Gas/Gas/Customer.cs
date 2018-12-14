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
    public partial class Customer : Form
    {
        UserDAO dao = new UserDAO();
        bool addNew = false;
        bool viewOwe = false;
        bool  viewPay = false;
        public Customer()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gasDataSet);

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            UserDAO dao = new UserDAO();
            DataTable table = dao.LoadUser();
            dataGridView1.DataSource = table;
            idTextBox.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                idTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                addressTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                phoneTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            } catch(Exception ex)
            {

            }
            addNew = false;
           }
        public bool Check()
        {
            if (nameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Điền Tên Khách Hàng");
                return false;
            }
            return true;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            if (!addNew) return;
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneTextBox.Text;
            UserDTO dto = new UserDTO(name, address, phone);
            bool check = dao.InsertUser(dto);
            if (check)
            {
                MessageBox.Show("Thêm Khách Hàng Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm Khách Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            addNew = false;
            Customer_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!idTextBox.Text.Equals(""))
            {
                DialogResult rs = MessageBox.Show("Bạn Có Muốn Xóa " + nameTextBox.Text + " ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    bool check = dao.DeleteUser(idTextBox.Text);
                    if (check) MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                Customer_Load(sender, e);
            }
            addNew = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew = true;
            idTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            phoneTextBox.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            if (idTextBox.Text.Equals("")) return;
            string id = idTextBox.Text;
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string phone = phoneTextBox.Text;
            UserDTO dto = new UserDTO(int.Parse(id), name, address, phone);
            bool check = dao.UpdateUser(dto);
            if (check) MessageBox.Show("Sửa Khách Hàng Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else MessageBox.Show("Sửa Khách Hàng Thất Bại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            addNew = false;
            Customer_Load(sender, e);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string searhValue = txtSearch.Text;
            DataTable table = dao.SearchUser(searhValue);
            dataGridView1.DataSource = table;
            addNew = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searhValue = txtSearch.Text;
            DataTable table = dao.SearchUser(searhValue);
            dataGridView1.DataSource = table;
            addNew = false;
        }

        private void btnOwe_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text.Equals(""))
            {
                MessageBox.Show("Trước Tiên Vui Lòng Nhấn Vào Khách Hàng Bạn Muốn Chọn","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                if (!viewOwe)
                {
                    OweCustomer owe = new OweCustomer();
                    viewOwe = true;
                    owe.FormClosed += Owe_Closed;
                    owe.CusId = idTextBox.Text;
                    owe.CusName = nameTextBox.Text;
                    owe.Show();
                }
            }
        }
        public void Owe_Closed(object sender,EventArgs e)
        {
            viewOwe = false;
        }
    }
}
