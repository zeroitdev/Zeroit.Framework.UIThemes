// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionNumericUpDown : Control
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
            this.Height = 26;
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (X > this.Width - 17 && X < this.Width - 3)
            {
                if (Y < 13)
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
        public RedemptionNumericUpDown()
        {
            _Max = 9999999;
            _Min = 0;
            Cursor = Cursors.IBeam;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            DoubleBuffered = true;
            Font = new Font("Arial", 8.25f, FontStyle.Bold);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int Curve = 4;
            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
            }
            G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
            LinearGradientBrush ButtonBackground = new LinearGradientBrush(new Rectangle(Width - 17, 0, 17, Height - 2), Color.FromArgb(75, 78, 87), Color.FromArgb(50, 51, 55), 90);
            G.FillRectangle(ButtonBackground, ButtonBackground.Rectangle);
            G.ResetClip();
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
            DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 8), new Point(Width - 6, 8), new Point(Width - 9, 5), G);
            DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 17), new Point(Width - 6, 17), new Point(Width - 9, 20), G);
            G.SetClip(Draw.RoundRect(new Rectangle(Width - 17, 0, 17, Height - 2), Curve));
            G.DrawPath(new Pen(Color.FromArgb(82, 85, 92)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 4), Curve));
            G.ResetClip();
            G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, 0), new Point(Width - 17, Height - 2));
            G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, 1), new Point(Width - 16, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, Height / 2 - 1), new Point(Width - 1, Height / 2 - 1));
            G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, Height / 2), new Point(Width - 2, Height / 2));

            G.DrawString(Value.ToString(), Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Point(8, 8));
            G.DrawString(Value.ToString(), Font, Brushes.White, new Point(7, 7));
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

