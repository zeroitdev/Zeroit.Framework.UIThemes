// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="BasicButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Professional
{
    public class ProBasicButton : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            DrawingHelper dh = new DrawingHelper();
            int slope = Adjustments.Roundness;

            Rectangle mainRect = new Rectangle(2, 0, Width - 5, Height - 1);
            GraphicsPath mainPath = dh.RoundRect(mainRect, slope);
            LinearGradientBrush backLGB = null;
            if (_scheme == ColorScheme.Orange)
            {
                backLGB = new LinearGradientBrush(mainRect, Color.FromArgb(255, 120, 0), Color.FromArgb(200, 50, 0), 90.0F);
            }
            else
            {
                ColorBlend backCB = new ColorBlend(3);
                backCB.Colors = new[] { Color.WhiteSmoke, Color.WhiteSmoke, Color.FromArgb(225, 230, 230) };
                backCB.Positions = new[] { 0.0f, 0.75f, 1.0f };
                backLGB = new LinearGradientBrush(mainRect, Color.Black, Color.Black, 90.0F);
                backLGB.InterpolationColors = backCB;
            }
            g.FillPath(backLGB, mainPath);

            if (_scheme == ColorScheme.Orange)
            {
                if (state == MouseState.Over)
                {
                    g.FillPath(new SolidBrush(Color.FromArgb(18, Color.White)), mainPath);
                }
                else if (state == MouseState.Down)
                {
                    g.FillPath(new SolidBrush(Color.FromArgb(30, Color.White)), mainPath);
                }
            }
            else
            {
                if (state == MouseState.Over)
                {
                    g.FillPath(new SolidBrush(Color.FromArgb(10, Color.Black)), mainPath);
                }
                else if (state == MouseState.Down)
                {
                    g.FillPath(new SolidBrush(Color.FromArgb(18, Color.Black)), mainPath);
                }
            }

            int textX = 0;
            int textY = 0;
            if (_image != null)
            {
                int bufferWidth = 4;
                Size imageSize = new Size(Height - 20, Height - 20);
                Point imageLocation = new Point();
                Rectangle imageRect = new Rectangle();
                if (_alignment == HorizontalAlignment.Left)
                {
                    imageRect = new Rectangle(new Point(14, 10), imageSize);
                    textX = imageRect.X + imageSize.Width + bufferWidth;
                }
                else if (_alignment == HorizontalAlignment.Center)
                {
                    imageLocation = new Point((int)((Width / 2) - (imageSize.Width / 2.0) - (bufferWidth / 2.0) - (g.MeasureString(Text, Font).Width / 2.0)), (int)((Height / 2) - (imageSize.Height / 2.0)));
                    imageRect = new Rectangle(imageLocation, imageSize);
                    textX = imageLocation.X + imageSize.Width + bufferWidth;
                }
                else if (_alignment == HorizontalAlignment.Right)
                {
                    textX = (int)(Width - 14 - g.MeasureString(Text, Font).Width);
                    imageRect = new Rectangle(new Point(textX - bufferWidth - imageSize.Width, 10), imageSize);
                }
                g.DrawImage(_image, imageRect);
            }
            else
            {
                if (_alignment == HorizontalAlignment.Left)
                {
                    textX = 14;
                }
                else if (_alignment == HorizontalAlignment.Center)
                {
                    textX = (int)((this.Width / 2.0) - (g.MeasureString(Text, Font).Width / 2.0));
                }
                else if (_alignment == HorizontalAlignment.Right)
                {
                    textX = (int)(Width - g.MeasureString(Text, Font).Width - 14);
                }
            }
            textY = (int)((this.Height / 2.0) - (g.MeasureString(Text, Font).Height / 2.0) + 1);

            LinearGradientBrush borderLGB = null;
            if (_scheme == ColorScheme.Orange)
            {
                g.DrawString(Text, Font, Brushes.WhiteSmoke, new Point(textX, textY));
                borderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(180, 60, 0), Color.FromArgb(220, 120, 60), 90.0F);
            }
            else
            {
                g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(50, 50, 50)), new Point(textX, textY));
                borderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.Silver, Color.Gainsboro, 90.0F);
            }

            g.DrawPath(new Pen(borderLGB), mainPath);

        }

        public ProBasicButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Font = new Font(Adjustments.DefaultFontFamily, 10);
            Size = new Size(140, 50);
            Cursor = Cursors.Hand;
        }

        private Image _image;
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        private HorizontalAlignment _alignment = HorizontalAlignment.Center;
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
                Invalidate();
            }
        }

        public enum ColorScheme
        {
            White,
            Orange
        }

        private ColorScheme _scheme = ColorScheme.White;
        public ColorScheme Scheme
        {
            get
            {
                return _scheme;
            }
            set
            {
                _scheme = value;
                Invalidate();
            }
        }

        public enum MouseState
        {
            None,
            Over,
            Down
        }

        private MouseState state = MouseState.None;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            state = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            state = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            state = MouseState.Over;
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

    }
}
