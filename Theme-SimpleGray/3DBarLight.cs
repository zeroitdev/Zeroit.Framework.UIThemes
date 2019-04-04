// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="3DBarLight.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGray3DBarLight : ThemeControl
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

        public SimplyGray3DBarLight()
        {
            AllowTransparent();
            ForeColor = Color.White;
        }

        Color Gr = Color.Gray;
        Brush SBr = Brushes.Silver;
        Pen P = Pens.DarkGray;
        Brush Br = Brushes.DarkGray;

        Color T = Color.Transparent;

        public override void PaintHook()
        {
            G.Clear(Gr);

            G.DrawRectangle(P, 0, 0, Width - 1, Height - 1);
            G.FillRectangle(Br, 0, 0, Convert.ToInt32((_Value / _Maximum) * Width), Height);
            G.FillRectangle(SBr, 0, 0, Convert.ToInt32((_Value / _Maximum) * Width), Height / 2);

            DrawText(HorizontalAlignment.Center, ForeColor, 0);

            DrawCorners(T, ClientRectangle);
        }
    }

}

