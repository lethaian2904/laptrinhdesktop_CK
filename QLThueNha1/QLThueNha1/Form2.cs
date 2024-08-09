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
    public partial class frmQLHopDong : Form
    {
        public frmQLHopDong()
        {
            InitializeComponent();
            Load += new EventHandler(Load_HopDong);
        }

        private void Load_HopDong(object sender, EventArgs e)
        {
            string sql = @"Select C.SoHD, A.TenChuNha, B.TenKhach, C.NgayBatDau, C.NgayKetThuc, (DATEDIFF(MONTH, C.NgayBatDau, C.NgayKetThuc) *A.GiaThue) as ThanhTien
                        from NHA as A, KHACHTHUENHA as B, HOPDONG as C 
                        where A.MaNha=C.MaNha and B.MaKhach=C.MaKhach";
            Data_Provider.moKetNoi();
            dataGridView1.DataSource = Data_Provider.GetDataTable(sql);
            lblThanhTien.Text = "Hợp đồng có giá cao nhất: " + string.Format("{0:0,0vnđ}", thanhTienMax());
        }

        private object thanhTienMax()
        {
            float max = 0;
            float thanhtien = 0;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                thanhtien = float.Parse(row[5].ToString());
                if (thanhtien > max)
                    max = thanhtien;
            }
            return max;
        }
    }
}
