// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GrayProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterGreyProgressbar : ThemeControl154
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

        public BoosterGreyProgressbar()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            DrawGradient(Color.FromArgb(129, 129, 129), Color.FromArgb(75, 75, 75), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height);
            G.DrawLine(new Pen(Color.FromArgb(182, 182, 182)), 0, 2, Convert.ToInt32((_Value / _Maximum) * Width - 2), 2);

            CreateRound(0, 0, Width, Height, 5);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(91, 91, 91)), 1);
            DrawCorners(BackColor);
        }
    }
    
}

