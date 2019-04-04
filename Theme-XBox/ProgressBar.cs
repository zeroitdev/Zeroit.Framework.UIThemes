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

namespace Zeroit.Framework.UIThemes.Xbox
{

    public class XboxProgressBar : ThemeControl
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

        public override void PaintHook()
        {
            G.Clear(Color.LightGray);
            DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, Width, 20, 90);
            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            DrawBorders(Pens.DarkGreen, Pens.LawnGreen, ClientRectangle);
            DrawCorners(Color.Black, ClientRectangle);
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    2:
                    DrawGradient(Color.DarkGreen, (Color.FromArgb(18, 255, 0)), 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 6, 90);
                    DrawGradient(Color.DarkGreen, (Color.FromArgb(18, 255, 0)), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 8, Height - 8, 90);
                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    0:
                    DrawGradient(Color.DarkGreen, (Color.FromArgb(18, 255, 0)), 3, 3, Convert.ToInt32(_Value / _Maximum * Width), Height - 6, 90);
                    DrawGradient(Color.DarkGreen, (Color.FromArgb(18, 255, 0)), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 2, Height - 8, 90);
                    break;
            }

        }
    }

}


