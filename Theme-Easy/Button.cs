// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
    public class EasyButton : Control
    {
        private bool isHover;
        private string _ButtonText;
        private Image _Image;
        private Size _ImageSize;

        public EasyButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHover = false;
            Invalidate();
        }

        [Category("Appearance")]
        public override string Text
        {
            get
            {
                return _ButtonText;
            }
            set
            {
                _ButtonText = value;
            }
        }

        [Category("Appearance")]
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }

        [Category("Appearance")]
        public Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
            set
            {
                _ImageSize = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            SizeF s = g.MeasureString(_ButtonText, Font);
            int x = ClientSize.Width;
            int y = ClientSize.Height;

            g.FillRectangle(new SolidBrush(Color.FromArgb(120, 0, 0, 0)), new Rectangle(0, Convert.ToInt32(y / 2.0), x - 1, y - 1));
            g.FillRectangle(new SolidBrush(Color.FromArgb(80, 0, 0, 0)), new Rectangle(0, 0, x - 1, Convert.ToInt32(y / 2.0)));

            if (Text == null)
            {
                _ButtonText = Name;
            }

            g.DrawString(_ButtonText, Font, new SolidBrush(Color.White), (float)((x - s.Width) / 2.0), (float)((y - s.Height) / 2.0));

            if (_Image != null)
            {
                int imgX = _ImageSize.Width;
                int imgY = _ImageSize.Height;

                if (_ImageSize.IsEmpty)
                {
                    g.DrawImage(_Image, new Rectangle(5, Convert.ToInt32((y - imgY) / 2.0), 16, 16));
                }
                else
                {
                    g.DrawImage(_Image, new Rectangle(5, Convert.ToInt32((y - imgY) / 2.0), imgX, imgY));
                }
            }

            if (isHover)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), new Rectangle(0, 0, x, y));
            }

            g.Dispose();
        }
    }
}
