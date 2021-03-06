﻿// ***********************************************************************
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

namespace Zeroit.Framework.UIThemes.Evolve
{

    public class EvolveRadiobutton : ThemeControl154
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
                if (C.GetType().ToString() == String.Format(Application.ProductName.ToString(), ".XtremeRadiobutton"))
                {
                    EvolveRadiobutton CC = null;
                    CC = (EvolveRadiobutton)C;
                    CC.Checked = false;
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
            G.Clear(Color.FromArgb(47, 47, 47));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (_Checked == false)
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(112, 112, 112), Color.FromArgb(25, 25, 25), 90f);
                G.FillEllipse(Gbrush, new Rectangle(1, 1, 14, 14));
                Gbrush = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(76, 76, 76), Color.FromArgb(25, 25, 25), 90f);
                G.FillEllipse(Gbrush, new Rectangle(2, 2, 12, 12));
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.Black), 0, 0, 16, 16);
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(1, 1, 14, 14), Color.FromArgb(181, 93, 93), Color.FromArgb(80, 10, 10), 90f);
                G.FillEllipse(Gbrush, new Rectangle(1, 1, 14, 14));
                Gbrush = new LinearGradientBrush(new Rectangle(2, 2, 12, 12), Color.FromArgb(160, 53, 53), Color.FromArgb(100, 13, 13), 90f);
                G.FillEllipse(Gbrush, new Rectangle(2, 2, 12, 12));
                G.FillEllipse(Brushes.Black, new Rectangle(5, 6, 5, 5));
                G.FillEllipse(Brushes.White, new Rectangle(5, 5, 5, 5));
            }

            G.DrawString(Text, Font, Brushes.Black, 18, 2);
            G.DrawString(Text, Font, Brushes.White, 18, 1);
        }

        public EvolveRadiobutton()
        {
            this.Size = new Size(50, 14);
        }
    }


}


