// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.VibeLander
{

    public class VibeProgressBar : ThemeControl
    {
        private int _Maximum;
        bool Gloss;
        bool Vertical = true;
        public bool VerticalAlignment
        {
            get { return Vertical; }
            set
            {
                Vertical = value;
                Invalidate();
            }
        }
        public bool Glossy
        {
            get { return Gloss; }
            set
            {
                Gloss = value;
                Invalidate();
            }
        }
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {


                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }
        public override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.Transparent);
            int s = 0;
            Pen pe = new Pen(Color.FromArgb(34, 112, 171), 1);
            LinearGradientBrush xe = new LinearGradientBrush(ClientRectangle, Color.FromArgb(31, 119, 181), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
            G.FillPath(xe, Draw.RoundRect(ClientRectangle, 4));
            G.DrawPath(pe, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
            G.DrawLine(new Pen(Color.FromArgb(65, 131, 197, 241)), 2, 1, Width - 3, 1);

            //Fill
            if (_Value > 1)
            {
                if (Vertical)
                {
                    s = (Height - Convert.ToInt32(_Value / _Maximum * Height));

                    if (Glossy)
                    {
                        Pen p = new Pen(Color.FromArgb(34, 112, 171), 1);
                        LinearGradientBrush x = new LinearGradientBrush(ClientRectangle, Color.FromArgb(51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
                        G.FillPath(x, Draw.RoundRect(new Rectangle(2, s + 3, Width - 5, Convert.ToInt32(_Value / _Maximum * Height) - 6), 4));
                        DrawGradient(Color.FromArgb(50, Color.White), Color.Transparent, 4, s + 3, 10, Convert.ToInt32(_Value / _Maximum * Height) - 7, 270);
                        G.DrawPath(p, Draw.RoundRect(new Rectangle(2, s + 3, Width - 5, Convert.ToInt32(_Value / _Maximum * Height) - 6), 3));
                        G.DrawLine(new Pen(Color.FromArgb(90, 131, 197, 241)), 4, s + 4, Width - 6, s + 4);
                    }
                    else if (!Glossy)
                    {
                        Pen p = new Pen(Color.FromArgb(34, 112, 171), 1);
                        LinearGradientBrush x = new LinearGradientBrush(ClientRectangle, Color.FromArgb(51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
                        G.FillPath(x, Draw.RoundRect(new Rectangle(2, s + 3, Width - 5, Convert.ToInt32(_Value / _Maximum * Height) - 6), 4));
                        G.DrawPath(p, Draw.RoundRect(new Rectangle(2, s + 3, Width - 5, Convert.ToInt32(_Value / _Maximum * Height) - 6), 3));
                        G.DrawLine(new Pen(Color.FromArgb(90, 131, 197, 241)), 4, s + 4, Width - 6, s + 4);

                    }
                }
                else if (!Vertical)
                {
                    s = (Height - Convert.ToInt32(_Value / _Maximum * Width));

                    if (Glossy)
                    {
                        Pen p = new Pen(Color.FromArgb(34, 112, 171), 1);
                        LinearGradientBrush x = new LinearGradientBrush(ClientRectangle, Color.FromArgb(51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
                        G.FillPath(x, Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 5), 4));
                        G.DrawLine(new Pen(Color.FromArgb(90, 131, 197, 241)), 4, 3, Convert.ToInt32(_Value / _Maximum * Width) - 7, 3);
                        DrawGradient(Color.FromArgb(60, Color.White), Color.Transparent, 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 7, Height / 2 - 3, 0);
                        G.DrawPath(p, Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 5), 3));

                    }
                    else if (!Glossy)
                    {

                        Pen p = new Pen(Color.FromArgb(34, 112, 171), 1);
                        LinearGradientBrush x = new LinearGradientBrush(ClientRectangle, Color.FromArgb(51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
                        G.FillPath(x, Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 5), 4));
                        G.DrawLine(new Pen(Color.FromArgb(90, 131, 197, 241)), 4, 3, Convert.ToInt32(_Value / _Maximum * Width) - 7, 3);
                        G.DrawPath(p, Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 5), 3));
                    }
                }
            }

            //Borders

        }
        public void Increment(int Amount)
        {
            if (this.Value + Amount > Maximum)
            {
                this.Value = Maximum;
            }
            else
            {
                this.Value += Amount;
            }
        }

        public VibeProgressBar()
        {
            this.Value = 0;
            this.Maximum = 100;
            AllowTransparent();
        }
    }
}

