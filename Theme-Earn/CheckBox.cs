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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Earn
{
    [DefaultEvent("CheckedChanged")]
    public class EarnCheckBox : ThemeControl154
    {

        public EarnCheckBox()
        {
            LockHeight = 14;
            SetColor("Text", 75, 77, 89);
            SetColor("Gradient 1", 240, 240, 240);
            SetColor("Gradient 2", 240, 240, 240);
            SetColor("Glow", 240, 240, 240);
            SetColor("Edges", 127, 128, 136);
            SetColor("Backcolor", BackColor);
            SetColor("Check", 75, 77, 89);
            Width = 160;
        }

        private int X;
        private Color TextColor;
        private Color G1;
        private Color G2;
        private Color Glow;
        private Color Edge;
        private Color BG;

        private Color Tick;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edges");
            BG = GetColor("Backcolor");
            Tick = GetColor("Check");
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
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(12, 12)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(12, 12)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(12, 6)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(12, 12)), G1, G2, 90f);
                G.FillRectangle(LGB, new Rectangle(new Point(0, 0), new Size(12, 12)));
                G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(0, 0), new Size(12, 6)));
            }

            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(0, 0), new Size(12, 12)));

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 11), Brushes.Green, new Point(-3, -1));
            DrawText(new SolidBrush(Tick), HorizontalAlignment.Left, 19, -1);
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

