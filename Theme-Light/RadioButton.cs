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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightRadiobutton : ThemeControl
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
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".lRadiobutton")
                {
                    LightRadiobutton CC = null;
                    CC = (LightRadiobutton)C;
                    CC.Checked = false;

                }
                else
                {
                }
            }
            _Checked = true;
        }

        public LightRadiobutton()
        {
            Size = new Size(90, 15);
            MinimumSize = new Size(17, 17);
            MaximumSize = new Size(600, 17);
        }

        public override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
            HatchBrush hb2 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
            LinearGradientBrush a = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 90f);
            if (_Checked == false)
            {
                G.FillEllipse(new SolidBrush(Color.Gray), 0, 0, 16, 16);
                G.FillEllipse(new SolidBrush(Color.LightGray), 1, 1, 14, 14);
                G.FillEllipse(a, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(hb, new Rectangle(2, 2, 12, 12));

            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.Gray), 0, 0, 16, 16);
                G.FillEllipse(new SolidBrush(Color.LightGray), 1, 1, 14, 14);
                G.FillEllipse(a, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(hb, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(Brushes.Black, new Rectangle(5, 6, 5, 5));
                G.FillEllipse(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(5, 5, 5, 5));
            }
            DrawText(HorizontalAlignment.Left, this.ForeColor, 18, 1);
        }
    }

}


