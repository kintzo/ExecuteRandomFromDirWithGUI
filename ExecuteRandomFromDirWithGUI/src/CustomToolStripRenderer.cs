using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ExecuteRandomFromDirWithGUI
{
    class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        Color BackGroundColor = Color.FromArgb(37, 37, 37);
        Color TextColor = Color.White;
        Color SelectedItemBackGroundColor = Color.FromArgb(57, 57, 57);

        Font font = new Font("Segoe UI", 9);

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            using (SolidBrush backBrush = new SolidBrush(BackGroundColor))
                e.Graphics.FillRectangle(backBrush, rc);

            e.Item.ForeColor = TextColor;

            if (e.Item.Selected)
            {
                using (SolidBrush backBrush = new SolidBrush(SelectedItemBackGroundColor))
                    e.Graphics.FillRectangle(backBrush, rc);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e) {
            ToolStripSeparator sep = (ToolStripSeparator)e.Item;
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Pen pen = new Pen(SelectedItemBackGroundColor);

            using (SolidBrush backBrush = new SolidBrush(BackGroundColor))
                e.Graphics.FillRectangle(backBrush, rc);

            e.Graphics.DrawLine(pen, 4, sep.Height / 2, sep.Width - 4, sep.Height / 2);
            pen.Dispose();
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)e.Item;
            if (tsMenuItem != null)
                e.ArrowColor = TextColor;
            base.OnRenderArrow(e);
        }
    }
}
