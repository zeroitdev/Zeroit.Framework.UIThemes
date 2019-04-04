﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Orains
{
    [DefaultEvent("CheckedChanged")]
    public class OrainsRadioButton : ThemeControl154
    {
        private int X;

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        protected override void OnCreation()
        {
            InvalidateControls();
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is OrainsRadioButton)
                {
                    ((OrainsRadioButton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }
        Brush TextColor;
        Pen CircleColor;

        Pen CircleInner;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            CircleColor = GetPen("Circle");
            CircleInner = GetPen("Inner");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 30 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (_Checked)
            {
                G.DrawEllipse(CircleColor, new Rectangle(0, 0, 16, 16));
                G.DrawEllipse(CircleInner, new Rectangle(1, 1, 14, 14));
                G.FillEllipse(new SolidBrush(Color.DarkOrange), new Rectangle(5, 5, 6, 6));

            }
            else
            {
                G.DrawEllipse(CircleColor, new Rectangle(0, 0, 16, 16));
                G.DrawEllipse(CircleInner, new Rectangle(1, 1, 14, 14));
            }

            if (State == MouseState.Over)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(20, Color.Orange)), 5, 5, 6, 6);
            }

            G.DrawString(Text, Font, TextColor, new Point(22, 2));
        }

        public OrainsRadioButton()
        {
            this.Size = new Size(50, 17);
            SetColor("Text", Color.Orange);
            SetColor("Circle", Color.Black);
            SetColor("Inner", Color.FromArgb(40, 40, 40));
        }
    }

}


