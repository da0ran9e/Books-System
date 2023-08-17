using System;
using WinForms.Drawing.SvgRender;

namespace WinForms.Drawing.SvgRender.SvgElements
{
    public class SvgElementAttribute : Attribute
    {
        public string TargetName { get; private set; }

        public SvgElementAttribute(string strTargetName)
        {
            this.TargetName = strTargetName;
        }
    }
}
