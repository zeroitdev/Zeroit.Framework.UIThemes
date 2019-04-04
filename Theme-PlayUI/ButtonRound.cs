// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonRound.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
#region  Imports

using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
	
#endregion
	
	

namespace Zeroit.Framework.UIThemes.PlayUI
{
    #region  Round Button

    public class PlayUIButtonRound : Control
    {

        #region  Enums

        public enum MyRadius
        {
            R12,
            R21
        }

        #endregion
        #region  Variables

        private int MouseState;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Pen P1;
        private Pen P3;
        private Image _Image;
        private Size _ImageSize;
        private MyRadius _Radius;

        #endregion
        #region  Properties

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

        public MyRadius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                switch (_Radius)
                {
                    case MyRadius.R12:
                        Size = new Size(25, 25);
                        break;
                    case MyRadius.R21:
                        Size = new Size(44, 44);
                        break;
                }
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion

        public PlayUIButtonRound()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(25, 25);
            P1 = new Pen(Color.FromArgb(116, 119, 126)); // P1 = Border color
        }

        protected override void OnResize(System.EventArgs e)
        {
            switch (_Radius)
            {
                case MyRadius.R12:
                    this.Size = new Size(25, 25);
                    break;
                case MyRadius.R21:
                    this.Size = new Size(44, 44);
                    break;
            }

            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(116, 119, 126), Color.FromArgb(116, 119, 126), 90.0F);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(95, 97, 103), Color.FromArgb(95, 97, 103), 90.0F);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(95, 97, 103), Color.FromArgb(95, 97, 103), 90.0F);
            P3 = new Pen(PressedContourGB); // P3 = Border color when button is pressed

            Invalidate();
            base.OnResize(e);
        }
        private void FinishDrawing(Graphics g, Point center, int radius)
        {
            Rectangle MyCircle = new Rectangle((int)(center.X / 2), (int)(center.Y / 2), radius * 2, radius * 2);

            switch (MouseState)
            {
                case 0: //Inactive
                    g.FillEllipse(InactiveGB, MyCircle);
                    g.DrawEllipse(P1, MyCircle);

                    if (Image == null)
                    {
                    }
                    else
                    {
                        g.DrawImage(_Image, 5, 5, ImageSize.Width, ImageSize.Height);
                    }
                    break;

                case 1: //Pressed
                    g.FillEllipse(PressedGB, MyCircle);
                    g.DrawEllipse(P3, MyCircle);

                    if (Image == null)
                    {
                    }
                    else
                    {
                        g.DrawImage(_Image, 5, 5, ImageSize.Width, ImageSize.Height);
                    }
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            switch (_Radius)
            {
                case MyRadius.R12:
                    FinishDrawing(e.Graphics, new Point(0, 0), 12);
                    break;
                case MyRadius.R21:
                    FinishDrawing(e.Graphics, new Point(0, 0), 21);
                    break;
            }
        }
    }

    #endregion
}