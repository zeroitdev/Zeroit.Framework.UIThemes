// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGrayProgressBar : ThemeControl
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


        private int _Value;
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

        public SimplyGrayProgressBar()
        {
            AllowTransparent();
        }

        Color Gr = Color.Gray;
        Pen P = new Pen(Color.FromArgb(60, 60, 60));
        Brush Br = Brushes.DarkGray;

        Color T = Color.Transparent;
        public override void PaintHook()
        {
            G.Clear(Gr);

            G.FillRectangle(Br, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), Height - 2);
            G.DrawRectangle(P, 0, 0, Width - 1, Height - 1);

            DrawCorners(T, ClientRectangle);
        }
    }

}

