using Lab04_04;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab04
{
    public partial class frmOrderViewer : Form
    {
        public frmOrderViewer()
        {
            InitializeComponent();
        }

        // === LOAD FORM – mặc định ngày hiện tại ===
        private void frmOrderViewer_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpFrom.Value = today;
            dtpTo.Value = today;
            LoadInvoices(today, today);
        }

        // 🔹 Tải danh sách hoá đơn trong khoảng ngày giao hàng
        private void LoadInvoices(DateTime from, DateTime to)
        {
            try
            {
                using (var ctx = new OrderContextDB())
                {
                    // ✅ Tính toán ngày cuối cùng (đến hết ngày) trước khi query
                    var toEndOfDay = to.Date.AddDays(1); // 00:00:00 của ngày hôm sau

                    // ✅ Dùng AsEnumerable() để tránh lỗi LINQ to Entities
                    var invoices = ctx.Invoices
                        .AsEnumerable()
                        .Where(inv => inv.DeliveryDate >= from &&
                                      inv.DeliveryDate < toEndOfDay)
                        .OrderBy(inv => inv.DeliveryDate)
                        .ToList();

                    dgvInvoices.Rows.Clear();
                    foreach (var inv in invoices)
                    {
                        dgvInvoices.Rows.Add(
                            inv.InvoiceNo,
                            inv.OrderDate.ToString("dd/MM/yyyy"),
                            inv.DeliveryDate.ToString("dd/MM/yyyy"),
                            inv.Note ?? "—"
                        );
                    }

                    toolStripStatusLabel1.Text = $"Đã tải {invoices.Count} hoá đơn";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Khi click vào hoá đơn → hiện chi tiết
        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string invoiceNo = dgvInvoices.Rows[e.RowIndex].Cells["colInvoiceNo"].Value?.ToString();
            if (string.IsNullOrEmpty(invoiceNo)) return;

            try
            {
                using (var ctx = new OrderContextDB())
                {
                    var orders = ctx.Orders
                        .Where(o => o.InvoiceNo == invoiceNo)
                        .OrderBy(o => o.No)
                        .ToList();

                    dgvDetails.Rows.Clear();
                    foreach (var o in orders)
                    {
                        dgvDetails.Rows.Add(
                            o.No,
                            o.ProductID,
                            o.ProductName.Trim(),
                            o.Unit,
                            o.Price.ToString("N0"),
                            o.Quantity,
                            (o.Price * o.Quantity).ToString("N0")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Tìm kiếm theo khoảng ngày
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;
            if (from > to)
            {
                MessageBox.Show("⚠️ Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadInvoices(from, to);
        }

        // 🔹 CheckBox "Xem tất cả trong tháng"
        private void chkThisMonth_CheckedChanged(object sender, EventArgs e)
        {
            var now = DateTime.Today;
            var start = new DateTime(now.Year, now.Month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            dtpFrom.Value = start;
            dtpTo.Value = end;

            if (chkThisMonth.Checked)
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                LoadInvoices(start, end);
            }
            else
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                LoadInvoices(dtpFrom.Value.Date, dtpTo.Value.Date);
            }
        }

        // 🌟 SÁNG TẠO #1: Xuất Excel (Clipboard)
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string header = "Số HĐ\tNgày đặt\tNgày giao\tGhi chú\n";
            string data = "";
            foreach (DataGridViewRow r in dgvInvoices.Rows)
            {
                data += $"{r.Cells[0].Value}\t{r.Cells[1].Value}\t{r.Cells[2].Value}\t{r.Cells[3].Value}\n";
            }

            Clipboard.SetText(header + data);
            MessageBox.Show("✅ Đã copy vào clipboard!\nMở Excel → Ctrl+V để dán.", "Xuất thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 🌟 SÁNG TẠO #2: Xem trước in (text căn lề)
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn một hoá đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string invNo = dgvInvoices.SelectedRows[0].Cells["colInvoiceNo"].Value?.ToString();
            if (string.IsNullOrEmpty(invNo)) return;

            using (var ctx = new OrderContextDB())
            {
                var inv = ctx.Invoices
                    .Include("Orders")
                    .FirstOrDefault(i => i.InvoiceNo == invNo);

                if (inv == null) { MessageBox.Show("Không tìm thấy hoá đơn!"); return; }

                string content =
                    "HOÁ ĐƠN BÁN HÀNG".PadLeft(50) + "\n" +
                    $"Số: {inv.InvoiceNo}".PadLeft(50) + "\n" +
                    $"Ngày đặt: {inv.OrderDate:dd/MM/yyyy} | Ngày giao: {inv.DeliveryDate:dd/MM/yyyy}\n" +
                    $"Ghi chú: {inv.Note ?? "—"}\n" +
                    new string('=', 90) + "\n" +
                    $"STT  Mã SP     Tên sản phẩm           ĐVT   SL      Đơn giá       Thành tiền\n" +
                    new string('-', 90) + "\n";

                foreach (var o in inv.Orders.OrderBy(x => x.No))
                {
                    content += $"{o.No,3}  {o.ProductID,-10} {o.ProductName,-25} {o.Unit,-5} {o.Quantity,4}  {o.Price,12:N0}  {o.Price * o.Quantity,12:N0}\n";
                }

                content += new string('-', 90) + "\n";

                var total = inv.Orders.Sum(o => o.Price * o.Quantity);
                content += $"{"TỔNG CỘNG:",70} {total,18:N0} đ";

                var preview = new Form { Text = $"Hoá đơn {invNo}", Size = new System.Drawing.Size(800, 600), StartPosition = FormStartPosition.CenterScreen };
                var rtb = new RichTextBox { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Courier New", 10), ReadOnly = true };
                rtb.Text = content;
                preview.Controls.Add(rtb);
                preview.ShowDialog();
            }
        }

        // 🔹 Tải lại
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Enabled ? dtpFrom.Value.Date : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime to = dtpTo.Enabled ? dtpTo.Value.Date : DateTime.Today;
            LoadInvoices(from, to);
            dgvDetails.Rows.Clear();
        }
    }
}