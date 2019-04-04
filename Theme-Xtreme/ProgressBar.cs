// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Xtreme
{
    public class XtremeIncProgressbar : ThemeControl154
    {

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                if (value < 0)
                    value = 0;

                _Value = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (_Value > value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.Black, Color.FromArgb(40, 40, 40), 0, 0, Width, Height, 2);

            DrawGradient(Color.FromArgb(165, 0, 0), Color.FromArgb(255, 0, 0), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height / 2);

            DrawBorders(Pens.Black);
            DrawBorders(Pens.Black, 2);
            DrawBorders(new Pen(Color.FromArgb(69, 71, 70)), 1);
            DrawGradient(Color.White, Color.Black, 0, 0, Width / 4, 1, 360);
            DrawGradient(Color.White, Color.Black, 0, 0, 1, Height / 2);
        }
    }

}


