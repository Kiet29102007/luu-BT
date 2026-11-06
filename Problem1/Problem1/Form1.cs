using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem1
{
    public partial class Quan : Form
    {
        public Quan()
        {
            InitializeComponent();
        }

        private void LamMoi()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtHeSoLuong.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cboPhongBan.SelectedIndex = 0;
            txtMaNV.ReadOnly = false;
            txtMaNV.Focus();
        }

        private bool KiemTraDuLieu()
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Tên Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }
            if (txtHeSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Hệ số lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeSoLuong.Focus();
                return false;
            }
            double hs;
            if (!double.TryParse(txtHeSoLuong.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out hs) &&
                !double.TryParse(txtHeSoLuong.Text.Trim(), out hs))
            {
                MessageBox.Show("Hệ số lương phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeSoLuong.Focus();
                return false;
            }
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboPhongBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool TrungMa(string ma)
        {
            foreach (ListViewItem it in listView1.Items)
                if (it.SubItems[0].Text.Equals(ma, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private double LayHeSo(ListViewItem it)
        {
            double v;
            double.TryParse(it.SubItems[4].Text, out v);
            return v;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string ma = txtMaNV.Text.Trim();
            if (TrungMa(ma))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }

            ListViewItem item = new ListViewItem(ma);                       // cột 0: Mã NV
            item.SubItems.Add(txtTenNV.Text.Trim());                         // cột 1: Họ tên
            item.SubItems.Add(dtpNgaySinh.Value.ToString("dd/MM/yyyy"));     // cột 2: Ngày sinh
            item.SubItems.Add(radNam.Checked ? "Nam" : "Nữ");                // cột 3: Giới tính
            item.SubItems.Add(txtHeSoLuong.Text.Trim());                     // cột 4: Hệ số lương
            item.SubItems.Add(cboPhongBan.Text);                             // cột 5: Phòng ban
            listView1.Items.Add(item);

            LamMoi();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListViewItem it = listView1.SelectedItems[0];
            txtMaNV.Text = it.SubItems[0].Text;
            txtTenNV.Text = it.SubItems[1].Text;
            dtpNgaySinh.Value = DateTime.ParseExact(it.SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (it.SubItems[3].Text == "Nam") radNam.Checked = true; else radNu.Checked = true;
            txtHeSoLuong.Text = it.SubItems[4].Text;
            cboPhongBan.Text = it.SubItems[5].Text;

            txtMaNV.ReadOnly = true;   // không cho sửa mã
        }

        // ---------- XÓA ----------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                LamMoi();
            }
        }

        // ---------- SỬA ----------
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraDuLieu()) return;

            ListViewItem it = listView1.SelectedItems[0];
            // cột 0 (mã) giữ nguyên
            it.SubItems[1].Text = txtTenNV.Text.Trim();
            it.SubItems[2].Text = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            it.SubItems[3].Text = radNam.Checked ? "Nam" : "Nữ";
            it.SubItems[4].Text = txtHeSoLuong.Text.Trim();
            it.SubItems[5].Text = cboPhongBan.Text;

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoi();
        }

        // ---------- TÌM KIẾM ----------
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem f = new frmTimKiem();
            if (f.ShowDialog() != DialogResult.OK) return;

            // bỏ màu cũ
            foreach (ListViewItem it in listView1.Items)
            {
                it.BackColor = Color.White;
                it.ForeColor = Color.Black;
            }

            int soKetQua = 0;
            string key = f.DuLieu.Trim();

            foreach (ListViewItem it in listView1.Items)
            {
                bool khop;
                if (f.TheoMa)
                    khop = it.SubItems[0].Text.Equals(key, StringComparison.OrdinalIgnoreCase);
                else
                    khop = it.SubItems[1].Text.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0;

                if (khop)
                {
                    it.BackColor = Color.Red;      // tô đỏ cả dòng
                    it.ForeColor = Color.White;
                    soKetQua++;
                }
            }

            if (soKetQua == 0)
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------- SẮP XẾP THEO HỆ SỐ LƯƠNG ----------
        private void btnSapXep_Click(object sender, EventArgs e)
        {
            frmSapXep f = new frmSapXep();
            if (f.ShowDialog() != DialogResult.OK) return;

            var ds = listView1.Items.Cast<ListViewItem>().ToList();
            var daSapXep = f.TangDan
                ? ds.OrderBy(x => LayHeSo(x)).ToList()
                : ds.OrderByDescending(x => LayHeSo(x)).ToList();

            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (ListViewItem it in daSapXep)
                listView1.Items.Add(it);
            listView1.EndUpdate();
        }

        // ---------- THOÁT ----------
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
