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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnNha_Click(object sender, EventArgs e)
        {
            frmThongTinNha f = new frmThongTinNha();
            f.Show();
        }

        private void btnQLHopDong_Click(object sender, EventArgs e)
        {
            frmQLHopDong f = new frmQLHopDong();
            f.Show();
        }
    }
}
