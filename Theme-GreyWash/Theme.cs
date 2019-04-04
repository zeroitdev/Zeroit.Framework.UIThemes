// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{

    #region  Mouse States

    internal enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #endregion

    internal static class DrawHelpers
    {

        #region Functions

        private static int Height;
        private static int Width;

        public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3F, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            GraphicsPath tempRoundRect = null;
            float d = Math.Min(w, h) * r;
            var xw = x + w;
            var yh = y + h;
            tempRoundRect = new GraphicsPath();

            if (TL)
            {
                tempRoundRect.AddArc(x, y, d, d, 180, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, y, x, y);
            }
            if (TR)
            {
                tempRoundRect.AddArc(xw - d, y, d, d, 270, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, y, xw, y);
            }
            if (BR)
            {
                tempRoundRect.AddArc(xw - d, yh - d, d, d, 0, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, yh, xw, yh);
            }
            if (BL)
            {
                tempRoundRect.AddArc(x, yh - d, d, d, 90, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, yh, x, yh);
            }

            tempRoundRect.CloseFigure();
            return tempRoundRect;
        }

        #endregion

    }

    public class GreywashTheme : ContainerControl
    {
        #region  Declarations 
        public static int _Header = 38;
        public static int _SubHeader = 35;
        private bool _Down = false;
        private Point _MousePoint;
        #endregion

        #region  MouseStates 

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _Down = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Location.Y < _Header && e.Button == MouseButtons.Left)
            {
                _Down = true;
                _MousePoint = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_Down == true)
            {
                ParentForm.Location = new Point(MousePosition.X - _MousePoint.X, MousePosition.Y - _MousePoint.Y);
            }
        }

        #endregion

        #region  Properties 

        private bool _Center = true;
        public bool _TitleCenter
        {
            get
            {
                return _Center;
            }
            set
            {
                _Center = value;
            }
        }

        public int _HeaderSize
        {
            get
            {
                return _Header;
            }
            set
            {
                _Header = value;
            }
        }

        private bool _SubHeaderVisable = false;
        public bool _SubHeaderShow
        {
            get
            {
                return _SubHeaderVisable;
            }
            set
            {
                _SubHeaderVisable = value;
            }
        }

        public int _SubHeaderSize
        {
            get
            {
                return _SubHeader;
            }
            set
            {
                _SubHeader = value;
            }
        }

        #endregion

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        public GreywashTheme()
        {
            BackColor = Color.LightGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            G.Clear(Color.LightGray);
            G.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, _Header, Width, Height - _Header));
            G.DrawRectangle(new Pen(Brushes.LightGray), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 1, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 1, 1, 1));
            StringFormat _StringF = new StringFormat();
            if (_Center == true)
            {
                _StringF.Alignment = StringAlignment.Center;
                _StringF.LineAlignment = StringAlignment.Center;
                G.DrawString(Text, new Font("Segoe UI", 12), Brushes.White, new RectangleF(0F, 0F, Width, _Header), _StringF);
            }
            else
            {
                _StringF.Alignment = StringAlignment.Near;
                _StringF.LineAlignment = StringAlignment.Center;
                G.DrawString(Text, new Font("Segoe UI", 12), Brushes.White, new RectangleF(0F, 0F, Width, _Header), _StringF);
            }

            if (_SubHeaderVisable == true)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, _Header, Width, _SubHeader));
            }
            else
            {

            }

        }

    }
    

}
