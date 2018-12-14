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
    public partial class Gas : Form
    {
        GasDAO dao = new GasDAO();
        bool addNew = false;
        public Gas()
        {
            InitializeComponent();
        }

        private void Gas_Load(object sender, EventArgs e)
        {

            DataTable table = dao.LoadGas();
            dataGridView1.DataSource = table;
            idTextBox.Enabled = false;
        }

        private void addressLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew = true;
            idTextBox.Text = "";
            nameTextBox.Text = "";
            quantityTexbox.Text = "";
            priceTexbox.Text = "";
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public bool Check()
        {
            if (nameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Điền Tên Mặt Hàng");
                return false;
            }
            if (quantityTexbox.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Điền Số Lượng Nhập Hàng");
                return false;
            }
            if (priceTexbox.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Điền Đơn Giá Hàng");
                return false;
            }
            return true;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            if (!addNew) return;
            string name = nameTextBox.Text;
            string quantity =quantityTexbox.Text;
            string price = priceTexbox.Text;
            GasDTO dto = new GasDTO(name, float.Parse(quantity), float.Parse(price));
            bool check = dao.InsertGas(dto);
            if (check)
            {
                MessageBox.Show("Thêm  Hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm  Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            addNew = false;
            Gas_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!idTextBox.Text.Equals(""))
            {
                DialogResult rs = MessageBox.Show("Bạn Có Muốn Xóa " + nameTextBox.Text + " ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    bool check = dao.DeleteGas(idTextBox.Text);
                    if (check) MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                Gas_Load(sender, e);
            }
            addNew = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            if (idTextBox.Text.Equals("")) return;
            string id = idTextBox.Text;
            string name = nameTextBox.Text;
            string quantity = quantityTexbox.Text;
            string price = priceTexbox.Text;
            GasDTO dto = new GasDTO(int.Parse(id), name, float.Parse(quantity),float.Parse(price));
            bool check = dao.UpdateGas(dto);
            if (check) MessageBox.Show("Sửa  Hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Sửa  Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            addNew = false;
            Gas_Load(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searhValue = txtSearch.Text;
            DataTable table = dao.SearchGas(searhValue);
            dataGridView1.DataSource = table;
            addNew = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                idTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                quantityTexbox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                priceTexbox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string searhValue = txtSearch.Text;
            DataTable table = dao.SearchGas(searhValue);
            dataGridView1.DataSource = table;
            addNew = false;
        }
    }
}
