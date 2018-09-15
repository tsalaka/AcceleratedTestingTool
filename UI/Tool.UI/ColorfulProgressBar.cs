using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kronos.AcceleratedTool.UI
{
    public class ColorfulProgressBar : ProgressBar
    {
        public ColorfulProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetDefaultStyle();
        }

        public void SetDefaultStyle()
        {
            ForeColor = Color.LimeGreen;
            BackColor = Color.DarkGreen;
        }

        public void SetErrorStyle()
        {
            ForeColor = Color.Red;
            BackColor = Color.DarkRed;
        }

        public void SetWarningStyle()
        {
            ForeColor = Color.Gold;
            BackColor = Color.Yellow;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, Width, Height);
            double scaleFactor = ((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum);

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)((rec.Width * scaleFactor) - 4);
            rec.Height -= 4;
            brush = new LinearGradientBrush(rec, ForeColor, BackColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}
