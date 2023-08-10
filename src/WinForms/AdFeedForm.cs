﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AdFeedForm : Form
    {
        public AdFeedForm()
        {
            InitializeComponent();
        }

        private void AdFeedForm_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            AppUtils.EnableAcrylic(this, Color.Transparent);
            base.OnHandleCreated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
        }
    }
}
