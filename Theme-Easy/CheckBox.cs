// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyCheckBox : Control
    {
        private bool _Checked;

        public EasyCheckBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(20, 20);
            MaximumSize = Size;
            MinimumSize = Size;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_Checked)
            {
                _Checked = false;
            }
            else if (!_Checked)
            {
                _Checked = true;
            }
            Invalidate();
            base.OnMouseClick(e);
        }

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            int x = ClientSize.Width;
            int y = ClientSize.Height;

            g.FillEllipse(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), new Rectangle(0, 0, x - 1, y - 1));
            g.FillEllipse(new SolidBrush(Color.FromArgb(75, 255, 255, 255)), new Rectangle(3, 3, x - 7, y - 7));

            if (_Checked)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), new RectangleF(5F, 5F, (float)(x / 2.0) - 1, (float)(y / 2.0) - 1));
            }

            g.Dispose();
        }
    }
}
