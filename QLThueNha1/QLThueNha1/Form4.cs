using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueNha1
{
    public partial class frmQLKhachThueNha : Form
    {
        public frmQLKhachThueNha()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnThem.Click += new EventHandler(Them);
            btnSua.Click += new EventHandler(Sua);
            btnXoa.Click += new EventHandler(Xoa);
            btnLamMoi.Click += new EventHandler(LamMoi);
            btnThoat.Click += new EventHandler(Thoat);
            btnTimKTN.Click += new EventHandler(TimKiem);
        }

        private void TimKiem(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql = string.Format("Select * from KHACHTHUENHA where TenKhach Like N'%{0}'", txtTenKhach.Text);
            dataGridView1.DataSource = Data_Provider.GetDataTable(sql);
            Data_Provider.dongKetNoi();

        }

        private void Thoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            txtMaKhach.Clear();
            txtMaKhach.Focus();
            txtTenKhach.Clear();
            if (rdNam.Checked == false)
                rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            load_KTN();
        }

        private void Xoa(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sua(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Them(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql1 = string.Format("Select count(*) from KHACHTHUENHA where MaKhach ='{0}'", txtMaKhach.Text);
            int count = Data_Provider.checkData(sql1);
            if (count > 0)
            {
                MessageBox.Show("Mã Khách đã tồn tại.Vui lòng nhập mã khác!");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTenKhach.Text))
                {

                    string sql = "insert into KHACHTHUENHA(MaKhach,TenKhach,NgaySinh,GioiTinh)" +
                        "values(@maKhach,@tenkhach,@ngaySinh,@gioiTinh)";
                    bool GioiTinh = rdNam.Checked == true ? true : false;
                    object[] value = { txtMaKhach.Text, txtTenKhach.Text, dtpNgaySinh.Value, GioiTinh };
                    string[] name = { "@maKhach", "@tenKhach", "@ngaySinh", "@gioiTinh" };

                    Data_Provider.updateData(sql, value, name);
                    load_KTN();
                }
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");
            }
            Data_Provider.dongKetNoi();
        }

        #region
        public void load_KTN()
        {
            string sql = "select * from KHACHTHUENHA";
            dataGridView1.DataSource = Data_Provider.GetDataTable(sql);
        }
        #endregion
        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            load_KTN();
            Data_Provider.dongKetNoi();
        }
    }
}
