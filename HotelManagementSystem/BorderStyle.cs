using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    internal static class BorderStyle
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public static void ApplyRoundedBorder(Form form, int borderRadius)
        {
            form.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }

        public static void ApplyRoundedBorder(Panel panel, int borderRadius)
        {
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, borderRadius, borderRadius));
        }

        public static void ApplyRoundedBorder(Button button, int borderRadius)
        {
            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, borderRadius, borderRadius));
        }

        public static void ApplyRoundedBorder(PictureBox pictureBox, int borderRadius)
        {
            pictureBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox.Width, pictureBox.Height, borderRadius, borderRadius));
        }

    }
}
