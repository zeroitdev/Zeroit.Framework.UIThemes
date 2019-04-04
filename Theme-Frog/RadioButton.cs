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

namespace Zeroit.Framework.UIThemes.Frog
{

    //Skidded form Mava~
    public class FrogRadioButton : ThemeControl154
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
                if (C.GetType().ToString() == String.Format(Application.ProductName, " ", "_") + ".RadioButton")
                {
                    RadioButton CC = null;
                    CC = (RadioButton)C;
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
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
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
            G.Clear(Color.FromArgb(255, 60, 60, 60));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Color Border = Color.FromArgb(160, GetColor("Border"));
            LinearGradientBrush LGBNone = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 50, 50, 50));
            LinearGradientBrush LGBOver = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 40, 40, 40));
            LinearGradientBrush LGBDown = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 30, 30, 30));


            switch (State)
            {
                case MouseState.Down:
                    G.FillEllipse(LGBDown, 1, 1, 15, 15);
                    break;
                case MouseState.None:
                    G.FillEllipse(LGBNone, 1, 1, 15, 15);
                    break;
                case MouseState.Over:
                    G.FillEllipse(LGBOver, 1, 1, 15, 15);
                    break;
            }

            G.DrawEllipse(Pens.Black, 0, 0, 16, 16);
            G.DrawEllipse(new Pen(GetColor("Border")), 1, 1, 14, 14);

            if ((_Checked))
            {
                G.FillEllipse(new SolidBrush(GetColor("Border")), 5, 5, 6, 6);
            }

            G.DrawString(Text, Font, new SolidBrush(GetColor("Border")), 18, 2);
        }
    }


}

