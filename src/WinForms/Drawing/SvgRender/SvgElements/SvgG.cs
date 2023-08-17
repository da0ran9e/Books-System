using System.Drawing.Drawing2D;
using WinForms.Drawing.SvgRender;

namespace WinForms.Drawing.SvgRender.SvgElements
{
    [SvgElement("g")]
    public class SvgG : SvgElement
    {
        public override string TargetName
        {
            get { return "g"; }
        }
        public override bool AllowElementDraw
        {
            get { return true; }
        }
        protected internal override void OnInitAttribute(string strName, string strValue) { }

        public override GraphicsPath GetPath()
        {
            return null;
        }

        protected internal override void Dispose() { }
    }
}
