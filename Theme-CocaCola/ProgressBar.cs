// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCProgressBar : ThemeControl151
    {

        public CCProgressBar()
        {
        }
        private int _maximum;
        public int maximum
        {
            get { return _maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _value)
                    _value = value;


                _maximum = value;
                Invalidate();
            }
        }
        private int _value;
        public int value
        {
            get { return _value; }
            set
            {
                if (value > _maximum)
                    value = maximum;
                _value = value;
                Invalidate();
            }
        }


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(192, 0, 0));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)), 1);

            G.FillRectangle(Brushes.White, 0, 0, Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.WhiteSmoke, 0, Convert.ToInt32((Height / 4)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.LightGray, 0, Convert.ToInt32((Height / 3)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.LightGray, 0, Convert.ToInt32((Height / 3)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.Silver, 0, Convert.ToInt32((Height / 2)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.DrawRectangle(Pens.RosyBrown, 0, 0, Width - 1, Height - 1);

        }
    }


}

