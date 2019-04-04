// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Paginator.cs" company="Zeroit Dev Technologies">
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    [DefaultEvent("SelectedIndexChanged")]
    public class LogInPaginator : Control
    {

        #region "Declarations"
        private GraphicsPath GP1;

        private GraphicsPath GP2;

        private Rectangle R1;
        private Size SZ1;

        private Point PT1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        #endregion
        private SolidBrush B2;

        #region "Functions"
        public GraphicsPath RoundRectangle(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public GraphicsPath RoundRect(dynamic x, dynamic y, dynamic w, dynamic h, dynamic r, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            r = 0.3;

            GraphicsPath functionReturnValue = default(GraphicsPath);
            dynamic d = Math.Min(w, h) * r;
            dynamic xw = x + w;
            dynamic yh = y + h;
            functionReturnValue = new GraphicsPath();
            var _with32 = functionReturnValue;
            if (TL)
                _with32.AddArc(x, y, d, d, 180, 90);
            else
                _with32.AddLine(x, y, x, y);
            if (TR)
                _with32.AddArc(xw - d, y, d, d, 270, 90);
            else
                _with32.AddLine(xw, y, xw, y);
            if (BR)
                _with32.AddArc(xw - d, yh - d, d, d, 0, 90);
            else
                _with32.AddLine(xw, yh, xw, yh);
            if (BL)
                _with32.AddArc(x, yh - d, d, d, 90, 90);
            else
                _with32.AddLine(x, yh, x, yh);
            _with32.CloseFigure();
            return functionReturnValue;
        }
        #endregion

        #region "Properties & Events"
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;
        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0);
                Invalidate();
            }
        }

        private int _NumberOfPages;
        public int NumberOfPages
        {
            get { return _NumberOfPages; }
            set
            {
                _NumberOfPages = value;
                _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0);
                Invalidate();
            }
        }

        public int MaximumIndex
        {
            get { return NumberOfPages - 1; }
        }

        private int ItemWidth;
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        private void InvalidateItems(PaintEventArgs e)
        {
            Size S = e.Graphics.MeasureString("000 ..", Font).ToSize();
            ItemWidth = S.Width + 10;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int NewIndex = 0;
                int OldIndex = _SelectedIndex;
                if (_SelectedIndex < 4)
                {
                    NewIndex = (e.X / ItemWidth);
                }
                else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
                {
                    NewIndex = (e.X / ItemWidth);

                    if (NewIndex == 2)
                    {
                        NewIndex = OldIndex;
                    }

                    if (NewIndex == 2)
                    {
                        NewIndex = OldIndex - (2 - NewIndex);
                    }

                    if (NewIndex == 2)
                    {
                        NewIndex = OldIndex + (NewIndex - 2);
                    }

                    #region Old Code
                    //                switch (NewIndex) {
                    //					case 2:
                    //						NewIndex = OldIndex;
                    //						break;
                    //					case  // ERROR: Case labels with binary operators are unsupported : LessThan
                    //2:
                    //						NewIndex = OldIndex - (2 - NewIndex);
                    //						break;
                    //					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                    //2:
                    //						NewIndex = OldIndex + (NewIndex - 2);
                    //						break;
                    //				} 
                    #endregion

                }

                else
                {
                    NewIndex = MaximumIndex - (4 - (e.X / ItemWidth));
                }

                if ((NewIndex < _NumberOfPages) && (!(NewIndex == OldIndex)))
                {
                    SelectedIndex = NewIndex;
                    if (SelectedIndexChanged != null)
                    {
                        SelectedIndexChanged(this, null);
                    }
                }
            }
            base.OnMouseDown(e);
        }

        #endregion

        #region "Draw Control"

        public LogInPaginator()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(54, 54, 54);
            Size = new Size(202, 26);
            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(55, 55, 55));
            P1 = new Pen(Color.FromArgb(35, 35, 35));
            P2 = new Pen(Color.FromArgb(23, 119, 151));
            P3 = new Pen(Color.FromArgb(35, 35, 35));
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            InvalidateItems(e);
            Graphics g = e.Graphics;
            var _with33 = g;
            _with33.Clear(BackColor);
            _with33.SmoothingMode = SmoothingMode.AntiAlias;
            _with33.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            bool LeftEllipse = false;
            bool RightEllipse = false;
            if (_SelectedIndex < 4)
            {
                for (int I = 0; I <= Math.Min(MaximumIndex, 4); I++)
                {
                    RightEllipse = (I == 4) && (MaximumIndex > 4);
                    DrawBox(I * ItemWidth, I, false, RightEllipse, g);
                }
            }
            else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = (I == 0);
                    RightEllipse = (I == 4);
                    DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse, g);
                }
            }
            else
            {
                for (int I = 0; I <= 4; I++)
                {
                    LeftEllipse = (I == 0) && (MaximumIndex > 4);
                    DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, false, g);
                }
            }
        }

        private void DrawBox(int x, int index, bool leftEllipse, bool rightEllipse, Graphics g)
        {
            R1 = new Rectangle(x, 0, ItemWidth - 4, Height - 1);
            GP1 = RoundRectangle(R1, 4);
            GP2 = RoundRectangle(new Rectangle(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2), 4);
            string T = Convert.ToString(index + 1);
            if (leftEllipse)
                T = ".. " + T;
            if (rightEllipse)
                T = T + " ..";
            SZ1 = g.MeasureString(T, Font).ToSize();
            PT1 = new Point(R1.X + (R1.Width / 2 - SZ1.Width / 2), R1.Y + (R1.Height / 2 - SZ1.Height / 2));
            if (index == _SelectedIndex)
            {
                g.FillPath(B1, GP1);
                Font F = new Font(Font, FontStyle.Underline);
                g.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                g.DrawString(T, F, Brushes.White, PT1);
                F.Dispose();
                g.DrawPath(P1, GP2);
                g.DrawPath(P2, GP1);
            }
            else
            {
                g.FillPath(B2, GP1);
                g.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
                g.DrawString(T, Font, Brushes.White, PT1);
                g.DrawPath(P3, GP2);
                g.DrawPath(P1, GP1);
            }
        }

        #endregion

    }

}


