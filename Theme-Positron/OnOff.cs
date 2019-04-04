// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="OnOff.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    [DefaultEvent("CheckedChanged")]
    public class PositronOnOff : ThemeControl154
    {
        private Brush TB;

        private Pen b;
        private bool _Checked = false;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }
        protected void DrawBorders(Pen p1, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, G);
        }
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset, G);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
            {
                _Checked = false;
            }
            else
            {
                _Checked = true;
            }
        }

        public PositronOnOff()
        {
            LockHeight = 24;
            LockWidth = 62;
            SetColor("Texts", Color.FromArgb(100, 100, 100));
            SetColor("border", Color.FromArgb(125, 125, 125));
        }

        protected override void ColorHook()
        {
            TB = GetBrush("Texts");
            b = GetPen("border");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90);
            HatchBrush HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent);

            if (_Checked)
            {
                G.FillRectangle(LGB1, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                G.FillRectangle(HB1, new Rectangle(2, 2, (Width / 2) - 2, Height - 4));
                G.DrawString("On", Font, TB, new Point(36, 6));
            }
            else if (!_Checked)
            {
                G.FillRectangle(LGB1, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                G.FillRectangle(HB1, new Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4));
                G.DrawString("Off", Font, TB, new Point(5, 6));
            }
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), G);
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1, G);

        }
    }
}

