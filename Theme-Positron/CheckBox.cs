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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    [DefaultEvent("CheckedChanged")]
    public class PositronCheckBox : ThemeControl154
    {
        private Color BG;
        private Brush TB;
        private Brush IN;
        private Pen IB;

        private Pen B;
        private bool _Checked;
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

        public PositronCheckBox()
        {
            LockHeight = 22;
            SetColor("BG", Color.FromArgb(240, 240, 240));
            SetColor("Texts", Color.FromArgb(100, 100, 100));
            SetColor("Inside", Color.FromArgb(175, 175, 175));
            SetColor("IB", Color.FromArgb(200, 200, 200));
            SetColor("B", Color.FromArgb(150, 150, 150));
            Size = new Size(150, 22);
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
            TB = GetBrush("Texts");
            IN = GetBrush("Inside");
            IB = GetPen("IB");
            B = GetPen("B");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (_Checked)
            {
                G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(IN, new Rectangle(new Point(4, 4), new Size(10, 10)));
                if (_Checked)
                {
                    G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));
                }
            }

            G.DrawRectangle(B, 2, 2, 14, 14);
            G.DrawRectangle(IB, 1, 1, 16, 16);
            G.DrawString(Text, Font, TB, 19, 3);
        }
    }
}

