// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Doom
{
    public class DoomRadioButton : ThemeControl154
    {
        public DoomRadioButton()
        {
            BackColor = Color.Transparent;
            Transparent = true;
            Size = new Size(50, 17);
        }

        #region "Events"
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

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            foreach (Control C in Parent.Controls)
            {
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".DoomRadioButton")
                {
                    DoomRadioButton CC = null;
                    CC = (DoomRadioButton)C;
                    CC.Checked = false;
                }
            }
            _Checked = true;
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 25 + textSize;
        }
        #endregion


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            //Text Area
            HatchBrush textAreaHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(200, 16, 16, 16), Color.FromArgb(200, 14, 14, 14));
            Rectangle textAreaRect = new Rectangle(8, 0, Width - 9, Height - 1);
            G.FillRectangle(textAreaHB, textAreaRect);
            G.DrawRectangle(Pens.Black, 8, 0, Width - 9, Height - 1);

            if (_Checked == false)
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(24, 30, 36), Color.FromArgb(25, 25, 25), 90f);
                G.FillEllipse(Gbrush, new Rectangle(1, 1, 14, 14));
                Gbrush = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(12, 12, 12), Color.FromArgb(25, 25, 25), 90f);
                G.FillEllipse(Gbrush, new Rectangle(2, 2, 12, 12));
                G.DrawEllipse(Pens.Black, 0, 0, 16, 16);
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(24, 24, 24), Color.FromArgb(10, 10, 10), 90f);
                G.FillEllipse(LGB1, new Rectangle(1, 1, 14, 14));
                LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(16, 16, 16), Color.FromArgb(8, 8, 8), 90f);
                G.FillEllipse(LGB2, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(Brushes.Black, new Rectangle(5, 6, 5, 5));
                SolidBrush SB = new SolidBrush(Color.White);
                G.FillEllipse(SB, new Rectangle(4, 4, 8, 8));
                G.DrawEllipse(Pens.White, 0, 0, 16, 16);
            }
            //Text
            G.DrawString(Text, Font, Brushes.Red, 20, 1);
        }


    }


}

