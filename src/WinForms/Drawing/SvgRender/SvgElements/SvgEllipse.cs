using System.Drawing.Drawing2D;
using WinForms.Drawing.SvgRender;

namespace WinForms.Drawing.SvgRender.SvgElements
{
    [SvgElement("ellipse")]
    public class SvgEllipse : SvgElement
    {
        public override string TargetName
        {
            get { return "ellipse"; }
        }

        public override bool AllowElementDraw
        {
            get { return true; }
        }

        public float CX { get; set; }
        public float CY { get; set; }
        public float RX { get; set; }
        public float RY { get; set; }

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
                case "rx":
                    RX = SvgAttributes.GetSize(this, "rx");
                    break;
                case "ry":
                    RY = SvgAttributes.GetSize(this, "ry");
                    break;
            }
        }

        public override GraphicsPath GetPath()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(
                SvgAttributes.GetSize(CurrentParent, "x") + CX - RX,
                SvgAttributes.GetSize(CurrentParent, "y") + CY - RY,
                RX * 2,
                RY * 2);
            return gp;
        }

        protected internal override void Dispose() { }
    }
}
