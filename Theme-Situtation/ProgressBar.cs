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

namespace Zeroit.Framework.UIThemes.Situa
{
    public class SProgressBar : ThemeControl
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

        private int _Value = 25;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                if (value < 1)
                    value = 1;
                _Value = value;
                Invalidate();
            }
        }

        public override void PaintHook()
        {
            G.Clear(Color.DarkSlateGray);
            if ((_Value > 0))
            {
                DrawGradient(Color.Black, Color.DarkSlateGray, 0, 0, Convert.ToInt32((_Value / _Maximum) * Width), Height, 90);
            }
            G.DrawRectangle(Pens.DarkSlateGray, 0, 0, Width - 1, Height - 1);
            DrawBorders(Pens.LightBlue, Pens.DarkSlateGray, ClientRectangle);
        }
    }

}
