// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Sugar
{
    public class SugarProgressbar : ThemeControl154
    {
        private int _Maximum = 100;
        private int _Value;
        private int HOffset = 0;
        private int Progress;

        protected override void ColorHook()
        {
        }

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = Maximum;
                _Value = value;
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

        protected override void OnAnimation()
        {
            HOffset -= 1;
            if (HOffset == 7)
                HOffset = 0;
        }

        protected override void PaintHook()
        {
            HatchBrush hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(60, Color.Green));
            G.Clear(Color.FromArgb(0, 236, 241, 242));
            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(236, 241, 242);
            cblend.Colors[1] = Color.FromArgb(236, 241, 242);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2));
            cblend.Colors[1] = Color.FromArgb(236, 241, 242);
            DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height / 5 * 2));
            G.RenderingOrigin = new Point(HOffset, 0);
            hatch = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(40, Color.Green), Color.FromArgb(0, Color.Green));
            G.FillRectangle(hatch, 0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(236, 241, 242)), 1);
            DrawCorners(Color.Black);
            G.DrawLine(new Pen(Color.FromArgb(200, 236, 241, 242)), Convert.ToInt32(((Width / _Maximum) * _Value) - 2), 1, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
            G.DrawLine(Pens.Green, Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, 2, Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, Height - 3);
            Progress = Convert.ToInt32(((Width / _Maximum) * _Value));
            ColorBlend cblend2 = new ColorBlend(3);
            cblend2.Colors[0] = Color.FromArgb(0, Color.Gray);
            cblend2.Colors[1] = Color.FromArgb(80, Color.DimGray);
            cblend2.Colors[2] = Color.FromArgb(0, Color.Gray);
            cblend2.Positions = new float[]{
            0,
            0.5f,
            1
        };
            HatchBrush HB = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
            G.FillRectangle(new SolidBrush(Color.FromArgb(190, 210, 217)), Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, 2, Width - Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, Height - 4);
            G.FillRectangle(HB, new Rectangle(0, 0, Width - 1, Height - 1));
            if (Value > 0)
                G.FillRectangle(new SolidBrush(Color.FromArgb(190, 210, 217)), Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, 2, Width - Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, Height - 4);
        }

        public SugarProgressbar()
        {
            _Maximum = 100;
            IsAnimated = true;
        }
    }

}

