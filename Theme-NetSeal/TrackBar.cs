// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("Scroll")]
    public class NSTrackBar : Control
    {

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 10;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();

                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }

        public NSTrackBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 17;

            P1 = new Pen(Color.FromArgb(0, 153, 204), 2);
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            P3 = new Pen(Color.FromArgb(24, 24, 24));
            P4 = new Pen(Color.FromArgb(65, 65, 65));
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;

        private int I1;
        private Pen P1;
        private Pen P2;
        private Pen P3;

        private Pen P4;
        private LinearGradientBrush GB1;
        private LinearGradientBrush GB2;

        private LinearGradientBrush GB3;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 5, Width - 1, 10, 5);
            GP2 = theme.CreateRound(1, 6, Width - 3, 8, 5);

            R1 = new Rectangle(0, 7, Width - 1, 5);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90f);

            I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11));
            R2 = new Rectangle(I1, 0, 10, 20);

            G.SetClip(GP2);
            G.FillRectangle(GB1, R1);

            R3 = new Rectangle(1, 7, R2.X + R2.Width - 2, 8);
            GB2 = new LinearGradientBrush(R3, Color.FromArgb(51, 181, 229), Color.FromArgb(0, 153, 204), 90f);

            G.SmoothingMode = SmoothingMode.None;
            G.FillRectangle(GB2, R3);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            for (int I = 0; I <= R3.Width - 15; I += 5)
            {
                G.DrawLine(P1, I, 0, I + 15, Height);
            }

            G.ResetClip();

            G.DrawPath(P2, GP1);
            G.DrawPath(P3, GP2);

            GP3 = theme.CreateRound(R2, 5);
            GP4 = theme.CreateRound(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2, 5);
            GB3 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);

            G.FillPath(GB3, GP3);
            G.DrawPath(P3, GP3);
            G.DrawPath(P4, GP4);
        }

        private bool TrackDown;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11));
                R2 = new Rectangle(I1, 0, 10, 20);

                TrackDown = R2.Contains(e.Location);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (TrackDown && e.X > -1 && e.X < (Width + 1))
            {
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / Width));
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            TrackDown = false;
            base.OnMouseUp(e);
        }

    }

}


