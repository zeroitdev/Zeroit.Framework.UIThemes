// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NYX
{
    [DefaultEvent("CheckedChanged")]
    public class NYXCheckBox : ThemeControl154
    {
        //Coded by HΛWK

        int X;

        int Y;
        public NYXCheckBox()
        {
            Size = new Size(120, 20);
            LockHeight = 20;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Y = e.Location.Y;
            Invalidate();
        }

        protected override void ColorHook()
        {
        }

        //Coded by HΛWK
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));
            Point[] cbPoints = {
            new Point(3, 5),
            new Point(5, 3),
            new Point(14, 3),
            new Point(16, 5),
            new Point(16, 14),
            new Point(14, 16),
            new Point(5, 16),
            new Point(3, 14)
        };
            Point[] innerpoints = {
            new Point(4, 6),
            new Point(6, 4),
            new Point(13, 4),
            new Point(15, 6),
            new Point(15, 13),
            new Point(13, 15),
            new Point(6, 15),
            new Point(4, 13)
        };
            G.DrawPolygon(Pens.Black, cbPoints);
            ColorBlend checked_cblend = new ColorBlend(3);
            checked_cblend.Colors[0] = Color.FromArgb(90, 0, 0);
            checked_cblend.Colors[1] = Color.FromArgb(120, 0, 0);
            checked_cblend.Colors[2] = Color.FromArgb(180, 0, 0);
            checked_cblend.Positions = new float[]{
            0,
            0.7f,
            1
        };
            ColorBlend bg_cblend = new ColorBlend(3);
            bg_cblend.Colors[0] = Color.FromArgb(14, 14, 14);
            bg_cblend.Colors[1] = Color.FromArgb(12, 12, 12);
            bg_cblend.Colors[2] = Color.FromArgb(16, 16, 16);
            bg_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            //Checked
            if (_Checked == true)
            {
                DrawGradient(checked_cblend, new Rectangle(4, 4, 12, 12), -45f);
                G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(150, 0, 0))), innerpoints);
                G.DrawPolygon(Pens.Black, cbPoints);
            }
            else
            {
                DrawGradient(bg_cblend, new Rectangle(4, 4, 12, 12), -45f);
                G.DrawPolygon(Pens.Black, cbPoints);
            }
            //Highlight On MouseOver
            if (State == MouseState.Over && X <= 16 && Y >= 4 && Y <= 16)
            {
                G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(210, 210, 210))), cbPoints);
            }
            else if (State == MouseState.Down)
            {
                G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(210, 210, 210))), cbPoints);
            }
            //Text
            DrawText(Brushes.Black, HorizontalAlignment.Left, 20, 1);
            DrawText(Brushes.Red, HorizontalAlignment.Left, 19, 0);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (X <= 16 && Y >= 4 && Y <= 16)
            {
                _Checked = !_Checked;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
    }

}

