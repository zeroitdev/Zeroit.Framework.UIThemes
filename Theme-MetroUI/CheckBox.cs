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
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Metro
{
    [DefaultEvent("CheckedChanged")]
    public class MetroUICheck : ThemeControl154
    {

        public MetroUICheck()
        {
            LockHeight = 20;
            Width = 120;
            SetColor("Text", Color.Black);
            SetColor("Backcolor", Color.White);
            Font = new Font("Segoe UI", 12);

        }

        private int X;
        private Color TextColor;

        private Color BG;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            BG = GetColor("Backcolor");
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(BG);
            if (_Checked)
            {
                G.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 20, 20));
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, 20 - 2, 20 - 2));
            }
            else
            {
                G.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 20, 20));
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, 20 - 2, 20 - 2));
            }

            if (State == MouseState.Over & X < 15)
            {
                G.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 20, 20));
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, 20 - 2, 20 - 2));
            }
            else if (State == MouseState.Down & X < 15)
            {
                G.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, 20, 20));
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, 20 - 2, 20 - 2));
            }

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 20), new SolidBrush(Color.FromArgb(53, 157, 181)), new Point(-7, -5));
            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 25, 0);
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
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnMouseDown(e);
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

    }
}


