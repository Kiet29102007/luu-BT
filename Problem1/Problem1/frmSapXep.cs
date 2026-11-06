using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem1
{
    public partial class frmSapXep : Form
    {
        public bool TangDan { get; private set; }

        public frmSapXep()
        {
            InitializeComponent();
        }

        private void frmSapXep_Load(object sender, EventArgs e)
        {
            cboKieuSapXep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKieuSapXep.Items.Add("Sắp Xếp Tăng Dần");
            cboKieuSapXep.Items.Add("Sắp Xếp Giảm Dần");
            cboKieuSapXep.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TangDan = (cboKieuSapXep.SelectedIndex == 0);
            this.DialogResult = DialogResult.OK;
        }
    }
}
