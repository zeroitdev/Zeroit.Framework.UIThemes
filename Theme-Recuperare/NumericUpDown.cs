﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Recuperare
{

    public class RecuperareIINumericUpDown : Control
    {

        #region " Properties & Flicker Control "
        private MouseState State = new MouseState();
        private int X;
        private int Y;
        private long _Value;
        private long _Max;
        private long _Min;
        private bool Typing;
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value <= _Max & value >= _Min)
                    _Value = value;
                Invalidate();
            }
        }
        public long Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                    _Max = value;
                if (_Value > _Max)
                    _Value = _Max;
                Invalidate();
            }
        }
        public long Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                    _Min = value;
                if (_Value < _Min)
                    _Value = _Min;
                Invalidate();
            }
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Y = e.Location.Y;
            Invalidate();
            if (e.X < Width - 23)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Default;
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            this.Height = 30;
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (X > this.Width - 21 && X < this.Width - 3)
            {
                if (Y < 15)
                {
                    if ((Value + 1) <= _Max)
                        _Value += 1;
                }
                else
                {
                    if ((Value - 1) >= _Min)
                        _Value -= 1;
                }
            }
            else
            {
                Typing = !Typing;
                Focus();
            }
            Invalidate();
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (Typing)
                    _Value = Convert.ToInt32(Convert.ToString(_Value) + e.KeyChar.ToString());
                if (_Value > _Max)
                    _Value = _Max;
            }
            catch (Exception ex)
            {
            }
        }
        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Up)
            {
                if ((Value + 1) <= _Max)
                    _Value += 1;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if ((Value - 1) >= _Min)
                    _Value -= 1;
            }
            else if (e.KeyCode == Keys.Back)
            {
                string tmp = _Value.ToString();
                tmp = tmp.Remove(Convert.ToInt32(tmp.Length - 1));
                if ((tmp.Length == 0))
                    tmp = "0";
                _Value = Convert.ToInt32(tmp);
            }
            Invalidate();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }
        #endregion

        public RecuperareIINumericUpDown()
        {
            _Max = 9999999;
            _Min = 0;
            Cursor = Cursors.IBeam;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(233, 233, 233);
            ForeColor = Color.FromArgb(27, 94, 137);
            DoubleBuffered = true;
            Font = new Font("Verdana", 6.75f, FontStyle.Bold);

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush innerBorderBrush = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(220, 220, 220), Color.FromArgb(228, 228, 228), 90);
            Pen innerBorderPen = new Pen(innerBorderBrush);
            G.DrawRectangle(innerBorderPen, new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(191, 191, 191)), new Point(1, 1), new Point(Width - 3, 1));

            G.DrawRectangle(new Pen(Color.FromArgb(254, 254, 254)), new Rectangle(0, 0, Width - 1, Height - 1));


            LinearGradientBrush buttonGradient = new LinearGradientBrush(new Rectangle(Width - 23, 4, 19, 21), Color.FromArgb(245, 245, 245), Color.FromArgb(232, 232, 232), 90);
            G.FillRectangle(buttonGradient, buttonGradient.Rectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(252, 252, 252)), new Rectangle(Width - 22, 5, 17, 19));
            G.DrawRectangle(new Pen(Color.FromArgb(190, 190, 190)), new Rectangle(Width - 23, 4, 19, 21));
            G.DrawLine(new Pen(Color.FromArgb(200, 167, 167, 167)), new Point(Width - 22, Height - 4), new Point(Width - 5, Height - 4));
            G.DrawLine(new Pen(Color.FromArgb(188, 188, 188)), new Point(Width - 22, Height - 16), new Point(Width - 5, Height - 16));
            G.DrawLine(new Pen(Color.FromArgb(252, 252, 252)), new Point(Width - 22, Height - 15), new Point(Width - 5, Height - 15));


            //Top Triangle
            DrawTriangle(Color.FromArgb(27, 94, 137), new Point(Width - 17, 18), new Point(Width - 9, 18), new Point(Width - 13, 21), G);

            //Bottom Triangle
            DrawTriangle(Color.FromArgb(27, 94, 137), new Point(Width - 17, 10), new Point(Width - 9, 10), new Point(Width - 13, 7), G);

            G.DrawString(Value.ToString(), Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 1, Height - 1), new StringFormat { LineAlignment = StringAlignment.Center });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }

}

