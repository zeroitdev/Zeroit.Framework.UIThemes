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
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{
    public class iCheckBox : ThemeControl154
    {
        protected override void ColorHook()
        {
        }

        #region "Events"
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
        #endregion

        public iCheckBox()
        {
            Click += changeChecked;
            Size = new Size(150, 17);
            LockHeight = 17;
            Font = new Font("Arial", 9);
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));

            Rectangle xRect = new Rectangle(0, 0, 20, 16);
            Rectangle cRect = new Rectangle(21, 0, 20, 16);

            ColorBlend bg_cblend = new ColorBlend(3);
            bg_cblend.Colors[0] = Color.FromArgb(35, 35, 35);
            bg_cblend.Colors[1] = Color.FromArgb(52, 52, 52);
            bg_cblend.Colors[2] = bg_cblend.Colors[0];
            bg_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            LinearGradientBrush pBrush = new LinearGradientBrush(xRect, Color.Black, Color.Red, 90f);
            pBrush.InterpolationColors = bg_cblend;
            G.FillRectangles(pBrush, new RectangleF[]{
            cRect,
            xRect
        });

            //On And Off Switches
            if (_Checked)
            {
                //b
                G.DrawString("b", new Font("Marlett", 16), Brushes.ForestGreen, new Point(18, -1));
                G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(70, 70, 70)), new Point(1, 1));
            }
            else
            {
                G.DrawString("b", new Font("Marlett", 16), new SolidBrush(Color.FromArgb(70, 70, 70)), new Point(18, -1));
                G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(180, 50, 50)), new Point(1, 1));
            }
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, 40, 16));
            G.DrawLine(Pens.Black, new Point(20, 0), new Point(20, 17));

            //Text
            G.DrawString(Text, new Font("Arial", 8), Brushes.WhiteSmoke, 44, 2);

        }

    }


}


