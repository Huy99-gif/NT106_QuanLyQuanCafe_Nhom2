using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{

    [SupportedOSPlatform("windows")]
    public partial class MsgBox : Form
    {

        // --- CÁC HÀM DLL ĐỂ LÀM GIAO DIỆN XỊN ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MsgBox()
        {
            InitializeComponent();
            // Bo góc Form 15 pixel cho nó "mượt"
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        // --- HÀM TĨNH (STATIC) ĐỂ GỌI NHANH ---
        public static DialogResult Show(string message, string title = "Notification", MessageBoxType type = MessageBoxType.Info)
        {
            using MsgBox msg = new();
            msg.lblTitle.Text = title;
            msg.lblMessage.Text = message;
            msg.ApplyTypeStyle(type);
            return msg.ShowDialog();
        }

        // Đổi màu Header và Button theo loại thông báo
        private void ApplyTypeStyle(MessageBoxType type)
        {
            Color themeColor;
            switch (type)
            {
                case MessageBoxType.Success:
                    themeColor = Color.FromArgb(40, 167, 69); // Xanh lá
                    break;
                case MessageBoxType.Error:
                    themeColor = Color.FromArgb(220, 53, 69); // Đỏ
                    break;
                case MessageBoxType.Warning:
                    themeColor = Color.FromArgb(255, 193, 7); // Vàng
                    btnOk.ForeColor = Color.Black;
                    break;
                default:
                    themeColor = Color.FromArgb(0, 123, 255); // Xanh dương (Info)
                    break;
            }
            pnlHeader.BackColor = themeColor;
            btnOk.BackColor = themeColor;
        }

        public enum MessageBoxType { Info, Success, Error, Warning }

        // Sự kiện di chuyển Form khi nhấn giữ Header
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            _ = SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        // Sự kiện nút OK
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
