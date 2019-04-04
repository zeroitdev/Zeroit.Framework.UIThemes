// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influx
{
    [DefaultEvent("CheckedChanged")]
    public class InfluxCheckbox : ThemeControl154
    {
        private bool _Checked;

        private int X;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnClick(System.EventArgs e)
        {
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = Convert.ToInt32(this.CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 20 + textSize;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _Checked = !_Checked;
        }

        Color CheckBoxColor;
        Brush TextBrush;
        protected override void ColorHook()
        {
            CheckBoxColor = GetColor("CheckBoxColor");
            TextBrush = GetBrush("Text");
        }

        Rectangle CheckButtonBorder = new Rectangle(0, 3, 11, 11);
        Point[] CheckPoints = {
        new Point(2, 7),
        new Point(5, 10),
        new Point(7, 6),
        new Point(10, 1)
    };
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(77, 77, 77));
            G.SmoothingMode = SmoothingMode.HighQuality;

            //HatchBrush
            HatchBrush HB = new HatchBrush(HatchStyle.Percent20, Color.FromArgb(83, 83, 83), BackColor);
            G.FillRectangle(HB, new Rectangle(0, 0, Width, Height));

            if (_Checked)
            {
                if (State == MouseState.Over & X <= 11)
                {
                    LinearGradientBrush Gradient = new LinearGradientBrush(CheckButtonBorder, Color.FromArgb(108, 108, 108), Color.FromArgb(95, 95, 95), 90);
                    G.FillRectangle(Gradient, CheckButtonBorder);
                }
                else
                {
                    LinearGradientBrush Gradient = new LinearGradientBrush(CheckButtonBorder, Color.FromArgb(103, 103, 103), Color.FromArgb(90, 90, 90), 90);
                    G.FillRectangle(Gradient, CheckButtonBorder);
                }
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(67, 67, 67))), CreateRound(CheckButtonBorder, 2));
                G.DrawLines(new Pen(TextBrush, 2), CheckPoints);
            }
            else
            {
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(59, 59, 59))), CreateRound(CheckButtonBorder, 2));
                if (State == MouseState.Over & X <= 11)
                {
                    LinearGradientBrush Gradient = new LinearGradientBrush(CheckButtonBorder, Color.FromArgb(95, 95, 95), Color.FromArgb(70, 70, 70), 90);
                    G.FillRectangle(Gradient, CheckButtonBorder);
                }
                else
                {
                    LinearGradientBrush Gradient = new LinearGradientBrush(CheckButtonBorder, Color.FromArgb(90, 90, 90), Color.FromArgb(65, 65, 65), 90);
                    G.FillRectangle(Gradient, CheckButtonBorder);
                }
            }
            G.DrawString(Text, Font, TextBrush, new Point(17, 2));
        }

        public InfluxCheckbox()
        {
            this.Size = new Size(50, 16);
            BackColor = Color.FromArgb(77, 77, 77);
            SetColor("CheckBoxColor", Color.FromArgb(77, 77, 77));
            SetColor("Text", Color.FromArgb(229, 229, 229));
        }
    }

}


