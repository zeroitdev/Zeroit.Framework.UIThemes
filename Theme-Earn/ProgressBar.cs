// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnProgressBar : ThemeControl154
    {

        Color G1;
        Color G2;
        Color G3;
        Color Glow;
        Color Edge1;
        Color Edge2;

        int GlowPosition;
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

        private int _Maximum = 100;
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

        public bool Animated
        {
            get { return IsAnimated; }
            set
            {
                IsAnimated = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public EarnProgressBar()
        {
            SetColor("Gradient 1", 240, 240, 240);
            SetColor("Gradient 2", 79, 178, 52);
            SetColor("Gradient 3", 130, 208, 73);
            SetColor("Glow", Color.Transparent);
            SetColor("Edge1", 75, 77, 89);
            SetColor("Edge2", 240, 240, 240);
            IsAnimated = true;

        }

        protected override void ColorHook()
        {
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            G3 = GetColor("Gradient 3");
            Glow = GetColor("Glow");
            Edge1 = GetColor("Edge1");
            Edge2 = GetColor("Edge2");
        }

        protected override void OnAnimation()
        {
            if (GlowPosition == 0)
            {
                GlowPosition = 7;
            }
            else
            {
                GlowPosition -= 1;
            }
        }

        protected override void PaintHook()
        {
            G.Clear(G1);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), G2, G3, 90f);
            G.FillRectangle(LGB, new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, Height - 2)));
            G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, (Height / 2) - 3)));

            G.RenderingOrigin = new Point(GlowPosition, 0);

            G.DrawLine(new Pen(Edge2), new Point((Width / Maximum) * Value - 1, 1), new Point((Width / Maximum) * Value - 1, Height + 1));
            G.DrawRectangle(new Pen(Edge2), new Rectangle(new Point(2, 2), new Size(Width - 4, Height - 4)));
            G.DrawRectangle(new Pen(Edge1), new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
            DrawCorners(Color.FromArgb(240, 240, 240));
        }

    }

}

