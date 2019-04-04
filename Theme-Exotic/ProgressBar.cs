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


namespace Zeroit.Framework.UIThemes.Exotic
{
    public class ExoticProgressBar : ThemeControl
    {
        private int _Maximum;
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
                Maximum = 100;
                _Value = value;
                Invalidate();
            }
        }
        public override void PaintHook()
        {
            G.Clear(Color.Black);
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    2:
                    DrawGradient(Color.FromArgb(240, 248, 250), Color.FromArgb(0, 0, 0), 3, 3, Convert.ToInt32(_Value / _Maximum * Width) - 6, Height - 6, 90);
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(240, 248, 250), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 8, Height - 8, 90);
                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    0:
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(240, 248, 250), 3, 3, Convert.ToInt32(_Value / _Maximum * Width), Height - 6, 90);
                    DrawGradient(Color.FromArgb(240, 240, 250), Color.FromArgb(0, 0, 0), 4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 2, Height - 8, 90);
                    break;
            }
            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(Pens.AliceBlue, 1, 1, Width - 5, Height - 5);
        }
    }


}


