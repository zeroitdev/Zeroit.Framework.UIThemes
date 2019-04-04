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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Electric
{
    public class ElectricProgressBar : ThemeControl
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

        public ElectricProgressBar()
        {
            AllowTransparent();
            ForeColor = Color.White;
        }

        Pen Border = new Pen(Color.FromArgb(82, 128, 145));
        Color T = Color.Transparent;
        Color BackClr = Color.FromArgb(26, 100, 127);
        SolidBrush UpperColor = new SolidBrush(Color.FromArgb(50, 121, 148));

        SolidBrush LowerColor = new SolidBrush(Color.FromArgb(25, 105, 135));
        public override void PaintHook()
        {
            G.Clear(BackClr);
            //Background color of the control

            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), Height - 2);
            //      \
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), (Height - 2) / 2);
            // > Draw the colors and the border
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1);
            //                                  /

            DrawText(HorizontalAlignment.Center, ForeColor, 0);
            //Text

            DrawCorners(BackClr, ClientRectangle);
            //Corners..
        }
    }


}


