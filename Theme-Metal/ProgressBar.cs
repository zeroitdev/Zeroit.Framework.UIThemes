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

namespace Zeroit.Framework.UIThemes.Metal
{
    public class ProgressBar : ThemeControl
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
        Pen Border = new Pen(Color.FromArgb(90, 90, 90));
        SolidBrush UpperColor = new SolidBrush(Color.FromArgb(70, 70, 70));
        SolidBrush LowerColor = new SolidBrush(Color.FromArgb(55, 55, 55));

        public override void PaintHook()
        {
            DrawGradient(Color.FromArgb(140, 140, 140), Color.FromArgb(221, 239, 249), 0, 0, Width, 60, 90);
            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), Height - 2);
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), (Height - 2) / 2);
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1);
            //                                 
            DrawBorders(new Pen(Color.FromArgb(120, 120, 120)), new Pen(Color.FromArgb(150, 150, 150)), ClientRectangle);
            DrawCorners(Color.FromArgb(63, 63, 63), ClientRectangle);


        }
    }


}