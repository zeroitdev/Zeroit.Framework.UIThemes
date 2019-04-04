// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Bonfire
{
    public class BonfireButton : Control
    {
        public enum Style
        {
            Blue,
            Dark,
            Light
        }

        private Style _style;
        public Style ButtonStyle
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                Invalidate();
            }
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

        private bool _rounded;
        public bool RoundedCorners
        {
            get
            {
                return _rounded;
            }
            set
            {
                _rounded = value;
                Invalidate();
            }
        }

        public enum State
        {
            None,
            Over,
            Down
        }

        private State MouseState;

        public BonfireButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            MouseState = State.None;
            Size = new Size(65, 26);
            Font = new Font("Verdana", 8);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            int slope = 3;

            Rectangle shadowRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath shadowPath = Drawing.RoundRect(shadowRect, slope);
            Rectangle mainRect = new Rectangle(0, 0, Width - 2, Height - 2);
            switch (ButtonStyle)
            {
                case Style.Blue:
                    if (_rounded)
                    {
                        G.FillPath(new SolidBrush(Color.FromArgb(20, 135, 195)), shadowPath);
                        G.FillPath(new SolidBrush(Color.FromArgb(20, 160, 230)), Drawing.RoundRect(mainRect, slope));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, 135, 195)), shadowRect);
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, 160, 230)), mainRect);
                    }
                    break;
                case Style.Dark:
                    if (_rounded)
                    {
                        G.FillPath(new SolidBrush(Color.FromArgb(45, 45, 45)), shadowPath);
                        G.FillPath(new SolidBrush(Color.FromArgb(75, 75, 75)), Drawing.RoundRect(mainRect, slope));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 45)), shadowRect);
                        G.FillRectangle(new SolidBrush(Color.FromArgb(75, 75, 75)), mainRect);
                    }
                    break;
                case Style.Light:
                    if (_rounded)
                    {
                        G.FillPath(new SolidBrush(Color.FromArgb(145, 145, 145)), shadowPath);
                        G.FillPath(new SolidBrush(Color.FromArgb(170, 170, 170)), Drawing.RoundRect(mainRect, slope));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(145, 145, 145)), shadowRect);
                        G.FillRectangle(new SolidBrush(Color.FromArgb(170, 170, 170)), mainRect);
                    }
                    break;
            }

            if (_image == null)
            {
                int textX = Convert.ToInt32(((this.Width - 1) / 2.0) - (G.MeasureString(Text, Font).Width / 2.0));
                int textY = Convert.ToInt32(((this.Height - 1) / 2.0) - (G.MeasureString(Text, Font).Height / 2.0));
                G.DrawString(Text, Font, Brushes.White, textX, textY);
            }
            else
            {
                Size textSize = new Size(Convert.ToInt32(G.MeasureString(Text, Font).Width), Convert.ToInt32(G.MeasureString(Text, Font).Height));
                int imageWidth = this.Height - 19;
                int imageHeight = this.Height - 19;
                int imageX = Convert.ToInt32(((this.Width - 1) / 2.0) - ((imageWidth + 4 + textSize.Width) / 2.0));
                int imageY = Convert.ToInt32(((this.Height - 1) / 2.0) - (imageHeight / 2.0));
                G.DrawImage(_image, imageX, imageY, imageWidth, imageHeight);
                G.DrawString(Text, Font, Brushes.White, new Point(imageX + imageWidth + 4, Convert.ToInt32(((this.Height - 1) / 2.0) - textSize.Height / 2.0)));
            }

            if (MouseState == State.Over)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(25, Color.White)), shadowPath);
            }
            else if (MouseState == State.Down)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(40, Color.White)), shadowPath);
            }

        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = State.None;
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = State.Down;
            Invalidate();
        }
    }
}
