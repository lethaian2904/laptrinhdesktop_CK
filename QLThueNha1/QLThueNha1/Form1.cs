using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueNha1
{
    public partial class frmThongTinNha : Form
    {
        public frmThongTinNha()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnThem.Click += new EventHandler(Them);
            btnSua.Click += new EventHandler(Sua);
            btnXoa.Click += new EventHandler(Xoa);
            btnLamMoi.Click += new EventHandler(LamMoi);
            btnThoat.Click += new EventHandler(Thoat);
        }

        private void Thoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            txtMaNha.Clear();
            txtMaNha.Focus();
            txtTenChuNha.Clear();
            txtGiaThue.Clear();
            if (rdDaThue.Checked == false)
                rdDaThue.Checked = true;
            Load_NHA();
            
        }

        private void Xoa(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                int ma;

                // Kiểm tra và chuyển đổi giá trị cột đầu tiên thành số nguyên
                if (int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out ma))
                {
                    // Nếu chuyển đổi thành công, thực hiện câu lệnh xóa
                    string sql = string.Format("Delete from NHA where MaNha = {0}", ma);
                    Data_Provider.updateData(sql);
                    Load_NHA();
                }
                else
                {
                    // Nếu không thể chuyển đổi, hiển thị thông báo lỗi
                    MessageBox.Show("Giá trị Mã Nhà không hợp lệ. Không thể xóa bản ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Data_Provider.dongKetNoi();
        }

        private void Sua(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql1 = string.Format("Select count(*) from NHA where MaNha ='{0}'", txtMaNha.Text);
            int count = Data_Provider.checkData(sql1);
            if (count > 0)
            {
                MessageBox.Show("Mã nhà đã tồn tại.Vui lòng nhập mã khác!");
            }
            else
            {
                if (isNumber(txtGiaThue.Text) && !string.IsNullOrEmpty(txtTenChuNha.Text))
                {

                    string sql = "insert into NHA(MaNha,TenChuNha,GiaThue,DaCHoThue)" +
                        "values(@maNha,@tenchunha,@giathue,@dachothue)";
                    bool dachothue = rdDaThue.Checked == true ? true : false;
                    object[] value = { txtMaNha.Text, txtTenChuNha.Text, txtGiaThue.Text, dachothue };
                    string[] name = { "@maNha", "@tenchunha", "@giathue", "@dachothue" };

                    Data_Provider.updateData(sql, value, name);
                    Load_NHA();
                }
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");
            }
            Data_Provider.dongKetNoi();
        }

        #region
        public bool isNumber(string value)
        {
            bool ktra;
            float result;
            ktra = float.TryParse(value, out result);
            return ktra;
        }
        #endregion
        private void Them(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql1 = string.Format("Select count(*) from NHA where MaNha ='{0}'", txtMaNha.Text);
            int count = Data_Provider.checkData(sql1);
            if (count > 0)
            {
                MessageBox.Show("Mã nhà đã tồn tại.Vui lòng nhập mã khác!");
            }
            else
            {
                if (isNumber(txtGiaThue.Text) && !string.IsNullOrEmpty(txtTenChuNha.Text))
                {

                    string sql = "insert into NHA(MaNha,TenChuNha,GiaThue,DaCHoThue)" +
                        "values(@maNha,@tenchunha,@giathue,@dachothue)";
                    bool dachothue = rdDaThue.Checked == true ? true : false;
                    object[] value = { txtMaNha.Text, txtTenChuNha.Text, txtGiaThue.Text, dachothue };
                    string[] name = { "@maNha", "@tenchunha", "@giathue", "@dachothue" };

                    Data_Provider.updateData(sql, value, name);
                    Load_NHA();
                }
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");
            }
            Data_Provider.dongKetNoi();
        }

        #region Lấy dữ liệu

        public void Load_NHA()
        {
            string sql = "select * from NHA";
            dataGridView1.DataSource = Data_Provider.GetDataTable(sql);
        }

        #endregion
        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            Load_NHA();
            Data_Provider.dongKetNoi();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            txtMaNha.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenChuNha.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtGiaThue.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            string dachothue = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (dachothue == "True")
                rdDaThue.Checked = true;
            else
                rdChuaThue.Checked = true;
        }
    }
}
