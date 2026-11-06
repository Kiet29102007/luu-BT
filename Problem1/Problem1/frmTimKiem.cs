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
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }

       
            public bool TheoMa { get; private set; }
            public string DuLieu { get; private set; }

            private void frmTimKiem_Load(object sender, EventArgs e)
            {
                cboTieuChi.DropDownStyle = ComboBoxStyle.DropDownList;
                cboTieuChi.Items.Add("Tìm Kiếm Theo Mã");
                cboTieuChi.Items.Add("Tìm Kiếm Theo Tên");
                cboTieuChi.SelectedIndex = 0;
            }

            private void btnTimKiem_Click(object sender, EventArgs e)
            {
                if (txtDuLieu.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDuLieu.Focus();
                    return;
                }
                TheoMa = (cboTieuChi.SelectedIndex == 0);
                DuLieu = txtDuLieu.Text;
                this.DialogResult = DialogResult.OK;   // tự đóng form
            }
        }
    }
