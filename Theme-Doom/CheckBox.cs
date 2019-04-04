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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Doom
{
    public class DoomCheckBox : ThemeControl154
    {

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

        public DoomCheckBox()
        {
            Click += changeChecked;
            Transparent = true;
            Size = new Size(150, 16);
            Font = new Font("Arial", 9);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Transparent);
            //Background
            Rectangle rect = new Rectangle(0, 0, 45, 15);
            G.FillRectangle(Brushes.Black, rect);
            //On And Off Switches
            if ((_Checked == false))
            {
                G.DrawString("OFF", Font, Brushes.White, 3, 1);
                Rectangle offRect = new Rectangle(31, 2, 12, 12);
                LinearGradientBrush offLGB = new LinearGradientBrush(offRect, Color.FromArgb(150, Color.Gainsboro), Color.LightGray, 90f);
                G.FillRectangle(offLGB, offRect);
                G.DrawRectangle(Pens.White, new Rectangle(31, 2, 11, 11));
            }
            else
            {
                G.DrawString("ON", Font, new SolidBrush(Color.FromArgb(200, Color.Lime)), 18, 1);
                Rectangle onRect = new Rectangle(2, 2, 12, 12);
                LinearGradientBrush onLGB = new LinearGradientBrush(onRect, Color.FromArgb(150, Color.DarkGreen), Color.DarkGreen, 90f);
                G.FillRectangle(onLGB, onRect);
                G.DrawRectangle(Pens.Lime, new Rectangle(2, 2, 11, 11));
            }
            //Text Area
            Rectangle textAreaRect = new Rectangle(45, 0, Width - 1, Height - 1);
            HatchBrush textAreaHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(200, 16, 16, 16), Color.FromArgb(200, 14, 14, 14));
            G.FillRectangle(textAreaHB, textAreaRect);
            DrawText(new SolidBrush(Color.Red), HorizontalAlignment.Left, 50, 0);
            //Border
            DrawBorders(Pens.Black);
        }
    }


}

