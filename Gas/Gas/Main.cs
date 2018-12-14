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
    public partial class Main : Form
    {
        Customer customer;
        bool checkCustomer = false;
        bool checkGas = false;
        bool checkOwe = false;
        bool checkPay = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
          
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkCustomer == false)
            {
                customer= new Customer();
                customer.MdiParent = this;
                customer.Show();
                checkCustomer = true;
                customer.FormClosed += customer_Closed;
            }
           
        }
        public void customer_Closed(object sender ,EventArgs e)
        {
            checkCustomer = false;
        }

        private void xăngDầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkGas == false)
            {
                Gas gas= new Gas();
                gas.MdiParent = this;
                gas.Show();
                checkGas = true;
                gas.FormClosed += Gas_Close;
            }
        }
        public void Gas_Close(object sender,EventArgs e)
        {
            checkGas = false;
        }

        private void nợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkOwe == false)
            {
                Owe owe = new Owe();
                owe.MdiParent = this;
                owe.Show();
                checkOwe = true;
                owe.FormClosed += Owe_Close;
            }
        }
        public void Owe_Close(object sender,EventArgs e)
        {
            checkOwe = false;
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkPay)
            {
                Pay pay = new Pay();
                checkPay = true;
                pay.Show();
                pay.FormClosed += Pay_Closed;
            }
        }
        public void Pay_Closed(object sender,EventArgs e)
        {
            checkPay = false;
        }
    }
}
