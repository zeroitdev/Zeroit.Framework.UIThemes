// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashProgressBar : Control
    {
        #region  Properties 

        private int _Maximum;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
                Invalidate();
            }
        }

        private int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                Invalidate();
            }
        }

        #endregion

        public GreywashProgressBar()
        {
            Maximum = 100;
            Minimum = 0;
            Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            G.DrawRectangle(new Pen(Color.DarkGray), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(0, 0, Width - 1, Height - 1));
            
            if (_Value > 2)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
            }
            
            else if (_Value > 0)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
            }
        }

    }

}
