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
    public partial class addOwe : Form
    {
        private string customerId, customerName;
        bool add = true;
        private OweDTO dto;
        List<UserDTO> list;
        List<GasDTO> listGas;
        float quantity;
        float price;
        OweDAO dao = new OweDAO();
        public addOwe()
        {
            InitializeComponent();
        }

        public string CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        internal OweDTO Dto { get => dto; set => dto = value; }

        private void cbbGasName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int index = cbbGasName.SelectedIndex;
           
               
            
            if (txtQuantity.Text.Equals("")||txtQuantity.Text.Equals("0")||float.IsNaN(quantity))
            {
                quantity = 1;
                txtQuantity.Text = quantity.ToString();
            }
            else
            {
                string temp = txtQuantity.Text.Trim();
                quantity = float.Parse(temp);
            }
            txtPrice.Text = listGas[index].Price.ToString();
            price = float.Parse(txtPrice.Text);
            txtTotal.Text = price * quantity + "";
        }

    

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
           
        }
        public bool Check()
        {
            if (cbbCusName.SelectedItem == null)
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cbbGasName.SelectedItem == null)
            {
                MessageBox.Show("Vui Lòng Chọn Mặt Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtTotal.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Điền Vào Tổng Cộng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                if(!txtPrice.Text.Equals(""))
                float.Parse(txtPrice.Text);
            }catch
            {
                MessageBox.Show("Vui Lòng Điền Số Vào Giá Hoặc Bỏ Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                if (!txtQuantity.Text.Equals(""))
                    float.Parse(txtQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Vui Lòng Điền Số Vào Số Lượng Hoặc Bỏ Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            { 
                    float.Parse(txtTotal.Text);
            }
            catch
            {
                MessageBox.Show("Vui Lòng Điền Số Vào Tổng Cộng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(add)
            {
                if (!Check()) return;
                string date = dateTimePicker1.Value.ToString();
                int index = cbbCusName.SelectedIndex;
                string customerId = list[index].Id.ToString();
                string gasId = listGas[cbbGasName.SelectedIndex].Id.ToString();
                string price = txtPrice.Text;
                string quantity = txtQuantity.Text;
                string total = txtTotal.Text;
                string note = txtNote.Text;
                bool check = dao.AddOwe(date, customerId, gasId, price, quantity, total, note);
                if (check)
                {
                    MessageBox.Show("Thêm Nợ Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm Nợ Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                string id = dto.Id;
                DialogResult rs = MessageBox.Show("Xác Nhận Khoản Trả Khoản Nợ Này?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    PayDAO dao1 = new PayDAO();
                    bool check = dao1.Pay(id);
                    if (check)
                    {
                       MessageBox.Show("Trả Nợ Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   else
                    {
                        MessageBox.Show("Trả Nợ Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    dao1.AddPay(DateTime.Now.ToString(), id, txtNote.Text);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addOwe_Load(object sender, EventArgs e)
        {
           list= dao.LoadCustomer();
            listGas = dao.LoadGas();
            foreach (UserDTO dto in list)
            {
                cbbCusName.Items.Add(dto.Name);
            }
            if (customerId != null)
            {
                foreach (UserDTO dto in list)
                {
                    if (dto.Id.ToString().Equals(customerId))
                    {
                        cbbCusName.SelectedItem = dto.Name;
                    }
                }
            }
            foreach (GasDTO item in listGas)
            {
                cbbGasName.Items.Add(item.Name);
            }
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                price = float.Parse(txtPrice.Text);
                quantity = float.Parse(txtQuantity.Text);
                txtTotal.Text = price * quantity + "";
            }
            catch
            {

            }
        }

        private void txtTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPrice.Text.Equals("0") || txtQuantity.Text.Equals("0"))
            {
                return;
            }
            try
            {
                float total = float.Parse(txtTotal.Text);
                price = float.Parse(txtPrice.Text);
                txtQuantity.Text = (total / price).ToString();
            }
            catch
            {

            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                price = float.Parse(txtPrice.Text);
                quantity = float.Parse(txtQuantity.Text);
                txtTotal.Text = price * quantity + "";
            }
            catch
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Check()) return;
            string date = dateTimePicker1.Value.ToString();
            int index = cbbCusName.SelectedIndex;
            string customerId = list[index].Id.ToString();
            string gasId = listGas[cbbGasName.SelectedIndex].Id.ToString();
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            string total = txtTotal.Text;
            string note = txtNote.Text;
            bool check = dao.UpdateOwe(date, customerId, gasId, price, quantity, total, note,dto.Id);
            if (check)
            {
                MessageBox.Show("Sửa Nợ Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sửa Nợ Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Đồng Ý Xóa Khoản Nợ Này?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                bool check = dao.DeleteOwe(dto.Id);
                if (check)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                this.Close();
            }
        }

        public void ShowDetail()
        {
            lbl.Text = "Thông Tin Chi Tiết";
            btnAdd.Text = "Trả"; 
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            add = false;
            dateTimePicker1.Value = DateTime.Parse(dto.Date);
            cbbCusName.SelectedItem = dto.Customer;
            cbbGasName.SelectedItem = dto.Gas;
            txtQuantity.Text = dto.Quantity.ToString();
            txtPrice.Text = dto.Price.ToString();
            txtTotal.Text = dto.Total.ToString();
            txtNote.Text = dto.Note;
        }
    }
}
