﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueRadioButton : Control
    {
        private bool _check;
        public bool Checked
        {
            get
            {
                return _check;
            }
            set
            {
                _check = value;
                Invalidate();
            }
        }

        public UniqueRadioButton() : base()
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
            {
                Checked = true;
            }
            foreach (UniqueRadioButton ctrl in
                from ctrl1 in Parent.Controls.OfType<UniqueRadioButton>()
                where ctrl1.Handle != Handle
                where ctrl1.Enabled
                select ctrl1)
            {
                ctrl.Checked = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            g.DrawString(Text, new Font("Verdana", 10F, FontStyle.Regular), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(12, 4, Width, 16), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            Rectangle selectionrect = new Rectangle(3, 3, 17, 17);
            g.DrawEllipse(new Pen(Color.FromArgb(152, 152, 152), 2F), selectionrect);
            if (Checked)
            {
                selectionrect.Inflate(-4, -4);
                g.DrawEllipse(new Pen(Color.FromArgb(182, 182, 182), 2F), selectionrect);
            }
            else
            {
                g.DrawEllipse(new Pen(Color.FromArgb(152, 152, 152)), selectionrect);
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }

}