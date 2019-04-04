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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Evolve
{


    public class EvolveProgressBar : ThemeControl154
    {

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value >= Minimum & value <= _Max)
                    _Value = value;
                Invalidate();
            }
        }

        private int _Max = 100;
        public int Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                    _Max = value;
                Invalidate();
            }
        }

        private int _Min = 0;
        public int Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                    _Min = value;
                Invalidate();
            }
        }

        public EvolveProgressBar()
        {
            Transparent = true;
        }

        protected override void ColorHook()
        {
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 11;
        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.Clear(Color.FromArgb(47, 47, 47));

            LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(6, 0), new Size(Width - 6, 10)), Color.FromArgb(10, 10, 10), Color.FromArgb(47, 47, 47), 90f);
            G.FillRectangle(Gbrush, new Rectangle(new Point(6, 0), new Size(Width - 12, 10)));
            G.FillEllipse(Gbrush, new Rectangle(new Point(0, 0), new Size(10, 10)));
            G.FillEllipse(Gbrush, new Rectangle(new Point(this.Width - 11, 0), new Size(10, 10)));
            if (Value < 3)
            {
                Gbrush = new LinearGradientBrush(new Rectangle(new Point(6, 0), new Size(Width - 6, 10)), Color.FromArgb(180, 80, 80), Color.FromArgb(160, 70, 70), 90f);
                G.FillEllipse(Gbrush, new Rectangle(new Point((this.Width / 100) * _Value - 7, 0), new Size(5, 6)));
                Gbrush = new LinearGradientBrush(new Rectangle(new Point(6, 0), new Size(Width - 6, 10)), Color.FromArgb(150, 40, 40), Color.FromArgb(120, 30, 30), 90f);
                G.FillEllipse(Gbrush, new Rectangle(new Point((this.Width / 100) * _Value - 7, 4), new Size(6, 6)));
                HatchBrush Hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(50, Color.Black), Color.Transparent);
                G.FillRectangle(Hatch, new Rectangle(new Point(2, 1), new Size((this.Width / 100) * _Value - 2, 8)));
            }
            else
            {
                Gbrush = new LinearGradientBrush(new Rectangle(new Point(6, 0), new Size(Width - 6, 10)), Color.FromArgb(180, 80, 80), Color.FromArgb(160, 70, 70), 90f);
                G.FillEllipse(Gbrush, new Rectangle(new Point((this.Width / 100) * _Value - 7, 0), new Size(5, 6)));
                G.FillEllipse(Gbrush, new Rectangle(new Point(1, 1), new Size(9, 5)));
                G.FillRectangle(Gbrush, new Rectangle(new Point(7, 1), new Size((this.Width / 100) * _Value - 11, 4)));
                Gbrush = new LinearGradientBrush(new Rectangle(new Point(6, 0), new Size(Width - 6, 10)), Color.FromArgb(150, 40, 40), Color.FromArgb(120, 30, 30), 90f);
                G.FillEllipse(Gbrush, new Rectangle(new Point((this.Width / 100) * _Value - 7, 4), new Size(6, 6)));
                G.FillEllipse(Gbrush, new Rectangle(new Point(1, 5), new Size(9, 6)));
                G.FillRectangle(Gbrush, new Rectangle(new Point(7, 5), new Size((this.Width / 100) * _Value - 11, 4)));
                HatchBrush Hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(50, Color.Black), Color.Transparent);
                G.FillRectangle(Hatch, new Rectangle(new Point(2, 1), new Size((this.Width / 100) * _Value - 2, 8)));
            }

            G.DrawArc(Pens.Black, new Rectangle(new Point(0, 0), new Size(10, 10)), -90, -180);
            G.DrawLine(Pens.Black, new Point(6, 0), new Point(this.Width - 7, 0));
            G.DrawLine(Pens.Black, new Point(6, 10), new Point(this.Width - 7, 10));
            G.DrawArc(Pens.Black, new Rectangle(new Point(this.Width - 11, 0), new Size(10, 10)), 90, -180);
            G.DrawLine(new Pen(Color.FromArgb(72, 72, 72)), new Point(4, 11), new Point(this.Width - 4, 11));
            G.DrawArc(Pens.Black, new Rectangle(new Point((this.Width / 100) * _Value - 11, 0), new Size(10, 10)), 90, -180);

            DrawPixel(Color.FromArgb(47, 47, 47), 0, 0);
            DrawPixel(Color.FromArgb(47, 47, 47), 1, 0);
            DrawPixel(Color.FromArgb(47, 47, 47), 2, 0);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 1);
            DrawPixel(Color.FromArgb(47, 47, 47), 1, 1);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 2);
            DrawPixel(Color.FromArgb(47, 47, 47), 1, 1);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 3);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 4);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 9);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 8);
            DrawPixel(Color.FromArgb(47, 47, 47), 0, 10);
            DrawPixel(Color.FromArgb(47, 47, 47), 1, 10);
            DrawPixel(Color.FromArgb(47, 47, 47), 2, 10);
        }
    }


}


