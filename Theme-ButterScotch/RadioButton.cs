// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchRadioButton : Control
    {
        private bool _check;
        public bool Checked
        {
            get { return _check; }
            set
            {
                _check = value;
                Invalidate();
            }
        }

        public ButterscotchRadioButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(180, 25);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!Checked)
                Checked = true;
            foreach (ButterscotchRadioButton ctrl in Controls) /*from ctrl1 in Parent.Controls.OfType<ButterscotchRadioButton>() where ctrl1.Handle != Handlewhere ctrl1.Enabled)*/
            {
                ctrl.Checked = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle selectionrect = new Rectangle(3, 3, 18, 18);
            Rectangle innerselectionrect = new Rectangle(4, 4, 17, 17);
            Rectangle selectrect = new Rectangle(8, 8, 8, 8);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            g.DrawString(Text, new Font("Segoe UI", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(245, 245, 245)), new Rectangle(25, 4, Width, 16), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            if (Checked)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), selectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(40, 37, 33)), innerselectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(246, 180, 12)), selectrect);
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), selectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(40, 37, 33)), innerselectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(20, 18, 17)), selectrect);
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
