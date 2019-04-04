// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Bar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Destiny
{
    public class Destiny_Bar : ThemeControl
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

        public Destiny_Bar()
        {
            AllowTransparent();
        }

        Pen Border = new Pen(Color.FromArgb(82, 128, 145));
        Color T = Color.Transparent;
        Color BackClr = Color.Black;
        SolidBrush UpperColor = new SolidBrush(Color.Teal);

        SolidBrush LowerColor = new SolidBrush(Color.DarkCyan);
        public override void PaintHook()
        {
            G.Clear(BackClr);

            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), Height - 2);
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), (Height - 2) / 2);
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1);

            DrawText(HorizontalAlignment.Center, ForeColor, 0);

            DrawCorners(BackClr, ClientRectangle);
        }
    }

}


