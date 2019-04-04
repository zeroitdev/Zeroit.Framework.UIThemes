// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Anom
{

    public class AnomRadiobutton : ThemeControl154
    {

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
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".AnomRadiobutton")
                {
                    AnomRadiobutton CC = null;
                    CC = (AnomRadiobutton)C;
                    CC.Checked = false;

                }
                else
                {
                }
            }
            _Checked = true;
        }


        protected override void ColorHook()
        {
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 20 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(80, Color.Gray), Color.Transparent);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(1, 1, 16, 16), Color.FromArgb(255, 222, 222, 222), Color.FromArgb(255, 200, 200, 200), 90f);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.FillEllipse(LGB, 1, 1, 15, 15);
            G.FillEllipse(HB, 1, 1, 15, 15);
            G.DrawEllipse(new Pen(Color.Black), 0, 0, 16, 16);

            if ((_Checked))
            {
                //G.FillEllipse(LGB, 4, 4, 8, 8)
                //G.FillEllipse(HB, 4, 4, 8, 8)
                G.FillEllipse(new SolidBrush(Color.Black), 4, 4, 8, 8);
                //G.DrawString("a", New Font("Webdings", 13), Brushes.Black, New Point(-2, -2))
            }

            G.DrawString(Text, Font, Brushes.Black, 18, 2);
        }

        public AnomRadiobutton()
        {
            this.Size = new Size(100, 17);
        }
    }

}


