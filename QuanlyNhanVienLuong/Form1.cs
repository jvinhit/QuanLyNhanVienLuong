using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.XtraBars.Helpers;
using DataAcessLayer;
using BusinessLayer;

namespace QuanlyNhanVienLuong
{
    public partial class Form1 : XtraForm
    {
      
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCSDL load = new LoadCSDL();
            load.Initdata();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbSkins, true);
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new frmDangNhap();
            frm.ShowDialog();
        }
    }
}
