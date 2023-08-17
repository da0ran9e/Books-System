using System.Drawing;
using System.Drawing.Drawing2D;
using WinForms.Drawing.SvgRender;

namespace WinForms.Drawing.SvgRender.SvgElements
{
    [SvgElement("circle")]
    public class SvgCircle : SvgElement
    {
        public override string TargetName
        {
            get { return "circle"; }
        }

        public override bool AllowElementDraw
        {
            get { return true; }
        }

        public float CX { get; set; }
        public float CY { get; set; }
        public float R { get; set; }

        protected internal override void OnInitAttribute(string strName, string strValue)
        {
            switch (strName)
            {
                case "cx":
                    CX = SvgAttributes.GetSize(this, "cx");
                    break;
                case "cy":
                    CY = SvgAttributes.GetSize(this, "cy");
                    break;
                case "r":
                    R = SvgAttributes.GetSize(this, "r");
                    break;
            }
        }

        public override GraphicsPath GetPath()
        {
            GraphicsPath gp = new GraphicsPath();
            RectangleF rectF = new RectangleF(
                SvgAttributes.GetSize(CurrentParent, "x") + CX - R,
                SvgAttributes.GetSize(CurrentParent, "y") + CY - R,
                R * 2,
                R * 2);
            gp.AddEllipse(rectF);
            return gp;
        }

        protected internal override void Dispose() { }
    }
}
