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

namespace Zeroit.Framework.UIThemes.Somnium
{
    public class SomniumProgressBar : ThemeControl151
    {
        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }

        private int _Value = 50;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        //G.Clear
        private Color C1;
        private Color C2;
        //Lime Gradient
        private Color C3;
        //DrawRectangle
        private Pen P1;
        //Gloss
        private Brush B1;
        public SomniumProgressBar()
        {
            Size = new Size(75, 18);
        }
        protected override void ColorHook()
        {
            C1 = Color.FromArgb(15, 15, 15);
            C2 = Color.FromArgb(50, 50, 50);
            C3 = Color.FromArgb(0, 0, 0);
            P1 = Pens.Black;
            B1 = new SolidBrush(Color.FromArgb(50, Color.White));
        }

        protected override void PaintHook()
        {
            G.Clear(C1);
            if ((_Value > 0))
            {
                DrawGradient(C2, C3, 0, 0, Convert.ToInt32((_Value / _Maximum) * Width), Height, 90);
            }
            G.FillRectangle(B1, 0, 0, Width, Convert.ToInt32(Height / 2));
            DrawBorders(P1, 0, 0, Width, Height);
        }
    }

}


