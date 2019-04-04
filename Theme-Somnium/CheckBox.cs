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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Somnium
{
    public class SomniumCheckBox : ThemeControl151
    {
        //G.Clear
        private Color C1;
        private Color C2;
        //Lime Gradient
        private Color C3;
        //DrawRectangle
        private Pen P1;
        //Gloss
        private Brush B1;
        //DrawText
        private Brush B2;
        //Fill
        private Brush B3;
        //BackGround
        private HatchBrush HB1;
        private bool _Checked = false;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        public SomniumCheckBox()
        {
            Click += changeChecked;
            Size = new Size(136, 16);
        }
        public void changeChecked(object sender, EventArgs e)
        {
            switch (_Checked)
            {
                case false:
                    _Checked = true;
                    break;
                case true:
                    _Checked = false;
                    break;
            }
        }
        protected override void ColorHook()
        {
            C1 = Color.FromArgb(15, 15, 15);
            C2 = Color.White;
            C3 = Color.LightGray;
            P1 = Pens.Black;
            B1 = new SolidBrush(Color.FromArgb(15, Color.White));
            B2 = new SolidBrush(Color.White);
            B3 = new SolidBrush(Color.FromArgb(15, 15, 15));
            HB1 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(15, 15, 15));
        }

        protected override void PaintHook()
        {
            G.Clear(C1);
            G.FillRectangle(HB1, 0, 0, Width, Height);
            G.FillRectangle(B3, 0, 0, 15, 15);
            G.DrawRectangle(P1, 0, 0, 15, 15);

            if ((_Checked == false))
            {
                if ((State == MouseState.Over))
                {
                    DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(15, 15, 15), 2, 2, 11, 11, 90);
                }
                else
                {
                    DrawGradient(Color.FromArgb(15, 15, 15), Color.FromArgb(50, 50, 50), 2, 2, 11, 11, 90);
                }
            }
            else
            {
                if ((State == MouseState.Over))
                {
                    DrawGradient(C3, C2, 2, 2, 11, 11, 90);
                }
                else
                {
                    DrawGradient(C2, C3, 2, 2, 11, 11, 90);
                }

            }
            G.FillRectangle(B1, 2, 2, 11, 11);
            G.DrawRectangle(P1, 2, 2, 11, 11);
            DrawText(B2, HorizontalAlignment.Left, 15, 0);
        }
    }

}


