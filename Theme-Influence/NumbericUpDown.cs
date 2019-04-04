// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="NumbericUpDown.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceNumericUpDown : Control
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
            this.Height = 22;
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (X > this.Width - 21)
            {
                if (Y < 10)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public InfluenceNumericUpDown()
        {
            _Max = 9999999;
            _Min = 0;
            Cursor = Cursors.IBeam;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(BackColor);

            Draw d = new Draw();
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.FromArgb(20, 20, 20));

            LinearGradientBrush g1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
            G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            G.FillPath(h1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillPath(s1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            //'Separator Lines
            G.DrawLine(new Pen(Color.FromArgb(10, 10, 10)), new Point(Width - 21, 0), new Point(Width - 21, Height));
            G.DrawLine(new Pen(Color.FromArgb(70, 70, 70)), new Point(Width - 20, 1), new Point(Width - 20, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(10, 10, 10)), new Point(Width - 20, 10), new Point(Width, 10));
            G.DrawLine(new Pen(Color.FromArgb(70, 70, 70)), new Point(Width - 19, 11), new Point(Width - 3, 11));

            //Top Triangle
            DrawTriangle(Color.White, new Point(Width - 14, 14), new Point(Width - 7, 14), new Point(Width - 11, (int)17.5), G);

            //Bottom Triangle
            DrawTriangle(Color.White, new Point(Width - 14, 7), new Point(Width - 7, 7), new Point(Width - 11, 3), G);

            G.DrawString(Value.ToString(), Font, Brushes.White, new Point(5, 4));
            //G.DrawRectangle(New Pen(Color.FromArgb(70, 70, 70)), New Rectangle(1, 1, Width - 3, Height - 3))
            //G.DrawRectangle(New Pen(Color.FromArgb(30, 30, 30)), New Rectangle(0, 0, Width - 1, Height - 1))

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }


}

