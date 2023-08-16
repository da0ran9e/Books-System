using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    internal class GradientPanel : Panel
    {
        public Color GradientPrimaryColor { get; set; }
        public Color GradientSecondaryColor { get; set; }
        public float GradientAngle { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, GradientPrimaryColor, GradientSecondaryColor, GradientAngle);
            e.Graphics.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }

    }
}
