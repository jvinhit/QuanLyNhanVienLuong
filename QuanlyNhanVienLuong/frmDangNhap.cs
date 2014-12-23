using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanlyNhanVienLuong
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtEUser.Text == " " && txtEpass.Text == " ")
            {
                MessageBox.Show("Chưa nhập user & pass","Nhap Lai",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            if ((this.txtEUser.Text == "admin") && (this.txtEpass.Text == "admin"))
            {
                this.Hide();
                Form frm = new Form1();
                frm.ShowDialog();

            }
        }
    }
}
